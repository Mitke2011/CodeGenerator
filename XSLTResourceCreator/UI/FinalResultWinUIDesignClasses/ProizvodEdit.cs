
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
        partial class ProizvodEdit:Form
            {
            
    public Proizvod(int ID)
      {
      InitializeComponent();
      MiddleTierManager mm = new MiddleTierManager();
      Proizvod ob = new Proizvod();
      ob.SifraProizvoda Naziv Kolicina_Property = ID;
      ob = (Proizvod) mm.FindOne(ob,true/>");
      
      
                    this.hdnID.Text =obj.SifraProizvoda;
                
                    this.txtNaziv.Text=obj.Naziv;
                
                    this.txtKolicina.Text=obj.Kolicina;
                
      }
  
      private void button1_Click(object sender, EventArgs e)
      {
      Proizvod obj = new Proizvod();
        
            classObject.SifraProizvoda = 
                    this.txtSifraProizvoda.Text;
                
            classObject.Naziv = 
                    this.txtNaziv.Text;
                
            classObject.Kolicina = 
                    this.txtKolicina.Text;
                
      
      MiddleTier mm = new MiddleTier();
      mm.Save(Proizvod obj);
    }
  
      private void button2_Click(object sender, EventArgs e)
      {
      Proizvod obj = new Proizvod();
        
            classObject.SifraProizvoda = 
                    this.txtSifraProizvoda.Text;
                
            classObject.Naziv = 
                    this.txtNaziv.Text;
                
            classObject.Kolicina = 
                    this.txtKolicina.Text;
                
      MiddleTier mm = new MiddleTier();
      mm.Update(Proizvod obj);
  }
  
      private void button3_Click(object sender, EventArgs e)
      {
      Proizvod obj = new Proizvod();
        
            classObject.SifraProizvoda = 
                    this.txtSifraProizvoda.Text;
                
            classObject.Naziv = 
                    this.txtNaziv.Text;
                
            classObject.Kolicina = 
                    this.txtKolicina.Text;
                
      MiddleTier mm = new MiddleTier();
      mm.Delete(Proizvod obj);
  }
  
      private void button4_Click(object sender, EventArgs e)
      {
      Proizvod obj = new Proizvod();
        
            classObject.SifraProizvoda = 
                    this.txtSifraProizvoda.Text;
                
            classObject.Naziv = 
                    this.txtNaziv.Text;
                
            classObject.Kolicina = 
                    this.txtKolicina.Text;
                
      MiddleTier mm = new MiddleTier();
      Proizvod searchObject = mm.Find(Proizvod obj);
    
  }
  
          }
          }
        