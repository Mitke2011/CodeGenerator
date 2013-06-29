using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormPatternApplication
{
    public partial class Form3 :AbsClass1 
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aSPBazaDataSet.Proizvod' table. You can move, or remove it, as needed.
            base.InitializeComponent();
            this.proizvodTableAdapter.Fill(this.aSPBazaDataSet.Proizvod);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Event handled by custom code!");
            
        }

        //private void btnAbs_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Abstract action!");
        //}

        
        
    }
}
