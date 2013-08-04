
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
    partial class ProizvodEdit : Form
    {

        public ProizvodEdit(int ID)
        {
            InitializeComponent();
            MiddletierManager mm = new MiddletierManager();
            Proizvod ob = new Proizvod();
            ob.SifraProizvoda = ID;
            ob = (Proizvod)mm.FindOne(ob, true);


            this.hdnID.Text = ob.SifraProizvoda.ToString();

            this.txtNaziv.Text = ob.Naziv;

            this.txtKolicina.Text = ob.Kolicina.ToString();

        }

        public ProizvodEdit()
        {
            InitializeComponent();
            //MiddletierManager mm = new MiddletierManager();
            //Proizvod ob = new Proizvod();
            //ob.SifraProizvoda = ID;
            //ob = (Proizvod)mm.FindOne(ob, true);


            //this.hdnID.Text = ob.SifraProizvoda.ToString();

            //this.txtNaziv.Text = ob.Naziv;

            //this.txtKolicina.Text = ob.Kolicina.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proizvod obj = new Proizvod();

            obj.SifraProizvoda = int.Parse(this.hdnID.Text);
            obj.Naziv =
                    this.txtNaziv.Text;

            obj.Kolicina =
                    int.Parse(this.txtKolicina.Text);


            MiddletierManager mm = new MiddletierManager();
            mm.Save(obj, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proizvod obj = new Proizvod();

            obj.SifraProizvoda = int.Parse(this.hdnID.Text);
            obj.Naziv =
                    this.txtNaziv.Text;

            obj.Kolicina =
                    int.Parse(this.txtKolicina.Text);

            MiddletierManager mm = new MiddletierManager();
            mm.Update(obj, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Proizvod obj = new Proizvod();

            obj.SifraProizvoda = int.Parse(this.hdnID.Text);
            obj.Naziv =
                    this.txtNaziv.Text;

            obj.Kolicina =
                    int.Parse(this.txtKolicina.Text);

            MiddletierManager mm = new MiddletierManager();
            mm.Delete(obj, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Proizvod obj = new Proizvod();

            obj.SifraProizvoda = int.Parse(this.hdnID.Text);
            obj.Naziv =
                    this.txtNaziv.Text;

            obj.Kolicina =
                    int.Parse(this.txtKolicina.Text);

            MiddletierManager mm = new MiddletierManager();
            Proizvod searchObject = (Proizvod)mm.FindOne(obj, true);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Proizvod obj = new Proizvod();

            int id;//= int.Parse(this.hdnID.Text);
            if (int.TryParse(this.hdnID.Text, out id))
            {
                obj.SifraProizvoda = id;
            }
            obj.Naziv =
                    this.txtNaziv.Text;

            obj.Kolicina =
                    int.Parse(this.txtKolicina.Text);


            MiddletierManager mm = new MiddletierManager();


            if (!this.hdnID.Text.Equals(string.Empty))
            {
                mm.Update(obj, true);
            }
            else
            {
                mm.Save(obj, true);
            }

            ProizvodList pl = new ProizvodList();
            pl.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Proizvod obj = new Proizvod();
            int id;//= int.Parse(this.hdnID.Text);
            if (int.TryParse(this.hdnID.Text, out id))
            {
                obj.SifraProizvoda = id;
            }
            obj.Naziv =
                   this.txtNaziv.Text;

            obj.Kolicina =
                    int.Parse(this.txtKolicina.Text);


            MiddletierManager mm = new MiddletierManager();
            mm.Delete(obj, true);

            ProizvodList pl = new ProizvodList();
            pl.Visible = true;

        }

    }
}
