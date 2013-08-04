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
        <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\UI\FinalResultWinUIDesignClasses\'"/>
        <xsl:variable name="filename" select="concat($dirname,@Name,'Edit','.cs')"/>
        <xsl:result-document method="text" href="{$filename}">
            using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Data;
            using System.Drawing;
            using System.Linq;
            using System.Text;
            using System.Windows.Forms;
            using Middletier;
            using ObjectClasses;

            namespace WinFormsApplication
            {
            partial class <xsl:value-of select="@Name"/>Edit:Form
            {
            <xsl:call-template name ="LoadFormEvent"/>
        <xsl:call-template name ="SaveAction"/>
        <!--<xsl:call-template name ="UpdateAction"/>-->
        <xsl:call-template name ="DeleteAction"/>
        <xsl:call-template name ="SearchAction"/>
          }
          }
        </xsl:result-document>
      </xsl:for-each>
    </xsl:template>
    
  <xsl:template name="LoadFormEvent">
    public <xsl:value-of select="@Name"/>Edit(int ID)
      {
      InitializeComponent();
      MiddletierManager mm = new MiddletierManager();
      <xsl:value-of select="@Name"/> ob = new <xsl:value-of select="@Name"/>();
      ob.<xsl:for-each select="orm:Properties/*"><xsl:if test="@IsPrimaryKey = 'true'" ><xsl:value-of select ="@Name"/></xsl:if></xsl:for-each>=ID;
      ob = (<xsl:value-of select="@Name"/>) mm.FindOne(ob,true);
      
      <xsl:call-template name="FillTheFormUsingObject"/>
      }
      
  public <xsl:value-of select="@Name"/>Edit()
      {
      InitializeComponent();
      this.hdnID.Text ="";
      }
  </xsl:template>

  <xsl:template name="SaveAction">
      private void btnSave_Click(object sender, EventArgs e)
      {
      <xsl:call-template name="FillTheObjectFromForm"/>
      MiddletierManager mm = new MiddletierManager();
      if(this.hdnID.Text.Equals(string.Empty))
      mm.Save( obj,true);
      else
      mm.Update( obj,true);
      
       <xsl:value-of select="@Name"/>List form = new <xsl:value-of select="@Name"/>List();
       form.Visible = true;
      }
  </xsl:template>

  <xsl:template name="UpdateAction">
      private void button2_Click(object sender, EventArgs e)
      {
      <xsl:call-template name="FillTheObjectFromForm"/>
      MiddletierManager mm = new MiddletierManager();
      mm.Update( obj,true);
  }
  </xsl:template>

  <xsl:template name="DeleteAction">
      private void btnDelete_Click(object sender, EventArgs e)
      {
      <xsl:call-template name="FillTheObjectFromForm"/>
      MiddletierManager mm = new MiddletierManager();
      if(!this.hdnID.Text.Equals(string.Empty))
      mm.Delete(obj,true);
      
      <xsl:value-of select="@Name"/>List form = new  <xsl:value-of select="@Name"/>List();
       form.Visible = true;
  }
  </xsl:template>

  <xsl:template name="SearchAction">
      private void button4_Click(object sender, EventArgs e)
      {
      <xsl:call-template name="FillTheObjectFromForm"/>
      MiddletierManager mm = new MiddletierManager();
      <xsl:value-of select="@Name"/> searchObject = (<xsl:value-of select="@Name"/>) mm.FindOne(obj,true);
    
  }
  </xsl:template>

    <xsl:template name="FillTheObjectFromForm">
        <xsl:value-of select="@Name"/> obj = new <xsl:value-of select="@Name"/>();
        int id = 0;
        int.TryParse(this.hdnID.Text, out id);
        <xsl:for-each select="orm:Properties/*">
        obj.<xsl:value-of select="@Name"/> = <xsl:choose>
            <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false' and @NETType='System.Int32'">
                int.Parse(this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>);
            </xsl:when>
            <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='false' and @NETType='System.String'">
                this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
            </xsl:when>
            <xsl:when test ="@ControlPrefix = 'txt' and @IsPrimaryKey='true'">
                id;
                <!--int id;
            if (int.TryParse(this.hdnID.Text, out id))
            {
                obj.SifraProizvoda = id;
            }-->
            </xsl:when>
            <xsl:when test="@ControlPrefix ='cbo' and @NETType='System.String'">
                (string)this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
            </xsl:when>
            <xsl:when test="@ControlPrefix ='cbo' and @NETType='System.Int32'">
                (int)this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>;
            </xsl:when>
            <xsl:when test="@ControlPrefix ='dtp'">
                this.<xsl:value-of select="@ControlName"/>.Value;
            </xsl:when>
            <xsl:when test="@ControlPrefix ='chk'">
                this.<xsl:value-of select="@ControlName"/>.Checked;
            </xsl:when>
        </xsl:choose>
    </xsl:for-each>
    </xsl:template>

    <xsl:template name="FillTheFormUsingObject">

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
                    this.hdnID.Text =ob.<xsl:value-of select="@Name"/>.ToString();
                </xsl:when>
                <xsl:when test="@ControlPrefix ='cbo'">
                    this.<xsl:value-of select="@ControlName"/>.<xsl:value-of select="@BindProperty"/>=ob.<xsl:value-of select="@Name"/>;
                </xsl:when>
                <xsl:when test="@ControlPrefix ='dtp'">
                    this.<xsl:value-of select="@ControlName"/>.Value=ob.<xsl:value-of select="@Name"/>;
                </xsl:when>
                <xsl:when test="@ControlPrefix ='chk'">
                    this.<xsl:value-of select="@ControlName"/>.Checked=ob.<xsl:value-of select="@Name"/>;
                </xsl:when>
            </xsl:choose>
        </xsl:for-each>
    </xsl:template>
    
</xsl:stylesheet>
