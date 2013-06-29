      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
        namespace XSLT
        {
        public class Korpa
        {
        
    public Korpa ()
    {
    }
  
      private int KorpaID ;
      private int SifraKupca ;
      private System.DateTime Datum ;
        public int GetIDField ()
        {
        return this.KorpaID;
        }
      
      public int SifraKupcaProperty
      {
        get
        {
          return SifraKupca ;
        }

        set
        {
          this.SifraKupca=value;
        }
      }
      
      public System.DateTime DatumProperty
      {
        get
        {
          return Datum ;
        }

        set
        {
          this.Datum=value;
        }
      }
      

        }
        }
      