
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
                using Middletier;

                namespace WebUI
                {
                public partial class KorpaEdit : System.Web.UI.Page
                {
                
        protected void Page_Load(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        if(!IsPostBack)
        {
        Korpa ob = new Korpa();
        int id;
        if (int.TryParse(Request.QueryString["objectid"],out id))
        {
        ob.KorpaID = id;
        ob =(Korpa) Convert.ChangeType(mm.FindOne(ob,true),typeof(Korpa));
        }


        
                    this.hdnID.Value =ob.KorpaID.ToString();
                
                    this.cboSifraKupca.SelectedValue=ob.SifraKupca;
                
                    this.dtpDatum.Value=ob.Datum;
                
        }



        }
    

        protected void SaveButtonEvent(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        Korpa objectClass = new Korpa();
        
            objectClass.KorpaID = int.Parse(this.hdnID.Value);
            objectClass.SifraKupca = 
                    this.cboSifraKupca.SelectedValue;
                
            objectClass.Datum = 
                    this.dtpDatum.Value;
                
        if(Request.QueryString["objectid"]!=null)
        mm.Update(objectClass,true);
        else
        mm.Save(objectClass,true);
        }
    

        protected void DeleteButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        Korpa objectClass = new Korpa();
        
            objectClass.KorpaID = int.Parse(this.hdnID.Value);
            objectClass.SifraKupca = 
                    this.cboSifraKupca.SelectedValue;
                
            objectClass.Datum = 
                    this.dtpDatum.Value;
                
        mm.Delete(objectClass,true);
        }
    

        protected void UpdateButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();

        Korpa objectClass = new Korpa();
        
            objectClass.KorpaID = int.Parse(this.hdnID.Value);
            objectClass.SifraKupca = 
                    this.cboSifraKupca.SelectedValue;
                
            objectClass.Datum = 
                    this.dtpDatum.Value;
                

        mm.Update(objectClass,true);

        }
    

                }
                }
            