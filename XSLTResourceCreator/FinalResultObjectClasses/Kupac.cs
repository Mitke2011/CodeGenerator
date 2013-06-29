      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
          using Middletier;

          namespace XSLT
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
        
        
        

          public static string GetIDPropertyName ()
          {
          return "SifraKupca";
            }
          [CodeAttribute("SifraKupca","Kupac", true)]
          public System.Int32 SifraKupca
          {
            get{return this.sifrakupca;}
          set
          {
          this.sifrakupca=value;
          }
          }
      
        [CodeAttribute("Ime","Kupac")]
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
      
        [CodeAttribute("Prezime","Kupac")]
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
      
        [CodeAttribute("BrojTelefona","Kupac")]
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
      
        [CodeAttribute("Adresa","Kupac")]
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
      