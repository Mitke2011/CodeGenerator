
        CREATE PROCEDURE UpdateKorpa
        (
        
          @KorpaID Int,
        
          @SifraKupca Int,
        
          @Datum Date
        )
        AS
        BEGIN
        
    UPDATE Korpa 
    SET SifraKupca = @SifraKupca,
        Datum = @Datum
    WHERE KorpaID = @KorpaID
        END
        GO

      