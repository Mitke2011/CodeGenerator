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
            <xsl:choose>
                <xsl:when test ="@Name = 'sysdiagram'">
                </xsl:when>
                <xsl:otherwise>
            <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\UI\FinalResultWebUIListDesignClasses\'"/>
            <xsl:variable name="filename" select="concat($dirname,@Name,'List','.aspx.cs')"/>
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
                        public partial class <xsl:value-of select="@Name"/>List : System.Web.UI.Page
                        {
                        <xsl:variable name="ObjectName" select="@Name"/>
                        <xsl:call-template name="PageLoadingEvent">
                            <xsl:with-param name="object" select="orm:Object"/>
                        </xsl:call-template>
                        <xsl:call-template name ="ModifyButtonEvent">
                            <xsl:with-param name="object" select="orm:Object"/>
                        </xsl:call-template>

                        private int GetColumnIndex(GridViewRow row, string columnName)
                        {
                        int columnindex = 0;
                        foreach (DataControlFieldCell c in row.Cells)
                        {
                        if (c.ContainingField is BoundField)
                        {
                        if ((c.ContainingField as BoundField).DataField.Equals(columnName))
                        {
                        break;
                        }
                        }
                        columnindex++;
                        }
                        return columnindex;
                        }
                        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
                        {
                        e.Row.Cells[2].Visible = false;
                        }
                        }
                        }

            </xsl:result-document>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="PageLoadingEvent">
        <xsl:param name="object"/>
        protected void Page_Load(object sender, EventArgs e)
        {
            MiddletierManager mm = new MiddletierManager();
            List&lt;<xsl:value-of select="@Name"/>&gt; lt = new List&lt;<xsl:value-of select="@Name"/>&gt;();

        int refID;
        string columnName="";
        string refTable ="";
        if(int.TryParse(Request.QueryString["refID"],out refID))
        {
        columnName=Request.QueryString["colName"];
        refTable=Request.QueryString["tableName"];

        foreach (<xsl:value-of select="@Name"/> item in mm.FindAllReferenced((new <xsl:value-of select="@Name"/>()),refTable,columnName,refID))
        {
        lt.Add(item);
        }
        }
        else
        {
        foreach (<xsl:value-of select="@Name"/> item in mm.FindAll((new <xsl:value-of select="@Name"/>()),"<xsl:value-of select="@TableName"/>",true))
            {
                lt.Add(item);   
            }
        }
            
            
            this.GridView1.DataSource = lt;
            this.GridView1.DataBind();
        }
    </xsl:template>

    <xsl:template name="ModifyButtonEvent">
        <xsl:param name="object"/>
        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            <!--int a = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = GridView1.Rows[a];
            int columnidex = GetColumnIndex(row, <xsl:value-of select="@Name"/>.GetIDPropertyName());
        string tekst = this.GridView1.Rows[a].Cells[columnidex].Text;

        Response.Redirect("<xsl:value-of select="@Name"/>Edit.aspx?objectid=" + tekst);//dodaj kolonu u URl kao parametar. Citaj ga preko String s = Request.QueryString["objectid"];-->

        int a = -1;
        if (int.TryParse(e.CommandArgument.ToString(),out a) &amp;&amp; (e.CommandName.Equals("Edit") || e.CommandName.Equals("Delete")))
        {
        if (a>=0)
        {
        GridViewRow row = GridView1.Rows[a];
        int columnidex = GetColumnIndex(row, <xsl:value-of select="@Name"/>.GetIDPropertyName());
        string tekst = this.GridView1.Rows[a].Cells[columnidex].Text;
        Response.Redirect("<xsl:value-of select="@Name"/>Edit.aspx?objectid=" + tekst);
        }
        }
        else
        {
        Response.Redirect("<xsl:value-of select="@Name"/>Edit.aspx");
        }

        }
    </xsl:template>
    
</xsl:stylesheet>
