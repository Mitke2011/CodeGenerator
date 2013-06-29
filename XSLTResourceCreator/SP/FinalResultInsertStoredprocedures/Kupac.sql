
    CREATE PROCEDURE InsertKupac
    (
    
          @Ime NVarChar(50),
          
          @Prezime NVarChar(50),
          
          @BrojTelefona NVarChar(50),
          
          @Adresa NVarChar(50)
          
    )
    AS
    BEGIN
    
    insert into Kupac (
           [Ime],
         
           [Prezime],
         
           [BrojTelefona],
         
           [Adresa]
             )
    values (
          @Ime,
        
          @Prezime,
        
          @BrojTelefona,
        
                @Adresa)
  
    END
    GO
  