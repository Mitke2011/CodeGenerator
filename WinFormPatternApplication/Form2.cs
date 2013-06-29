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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            List<Osoba> ls = new List<Osoba>();
            Osoba o1 = new Osoba();
            o1.Ime = "Stefan";
            o1.ID = 5;
            Osoba o2 = new Osoba();
            o2.Ime = "Nemanja";
            o2.ID = 4;

            o1.Prezime = o2.Prezime = "Mitic";
            ls.Add(o1);
            ls.Add(o2);
            
            this.dataGridView1.DataSource = ls;
            
            int lastColumnIndex = dataGridView1.ColumnCount;
            
            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
       
            btnCol.Name = "Modify";
      
            btnCol.Text = "Modify";
            
            DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
            tbCol.Name = "IDValue";
            tbCol.Visible = false;
            tbCol.DataPropertyName = "ID";
            
            btnCol.UseColumnTextForButtonValue = true;

            
            dataGridView1.Columns.Add(btnCol);
            dataGridView1.Columns.Add(tbCol);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        public Form2(int hiddenID)
        {
            InitializeComponent();
            
            List<Osoba> ls = new List<Osoba>();
            Osoba o1 = new Osoba();
            o1.Ime = "Stefan";
            o1.ID = 5;
            Osoba o2 = new Osoba();
            o2.Ime = "Nemanja";
            o2.ID = 4;

            o1.Prezime = o2.Prezime = "Mitic";
            ls.Add(o1);
            ls.Add(o2);

            this.dataGridView1.DataSource = ls;

            int lastColumnIndex = dataGridView1.ColumnCount;

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();

            btnCol.Name = "Modify";

            btnCol.Text = "Modify";

            DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
            tbCol.Name = "IDValue";
            tbCol.Visible = false;
            tbCol.DataPropertyName = "ID";

            btnCol.UseColumnTextForButtonValue = true;


            dataGridView1.Columns.Add(btnCol);
            dataGridView1.Columns.Add(tbCol);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            //this.label1.Text = "" + hiddenID;
        }


        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var columns = dataGridView1.Columns.GetEnumerator();
            int idColumnIndex = 0;

            while (columns.MoveNext())
            {
                if ((columns.Current as DataGridViewTextBoxColumn) != null && (columns.Current as DataGridViewTextBoxColumn).Name.Equals("IDValue"))
                {
                    idColumnIndex = (columns.Current as DataGridViewTextBoxColumn).Index;
                }
            }

             
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["Modify"].Index) return;

            int ID = (Int32)dataGridView1[idColumnIndex, e.RowIndex].Value;

            

            MessageBox.Show(String.Format(
                    "Izvrsena je akcija Modify nad redom {0} ", ID), "Modify");

        }

    }
}
