using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using MetadataFromDB;
using Saxon.Api;
using Saxon;
using MetadataFromDB;
using Middletier;

namespace XSLTResourceCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region PartitionedCode

            MetadataMerger mm = new MetadataMerger();
            //mm.MergeDocuments();

            //XslCompiledTransform tr7 = new XslCompiledTransform(true);
            //tr7.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 9\RichClient\layoutWinEdit.xslt");
            //tr7.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep13.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep14.cs");


            #region Probe i Saxon

            //            XslCompiledTransform tr1 = new XslCompiledTransform(true);
            //            tr1.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMObjectOne.xslt");
            //            tr1.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResult4.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep11.xml");

            //            XslCompiledTransform tr5 = new XslCompiledTransform(true); //NE RADI
            //            tr5.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\ObjectClassCreator.xslt");
            //            tr5.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep11.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\FinalObjects.xml");

            //            XslCompiledTransform tr2 = new XslCompiledTransform(true);
            //            tr2.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMObjectTwo.xslt");
            //            tr2.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep11.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep51.xml");

            //            XslCompiledTransform tr3 = new XslCompiledTransform(true);
            //            tr3.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMBuildOne.xslt");
            //            tr3.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep2.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep30.xml");

            //            XslCompiledTransform tr4 = new XslCompiledTransform(true);
            //            tr4.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMBuildTwo.xslt");
            //            tr4.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep3.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep41.xml");



            #region Saxon

            //const string xmlFile =
            //     @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep11.xml";
            //const string xsltFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\ObjectClassCreator.xslt";
            //const string outFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult.xml";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFile))
            //    using (XmlReader xslt = XmlReader.Create(xsltFile))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().
            //            Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //        Console.WriteLine("Output written to " + outFile + Environment.NewLine);
            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}

            #endregion

            #endregion

            #region Pokretanje Aplikacije

            #region Pokretanje koda za dobijanje DB XML
            //ExtractMetadataFromDB extr = new SQLServerExtraction("MITKE-PC");
            //XmlDocument dbMeta = new XmlDocument();
            //dbMeta = extr.CreateMetaData(true, "", "", "", "", "ASPBaza");
            //dbMeta.Save(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml");
            #endregion

            //#region Spajannje dokumenata za ORM ili UI XML

            string dbm = @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            string orm = @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\ORMSimplest3.xml";

            //string orm = @"C:\Users\mitke\Desktop\ORMSimplest3.xml";

            //MetadataMerger mm1 = new MetadataMerger(dbm, orm); //Spajanje fajlova
            //mm1.MergeDocuments();

            #endregion

            #region Pokretanje transformacije za generisanje domenskih klasa - SAXON
            //const string xmlFile =
            //     @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            //const string xsltFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\DomainClassGenerationTransformation.xslt";
            //const string outFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult.xml";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFile))
            //    using (XmlReader xslt = XmlReader.Create(xsltFile))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().
            //            Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //        Console.WriteLine("Output written to " + outFile + Environment.NewLine);
            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}
            #endregion

            #region Pokretanje transformacija za generisanje procedura
            //            XslCompiledTransform trSP1 = new XslCompiledTransform(true);
            //            tr1.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPSelectSingle.xslt");
            //            tr1.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\DBMeta3.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\SPSelectSingle.txt");

            //            XslCompiledTransform trSP2 = new XslCompiledTransform(true);
            //            tr1.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPSelectALL.xslt");
            //            tr1.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\DBMeta3.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\SPSelectALL.txt");

            //            XslCompiledTransform trSP3 = new XslCompiledTransform(true);
            //            tr1.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPUpdate.xslt");
            //            tr1.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\DBMeta3.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\SPUpdate.txt");

            //            XslCompiledTransform trSP4 = new XslCompiledTransform(true);
            //            trSP4.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPInsert.xslt");
            //            trSP4.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\DBMeta3.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\SPInsert.txt");

            //            XslCompiledTransform trSP5 = new XslCompiledTransform(true);
            //            tr1.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPDeleteSingle.xslt");
            //            tr1.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\DBMeta3.xml",
            //@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\SPDeleteSingle.txt");
            #endregion

            #region ORM XML


            //XslCompiledTransform tr1 = new XslCompiledTransform(true);
            //tr1.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMObjectOne.xslt");
            //tr1.Transform(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm\MergeResultORMFinal.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj\MergeResultStepFinalXMLORM.xml");

            //XslCompiledTransform tr2 = new XslCompiledTransform(true);
            //tr2.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMObjectTwo.xslt");
            //tr2.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj\MergeResultStepFinalXMLORM.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj\MergeResultObject1.xml");

            //XslCompiledTransform tr3 = new XslCompiledTransform(true);
            //tr3.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMBuildOne.xslt");
            //tr3.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj\MergeResultObject1.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj\MergeResultobject2.xml");

            //XslCompiledTransform tr4 = new XslCompiledTransform(true);
            //tr4.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\CodeGenDotNet 159059-1372 (a)\CSharp\Chapter 6\ORMTransform\ORMBuildTwo.xslt");
            //tr4.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj\MergeResultobject2.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj\ORMFinal.xml");

            #endregion

            #region Pokretanje transformacija za generisanje ORM klasa - SAXON

            //const string xmlFile =
            //    @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml";


            //const string xsltFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\ObjectClassCreator.xslt";
            //const string outFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult.xml";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFile))
            //    using (XmlReader xslt = XmlReader.Create(xsltFile))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //        Console.WriteLine("Output written to " + outFile + Environment.NewLine);
            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}
            #endregion

            #region UI XML
            //MetadataMerger mm3 = new MetadataMerger(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\MergeResultStep12.xml",
            //                                        @"C:\Users\mitke\Desktop\UISimplest1.xml");
            //mm3.MergeDocuments("UI");

            //MetadataMerger mm3 = new MetadataMerger(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml",
            //                                        @"C:\Users\mitke\Desktop\UISimplest1.xml");
            //mm3.MergeDocuments("UI");
            #endregion

            #region Pokretanje transformacija za generisanje UI klasa - SAXON

            //XslCompiledTransform tr6 = new XslCompiledTransform(true);
            //tr6.Load(@"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\XSLT\WinInputTransform.xslt");
            //tr6.Transform(@"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\templates\ui\MergeResultUIFinal.xml",
            //              @"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\templates\ui\UIInput.xml");

            //XslCompiledTransform tr8 = new XslCompiledTransform(true); //.design.cs klasa
            //tr8.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\WinFormGeneratorTemplate.xslt");
            //tr8.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\ui\UIInput.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\WinFormPatternApplication\FinalUIClass.designer.cs");

            //XslCompiledTransform tr9 = new XslCompiledTransform(true); //.design.cs klasa
            //tr9.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\WinFormGeneratorTemplate.xslt");
            //tr9.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\ui\UIInput.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\WinFormPatternApplication\FinalUIClass.designer.cs");
            #endregion

            //Proizvod pr = new Proizvod();
            //pr.NazivProperty = "Laptop";
            //pr.KolicinaProperty = 1;

            //MiddletierManager mt=new MiddletierManager();
            //mt.Save(pr);

            #region Insert Procedures
            //const string xmlFile =
            //     @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\DBMeta3.xml";
            //const string insertTransformation = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPInsert.xslt";
            ////const string outFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult.xml";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFile))
            //    using (XmlReader xslt = XmlReader.Create(insertTransformation))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().
            //            Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        //serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //       // Console.WriteLine("Output written to " + outFile + Environment.NewLine);
            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}
            #endregion

            #region Delete Procedures
            //const string xmlFile =
            //    @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            //const string deleteTransformation = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPDeleteSingle.xslt";
            //const string outFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult.xml";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFile))
            //    using (XmlReader xslt = XmlReader.Create(deleteTransformation))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().
            //            Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        //serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //        //Console.WriteLine("Output written to " + outFile + Environment.NewLine);
            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}
            #endregion

            #region Update Procedures
            //const string xmlFileUp =
            //    @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            //const string updateTransformation = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPUpdate.xslt";
            ////const string outFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult.xml";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFileUp))
            //    using (XmlReader xslt = XmlReader.Create(updateTransformation))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().
            //            Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        //serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //        //Console.WriteLine("Output written to " + outFile + Environment.NewLine);
            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}
            #endregion

            #region Select All Procedures
            //const string xmlFileSelAll =
            //    @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            //const string selectAllTransformation = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPSelectALL.xslt";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFileSelAll))
            //    using (XmlReader xslt = XmlReader.Create(selectAllTransformation))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().
            //            Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        //serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}
            #endregion

            #region Select One Procedures
            //const string xmlFileSelOne =
            //    @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Konacni fajlovi\Generisani fajlovi\db\DBMeta.xml";
            //const string selectOneTransformation = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\SPSelectSingle.xslt";

            //try
            //{
            //    using (XmlReader xml = XmlReader.Create(xmlFileSelOne))
            //    using (XmlReader xslt = XmlReader.Create(selectOneTransformation))
            //    {
            //        // Create a Processor instance
            //        var processor = new Processor();

            //        // Load the source document
            //        XdmNode input = processor.NewDocumentBuilder().
            //            Build(xml);

            //        // Create a transformer for the stylesheet
            //        XsltTransformer transformer = processor.NewXsltCompiler().
            //            Compile(xslt).Load();

            //        // Set the root node of the source document to be the initial context node
            //        transformer.InitialContextNode = input;

            //        // Create a serializer
            //        var serializer = new Serializer();
            //        //serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));

            //        // Transform the source XML
            //        transformer.Run(serializer);

            //    }
            //}
            //catch (Exception e)
            //{
            //    ConsoleColor currentConsoleColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("oops : " + e.Message);
            //    Console.ForegroundColor = currentConsoleColor;
            //}
            #endregion

            #region ORM XML MODIFIED


            //XslCompiledTransform trM = new XslCompiledTransform(true);
            //trM.Load(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\promenjene_transformacije\ORMObjectOne.xslt");
            //trM.Transform(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm\MergeResultORMFinal.xml",
            //              @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultStepFinalXMLORM.xml");

            //XslCompiledTransform trM2 = new XslCompiledTransform(true);
            //trM2.Load(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\promenjene_transformacije\ORMObjectTwo.xslt");
            //trM2.Transform(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultStepFinalXMLORM.xml",
            //              @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultObject1.xml");

            //XslCompiledTransform trM3 = new XslCompiledTransform(true);
            //trM3.Load(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\promenjene_transformacije\ORMBuildOne.xslt");
            //trM3.Transform(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultObject1.xml",
            //              @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml");


            //Suvisna
            //XslCompiledTransform trM4 = new XslCompiledTransform(true);
            //trM4.Load(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\promenjene_transformacije\ORMBuildTwo.xslt");
            //trM4.Transform(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml",
            //              @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDORMFinal.xml");

            #endregion

            #endregion
            XSLTManager manager = new XSLTManager();
            manager.GenerateObjectXML("MITKE-PC", "ASPBaza");
            manager.GenerateObjectClasses();
            manager.GenerateDomainClasses();

            //MetadataMerger mm3 = new MetadataMerger(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\orm_obj_modified\MODIFIEDMergeResultobject2Final.xml",
            //                                        @"C:\Users\mitke\Desktop\UISimplest1.xml");
            //mm3.MergeDocuments("UI");


            //XslCompiledTransform tr6 = new XslCompiledTransform(true);
            //tr6.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\WinInputTransform.xslt");
            //tr6.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\ui\MergeResultUIFinal.xml",
            // 
            //XslCompiledTransform tr9 = new XslCompiledTransform(true); //.design.cs klasa
            //tr9.Load(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\XSLT\WinFormGeneratorTemplate.xslt");
            //tr9.Transform(@"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\ui\UIInput.xml",
            //              @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\WinFormPatternApplication\FinalUIClass.designer.cs");
            // 

            //XslCompiledTransform tr10 = new XslCompiledTransform(true); //designer.cs
            //tr10.Load(@"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\XSLT\WinFormEventPage.xslt");
            //tr10.Transform(@"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\templates\ui\UIInput.xml",
            //               @"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\WinFormPatternApplication\FinalUIClass.cs");


           // const string xmlFile =
           //@"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\templates\ui\UIInput.xml";
           // const string xsltFile = @"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\XSLT\WinFormGeneratorTemplate.xslt";
           // const string outFile = @"C:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\templates\Saxonresult1.xml";

           // try
           // {
           //     using (XmlReader xml = XmlReader.Create(xmlFile))
           //     using (XmlReader xslt = XmlReader.Create(xsltFile))
           //     {
           //         var processor = new Processor();
           //         XdmNode input = processor.NewDocumentBuilder().Build(xml);
           //         XsltTransformer transformer = processor.NewXsltCompiler().
           //             Compile(xslt).Load();
           //         transformer.InitialContextNode = input;
           //         var serializer = new Serializer();
           //         serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));
           //         transformer.Run(serializer);
           //         Console.WriteLine("Output written to " + outFile + Environment.NewLine);
           //     }
           // }
           // catch (Exception e)
           // {
           //     ConsoleColor currentConsoleColor = Console.ForegroundColor;
           //     Console.ForegroundColor = ConsoleColor.Red;
           //     Console.WriteLine("oops : " + e.Message);
           //     Console.ForegroundColor = currentConsoleColor;
           // }
            //primer putnaje za xml fajl string path2 = @"..\..\..\templates\ui\UIInput.xml"; Slicno odradi i za ostale
           //  string xmlFile =
           //@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main 2013-06-05\Code Generator Main\templates\ui\UIInput.xml";
           // const string xsltFile = @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main 2013-06-05\Code Generator Main\XSLT\WinListDesign.xslt";
           // const string outFile = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult1.xml";

           // try
           // {
           //     using (XmlReader xml = XmlReader.Create(xmlFile))
           //     using (XmlReader xslt = XmlReader.Create(xsltFile))
           //     {
           //         var processor = new Processor();
           //         XdmNode input = processor.NewDocumentBuilder().Build(xml);
           //         XsltTransformer transformer = processor.NewXsltCompiler().
           //             Compile(xslt).Load();
           //         transformer.InitialContextNode = input;
           //         var serializer = new Serializer();
           //         serializer.SetOutputStream(new FileStream(outFile, FileMode.Create, FileAccess.Write));
           //         transformer.Run(serializer);
           //         Console.WriteLine("Output written to " + outFile + Environment.NewLine);
           //     }
           // }
           // catch (Exception e)
           // {
           //     ConsoleColor currentConsoleColor = Console.ForegroundColor;
           //     Console.ForegroundColor = ConsoleColor.Red;
           //     Console.WriteLine("oops : " + e.Message);
           //     Console.ForegroundColor = currentConsoleColor;
           // }

           //// const string xmlFile =
           ////@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main 2013-06-05\Code Generator Main\templates\ui\UIInput.xml";
           // const string xsltFile2 = @"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main 2013-06-05\Code Generator Main\XSLT\WinListEvent.xslt";
           // const string outFile2 = @"C:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main\templates\Saxonresult12.xml";

           // try
           // {
           //     using (XmlReader xml = XmlReader.Create(xmlFile))
           //     using (XmlReader xslt = XmlReader.Create(xsltFile2))
           //     {
           //         var processor = new Processor();
           //         XdmNode input = processor.NewDocumentBuilder().Build(xml);
           //         XsltTransformer transformer = processor.NewXsltCompiler().
           //             Compile(xslt).Load();
           //         transformer.InitialContextNode = input;
           //         var serializer = new Serializer();
           //         serializer.SetOutputStream(new FileStream(outFile2, FileMode.Create, FileAccess.Write));
           //         transformer.Run(serializer);
           //         Console.WriteLine("Output written to " + outFile2 + Environment.NewLine);
           //     }
           // }
           // catch (Exception e)
           // {
           //     ConsoleColor currentConsoleColor = Console.ForegroundColor;
           //     Console.ForegroundColor = ConsoleColor.Red;
           //     Console.WriteLine("oops : " + e.Message);
           //     Console.ForegroundColor = currentConsoleColor;
           // }
            

        }
    }
}
