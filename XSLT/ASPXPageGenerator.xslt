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
      <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\UI\FinalResultWebUIDesignClasses\'"/>
      <xsl:variable name="filename" select="concat($dirname,@Name,'Edit','.aspx')"/>
      <xsl:result-document method="text" href="{$filename}">

          <xsl:choose>
              <xsl:when test ="@Name = 'sysdiagram'">
              </xsl:when>
              <xsl:otherwise>
                  <xsl:variable name="properties" select="orm:Properties/orm:Property[@Display='true']" />

                  <xsl:variable name="ObjectName" select="@Name"/>

                  <xsl:call-template name="header">
                      <xsl:with-param name="objectname" select="$ObjectName"/>
                  </xsl:call-template>
                  <xsl:call-template name="ContentPlaceHolder1"/>
                  <xsl:call-template name="ContentPlaceHolder2">
                      <xsl:with-param name="properties" select="$properties"/>
                  </xsl:call-template>
              </xsl:otherwise>
          </xsl:choose>
          
        
        

      </xsl:result-document>
    </xsl:for-each>
  </xsl:template>

  <!--<xsl:variable name ="objectname" select="//orm:Object/@Name"/>
  <xsl:variable name="properties" select="//orm:Object[@Name=$objectname]//orm:Properties/orm:Property[@Display='true']"/>-->

  <xsl:template name ="header">
    <xsl:param name="objectname"/>
    &lt;%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#"
    AutoEventWireup="true" CodeBehind="<xsl:value-of select="$objectname"/>Edit.aspx.cs"  Inherits="ASPWebApplication.<xsl:value-of select="$objectname"/>Edit" %&gt;
  </xsl:template>

  <xsl:template name ="ContentPlaceHolder1">
    &lt;asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server"&gt;
    &lt;/asp:Content &gt;
  </xsl:template>
  <xsl:template name="ContentPlaceHolder2">
    <xsl:param name="properties"/>
    &lt;asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server"&gt;
    &lt;table&gt;
      &lt;asp:HiddenField ID="hdnID" runat="server" /&gt;
    <xsl:call-template name="CreateRows">
      <xsl:with-param name="properties" select="$properties"/>
    </xsl:call-template>
      &lt;tr&gt;
          &lt;td&gt;&lt;asp:Button runat="server" ID="btnSave" Text="Save" OnClick="SaveButtonEvent"/&gt;&lt;/td&gt;
          &lt;td&gt;&lt;asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="DeleteButton"/&gt;&lt;/td&gt;      
      <xsl:for-each select="orm:ChildCollection">
          &lt;td&gt;&lt;asp:Button runat="server" ID="btnLoadChildren<xsl:value-of select="@ObjectName"/>" Text="Load <xsl:value-of select="@ObjectName"/> children" OnClick="LoadChildren<xsl:value-of select="@ObjectName"/>"&gt;&lt;/asp:Button&gt;&lt;/td&gt;
      </xsl:for-each>
      &lt;td&gt;&lt;asp:HyperLink ID="hypGoBack" runat="server" NavigateUrl="<xsl:value-of select="@Name"/>List.aspx"&gt;Go Back&lt;/asp:HyperLink&gt;&lt;/td&gt;
      &lt;/tr&gt;
    &lt;/table&gt;
    &lt;/asp:Content&gt;
  </xsl:template>

  <xsl:template name="CreateRows">
    <xsl:param name="properties"/>
    <xsl:for-each select="$properties">
      &lt;tr&gt;
      &lt;td&gt;
      &lt;asp:Label runat="server" Text="<xsl:value-of select="@Name"/>" /&gt;
      &lt;/td&gt;
      &lt;td&gt;
      <xsl:choose>
        <xsl:when test="@ControlPrefix='txt' and @NETType='System.Int32'">
          &lt;asp:TextBox runat="server" ID="<xsl:value-of select ="@ControlName"/>"/&gt;
          <!--&lt;asp:CustomValidator ID="CustomValidator<xsl:value-of select ="@ControlName"/>" runat="server" OnServerValidate="<xsl:value-of select ="@ControlName"/>Validation" ControlToValidate="<xsl:value-of select ="ControlName"/>" ErrorMessage="Input could not be parsed to integer number!!!" ValidationGroup="int"&gt;
          &lt;/asp:CustomValidator&gt;-->
        </xsl:when>
        <xsl:when test="@ControlPrefix='txt'">
          &lt;asp:TextBox runat="server" ID="<xsl:value-of select ="@ControlName"/>"/&gt;
        </xsl:when>
      </xsl:choose>
      <xsl:choose>
        <xsl:when test="@ControlPrefix='cbo'">
          &lt;asp:DropDownList runat="server" ID="<xsl:value-of select ="@ControlName"/>"&gt;&lt;/asp:DropDownList&gt;
        </xsl:when>
        <xsl:when test="orm:Property/@ControlPrefix='chk'">
          &lt;asp:CheckBox runat="server" ID="<xsl:value-of select ="@ControlName"/>" Checked="True"&gt;&lt;/asp:CheckBox&gt;
        </xsl:when>
        <xsl:when test="orm:Property/@ControlPrefix='dtp'">
          &lt;asp:Calendar runat="server" ID="<xsl:value-of select ="@ControlName"/>"&gt;&lt;/asp:Calendar&gt;
        </xsl:when>
      </xsl:choose>
      &lt;/td&gt;
      &lt;/tr&gt;
        &lt;tr&gt;
        <!--&lt;td&gt;
        &lt;asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="DeleteButton"/&gt;
        &lt;/td&gt;-->
        &lt;/tr&gt;
    </xsl:for-each>
      
     
  </xsl:template>
</xsl:stylesheet>
