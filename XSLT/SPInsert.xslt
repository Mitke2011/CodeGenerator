<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:dbs="http://kadgen/DatabaseStructure"
>
    <xsl:output method="text" indent="no"/>

    <xsl:template match="dbs:Tables">  
      
        <xsl:for-each select="dbs:Table">
          <xsl:variable name="tableName" select="dbs:Table/@TableName"/>
          <xsl:variable name="dirname" select ="'..\..\SP\FinalResultInsertStoredprocedures\'"/>
          <xsl:variable name="filename" select="concat($dirname,@Name,'.sql')"/>
          
          <xsl:result-document method="text" href="{$filename}">
            <xsl:call-template name="main"/>
          </xsl:result-document>        
        </xsl:for-each>
      
    </xsl:template>

  <xsl:template name="query" match="dbs:Table">
    insert into <xsl:value-of select="@Name"/> (<xsl:call-template name="tablecolumns"/>)
    values (<xsl:call-template name="QueryInsertParams"/>)
  </xsl:template>

  <xsl:template name="tablecolumns" match="dbs:Table">
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
      <xsl:for-each select="$columns">
        <xsl:variable name="column" select="dbs:TableColumn"/>
       <xsl:choose>
         <xsl:when test="position() &lt; count($columns)  and @IsPrimaryKey!='true'">
           [<xsl:value-of select="@Name"/>],
         </xsl:when>
         <xsl:otherwise>
             <xsl:if test="@IsPrimaryKey!='true'">
           [<xsl:value-of select="@Name"/>]
             </xsl:if>
         </xsl:otherwise>
       </xsl:choose>

      </xsl:for-each>    
  </xsl:template>

  <xsl:template name="SPInsertParams" match="dbs:Table">
    
    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:variable name="column" select="dbs:TableColumn"/>
      <xsl:choose>
        <xsl:when test="position() &lt; count($columns) and @IsPrimaryKey!='true'">
          @<xsl:value-of select="@Name"/> <xsl:text> </xsl:text>  <xsl:value-of select="@SQLType"/> <xsl:if test="@MaxLength !=''">(<xsl:value-of select="@MaxLength"/>),
          </xsl:if>
        </xsl:when>
        <xsl:otherwise>
            <xsl:if test="@IsPrimaryKey!='true'">
          @<xsl:value-of select="@Name"/> <xsl:text> </xsl:text>  <xsl:value-of select="@SQLType"/> <xsl:if test="@MaxLength !=''">(<xsl:value-of select="@MaxLength"/>)
          </xsl:if>
            </xsl:if>
        </xsl:otherwise>
      </xsl:choose>

    </xsl:for-each>

  </xsl:template>

  <xsl:template name="QueryInsertParams" match="dbs:Table">
    <!--<xsl:for-each select="dbs:TableColumns/*">
      @<xsl:value-of select="@Name"/>,
    </xsl:for-each>-->

    <xsl:variable name="columns" select="dbs:TableColumns/*"/>
    <xsl:for-each select="$columns">
      <xsl:variable name="column" select="dbs:TableColumn"/>
      <xsl:choose>
        <xsl:when test="position() &lt; count($columns) and @IsPrimaryKey!='true'">
          @<xsl:value-of select="@Name"/>,
        </xsl:when>
        <xsl:otherwise>
            <xsl:if test="@IsPrimaryKey!='true'">
                @<xsl:value-of select="@Name"/>
            </xsl:if>
        </xsl:otherwise>
      </xsl:choose>

    </xsl:for-each>

  </xsl:template>
  
  <xsl:template name="main" match="dbs:Table">
    CREATE PROCEDURE Insert<xsl:value-of select="@Name"/>
    (
    <xsl:call-template name="SPInsertParams"/>
    )
    AS
    BEGIN
    <xsl:call-template name="query" />
    END
    GO
  </xsl:template>
</xsl:stylesheet>
