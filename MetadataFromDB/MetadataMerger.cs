using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MetadataFromDB
{
    public class MetadataMerger
    {
        private XmlDocument dbm = new XmlDocument();
        private XmlDocument orm = new XmlDocument();

        public MetadataMerger()
        {

        }

        public MetadataMerger(string mainInputLocation, string mergerLocation)
        {
            dbm.Load(mainInputLocation);
            orm.Load(mergerLocation);
        }

        public void MergeDocuments(string operationName = "ORM")
        {
            MergeRootNode(dbm, orm);
            switch (operationName)
            {
                case "ORM": SaveORM(dbm);
                    break;
                case "UI": SaveUI(dbm);
                    break;
            }
        }

        private void SaveORM(XmlDocument source)
        {
            source.Save(@"..\..\..\templates\orm\MergeResultORMFinal.xml");
        }

        private void SaveUI(XmlDocument source)
        {
            source.Save(@"..\..\..\templates\ui\MergeResultUIFinal.xml");
        }

        private void MergeRootNode(XmlDocument dbSource, XmlDocument ormSource)
        {
            XmlNode resultRoot = null;
            XmlNode mergRoot = null;

            foreach (XmlNode rootNode in dbSource.ChildNodes)
            {
                if (rootNode.NodeType == XmlNodeType.Element)
                {
                    resultRoot = rootNode;
                }
            }

            foreach (XmlNode mergeNode in ormSource.ChildNodes)
            {
                if (mergeNode.NodeType == XmlNodeType.Element)
                {
                    mergRoot = mergeNode;
                }
            }

            if (GetAttributeOrEmpty(mergRoot, "FreeForm").ToUpper().Equals("TRUE"))
            {
                foreach (XmlNode merg in mergRoot.ChildNodes)
                {
                    MergeNode(resultRoot, merg, null);
                }
            }
            else
            {
                MergeNode(resultRoot, mergRoot, null);
            }
        }

        private void MergeNode(XmlNode result, XmlNode node, XmlAttribute namedAttribute)//rekurzivno se poziva, detaljno objasni
        {
            XmlNamespaceManager nmsp = new XmlNamespaceManager(result.OwnerDocument.NameTable);
            string predicate = "";
            nmsp.AddNamespace(node.Prefix, node.NamespaceURI);

            if (namedAttribute != null)
            {
                predicate = "[@Name='" + namedAttribute.Value + "']";
            }

            XmlNode searchTestNode = result.SelectSingleNode(node.Name + predicate, nmsp);

            if (searchTestNode == null)
            {
                AddChildNode(result, node);
            }
            else
            {
                foreach (XmlAttribute attribut in node.Attributes)
                {
                    if (searchTestNode.Attributes[attribut.Name] == null)
                    {
                        searchTestNode.Attributes.Append(NewAttribute(searchTestNode.OwnerDocument, attribut.Name,
                                                                      attribut.Value));
                    }
                    else
                    {
                        searchTestNode.Attributes[attribut.Name].Value = attribut.Value;
                    }
                }
                foreach (XmlNode child in node.ChildNodes)
                {
                    MergeNode(searchTestNode, child, child.Attributes["Name"]);
                }
            }


        }

        private void AddChildNode(XmlNode result, XmlNode node)
        {
            result.AppendChild(result.OwnerDocument.ImportNode(node, true));
        }

        private string GetAttributeOrEmpty(XmlNode resultRoot, string attributeName)
        {
            string result = "";
            if (resultRoot != null)
            {
                if (resultRoot.Attributes != null)
                {
                    XmlNode mainNode = resultRoot.Attributes.GetNamedItem(attributeName);
                    if (mainNode != null)
                    {
                        result = mainNode.Value;
                    }
                }
            }
            return result;
        }

        private System.Xml.XmlAttribute NewAttribute(System.Xml.XmlDocument xmlDoc, string name, string value)
        {
            System.Xml.XmlAttribute nodeAttribute;
            nodeAttribute = xmlDoc.CreateAttribute(name);
            nodeAttribute.Value = value;
            return nodeAttribute;
        }
    }
}
