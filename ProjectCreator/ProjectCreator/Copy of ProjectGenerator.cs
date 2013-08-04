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
    public class BackupProjectGenerator
    {
        public DTE2 dte;//= (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
        //public DTE2 dte = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.11.0");

        public BackupProjectGenerator(string VSversion)
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

        public void CreateSolution(GennInfo gen)//(string DirPath, string vsversion, string vslocation)
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


            Type solutionObject = Type.GetTypeFromProgID(vs, true);
            Solution4 sol = System.Activator.CreateInstance(solutionObject, true) as Solution4;

            GenerateObjectProjects(gen, sol, cl);
            GenerateDomainProjects(gen, sol, cl);


        }

        private void GenerateObjectProjects(GennInfo gen, Solution4 sol, string cl)
        {
            try
            {
                sol.Create(@"e:\tempSolutionCLOB", "ObjectProject");
            }
            catch (Exception)
            {

            }
            try
            {
                sol.AddFromTemplate(cl, @"e:\tempSolutionCLOB\classLibproject", "ObjectProject", true);
            }
            catch (Exception)
            {

            }

            string[] ObjectFiles = Directory.GetFiles(gen.locationObj);

            try
            {
                for (int i = 0; i < ObjectFiles.Length; i++)
                {
                    sol.Projects.Item(1).ProjectItems.AddFromFileCopy(ObjectFiles[i]);
                }
            }
            catch (Exception)
            {

            }

            //Microsoft.Build.BuildEngine.Engine en = new Microsoft.Build.BuildEngine.Engine();
            //BuildPropertyGroup bpg = new BuildPropertyGroup();
            //bpg.SetProperty("Configuration", "Debug");
            //bpg.SetProperty("Platform", "AnyCPU");
            //en.BuildProjectFile(@"e:\tempSolutionCLOB\classLibproject\ObjectProject.csproj", null, bpg);


            try
            {
                VSProject vp1 = (sol.Projects.Item(1)).Object as VSProject;

                vp1.References.Add(gen.locationMid + @"\Middletier.dll");//middletier.dll JER SADA IZ NJEGA VUCEM CODEATTRIBUTE KLASU

                sol.SaveAs("ObjectProject.sln");

                SolutionBuild2 solSb = (SolutionBuild2)sol.SolutionBuild;
                solSb.SolutionConfigurations.Item("Debug").Activate();
                solSb.Build(true);
                sol.Close(false);
            }
            catch (Exception)
            {

            }

            //Microsoft.Build.BuildEngine.Engine en = new Microsoft.Build.BuildEngine.Engine();
            //BuildPropertyGroup bpg = new BuildPropertyGroup();
            //bpg.SetProperty("Configuration", "Debug");
            //bpg.SetProperty("Platform", "AnyCPU");
            //en.BuildProjectFile(@"e:\tempSolutionCLOB\classLibproject\ObjectProject.csproj", null, bpg);
            //sol.Close(false);
        }
        private void GenerateDomainProjects(GennInfo gen, Solution4 sol, string cl)
        {
            try
            {
                sol.Create(@"e:\tempSolutionCLDom", "DomainProject");
            }
            catch (Exception)
            {

            }
            try
            {
                sol.AddFromTemplate(cl, @"e:\tempSolutionCLDom\classLibproject", "DomainProject", true);

            }
            catch (Exception)
            {

            }

            string[] ObjectFiles = Directory.GetFiles(gen.locationDom);

            try
            {
                for (int i = 0; i < ObjectFiles.Length; i++)
                {
                    sol.Projects.Item(1).ProjectItems.AddFromFileCopy(ObjectFiles[i]);
                }
            }
            catch (Exception)
            {

            }

            //Engine en = new Engine();
            //BuildPropertyGroup bpg = new BuildPropertyGroup();
            //bpg.SetProperty("Configuration", "Debug");
            //bpg.SetProperty("Platform", "AnyCPU");
            //en.BuildProjectFile(@"e:\tempSolutionCLDom\classLibproject\DomainProject.csproj", null, bpg);

            try
            {
                VSProject vp1 = (sol.Projects.Item(1)).Object as VSProject;

                vp1.References.Add(gen.locationMid + @"\Middletier.dll");//middletier.dll JER SADA IZ NJEGA VUCEM CODEATTRIBUTE KLASU

                sol.SaveAs("DomainProject.sln");

                SolutionBuild2 solSb = (SolutionBuild2)sol.SolutionBuild;
                solSb.SolutionConfigurations.Item("Debug").Activate();
                solSb.Build(true);

                sol.Close(false);
            }
            catch (Exception)
            {

            }
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
                    try
                    {
                        Thread.Sleep(2000);
                        solDestination.AddFromFile(proj, false);
                    }
                    catch (Exception)
                    {
                    }
                }


            }

            try
            {
                Thread.Sleep(3000);
                var reference = (solDestination.Projects.Item(1).Object as VSProject).References.Add(objbin);
            }
            catch (Exception)
            {


            }
            try
            {
                Thread.Sleep(3000);
                var reference2 = (solDestination.Projects.Item(1).Object as VSProject).References.Add(gen.locationMid + @"\Middletier.dll");
            }
            catch (Exception)
            {


            }
            try
            {
                Thread.Sleep(3000);
                var reference3 = (solDestination.Projects.Item(1).Object as VSProject).References.Add(dombin);
            }
            catch (Exception)
            {


            }

            if (gen.UiType.Equals("ASP.NET"))
            {
                try
                {
                    Thread.Sleep(2000);
                    solDestination.SaveAs("ASPWebApplication.sln");
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    Thread.Sleep(2000);
                    solDestination.SaveAs("WinFormsApplication.sln");
                }
                catch (Exception)
                {

                }
            }

            try
            {
                SolutionBuild2 buildDestination = null;
                try
                {
                    Thread.Sleep(1000);
                    buildDestination = solDestination.SolutionBuild as SolutionBuild2;
                }
                catch (Exception)
                {
                }
                buildDestination.SolutionConfigurations.Item("Debug").Activate();
                buildDestination.Build(true);

                for (int i = 0; i < 2; i++)
                {
                    Thread.Sleep(1000);
                }

                solDestination.Close(false);
            }
            catch (Exception)
            {

            }
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
            Type solutionObject = Type.GetTypeFromProgID(vs, true);
            Solution4 sln = System.Activator.CreateInstance(solutionObject, true) as Solution4;
            #region  Generate UI?

            if (gen.GenerateUI)
            {
                if (gen.UiType.Equals("ASP.NET"))
                {

                    string templateWebApp = string.Concat(gen.VSLocation,
                                                          @"\Common7\IDE\ProjectTemplatesCache\CSharp\Web\1033\WebApplicationProject40.zip\WebApplicationProject40.vstemplate");

                    try
                    {
                        sln.Create(@"e:\tempSolution", "ASPWebApplication");
                    }
                    catch (Exception)
                    {

                    }

                    Uri u = new Uri(templateWebApp);
                    //Uri u2 = new Uri(str1);
                    string ws = u.LocalPath;

                    try
                    {
                        sln.AddFromTemplate(ws, @"e:\tempSolution\websiteproject", "ASPWebApplication", true);
                    }
                    catch (Exception)
                    {

                    }

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

                    try
                    {
                        sln.SaveAs(@"e:\tempSolution\ASPWebApplication.sln");
                    }
                    catch (Exception)
                    {
                    }
                    return sln;
                }

                else
                {


                    string winapptemplatepath = string.Concat(gen.VSLocation,
                                                              @"\Common7\IDE\ProjectTemplatesCache\CSharp\Windows\1033\WindowsApplication.zip\csWindowsApplication.vstemplate");
                    try
                    {
                        sln.Create(@"e:\tempSolution2", "WinFormsApplication");
                    }
                    catch (Exception)
                    {

                    }

                    Uri u = new Uri(winapptemplatepath);

                    string ws = u.LocalPath;

                    try
                    {
                        sln.AddFromTemplate(ws, @"e:\tempSolution2\winproject", "WinFormsApplication", true);
                    }
                    catch (Exception)
                    {

                    }

                    #region Dodaj WIN UI stranice

                    string[] UIFiles =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignClasses", gen.locationUI));

                    string[] UIFileNames =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignClasses", gen.locationUI))
                                 .Select(path => Path.GetFileName(path))
                                 .ToArray();

                    try
                    {
                        for (int i = 0; i < UIFiles.Length; i++)
                        {
                            if (!File.Exists(string.Format(@"{0}\{1}", @"e:\tempSolution2\winproject", UIFileNames[i])))
                            {
                                sln.Projects.Item(1).ProjectItems.AddFromFileCopy(UIFiles[i]);
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }

                    string[] UIFilesList =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignListClasses", gen.locationUI));

                    string[] UIFileNamesList =
                        Directory.GetFiles(string.Format(@"{0}\FinalResultWinUIDesignListClasses", gen.locationUI)).Select(path => Path.GetFileName(path)).ToArray();

                    try
                    {
                        for (int i = 0; i < UIFilesList.Length; i++)
                        {
                            if (!File.Exists(string.Format(@"{0}\{1}", @"e:\tempSolution2\winproject", UIFileNamesList[i])))
                            {
                                sln.Projects.Item(1).ProjectItems.AddFromFileCopy(UIFilesList[i]);
                            }
                        }
                    }
                    catch (Exception)
                    {


                    }

                    #endregion

                    try
                    {
                        sln.SaveAs(@"e:\tempSolution2\WinFormsApplication.sln");
                    }
                    catch (Exception)
                    {

                    }
                    return sln;


                }
            }

            #endregion

            return sln;
        }
    }
}
