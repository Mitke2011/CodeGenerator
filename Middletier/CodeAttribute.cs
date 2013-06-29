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
