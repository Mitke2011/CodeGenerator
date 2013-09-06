<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
   xmlns:dbs="http://stefan/DbStructure"
        xmlns:orm="http://stefan/ORM.xsd">
    <xsl:import href="..\XSLT\GenericTemplates.xslt"/>

    <xsl:output method="text" encoding="UTF-8" indent="yes"/>

    <xsl:param name="Name"/>
    <xsl:param name ="filedName"/>
    <!--<xsl:variable name="tableName" select="orm:Object/@TableName"/>-->
    <xsl:template match="/">

        <xsl:apply-templates select="//orm:Assembly//orm:Objects" mode="BuildClasses" />

    </xsl:template>

    <xsl:template match="orm:Objects" mode="BuildClasses">
        <xsl:for-each select="orm:Object">
            <xsl:variable name="dirname" select ="'..\..\..\XSLTResourceCreator\FinalResultObjectClasses\'"/>
            <xsl:variable name="filename" select="concat($dirname,@Name,'.cs')"/>
            <!--<xsl:variable name="tableName1" select="orm:Object/@TableName"/>-->
            <xsl:result-document method="text" href="{$filename}">

                <xsl:choose>
                    <xsl:when test ="@Name = 'sysdiagram'">
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:call-template name="Header"/>

                        using Middletier;
                        <xsl:variable name="PrimaryKeyPr" select="orm:Properties/orm:Property[@IsPrimaryKey='true']/@Name"/>
                        namespace ObjectClasses
                        {
                        [CodeAttribute("<xsl:value-of select="@TableName"/>")]
                        public class <xsl:value-of select="@Name"/><xsl:call-template name="ParentClass">
                            <xsl:with-param name="PrimaryKeyProp" select="$PrimaryKeyPr"/>
                        </xsl:call-template>
                        {
                        <xsl:call-template name="ClassConstructors"/>

                        <xsl:call-template name="ClassFields"/>

                        <xsl:call-template name="FieldProperties">
                            <xsl:with-param name="tableName" select="@TableName"/>
                        </xsl:call-template>

                        <xsl:call-template name ="CreteChildCollection"/>

                        <xsl:call-template name="FillTheChildList"/>

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
        <xsl:for-each select="orm:Properties/*">
            private <xsl:value-of select="@NETType"/> <xsl:text> </xsl:text> <xsl:value-of select="lower-case(@Name)" /> <!--<xsl:value-of select="@Name"/>--> ;<xsl:text/>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="FieldProperties">
        <xsl:param name="tableName"/>
        <xsl:for-each select="orm:Properties/*">

            <xsl:if test="@IsPrimaryKey='true'">


                <!--[CodeAttribute("<xsl:value-of select ="@Column"/>","<xsl:value-of select="$tableName"/>", <xsl:value-of select ="@IsPrimaryKey"/>)]
        public <xsl:value-of select="@NETType"/> GetIDField ()
        {
        return this.<xsl:value-of select="@Name"/>;
          }-->

                public static string GetIDPropertyName ()
                {
                return "<xsl:value-of select="@Name"/>";
                }

                public <xsl:value-of select="@NETType"/><xsl:text>  </xsl:text>GetIDProperty ()
                {
                return this.<xsl:value-of select="@Name"/>;
                }

                [CodeAttribute("<xsl:value-of select ="@Column"/>","<xsl:value-of select="$tableName"/>", <xsl:value-of select ="@IsPrimaryKey"/>)]
                public <xsl:value-of select="@NETType"/><xsl:text> </xsl:text><xsl:value-of select="@Name"/>
                {
                get{return this.<xsl:value-of select="lower-case(@Name)"/>;}
                set
                {
                this.<xsl:value-of select="lower-case(@Name)"/>=value;
                }
                }
            </xsl:if>

            <xsl:if test="@IsPrimaryKey='false'">
                [CodeAttribute("<xsl:value-of select ="@Column"/>","<xsl:value-of select="$tableName"/>")]
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
            </xsl:if>
        </xsl:for-each>

    </xsl:template>

    <xsl:template name="CreteChildCollection">
        <!--Za svaki tip child elementa napravi posebnu listu. Kao i metodu koja puni tu kolekciju, a poziva se u konstruktoru klase.-->
        MiddletierManager mng = new MiddletierManager();
        <xsl:for-each select ="orm:ChildCollection">            
            List&lt; <xsl:value-of select="@ObjectName"/> &gt; <xsl:value-of select="lower-case(@ObjectName)"/>List =new List&lt; <xsl:value-of select="@ObjectName"/> &gt;();          
        </xsl:for-each>
        <!--<xsl:for-each select ="orm:ChildCollection"> -->
        <!--iskomentarisano jer debager radi sa 1.0 XSLT-om-->
        <!--            
            List&lt; <xsl:value-of select="@ObjectName"/> &gt; <xsl:value-of select="lower-case(@ObjectName)"/> = new List&lt; <xsl:value-of select="@ObjectName"/> &gt;();
        </xsl:for-each>-->
    </xsl:template>

    <xsl:template name="FillTheChildList">
        
        public void LoadTheChildrenLists()
        {
        <xsl:for-each select ="orm:ChildCollection">
            <!--this.<xsl:value-of select="lower-case(@ObjectName)"/>List    = (List&lt; <xsl:value-of select="@ObjectName"/> &gt;)
            mng.FindAllReferenced(new <xsl:value-of select="@ObjectName"/>(),"<xsl:value-of select="@ChildTableName"/>","<xsl:value-of select="orm:ChildKeyField/@Name"/>",
            this.GetIDProperty());-->

            foreach(<xsl:value-of select="@ObjectName"/> item in mng.FindAllReferenced(new <xsl:value-of select="@ObjectName"/>(),"<xsl:value-of select="@ChildTableName"/>","<xsl:value-of select="orm:ChildKeyField/@Name"/>",this.GetIDProperty()))
            {
                this.<xsl:value-of select="lower-case(@ObjectName)"/>List.Add(item);
            }

            <!--this.collectionList = (List&lt; <xsl:value-of select="@ObjectName"/> &gt;)mng.FindAllReferenced(new <xsl:value-of select="@ObjectName"/>(),"<xsl:value-of select="@ChildTableName"/>","<xsl:value-of select="orm:ChildKeyField/@Name"/>");-->
        </xsl:for-each>
        }
    </xsl:template>

    <xsl:template name="ParentClass">
        <xsl:param name="PrimaryKeyProp"/>
        <xsl:for-each select="orm:ParentObject">
            <xsl:if test="orm:ChildKeyField/@Name = $PrimaryKeyProp">
                :<xsl:value-of select="@Name"/>
            </xsl:if>
        </xsl:for-each>
    </xsl:template>
    
</xsl:stylesheet>
