-- ################### SEED DATA ######################

-- Extract data from .csv file and load into our db

-- Create a staging table to hold all the seed data.  We'll query this 
-- table in order to extract what we need to then insert into our real
-- tables.
CREATE TABLE [dbo].[AllData]
(
	[Location] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[Event] NVARCHAR(20),
	[Gender] NVARCHAR(20),
	[Athlete] NVARCHAR(50),
	[RaceTime] REAL
);

-- Hard code the full path to the csv file.  It'll be better this way 
-- when we run this in HW 9 to build an Azure db 
BULK INSERT [dbo].[AllData]
	FROM 'C:\Users\Owner\Desktop\Git_Clone\CS460-F19-brad7555\HW8\Lab8\racetimes.csv'
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2
	);

-- Load coaches data, no foreign keys here to worry about so we can 
-- do a straight insert of just the distinct values

--DROP TABLE [dbo].[AllData];
INSERT INTO [dbo].[Coaches] ([Name])
    SELECT DISTINCT Coach 
    FROM [dbo].[AllData];

INSERT INTO [dbo].[Teams] (Name, CID)
    SELECT DISTINCT ad.Team, cs.ID
        FROM dbo.AllData as ad, dbo.Coaches as cs
        WHERE ad.Coach = cs.Name;

INSERT INTO [dbo].[Athletes] (Name, Gender, TID)
    SELECT DISTINCT ad.Athlete, ad.Gender, cs.ID
        FROM dbo.AllData as ad, dbo.Teams as cs
        WHERE ad.Team = cs.Name;

INSERT INTO [dbo].[Events] ([Type])
    SELECT DISTINCT Event 
    FROM [dbo].[AllData];

INSERT INTO [dbo].[LocationDetails] (Date, Place)
    SELECT DISTINCT ad.MeetDate, ad.Location
    FROM [dbo].[AllData] as ad;

INSERT INTO [dbo].[Results] (RaceTime, AID, EID, LID)
    SELECT DISTINCT ad.RaceTime, a.ID, e.ID, l.ID 
    FROM dbo.AllData as ad, dbo.Athletes as a, dbo.Events as e, dbo.LocationDetails as l
    WHERE ad.Athlete = a.Name AND ad.Event = e.Type AND ad.MeetDate = l.Date;


