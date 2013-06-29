
        CREATE PROCEDURE UpdateKorpa_Proizvod
        (
        
          @SifraProizvoda Int,
        
          @SifraKorpe Int,
        
          @Datum_Kupovine Date,
        
          @ID Int
        )
        AS
        BEGIN
        
    UPDATE Korpa_Proizvod 
    SET SifraProizvoda = @SifraProizvoda,
        SifraKorpe = @SifraKorpe,
        Datum_Kupovine = @Datum_Kupovine,
        
    WHERE ID = @ID
        END
        GO

      