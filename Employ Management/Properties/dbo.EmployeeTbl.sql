CREATE TABLE [dbo].[EmployeeTbl] (
    [ID] INT NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    [Address] VARCHAR (50) NOT NULL,
    [Position] VARCHAR (50) NOT NULL,
    [DOB] DATE NOT NULL,
    [Phone] VARCHAR (50) NOT NULL,
    [Education] VARCHAR (50) NOT NULL,
    [Gender] VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
