      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
        namespace XSLT
        {
        public class Korpa_Proizvod
        {
        
    public Korpa_Proizvod ()
    {
    }
  
      private int SifraProizvoda ;
      private int SifraKorpe ;
      private System.DateTime Datum_Kupovine ;
      private int ID ;
      public int SifraProizvodaProperty
      {
        get
        {
          return SifraProizvoda ;
        }

        set
        {
          this.SifraProizvoda=value;
        }
      }
      
      public int SifraKorpeProperty
      {
        get
        {
          return SifraKorpe ;
        }

        set
        {
          this.SifraKorpe=value;
        }
      }
      
      public System.DateTime Datum_KupovineProperty
      {
        get
        {
          return Datum_Kupovine ;
        }

        set
        {
          this.Datum_Kupovine=value;
        }
      }
      
        public int GetIDField ()
        {
        return this.ID;
        }
      

        }
        }
      