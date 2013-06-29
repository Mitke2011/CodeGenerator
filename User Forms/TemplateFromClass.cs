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
    public partial class TemplateFromClass : Form
    {
        private OpenFileDialog fileDialog;
        string location = null;
        private GenerateXML gen;
        private ObjectDefinition odef;

        public TemplateFromClass()
        {
            InitializeComponent();

            gen = new GenerateXML();
            odef = new ObjectDefinition();

            this.fileDialog = new OpenFileDialog();
            fileDialog.Title = "Find your project DLL";
            fileDialog.DefaultExt = "dll";
            fileDialog.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
            fileDialog.InitialDirectory = Environment.SpecialFolder.Personal.ToString();

            this.saveFileDialog1 = new SaveFileDialog();
            this.saveFileDialog1.Title = "Save to...";
            this.saveFileDialog1.DefaultExt = "cs";
            this.saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            this.saveFileDialog1.InitialDirectory = Environment.SpecialFolder.Personal.ToString();

            FillClassCombo();

        }

        private void FillClassCombo()
        {
            location = null;

            fileDialog.ShowDialog();
            location = fileDialog.FileName;

            try
            {
                Assembly myAssem = Assembly.ReflectionOnlyLoadFrom(location);
                foreach (Type type in myAssem.GetTypes())
                {
                    if (type.IsClass)
                        this.comboClass.Items.Add(type.Name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The assembly file was not selected ! ");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FillClassCombo();
        }

        private void btnSaveTo_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            this.txtTemplate.Text = this.saveFileDialog1.FileName;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                Assembly myAssem = Assembly.ReflectionOnlyLoadFrom(location);
                Type myClass = myAssem.GetType(comboClass.SelectedItem.ToString());
                PropertyInfo[] props = myClass.GetProperties();
                foreach (var property in props)
                {
                    PropertyDefinition prop2 = new PropertyDefinition();
                    prop2.ClassName = myClass.Name;
                    // prop2.PropDataType = property.PropertyType;
                    odef.Property.Add(prop2);
                }
                //MethodInfo[] methods = myClass.GetMethods();  VRACA SVE METODE I IZ NJIH SE IZDVAJAJU IME I POVRATNI TIP
                //foreach (var method in methods)
                //{
                //   string methodNAme= method.Name;
                //   string returnType = method.ReturnType.ToString();
                //}
            } 
            catch (Exception)
            {
                MessageBox.Show("The assembly file was not selected ! ");
            }
        }

    }
}
