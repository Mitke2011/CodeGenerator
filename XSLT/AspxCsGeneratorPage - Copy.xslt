<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:orm="http://stefan/ORM.xsd"
                xmlns:ui="http://stefan/UserInterface"
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
            <xsl:variable name="filename" select="concat($dirname,@Name,'Edit','.aspx.cs')"/>
            <!--<xsl:result-document method="text" href="{$filename}">--> 
                <xsl:call-template name ="SaveButtonEvent"/>
            <!--</xsl:result-document>-->
        </xsl:for-each>
    </xsl:template>
        <xsl:template name="SaveButtonEvent">

        protected void SaveButtonEvent(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        <xsl:value-of select="@Name"/> objectClass = new <xsl:value-of select="@Name"/>();
        <xsl:call-template name="FillTheObjectFromForm"/>
        mm.Save(objectClass);
        }
    </xsl:template>
    <xsl:template name="FillTheObjectFromForm">
        <xsl:for-each select="orm:Properties/*">
            objectClass.<xsl:value-of select="@Name"/> = this.<xsl:choose>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false'">
                    <xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
                </xsl:when>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='true'">hdnID.Value;</xsl:when>
                <xsl:when test="@ControlPrefix ='cbo'">
                    <xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
                </xsl:when>
                <xsl:when test="@ControlPrefix ='dtp'">
                    <xsl:value-of select="@ControlName"/>.Value;
                </xsl:when>
                <xsl:when test="@ControlPrefix ='chk'">
                    <xsl:value-of select="@ControlName"/>.Checked;
                </xsl:when>
            </xsl:choose>            
        </xsl:for-each>
    </xsl:template>   
</xsl:stylesheet>
