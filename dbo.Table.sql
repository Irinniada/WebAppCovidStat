CREATE TABLE [dbo].[Vacced]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Birthday] DATE NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [DayOfVaccination] DATE NOT NULL, 
    [Vaccine] NVARCHAR(50) NOT NULL, 
    [VaccineDose] INT NOT NULL
)
