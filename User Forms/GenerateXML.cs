using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TypeLib;
using System.Windows.Forms;

namespace User_Forms
{
    public class GenerateXML
    {
        TextWritter writer;

        public TextWritter Writer
        {
            get { return writer; }
            set { writer = value; }
        }
        string docContent;

        public GenerateXML()
        {
            writer = new TextWritter();
        }

        public void PrintHeader(string className, string classNamespace)
        {
            if (!className.Equals(String.Empty) && !classNamespace.Equals(String.Empty))
            {
                writer.WriteLine("<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "UTF-8" + '"' + "?>");
                writer.WriteLine("<ObjectDefinition>");
                writer.WriteLine("<ClassName>{0}</ClassName>", className);
                writer.WriteLine("<ClassNamespace>{0}</ClassNamespace>", classNamespace);
                writer.WriteLine();
            }
            else
            {
                MessageBox.Show("Class name and namespace name must be set !");
                throw new Exception();
            }
        }

        public void PrintFooter()
        {
            writer.WriteLine("</ObjectDefinition>");
        }

        public void Finilize()
        {
            docContent = writer.ToString();
            StreamWriter sw = new StreamWriter(@"..\..\..\templates\stefan.xml");
            sw.Write(docContent);
            sw.Flush();
            sw.Close();
        }

        public void PrintContent(string className, string fieldName, string fieldDataType, string cardinality, string compositeClass, string isID)
        {
            if (!fieldName.Equals(string.Empty) && fieldName != null)
            {
                writer.WriteLine("<Property>");
                writer.WriteLine("<ClassName>{0}</ClassName>", className);
                writer.WriteLine("<PropertyName>{0}</PropertyName>", fieldName);
                writer.WriteLine("<CompositeTypeName>{0}</CompositeTypeName>", compositeClass);
                writer.WriteLine("<PropType>{0}</PropType>", cardinality);
                writer.WriteLine("<DataType>{0}</DataType>", fieldDataType);
                writer.WriteLine("<IsID>{0}</IsID>", isID);
                writer.WriteLine("</Property>");
                writer.WriteLine();
            }
        }

    }
}
