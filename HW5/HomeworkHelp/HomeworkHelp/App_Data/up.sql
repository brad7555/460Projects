CREATE TABLE [dbo].[Homework]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [PRIORITY]  TEXT       NOT NULL,
    [DATE]    DATE        NOT NULL,
	[TIME] TEXT        NOT NULL,
	[DEPARTMENT] NVARCHAR(64)        NOT NULL,
    [COURSEID]  INT        NOT NULL,
	[TITLE] TEXT        NOT NULL,
	[NOTES]  TEXT			NOT NULL,
    CONSTRAINT [PK_dbo.Homework] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Homework] (PRIORITY, DATE, TIME, DEPARTMENT, COURSEID, TITLE, NOTES) VALUES
    ('1', '2019-12-19', '11:59 PM', 'CS', '334', 'Essay', 'Include Srouces'),
	('1', '2021-9-5', '11:59 PM', 'CS', '346', 'Essay', 'Inc Srouces'),
	('1', '2021-8-2', '11:59 PM', 'CS', '346', 'Essay', 'Inc Srouces'),
	('1', '2021-7-18', '11:59 PM', 'CS', '346', 'Essay', 'Inc Srouces'),
	('1', '2019-11-20', '11:59 PM', 'CS', '346', 'Essay', 'Inc Srouces')
    
GO
