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
            <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\UI\FinalResultWinUIDesignListClasses\'"/>
            <xsl:variable name="filename" select="concat($dirname,@Name,'List','.cs')"/>
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
                partial class <xsl:value-of select="@Name"/>List:Form
                {
                MiddletierManager mm = new MiddletierManager();
                <xsl:call-template name ="LoadFormEvent">
                    <xsl:with-param name="objectName" select="@Name"/>
                </xsl:call-template>

                <xsl:call-template name="gridEvent"/>
                
                }
                }
            </xsl:result-document>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="LoadFormEvent">
        <xsl:param name="objectName"/>
        public <xsl:value-of select="@Name"/>List()
        {
          InitializeComponent();
          <!--List &lt;<xsl:value-of select="$objectName"/>&gt; ls = (List&lt;<xsl:value-of select="$objectName"/>&gt;)mm.FindAll(<xsl:value-of select="@Name"/> obj, "<xsl:value-of select="orm:Object/@TableName"/>");-->

        <xsl:value-of select="@Name"/> obj = new <xsl:value-of select="@Name"/>();
        List&lt;<xsl:value-of select="@Name"/>&gt; ls  = new List&lt;<xsl:value-of select="@Name"/>&gt;();

            foreach (<xsl:value-of select="@Name"/> item in mm.FindAll(obj, "<xsl:value-of select="@TableName"/>",true))
            {
                ls.Add(item);
            }
        this.dataGridView1.DataSource = ls;
        
        DataGridViewButtonColumn btnCol1 = new DataGridViewButtonColumn();

        btnCol1.Name = "New";

        btnCol1.Text = "New";

        DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();

        btnCol.Name = "Modify";

        btnCol.Text = "Modify";

        DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
        tbCol.Name = "IDValue";
        tbCol.Visible = false;
        <!--tbCol.DataPropertyName = "<xsl:value-of select="//orm:Object[@Name = $objectName]//orm:Properties/orm:Property[@IsPrimaryKey]/@Name"/>_Property";-->
        tbCol.DataPropertyName = "<xsl:value-of select="orm:Properties/orm:Property[@IsPrimaryKey='true']/@Name"/>";
      btnCol.UseColumnTextForButtonValue = true;
      btnCol1.UseColumnTextForButtonValue = true;


      dataGridView1.Columns.Add(btnCol1);
      dataGridView1.Columns.Add(btnCol);
      dataGridView1.Columns.Add(tbCol);

      dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
      }
    </xsl:template>
    <xsl:template name ="gridEvent">
        <xsl:param name ="objectName"/>
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        var columns = dataGridView1.Columns.GetEnumerator();
        int idColumnIndex = 0;

        while (columns.MoveNext())
        {
        if ((columns.Current as DataGridViewTextBoxColumn) != null &amp;&amp; (columns.Current as DataGridViewTextBoxColumn).Name.Equals("IDValue"))
        {
        idColumnIndex = (columns.Current as DataGridViewTextBoxColumn).Index;
        }
        }

        
      if (e.RowIndex &lt; 0) return;
            
            
            if (e.ColumnIndex ==
                dataGridView1.Columns["New"].Index)
            {
                <xsl:value-of select="@Name"/>Edit forma = new <xsl:value-of select="@Name"/>Edit();
                forma.Visible = true;
            }

          if (e.ColumnIndex ==
              dataGridView1.Columns["Modify"].Index)
            {
              int ID = (Int32)dataGridView1[idColumnIndex, e.RowIndex].Value;
                <xsl:value-of select="@Name"/>Edit forma = new <xsl:value-of select="@Name"/>Edit(ID);
                forma.Visible = true;
            }


        }
    </xsl:template>
</xsl:stylesheet>
