
        Create  PROCEDURE DeleteKupac(@SifraKupca Int)
        AS
        BEGIN
        DELETE FROM Kupac  WHERE
        SifraKupca= @SifraKupca
        
        END
        GO
      