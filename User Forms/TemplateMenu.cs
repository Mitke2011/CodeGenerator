using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace User_Forms
{
    public partial class TemplateMenu : Form
    {
        public TemplateMenu()
        {
            InitializeComponent();
           
        }

        private void editExistingTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTemplate form1 = new GenerateTemplate();
            form1.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTemplate form2 = new EditTemplate();
            form2.Show();
        }

        private void generateDomainClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneratorMenu form3 = new GeneratorMenu();
            form3.Show();
        }

        private void generateDBManagerClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBmanagerGenerator form4 = new DBmanagerGenerator();
            form4.Show();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateFromClass form = new TemplateFromClass();
            form.Show();
        }      
               
    }
}
