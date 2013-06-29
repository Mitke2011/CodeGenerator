using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetadataFromDB
{
   public class XMLAddings
    {
       public static System.Xml.XmlAttribute NewBoolAttribute(System.Xml.XmlDocument xmlDoc, string name, bool value)
       {
           System.Xml.XmlAttribute nodeAttribute;
           nodeAttribute = xmlDoc.CreateAttribute(name);
           if (value)
           {
               nodeAttribute.Value = "true";
           }
           else
           {
               nodeAttribute.Value = "false";
           }
           return nodeAttribute;
       }

       public static System.Xml.XmlAttribute NewAttribute(System.Xml.XmlDocument xmlDoc, string name, string value)
       {
           System.Xml.XmlAttribute nodeAttribute;
           nodeAttribute = xmlDoc.CreateAttribute(name);
           nodeAttribute.Value = value;
           return nodeAttribute;
       }

       public static string GetSingular(string name)
       {
           if (name.ToLower().EndsWith("ss") | !name.ToLower().EndsWith("s"))
           {
               // This is generally not a plural    
               return name;
           }
           else if (name.ToLower().EndsWith("us"))
           {
               // This is generally not a plural
               return name;
           }
           else if (name.ToLower().EndsWith("sses"))
           {
               return name.Substring(0, name.Length - 2);
           }
           else if (name.ToLower().EndsWith("uses"))
           {
               return name.Substring(0, name.Length - 2);
           }
           else if (name.ToLower().EndsWith("ies"))
           {
               // NOTE: You can't tell from here if it used to be ey or y. You must
               //       add the specific cases important to you.
               return name.Substring(0, name.Length - 3) + "y";
           }
           else if (name.ToLower().EndsWith("s"))
           {
               return name.Substring(0, name.Length - 1);
           }
           else
           {
               return name; // We shouldnt be able to get here
           }
       }

       public static string GetPlural(string name)
       {
           // Simple rules, you may need to expand these. Create new Case entries 
           // above the Else for any exceptions important to you
           string testName = GetSingular(name);
           switch (testName)
           {
               default:
                   if (testName.EndsWith("ey"))
                   {
                       return testName.Substring(0, testName.Length - 2) + "ies";
                   }
                   else if (testName.EndsWith("ay"))
                   {
                       return testName.Substring(0, testName.Length) + "s";
                   }
                   else if (testName.EndsWith("y"))
                   {
                       return testName.Substring(0, testName.Length - 1) + "ies";
                   }
                   else if (testName.EndsWith("ss"))
                   {
                       return testName.Substring(0, testName.Length) + "es";
                   }
                   else if (testName.EndsWith("us"))
                   {
                       return testName.Substring(0, testName.Length) + "es";
                   }
                   else if (testName.EndsWith("s"))
                   {
                       return testName.Substring(0, testName.Length - 1) + "es";
                   }
                   else
                   {
                       return testName + "s";
                   }
           }
       }

       public static string FixName(string name) //osnovni poziv
       {
           return FixName(name, false);
       } 

       public static string FixName(string name, string removePrefix)
       {
           return FixName(name, (removePrefix.Trim().ToLower() == "true"));
       }

       public static string FixName(string name, bool removePrefix)
       {
           string ret = name;
           string keywords;
           // remove any blanks
           if (removePrefix)
           {
               ret = ret.Substring(GetPrefix(ret).Length);
           }
           ret = ret.Replace(" ", "_");

           // replace c# keywords( C# is case sensitive )
           keywords = " abstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual void volatile while ";
           if (keywords.IndexOf(" " + ret + " ") > 0)
           {
               ret = "_" + ret;
           }

           return ret;
       }

       public static string GetPrefix(string name)
       {
           string ret = name;

           for (int i = 0; i <= name.Length - 1; i++)
           {               
               if (Char.IsUpper(name, i))
               {
                   return name.Substring(0, i);
               }
           }
           return name;
       }

       public static string GetAttributeOrEmpty(System.Xml.XmlNode node, string attributeName)
       {
           string ret = "";
           if (node != null)
           {
               if (node.Attributes != null)
               {
                   System.Xml.XmlNode attr = node.Attributes.GetNamedItem(attributeName);
                   if (attr != null)
                   {
                       ret = attr.Value;
                   }
               }
           }
           return ret;
       }

       public static void AppendIfExists(System.Xml.XmlNode node, System.Xml.XmlNode nodeChild)
       {
           if (nodeChild != null)
           {
               node.AppendChild(nodeChild);
           }
       }

       public static string GetSQLTypeFromSQLType(string SQLTypeName)
       {
           // This is kind of ugly, and currently we don't store the 
           // original type, trusting this synonum and case insensitity
           switch (SQLTypeName.ToLower())
           {
               case "numeric":
                   SQLTypeName = "decimal";
                   break;
           }
           // This is to fix the case for C#
           SQLTypeName = Enum.Parse(typeof(System.Data.SqlDbType), SQLTypeName, true).ToString();
           return SQLTypeName;
       }

       public static string GetNETTypeFromSQLType(string SQLTypeName)
       {
           switch (SQLTypeName.ToLower())
           {
               case "int":
                   return "System.Int32";
               case "smallint":
                   return "System.Int16";
               case "bigint":
                   return "System.Int64";
               case "decimal":
                   return "System.Decimal";
               case "base64Binary":
                   return "System.Byte()";
               case "boolean":
                   return "bool";
               case "dateTime":
                   return "System.DateTime";
               case "float":
                   return "System.Double";
               case "real":
                   return "System.Single";
               case "unsignedByte":
                   return "System.Byte";
               case "char":
               case "nchar":
               case "varchar":
               case "nvarchar":
               case "ntext":
               case "text":
                   return "System.String";
               case "date":
               case "datetime":
               case "smalldatetime":
                   return "System.DateTime";
               case "money":
               case "smallmoney":
               case "numeric":
                   return "System.Decimal";
               case "bit":
                   return "bool";
               case "tinyint":
                   return "System.Byte";
               case "timestamp":
                   return "System.Byte()";
               case "uniqueidentifier":
                   return "System.Guid";
               case "image":
               case "binary":
               case "varbinary":
                   return "System.Byte()"; // This is an issue as it is VB or C# specific
               default:
                   System.Diagnostics.Debug.WriteLine("type not found - {0}", SQLTypeName);
                   break;
           }
           return null;
       }

    }
}
