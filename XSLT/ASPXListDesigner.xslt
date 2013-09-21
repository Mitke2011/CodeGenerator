<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:orm="http://stefan/ORM.xsd"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="//orm:Assembly//orm:Objects" mode="Object"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="orm:Objects" mode="Object">

        <xsl:for-each select="orm:Object">
            <xsl:choose>
                <xsl:when test ="@Name = 'sysdiagram'">
                </xsl:when>
                <xsl:otherwise>
            <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\UI\FinalResultWebUIListDesignClasses\'"/>
            <xsl:variable name="filename" select="concat($dirname,@Name,'List','.aspx.designer.cs')"/>
            <xsl:result-document method="text" href="{$filename}">
                        <xsl:call-template name="Main">
                            <xsl:with-param name="objectname" select="@Name"/>
                        </xsl:call-template>                 
            </xsl:result-document>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="Main">
        <xsl:param name="objectname"/>
        namespace ASPWebApplication<!--<xsl:value-of select="namespace"/>-->{
        partial class <xsl:value-of select="@Name"/>List {

        protected global::System.Web.UI.WebControls.GridView GridView1;
        protected global::System.Web.UI.WebControls.HiddenField hdnID;
        }
        }
    </xsl:template>
</xsl:stylesheet>
