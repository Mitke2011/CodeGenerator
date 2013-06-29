
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
        partial class Korpa_ProizvodEdit:Form
            {
            
    public Korpa_Proizvod(int ID)
      {
      InitializeComponent();
      MiddleTierManager mm = new MiddleTierManager();
      Korpa_Proizvod ob = new Korpa_Proizvod();
      ob.SifraProizvoda SifraKorpe Datum_Kupovine ID_Property = ID;
      ob = (Korpa_Proizvod) mm.FindOne(ob,true/>");
      
      
                    this.cboSifraProizvoda.SelectedValue=obj.SifraProizvoda;
                
                    this.cboSifraKorpe.SelectedValue=obj.SifraKorpe;
                
                    this.dtpDatum_Kupovine.Value=obj.Datum_Kupovine;
                
                    this.hdnID.Text =obj.ID;
                
      }
  
      private void button1_Click(object sender, EventArgs e)
      {
      Korpa_Proizvod obj = new Korpa_Proizvod();
        
            classObject.SifraProizvoda = 
                    this.cboSifraProizvoda.SelectedValue;
                
            classObject.SifraKorpe = 
                    this.cboSifraKorpe.SelectedValue;
                
            classObject.Datum_Kupovine = 
                    this.dtpDatum_Kupovine.Value;
                
            classObject.ID = 
                    this.txtID.Text;
                
      
      MiddleTier mm = new MiddleTier();
      mm.Save(Korpa_Proizvod obj);
    }
  
      private void button2_Click(object sender, EventArgs e)
      {
      Korpa_Proizvod obj = new Korpa_Proizvod();
        
            classObject.SifraProizvoda = 
                    this.cboSifraProizvoda.SelectedValue;
                
            classObject.SifraKorpe = 
                    this.cboSifraKorpe.SelectedValue;
                
            classObject.Datum_Kupovine = 
                    this.dtpDatum_Kupovine.Value;
                
            classObject.ID = 
                    this.txtID.Text;
                
      MiddleTier mm = new MiddleTier();
      mm.Update(Korpa_Proizvod obj);
  }
  
      private void button3_Click(object sender, EventArgs e)
      {
      Korpa_Proizvod obj = new Korpa_Proizvod();
        
            classObject.SifraProizvoda = 
                    this.cboSifraProizvoda.SelectedValue;
                
            classObject.SifraKorpe = 
                    this.cboSifraKorpe.SelectedValue;
                
            classObject.Datum_Kupovine = 
                    this.dtpDatum_Kupovine.Value;
                
            classObject.ID = 
                    this.txtID.Text;
                
      MiddleTier mm = new MiddleTier();
      mm.Delete(Korpa_Proizvod obj);
  }
  
      private void button4_Click(object sender, EventArgs e)
      {
      Korpa_Proizvod obj = new Korpa_Proizvod();
        
            classObject.SifraProizvoda = 
                    this.cboSifraProizvoda.SelectedValue;
                
            classObject.SifraKorpe = 
                    this.cboSifraKorpe.SelectedValue;
                
            classObject.Datum_Kupovine = 
                    this.dtpDatum_Kupovine.Value;
                
            classObject.ID = 
                    this.txtID.Text;
                
      MiddleTier mm = new MiddleTier();
      Korpa_Proizvod searchObject = mm.Find(Korpa_Proizvod obj);
    
  }
  
          }
          }
        