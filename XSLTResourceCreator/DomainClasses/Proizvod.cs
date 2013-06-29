      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
                using Middletier;

                namespace
                {
                
                [CodeAttribute("Proizvod")]
                public class Proizvod
                {
                
        public Proizvod ()
        {
        }
    
            private System.Int32 sifraproizvoda  ;
            private System.String naziv  ;
            private System.Int32 kolicina  ;

            public System.Int32 GetIDPropertyValue ()
            {
            return this.SifraProizvoda;
            }
        
            [CodeAttribute("SifraProizvoda","Proizvod", true)]
            public System.Int32 SifraProizvoda
            {
            get
            {
            return sifraproizvoda ;
            }

            set
            {
            this.sifraproizvoda=value;
            }
            }
        
            [CodeAttribute("Naziv","Proizvod", false)]
            public System.String Naziv
            {
            get
            {
            return naziv ;
            }

            set
            {
            this.naziv=value;
            }
            }
        
            [CodeAttribute("Kolicina","Proizvod", false)]
            public System.Int32 Kolicina
            {
            get
            {
            return kolicina ;
            }

            set
            {
            this.kolicina=value;
            }
            }
        

                }
                }

            