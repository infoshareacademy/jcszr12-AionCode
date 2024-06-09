INSERT INTO MealDay( [Day],  [AddDate] , [UserCookBookId])
VALUES 
('2024/04/09 17:00', '2024/04/09 17:00','4bd32ece-6d64-495b-9a54-4661d9ef06a3'),
('2024/05/09 18:00', '2024/04/09 17:00','4bd32ece-6d64-495b-9a54-4661d9ef06a3'),
('2024/06/09 19:00', '2024/04/09 17:00','4bd32ece-6d64-495b-9a54-4661d9ef06a3'),
('2024/07/09 20:00', '2024/04/09 17:00','4bd32ece-6d64-495b-9a54-4661d9ef06a3');

INSERT INTO RecipeUsed(RecipeDetailsId, AddDate, PartOfDay,MealDayId)
VALUES
(3,'2024/04/09 17:00','Obiad', 1)

INSERT INTO RecipeDetails([Name], [Category] ,[Description],[ImagePath],[AddDate] ,[UserCookBookId])
VALUES
('Kurczak w cieœcie', 'miêcho', 
'kurczak to kurczak, smakuje jak kurczak',
'kurczak.png','2024/04/09 17:00',
'4bd32ece-6d64-495b-9a54-4661d9ef06a3'),
('Kurczak z jab³kiem', 'miêcho', 
'kurczak to kurczak, smakuje jak kurczak',
'kurczak.png','2024/04/09 17:00',
'4bd32ece-6d64-495b-9a54-4661d9ef06a3'),
('Kurczak w panierce', 'miêcho', 
'kurczak to kurczak, smakuje jak kurczak',
'kurczak.png','2024/04/09 17:00',
'4bd32ece-6d64-495b-9a54-4661d9ef06a3'),
('Kurczak solo', 'miêcho', 
'kurczak to kurczak, smakuje jak kurczak',
'kurczak.png','2024/04/09 17:00',
'4bd32ece-6d64-495b-9a54-4661d9ef06a3');