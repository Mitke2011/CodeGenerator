using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Middletier;
namespace User_Forms
{
    public partial class CodeGeneratorStep3 : Form
    {
        private GennInfo g3;
        public CodeGeneratorStep3(GennInfo g)
        {
            InitializeComponent();
            this.txtVSlocation.Enabled = false;
            this.txtSolutionName.Enabled = false;
            this.btnSolutionLocation.Enabled = false;
            this.g3 = g;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find Visual studio folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtVSlocation.Text = fbd.SelectedPath;

        }

        private void Step2_Load(object sender, EventArgs e)
        {
            cbVSversion.Items.Add("Visual Studio 2010");
            cbVSversion.Items.Add("Visual Studio 2012");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.g3.VSLocation = txtVSlocation.Text;
            this.g3.solutionname = txtSolutionName.Text;
            this.g3.GenerateSolution = cbSolution.Checked;
            this.g3.version = cbVSversion.SelectedItem.ToString();

            CodeGeneratorStep4 f4 = new CodeGeneratorStep4(g3);
            f4.Visible = true;
        }

        private void cbSolution_Click(object sender, EventArgs e)
        {
            if (!cbSolution.Checked)
            {
                this.txtVSlocation.Enabled = false;
                this.txtSolutionName.Enabled = false;
                this.btnSolutionLocation.Enabled = false;
            }
            else
            {
                this.txtVSlocation.Enabled = true;
                this.txtSolutionName.Enabled = true;
                this.btnSolutionLocation.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string confiFileLocation = @"e:\CodeGenerator\Config.txt";
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
                    if (optionName.Equals("VisualStudioLocation"))
                    {
                        txtVSlocation.Text = optionValue;
                        break;
                    } 
                }
            }
        }
    }
}
