      
     using System;
     using System.Collections.Generic;
     using System.Xml;     
     using System.Linq;
     using System.Text;
    
    namespace XSLT
    {
    
        
    public class Kupac
    {
    
    public Kupac ()
    {
    }   
  
      private int SifraKupca ;
      private string Ime ;
      private string Prezime ;
      private string BrojTelefona ;
      private string Adresa ;
      
      public int GetIDField ()
      {
        return this.SifraKupca;
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
     
      public string ImeProperty
      {
        get
        {
          return Ime ;
        }
        
        set
        {
          this.Ime=value;
        }
      }      
     
      public string PrezimeProperty
      {
        get
        {
          return Prezime ;
        }
        
        set
        {
          this.Prezime=value;
        }
      }      
     
      public string BrojTelefonaProperty
      {
        get
        {
          return BrojTelefona ;
        }
        
        set
        {
          this.BrojTelefona=value;
        }
      }      
     
      public string AdresaProperty
      {
        get
        {
          return Adresa ;
        }
        
        set
        {
          this.Adresa=value;
        }
      }      
    
    
    }
  
        
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
     
      public int KorpaIDProperty
      {
        get
        {
          return KorpaID ;
        }
        
        set
        {
          this.KorpaID=value;
        }
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
  
        
    public class Korpa_Proizvod
    {
    
    public Korpa_Proizvod ()
    {
    }   
  
      private int SifraProizvoda ;
      private int SifraKorpe ;
      private System.DateTime Datum_Kupovine ;
      private int ID ;
      
      public int GetIDField ()
      {
        return this.ID;
      }
     
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
     
      public int IDProperty
      {
        get
        {
          return ID ;
        }
        
        set
        {
          this.ID=value;
        }
      }      
    
    
    }
  
        
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
  