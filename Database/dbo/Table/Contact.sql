CREATE TABLE [dbo].[Contact]
(
	[id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [nom] VARCHAR(MAX) NULL, 
    [prenom] VARCHAR(MAX) NULL, 
    [mail] VARCHAR(MAX) NULL, 
    [campagne_id] INT NOT NULL
)
