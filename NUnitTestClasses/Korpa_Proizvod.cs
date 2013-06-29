
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using Code_Generation;
using Middletier;

namespace NUnitTestClasses
{
    [CodeAttribute("Korpa_Proizvod")]
    public class Korpa_Proizvod
    {

        public Korpa_Proizvod()
        {
        }

        private System.Int32 SifraProizvoda;
        private System.Int32 SifraKorpe;
        private System.DateTime Datum_Kupovine;
        private System.Int32 ID;
        [CodeAttribute("SifraProizvoda", "Korpa_Proizvod")]
        public System.Int32 SifraProizvodaProperty
        {
            get
            {
                return SifraProizvoda;
            }

            set
            {
                this.SifraProizvoda = value;
            }
        }

        [CodeAttribute("SifraKorpe", "Korpa_Proizvod")]
        public System.Int32 SifraKorpeProperty
        {
            get
            {
                return SifraKorpe;
            }

            set
            {
                this.SifraKorpe = value;
            }
        }

        [CodeAttribute("Datum_Kupovine", "Korpa_Proizvod")]
        public System.DateTime Datum_KupovineProperty
        {
            get
            {
                return Datum_Kupovine;
            }

            set
            {
                this.Datum_Kupovine = value;
            }
        }



        [CodeAttribute("ID", "Korpa_Proizvod", true)]
        public System.Int32 GetIDField()
        {
            return this.ID;
        }


    }
}
