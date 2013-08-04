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
            <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\UI\FinalResultWebUIDesignClasses\'"/>
            <xsl:variable name="filename" select="concat($dirname,@Name,'Edit','.aspx.cs')"/>
            <xsl:result-document method="text" href="{$filename}">
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
                using Middletier;
                using ObjectClasses;

                namespace ASPWebApplication
                {
                public partial class <xsl:value-of select="@Name"/>Edit : System.Web.UI.Page
                {
                <xsl:variable name="IDPropName"
                      select="orm:Properties/orm:Property[@IsPrimaryKey='true']/@Name" />

                
                <xsl:call-template name="PageLoadingEvent">
                <xsl:with-param name="IDPropName" select="$IDPropName"/>
                </xsl:call-template>
                <xsl:call-template name ="SaveButtonEvent">

                </xsl:call-template>
                <xsl:call-template name="DeleteButtonEvent">

                </xsl:call-template>
                <xsl:call-template name="UpdateButtonEvent">

                </xsl:call-template>

                }
                }
            </xsl:result-document>
        </xsl:for-each>
    </xsl:template>


    <xsl:template name="PageLoadingEvent">
<xsl:param name="IDPropName"/>
        protected void Page_Load(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        if(!IsPostBack)
        {
        <xsl:value-of select="@Name"/> ob = new <xsl:value-of select="@Name"/>();
        int id;
        if (int.TryParse(Request.QueryString["objectid"],out id))
        {
        ob.<xsl:value-of select="$IDPropName"/> = id;
        ob =(<xsl:value-of select="@Name"/>) Convert.ChangeType(mm.FindOne(ob,true),typeof(<xsl:value-of select="@Name"/>));
        }


        <xsl:call-template name="FillTheFormUsingObject"/>
        }



        }
    </xsl:template>

    <xsl:template name="SaveButtonEvent">

        protected void SaveButtonEvent(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        <xsl:value-of select="@Name"/> objectClass = new <xsl:value-of select="@Name"/>();
        <xsl:call-template name="FillTheObjectFromForm">

        </xsl:call-template>
        if(Request.QueryString["objectid"]!=null)
        mm.Update(objectClass,true);
        else
        mm.Save(objectClass,true);
        }
    </xsl:template>

    <xsl:template name="SearchButtonEvent">

        protected void SearchForObject (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        <xsl:value-of select="@Name"/> objectClass = new <xsl:value-of select="@Name"/>();
        <xsl:call-template name="FillTheObjectFromForm">

        </xsl:call-template>
        mm.FindOne(objectClass,true);
        }
    </xsl:template>

    <xsl:template name ="DeleteButtonEvent">

        protected void DeleteButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        <xsl:value-of select="@Name"/> objectClass = new <xsl:value-of select="@Name"/>();
        <xsl:call-template name="FillTheObjectFromForm">

        </xsl:call-template>
        mm.Delete(objectClass,true);
        }
    </xsl:template>

    <xsl:template name="UpdateButtonEvent">

        protected void UpdateButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();

        <xsl:value-of select="@Name"/> objectClass = new <xsl:value-of select="@Name"/>();
        <xsl:call-template name="FillTheObjectFromForm">

        </xsl:call-template>

        mm.Update(objectClass,<!--"<xsl:value-of select="@TableName"/>",-->true);

        }
    </xsl:template>


    <xsl:template name="FillTheObjectFromForm">
        <xsl:for-each select="orm:Properties/*">
            objectClass.<xsl:value-of select="@Name"/> = <xsl:choose>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false' and @NETType='System.Int32'">
                    int.Parse(this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>);
                </xsl:when>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false' and @NETType='System.String'">
                    this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
                </xsl:when>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='true'">int.Parse(this.hdnID.Value);</xsl:when>
                <xsl:when test="@ControlPrefix ='cbo'">
                    int.Parse(this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>);
                </xsl:when>
                <xsl:when test="@ControlPrefix ='dtp'">
                    this.<xsl:value-of select="@ControlName"/>.SelectedDate;
                </xsl:when>
                <xsl:when test="@ControlPrefix ='chk'">
                    this.<xsl:value-of select="@ControlName"/>.Checked;
                </xsl:when>
            </xsl:choose>
            <!--objectClass.<xsl:value-of select="@Name"/> = this.<xsl:value-of select="@Name"/><xsl:if test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false'">
            <xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
        </xsl:if>
        <xsl:if test ="orm:Property/@ControlPrefix = 'txt' and orm:Property/@IsPrimaryKey='true'">hdnID.Value;</xsl:if>
        <xsl:if test="@ControlPrefix ='cbo'">
            <xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
        </xsl:if>
        <xsl:if test="@ControlPrefix ='dtp'">
            <xsl:value-of select="@ControlName"/>.Value;
        </xsl:if>
        <xsl:if test="@ControlPrefix ='chk'">
            <xsl:value-of select="@ControlName"/>.Checked;
        </xsl:if>-->
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="FillTheFormUsingObject">

        <!--<xsl:value-of select="@Name"/> classObject = new <xsl:value-of select="@Name"/>();-->
        <xsl:for-each select="orm:Properties/*">
            <!--this.<xsl:value-of select="orm:Property/@ControlName"/> =-->
            <xsl:choose>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false' and @NETType = 'System.String'">
                    this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>=ob.<xsl:value-of select="@Name"/>;
                </xsl:when>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false' and @NETType = 'System.Int32'">
                    this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>=ob.<xsl:value-of select="@Name"/>.ToString();
                </xsl:when>
                <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='true'">
                    this.hdnID.Value =ob.<xsl:value-of select="@Name"/>.ToString();
                </xsl:when>
                <xsl:when test="@ControlPrefix ='cbo'">
                    this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>=ob.<xsl:value-of select="@Name"/>.ToString();
                </xsl:when>
                <xsl:when test="@ControlPrefix ='dtp'">
                    this.<xsl:value-of select="@ControlName"/>.SelectedDate=ob.<xsl:value-of select="@Name"/>;
                </xsl:when>
                <xsl:when test="@ControlPrefix ='chk'">
                    this.<xsl:value-of select="@ControlName"/>.Checked=ob.<xsl:value-of select="@Name"/>.ToString();
                </xsl:when>
            </xsl:choose>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
