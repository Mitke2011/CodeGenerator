using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code_Generation;
using JavaCodeGenerator;
using TypeLib;
namespace User_Forms
{
    public class Controler
    {
        IBusinessClassGenerator generat;
        private ObjectDefinition odef;
        private string fileLocation;
        private string xmlLocation;
        private IDBManagerGenerator generat2;

        public Controler()
        {
                
        }

        public Controler(string xmlLocation, string fileLocation)
        {
            this.xmlLocation = xmlLocation;
            this.fileLocation = fileLocation;
        }

        public void CreateClassFile(string language)
        {
            odef = ObjectDefinition.LoadFromFile(xmlLocation);
            if (language.Equals("C#"))
            {
                generat = new CodeGenerator(odef.ClassName);
            }
            else
            {
                generat = new JCodeGenerator(odef.ClassName);
            }
            generat = new CodeGenerator(odef.ClassName);
            generat.SaveCode(this.fileLocation);
        }

        public void CreateDBManagerClassFile(string constr,string language,string driver)
        {
            odef = ObjectDefinition.LoadFromFile(xmlLocation);
            if (language.Equals("C#"))
            {
                generat2 = (IDBManagerGenerator)new DBBrockerGenerator(odef.ClassName, constr);
            }
            else
            {
                generat2 = (IDBManagerGenerator) new JavaDBBrockerGenerator(odef.ClassName,constr,driver);
            }
           
            generat2.SaveCode(this.fileLocation);
        }
    }
}
