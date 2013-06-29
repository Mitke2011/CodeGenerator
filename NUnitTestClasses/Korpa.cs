
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using Middletier;

namespace NUnitTestClasses
{
    [CodeAttribute("Korpa")]
    public class Korpa
    {

        public Korpa()
        {
        }

        private System.Int32 KorpaID;
        private System.Int32 SifraKupca;
        private System.DateTime Datum;


        [CodeAttribute("KorpaID", "Korpa", true)]
        public System.Int32 GetIDField()
        {
            return this.KorpaID;
        }

        [CodeAttribute("SifraKupca", "Korpa")]
        public System.Int32 SifraKupcaProperty
        {
            get
            {
                return SifraKupca;
            }

            set
            {
                this.SifraKupca = value;
            }
        }

        [CodeAttribute("Datum", "Korpa")]
        public System.DateTime DatumProperty
        {
            get
            {
                return Datum;
            }

            set
            {
                this.Datum = value;
            }
        }


    }
}
