
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
                using Middletier;

                namespace WebUI
                {
                public partial class Korpa_ProizvodEdit : System.Web.UI.Page
                {
                
        protected void Page_Load(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        if(!IsPostBack)
        {
        Korpa_Proizvod ob = new Korpa_Proizvod();
        int id;
        if (int.TryParse(Request.QueryString["objectid"],out id))
        {
        ob.ID = id;
        ob =(Korpa_Proizvod) Convert.ChangeType(mm.FindOne(ob,true),typeof(Korpa_Proizvod));
        }


        
                    this.cboSifraProizvoda.SelectedValue=ob.SifraProizvoda;
                
                    this.cboSifraKorpe.SelectedValue=ob.SifraKorpe;
                
                    this.dtpDatum_Kupovine.Value=ob.Datum_Kupovine;
                
                    this.hdnID.Value =ob.ID.ToString();
                
        }



        }
    

        protected void SaveButtonEvent(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        Korpa_Proizvod objectClass = new Korpa_Proizvod();
        
            objectClass.SifraProizvoda = 
                    this.cboSifraProizvoda.SelectedValue;
                
            objectClass.SifraKorpe = 
                    this.cboSifraKorpe.SelectedValue;
                
            objectClass.Datum_Kupovine = 
                    this.dtpDatum_Kupovine.Value;
                
            objectClass.ID = int.Parse(this.hdnID.Value);
        if(Request.QueryString["objectid"]!=null)
        mm.Update(objectClass,true);
        else
        mm.Save(objectClass,true);
        }
    

        protected void DeleteButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        Korpa_Proizvod objectClass = new Korpa_Proizvod();
        
            objectClass.SifraProizvoda = 
                    this.cboSifraProizvoda.SelectedValue;
                
            objectClass.SifraKorpe = 
                    this.cboSifraKorpe.SelectedValue;
                
            objectClass.Datum_Kupovine = 
                    this.dtpDatum_Kupovine.Value;
                
            objectClass.ID = int.Parse(this.hdnID.Value);
        mm.Delete(objectClass,true);
        }
    

        protected void UpdateButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();

        Korpa_Proizvod objectClass = new Korpa_Proizvod();
        
            objectClass.SifraProizvoda = 
                    this.cboSifraProizvoda.SelectedValue;
                
            objectClass.SifraKorpe = 
                    this.cboSifraKorpe.SelectedValue;
                
            objectClass.Datum_Kupovine = 
                    this.dtpDatum_Kupovine.Value;
                
            objectClass.ID = int.Parse(this.hdnID.Value);

        mm.Update(objectClass,true);

        }
    

                }
                }
            