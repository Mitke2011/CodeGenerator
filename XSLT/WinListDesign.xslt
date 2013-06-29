<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:orm="http://stefan/ORM.xsd"
                xmlns:ui="http://stefan/UserInterface"
>
    
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
      <xsl:variable name="dirname" select ="'..\..\UI\FinalResultWinUIDesignListClasses\'"/>
      <xsl:variable name="filename" select="concat($dirname,@Name,'List','.Designer.cs')"/>
      <xsl:result-document method="text" href="{$filename}">
        <xsl:variable name="properties"
              select="orm:Properties/orm:Property[@Display='true']" />


        <xsl:variable name="ObjectName" select="@Name"/>
        <xsl:variable name="currentForm"
                   select="$forms[@Name = concat($ObjectName, 'Edit')]"/>

          namespace WinFormPatternApplication
        {
        partial class <xsl:value-of select="@Name"/>List
        {
        private System.ComponentModel.IContainer components = null;

        <xsl:call-template name="DisposeMethod"/>
        <xsl:call-template name="InitializeComponentMethod">
          <!--<xsl:with-param name="props" select="$properties"/>-->
          <xsl:with-param name="form" select="$currentForm"/>
        </xsl:call-template>
        <xsl:call-template name="FormFields">
          <!--<xsl:with-param name="props" select="$properties"/>-->
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
    
    <xsl:param name="form"/>
    protected void InitializeComponent()
    {

    this.dataGridView1 = new System.Windows.Forms.DataGridView();
    <xsl:call-template name="SetPropertiesForControls">
      <xsl:with-param name="form" select="$form"/>
     
    </xsl:call-template>
    <xsl:call-template name="AddControlsToForm">
      
    </xsl:call-template>
    
    <xsl:call-template name="InitializeForm">
      <xsl:with-param name="form" select="$form"/>
    </xsl:call-template>
    }
  </xsl:template>

  <xsl:template name="FormFields">
    private System.Windows.Forms.DataGridView dataGridView1;
  </xsl:template>

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
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
  </xsl:template>

  <xsl:template name="SetPropertiesForControls">
    
    <xsl:param name="form"/>
    <xsl:variable name="top" select="$form/@VerticalMargin+(position()-1)*($form/@Height+$form/@VerticalMargin)"/>
    <xsl:variable name="tabindex" select="(position()-1)*2"/>
          
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(579, 150);
            this.dataGridView1.TabIndex = 1;
  </xsl:template>
  
  <xsl:template name="AddControlsToForm">
    this.Controls.Add(this.dataGridView1);
  </xsl:template>
  
</xsl:stylesheet>
