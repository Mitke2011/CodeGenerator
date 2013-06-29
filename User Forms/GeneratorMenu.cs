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
    public partial class GeneratorMenu : Form
    {


        public GeneratorMenu()
        {
            InitializeComponent();

            this.saveFileDialog1 = new SaveFileDialog();
            this.saveFileDialog1.Title = "Save to...";
            this.saveFileDialog1.DefaultExt = "cs";
            this.saveFileDialog1.Filter = "cs files (*.cs)|*.cs";
            this.saveFileDialog1.InitialDirectory = Environment.SpecialFolder.Personal.ToString();
            this.fileDialog = new OpenFileDialog();
            fileDialog.Title = "Find ...";
            fileDialog.DefaultExt = "xml";
            fileDialog.Filter = "xml files (*.xml)|*.xml";
            fileDialog.InitialDirectory = Environment.SpecialFolder.Personal.ToString();
            this.rdBtnC.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string language;
            Controler control = new Controler(this.txtTemplate.Text, this.txtClass.Text);
            if (this.rdBtnC.Checked)
            {
                language = "C#";
            }
            else
            {
                language = "Java";
            }
            control.CreateClassFile(language);
        }

        private void btnSaveClass_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            this.txtClass.Text = this.saveFileDialog1.FileName;
        }

        private void btnFindTemplate_Click(object sender, EventArgs e)
        {
            this.fileDialog.ShowDialog();
            this.txtTemplate.Text = fileDialog.FileName;
        }
    }
}
