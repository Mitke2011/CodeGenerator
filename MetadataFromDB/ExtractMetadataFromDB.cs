using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace MetadataFromDB
{
    public abstract class ExtractMetadataFromDB
    {
        protected XmlDocument mXMLDoc;
        protected DataSet mDataSet;
        private bool mUseVerboseNames = false;
        private bool mUseProcContents = false;
        protected string mRemovePrefix;
       

        #region Abstrac Methods
        protected abstract DataTable DataTableFromSQL(string SQLText, string databaseName, string tablename);

        protected abstract void DataTableFromSQL(string SQLText, string tablename, DataTable dt);

        protected abstract DataSet RunStoredProc(string spname, XmlNode nodeParams, string databaseName);
        #endregion

        public XmlDocument CreateMetaData(params string[] databaseNames)
        {
            mXMLDoc = new XmlDocument();
            XmlElement nodeRoot = mXMLDoc.CreateElement("dbs", "MetaDataRoot", "http://stefan/DbStructure");
            nodeRoot.Attributes.Append(XMLAddings.NewBoolAttribute(mXMLDoc, "FreeForm", true)); 
            XmlElement nodeDatabase;
            
            if (databaseNames.GetLength(0) == 0)
            {
                DataTable dtDatabases = GetDatabases();
                databaseNames = new string[dtDatabases.Rows.Count];
                for (int i = 0; i < dtDatabases.Rows.Count; i++)
                {
                    databaseNames[i] = dtDatabases.Rows[i]["CATALOG_NAME"].ToString();
                }
            }

            this.mRemovePrefix = "";

            mXMLDoc.AppendChild(mXMLDoc.CreateXmlDeclaration("1.0", "UTF-8", "")); 
            mXMLDoc.AppendChild(nodeRoot);
            XmlElement node = this.CreateElement("DataStructures");
            nodeRoot.AppendChild(node);
            foreach (string name in databaseNames)
            {
                mDataSet = null;
                nodeDatabase = this.CreateElement("DataStructure", name);
                node.AppendChild(nodeDatabase);
                FillMetaDataSet(name);
                nodeDatabase.AppendChild(this.GetAllTablesXML(string.Empty));//custom metoda

                string test = "";
            }
            return mXMLDoc;
        }

        protected virtual XmlElement CreateElement(string ElementName)
        {
            return mXMLDoc.CreateElement("dbs", ElementName, "http://stefan/DbStructure");
        }

        protected virtual XmlElement CreateElement(string ElementName, string name)
        {
            XmlElement elem;
            elem = mXMLDoc.CreateElement("dbs", ElementName, "http://stefan/DbStructure");
            elem.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "Name", name));
            return elem;
        }

        protected virtual DataTable GetDatabases()
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA", "Master", "Databases");
        }

        #region Fill Metadata
        protected virtual void FillMetaDataSet(string name)
        {
            mDataSet = new DataSet();
            mDataSet.Tables.Add(GetDatabase(name));
            mDataSet.Tables.Add(GetTables(name));
            mDataSet.Tables.Add(GetColumns(name));
            mDataSet.Tables.Add(GetTableConstraints(name));
            mDataSet.Tables.Add(GetColumnConstraints(name));
            mDataSet.Tables.Add(GetKeyColumns(name));
            mDataSet.Tables.Add(GetReferentialConstraints(name));
        }

        protected virtual DataTable GetTableConstraints(string databaseName)
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_CATALOG='" + databaseName + "'", databaseName, "TableConstraints");
        }

        protected virtual DataTable GetKeyColumns(string databaseName)
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_CATALOG='" + databaseName + "'", databaseName, "KeyColumns");
        }

        protected virtual DataTable GetColumns(string databaseName)
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_CATALOG='" + databaseName + "' ORDER BY TABLE_NAME, ORDINAL_POSITION", databaseName, "Columns");
        }

        protected virtual DataTable GetTables(string databaseName)
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_CATALOG='" + databaseName + "' AND TABLE_TYPE='BASE TABLE'", databaseName, "Tables");
        }

        protected virtual DataTable GetDatabase(string databaseName)
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE CATALOG_NAME='" + databaseName + "'", databaseName, "Database");
        }
       
        #endregion

        #region Get Constraints
       

        protected virtual DataTable GetReferentialConstraints(string databaseName)
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_CATALOG='" + databaseName + "'", databaseName, "ReferentialConstraints");
        }

        protected virtual DataTable GetColumnConstraints(string databaseName)
        {
            return DataTableFromSQL("SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE TABLE_CATALOG='" + databaseName + "'", databaseName, "ColumnConstraints");
        } 
        #endregion

        #region Get Table/Column XML
        protected virtual XmlNode GetAllTablesXML(string lookupPrefix)
        {
            XmlElement nodeTables = this.CreateElement("Tables");
            nodeTables.Prefix = "dbs";
            foreach (DataRow rowTable in mDataSet.Tables["Tables"].Rows)
            {
               
                nodeTables.AppendChild(GetTableXML(rowTable, "Table", lookupPrefix));
            }
            return nodeTables;
        }

        protected virtual XmlNode GetTableXML(DataRow rowTable, string modeName, string lookupPrefix)
        {
            string tableName = rowTable["TABLE_NAME"].ToString();
            DataRow[] rowColumns = mDataSet.Tables["Columns"].Select(TableMatch(rowTable));
            XmlNode nodeColumns;
            string originalName = rowTable["TABLE_NAME"].ToString();
            bool isLookup = false;
            string name = XMLAddings.FixName(originalName, mRemovePrefix);
            string singularName = XMLAddings.GetSingular(name);
            string pluralName = XMLAddings.GetPlural(name);
            
            XmlNode nodeTable = NewElementWithName(modeName, singularName, rowTable, "TABLE");
            nodeTable.Attributes.Append(XMLAddings.NewAttribute(nodeTable.OwnerDocument, "OriginalName", originalName));
            
            if (lookupPrefix.Length > 0 && originalName.StartsWith(lookupPrefix))
            {
                isLookup = true;
                nodeTable.Attributes.Append(XMLAddings.NewAttribute(nodeTable.OwnerDocument, "IsLookup", "true"));
            }

            
            nodeColumns = nodeTable.AppendChild(this.CreateElement(modeName + "Columns"));
            foreach (DataRow rowColumn in rowColumns)
            {
                nodeColumns.AppendChild(GetColumnXML(rowTable, rowColumn, modeName, isLookup));
            }
            nodeTable.AppendChild(nodeColumns);
           
            nodeTable.AppendChild(GetTableConstraintsXML(modeName, rowTable));
            
            return nodeTable;
        }

        protected virtual XmlNode GetColumnXML(DataRow rowtable, DataRow rowColumn, string modeName, bool isLookup)
        {
            
            bool isPrimaryKey;
            XmlNode nodeColumn = NewElementWithName(modeName + "Column", XMLAddings.FixName(rowColumn["COLUMN_NAME"].ToString(), this.mRemovePrefix), rowColumn, "TABLE");
            nodeColumn.Attributes.Append(XMLAddings.NewAttribute(nodeColumn.OwnerDocument, "OriginalName", rowColumn["COLUMN_NAME"].ToString()));
            
            nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "Ordinal", rowColumn["ORDINAL_POSITION"].ToString()));
            string def = rowColumn["COLUMN_DEFAULT"].ToString();
            if (def.Length > 0)
            {
                nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "Default", def));
            }
            if (rowColumn["IS_NULLABLE"].ToString().ToLower() == "yes")
            {
                nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "AllowNulls", "true"));

                nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "AllowNulls", "false"));
            }
            nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "SQLType", XMLAddings.GetSQLTypeFromSQLType(rowColumn["DATA_TYPE"].ToString())));
            nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "NETType", XMLAddings.GetNETTypeFromSQLType(rowColumn["DATA_TYPE"].ToString())));
            nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "MaxLength", rowColumn["CHARACTER_MAXIMUM_LENGTH"].ToString()));
            isPrimaryKey = this.IsPrimaryKey(rowtable, rowColumn);
            nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "IsPrimaryKey", isPrimaryKey.ToString().ToLower()));
            if (isLookup && !isPrimaryKey)
            {
                nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "UseForDesc", "true"));
            }

            if (rowColumn["DOMAIN_NAME"].ToString().Length > 0)
            {
                nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "UDTCatalog", rowColumn["DOMAIN_CATALOG"].ToString()));
                nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "UDTOwner", rowColumn["DOMAIN_SCHEMA"].ToString()));
                nodeColumn.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "UDTName", rowColumn["DOMAIN_NAME"].ToString()));
            }
           
            return nodeColumn;
        }

        protected virtual void AddRelationsXML(string modeName, XmlNode nodeparent, DataRow rowtable)
        {
            XmlDocument xmlDoc = nodeparent.OwnerDocument;
            XmlNode nodeRelations = this.CreateElement(modeName + "Relations");
            XmlNode nodeRelation;
            XmlNode nodeRelated;
            DataRow[] rowKeys;
            DataRow[] rowConstraints;
            DataRow[] rowRefConstraints;
            
            DataRow rowPrimaryKey = GetPrimaryKeyConstraint(rowtable);
            if (rowPrimaryKey != null)
            {
     
                rowRefConstraints = mDataSet.Tables["ReferentialConstraints"].Select(ConstraintMatch(rowPrimaryKey, "", "UNIQUE_"));
                if (rowRefConstraints.GetLength(0) > 0)
                {
                    nodeRelation = this.CreateElement("ChildTables");
                    foreach (DataRow rowRefConstraint in rowRefConstraints)
                    {
                        rowKeys = mDataSet.Tables["KeyColumns"].Select(ConstraintMatch(rowRefConstraint));
                   
                        nodeRelated = this.CreateElement("ChildTable", XMLAddings.FixName(XMLAddings.GetSingular(rowKeys[0]["TABLE_NAME"].ToString()), this.mRemovePrefix));
                        AddKeyColumns(xmlDoc, nodeRelated, rowKeys, "ChildKeyField");
                        nodeRelation.AppendChild(nodeRelated);
                    }
                    nodeRelations.AppendChild(nodeRelation);
                }
            }

        
            rowConstraints = mDataSet.Tables["TableConstraints"].Select(TableMatch(rowtable) + " AND CONSTRAINT_TYPE='FOREIGN KEY'");
            if (rowConstraints.GetLength(0) > 0)
            {
                nodeRelation = this.CreateElement("ParentTables");
                foreach (DataRow rowConstraint in rowConstraints)
                {
                    rowRefConstraints = mDataSet.Tables["ReferentialConstraints"].Select(ConstraintMatch(rowConstraint));
                    foreach (DataRow rowRefConstraint in rowRefConstraints)
                    {
                        rowKeys = mDataSet.Tables["KeyColumns"].Select(ConstraintMatch(rowRefConstraint, "UNIQUE_", ""));
                        nodeRelated = this.CreateElement("ParentTable");
                        nodeRelated.Attributes.Append(XMLAddings.NewAttribute(xmlDoc, "Name", XMLAddings.FixName(rowKeys[0]["TABLE_NAME"].ToString(), this.mRemovePrefix)));
                        AddKeyColumns(xmlDoc, nodeRelated, rowKeys, "ParentKeyField");
                        nodeRelation.AppendChild(nodeRelated);

                        rowKeys = mDataSet.Tables["KeyColumns"].Select(ConstraintMatch(rowRefConstraint));
                        AddKeyColumns(xmlDoc, nodeRelated, rowKeys, "ChildField");
                    }
                }
                nodeRelations.AppendChild(nodeRelation);
            }
            nodeparent.AppendChild(nodeRelations);
        }

        protected virtual XmlNode GetPrivilegesXML(string modeName, DataRow[] rowPrivileges)
        {
            XmlNode nodePrivileges = this.CreateElement(modeName + "Privileges");
            XmlNode nodePrivilege;
            foreach (DataRow rowPrivilege in rowPrivileges)
            {
                nodePrivilege = this.CreateElement(modeName + "Privilege");
                nodePrivilege.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "Grantor", rowPrivilege["GRANTOR"].ToString()));
                nodePrivilege.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "Grantee", rowPrivilege["GRANTEE"].ToString()));
                nodePrivilege.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "Type", rowPrivilege["PRIVILEGE_TYPE"].ToString()));
                nodePrivileges.AppendChild(nodePrivilege);
            }
            return nodePrivileges;
        }

        protected virtual XmlNode GetTableConstraintsXML(string modeName, DataRow rowTable)
        {
            XmlNode nodeConstraints;
            nodeConstraints = this.CreateElement(modeName + "Constraints");
            AddPrimaryKeyXML(nodeConstraints, rowTable);
            AddRelationsXML(modeName, nodeConstraints, rowTable);
            AddUniqueConstraintXML(modeName, nodeConstraints, rowTable);
            
            return nodeConstraints;
        }

        protected virtual void AddUniqueConstraintXML(string modeName, XmlNode nodeParent, DataRow rowTable)
        {
            DataRow[] rowConstraints = mDataSet.Tables["TableConstraints"].Select(TableMatch(rowTable) + " AND CONSTRAINT_TYPE='UNIQUE'");
            foreach (DataRow row in rowConstraints)
            {
                XmlNode nodeConstraint = this.CreateElement("Unique");
                AddKeyColumns(nodeParent.OwnerDocument, nodeConstraint, mDataSet.Tables["KeyColumns"].Select(ConstraintMatch(row)), "UniqueField");
                nodeParent.AppendChild(nodeConstraint);
            }
        }

       

        protected virtual void AddPrimaryKeyXML(XmlNode nodeParent, DataRow rowTable)
        {
            DataRow rowPrimaryKey = GetPrimaryKeyConstraint(rowTable);
            if (rowPrimaryKey != null)
            {
                XmlNode nodeConstraint = this.CreateElement("PrimaryKey");
                AddKeyColumns(nodeParent.OwnerDocument, nodeConstraint, mDataSet.Tables["KeyColumns"].Select(ConstraintMatch(rowPrimaryKey)), "PKField");
                nodeParent.AppendChild(nodeConstraint);
            }
        }

        protected virtual void AddKeyColumns(XmlDocument xmldoc, XmlNode nodeParent, DataRow[] rowKeys, string fieldName)
        {
            XmlNode nodeKey;
            foreach (DataRow row in rowKeys)
            {
                nodeKey = this.CreateElement(fieldName, XMLAddings.FixName(row["COLUMN_NAME"].ToString(), this.mRemovePrefix));
                nodeKey.Attributes.Append(XMLAddings.NewAttribute(xmldoc, "Ordinal", row["ORDINAL_POSITION"].ToString()));
                nodeParent.AppendChild(nodeKey);
            }
        }
        #endregion

        
        protected virtual XmlElement NewElementWithName(string elementName, string name, DataRow row, params string[] prefixes)
        {
            string dbName;
            string owner;
            string partName;
            string fullName = null;
            XmlElement nodeElement = this.CreateElement(elementName, name);
            if (mUseVerboseNames && row != null)
            {
                foreach (string prefix in prefixes)
                {
                    dbName = row[prefix + "_CATALOG"].ToString();
                    owner = row[prefix + "_SCHEMA"].ToString();
                    partName = row[prefix + "_NAME"].ToString();
                    nodeElement.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, prefix + "Name", partName));
                    nodeElement.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, prefix + "Database", dbName));
                    nodeElement.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, prefix + "Owner", owner));
                    fullName += "[" + dbName + "].[" + owner + "].[" + partName + "]";
                    if (fullName.Length > 0)
                    {
                        fullName += "!";
                    }
                }
                nodeElement.Attributes.Append(XMLAddings.NewAttribute(mXMLDoc, "FullName", fullName));
            }
            return nodeElement;
        }

        #region Match
        protected virtual string GenericMatch(DataRow row, string targetPrefix, string sourcePrefix)
        {
            return string.Format("{0}CATALOG='{1}' AND {0}SCHEMA='{2}' AND {0}NAME='{3}'",
                                    targetPrefix,
                                    row[sourcePrefix + "CATALOG"].ToString(),
                                    row[sourcePrefix + "SCHEMA"].ToString(),
                                    row[sourcePrefix + "NAME"].ToString());
        }

        protected virtual string TableMatch(DataRow rowTable)
        {
            return GenericMatch(rowTable, "TABLE_", "TABLE_");
        }

        protected virtual string ColumnMatch(DataRow rowTable, DataRow rowColumn)
        {
            return TableMatch(rowTable) + " AND COLUMN_NAME='" + rowColumn["COLUMN_NAME"].ToString() + "'";
        }

        protected virtual string ConstraintMatch(DataRow rowConstraint)
        {
            return ConstraintMatch(rowConstraint, "", "");
        }

        protected virtual string ConstraintMatch(DataRow rowConstraint, string sourcePrefix, string targetPrefix)
        {
            return GenericMatch(rowConstraint, targetPrefix + "CONSTRAINT_", sourcePrefix + "CONSTRAINT_");
        }
        #endregion
        

        protected virtual void AddHierarchyNode(XmlNode nodeParent, XmlNode node, XmlNamespaceManager nsmgr)
        {
            XmlNodeList nodeList;
            XmlNode nodeTable;
            XmlNode nodeNew;
            nodeNew = this.CreateElement("HTable",
                XMLAddings.GetAttributeOrEmpty(node, "Name"));
            nodeParent.AppendChild(nodeNew);
            nodeList = node.SelectNodes("dbs:TableConstraints/dbs:TableRelations/dbs:ChildTables/dbs:ChildTable", nsmgr);
            foreach (XmlNode nodeChild in nodeList)
            {
                if (nodeNew.SelectSingleNode(
                    "ancestor-or-self::dbs:HTable[@Name='" +
                    XMLAddings.GetAttributeOrEmpty(nodeChild, "Name") + "']", nsmgr) == null)
                {
                    nodeTable = node.SelectSingleNode(
                        "ancestor::dbs:DataStructure/dbs:Tables/dbs:Table[@Name='" +
                        XMLAddings.GetAttributeOrEmpty(nodeChild, "Name") + "']", nsmgr);
                    AddHierarchyNode(nodeNew, nodeTable, nsmgr);
                }
            }
        }


        protected virtual bool IsPrimaryKey(DataRow rowTable, DataRow rowColumn)
        {
            DataRow rowPrimaryKey = GetPrimaryKeyConstraint(rowTable);
            DataRow[] rowKeyColumns;
            if (rowPrimaryKey != null)
            {
                rowKeyColumns = mDataSet.Tables["KeyColumns"].Select(ConstraintMatch(rowPrimaryKey) + " AND COLUMN_NAME='" + rowColumn["COLUMN_NAME"].ToString() + "'");
                return (rowKeyColumns.GetLength(0) > 0);
            }
            return false;
        }

        protected virtual DataRow GetPrimaryKeyConstraint(DataRow rowtable)
        {
            DataRow[] rowConstraints = mDataSet.Tables["TableConstraints"].Select(TableMatch(rowtable) + " AND CONSTRAINT_TYPE='PRIMARY KEY'");
            switch (rowConstraints.GetLength(0))
            {
                case 0:
                    
                    return null;
                case 1:
                    return rowConstraints[0];
                default:
                    throw new System.Exception("More than one primary key found on table " + rowtable["TABLE_NAME"].ToString());
            }
        }
        
    }
}
