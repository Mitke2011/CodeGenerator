      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
          using Middletier;

          namespace XSLT
          {
          [CodeAttribute("Korpa")]
        public class Korpa
        {
        
    public Korpa ()
    {
    }
  
      private System.Int32 korpaid  ;
      private System.Int32 sifrakupca  ;
      private System.DateTime datum  ;
        
        
        

          public static string GetIDPropertyName ()
          {
          return "KorpaID";
            }
          [CodeAttribute("KorpaID","Korpa", true)]
          public System.Int32 KorpaID
          {
            get{return this.korpaid;}
          set
          {
          this.korpaid=value;
          }
          }
      
        [CodeAttribute("SifraKupca","Korpa")]
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
      
        [CodeAttribute("Datum","Korpa")]
        public System.DateTime Datum
      {
        get
        {
          return datum ;
        }

        set
        {
          this.datum=value;
        }
      }
      

        }
        }
      