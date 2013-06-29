using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TypeLib
{
    public partial class ObjectDefinition
    {
        static XmlSerializer ser = new XmlSerializer(typeof(ObjectDefinition));
        
        public static ObjectDefinition LoadFromFile(string path)
        {
            ObjectDefinition oDef = null;

            oDef = ser.Deserialize(new XmlTextReader(path)) as ObjectDefinition;                   

            oDef.Commit();

            return oDef;

        }

        public static bool SaveToFile(ObjectDefinition oDef, string path)
        {

            try
            {
                using (XmlWriter writer = XmlTextWriter.Create(path))
                {
                    ser.Serialize(writer, oDef);

                    writer.Flush();
                    writer.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool Save(string Path)
        {
            return SaveToFile(this, Path);
        }

        public void Commit()
        {
            TypeManager.RegisterType(this);
        }

    }
}
