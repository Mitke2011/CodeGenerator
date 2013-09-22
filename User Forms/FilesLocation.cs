using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Middletier;

namespace User_Forms
{
    public partial class FilesLocation : Form
    {
        GennInfo gen = new GennInfo();
        public FilesLocation()
        {
            InitializeComponent();
        }

        public FilesLocation(GennInfo g)
        {
            InitializeComponent();
            gen = g;
        }

        private void button1_Click(object sender, EventArgs e)//prosledi geninfo 
        {
            string[] objectFiles = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\FinalResultObjectClasses");
            SaveFilesCopies(objectFiles, txtObjecDestination);

            string[] domainFiles = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\DomainClasses");
            SaveFilesCopies(domainFiles, txtDomainFiles);

            string[] insertSPFiles = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\SP\FinalResultInsertStoredprocedures");
            SaveFilesCopies(insertSPFiles, txtSPFiles);

            string[] updateSPFiles = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\SP\FinalResultUpdateStoredprocedures");
            SaveFilesCopies(updateSPFiles, txtSPFiles);

            string[] deleteSPFiles = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\SP\FinalResultDeleteStoredprocedures");
            SaveFilesCopies(deleteSPFiles, txtSPFiles);

            string[] findOneSPFiles = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\SP\FinalResultSelectSingleStoredprocedures");
            SaveFilesCopies(findOneSPFiles, txtSPFiles);

            string[] findAllSPFiles = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\SP\FinalResultSelectAllStoredProcedures");
            SaveFilesCopies(findAllSPFiles, txtSPFiles);

            if (gen.GenerateUI && gen.UiType.Equals("Windows Forms"))
            {
                string[] winUIFiles1 = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\UI\FinalResultWinUIDesignListClasses");
                SaveFilesCopies(winUIFiles1, txtUIFiles);

                string[] winUIFiles2 = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\UI\FinalResultWinUIDesignClasses");
                SaveFilesCopies(winUIFiles2, txtUIFiles); 
            }

            if (gen.GenerateUI && gen.UiType.Equals("ASP.NET"))
            {
                string[] webUIFiles1 = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\UI\FinalResultWebUIListDesignClasses");
                SaveFilesCopies(webUIFiles1, txtUIFiles);

                string[] webUIFiles2 = Directory.GetFiles(@"..\..\..\XSLTResourceCreator\UI\FinalResultWebUIDesignClasses");
                SaveFilesCopies(webUIFiles2, txtUIFiles); 
            }
            
        }

        private void SaveFilesCopies(string[] objectFiles, TextBox txt)
        {
            foreach (var objectFile in objectFiles)
            {
                File.Copy(objectFile, string.Format(@"{0}\{1}", txt.Text, Path.GetFileName(objectFile)));
            }
        }

        private void btnObjects_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find object classes folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtObjecDestination.Text = fbd.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find domain classes folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtDomainFiles.Text = fbd.SelectedPath;
        }

        private void btnSPLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find SP folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtSPFiles.Text = fbd.SelectedPath;
        }

        private void btnUILocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find UI files folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtUIFiles.Text = fbd.SelectedPath;
        }
    }
}
