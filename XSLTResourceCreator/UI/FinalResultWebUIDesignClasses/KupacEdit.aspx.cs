
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
                using Middletier;

                namespace WebUI
                {
                public partial class KupacEdit : System.Web.UI.Page
                {
                
        protected void Page_Load(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        if(!IsPostBack)
        {
        Kupac ob = new Kupac();
        int id;
        if (int.TryParse(Request.QueryString["objectid"],out id))
        {
        ob.SifraKupca = id;
        ob =(Kupac) Convert.ChangeType(mm.FindOne(ob,true),typeof(Kupac));
        }


        
                    this.hdnID.Value =ob.SifraKupca.ToString();
                
                    this.txtIme.Text=ob.Ime;
                
                    this.txtPrezime.Text=ob.Prezime;
                
                    this.txtBrojTelefona.Text=ob.BrojTelefona;
                
                    this.txtAdresa.Text=ob.Adresa;
                
        }



        }
    

        protected void SaveButtonEvent(object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        Kupac objectClass = new Kupac();
        
            objectClass.SifraKupca = int.Parse(this.hdnID.Value);
            objectClass.Ime = 
                    this.txtIme.Text;
                
            objectClass.Prezime = 
                    this.txtPrezime.Text;
                
            objectClass.BrojTelefona = 
                    this.txtBrojTelefona.Text;
                
            objectClass.Adresa = 
                    this.txtAdresa.Text;
                
        if(Request.QueryString["objectid"]!=null)
        mm.Update(objectClass,true);
        else
        mm.Save(objectClass,true);
        }
    

        protected void DeleteButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();
        Kupac objectClass = new Kupac();
        
            objectClass.SifraKupca = int.Parse(this.hdnID.Value);
            objectClass.Ime = 
                    this.txtIme.Text;
                
            objectClass.Prezime = 
                    this.txtPrezime.Text;
                
            objectClass.BrojTelefona = 
                    this.txtBrojTelefona.Text;
                
            objectClass.Adresa = 
                    this.txtAdresa.Text;
                
        mm.Delete(objectClass,true);
        }
    

        protected void UpdateButton (object sender, EventArgs e)
        {
        MiddletierManager mm = new MiddletierManager();

        Kupac objectClass = new Kupac();
        
            objectClass.SifraKupca = int.Parse(this.hdnID.Value);
            objectClass.Ime = 
                    this.txtIme.Text;
                
            objectClass.Prezime = 
                    this.txtPrezime.Text;
                
            objectClass.BrojTelefona = 
                    this.txtBrojTelefona.Text;
                
            objectClass.Adresa = 
                    this.txtAdresa.Text;
                

        mm.Update(objectClass,true);

        }
    

                }
                }
            