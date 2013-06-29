using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace User_Forms
{
    public partial class DBmanagerGenerator : Form
    {
        public DBmanagerGenerator()
        {
            InitializeComponent();

            this.saveFileDialog1 = new SaveFileDialog();
            this.saveFileDialog1.Title = "Save to...";
            this.saveFileDialog1.DefaultExt = "cs";
            this.saveFileDialog1.Filter = "cs files (*.cs)|*.cs";
            this.saveFileDialog1.InitialDirectory = Environment.SpecialFolder.Personal.ToString();
            this.fileDialog = new OpenFileDialog();
            fileDialog.Title = "Find your project DLL";
            fileDialog.DefaultExt = "xml";
            fileDialog.Filter = "xml files (*.xml)|*.xml";
            fileDialog.InitialDirectory = Environment.SpecialFolder.Personal.ToString();
            rdBtnC.Checked = true;
            txtDriver.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string language = "";
            if (rdBtnC.Checked)
            {
                language = "C#";
            }
            else
            {
                language = "Java";
            }
            Controler control = new Controler(this.txtTemplate.Text, this.txtClass.Text);
            control.CreateDBManagerClassFile(this.txtConStr.Text.Trim(), language, this.txtDriver.Text.Trim());
        }

        private void btnFindTemplate_Click(object sender, EventArgs e)
        {
            this.fileDialog.ShowDialog();
            this.txtTemplate.Text = fileDialog.FileName;
        }

        private void btnSaveClass_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            this.txtClass.Text = this.saveFileDialog1.FileName;
        }

        private void rdBtnJ_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDriver.Enabled = true;
        }

        private void rdBtnC_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDriver.Enabled = false;
        }

        private void DBmanagerGenerator_Load(object sender, EventArgs e)
        {

        }
    }
}
