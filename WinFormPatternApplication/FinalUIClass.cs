
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Middletier;

namespace WinUI
{
    partial class KupacEdit
    {

        private void KupacEdit_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
    {
      MiddleTier.Save(Kupac obj);
    }

        private void button1_Click(object sender, EventArgs e)
  {
    MiddleTier.Update(Kupac obj);
  }

        private void button1_Click(object sender, EventArgs e)
  {
    MiddleTier.Delete(Kupac obj);
  }

        private void button1_Click(object sender, EventArgs e)
  {
    Kupac searchObject = MiddleTier.Find(Kupac obj);
    
  }

    }
}
