
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using Code_Generation;
using Middletier;

namespace NUnitTestClasses
{
    [CodeAttribute("Kupac")]
    public class Kupac
    {

        public Kupac()
        {
        }

        private System.Int32 SifraKupca;
        private System.String Ime;
        private System.String Prezime;
        private System.String BrojTelefona;
        private System.String Adresa;


        [CodeAttribute("SifraKupca", "Kupac", true)]
        public System.Int32 GetIDField()
        {
            return this.SifraKupca;
        }

        [CodeAttribute("Ime", "Kupac")]
        public System.String ImeProperty
        {
            get
            {
                return Ime;
            }

            set
            {
                this.Ime = value;
            }
        }

        [CodeAttribute("Prezime", "Kupac")]
        public System.String PrezimeProperty
        {
            get
            {
                return Prezime;
            }

            set
            {
                this.Prezime = value;
            }
        }

        [CodeAttribute("BrojTelefona", "Kupac")]
        public System.String BrojTelefonaProperty
        {
            get
            {
                return BrojTelefona;
            }

            set
            {
                this.BrojTelefona = value;
            }
        }

        [CodeAttribute("Adresa", "Kupac")]
        public System.String AdresaProperty
        {
            get
            {
                return Adresa;
            }

            set
            {
                this.Adresa = value;
            }
        }


    }
}
