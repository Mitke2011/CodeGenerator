using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using MetadataFromDB;
using Saxon.Api;

namespace XSLTResourceCreator
{
    public class XSLTManager
    {
        private MetadataMerger mm;

        public void GenerateDBXML(string serverName, string dbName)
        {
            //MITKE-PC,ASPBaza

            ExtractMetadataFromDB extr = new SQLServerExtraction(serverName);
            XmlDocument dbMeta = new XmlDocument();
            dbMeta = extr.CreateMetaData(dbName);
            dbMeta.Save(@"..\..\..\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml");
        }

        public void GenerateObjectXML(string serverName, string dbName)
        {
            GenerateDBXML(serverName, dbName);

            string dbm = @"..\..\..\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            string orm = @"..\..\..\templates\Konacni fajlovi\ORMSimplest3.xml";
            mm = new MetadataMerger(dbm, orm); //Spajanje fajlova
            mm.MergeDocuments();

            XslCompiledTransform trM = new XslCompiledTransform(true);
            trM.Load(@"..\..\..\templates\promenjene_transformacije\ORMObjectOne.xslt");
            trM.Transform(@"..\..\..\templates\orm\MergeResultORMFinal.xml",
                          @"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultStepFinalXMLORM.xml");

            XslCompiledTransform trM2 = new XslCompiledTransform(true);//moze da se izbaci
            trM2.Load(@"..\..\..\templates\promenjene_transformacije\ORMObjectTwo.xslt");
            trM2.Transform(@"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultStepFinalXMLORM.xml",
                          @"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultObject1.xml");

            XslCompiledTransform trM3 = new XslCompiledTransform(true);
            trM3.Load(@"..\..\..\templates\promenjene_transformacije\ORMBuildOne.xslt");
            trM3.Transform(@"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultObject1.xml",
                          @"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml");
        }

        public void GenerateUIXML()
        {
            mm = new MetadataMerger(@"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml",
                                                    @"C:\Users\mitke\Desktop\UISimplest1.xml");
            mm.MergeDocuments("UI");

            XslCompiledTransform tr6 = new XslCompiledTransform(true);
            tr6.Load(@"..\..\..\XSLT\WinInputTransform.xslt");
            tr6.Transform(@"..\..\..\templates\ui\MergeResultUIFinal.xml",
                          @"..\..\..\templates\ui\UIInput.xml");
        }

        public void GenerateObjectClasses()
        {
            const string xmlFile =
            @"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml";

            const string xsltFile = @"..\..\..\XSLT\ObjectClassCreator.xslt";
            const string outFile = @"..\..\..\templates\Saxonresult1.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile))
                {

                    var processor = new Processor();


                    XdmNode input = processor.NewDocumentBuilder().Build(xml);


                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();


                    transformer.InitialContextNode = input;


                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));


                    transformer.Run(serializer);

                    Console.WriteLine("Output written to " + outFile + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }
        }

        public void GenerateDomainClasses()
        {
            const string xmlFile =
                 @"..\..\..\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            const string xsltFile = @"..\..\..\XSLT\DomainClassGenerationTransformation.xslt";
            const string outFile = @"..\..\..\templates\Saxonresult2.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile))
                {

                    var processor = new Processor();

                    XdmNode input = processor.NewDocumentBuilder().
                        Build(xml);

                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();

                    transformer.InitialContextNode = input;

                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }
        }

        public void GenerateWinFormUI()
        {
            const string xmlFile =
           @"..\..\..\templates\ui\UIInput.xml";
            const string xsltFile = @"..\..\..\XSLT\WinFormGeneratorTemplate.xslt";
            const string outFile = @"..\..\..\templates\Saxonresult3.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }

            const string xmlFile2 =
           @"..\..\..\templates\ui\UIInput.xml";
            const string xsltFile2 = @"..\..\..\XSLT\WinFormEventPage.xslt";
            const string outFile2 = @"..\..\..\templates\Saxonresult4.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile2))
                using (XmlReader xslt = XmlReader.Create(xsltFile2))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile2, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile2 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }
        }

        public void GenerateWinFormListForms()
        {
            string xmlFile =
          @"..\..\..\templates\ui\UIInput.xml";
            const string xsltFile = @"..\..\..\XSLT\WinListDesign.xslt";
            const string outFile = @"..\..\..\templates\Saxonresult5.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }
           
            const string xsltFile2 = @"..\..\..\XSLT\WinListEvent.xslt";
            const string outFile2 = @"..\..\..\templates\Saxonresult6.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile2))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile2, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile2 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }
        }

        public void GenerateASPNETUI()
        {
           // const string xmlFile =
           //@"..\..\..\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml";
            const string xmlFile = @"..\..\..\templates\ui\UIInput.xml";
            const string xsltFile = @"..\..\..\XSLT\ASPXPageGenerator.xslt";
            const string outFile = @"..\..\..\templates\Saxonresult7.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }


            const string xsltFile2 = @"..\..\..\XSLT\AspxCsGeneratorPage.xslt";
            const string outFile1 = @"..\..\..\templates\Saxonresult71.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile2))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile1, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile1 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }


            const string xsltFile3 = @"..\..\..\XSLT\DesignerPageGenerator.xslt";
            const string outFile2 = @"..\..\..\templates\Saxonresult72.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile3))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile2, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile2 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }
        }

        public void GenerateASPNETListUI()
        {
            const string xmlFile =
           @"..\..\..\templates\ui\UIInput.xml";
            const string xsltFile = @"..\..\..\XSLT\ASPXListPage.xslt";
            const string outFile = @"..\..\..\templates\Saxonresult8.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }


            const string xsltFile2 = @"..\..\..\XSLT\ASPXListDesigner.xslt";
            const string outFile1 = @"..\..\..\templates\Saxonresult81.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile2))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile1, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile1 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }


            const string xsltFile3 = @"..\..\..\XSLT\ASPXListCSPage.xslt";
            const string outFile2 = @"..\..\..\templates\Saxonresult82.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile3))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile2, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile2 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }
        }

        public void GenerateStorredProcedures()
        {
            const string xmlFile =
           @"..\..\..\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            const string xsltFile = @"..\..\..\XSLT\SPSelectSingle.xslt";
            const string outFile2 = @"..\..\..\templates\Saxonresult9.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile2, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile2 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }

            const string xsltFile2 = @"..\..\..\XSLT\SPSelectALL.xslt";
            const string outFile1 = @"..\..\..\templates\Saxonresult91.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile2))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile1, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile1 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }

            const string xsltFile3 = @"..\..\..\XSLT\SPUpdate.xslt";
            const string outFile3 = @"..\..\..\templates\Saxonresult92.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile3))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile3, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile3 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }

            const string xsltFile4 = @"..\..\..\XSLT\SPInsert.xslt";
            const string outFile4 = @"..\..\..\templates\Saxonresult94.xml";

            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile4))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile4, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile4 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }

            const string xsltFile5 = @"..\..\..\XSLT\SPDeleteSingle.xslt";
            const string outFile5 = @"..\..\..\templates\Saxonresult95.xml";
            try
            {
                using (XmlReader xml = XmlReader.Create(xmlFile))
                using (XmlReader xslt = XmlReader.Create(xsltFile5))
                {
                    var processor = new Processor();
                    XdmNode input = processor.NewDocumentBuilder().Build(xml);
                    XsltTransformer transformer = processor.NewXsltCompiler().
                        Compile(xslt).Load();
                    transformer.InitialContextNode = input;
                    var serializer = new Serializer();
                    serializer.SetOutputStream(new FileStream(outFile5, FileMode.Create, FileAccess.Write));
                    transformer.Run(serializer);
                    Console.WriteLine("Output written to " + outFile5 + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                ConsoleColor currentConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("oops : " + e.Message);
                Console.ForegroundColor = currentConsoleColor;
            }

        }
    }
}
