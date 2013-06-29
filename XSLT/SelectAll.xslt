<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:dbs="http://kadgen/DatabaseStructure"
>
    <xsl:output method="text" indent="yes"/>

  <xsl:template name="main" match="dbs:Tables">
    <xsl:for-each select="dbs:Table">
      <xsl:if test="@Name = 'Proizvod' ">
        <xsl:call-template name="sp_body"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="sp_body">
    Create  PROCEDURE GetAll<xsl:value-of select="@Name"/>()
    AS
    BEGIN
    SELECT * FROM <xsl:value-of select="@Name"/>
    END
  </xsl:template>
</xsl:stylesheet>
