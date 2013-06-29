<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"
			xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
			xmlns:xs="http://www.w3.org/2001/XMLSchema"
         xmlns:dbs="http://stefan/DbStructure"
         xmlns:orm="http://stefan/ORM.xsd">

    <xsl:import href="ORMSupport3.xslt"/>
    <xsl:output method="xml" encoding="UTF-8" indent="yes"/>
    <xsl:preserve-space elements="*" />

    <xsl:key match="//dbs:Table//dbs:TableColumn"
             name="TableColumns"
             use="concat(ancestor::dbs:DataStructure/@Name,'-',ancestor::dbs:Table/@Name,'-',@Name)" />

    <xsl:key match="//orm:BuildTable//orm:BuildColumn"
             name="BuildColumns"
             use="concat(ancestor::orm:BuildTable/@Name,'-',@Name)" />

    <xsl:key match="//orm:Object"
             name="Objects"
             use="@Name" />

    <xsl:param name="filename"/>
    <xsl:param name="gendatetime"/>

    <xsl:template match="/ | @* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@*"  />
            <xsl:apply-templates select="node()"/>
            <xsl:choose>
                <xsl:when test="name()='orm:Object'">
                    <xsl:call-template name="Objects"/>
                </xsl:when>
            </xsl:choose>
        </xsl:copy>
    </xsl:template>

    <xsl:template name="Objects">
        <xsl:apply-templates select="@*"  />
        <!--<xsl:apply-templates select="node()
		               [name()!='orm:CreateSP' and
		                name()!='orm:ChildCollection' and
		                name()!='orm:ParentObject' and
		                name()!='orm:UpdateSP' and
		                name()!='orm:DeleteSP' and
		                name()!='orm:SetSelectSP' and
		                name()!='orm:AllProperties' and
		                name()!='orm:Property' ]"/>-->
        <xsl:call-template name="Properties"/>
    </xsl:template>

    <!-- Add Property information to object  -->
    <xsl:template name="Properties">
        <xsl:variable name="runall">
            <xsl:if test="count(orm:Property)=0 or orm:AllProperties">true</xsl:if>
        </xsl:variable>
        <xsl:variable name="objecttablename" select="@TableName"/>
        <xsl:variable name="dsname"
                select="ancestor-or-self::*[@MapDataStructure][1]/@MapDataStructure"/>

        <xsl:variable name="columnkey">
            <xsl:choose>

                <xsl:when test="string-length(@ChildOf)!=0 and string-length(@Position)!=0">
                    <xsl:variable name="childof" select="@ChildOf" />
                    <!--<xsl:variable name="parentspsetname" >-->
                    <!--<xsl:for-each select="//orm:Object[@Name=$childof]">-->
                    <!--<xsl:for-each select="key('Objects',$childof)">-->
                    <!--<xsl:call-template name="GetUseSPSetName">
              <xsl:with-param name="type" select="'Retrieve'"/>
            </xsl:call-template>-->
                    <!--</xsl:for-each>-->
                    <!--</xsl:variable>-->
                    <!--<xsl:variable name="parentspname" 
	               select="//orm:SPSet[@Name=$parentspsetname]//orm:RunSP[@Task='Retrieve']/@Name"/>-->
                    <!--<xsl:variable name="parentspname"
              select="key('SPSets',concat($parentspsetname,'-Retrieve'))/@Name"/>
        <xsl:value-of select="concat('InStoredProc-',
	            $dsname,'-',$parentspname,'-Table',@Position)"/>-->
                </xsl:when>
                <!--<xsl:when test="orm:RetrieveSP/orm:SPRecordset/orm:Column">
        <xsl:value-of select="concat('InObject-',
               ancestor::orm:Assembly/@Name,'-',
               ancestor::orm:Object/@Name)"/>
      </xsl:when>
      <xsl:when test="orm:RetrieveSP">
        <xsl:variable name="spname" select="@Name"/>
        <xsl:value-of select="concat('InStoredProc-',
               $dsname,'-',$spname,'-Table')"/>
      </xsl:when>-->
                <xsl:otherwise>

                    <!--<xsl:variable name="spname"
              select="key('SPSets',concat($spsetname,'-Retrieve'))/@Name"/>
        <xsl:value-of select="concat('InStoredProc-',$dsname,'-',$spname,'-Table')"/>-->
                </xsl:otherwise>
            </xsl:choose>
        </xsl:variable>

        <xsl:for-each select="orm:Property">
            <xsl:copy>
                <xsl:call-template name="PropertyAttributes"/>
                <xsl:apply-templates select="@*"  />
                <xsl:apply-templates select="node()" />
                <xsl:call-template name="PropertyContents">
                    <xsl:with-param name="tablename" select="$objecttablename"/>
                </xsl:call-template>
            </xsl:copy>
        </xsl:for-each>
        <xsl:if test="$runall='true'">
            <!--<xsl:for-each select="key('RecSetColumns',$columnkey)/dbs:Column | key('RecSetColumns',$columnkey)/orm:Column">-->
            <xsl:for-each select="dbs:TableColumns/*">
                <xsl:variable name="name" select="@Name"/>

                <xsl:if test="count(orm:Property[@Name=$name])=0">
                    <xsl:variable name="tablename">
                        <xsl:choose>
                            <xsl:when test="name()='orm:Column'">

                                <xsl:value-of select="ancestor::orm:Table/@Name"/>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="$objecttablename"/>
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:variable>

                    <xsl:element name="orm:Property">
                        <xsl:for-each select="key('BuildColumns',concat($tablename,'-',$name))">
                            <xsl:for-each select="@*">
                                <xsl:if test="string-length(.)!=0">
                                    <xsl:copy/>
                                </xsl:if>
                            </xsl:for-each>
                        </xsl:for-each>

                        <xsl:for-each select="key('TableColumns',concat($dsname,'-',$tablename,'-',$name))">

                            <xsl:for-each select="@*">
                                <xsl:if test="string-length(.)!=0">
                                    <xsl:copy/>
                                </xsl:if>
                            </xsl:for-each>

                            <xsl:call-template name="PropertyAttributes"/>

                        </xsl:for-each>
                        <xsl:for-each select="@*">
                            <xsl:choose>
                                <xsl:when test="name()='MaxLength' and .&lt;=0"/>
                                <xsl:when test="string-length(.)!=0">
                                    <xsl:copy/>
                                </xsl:when>
                            </xsl:choose>
                        </xsl:for-each>
                        <xsl:call-template name="PropertyAttributes" />
                        <xsl:call-template name="PropertyContents">
                            <xsl:with-param name="tablename" select="$objecttablename"/>
                        </xsl:call-template>
                    </xsl:element>
                </xsl:if>
            </xsl:for-each>
        </xsl:if>
    </xsl:template>

    <xsl:template name="PropertyAttributes">
        <xsl:call-template name="CopyImportantColumnAttributes"/>
    </xsl:template>

    <xsl:template name="PropertyContents">
        <xsl:param name="tablename" />
        <xsl:variable name="propertyname" select="@Name"/>
        <xsl:for-each select="ancestor::dbs:DataStructure//dbs:Table[@Name=$tablename]//dbs:TableColumn[@Name=$propertyname]">
            <xsl:for-each select=".//dbs:TableColumnPrivilege">
                <xsl:element name="orm:TableColumnPrivilege">
                    <xsl:apply-templates select="@*" />
                </xsl:element>
            </xsl:for-each>
            <xsl:for-each select=".//dbs:CheckConstraint">
                <xsl:element name="orm:CheckConstraint">
                    <xsl:apply-templates select="@*" />
                </xsl:element>
            </xsl:for-each>
        </xsl:for-each>
    </xsl:template>


</xsl:stylesheet> 
  