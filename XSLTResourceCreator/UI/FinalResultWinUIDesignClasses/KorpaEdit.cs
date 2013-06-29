
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
        partial class KorpaEdit:Form
            {
            
    public Korpa(int ID)
      {
      InitializeComponent();
      MiddleTierManager mm = new MiddleTierManager();
      Korpa ob = new Korpa();
      ob.KorpaID SifraKupca Datum_Property = ID;
      ob = (Korpa) mm.FindOne(ob,true/>");
      
      
                    this.hdnID.Text =obj.KorpaID;
                
                    this.cboSifraKupca.SelectedValue=obj.SifraKupca;
                
                    this.dtpDatum.Value=obj.Datum;
                
      }
  
      private void button1_Click(object sender, EventArgs e)
      {
      Korpa obj = new Korpa();
        
            classObject.KorpaID = 
                    this.txtKorpaID.Text;
                
            classObject.SifraKupca = 
                    this.cboSifraKupca.SelectedValue;
                
            classObject.Datum = 
                    this.dtpDatum.Value;
                
      
      MiddleTier mm = new MiddleTier();
      mm.Save(Korpa obj);
    }
  
      private void button2_Click(object sender, EventArgs e)
      {
      Korpa obj = new Korpa();
        
            classObject.KorpaID = 
                    this.txtKorpaID.Text;
                
            classObject.SifraKupca = 
                    this.cboSifraKupca.SelectedValue;
                
            classObject.Datum = 
                    this.dtpDatum.Value;
                
      MiddleTier mm = new MiddleTier();
      mm.Update(Korpa obj);
  }
  
      private void button3_Click(object sender, EventArgs e)
      {
      Korpa obj = new Korpa();
        
            classObject.KorpaID = 
                    this.txtKorpaID.Text;
                
            classObject.SifraKupca = 
                    this.cboSifraKupca.SelectedValue;
                
            classObject.Datum = 
                    this.dtpDatum.Value;
                
      MiddleTier mm = new MiddleTier();
      mm.Delete(Korpa obj);
  }
  
      private void button4_Click(object sender, EventArgs e)
      {
      Korpa obj = new Korpa();
        
            classObject.KorpaID = 
                    this.txtKorpaID.Text;
                
            classObject.SifraKupca = 
                    this.cboSifraKupca.SelectedValue;
                
            classObject.Datum = 
                    this.dtpDatum.Value;
                
      MiddleTier mm = new MiddleTier();
      Korpa searchObject = mm.Find(Korpa obj);
    
  }
  
          }
          }
        