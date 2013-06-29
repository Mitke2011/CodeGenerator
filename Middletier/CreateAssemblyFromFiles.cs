using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Code_Generation;
using System.IO;
using TypeLib;
namespace Middletier
{
    public class CreateAssemblyFromFiles
    {
        public CodeCompileUnit cpu;
        CodeDomProvider provider = new CSharpCodeProvider();
        public CodeTypeDeclaration genClass;
        //public string fileName = @"c:\Users\Mitic\Desktop\StefanCodeDomKlasa.cs";
        public string fileName = "";
        public CodeNamespace generatorNamespace;

        #region Primer koda
        //public CreateAssemblyFromFiles()
        //{
        //    InitializeGraph();
        //}

        //public void InitializeGraph()
        //{
        //    this.cpu = new CodeCompileUnit();
        //    this.generatorNamespace = new CodeNamespace();

        //    this.genClass = new CodeTypeDeclaration("SimpleClass");
        //    this.genClass.IsClass = true;

        //}

        //public void FillTheGraph(CodeCompileUnit cpu, CodeNamespace generatorNamespace, CodeTypeDeclaration genClass)
        //{
        //    #region Stari kod
        //    //CodeCompileUnit cpu = new CodeCompileUnit();
        //    //CodeNamespace generatorNamespace = new CodeNamespace("GeneratorNamespace");
        //    //CodeMemberField[] classFields = new CodeMemberField[]
        //    //                                    {
        //    //                                        new CodeMemberField(typeof(int),"ID"){Attributes = MemberAttributes.Private},
        //    //                                        new CodeMemberField(typeof(string),"name"){Attributes = MemberAttributes.Private}
        //    //                                    }; 
        //    #endregion

        //    generatorNamespace.Imports.AddRange(
        //        new CodeNamespaceImport[]
        //            {
        //                new CodeNamespaceImport("System"),
        //                new CodeNamespaceImport("System.Collections.Generic"),
        //                new CodeNamespaceImport("System.Linq"), 
        //                new CodeNamespaceImport("System.Text"),
        //                new CodeNamespaceImport("Code_Generation")
        //            });

        //    genClass.TypeAttributes = TypeAttributes.Public;


        //    #region Konstruktori
        //    CodeConstructor emptyCtor = new CodeConstructor();
        //    emptyCtor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
        //    CodeFieldReferenceExpression field1 = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "name");
        //    emptyCtor.Statements.Add(new CodeAssignStatement(field1, new CodePrimitiveExpression("")));

        //    CodeConstructor paramCtor = new CodeConstructor();
        //    paramCtor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
        //    paramCtor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "name"));
        //    CodeFieldReferenceExpression field2 = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "name");
        //    paramCtor.Statements.Add(new CodeAssignStatement(field2, new CodeArgumentReferenceExpression("name")));

        //    #endregion

        //    #region Polja klase
        //    CodeTypeMember[] classFields = new CodeMemberField[]
        //                                        {
        //                                            new CodeMemberField(typeof(int),"id"){Attributes = MemberAttributes.Private},
        //                                            new CodeMemberField(typeof(string),"name"){Attributes = MemberAttributes.Private}
        //                                        };
        //    #endregion

        //    #region Svojstva

        //    CodeAttribute ca1 = new CodeAttribute("kolona1", "tabela1");
        //    CodeAttribute ca2 = new CodeAttribute("kolona2", "tabela2");

        //    CodeMemberProperty prop1 = new CodeMemberProperty();
        //    prop1.CustomAttributes.Add(new CodeAttributeDeclaration(ca1.GetType().Name,
        //                                new CodeAttributeArgument(new CodePrimitiveExpression(ca1.columnName)),

        //                                new CodeAttributeArgument(new CodePrimitiveExpression(ca1.tableName))));
        //    prop1.Name = "ID";
        //    prop1.Type = new CodeTypeReference(typeof(int));
        //    prop1.HasGet = true;
        //    prop1.HasSet = false;
        //    prop1.Attributes = MemberAttributes.Public | MemberAttributes.Final;
        //    prop1.GetStatements.Add(
        //        new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "id")));

        //    CodeMemberProperty prop2 = new CodeMemberProperty();
        //    prop2.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(ca2.GetType().Name),
        //                                                            new CodeAttributeArgument(new CodePrimitiveExpression
        //                                                                                          (ca2.columnName)),
        //                                                            new CodeAttributeArgument(new CodePrimitiveExpression(ca1.tableName))));

        //    prop2.Name = "Name";
        //    prop2.HasGet = true;
        //    prop2.HasSet = true;
        //    prop2.Attributes = MemberAttributes.Public | MemberAttributes.Final;
        //    prop2.Type = new CodeTypeReference(typeof(string));
        //    prop2.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "name")));
        //    prop2.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "name"), new CodePropertySetValueReferenceExpression()));
        //    #endregion

        //    genClass.Members.AddRange(classFields);
        //    genClass.Members.AddRange(new CodeTypeMember[]
        //    {
        //        prop1,
        //        prop2,
        //        emptyCtor,
        //        paramCtor
        //    }
        //);
        //    generatorNamespace.Types.Add(genClass);
        //    cpu.Namespaces.Add(generatorNamespace);

        //    #region Kompajliranje u asembli
        //    #endregion

        //    //generisanje koda iz asemblija
        //    #region Generisanje koda
        //    #endregion
        //}
        #endregion

        public CreateAssemblyFromFiles(ObjectDefinition odef)
        {
            InitializeXMLCodeGraph(odef);
        }

        public void InitializeXMLCodeGraph(ObjectDefinition odef)
        {
            this.cpu = new CodeCompileUnit();
            this.generatorNamespace = new CodeNamespace(odef.ClassNamespace);

            this.genClass = new CodeTypeDeclaration(odef.ClassName);
            this.genClass.IsClass = true;
        }

        public void CompileCodeToAssembly(CodeCompileUnit cpu)
        {
            CompilerParameters cp = new CompilerParameters();
            //sluzi da se uspostavi referenca ka projektima koje tekuci projekat mora da vidi,samim tim i da se omoguci koriscenje using naredbi
            cp.ReferencedAssemblies.AddRange(new string[]
                                                 {
          "System.dll"                                           
                                                 });

            var results = provider.CompileAssemblyFromDom(cp, cpu);
        }

        public void GenerateCodeFromCompileUnit(CodeCompileUnit compileUnit, string finalFileName)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CodeGeneratorOptions go = new CodeGeneratorOptions();
            go.BracingStyle = "C";
            using (StreamWriter sm = new StreamWriter(finalFileName))
            {
                provider.GenerateCodeFromCompileUnit(compileUnit, sm, go);
            }

            //var newCPU = provider.Parse(new StreamReader(finalFileName));
        }

        #region Generate from ObjectDefinition XML

        public void CreateClass(string templateLocation)
        {
            ObjectDefinition odef = ObjectDefinition.LoadFromFile(templateLocation);

            generatorNamespace.Imports.AddRange(
                new CodeNamespaceImport[]
                    {
                        new CodeNamespaceImport("System"),
                        new CodeNamespaceImport("System.Collections.Generic"),
                        new CodeNamespaceImport("System.Linq"), 
                        new CodeNamespaceImport("System.Text"),
                        new CodeNamespaceImport("Code_Generation")
                    });
            genClass.TypeAttributes = TypeAttributes.Public;

            this.CreateClasConstructors(odef.Property);
            this.CreateClassFields(odef.Property);
            this.CreateClassProperties(odef.Property);

            generatorNamespace.Types.Add(genClass);
            cpu.Namespaces.Add(generatorNamespace);
        }

        public void CreateClassProperties(List<PropertyDefinition> properties)
        {
            #region Svojstva

            CodeMemberProperty prop2 = new CodeMemberProperty();

            foreach (var item in properties)
            {
                prop2.Name = item.PropertyName;
                prop2.HasGet = true;
                //prop2.HasSet = !item.IsID; //ostaviti na savest korisniku da u bazi regulise primarni kljuc
                prop2.HasSet = true;
                prop2.Type = new CodeTypeReference(item.PropDataType.ToString());
                prop2.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                prop2.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), item.PropertyName.ToLower())));
                prop2.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), item.PropertyName.ToLower()), new CodePropertySetValueReferenceExpression()));

                this.genClass.Members.Add(prop2);
            }

            #endregion
        }

        public void CreateClassFields(List<PropertyDefinition> fields)
        {
            #region Polja klase
            List<CodeMemberField> ctmList = new List<CodeMemberField>();

            foreach (var item in fields)
            {
                ctmList.Add(new CodeMemberField(item.PropDataType.ToString(), item.PropertyName.ToLower()) { Attributes = MemberAttributes.Private });
            }

            CodeTypeMember[] classFields = ctmList.ToArray();
            genClass.Members.AddRange(classFields);
            #endregion
        }

        public void CreateClasConstructors(List<PropertyDefinition> properties)
        {
            #region Konstruktori
            CodeConstructor emptyCtor = new CodeConstructor();
            emptyCtor.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            CodeConstructor paramCtor = new CodeConstructor();
            paramCtor.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            foreach (var item in properties)
            {
                CodeFieldReferenceExpression field1 = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), item.PropertyName.ToLower());

                switch (item.PropDataType.ToString())
                {
                    case "Single":
                    case "Byte":
                    case "Double":
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Decimal": emptyCtor.Statements.Add(new CodeAssignStatement(field1, new CodePrimitiveExpression(0)));
                        break;
                    case "Boolean": emptyCtor.Statements.Add(new CodeAssignStatement(field1, new CodePrimitiveExpression(true)));
                        break;
                    case "DateTime": emptyCtor.Statements.Add(new CodeAssignStatement(field1, new CodePrimitiveExpression(DateTime.Now)));
                        break;
                    case "String": emptyCtor.Statements.Add(new CodeAssignStatement(field1, new CodePrimitiveExpression("")));
                        break;
                    default:
                        emptyCtor.Statements.Add(new CodeAssignStatement(field1, new CodePrimitiveExpression(null)));
                        break;
                }
                paramCtor.Parameters.Add(new CodeParameterDeclarationExpression(item.PropDataType.ToString(), item.PropertyName.ToLower()));
                CodeFieldReferenceExpression field2 = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), item.PropertyName.ToLower());
                paramCtor.Statements.Add(new CodeAssignStatement(field2, new CodeArgumentReferenceExpression(item.PropertyName.ToLower())));
            }

            genClass.Members.AddRange(new CodeTypeMember[] { emptyCtor, paramCtor });

            #endregion
        }

        #endregion
    }
}
