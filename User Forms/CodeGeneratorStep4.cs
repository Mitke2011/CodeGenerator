using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XSLTResourceCreator;
using Middletier;
using ProjectCreator;

namespace User_Forms
{
    public partial class CodeGeneratorStep4 : Form
    {
        private GennInfo g4;
        public CodeGeneratorStep4(GennInfo g)
        {
            InitializeComponent();
            g4 = g;
        }

        private void btnFindMiddletierDll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find Visual studio folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtMidletierDll.Text = fbd.SelectedPath;
        }

        private void btnObjectFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find Visual studio folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtObjectFiles.Text = fbd.SelectedPath;
        }

        private void btnFindDomainFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find Visual studio folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtDomainFiles.Text = fbd.SelectedPath;
        }

        private void btnFindUIFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find Visual studio folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtUIFiles.Text = fbd.SelectedPath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbApplicationType.Items.Add("ASP.NET");
            cbApplicationType.Items.Add("Windows Forms");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g4.UiType = cbApplicationType.SelectedItem.ToString();
            g4.locationDom = txtDomainFiles.Text;
            g4.locationMid = txtMidletierDll.Text;
            g4.locationObj = txtObjectFiles.Text;
            g4.locationUI = txtUIFiles.Text;
            g4.locationConfigFile = txtConfig.Text;

            foreach (var item in Directory.GetFiles(g4.locationDom))
            {
                File.Delete(item);
            }
            
            foreach (var item in Directory.GetFiles(g4.locationObj))
            {
                File.Delete(item);
            }

            foreach (var item in Directory.GetFiles(g4.locationUI))
            {
                File.Delete(item);
            }

            XSLTManager manager = new XSLTManager();

            if (g4.GenerateOb)
            {
                manager.GenerateObjectXML(g4.dbServerName, g4.dbName);
                manager.GenerateObjectClasses();
            }
            if (g4.GenereateDomain)
            {
                manager.GenerateDBXML(g4.dbServerName, g4.dbName);
                manager.GenerateDomainClasses();
            }
            if (g4.GenerateSP)
            {
                ClearSPDirectory();
                manager.GenerateDBXML(g4.dbServerName, g4.dbName);
                manager.GenerateStorredProcedures();
            }
            if (g4.GenerateUI)
            {
                manager.GenerateUIXML();
                if (g4.UiType.Equals("Windows Forms"))
                {
                    ClearUIFormDirectory();
                    manager.GenerateWinFormListForms();
                    manager.GenerateWinFormUI();
                }
                else
                {
                    ClearWebUIDirectory();
                    manager.GenerateASPNETUI();
                    manager.GenerateASPNETListUI();
                }
            }

            if (g4.GenerateSolution)
            {
                ProjectGenerator gen = new ProjectGenerator(g4.version);
                gen.CreateSolution(g4, g4.GenerateOb, g4.GenereateDomain);
                string[] projects = new string[] { @"e:\tempSolutionCLDom\classLibproject\", @"e:\tempSolutionCLOB\classLibproject\" };
                gen.AddProjects(projects, g4, @"e:\tempSolutionCLOB\classLibproject\bin\Debug\ObjectProject.dll", @"e:\tempSolutionCLDom\classLibproject\bin\Debug\DomainProject.dll");
                MessageBox.Show("Generation completed!");
            }
            else
            {
                FilesLocation form = new FilesLocation(g4);
                form.Visible = true;
            }

            

        }

        private void ClearUIFormDirectory()
        {
            string rootPath = @"..\..\..\XSLTResourceCreator\UI\";

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultWinUIDesignClasses"))
            {
                File.Delete(file);
            }

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultWinUIDesignListClasses"))
            {
                File.Delete(file);
            }
        }

        private void ClearWebUIDirectory()
        {
            string rootPath = @"..\..\..\XSLTResourceCreator\UI\";

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultWebUIDesignClasses"))
            {
                File.Delete(file);
            }

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultWebUIListDesignClasses"))
            {
                File.Delete(file);
            }
        }

        private void ClearSPDirectory()
        {
            string rootPath = @"..\..\..\XSLTResourceCreator\SP\";

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultDeleteStoredprocedures"))
            {
                File.Delete(file);
            }

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultInsertStoredprocedures"))
            {
                File.Delete(file);
            }

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultSelectAllStoredProcedures"))
            {
                File.Delete(file);
            }

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultSelectSingleStoredprocedures"))
            {
                File.Delete(file);
            }

            foreach (var file in Directory.GetFiles(rootPath + "FinalResultUpdateStoredprocedures"))
            {
                File.Delete(file);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string confiFileLocation = @"..\..\..\Config.txt";
            string[] options = new string[15];
            using (StreamReader sr = new StreamReader(confiFileLocation))
            {
                string option = "";
                int index = 0;
                while ((option = sr.ReadLine()) != null)
                {
                    options[index] = option;
                    index++;
                }
            }

            foreach (var option in options)
            {
                if ( option!=null && !option.Equals(string.Empty))
                {
                    string optionName = option.Split('|')[0];
                    string optionValue = option.Split('|')[1];

                    switch (optionName)
                    {
                        case "MiddletierLocation":
                            txtMidletierDll.Text = optionValue;
                            break;
                        case "ObjectClassLocation":
                            txtObjectFiles.Text = optionValue;
                            break;
                        case "DomainClassLocation":
                            txtDomainFiles.Text = optionValue;
                            break;
                        case "UIClassesLocation":
                            txtUIFiles.Text = optionValue;
                            break;
                        case "ConfigLocation":
                            txtConfig.Text = optionValue;
                            break;
                    } 
                }
            }
        }
    }
}
