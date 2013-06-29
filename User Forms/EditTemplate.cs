using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace User_Forms
{
    public partial class EditTemplate : Form
    {
        private OpenFileDialog dialog;
        private string XMLtemplateFile = "";

        public TextBox GetTXTField()
        {
            return this.txtTemplate;
        }

        public EditTemplate()
        {
            InitializeComponent();
            SetDialog();
            this.txtTemplate.ScrollBars = ScrollBars.Vertical;                       
        }

        private void SetDialog()
        {
            this.dialog = new OpenFileDialog();
            this.dialog.Title = "Load template file";
            this.dialog.DefaultExt = "xml";
            this.dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            this.dialog.InitialDirectory = "c:\\";
        }

        private void Settext()
        {            
            StreamReader str;
            try
            {
                str = new StreamReader(this.dialog.FileName);
                txtTemplate.Text = str.ReadToEnd();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a valid XML file.");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.dialog.ShowDialog();
            Settext();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.XMLtemplateFile = this.txtTemplate.Text;
            string openedTemplate = this.XMLtemplateFile.Remove(XMLtemplateFile.LastIndexOf('/') - 1);
            MiniAddForm form1 = new MiniAddForm(openedTemplate, this);
            form1.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GenerateXML newXml = new GenerateXML();
            try
            {
                newXml.Writer.WriteLine(this.txtTemplate.Text);
                newXml.Finilize();
                MessageBox.Show("Successfully saved changes to XML template !");
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured while writting to XML file !");
            }
        }

    }
}
