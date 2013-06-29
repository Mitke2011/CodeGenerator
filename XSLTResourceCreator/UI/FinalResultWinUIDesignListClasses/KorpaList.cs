
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
                partial class KorpaList:Form
                {
                MiddletierManager mm = new MiddletierManager();
                
        public KorpaList()
        {
          InitializeComponent();
          

        Korpa obj = new Korpa();
        List<Korpa> ls  = new List<Korpa>();

            foreach (Korpa item in mm.FindAll(obj, "Korpa"))
            {
                ls.Add(item);
            }
        this.dataGridView1.DataSource = ls;

        DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();

        btnCol.Name = "Modify";

        btnCol.Text = "Modify";

        DataGridViewTextBoxColumn tbCol = new DataGridViewTextBoxColumn();
        tbCol.Name = "IDValue";
        tbCol.Visible = false;
        
        tbCol.DataPropertyName = "KorpaID_Property";
        btnCol.UseColumnTextForButtonValue = true;


        dataGridView1.Columns.Add(btnCol);
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


        if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["Modify"].Index) return;

            int ID = (Int32)dataGridView1[idColumnIndex, e.RowIndex].Value;

            KorpaEdit forma = new KorpaEdit(ID);
            forma.Visible = true;


        }
    
                
                }
                }
            