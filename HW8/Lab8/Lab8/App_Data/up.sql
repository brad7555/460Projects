

CREATE TABLE [dbo].[Coaches]
(
    [ID]    INT IDENTITY (1,1)    NOT NULL,
    [Name]    NVARCHAR(50)        NOT NULL,
    CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Teams]
(
    [ID]    INT IDENTITY (1,1)    NOT NULL,
    [Name]    NVARCHAR(50)        NOT NULL,
    [CID]   INT                    NOT NULL,
    CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Coaches_ID] FOREIGN KEY ([CID]) REFERENCES [dbo].[Coaches] ([ID])
);

CREATE TABLE [dbo].[Athletes]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [Name]        NVARCHAR(50)        NOT NULL,
    [Gender]    NVARCHAR(50)        NOT NULL,
    [TID]        INT                    NOT NULL,
    CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Teams_ID] FOREIGN KEY ([TID]) REFERENCES [dbo].[Teams] ([ID])
);

CREATE TABLE [dbo].[Events]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [Type]        NVARCHAR(50)        NOT NULL,
    CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[LocationDetails]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [Date]        DATETIME            NOT NULL,
    [Place]        NVARCHAR(50)        NOT NULL,
    CONSTRAINT [PK_dbo.ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Results]
(   [ID]        INT IDENTITY (1,1)    NOT NULL,
    [RaceTime]    NVARCHAR(50)        NOT NULL,
    [AID]        INT                    NOT NULL,
    [EID]        INT                    NOT NULL,
    [LID]        INT                    NOT NULL,
    CONSTRAINT [PK_dbo.Results] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Athletes_ID] FOREIGN KEY ([AID]) REFERENCES [dbo].[Athletes] ([ID]),
    CONSTRAINT [FK_dbo.Events_ID] FOREIGN KEY ([EID]) REFERENCES [dbo].[Events] ([ID]),
    CONSTRAINT [FK_dbo.LocationDetails_ID] FOREIGN KEY ([LID]) REFERENCES [dbo].[LocationDetails] ([ID])
);
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




GO

