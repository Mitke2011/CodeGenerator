
        Create  PROCEDURE DeleteProizvod(@SifraProizvoda Int)
        AS
        BEGIN
        DELETE FROM Proizvod  WHERE
        SifraProizvoda= @SifraProizvoda
        
        END
        GO
      