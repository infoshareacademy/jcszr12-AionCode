USE [AionCodeDatabase]
GO

BEGIN
INSERT INTO [dbo].[userCookBook]
           ([Name]
           ,[Email]
           ,[Password]
           ,[Role]
           ,[AddDate])
     VALUES
           ('test1', 'test@wp.pl', 111111, 'test', '2024-04-08')
END

INSERT INTO [dbo].[IngredientDetails]
           ([Name]
           ,[Description]
           ,[Type]
           ,[Calories]
           ,[Proteins]
           ,[Fats]
           ,[Carbohydrates]
           ,[ImagePath]
           ,[AddDate]
           ,[GI]
           ,[UserCookBookId])
     VALUES
           ('Czereśnia','Słodka z pestką','Owoc',61,1,0.3,14.6,'http://127.0.0.1:10000/devstoreaccount1/ingredient-files/czeresnia.png','2024-08-12',22,1),
		   ('Kapusta','Zielona z liściami','Warzywo',38,1.7,0.2,7.4,'http://127.0.0.1:10000/devstoreaccount1/ingredient-files/kapusta.png','2024-08-12',15,1),
		   ('Pietruszka','Zielona z liściami','Warzywo',38,2.6,0.5,15.6,'http://127.0.0.1:10000/devstoreaccount1/ingredient-files/pietruszka.png','2024-08-12',11,1);
