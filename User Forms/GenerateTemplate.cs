using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using TypeLib;

namespace User_Forms
{
    public partial class GenerateTemplate : Form
    {
        private OpenFileDialog fileDialog;

        public GenerateTemplate()
        {
            InitializeComponent();


            this.fileDialog = new OpenFileDialog();
            fileDialog.Title = "Find your project DLL";
            fileDialog.DefaultExt = "dll";
            fileDialog.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
            fileDialog.InitialDirectory = Environment.SpecialFolder.Personal.ToString();

            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            List<string> datasource = new List<string>();
            Array list = System.Enum.GetValues(typeof(DataType));

            foreach (DataType item in list)
            {
                datasource.Add(item.ToString());
            }

            cmbDataType1.DataSource = new BindingSource(datasource, "");
            cmbDataType2.DataSource = new BindingSource(datasource, "");
            cmbDataType3.DataSource = new BindingSource(datasource, "");
            cmbDataType4.DataSource = new BindingSource(datasource, "");
            cmbDataType5.DataSource = new BindingSource(datasource, "");
            cmbDataType6.DataSource = new BindingSource(datasource, "");
            cmbDataType7.DataSource = new BindingSource(datasource, "");

            List<string> datasource2 = new List<string>();
            Array list2 = System.Enum.GetValues(typeof(PropertyType));

            foreach (PropertyType item in list2)
            {
                datasource2.Add(item.ToString());
            }


            cmbCardinal1.DataSource = new BindingSource(datasource2, "");
            cmbCardinal2.DataSource = new BindingSource(datasource2, "");
            cmbCardinal3.DataSource = new BindingSource(datasource2, "");
            cmbCardinal4.DataSource = new BindingSource(datasource2, "");
            cmbCardinal5.DataSource = new BindingSource(datasource2, "");
            cmbCardinal6.DataSource = new BindingSource(datasource2, "");
            cmbCardinal7.DataSource = new BindingSource(datasource2, "");
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            SetClassCombo(comboClass1);
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

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            SetClassCombo(comboClass2);
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            SetClassCombo(comboClass3);
        }

        private void btnBrowse4_Click(object sender, EventArgs e)
        {
            SetClassCombo(comboClass4);
        }

        private void btnBrowse5_Click(object sender, EventArgs e)
        {
            SetClassCombo(comboClass5);
        }

        private void btnBrowse6_Click(object sender, EventArgs e)
        {
            SetClassCombo(comboClass6);
        }

        private void btnBrowse7_Click(object sender, EventArgs e)
        {
            SetClassCombo(comboClass7);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GenerateXML gen = new GenerateXML();
            try
            {
                gen.PrintHeader(txtClassName.Text,txtNamespace.Text);
                gen.PrintContent(txtClassName.Text, fieldName1.Text, cmbDataType1.SelectedItem != null ? cmbDataType1.SelectedItem.ToString() : string.Empty, cmbCardinal1.SelectedItem != null ? cmbCardinal1.SelectedItem.ToString() : string.Empty, comboClass1.SelectedItem != null ? comboClass1.SelectedItem.ToString() : string.Empty, isID1.Checked.ToString().ToLower());
                gen.PrintContent(txtClassName.Text, fieldName2.Text, cmbDataType2.SelectedItem != null ? cmbDataType2.SelectedItem.ToString() : string.Empty, cmbCardinal2.SelectedItem != null ? cmbCardinal2.SelectedItem.ToString() : string.Empty, comboClass2.SelectedItem != null ? comboClass2.SelectedItem.ToString() : string.Empty, isID2.Checked.ToString().ToLower());
                gen.PrintContent(txtClassName.Text, fieldName3.Text, cmbDataType3.SelectedItem != null ? cmbDataType3.SelectedItem.ToString() : string.Empty, cmbCardinal3.SelectedItem != null ? cmbCardinal3.SelectedItem.ToString() : string.Empty, comboClass3.SelectedItem != null ? comboClass3.SelectedItem.ToString() : string.Empty, isID3.Checked.ToString().ToLower());
                gen.PrintContent(txtClassName.Text, fieldName4.Text, cmbDataType4.SelectedItem != null ? cmbDataType4.SelectedItem.ToString() : string.Empty, cmbCardinal4.SelectedItem != null ? cmbCardinal4.SelectedItem.ToString() : string.Empty, comboClass4.SelectedItem != null ? comboClass4.SelectedItem.ToString() : string.Empty, isID4.Checked.ToString().ToLower());
                gen.PrintContent(txtClassName.Text, fieldName5.Text, cmbDataType5.SelectedItem != null ? cmbDataType5.SelectedItem.ToString() : string.Empty, cmbCardinal5.SelectedItem != null ? cmbCardinal5.SelectedItem.ToString() : string.Empty, comboClass5.SelectedItem != null ? comboClass5.SelectedItem.ToString() : string.Empty, isID5.Checked.ToString().ToLower());
                gen.PrintContent(txtClassName.Text, fieldName6.Text, cmbDataType6.SelectedItem != null ? cmbDataType6.SelectedItem.ToString() : string.Empty, cmbCardinal6.SelectedItem != null ? cmbCardinal6.SelectedItem.ToString() : string.Empty, comboClass6.SelectedItem != null ? comboClass6.SelectedItem.ToString() : string.Empty, isID6.Checked.ToString().ToLower());
                gen.PrintContent(txtClassName.Text, fieldName7.Text, cmbDataType7.SelectedItem != null ? cmbDataType7.SelectedItem.ToString() : string.Empty, cmbCardinal7.SelectedItem != null ? cmbCardinal7.SelectedItem.ToString() : string.Empty, comboClass7.SelectedItem != null ? comboClass7.SelectedItem.ToString() : string.Empty, isID7.Checked.ToString().ToLower());
                gen.PrintFooter();
                gen.Finilize();

                MessageBox.Show("The template has been successfully saved.");
            }
            catch (Exception)
            {
                MessageBox.Show("The error was detected while writting one of properties to XML file. Please check your setup.");
            }

        }





    }
}
