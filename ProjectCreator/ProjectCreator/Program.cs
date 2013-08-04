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

using Microsoft.VisualStudio.CommandBars;

namespace ProjectCreator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            //EnvDTE80.DTE2 dte2;
            //dte2 = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.
            //GetActiveObject("VisualStudio.DTE.11.0");            

            //string vs = "VisualStudio.Solution.11.0";
            //Type solutionObject = Type.GetTypeFromProgID(vs, true);
            //Solution2 sln = System.Activator.CreateInstance(solutionObject, true) as Solution2;

            
            //try
            //{
            //    string str1 = @"c:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\ProjectTemplatesCache\CSharp\Windows\1033\ClassLibrary\csClassLibrary.vstemplate";
            //    string str2 = @"c:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\ProjectTemplatesCache\CSharp\Web\1033\WebApplicationProject20\WebApplicationProject20.vstemplate";
                
            //    sln.Create(@"e:\tempSolution", "ASPNETCreator");

                               
            //    Uri u = new Uri(str2);
            //    Uri u2 = new Uri(str1);
            //    string ws = u.LocalPath;
                
            //    sln.AddFromTemplate(ws, @"e:\tempSolution\websiteproject", "MyWebSiteProject", true);
            //    sln.SaveAs(@"e:\tempSolution\ASPNETCreator.sln");
               
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
            //Program2 p2 = new Program2();
            ////p2.CreateSolution(@"c:\Users\Mitic\Documents\Visual Studio 2012\Projects\Code Generator Main\XSLTResourceCreator\FinalResultObjectClasses\");
            //p2.CreateSolution(@"c:\Users\mitke\Documents\Visual Studio 2010\Projects\Code Generator Main 2013-06-05\Code Generator Main\XSLTResourceCreator\FinalResultObjectClasses");
            
            //p2.AddProjects(@"e:\tempSolutionCL\classLibproject", "ASP.NET");

        }

        
    }
}
