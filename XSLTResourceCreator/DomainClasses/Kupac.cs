      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
                using Middletier;

                namespace
                {
                
                [CodeAttribute("Kupac")]
                public class Kupac
                {
                
        public Kupac ()
        {
        }
    
            private System.Int32 sifrakupca  ;
            private System.String ime  ;
            private System.String prezime  ;
            private System.String brojtelefona  ;
            private System.String adresa  ;

            public System.Int32 GetIDPropertyValue ()
            {
            return this.SifraKupca;
            }
        
            [CodeAttribute("SifraKupca","Kupac", true)]
            public System.Int32 SifraKupca
            {
            get
            {
            return sifrakupca ;
            }

            set
            {
            this.sifrakupca=value;
            }
            }
        
            [CodeAttribute("Ime","Kupac", false)]
            public System.String Ime
            {
            get
            {
            return ime ;
            }

            set
            {
            this.ime=value;
            }
            }
        
            [CodeAttribute("Prezime","Kupac", false)]
            public System.String Prezime
            {
            get
            {
            return prezime ;
            }

            set
            {
            this.prezime=value;
            }
            }
        
            [CodeAttribute("BrojTelefona","Kupac", false)]
            public System.String BrojTelefona
            {
            get
            {
            return brojtelefona ;
            }

            set
            {
            this.brojtelefona=value;
            }
            }
        
            [CodeAttribute("Adresa","Kupac", false)]
            public System.String Adresa
            {
            get
            {
            return adresa ;
            }

            set
            {
            this.adresa=value;
            }
            }
        

                }
                }

            