
          
          Create  PROCEDURE SelectProizvod(@SifraProizvoda Int)
          AS
          BEGIN
          SELECT * FROM Proizvod

          WHERE SifraProizvoda = @SifraProizvoda

          END
          GO
        