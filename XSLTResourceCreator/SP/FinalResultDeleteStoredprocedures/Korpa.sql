
        Create  PROCEDURE DeleteKorpa(@KorpaID Int)
        AS
        BEGIN
        DELETE FROM Korpa  WHERE
        KorpaID= @KorpaID
        
        END
        GO
      