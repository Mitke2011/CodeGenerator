using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MetadataFromDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SQLServerExtraction sqlex = new SQLServerExtraction("MITKE-PC");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc = sqlex.CreateMetaData("ASPBaza");
        }
    }
}
