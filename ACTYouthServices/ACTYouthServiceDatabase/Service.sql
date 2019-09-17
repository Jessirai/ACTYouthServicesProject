CREATE TABLE [dbo].[Service]
(
	[ServiceID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NCHAR(10) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Latitude] DECIMAL(9, 6) NOT NULL, 
    [Longitude] DECIMAL(9, 6) NOT NULL, 
    [Location] NCHAR(10) NOT NULL, 
    [Shelter] BIT NULL, 
    [Health] BIT NULL, 
    [Food] BIT NULL, 
    [Legal] BIT NULL, 
    [Family] BIT NULL,
	PRIMARY KEY CLUSTERED ([ServiceID] ASC)
)
