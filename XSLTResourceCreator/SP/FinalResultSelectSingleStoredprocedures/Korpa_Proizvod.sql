
          
          Create  PROCEDURE SelectKorpa_Proizvod(@ID Int)
          AS
          BEGIN
          SELECT * FROM Korpa_Proizvod

          WHERE ID = @ID

          END
          GO
        