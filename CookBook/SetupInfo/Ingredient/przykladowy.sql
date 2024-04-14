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
           ('Czereśnia','Słodka z pestką','Owoc',61,1,0.3,14.6,'czeresnia.png','2024-08-12',22,1),
		   ('Kapusta','Zielona z liściami','Warzywo',38,1.7,0.2,7.4,'kapusta.png','2024-08-12',15,1),
		   ('Pietruszka','Zielona z liściami','Warzywo',38,2.6,0.5,15.6,'pietruszka.png','2024-08-12',11,1),
		   ('Kalafior','Kalafior zaliczany jest do cenniejszych warzyw z uwagi na swój skład chemiczny, a także walory smakowe i dietetyczne. Zawiera m.in.: sód, potas, magnez, wapń, mangan, żelazo, miedź, cynk, fosfor, fluor, chlor, jod, karoteny, witaminy:  K, B1, B2, B6, C; kwasy: nikotynowy i pantotenowy.','Warzywo',25.00,2.6,0.5,15.6,'kalafior.png','2024-04-14',16,1);

