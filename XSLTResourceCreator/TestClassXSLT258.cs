using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSLTResourceCreator
{
    public class TestClassXSLT258
    {
        public static void Main(string[] args)
        {
            XSLTManager manager = new XSLTManager();
            manager.GenerateObjectXML("MITKE-PC", "ASPBaza");
            manager.GenerateDBXML("MITKE-PC", "ASPBaza");
            manager.GenerateObjectClasses();
            manager.GenerateDomainClasses();
            manager.GenerateStorredProcedures();
            manager.GenerateUIXML();
            manager.GenerateWinFormUI();
            manager.GenerateWinFormListForms();

            manager.GenerateASPNETUI();
            manager.GenerateASPNETListUI();

            Console.ReadLine();
        }
    }
}
