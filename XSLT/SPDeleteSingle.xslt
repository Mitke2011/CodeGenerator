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

      <xsl:variable name="tableName" select="dbs:Table/@TableName"/>
      <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\SP\FinalResultDeleteStoredprocedures\'"/>
      <xsl:variable name="filename" select="concat($dirname,@Name,'.sql')"/>
      <!--<xsl:if test="@Name='Proizvod'">-->
      <xsl:result-document method="text" href="{$filename}">

          
                  Create  PROCEDURE Delete<xsl:value-of select="@Name"/>(@<xsl:call-template name="IDcolumn"/>)
                  AS
                  BEGIN
                  DELETE FROM <xsl:value-of select="@Name"/>  WHERE
                  <xsl:call-template name="where_condition"/>

                  END
                  GO             
       
      </xsl:result-document>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="where_condition" match="dbs:TableColumns">
    <xsl:for-each select="dbs:TableColumns/*">
      <xsl:if test="@IsPrimaryKey = 'true'">
        <xsl:value-of select="@Name"/>= @<xsl:value-of select="@Name"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="IDcolumn">
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:if test="@IsPrimaryKey='true'">
          <xsl:value-of select="@Name"/><xsl:text> </xsl:text> <xsl:value-of select="@SQLType"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
  
</xsl:stylesheet>
