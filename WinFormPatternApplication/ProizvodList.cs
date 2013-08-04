
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Middletier;

namespace WinFormPatternApplication
{
    partial class ProizvodList : Form
    {
        MiddletierManager mm = new MiddletierManager();

        public ProizvodList()
        {
            InitializeComponent();


            Proizvod obj = new Proizvod();
            List<Proizvod> ls = new List<Proizvod>();

            foreach (Proizvod item in mm.FindAll(obj, "Proizvod", true))
            {
                ls.Add(item);
            }
            this.dataGridView1.DataSource = ls;

            DataGridViewButtonColumn btnCol1 = new DataGridViewButtonColumn();

            btnCol1.Name = "New";

            btnCol1.Text = "New";

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();

            btnCol.Name = "Modify";

            btnCol.Text = "Modify";

            DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
            tbCol.Name = "IDValue";
            tbCol.Visible = false;

            tbCol.DataPropertyName = "SifraProizvoda";
            btnCol.UseColumnTextForButtonValue = true;
            btnCol1.UseColumnTextForButtonValue = true;


            dataGridView1.Columns.Add(btnCol);
            dataGridView1.Columns.Add(btnCol1);
            dataGridView1.Columns.Add(tbCol);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
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


            if (e.RowIndex < 0) return;
            
            
            if (e.ColumnIndex ==
                dataGridView1.Columns["New"].Index)
            {
                ProizvodEdit forma1 = new ProizvodEdit();
                forma1.Visible = true;
            }

            if (e.ColumnIndex ==
                dataGridView1.Columns["Modify"].Index)
            {
                int ID = (Int32)dataGridView1[idColumnIndex, e.RowIndex].Value;

                ProizvodEdit forma = new ProizvodEdit(ID);
                forma.Visible = true;

                this.Visible = false;
            }
            


        }


    }
}
