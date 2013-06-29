
          
          Create  PROCEDURE SelectKupac(@SifraKupca Int)
          AS
          BEGIN
          SELECT * FROM Kupac

          WHERE SifraKupca = @SifraKupca

          END
          GO
        