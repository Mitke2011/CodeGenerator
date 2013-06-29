
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;

namespace XSLT
{
    public class Kupac
    {

        public Kupac()
        {
        }

        private int SifraKupca;
        private string Ime;
        private string Prezime;
        private string BrojTelefona;
        private string Adresa;
        public int GetIDField()
        {
            return this.SifraKupca;
        }

        public string ImeProperty
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

        public string PrezimeProperty
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

        public string BrojTelefonaProperty
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

        public string AdresaProperty
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
