using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace User_Forms
{
    public partial class ConfigSetup : Form
    {
        public ConfigSetup()
        {
            InitializeComponent();
            LoadConfigurationSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sr = new StreamWriter(@"..\..\..\Config.txt", false))
            {
                sr.WriteLine("Dbname|"+txtDBName.Text);
                sr.WriteLine("DBServerName|" + txtDBServer.Text);
                sr.WriteLine("VisualStudioLocation|" + txtVSLocation.Text);
                sr.WriteLine("MiddletierLocation|" + txtMTLocation.Text);
                sr.WriteLine("ObjectClassLocation|" + txtOCLocation.Text);
                sr.WriteLine("DomainClassLocation|" + txtDCLocation.Text);
                sr.WriteLine("UIClassesLocation|" + txtUILocation.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find Visual Studio folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtVSLocation.Text = fbd.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find MiddleTier dll location";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtMTLocation.Text = fbd.SelectedPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find object classes folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtOCLocation.Text = fbd.SelectedPath;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find domain classes folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtDCLocation.Text = fbd.SelectedPath;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Find UI classes folder";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();


            txtUILocation.Text = fbd.SelectedPath;
        }

        private void LoadConfigurationSettings()
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
                if (option != null && !option.Equals(string.Empty))
                {
                    string optionName = option.Split('|')[0];
                    string optionValue = option.Split('|')[1];
                    switch (optionName)
                    {
                        case "Dbname": txtDBName.Text = optionValue;
                            break;
                        case "DBServerName":
                            txtDBServer.Text = optionValue;
                            break;
                        case "VisualStudioLocation":
                            txtVSLocation.Text = optionValue;
                            break;
                        case "MiddletierLocation":
                            this.txtMTLocation.Text = optionValue;
                            break;
                        case "ObjectClassLocation":
                            this.txtOCLocation.Text = optionValue;
                            break;
                        case "DomainClassLocation":
                            this.txtDCLocation.Text = optionValue;
                            break;
                        case "UIClassesLocation":
                            this.txtUILocation.Text = optionValue;
                            break;
                    }
                }
            }
        }
    }
}
