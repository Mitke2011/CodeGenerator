using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TypeLib;

namespace User_Forms
{
    public partial class MiniAddForm : Form
    {
        GenerateXML gen;
        string template;
        private EditTemplate masterPage;
        string className;
        private OpenFileDialog fileDialog;

        public MiniAddForm(string template, EditTemplate masterpage)
        {
            InitializeComponent();
            gen = new GenerateXML();            
            this.template = template;
            this.masterPage = masterpage;
            gen.Writer.WriteLine(template);
            FillComboBoxes();

            this.fileDialog = new OpenFileDialog();
            fileDialog.Title = "Find your project DLL";
            fileDialog.DefaultExt = "dll";
            fileDialog.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
            fileDialog.InitialDirectory = Environment.SpecialFolder.Personal.ToString();
        }

        private void FillComboBoxes()
        {
            List<string> datasource = new List<string>();
            Array list = System.Enum.GetValues(typeof(DataType));

            foreach (DataType item in list)
            {
                datasource.Add(item.ToString());
            }

            comboFieldType.DataSource = new BindingSource(datasource, "");

            List<string> datasource2 = new List<string>();
            Array list2 = System.Enum.GetValues(typeof(PropertyType));

            foreach (PropertyType item in list2)
            {
                datasource2.Add(item.ToString());
            }

            comboCardinality.DataSource = new BindingSource(datasource2, "");
            
        }

        public MiniAddForm()
        {
            InitializeComponent();
            gen = new GenerateXML();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Session.temporaryText += "\n" + "";
            gen.PrintContent(className, this.txtFieldName.Text, this.comboFieldType.SelectedText, this.comboCardinality.SelectedText, this.comboComposite.SelectedText, this.chkIsID.Checked.ToString().ToLower());
            //this.masterPage.GetTXTField().Text=gen.Writer.ToString();
            //this.masterPage.Focus();
            //this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            gen.PrintContent(className, this.txtFieldName.Text, this.comboFieldType.SelectedText, this.comboCardinality.SelectedText, this.comboComposite.SelectedText, this.chkIsID.Checked.ToString().ToLower());
            gen.PrintFooter();
            this.masterPage.GetTXTField().Text = gen.Writer.ToString();
            this.masterPage.Focus();
            this.Close();
        }

        private void SetClassCombo(ComboBox combo)
        {
            string location = null;

            fileDialog.ShowDialog();
            location = fileDialog.FileName;

            try
            {
                Assembly myAssem = Assembly.ReflectionOnlyLoadFrom(location);
                foreach (Type type in myAssem.GetTypes())
                {
                    if (type.IsClass)
                        combo.Items.Add(type.Name);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The assembly file was not selected ! ");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SetClassCombo(this.comboComposite);
        }

    }
}
