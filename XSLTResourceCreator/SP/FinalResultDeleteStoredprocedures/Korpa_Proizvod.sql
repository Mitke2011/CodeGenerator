
        Create  PROCEDURE DeleteKorpa_Proizvod(@ID Int)
        AS
        BEGIN
        DELETE FROM Korpa_Proizvod  WHERE
        ID= @ID
        
        END
        GO
      