<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:dbs="http://stefan/DbStructure"
>
  <xsl:output method="text" indent="yes"/>

  <xsl:template name="main" match="dbs:Tables">
    <xsl:for-each select="dbs:Table">
        <xsl:choose>
            <xsl:when test ="@Name = 'sysdiagram'">
            </xsl:when>
            <xsl:otherwise>
      <!--<xsl:if test="@Name = 'Proizvod'">
        <xsl:call-template name="updateparams"/>-->
      <xsl:variable name="tableName" select="dbs:Table/@TableName"/>
      <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\SP\FinalResultUpdateStoredprocedures\'"/>
      <xsl:variable name="filename" select="concat($dirname,@Name,'.sql')"/>     
        
        
      <xsl:result-document method="text" href="{$filename}">
         
                  CREATE PROCEDURE Update<xsl:value-of select="@Name"/>
                  (
                  <xsl:call-template name="updateparams"/>
                  )
                  AS
                  BEGIN
                  <xsl:call-template name="query" >
                      <xsl:with-param name="tablename" select="@Name"/>
                  </xsl:call-template>
                  END
                  GO              
      </xsl:result-document>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="updatecolumns" match="dbs:TableColumns">
    <!--<xsl:for-each select="dbs:TableColumn">
      <xsl:value-of select="@Name"/>,
    </xsl:for-each>-->

    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:variable name="column" select="dbs:TableColumn"/>
      <xsl:choose>
        <xsl:when test="position() &lt; count($columns)">
          [<xsl:value-of select="@Name"/>],
        </xsl:when>
        <xsl:otherwise>
          [<xsl:value-of select="@Name"/>]
        </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>

  </xsl:template>

  <xsl:template name="updateparams">
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:variable name="column" select="dbs:TableColumn"/>
      <xsl:choose>
        <xsl:when test="position() &lt; count($columns)">
          @<xsl:value-of select="@Name"/> <xsl:text> </xsl:text>  <xsl:value-of select="@SQLType"/> <xsl:if test="@MaxLength !=''">(<xsl:value-of select="@MaxLength"/>)</xsl:if>,
        </xsl:when>
        <xsl:otherwise>
          @<xsl:value-of select="@Name"/> <xsl:text> </xsl:text>  <xsl:value-of select="@SQLType"/> <xsl:if test="@MaxLength !=''">(<xsl:value-of select="@MaxLength"/>)
          </xsl:if>
        </xsl:otherwise>
      </xsl:choose>

    </xsl:for-each>
  </xsl:template>

  <xsl:template name="where">
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:variable name="column" select="dbs:TableColumn"/>
      <xsl:if test="@IsPrimaryKey = 'true'">
        <xsl:value-of select="@Name"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="setSection">
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <!--<xsl:variable name="column" select="dbs:TableColumn[@IsPrimaryKey!='true']"/>-->
      <xsl:choose>
        <xsl:when test="position() &lt; count($columns) and @IsPrimaryKey!='true'">
            <xsl:value-of select="@Name"/> = @<xsl:value-of select="@Name"/>,
        </xsl:when>
          <xsl:otherwise>
              <xsl:if test="@IsPrimaryKey!='true'">
                  <xsl:value-of select="@Name"/> = @<xsl:value-of select="@Name"/>
              </xsl:if>
              
          </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>

  </xsl:template>

  <xsl:template name ="query">
    <xsl:param name="tablename"/>
    UPDATE <xsl:text/><xsl:value-of select="$tablename"/><xsl:text/> <!--(<xsl:call-template name="updatecolumns"/>)-->
    SET <xsl:call-template name="setSection"/>
    WHERE <xsl:call-template name="where"/> = @<xsl:call-template name="where"/>
  </xsl:template>

</xsl:stylesheet>
