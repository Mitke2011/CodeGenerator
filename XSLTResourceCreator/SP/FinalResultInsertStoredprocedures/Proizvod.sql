
    CREATE PROCEDURE InsertProizvod
    (
    
          @Naziv NVarChar(50),
          
          @Kolicina Int
    )
    AS
    BEGIN
    
    insert into Proizvod (
           [Naziv],
         
           [Kolicina]
             )
    values (
          @Naziv,
        
                @Kolicina)
  
    END
    GO
  