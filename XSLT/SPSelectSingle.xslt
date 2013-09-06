<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:dbs="http://stefan/DbStructure"
>
  <xsl:output method="text" indent="yes"/>

  <xsl:template match="dbs:Tables">
    
      <xsl:for-each select="dbs:Table">
        <xsl:variable name="tableName" select="dbs:Table/@TableName"/>
        <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\SP\FinalResultSelectSingleStoredprocedures\'"/>
        <xsl:variable name="filename" select="concat($dirname,@Name,'.sql')"/>
        <xsl:result-document method="text" href="{$filename}">

            <xsl:choose>
                <xsl:when test ="@Name = 'sysdiagram'">
                </xsl:when>
                <xsl:otherwise>
                    Create  PROCEDURE SelectOne<xsl:value-of select="@Name"/>(@<xsl:call-template name="IDcolumn"/>)
                    AS
                    BEGIN
                    SELECT * FROM <xsl:value-of select="@Name"/>

                    WHERE <xsl:call-template name="where_condition"/>

                    END
                    GO
                </xsl:otherwise>
            </xsl:choose>
            
        </xsl:result-document>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="where_condition" match="dbs:TableColumns">
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:variable name="column" select="dbs:TableColumn"/>
      <xsl:if test="@IsPrimaryKey = 'true'">
        <xsl:value-of select="@Name"/> = @<xsl:value-of select="@Name"/>
      </xsl:if>
    </xsl:for-each>

  </xsl:template>

  <xsl:template name="IDcolumn">
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:if test="@IsPrimaryKey='true'">
        <xsl:value-of select="@Name"/> <xsl:text> </xsl:text> <xsl:value-of select="@SQLType"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
