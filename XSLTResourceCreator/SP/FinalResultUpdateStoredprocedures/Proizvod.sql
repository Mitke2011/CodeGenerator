
        CREATE PROCEDURE UpdateProizvod
        (
        
          @SifraProizvoda Int,
        
          @Naziv NVarChar(50),
        
          @Kolicina Int
        )
        AS
        BEGIN
        
    UPDATE Proizvod 
    SET Naziv = @Naziv,
        Kolicina = @Kolicina
    WHERE SifraProizvoda = @SifraProizvoda
        END
        GO

      