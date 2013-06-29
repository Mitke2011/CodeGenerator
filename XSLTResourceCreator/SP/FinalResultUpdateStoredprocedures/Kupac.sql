
        CREATE PROCEDURE UpdateKupac
        (
        
          @SifraKupca Int,
        
          @Ime NVarChar(50),
        
          @Prezime NVarChar(50),
        
          @BrojTelefona NVarChar(50),
        
          @Adresa NVarChar(50)
          
        )
        AS
        BEGIN
        
    UPDATE Kupac 
    SET Ime = @Ime,
        Prezime = @Prezime,
        BrojTelefona = @BrojTelefona,
        Adresa = @Adresa
    WHERE SifraKupca = @SifraKupca
        END
        GO

      