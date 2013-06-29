using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using Code_Generation;
using Middletier;

namespace XSLTResourceCreator
{
    public class Proizvod
    {

        public Proizvod()
        {
        }


        private System.Int32 _sifraProizvoda;
        private System.String Naziv;
        private System.Int32 Kolicina;

        public System.Int32 GetIDField()
        {
            return this.SifraProizvoda;
        }

        [CodeAttribute("Naziv", "Proizvod")]
        public System.String NazivProperty
        {
            get
            {
                return Naziv;
            }

            set
            {
                this.Naziv = value;
            }
        }

        [CodeAttribute("Kolicina", "Proizvod")]
        public System.Int32 KolicinaProperty
        {
            get
            {
                return Kolicina;
            }

            set
            {
                this.Kolicina = value;
            }
        }

        [CodeAttribute("SifraProizvoda", "Proizvod", true)]
        public int SifraProizvoda
        {
            get { return _sifraProizvoda; }
            set { _sifraProizvoda = value; }
        }
    }
}
