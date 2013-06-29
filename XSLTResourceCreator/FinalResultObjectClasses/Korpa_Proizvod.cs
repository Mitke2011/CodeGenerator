      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
          using Middletier;

          namespace XSLT
          {
          [CodeAttribute("Korpa_Proizvod")]
        public class Korpa_Proizvod
        {
        
    public Korpa_Proizvod ()
    {
    }
  
      private System.Int32 sifraproizvoda  ;
      private System.Int32 sifrakorpe  ;
      private System.DateTime datum_kupovine  ;
      private System.Int32 id  ;
        [CodeAttribute("SifraProizvoda","Korpa_Proizvod")]
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
      
        [CodeAttribute("SifraKorpe","Korpa_Proizvod")]
        public System.Int32 SifraKorpe
      {
        get
        {
          return sifrakorpe ;
        }

        set
        {
          this.sifrakorpe=value;
        }
      }
      
        [CodeAttribute("Datum_Kupovine","Korpa_Proizvod")]
        public System.DateTime Datum_Kupovine
      {
        get
        {
          return datum_kupovine ;
        }

        set
        {
          this.datum_kupovine=value;
        }
      }
      
        
        
        

          public static string GetIDPropertyName ()
          {
          return "ID";
            }
          [CodeAttribute("ID","Korpa_Proizvod", true)]
          public System.Int32 ID
          {
            get{return this.id;}
          set
          {
          this.id=value;
          }
          }
      

        }
        }
      