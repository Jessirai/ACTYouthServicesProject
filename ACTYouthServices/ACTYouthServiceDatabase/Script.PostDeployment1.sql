/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Service AS Target 
USING (VALUES 
        (1, 'Service 1', 'Service 1 Desc', -109.236, -182.974, 'Belconnen', 1, 0, 0, 0, 0), 
        (2, 'Service 2', 'Service 2 Desc', -106.126, -184.967, 'Woden', 1, 0, 0, 1, 1), 
        (3, 'Service 3', 'Service 1 Desc', -110.336, -181.645, 'Civic', 0, 1, 1, 0, 0) 
) 
AS Source (ServiceID, Name, Description, Latitude, Longitude, Location, Shelter, Health, Food, Legal, Family) 
ON Target.ServiceID = Source.ServiceID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name, Description, Latitude, Longitude, Location, Shelter, Health, Food, Legal, Family) 
VALUES (Name, Description, Latitude, Longitude, Location, Shelter, Health, Food, Legal, Family);
