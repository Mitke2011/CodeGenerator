<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:dbs="http://stefan/DbStructure">

    <xsl:import href="..\XSLT\GenericTemplates.xslt"/>

    <xsl:output method="text" encoding="UTF-8" indent="yes"/>

    <xsl:param name="Name"/>
    <xsl:param name ="filedName"/>

    <xsl:template match="dbs:Tables">
        <xsl:for-each select="dbs:Table">
            <xsl:variable name="dirname" select="'..\..\..\XSLTResourceCreator\DomainClasses\'"/>
            <xsl:variable name ="filename" select="concat($dirname,@Name,'.cs')"/>
            <xsl:result-document method="text" href="{$filename}">

                <xsl:choose>
                    <xsl:when test ="@Name = 'sysdiagram'">
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:call-template name="Header"/>
                        using Middletier;

                        namespace DomainClasses
                        {

                        [CodeAttribute("<xsl:value-of select="@Name"/>")]
                        public class <xsl:value-of select="@Name"/>
                        {
                        <xsl:call-template name="ClassConstructors"/>

                        <xsl:call-template name="ClassFields"/>

                        <xsl:call-template name="FieldProperties">
                            <xsl:with-param name="tableName" select="@Name"/>
                        </xsl:call-template>

                        }
                        }
                    </xsl:otherwise>
                </xsl:choose>
                
                

            </xsl:result-document>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="ClassConstructors">
        public <xsl:value-of select="@Name"/> ()
        {
        }
    </xsl:template>

    <xsl:template name="ClassFields">
        <xsl:for-each select="dbs:TableColumns/*">
            private <xsl:value-of select="@NETType"/> <xsl:text> </xsl:text> <xsl:value-of select="lower-case(@Name)" /> <!--<xsl:value-of select="@Name"/>--> ;<xsl:text/>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="FieldProperties">
        <xsl:param name="tableName"/>
        <xsl:variable name="primaryKeyName"
                 select="dbs:TableConstraints/dbs:PrimaryKey/dbs:PKField/@Name" />
        <xsl:variable name ="primaryKey"
                      select="dbs:TableColumns/dbs:TableColumn[@Name=$primaryKeyName]"/>
        <xsl:if test="$primaryKey">

            public <xsl:value-of select="$primaryKey/@NETType"/> GetIDPropertyValue ()
            {
            return this.<xsl:value-of select="$primaryKey/@Name"/>;
            }
        </xsl:if>

        <xsl:for-each select="dbs:TableColumns/*">
            [CodeAttribute("<xsl:value-of select ="@Name"/>","<xsl:value-of select="$tableName"/>", <xsl:value-of select ="@IsPrimaryKey"/>)]
            public <xsl:value-of select="@NETType"/><xsl:text> </xsl:text><xsl:value-of select="@Name"/>
            {
            get
            {
            return <xsl:value-of select="lower-case(@Name)" /> ;
            }

            set
            {
            this.<xsl:value-of select="lower-case(@Name)" />=value;
            }
            }
        </xsl:for-each>

    </xsl:template>

</xsl:stylesheet>
