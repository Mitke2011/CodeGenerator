
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
        partial class KupacEdit:Form
            {
            
    public Kupac(int ID)
      {
      InitializeComponent();
      MiddleTierManager mm = new MiddleTierManager();
      Kupac ob = new Kupac();
      ob.SifraKupca Ime Prezime BrojTelefona Adresa_Property = ID;
      ob = (Kupac) mm.FindOne(ob,true/>");
      
      
                    this.hdnID.Text =obj.SifraKupca;
                
                    this.txtIme.Text=obj.Ime;
                
                    this.txtPrezime.Text=obj.Prezime;
                
                    this.txtBrojTelefona.Text=obj.BrojTelefona;
                
                    this.txtAdresa.Text=obj.Adresa;
                
      }
  
      private void button1_Click(object sender, EventArgs e)
      {
      Kupac obj = new Kupac();
        
            classObject.SifraKupca = 
                    this.txtSifraKupca.Text;
                
            classObject.Ime = 
                    this.txtIme.Text;
                
            classObject.Prezime = 
                    this.txtPrezime.Text;
                
            classObject.BrojTelefona = 
                    this.txtBrojTelefona.Text;
                
            classObject.Adresa = 
                    this.txtAdresa.Text;
                
      
      MiddleTier mm = new MiddleTier();
      mm.Save(Kupac obj);
    }
  
      private void button2_Click(object sender, EventArgs e)
      {
      Kupac obj = new Kupac();
        
            classObject.SifraKupca = 
                    this.txtSifraKupca.Text;
                
            classObject.Ime = 
                    this.txtIme.Text;
                
            classObject.Prezime = 
                    this.txtPrezime.Text;
                
            classObject.BrojTelefona = 
                    this.txtBrojTelefona.Text;
                
            classObject.Adresa = 
                    this.txtAdresa.Text;
                
      MiddleTier mm = new MiddleTier();
      mm.Update(Kupac obj);
  }
  
      private void button3_Click(object sender, EventArgs e)
      {
      Kupac obj = new Kupac();
        
            classObject.SifraKupca = 
                    this.txtSifraKupca.Text;
                
            classObject.Ime = 
                    this.txtIme.Text;
                
            classObject.Prezime = 
                    this.txtPrezime.Text;
                
            classObject.BrojTelefona = 
                    this.txtBrojTelefona.Text;
                
            classObject.Adresa = 
                    this.txtAdresa.Text;
                
      MiddleTier mm = new MiddleTier();
      mm.Delete(Kupac obj);
  }
  
      private void button4_Click(object sender, EventArgs e)
      {
      Kupac obj = new Kupac();
        
            classObject.SifraKupca = 
                    this.txtSifraKupca.Text;
                
            classObject.Ime = 
                    this.txtIme.Text;
                
            classObject.Prezime = 
                    this.txtPrezime.Text;
                
            classObject.BrojTelefona = 
                    this.txtBrojTelefona.Text;
                
            classObject.Adresa = 
                    this.txtAdresa.Text;
                
      MiddleTier mm = new MiddleTier();
      Kupac searchObject = mm.Find(Kupac obj);
    
  }
  
          }
          }
        