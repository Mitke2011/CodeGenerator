using System.IO;
using TypeLib;

namespace Code_Generation
{
    public class CodeGenerator : IBusinessClassGenerator
    {
        ObjectDefinition oDef;
        private TextWritter tw;

        public string SourceCode = null;

        public void SaveCode(string Path)
        {
            if (string.IsNullOrEmpty(SourceCode)) this.Build();

            StreamWriter sw = new StreamWriter(Path);
            sw.Write(SourceCode);
            sw.Flush();
            sw.Close();
        }

        public CodeGenerator(string className)
        {
            oDef = TypeManager.GetType(className);
            tw = new TextWritter();
        }

        public void Build()
        {
            tw.WriteLine("using System;");
            tw.WriteLine("using System.Collections.Generic;");
            tw.WriteLine("using System.Xml;");
            tw.WriteLine("using System.Xml.Schema;");
            tw.WriteLine("using System.Xml.Serialization;");
            tw.WriteLine("using System.Linq;");
            tw.WriteLine("using System.Text;");


            tw.WriteLine();
            tw.WriteLine("namespace {0}", oDef.ClassNamespace);
            tw.WriteLine("{");
            tw.Indent();

            GenerateClassBody(oDef, tw);
            tw.WriteLine();

            tw.WriteLine();
            tw.OutDent();
            tw.WriteLine("}"); // namespace


            SourceCode = tw.ToString();
        }

        public void GenerateClassBody(ObjectDefinition oDef, TextWritter tw)
        {
            tw.WriteLine();
            tw.WriteLine();

            tw.WriteLine("public class {0}", oDef.ClassName);
            tw.WriteLine("{");
            tw.Indent();

            tw.WriteLine();
            tw.WriteLine("public {0}()", oDef.ClassName);
            tw.WriteLine("{");
            tw.WriteLine("}");
            tw.WriteLine();

            //parametrized ctor
            string ctorParams = "";

            foreach (var property in oDef.Property)
            {
                ctorParams += "," + property.PropertyName + property.PropType;
            }
            //
            tw.WriteLine();

            foreach (PropertyDefinition pDef in oDef.Property)
            {
                GenerateProperty(pDef, tw);
                if (pDef.IsID)
                {
                    GenerateIDProperty(pDef, tw);
                }
            }

            tw.WriteLine();

            tw.WriteLine("}");

        }

        public void GenerateIDProperty(PropertyDefinition pDef, TextWritter tw)
        {
            tw.WriteLine("public {0} GetIDProp", pDef.PropDataType);
            //tw.WriteLine();
            tw.Indent();
            tw.WriteLine("{");
            tw.WriteLine();
            //tw.OutDent();
            tw.WriteLine("get");
            tw.Indent();
            tw.WriteLine("{");
            // tw.Indent();
            tw.WriteLine("return this.{0};", pDef.PropertyName);
            //tw.OutDent();
            tw.WriteLine("}");
            tw.WriteLine();
            tw.WriteLine("}");
            tw.OutDent();
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
                case DataType.Byte:
                    initString = "= 0";
                    generateSpecified = true;
                    break;
                case DataType.DateTime:
                    initString = "= DateTime.MinValue";
                    generateSpecified = true;
                    break;
                case DataType.Double:
                    initString = "= 0.0";
                    generateSpecified = true;
                    break;
                case DataType.Single:
                    initString = "= 0.0F";
                    generateSpecified = true;
                    break;
                case DataType.Int16:
                case DataType.Int32:
                case DataType.Int64:
                    initString = "= 0";
                    generateSpecified = true;
                    break;
                default:
                    initString = "= null";
                    break;

            }

            GenerateGenericProperty(typeName, pDef, tw, initString, generateSpecified);

        }

        public void GenerateListProperty(PropertyDefinition pDef, TextWritter tw)
        {
            string listTypeName = string.Format("List<{0}>", GetTypeName(pDef));
            string initString = " = null";

            GenerateGenericProperty(listTypeName, pDef, tw, initString, false);
        }


        public string GetTypeName(PropertyDefinition pDef)
        {
            if (pDef.PropType == PropertyType.Composite || pDef.PropType == PropertyType.ListComposites)
            {
                return pDef.CompositeTypeName;
            }

            return pDef.PropDataType.ToString();
        }

        private void GenerateGenericProperty(string typeName, PropertyDefinition pDef, TextWritter tw, string initString, bool generateSpecified)
        {
            tw.WriteLine("private {0} {1}Field {2};", typeName, pDef.PropertyName, initString);
            tw.WriteLine("public {0} {1}", typeName, pDef.PropertyName);
            tw.WriteLine("{");
            tw.Indent();
            tw.WriteLine();
            tw.WriteLine("get");
            tw.WriteLine("{");
            tw.Indent();
            if (!generateSpecified && typeName != "String")
            {
                tw.WriteLine("if ({0}Field == null)", pDef.PropertyName);
                tw.WriteLine("{0}Field = new {1}();", pDef.PropertyName, typeName);
            }
            tw.WriteLine("return {0}Field;", pDef.PropertyName);
            tw.OutDent();
            tw.WriteLine("}");
            tw.WriteLine();
            tw.WriteLine("set");
            tw.WriteLine("{");
            tw.Indent();

            tw.WriteLine("{0}Field = value;", pDef.PropertyName);
            tw.OutDent();
            tw.WriteLine("}");
            tw.OutDent();
            tw.WriteLine("}");
            tw.WriteLine();
        }
    }
}
