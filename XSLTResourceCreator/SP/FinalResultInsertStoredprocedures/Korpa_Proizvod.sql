
    CREATE PROCEDURE InsertKorpa_Proizvod
    (
    
          @SifraProizvoda Int
          @SifraKorpe Int
          @Datum_Kupovine Date
    )
    AS
    BEGIN
    
    insert into Korpa_Proizvod (
           [SifraProizvoda],
         
           [SifraKorpe],
         
           [Datum_Kupovine],
         )
    values (
          @SifraProizvoda,
        
          @SifraKorpe,
        
          @Datum_Kupovine,
        )
  
    END
    GO
  