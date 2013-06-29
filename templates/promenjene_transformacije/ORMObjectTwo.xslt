<?xml version="1.0" encoding="UTF-8" ?>

<xsl:stylesheet version="1.0"
			xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
			xmlns:xs="http://www.w3.org/2001/XMLSchema"
         xmlns:dbs="http://stefan/DbStructure"
         xmlns:orm="http://stefan/ORM.xsd"       >

    <xsl:import href="ORMSupport3.xslt"/>
    <xsl:output method="xml" encoding="UTF-8" indent="yes"/>
    <xsl:preserve-space elements="*" />

    <xsl:param name="filename"/>
    <xsl:param name="gendatetime"/>

    <xsl:template match="/ | @* | node()">
        <xsl:choose>
            <xsl:when test="name()='orm:Assembly'" />
            <xsl:otherwise>
                <xsl:copy>
                    <xsl:apply-templates select="@*"  />
                    <xsl:apply-templates select="node()"/>
                    <xsl:if test="name()='orm:MappingRoot'">
                        <xsl:call-template name="Assembly" />
                    </xsl:if>
                </xsl:copy>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>

    <xsl:template name="Assembly">
        <xsl:for-each select="//orm:Assembly">
            <xsl:copy>
                <xsl:apply-templates select="@*" />
                <xsl:apply-templates select="node()"/>
                <xsl:for-each select=".//orm:Object">
                    <xsl:apply-templates select=".//orm:ChildCollection" mode="MissingChildren" />
                </xsl:for-each>
            </xsl:copy>
        </xsl:for-each>
    </xsl:template>

    <xsl:template match="orm:ChildCollection" mode="MissingChildren">
        <xsl:variable name="assembly" select="ancestor::orm:Assembly"/>
        <xsl:variable name="dsname" select="ancestor::*[@MapDataStructure][1]/@MapDataStructure"/>
        <xsl:variable name="name" select="@Name" />
        <xsl:variable name="singularname" select="@Name" />
        <!--STEFN IZMENIO-->
        <xsl:variable name="pos" select="position()"/>
        <xsl:variable name="tablename" select="@ChildTableName" />
        <xsl:if test="count($assembly//orm:Object[@Name=$singularname])=0">

            <xsl:variable name="childof" select="ancestor::orm:Object/@TableName"/>
            <!--STEFN IZMENIO-->
            <xsl:variable name="inherits" select="@ChildTableName"/>
            <!--STEFN IZMENIO-->
            <xsl:for-each select="//dbs:DataStructure[$dsname=@Name]//dbs:Table[@Name=$tablename]">
                <xsl:call-template name="AddObject" >
                    <xsl:with-param name="childof" select="$childof" />
                    <xsl:with-param name="inherits" select="$inherits" />
                    <xsl:with-param name="pos" select="$pos"/>
                    <xsl:with-param name="name" select="$name" />
                </xsl:call-template>
            </xsl:for-each>
        </xsl:if>
    </xsl:template>

</xsl:stylesheet> 
  