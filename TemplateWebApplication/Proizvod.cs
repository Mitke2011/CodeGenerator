
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;

using Middletier;

namespace TemplateWebApplication
{
    [CodeAttribute("Proizvod")]
    public class Proizvod
    {

        public Proizvod()
        {
        }

        private System.Int32 sifraproizvoda;
        private System.String naziv;
        private System.Int32 kolicina;




        public static string GetIDPropertyName()
        {
            return "SifraProizvoda";
        }
        [CodeAttribute("SifraProizvoda", "Proizvod", true)]
        public System.Int32 SifraProizvoda
        {
            get { return this.sifraproizvoda; }
            set
            {
                this.sifraproizvoda = value;
            }
        }

        [CodeAttribute("Naziv", "Proizvod")]
        public System.String Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                this.naziv = value;
            }
        }

        [CodeAttribute("Kolicina", "Proizvod")]
        public System.Int32 Kolicina
        {
            get
            {
                return kolicina;
            }

            set
            {
                this.kolicina = value;
            }
        }


    }
}
