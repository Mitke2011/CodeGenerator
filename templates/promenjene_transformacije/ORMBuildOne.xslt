<?xml version="1.0" encoding="UTF-8" ?>

<xsl:stylesheet version="1.0"
			xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
			xmlns:xs="http://www.w3.org/2001/XMLSchema"
         xmlns:dbs="http://stefan/DbStructure"
         xmlns:orm="http://stefan/ORM.xsd">

    <xsl:import href="ORMSupport3.xslt"/>
    <xsl:output method="xml" encoding="UTF-8" indent="yes"/>
    <xsl:preserve-space elements="*" />

    <xsl:param name="filename"/>
    <xsl:param name="gendatetime"/>

    <xsl:key match="//orm:BuildTable"
             name="BuildTables"
             use="@Name"/>

    <xsl:template match="/ | @* | node()">
        <xsl:choose>
            <xsl:when test="name()='orm:Build'" />
            <xsl:otherwise>
                <xsl:copy>
                    <xsl:apply-templates select="@*"  />
                    <xsl:choose>
                        <xsl:when test="name()='orm:MappingRoot'">
                            <xsl:call-template name="Build" />
                        </xsl:when>
                        <xsl:when test="name()='orm:Object'">
                            <xsl:call-template name="ObjectAttributesUpdate" />
                        </xsl:when>
                    </xsl:choose>
                    <xsl:apply-templates select="node()"/>
                </xsl:copy>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>

    <xsl:template name="Build">
        <xsl:choose>
            <xsl:when test="count(//orm:Build)!=0">
                <xsl:for-each select="//orm:Build">
                    <xsl:copy>
                        <xsl:call-template name="BuildAttributes" />
                        <xsl:apply-templates select="@*" />
                    </xsl:copy>

                </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
                <xsl:element name="orm:Build">
                    <xsl:call-template name="BuildAttributes"/>
                    <!--<xsl:call-template name="BuildSPSets"/>-->
                </xsl:element>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>

    <xsl:template name="BuildAttributes">
        <xsl:call-template name="StandardAttributes"/>
    </xsl:template>

    <xsl:template name="StandardAttributes" >
        <xsl:attribute name="MapDataStructure">
            <xsl:value-of select="ancestor-or-self::*[@MapDataStructure][1]/@MapDataStructure" />
        </xsl:attribute>
    </xsl:template>

    <xsl:template name="GetObjectName" > <!--MOZDA MOZE DA SE OBRISE--> 
        <xsl:call-template name="IIF">
            <!--Suport3-->
            <xsl:with-param name="test" select="boolean(@ObjectName)" />
            <xsl:with-param name="truevalue" select="@ObjectName" />
            <xsl:with-param name="falsevalue" select="@Name"/>
        </xsl:call-template>
    </xsl:template>


    <!--<xsl:template name="BuildRSName"> --><!--MOZDA MOZE DA SE OBRISE--><!--
        <xsl:param name="name"/>
        <xsl:param name="pos"/>
        <xsl:choose>
            <xsl:when test="string-length($name)!=0">
                <xsl:value-of select="$name"/>
            </xsl:when>
            <xsl:when test="$pos=0">RecSet</xsl:when>
            <xsl:otherwise>
                <xsl:value-of select="concat('RecSet',$pos)" />
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>-->

    <!--<xsl:template name="BuildRecordsetAttributes"> --><!--MOZDA MOZE DA SE OBRISE--><!--
        <xsl:call-template name="StandardAttributes"/>
        --><!-- Add additional attributes --><!--
    </xsl:template>-->

    <xsl:template name="BuildTables">
        <xsl:param name="setname" />
        <xsl:param name="buildrsname" />
        <xsl:param name="tablename" />
        <xsl:param name="recset" />
        <xsl:variable name="runall">
            <xsl:if test="count($recset/orm:BuildTable)=0 or $recset/orm:AllTables">true</xsl:if>
        </xsl:variable>
        <xsl:variable name="dsname" select="ancestor-or-self::*[@MapDataStructure][1]/@MapDataStructure" />
        <xsl:for-each select="$recset/orm:BuildTable">
            <xsl:variable name="buildtablename" select="@Name" />
            <xsl:copy>
                <xsl:call-template name="BuildTableAttributes"/>
                <xsl:apply-templates select="@*" />
                <xsl:apply-templates select="node()[name()!='orm:BuildColumn']"/>
                <xsl:call-template name="BuildColumns">
                    <xsl:with-param name="buildrsname" select="$buildrsname" />
                    <xsl:with-param name="tablename" select="$buildtablename" />
                    <xsl:with-param name="buildtable" select="." />
                </xsl:call-template>
            </xsl:copy>
        </xsl:for-each>
        <xsl:if test="$runall='true'">
            <xsl:for-each select="//dbs:DataStructure[@Name=$dsname]//dbs:Table[@Name=$tablename]">
                <!-- This may be wrong -->
                <xsl:variable name="buildtablename" select="@Name" />
                <xsl:if test="count($recset/orm:BuildTable[@Name=$buildtablename])=0">
                    <xsl:element name="orm:BuildTable">
                        <xsl:attribute name="Name">
                            <xsl:value-of select="$buildtablename"/>
                        </xsl:attribute>
                        <xsl:call-template name="BuildTableAttributes"/>
                        <xsl:call-template name="BuildColumns">
                            <xsl:with-param name="buildrsname" select="$buildrsname" />
                            <!-- fix this -->
                            <xsl:with-param name="tablename" select="$buildtablename" />
                            <xsl:with-param name="buildtable" select="/xxx" />
                        </xsl:call-template>
                    </xsl:element>
                </xsl:if>
            </xsl:for-each>
        </xsl:if>
    </xsl:template>

    <xsl:template name="BuildJoins"><!--MOZDA MOZE DA SE OBRISE-->
        <!-- I am not currently building joins. If you have multiple tables, define the joins -->
    </xsl:template>

    <xsl:template name="BuildTableAttributes">
        <xsl:call-template name="StandardAttributes"/>
        Add additional attributes
    </xsl:template>

    <xsl:template name="BuildColumns">
        <xsl:param name="buildrsname" />
        <xsl:param name="tablename" />
        <xsl:param name="buildtable" />
        <xsl:variable name="runall">
            <xsl:if test="(count($buildtable//orm:BuildColumn)=0 or $buildtable/orm:AllColumns) and count($buildtable/orm:NoColumns)=0">true</xsl:if>
        </xsl:variable>
        <xsl:variable name="dsname" select="ancestor-or-self::*[@MapDataStructure][1]/@MapDataStructure" />
        <xsl:for-each select="$buildtable//orm:BuildColumn">
            <xsl:variable name="columnname" >
                <xsl:choose>
                    <xsl:when test="@Column">
                        <xsl:value-of select="@Column"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="@Name"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:variable>
            <xsl:copy>
                <xsl:for-each select="//dbs:DataStructure[@Name=$dsname]//dbs:Table[@Name=$tablename]//dbs:TableColumn[@Name=$columnname or @Column=$columnname]" >
                    <xsl:call-template name="CopyImportantColumnAttributes"/>
                </xsl:for-each>
                <xsl:apply-templates select="@*" />
                <xsl:apply-templates select="node()"/>
            </xsl:copy>
        </xsl:for-each>
        <xsl:if test="$runall='true'">
            <xsl:variable name="basebuildtable" select="key('BuildTables',$tablename)" />
            <xsl:for-each select="//dbs:DataStructure[@Name=$dsname]//dbs:Table[@Name=$tablename]//dbs:TableColumn" >
                <xsl:variable name="columnname" select="@Name" />
                <xsl:if test="count($buildtable/orm:BuildColumn[@Name=$columnname or @Column=$columnname])=0">
                    <xsl:element name="orm:BuildColumn">
                        <xsl:attribute name="Name">
                            <xsl:value-of select="$columnname"/>
                        </xsl:attribute>
                        <xsl:call-template name="CopyImportantColumnAttributes"/>
                        <xsl:if test="$basebuildtable/orm:BuildColumn[@Column=$columnname]">
                            <xsl:attribute name="Name">
                                <xsl:value-of select="$basebuildtable//orm:BuildColumn[@Column=$columnname]/@Name"/>
                            </xsl:attribute>
                        </xsl:if>
                    </xsl:element>
                </xsl:if>
            </xsl:for-each>
        </xsl:if>
    </xsl:template>

</xsl:stylesheet> 
  