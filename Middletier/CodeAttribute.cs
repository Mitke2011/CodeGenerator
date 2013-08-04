using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Middletier
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property|AttributeTargets.Method)]
    public class CodeAttribute : System.Attribute
    {
        public string columnName;
        public string tableName;
        public bool isID = false;
        public string parentTable = "";
        public string parentTableKey = "";
        public bool isForeignKey;

        public CodeAttribute(string columnName, string tableName, bool isFieldID,bool isForeignKey,string parentTable, string parentTableKey)
        {
            this.columnName = columnName;
            this.tableName = tableName;
            this.isID = isFieldID;
            this.isForeignKey = isForeignKey;
            if (!parentTable.Equals(string.Empty) && !parentTableKey.Equals(string.Empty))
            {
                this.parentTable = parentTable;
                this.parentTableKey = parentTableKey;
            }
        }

        public CodeAttribute(string columnName, string tableName,bool isForeignKey, string parentTable, string parentTableKey)
        {
            this.columnName = columnName;
            this.tableName = tableName;
            this.isForeignKey = isForeignKey;
            if (!parentTable.Equals(string.Empty) && !parentTableKey.Equals(string.Empty))
            {
                this.parentTable = parentTable;
                this.parentTableKey = parentTableKey;
            }
        }

        public CodeAttribute(string tableName, string parentTable, string parentTableKey)
        {
            this.tableName = tableName;
            if (!parentTable.Equals(string.Empty) && !parentTableKey.Equals(string.Empty))
            {
                this.parentTable = parentTable;
                this.parentTableKey = parentTableKey;
            }
        }


        public CodeAttribute(string columnName, string tableName, bool isFieldID)
        {
            this.columnName = columnName;
            this.tableName = tableName;
            this.isID = isFieldID;
        }

        public CodeAttribute(string columnName, string tableName)
        {
            this.columnName = columnName;
            this.tableName = tableName;
        }

        public CodeAttribute(string tableName)
        {
            this.tableName = tableName;
        }
    }
}
