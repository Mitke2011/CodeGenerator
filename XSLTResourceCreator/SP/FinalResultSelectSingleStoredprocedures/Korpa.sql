
          
          Create  PROCEDURE SelectKorpa(@KorpaID Int)
          AS
          BEGIN
          SELECT * FROM Korpa

          WHERE KorpaID = @KorpaID

          END
          GO
        