
    CREATE PROCEDURE InsertKorpa
    (
    
          @SifraKupca Int
          @Datum Date
    )
    AS
    BEGIN
    
    insert into Korpa (
           [SifraKupca],
         
           [Datum]
             )
    values (
          @SifraKupca,
        
                @Datum)
  
    END
    GO
  