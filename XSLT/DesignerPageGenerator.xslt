<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:orm="http://stefan/ORM.xsd"
>
    <xsl:output method="text" indent="yes"/>

  <xsl:template match="@* | node()">
    <xsl:copy>
      <xsl:apply-templates select="//orm:Assembly//orm:Objects" mode="Object"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="orm:Objects" mode="Object">

    <xsl:for-each select="orm:Object">
      <xsl:variable name="dirname" select ="'..\..\UI\FinalResultWebUIDesignClasses\'"/>
      <xsl:variable name="filename" select="concat($dirname,@Name,'Edit','.aspx.designer.cs')"/>
      <xsl:result-document method="text" href="{$filename}">
        <xsl:variable name="properties"
              select="orm:Properties/orm:Property[@Display='true']" />

        

        <xsl:call-template name="Main">
          <xsl:with-param name="objectname" select="@Name"/>
          <xsl:with-param name="properties" select="$properties"/>
        </xsl:call-template>
        
      </xsl:result-document>
    </xsl:for-each>
  </xsl:template>
  <xsl:template name="Main">
    <xsl:param name="objectname"/>
    <xsl:param name="properties"/>
    namespace WebUI
    {
    partial class <xsl:value-of select="@Name"/>Edit {

    <!--<xsl:variable name ="objectname" select="//orm:Object/@Name"/>
    <xsl:variable name="properties" select="//orm:Object[@Name=$objectname]//orm:Properties/orm:Property[@Display='true']"/>-->    
    
    <xsl:for-each select="$properties">
      <xsl:choose>
        <xsl:when test="@ControlPrefix='txt'">
          protected global::System.Web.UI.WebControls.TextBox <xsl:text/> <xsl:value-of select="@ControlName"/>;
          protected global::System.Web.UI.WebControls.Label <xsl:text/> <xsl:value-of select="@Name"/>;
        </xsl:when>
        <xsl:when test="@ControlPrefix='cbo'">
          protected global::System.Web.UI.WebControls.DropDownList <xsl:text/> <xsl:value-of select="@ControlName"/>;
          protected global::System.Web.UI.WebControls.Label <xsl:text/> <xsl:value-of select="@Name"/>;
        </xsl:when>
        <xsl:when test="@ControlPrefix='chk'">
          protected global::System.Web.UI.WebControls.CheckBox <xsl:text/> <xsl:value-of select="@ControlName"/>;
          protected global::System.Web.UI.WebControls.Label <xsl:text/> <xsl:value-of select="@Name"/>;
        </xsl:when>
        <xsl:when test="@ControlPrefix='dtp'">
          protected global::System.Web.UI.WebControls.Calendar <xsl:text/> <xsl:value-of select="@ControlName"/>;
          protected global::System.Web.UI.WebControls.Label <xsl:text/> <xsl:value-of select="@Name"/>;
        </xsl:when>
      </xsl:choose>
    </xsl:for-each>
      protected global::System.Web.UI.WebControls.HiddenField hdnID;
      protected global::System.Web.UI.WebControls.Button btnSave;
      protected global::System.Web.UI.WebControls.Button btnDelete;
      }
      }
  </xsl:template>
</xsl:stylesheet>
