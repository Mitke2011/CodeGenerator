using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Middletier;
namespace User_Forms
{
    public partial class CodeGeneratorStep2 : Form
    {
        private GennInfo g2;
        public CodeGeneratorStep2(GennInfo g)
        {
            InitializeComponent();
            g2 = g;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.g2.GenerateOb = cbObjects.Checked;
            this.g2.GenerateSP = cbSP.Checked;
            this.g2.GenerateUI = cbUI.Checked;
            this.g2.GenereateDomain = cbDomainclasses.Checked;

            CodeGeneratorStep3 f3 = new CodeGeneratorStep3(g2);
            f3.Visible = true;
        }
    }
}
