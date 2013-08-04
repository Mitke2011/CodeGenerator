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
            <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\UI\FinalResultWebUIListDesignClasses\'"/>
            <xsl:variable name="filename" select="concat($dirname,@Name,'List','.aspx')"/>
            <xsl:result-document method="text" href="{$filename}">
                <xsl:variable name="properties"
                      select="orm:Properties/orm:Property[@Display='true']" />
                <xsl:variable name="ObjectName" select="@Name"/>
                <xsl:call-template name="header">
                    <xsl:with-param name="objectname" select="$ObjectName"/>
                </xsl:call-template>
                <xsl:call-template name="ContentPlaceHolder1"/>
                <xsl:call-template name="ContentPlaceHolder2"/>
            </xsl:result-document>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name ="header">
        <xsl:param name="objectname"/>
        &lt;%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#"
        AutoEventWireup="true" EnableViewState="false" CodeBehind="<xsl:value-of select="$objectname"/>List.aspx.cs"  Inherits="ASPWebApplication.<xsl:value-of select="$objectname"/>List" %&gt;
    </xsl:template>

    <xsl:template name ="ContentPlaceHolder1">
        &lt;asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server"&gt;
        &lt;/asp:Content &gt;
    </xsl:template>
    <xsl:template name="ContentPlaceHolder2">
        &lt;asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server"&gt;
        
        &lt;asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_OnRowCommand" OnRowCreated="GridView1_OnRowCreated"&gt;
        &lt;Columns&gt;
        &lt;asp:TemplateField ShowHeader="False"&gt;
        &lt;ItemTemplate&gt;
        &lt;asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Manage" CommandArgument='&lt;%# ((GridViewRow)Container).RowIndex %&gt;' /&gt;
        &lt;/ItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
        &lt;asp:TemplateField ShowHeader="False"&gt;
        &lt;ItemTemplate&gt;
        &lt;asp:Button ID="btnAddNew" runat="server" CausesValidation="false" CommandName="AddNew" Text="Add New"/&gt;
        &lt;/ItemTemplate&gt;
        &lt;/asp:TemplateField&gt;
        <!--&lt;asp:TemplateField ShowHeader="False"&gt;
        &lt;ItemTemplate&gt;
        &lt;asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" CommandArgument='&lt;%# ((GridViewRow)Container).RowIndex %&gt;' /&gt;
        &lt;/ItemTemplate&gt;
        &lt;/asp:TemplateField&gt;-->
        &lt;/Columns&gt;
        &lt;/asp:GridView&gt;
        &lt;/asp:Content &gt;
    </xsl:template>
    
</xsl:stylesheet>
