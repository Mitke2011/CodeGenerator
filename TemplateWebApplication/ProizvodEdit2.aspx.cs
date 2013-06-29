
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Middletier;

namespace TemplateWebApplication
{
    public partial class ProizvodEdit2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MiddletierManager mm = new MiddletierManager();
            if (!IsPostBack)
            {
                Proizvod ob = new Proizvod();
                int id;
                if (int.TryParse(Request.QueryString["objectid"], out id))
                {
                    ob.SifraProizvoda = id;
                    ob = (Proizvod)Convert.ChangeType(mm.FindOne(ob, true), typeof(Proizvod));
                }



                this.hdnID.Value = ob.SifraProizvoda.ToString();

                this.txtNaziv.Text = ob.Naziv;

                this.txtKolicina.Text = ob.Kolicina.ToString();

            }



        }


        protected void SaveButtonEvent(object sender, EventArgs e)
        {
            MiddletierManager mm = new MiddletierManager();
            Proizvod objectClass = new Proizvod();

            objectClass.SifraProizvoda = int.Parse(this.hdnID.Value);
            objectClass.Naziv =
                    this.txtNaziv.Text;

            objectClass.Kolicina =
                    int.Parse(this.txtKolicina.Text);

            if (Request.QueryString["objectid"] != null)
                mm.Update(objectClass, true);
            else
                mm.Save(objectClass, true);
        }


        protected void DeleteButton(object sender, EventArgs e)
        {
            MiddletierManager mm = new MiddletierManager();
            Proizvod objectClass = new Proizvod();

            objectClass.SifraProizvoda = int.Parse(this.hdnID.Value);
            objectClass.Naziv =
                    this.txtNaziv.Text;

            objectClass.Kolicina =
                    int.Parse(this.txtKolicina.Text);

            mm.Delete(objectClass, true);
        }


        protected void UpdateButton(object sender, EventArgs e)
        {
            MiddletierManager mm = new MiddletierManager();

            Proizvod objectClass = new Proizvod();

            objectClass.SifraProizvoda = int.Parse(this.hdnID.Value);
            objectClass.Naziv =
                    this.txtNaziv.Text;

            objectClass.Kolicina =
                    int.Parse(this.txtKolicina.Text);


            mm.Update(objectClass, true);

        }


    }
}
