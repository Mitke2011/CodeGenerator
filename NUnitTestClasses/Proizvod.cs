
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;

using Code_Generation;
using Middletier;

namespace NUnitTestClasses
{
    [CodeAttribute("Proizvod")]
    public class Proizvod
    {

        public Proizvod()
        {
        }

        private System.Int32 SifraProizvoda;
        private System.String Naziv;
        private System.Int32 Kolicina;


        [CodeAttribute("SifraProizvoda", "Proizvod", true)]
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


    }
}
