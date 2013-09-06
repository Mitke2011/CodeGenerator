using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using EnvDTE80;
using EnvDTE90;
using EnvDTE100;
using VslangProj90;
using VSLangProj;
using System.IO;
using System.Threading;
using Thread = System.Threading.Thread;
using Microsoft.Build.BuildEngine;
using Project = EnvDTE.Project;
using Middletier;
using Engine = Microsoft.Build.BuildEngine.Engine;

namespace ProjectCreator
{
    public class ProjectGenerator
    {
        public DTE2 dte;//= (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
        //public DTE2 dte = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.11.0");

        public ProjectGenerator(string VSversion)
        {
            if (VSversion.Equals("Visual Studio 2010"))
            {
                dte = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
            }
            else
            {
                dte = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.11.0");
            }
        }

        public void CreateSolution(GennInfo gen, bool generateObjects, bool generateDomains)//(string DirPath, string vsversion, string vslocation)
        {
            string str1 = string.Concat(gen.VSLocation, @"\Common7\IDE\ProjectTemplatesCache\CSharp\Windows\1033\ClassLibrary.zip\csClassLibrary.vstemplate");
            string cl = (new Uri(str1)).LocalPath;

            string vs = "";

            if (gen.version.Equals("Visual Studio 2010"))
            {
                vs = "VisualStudio.Solution.10.0";
            }
            else
            {
                if (gen.version.Equals("Visual Studio 2012"))
                {
                    vs = "VisualStudio.Solution.11.0";
                }
            }
            
            MessageFilter.Register();
            Type solutionObject = Type.GetTypeFromProgID(vs, true);
            Solution4 sol = System.Activator.CreateInstance(solutionObject, true) as Solution4;
            MessageFilter.Revoke();

            if (generateObjects)
            {
                GenerateObjectProjects(gen, sol, cl);
            }
            if (generateDomains)
            {
                GenerateDomainProjects(gen, sol, cl); 
            }
        }

        private void GenerateObjectProjects(GennInfo gen, Solution4 sol, string cl)
        {
            ClearDirectory(@"e:\tempSolutionCLOB", @"e:\tempSolutionCLOB\classLibproject");
            sol.Create(@"e:\tempSolutionCLOB", "ObjectProject");
            MessageFilter.Register();
            sol.AddFromTemplate(cl, @"e:\tempSolutionCLOB\classLibproject", "ObjectProject", true);
            string[] ObjectFiles = Directory.GetFiles(gen.locationObj);

            for (int i = 0; i < ObjectFiles.Length; i++)
            {
                sol.Projects.Item(1).ProjectItems.AddFromFileCopy(ObjectFiles[i]);
            }

            //Microsoft.Build.BuildEngine.Engine en = new Microsoft.Build.BuildEngine.Engine();
            //BuildPropertyGroup bpg = new BuildPropertyGroup();
            //bpg.SetProperty("Configuration", "Debug");
            //bpg.SetProperty("Platform", "AnyCPU");
            //en.BuildProjectFile(@"e:\tempSolutionCLOB\classLibproject\ObjectProject.csproj", null, bpg);

            VSProject vp1 = (sol.Projects.Item(1)).Object as VSProject;

            vp1.References.Add(gen.locationMid + @"\Middletier.dll");//middletier.dll JER SADA IZ NJEGA VUCEM CODEATTRIBUTE KLASU

            sol.SaveAs("ObjectProject.sln");

            SolutionBuild2 solSb = (SolutionBuild2)sol.SolutionBuild;
            solSb.SolutionConfigurations.Item("Debug").Activate();
            solSb.Build(true);
            sol.Close(false);
            MessageFilter.Revoke();
            
            MessageFilter.Revoke();
        }

        private void ClearDirectory(string rootPath, string childPath)
        {
            DirectoryInfo dirInfoRoot = new DirectoryInfo(rootPath);
            DirectoryInfo dirInfoChild = new DirectoryInfo(childPath);

            foreach (var file in dirInfoRoot.GetFiles())
            {
                file.Delete();
            }

            foreach (var file in dirInfoChild.GetFiles())
            {
                file.Delete();
            }

            foreach (var dir in dirInfoChild.GetDirectories())
            {
                dir.Delete(true);
            }

        }

        private void GenerateDomainProjects(GennInfo gen, Solution4 sol, string cl)
        {
            ClearDirectory(@"e:\tempSolutionCLDom", @"e:\tempSolutionCLDom\classLibproject");
            sol.Create(@"e:\tempSolutionCLDom", "DomainProject");

            sol.AddFromTemplate(cl, @"e:\tempSolutionCLDom\classLibproject", "DomainProject", true);
            MessageFilter.Register();
            string[] ObjectFiles = Directory.GetFiles(gen.locationDom);

            for (int i = 0; i < ObjectFiles.Length; i++)
            {
                sol.Projects.Item(1).ProjectItems.AddFromFileCopy(ObjectFiles[i]);
            }

            //Engine en = new Engine();
            //BuildPropertyGroup bpg = new BuildPropertyGroup();
            //bpg.SetProperty("Configuration", "Debug");
            //bpg.SetProperty("Platform", "AnyCPU");
            //en.BuildProjectFile(@"e:\tempSolutionCLDom\classLibproject\DomainProject.csproj", null, bpg);

            VSProject vp1 = (sol.Projects.Item(1)).Object as VSProject;

            vp1.References.Add(gen.locationMid + @"\Middletier.dll");//middletier.dll JER SADA IZ NJEGA VUCEM CODEATTRIBUTE KLASU

            sol.SaveAs("DomainProject.sln");

            SolutionBuild2 solSb = (SolutionBuild2)sol.SolutionBuild;
            solSb.SolutionConfigurations.Item("Debug").Activate();
            solSb.Build(true);
            sol.Close(false);
            
            MessageFilter.Revoke();

        }

        public void AddProjects(string[] projectPaths, GennInfo gen, string objbin, string dombin)//string appType, string vsversion, string vslocation) //@"e:\tempSolutionCL\classLibproject"
        {
            List<Project> lp = new List<Project>();

            Solution4 solDestination = (Solution4)dte.Solution;
            
            solDestination = this.CreateDestinationSolution(gen);

            if (File.Exists(@"e:\tempSolutionCLOB\ObjectProject.sln"))
            {
                File.Delete(@"e:\tempSolutionCLOB\ObjectProject.sln");
            }

            if (File.Exists(@"e:\tempSolutionCLDom\DomainProject.sln"))
            {
                File.Delete(@"e:\tempSolutionCLDom\DomainProject.sln");
            }

            string projectPath = "";
            for (int i = 0; i < projectPaths.Length; i++)
            {
                projectPath = projectPaths[i];
                string[] projectslocations = Directory.GetFiles(projectPath, "*.csproj", SearchOption.AllDirectories);

                foreach (string proj in projectslocations)
                {
                    MessageFilter.Register();
                    solDestination.AddFromFile(proj, false);
                    MessageFilter.Revoke();
                }
            }

            MessageFilter.Register();
            var reference = (solDestination.Projects.Item(1).Object as VSProject).References.Add(objbin);
            MessageFilter.Revoke();
            MessageFilter.Register();
            var reference2 = (solDestination.Projects.Item(1).Object as VSProject).References.Add(gen.locationMid + @"\Middletier.dll");
            MessageFilter.Revoke();
            MessageFilter.Register();
            var reference3 = (solDestination.Projects.Item(1).Object as VSProject).References.Add(dombin);
            MessageFilter.Revoke();

            MessageFilter.Register();
            if (gen.UiType.Equals("ASP.NET"))
            {
                solDestination.SaveAs("ASPWebApplication.sln");
            }
            else
            {
                solDestination.SaveAs("WinFormsApplication.sln");
            }

            SolutionBuild2 buildDestination = null;

            buildDestination = solDestination.SolutionBuild as SolutionBuild2;

            buildDestination.SolutionConfigurations.Item("Debug").Activate();
            buildDestination.Build(true);
            
            solDestination.Close(false);
            MessageFilter.Revoke();

        }

        public Solution4 CreateDestinationSolution(GennInfo gen)//(string appType, string vsversion, string vslocation)
        {
            string vs = "";

            if (gen.version.Equals("Visual Studio 2010"))
            {
                vs = "VisualStudio.Solution.10.0";
            }
            else
            {
                if (gen.version.Equals("Visual Studio 2012"))
                {
                    vs = "VisualStudio.Solution.11.0";
                }
            }
            MessageFilter.Register();
            Type solutionObject = Type.GetTypeFromProgID(vs, true);
            Solution4 sln = System.Activator.CreateInstance(solutionObject, true) as Solution4;
            #region  Generate UI?

            if (gen.GenerateUI)
            {
                if (gen.UiType.Equals("ASP.NET"))
                {
                    string templateWebApp = string.Concat(gen.VSLocation,
                                                          @"\Common7\IDE\ProjectTemplatesCache\CSharp\Web\1033\WebApplicationProject40.zip\WebApplicationProject40.vstemplate");
                    
                    ClearDirectory(@"e:\tempSolution", @"e:\tempSolution\websiteproject");
                    sln.Create(@"e:\tempSolution", "ASPWebApplication");

                    Uri u = new Uri(templateWebApp);
                    //Uri u2 = new Uri(str1);
                    string ws = u.LocalPath;
                    sln.AddFromTemplate(ws, @"e:\tempSolution\websiteproject", "ASPWebApplication", true);

                    #region Dodaj WEB UI stranice

                    string[] UIFiles =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWebUIDesignClasses", gen.locationUI),
                                           "*aspx");

                    try
                    {
                        for (int i = 0; i < UIFiles.Length; i++)
                        {
                            sln.Projects.Item(1).ProjectItems.AddFromFileCopy(UIFiles[i]);
                        }
                    }
                    catch (Exception)
                    {


                    }

                    string[] UIListFiles =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWebUIListDesignClasses", gen.locationUI),
                                           "*aspx");

                    try
                    {
                        for (int i = 0; i < UIListFiles.Length; i++)
                        {
                            sln.Projects.Item(1).ProjectItems.AddFromFileCopy(UIListFiles[i]);
                        }
                    }
                    catch (Exception)
                    {


                    }

                    #endregion


                    sln.SaveAs(@"e:\tempSolution\ASPWebApplication.sln");
                    return sln;
                }

                else
                {
                    string winapptemplatepath = string.Concat(gen.VSLocation,
                                                              @"\Common7\IDE\ProjectTemplatesCache\CSharp\Windows\1033\WindowsApplication.zip\csWindowsApplication.vstemplate");

                    ClearDirectory(@"e:\tempSolution2", @"e:\tempSolution2\winproject");
                    sln.Create(@"e:\tempSolution2", "WinFormsApplication");

                    Uri u = new Uri(winapptemplatepath);
                    string ws = u.LocalPath;
                    sln.AddFromTemplate(ws, @"e:\tempSolution2\winproject", "WinFormsApplication", true);

                    #region Dodaj WIN UI stranice

                    string[] UIFiles =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignClasses", gen.locationUI));

                    string[] UIFileNames =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignClasses", gen.locationUI))
                                 .Select(path => Path.GetFileName(path))
                                 .ToArray();


                    for (int i = 0; i < UIFiles.Length; i++)
                    {
                        if (!File.Exists(string.Format(@"{0}\{1}", @"e:\tempSolution2\winproject", UIFileNames[i])))
                        {
                            sln.Projects.Item(1).ProjectItems.AddFromFileCopy(UIFiles[i]);
                        }
                    }

                    string[] UIFilesList =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignListClasses", gen.locationUI));

                    string[] UIFileNamesList =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignListClasses", gen.locationUI)).Select(path => Path.GetFileName(path)).ToArray();

                    for (int i = 0; i < UIFilesList.Length; i++)
                    {
                        if (!File.Exists(string.Format(@"{0}\{1}", @"e:\tempSolution2\winproject", UIFileNamesList[i])))
                        {
                            sln.Projects.Item(1).ProjectItems.AddFromFileCopy(UIFilesList[i]);
                        }
                    }

                    #endregion

                    sln.SaveAs(@"e:\tempSolution2\WinFormsApplication.sln");
                    MessageFilter.Revoke();
                    return sln;


                }
            }

            #endregion

            return sln;
        }
    }
}
