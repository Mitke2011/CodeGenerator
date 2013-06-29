using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TypeLib;

namespace JavaCodeGenerator
{
    public class JCodeGenerator:Code_Generation.IBusinessClassGenerator
    {
        ObjectDefinition oDef;
        private TypeLib.TextWritter tw;
        public string SourceCode = null;
        
        public void SaveCode(string Path)
        {
            if (string.IsNullOrEmpty(SourceCode)) this.Build();

            StreamWriter sw = new StreamWriter(Path);
            sw.Write(SourceCode);
            sw.Flush();
            sw.Close();
        }

        public JCodeGenerator(string className)
        {
            oDef = TypeLib.TypeManager.GetType(className);
            tw= new TextWritter();
        }
        
        public void Build()
        {
            tw.WriteLine("package {0};",oDef.ClassNamespace);
            tw.WriteLine();
            tw.WriteLine();
            tw.WriteLine("public class {0}",oDef.ClassName);
            tw.WriteLine("{");
            tw.WriteLine();
            GenerateClassBody(oDef,tw);
            tw.WriteLine();
            tw.WriteLine("}");

            SourceCode = tw.ToString();
        }

        public void GenerateClassBody(ObjectDefinition oDef, TextWritter indent)
        {
            tw.WriteLine();
            tw.WriteLine("public {0} ()",oDef.ClassName);
            tw.WriteLine("{");
            tw.WriteLine();
            tw.WriteLine("}");

            foreach (PropertyDefinition pDef in oDef.Property)
            {
                GenerateProperty(pDef, tw);
                if (pDef.IsID)
                {
                    GenerateIDProperty(pDef, tw);
                }
            }

        }

        public void GenerateIDProperty(PropertyDefinition pDef, TextWritter textWritter)
        {
            tw.WriteLine("public {0} getIDProp()", pDef.PropDataType);
            
            tw.WriteLine("{");
            textWritter.Indent();
            tw.WriteLine("return this.{0}Field;", pDef.PropertyName);
            tw.WriteLine("}");
            tw.WriteLine();
            
            tw.OutDent();
        }

        public string GetTypeName(PropertyDefinition pDef)
        {
            if (pDef.PropType == PropertyType.Composite || pDef.PropType == PropertyType.ListComposites)
            {
                return pDef.CompositeTypeName;
            }

            return pDef.PropDataType.ToString();
        }

        public void GenerateSingularProperty(string typeName, PropertyDefinition pDef, TextWritter tw)
        {
            string initString = string.Empty;
            bool generateSpecified = false;
            switch (pDef.PropDataType)
            {
                case DataType.Boolean:
                    initString = "= false";
                    generateSpecified = true;
                    break;
                case DataType.Date:
                    initString = "= new Date()";
                    generateSpecified = true;
                    break;
                case DataType.Double:
                    initString = "= 0.0";
                    generateSpecified = true;
                    break;
               case DataType.Integer:
                    initString = "= 0";
                    generateSpecified = true;
                    break;
               case DataType.Long:
                    initString = "= 0";
                    generateSpecified = true;
                    break;
                default:
                    initString = "= null";
                    break;
            }

            GenerateGenericProperty(typeName, pDef, tw, initString, generateSpecified);
        }

        private void GenerateGenericProperty(string typeName, PropertyDefinition pDef, TextWritter textWritter, string initString, bool generateSpecified)
        {
            tw.WriteLine("private {0} {1}Field {2};", typeName, pDef.PropertyName, initString);
            tw.WriteLine("public {0} get{1}()", typeName, pDef.PropertyName);
            tw.WriteLine("{");
            tw.Indent();
            tw.WriteLine();
           
            if (!generateSpecified && typeName != "String")
            {
                tw.WriteLine("if ({0}Field == null)", pDef.PropertyName);
                tw.WriteLine("{0}Field = new {1}();", pDef.PropertyName, typeName);
            }
            tw.WriteLine("return {0}Field;", pDef.PropertyName);
            tw.OutDent();
            tw.WriteLine("}");
            tw.WriteLine();
           
            tw.WriteLine("public void set{0}({1} value)", pDef.PropertyName,typeName);
            tw.WriteLine("{");
            tw.Indent();

            tw.WriteLine("{0}Field = value;", pDef.PropertyName);
            tw.OutDent();
            tw.WriteLine("}");
                                                  
        }

        public void GenerateListProperty(PropertyDefinition pDef, TextWritter tw)
        {
            string listTypeName = string.Format("List<{0}>", GetTypeName(pDef));
            string initString = " = null";

            GenerateGenericProperty(listTypeName, pDef, tw, initString, false);
        }

        public void GenerateProperty(PropertyDefinition pDef, TextWritter tw)
        {
            switch (pDef.PropType)
            {

                case PropertyType.Simple:
                case PropertyType.Composite:
                    GenerateSingularProperty(GetTypeName(pDef), pDef, tw);
                    break;
                case PropertyType.ListSimple:
                case PropertyType.ListComposites:
                    GenerateListProperty(pDef, tw);
                    break;
            }
        }
    }
}
