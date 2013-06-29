<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:dbs="http://stefan/DbStructure"
			xmlns:orm="http://stefan/ORM.xsd"
			xmlns:ui="http://stefan/UserInterface"
>

  <xsl:variable name="winnamespace" select="'WinFormPatternApplication'" />
  <xsl:variable name="fudge">
    <xsl:choose>
      <xsl:when test="position()=1">3</xsl:when>
      <xsl:otherwise>0</xsl:otherwise>
    </xsl:choose>
  </xsl:variable>
  <!--<xsl:variable name="top" select="$vmargin+(position()-1)*($height+$vmargin) - $fudge"/>-->
  <!--<xsl:variable name="tabindex" select="(position()-1)*2"/>-->

  <xsl:variable name="fugna" select="70"/>

  <!--<xsl:variable name="height"
             select="//ui:Form[@Name=$Name]/@Height" />
  <xsl:variable name="vmargin"
                 select="//ui:Form[@Name=$Name]/@VerticalMargin" />
  <xsl:variable name="hmargin"
                 select="//ui:Form[@Name=$Name]/@HorizontalMargin" />
  <xsl:variable name="labelwidth"
                 select="//ui:Form[@Name=$Name]/@LabelWidth" />
  <xsl:variable name="btnwidth"
                 select="//ui:Form[@Name=$Name]/@ButtonWidth" />
  <xsl:variable name="btnheight"
                 select="//ui:Form[@Name=$Name]/@ButtonHeight" />
  <xsl:variable name="formwidth"
                 select="//ui:Form[@Name=$Name]/@FormWidth" />
  <xsl:variable name="formheight"
                 select="//ui:Form[@Name=$Name]/@FormHeight" />-->
  <!--<xsl:variable name="properties"
              select="orm:Object/orm:Properties/orm:Property[@Display='true']" />-->

  <!--<xsl:variable name="childcollections"
              select="//orm:Object[@Name=$objectname and not(@IsLookup='true')]/orm:ChildCollection" />-->

  <xsl:output method="text" encoding="utf-8" indent="yes" />

  <xsl:template match="@* | node()">
    <xsl:variable name="allForms" select="//ui:Forms//ui:Form"/>    
    <xsl:copy>
      <xsl:apply-templates select="//orm:Assembly//orm:Objects" mode="Object">
        <xsl:with-param name="forms" select="$allForms"/>
      </xsl:apply-templates>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="orm:Objects" mode="Object">
    <xsl:param name="forms"/>
    <xsl:for-each select="orm:Object">
      <xsl:variable name="dirname" select ="'..\..\UI\FinalResultWinUIDesignClasses\'"/>
      <xsl:variable name="filename" select="concat($dirname,@Name,'Edit','.Designer.cs')"/>
      <xsl:result-document method="text" href="{$filename}">
        <xsl:variable name="properties"
              select="orm:Properties/orm:Property[@Display='true']" />


        <xsl:variable name="ObjectName" select="@Name"/>
        <xsl:variable name="currentForm"
                   select="$forms[@Name = concat($ObjectName, 'Edit')]"/>

        namespace <xsl:value-of select="$winnamespace"/>
        {
        partial class <xsl:value-of select="@Name"/>Edit
        {
        private System.ComponentModel.IContainer components = null;

        <xsl:call-template name="DisposeMethod"/>
        <xsl:call-template name="InitializeComponentMethod">
          <xsl:with-param name="props" select="$properties"/>
          <xsl:with-param name="form" select="$currentForm"/>
        </xsl:call-template>
        <xsl:call-template name="FormFields">
          <xsl:with-param name="props" select="$properties"/>
        </xsl:call-template>
        }
        }
      </xsl:result-document>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name ="DisposeMethod">
    protected override void Dispose(bool disposing)
    {
    if (disposing &amp;&amp; (components != null))
    {
    components.Dispose();
    }
    base.Dispose(disposing);
    }
  </xsl:template>

  <xsl:template name="InitializeComponentMethod">
    <xsl:param name="props"/>
    <xsl:param name="form"/>
    protected void InitializeComponent()
    {

    <xsl:call-template name="InitLabel">
      <xsl:with-param name="form" select="$form"/>
      <xsl:with-param name="props" select="$props"/>
    </xsl:call-template>

    <xsl:for-each select="$props">
      this.<xsl:value-of select="@ControlName"/>= <xsl:choose>
        <xsl:when test="@ControlPrefix='txt'">new System.Windows.Forms.TextBox();</xsl:when>
        <xsl:when test="@ControlPrefix='cbo'">new System.Windows.Forms.ComboBox();</xsl:when>
        <xsl:when test="@ControlPrefix='dtp'">new System.Windows.Forms.DateTimePicker();</xsl:when>
        <xsl:when test="@ControlPrefix='chk'">new System.Windows.Forms.CheckBox();</xsl:when>
      </xsl:choose>
    </xsl:for-each>
    this.hdnID = new System.Windows.Forms.TextBox();
    <xsl:call-template name="SetPropertiesForControls">
      <xsl:with-param name="form" select="$form"/>
      <xsl:with-param name="props" select="$props"/>
    </xsl:call-template>
    <xsl:call-template name="AddControlsToForm">
      <xsl:with-param name="props" select="$props"/>
    </xsl:call-template>
    <!--<xsl:apply-templates select="//ui:Form[@BusinessObject = @Name]" mode="Form"/>-->
    <xsl:call-template name="InitializeForm">
      <xsl:with-param name="form" select="$form"/>
    </xsl:call-template>
    }
  </xsl:template>

  <!--Sredjeno-->
  <xsl:template name="FormFields">
    <xsl:param name="props"/>
    <xsl:call-template name="AddLabel">
      <xsl:with-param name="props" select="$props"/>
    </xsl:call-template>
    <xsl:for-each select="$props">
      private  <xsl:value-of select="@ControlType"/>  <xsl:text> </xsl:text> <xsl:value-of select="@ControlName"/>;
    </xsl:for-each>
    private System.Windows.Forms.TextBox hdnID;
  </xsl:template>

  <!--Potebni podaci o formatu kontrola na formi-->
  <xsl:template name="InitializeForm" match="//ui:Form" mode="Form">
    <xsl:param name="form"/>
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(<xsl:text/>
    <xsl:value-of select="$form/@FormWidth"/>, <xsl:text/>
    <xsl:value-of select="$form/@FormHeight"/>);
    this.Name = "<xsl:value-of select="@Name"/>";
    this.Text = "<xsl:value-of select="@Name"/>";
    this.ResumeLayout(false);
    this.PerformLayout();
  </xsl:template>

  <!--Sredjeno-->
  <xsl:template name="AddControlsToForm">
    <xsl:param name="props"/>
    <xsl:for-each select="$props">
      this.Controls.Add(this.<xsl:value-of select="@ControlName"/>);
      this.Controls.Add(this.lbl<xsl:value-of select="@Name"/>);
    </xsl:for-each>
  </xsl:template>

  <!--Sredjeno-->
  <xsl:template name="AddLabel" >
    <xsl:param name="props"/>
    <xsl:for-each select="$props">
      private System.Windows.Forms.Label lbl<xsl:value-of select="@Name"/>;
    </xsl:for-each>
  </xsl:template>

  <!--Sredjeni parametri, pokupi podatke iz forme-->
  <xsl:template name="InitLabel">
    <xsl:param name="form"/>
    <xsl:param name="props"/>
    <xsl:for-each select="$props">
      <xsl:variable name="top" select="$form/@VerticalMargin+(position()-1)*($form/@Height+$form/@VerticalMargin)"/>
      <xsl:variable name="tabindex" select="(position()-1)*2"/>
      this.lbl<xsl:value-of select="@Name"/> = new System.Windows.Forms.Label();
      this.lbl<xsl:value-of select="@Name"/>.AutoSize = true;
      this.lbl<xsl:value-of select="@Name"/>.Name = "lbl<xsl:value-of select="@Name"/>";
      this.lbl<xsl:value-of select="@Name"/>.Location = new System.Drawing.Point(<xsl:text/>
      <xsl:value-of select="$form/@HorizontalMargin"/>, <xsl:text/>
      <xsl:value-of select="$top"/>);
      this.lbl<xsl:value-of select="@Name"/>.Size = new System.Drawing.Size(<xsl:text/>
      <xsl:value-of select="$form/@LabelWidth"/>, <xsl:text/>
      <xsl:value-of select="$form/@Height"/>);
      this.lbl<xsl:value-of select="@Name"/>.TabIndex = <xsl:value-of select="$tabindex + 1"/>;
      this.lbl<xsl:value-of select="@Name"/>.Text = "<xsl:value-of select="@Name"/>";
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="DisplayCollectionsAsDataGrids">

  </xsl:template>

  <!--Sredjeni parametri, izvuci podatke iz forme-->
  <xsl:template name="SetPropertiesForControls">
    <xsl:param name="props"/>
    <xsl:param name="form"/>
    <xsl:variable name="top" select="$form/@VerticalMargin+(position()-1)*($form/@Height+$form/@VerticalMargin)"/>
    <xsl:variable name="tabindex" select="(position()-1)*2"/>
    <xsl:for-each select="$props">
      <!--this.<xsl:value-of select="@ControlName"/>.Location = new System.Drawing.Point(<xsl:text/>
      <xsl:value-of select="$hmargin"/>, <xsl:text/>
      <xsl:value-of select="$top"/>);-->
      this.<xsl:value-of select="@ControlName"/>.Location = new System.Drawing.Point(<xsl:text/>
      <xsl:value-of select="$form/@HorizontalMargin + $fugna"/>, <xsl:text/>
      <xsl:if test="position()=1">
        <xsl:value-of select="$top"/>
      </xsl:if>
      <xsl:if test="position() = 2">
        <xsl:value-of select="$top + position () * $form/@Height"/>
      </xsl:if>
      <!--<xsl:if test="position()!=2 and position() mod 2 = 0">
        <xsl:value-of select="$top + position () * $height +2*$height"/>
      </xsl:if>-->
      <xsl:if test="position()!=1 and position() != 2">
        <xsl:value-of select="$top + (position ()-1) * 2 * $form/@Height"/>
      </xsl:if>);

      this.<xsl:value-of select="@ControlName"/>.Name = "<xsl:value-of select="@Name"/>";
      this.<xsl:value-of select="@ControlName"/>.Size = new System.Drawing.Size(<xsl:text/>
      <xsl:value-of select="$form/@LabelWidth"/>, <xsl:text/>
      <xsl:value-of select="$form/@Height"/>);
      this.<xsl:value-of select="@ControlName"/>.TabIndex =<xsl:value-of select="$tabindex + 1"/>;
      <xsl:if test="@ControlPrefix!='txt'">
        this.<xsl:value-of select="@ControlName"/>.Text = "<xsl:value-of select="@Name"/>";
      </xsl:if>
      <xsl:if test="@ControlPrefix='cbo'">
        this.<xsl:value-of select="@ControlName"/>.FormattingEnabled = true;
      </xsl:if>
    </xsl:for-each>
    this.hdnID.Visible = false;
  </xsl:template>

</xsl:stylesheet>
