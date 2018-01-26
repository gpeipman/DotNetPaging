SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PressReleases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](512) NOT NULL,
	[Company] [nvarchar](20) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
 CONSTRAINT [PK_PressReleases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PressReleases] ON 
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (1, N'Park Place Technologies selects Microsoft Cloud to transform sales and customer engagement', N'Microsoft', CAST(N'2017-12-11' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (2, N'Microsoft launches Azure Location Based Services for geospatial needs across industries', N'Microsoft', CAST(N'2017-11-28' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (4, N'Oracle Unveils World’s First Autonomous Database Cloud', N'Oracle', CAST(N'2017-10-02' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (7, N'Oracle Launches Enterprise-Grade Blockchain Cloud Service', N'Oracle', CAST(N'2017-10-02' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (8, N'ASX Upgrades its Technical Architecture to Improve Requirements for Business Productivity with JBoss Middleware', N'Red Hat', CAST(N'2017-12-13' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (9, N'Red Hat Adds Common Criteria Security Certification for Red Hat Enterprise Linux', N'Red Hat', CAST(N'2017-12-13' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (10, N'Kotlin on Android. Now official', N'JetBrains', CAST(N'2017-05-17' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (11, N'AvePoint Expands with New Office in Denver’s Tech Center', N'AvePoint', CAST(N'2017-11-28' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (12, N'AvePoint Wins at the 30th Annual ChamberRVA Impact Awards', N'AvePoint', CAST(N'2017-11-17' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (13, N'Nokia opens Cloud Collaboration Hubs to enable operators to realize their cloud strategies', N'Nokia', CAST(N'2018-01-26' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (14, N'Nokia launches world-first MulteFire(TM) small cell to widen adoption of private LTE for industries, enterprises and operators ', N'Nokia', CAST(N'2018-01-25' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (15, N'Worldwide user organization founded for open IoT platform MindSphere', N'Siemens', CAST(N'2018-01-24' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (16, N'Industrie 4.0: The hour of implementation has arrived', N'Siemens', CAST(N'2017-11-28' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (17, N'IBM and Salesforce Strengthen Strategic Partnership ', N'Salesforce', CAST(N'2018-01-19' AS Date))
GO
INSERT [dbo].[PressReleases] ([Id], [Title], [Company], [ReleaseDate]) VALUES (18, N'

YETI Coolers Launches New Digital Shopping Experience on Salesforce Commerce Cloud ', N'Salesforce', CAST(N'2018-01-16' AS Date))
GO
SET IDENTITY_INSERT [dbo].[PressReleases] OFF
GO
/****** Object:  Index [IX_PressReleases]    Script Date: 26.01.2018 22:31:51 ******/
CREATE NONCLUSTERED INDEX [IX_PressReleases] ON [dbo].[PressReleases]
(
	[ReleaseDate] DESC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
