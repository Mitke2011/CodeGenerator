using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Step2 : Form
    {
        public Step2()
        {
            InitializeComponent();
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

        }
    }
}
