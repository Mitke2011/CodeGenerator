using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Middletier;
using System.IO;

namespace User_Forms
{
    public partial class CodeGeneratorStep1 : Form
    {
        public CodeGeneratorStep1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            GennInfo g = new GennInfo();
            g.dbName = txtDBName.Text;
            g.dbServerName = txtDBSrv.Text;

            CodeGeneratorStep2 f2 = new CodeGeneratorStep2(g);
            f2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string confiFileLocation = @"e:\CodeGenerator\Config.txt";
            string [] options = new string[15];
            using (StreamReader sr = new StreamReader(confiFileLocation))
            {
                string option = "";
                int index = 0;
                while ((option = sr.ReadLine())!=null)
                {
                    options[index] = option;
                    index++;
                }
            }

            foreach (var option in options)
            {
                if ( option!=null && !option.Equals(string.Empty))
                {
                    string optionName = option.Split('|')[0];
                    string optionValue = option.Split('|')[1];
                    switch (optionName)
                    {
                        case "Dbname": txtDBName.Text = optionValue;
                            break;
                        case "DBServerName":
                            txtDBSrv.Text = optionValue;
                            break;
                    } 
                }
            }
        }
    }
}
