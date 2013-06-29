      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;

namespace MyClassLibProject
        {
        public class Proizvod
        {
        
    public Proizvod ()
    {
    }
  
      private int SifraProizvoda ;
      private string Naziv ;
      private int Kolicina ;
        public int GetIDField ()
        {
        return this.SifraProizvoda;
        }
      
      public string NazivProperty
      {
        get
        {
          return Naziv ;
        }

        set
        {
          this.Naziv=value;
        }
      }
      
      public int KolicinaProperty
      {
        get
        {
          return Kolicina ;
        }

        set
        {
          this.Kolicina=value;
        }
      }
      

        }
        }
      