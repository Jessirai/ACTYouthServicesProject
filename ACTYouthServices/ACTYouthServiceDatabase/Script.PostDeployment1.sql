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
        (1, 'Belconnen Community Service', '', 62640200, '26 Chandler Street, Belconnen ACT 2616', -35.230168, 149.07014, 'bcs@bcsact.com.au', 'Monday to Friday, 9AM to 5PM', 0, 0, 0, 1, 0, 1, 1, 'Belconnen', 'Parking, Toilets, Ramps', null, null, null, null, null, null, 'https://www.bcsact.com.au/'), 
        (2, 'Bit Bent - Gender Diverse Support', '', 62640200, 'Belconnen Youth Centre, Corner of Chandler Street and Swanson Court, Belconnen', -35.230168, 149.07014, 'bcs@bcsact.com.au', 'Monday evenings, 6PM to 8PM, during school terms', 0, 1, 0, 0, 0, 1, 1, 'Belconnen', null, 'Anyone', null, 12, 25, 'No fee', null, 'https://www.bcsact.com.au/programs-and-services/bit-bent-lgtbiq-social-group-youth-services/')
) 
AS Source (ServiceID, Name, Description, Phone, Address, Longitude, Latitude, Email, OpeningHours, Shelter, Food, Job, Family, Legal, Diversity, Health, Location, Accessability, Clientele, Referral, MinAge, MaxAge, Cost, Languages, Website) 
ON Target.ServiceID = Source.ServiceID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name, Description, Phone, Address, Longitude, Latitude, Email, OpeningHours, Shelter, Food, Job, Family, Legal, Diversity, Health, Location, Accessability, Clientele, Referral, MinAge, MaxAge, Cost, Languages, Website) 
VALUES (Name, Description, Phone, Address, Longitude, Latitude, Email, OpeningHours, Shelter, Food, Job, Family, Legal, Diversity, Health, Location, Accessability, Clientele, Referral, MinAge, MaxAge, Cost, Languages, Website);
