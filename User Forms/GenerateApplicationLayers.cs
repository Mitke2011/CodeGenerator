using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XSLTResourceCreator;
namespace User_Forms
{
    public partial class GenerateApplicationLayers : Form
    {
        public GenerateApplicationLayers()
        {
            InitializeComponent();
            this.comboBox1.Items.Add("Win Forms");
            this.comboBox1.Items.Add("ASP.NET");
        }

        private void btnStartGen_Click(object sender, EventArgs e)
        {
            XSLTManager manager = new XSLTManager();
            if (this.comboBox1.SelectedText.Equals("ASP.NET"))
            {
                manager.GenerateASPNETUI();
            }
            else
            {
                manager.GenerateWinFormListForms();
                manager.GenerateWinFormUI();
            }
        }
    }
}
