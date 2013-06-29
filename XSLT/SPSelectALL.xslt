﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:dbs="http://kadgen/DatabaseStructure"
>
  <xsl:output method="text" indent="yes"/>

  <xsl:template match="dbs:Tables">
    
    <xsl:for-each select="dbs:Table">
        <xsl:variable name="tableName" select="dbs:Table/@TableName"/>
        <xsl:variable name="dirname" select ="'..\..\SP\FinalResultSelectAllStoredProcedures\'"/>
        <xsl:variable name="filename" select="concat($dirname,@Name,'.sql')"/>

        <xsl:result-document method="text" href="{$filename}">
          Create  PROCEDURE SelectAll<xsl:value-of select="@Name"/>
          AS
          BEGIN
          SELECT * FROM <xsl:value-of select="@Name"/>
          end
          go
        </xsl:result-document>      
    </xsl:for-each>
  </xsl:template>
 
</xsl:stylesheet>