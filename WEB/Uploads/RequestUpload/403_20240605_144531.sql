USE [hseProd]
GO
/****** Object:  Table [dbo].[GRI403A_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403A_ESG](
	[GRI403AId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYearA] [int] NULL,
	[OccupHealthA] [varchar](max) NULL,
	[ScopeWorkerA] [varchar](max) NULL,
	[OccupHealthServiceA] [varchar](max) NULL,
	[CommentA] [varchar](max) NULL,
	[SupportDocA] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GRI403AId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403C_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403C_ESG](
	[GRI403CId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYearC] [int] NOT NULL,
	[OrgImpC] [bit] NULL,
	[OrgImpDescC] [varchar](max) NULL,
	[PerEmpC] [bit] NULL,
	[PerEmpDescC] [varchar](max) NULL,
	[CommentC] [varchar](max) NULL,
	[SupDocC] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GRI403CId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403D_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403D_ESG](
	[GRI403DId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[DescriptionId] [int] NULL,
	[GRI403DValues] [numeric](21, 2) NULL,
	[Gender] [varchar](20) NULL,
	[UnitId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GRI403DId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403DDoc_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403DDoc_ESG](
	[GRI403DDocId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[InjuriesCont] [varchar](max) NULL,
	[InjuryRate] [varchar](150) NULL,
	[Comment] [varchar](max) NULL,
	[SupDoc] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GRI403DDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403E_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403E_ESG](
	[GRI403EId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[DescriptionId] [int] NULL,
	[GRI403EValues] [numeric](21, 2) NULL,
	[Gender] [varchar](20) NULL,
	[UnitId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GRI403EId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403EDoc_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403EDoc_ESG](
	[GRI403EDocId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[InjuriesCount] [varchar](max) NULL,
	[InjuryRate] [varchar](150) NULL,
	[Comment] [varchar](max) NULL,
	[SupDoc] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GRI403EDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403F_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403F_ESG](
	[GRI403FId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[DescriptionId] [int] NULL,
	[GRI403FValues] [numeric](21, 2) NULL,
	[Gender] [varchar](20) NULL,
	[UnitId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_GRI403F_ESG] PRIMARY KEY CLUSTERED 
(
	[GRI403FId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403FDoc_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403FDoc_ESG](
	[GRI403FDocId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[DiseaseTotal] [varchar](max) NULL,
	[DiseaseRate] [varchar](150) NULL,
	[Comment] [varchar](max) NULL,
	[SupDoc] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GRI403FDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403G_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403G_ESG](
	[GRI403GId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[DescriptionId] [int] NULL,
	[GRI403GValues] [numeric](21, 2) NULL,
	[Gender] [varchar](20) NULL,
	[UnitId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRI403GDoc_ESG]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRI403GDoc_ESG](
	[GRI403GDocId] [int] IDENTITY(1,1) NOT NULL,
	[GRIYear] [int] NULL,
	[GRIMonth] [int] NULL,
	[OccupationalTotal] [varchar](max) NULL,
	[Comment] [varchar](max) NULL,
	[SupDoc] [varchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GRI403A_ESG] ON 

INSERT [dbo].[GRI403A_ESG] ([GRI403AId], [GRIYearA], [OccupHealthA], [ScopeWorkerA], [OccupHealthServiceA], [CommentA], [SupportDocA], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, N'T', N't', N't', N't', N'C', 2970, CAST(N'2023-10-11T17:23:01.470' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403A_ESG] ([GRI403AId], [GRIYearA], [OccupHealthA], [ScopeWorkerA], [OccupHealthServiceA], [CommentA], [SupportDocA], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, 2024, NULL, N'v', N'b', N'b', N'C', 2970, CAST(N'2024-01-28T18:08:23.720' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GRI403A_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403C_ESG] ON 

INSERT [dbo].[GRI403C_ESG] ([GRI403CId], [GRIYearC], [OrgImpC], [OrgImpDescC], [PerEmpC], [PerEmpDescC], [CommentC], [SupDocC], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 0, 1, N'r', 1, N'g', N'g', N'C', 2970, CAST(N'2023-10-12T12:21:39.640' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GRI403C_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403D_ESG] ON 

INSERT [dbo].[GRI403D_ESG] ([GRI403DId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403DValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, 10, 1, CAST(10.00 AS Numeric(21, 2)), N'Male', 5, 2970, CAST(N'2023-10-17T18:56:29.363' AS DateTime), 2970, NULL, 1)
INSERT [dbo].[GRI403D_ESG] ([GRI403DId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403DValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, 2023, 10, 3, CAST(12.00 AS Numeric(21, 2)), N'Female', 2, 2970, CAST(N'2023-10-17T18:56:32.690' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403D_ESG] ([GRI403DId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403DValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (3, 2023, 10, 4, CAST(13.00 AS Numeric(21, 2)), N'Female', 3, 2970, CAST(N'2023-10-17T18:56:44.780' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403D_ESG] ([GRI403DId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403DValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (4, 2023, 10, 5, CAST(34.00 AS Numeric(21, 2)), N'Female', 3, 2970, CAST(N'2023-10-17T18:56:48.270' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403D_ESG] ([GRI403DId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403DValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (5, 2023, 10, 6, CAST(43.00 AS Numeric(21, 2)), N'Female', 4, 2970, CAST(N'2023-10-17T18:56:52.420' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403D_ESG] ([GRI403DId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403DValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (6, 2023, 10, 7, CAST(1.00 AS Numeric(21, 2)), N'Male', 3, 2970, CAST(N'2023-10-17T19:05:11.987' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GRI403D_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403DDoc_ESG] ON 

INSERT [dbo].[GRI403DDoc_ESG] ([GRI403DDocId], [GRIYear], [GRIMonth], [InjuriesCont], [InjuryRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, 10, N'data added', N'12', N'comment data added', N'/Uploads/ESG/403D/Truck Park Issue.png', 2970, CAST(N'2023-10-17T18:57:42.240' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403DDoc_ESG] ([GRI403DDocId], [GRIYear], [GRIMonth], [InjuriesCont], [InjuryRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, 0, 0, NULL, NULL, NULL, NULL, 2970, CAST(N'2023-10-20T18:20:21.493' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GRI403DDoc_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403E_ESG] ON 

INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, 10, 9, CAST(54.00 AS Numeric(21, 2)), N'Male', 2, 2970, CAST(N'2023-10-20T18:19:48.053' AS DateTime), 2970, CAST(N'2023-10-23T17:12:55.947' AS DateTime), 1)
INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, 2023, 10, 14, CAST(9.00 AS Numeric(21, 2)), N'Male', 4, 2970, CAST(N'2023-10-20T18:21:27.110' AS DateTime), 2970, CAST(N'2023-10-20T18:22:44.150' AS DateTime), 1)
INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (3, 2023, 10, 13, CAST(8.00 AS Numeric(21, 2)), N'Male', 4, 2970, CAST(N'2023-10-20T18:21:30.320' AS DateTime), 2970, CAST(N'2023-10-20T18:22:31.380' AS DateTime), 1)
INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (4, 2023, 10, 11, CAST(56.00 AS Numeric(21, 2)), N'Female', 3, 2970, CAST(N'2023-10-20T18:22:14.550' AS DateTime), 2970, CAST(N'2023-10-23T17:13:35.730' AS DateTime), 1)
INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (5, 2023, 10, 12, CAST(45.00 AS Numeric(21, 2)), N'Female', 3, 2970, CAST(N'2023-10-20T18:22:23.720' AS DateTime), 2970, CAST(N'2023-10-20T18:47:12.910' AS DateTime), 1)
INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (6, 0, 0, 18, CAST(0.00 AS Numeric(21, 2)), NULL, 0, 2970, CAST(N'2023-10-23T19:11:36.200' AS DateTime), 2970, CAST(N'2023-10-23T19:12:10.400' AS DateTime), 1)
INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (7, 2023, 12, 17, CAST(34.00 AS Numeric(21, 2)), N'Male', 2, 2970, CAST(N'2023-10-25T12:01:28.290' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403E_ESG] ([GRI403EId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403EValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (8, 2022, 2, 9, CAST(23.00 AS Numeric(21, 2)), N'Male', 1, 2970, CAST(N'2024-01-19T11:40:00.467' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GRI403E_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403EDoc_ESG] ON 

INSERT [dbo].[GRI403EDoc_ESG] ([GRI403EDocId], [GRIYear], [GRIMonth], [InjuriesCount], [InjuryRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, 10, N'tr', N'gh', N'dfgdf', N'/Uploads/ESG/403E/sample-pdf-file.pdf', 2970, CAST(N'2023-10-20T18:47:34.220' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403EDoc_ESG] ([GRI403EDocId], [GRIYear], [GRIMonth], [InjuriesCount], [InjuryRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, 0, 0, N't1', N't2', N't3', N'/Uploads/ESG/403E/Truck Park Issue.pdf', 2970, CAST(N'2023-10-23T17:15:32.983' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403EDoc_ESG] ([GRI403EDocId], [GRIYear], [GRIMonth], [InjuriesCount], [InjuryRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (3, 0, 0, NULL, NULL, NULL, NULL, 0, CAST(N'2023-10-23T18:44:37.207' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GRI403EDoc_ESG] ([GRI403EDocId], [GRIYear], [GRIMonth], [InjuriesCount], [InjuryRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (4, 2023, 12, N'test1', N'test2', N'test3', N'/Uploads/ESG/403E/Truck Park Issue.pdf', 2970, CAST(N'2023-10-25T12:02:14.780' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403EDoc_ESG] ([GRI403EDocId], [GRIYear], [GRIMonth], [InjuriesCount], [InjuryRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (5, 2022, 2, NULL, NULL, N'', NULL, 0, CAST(N'2024-01-19T11:40:05.637' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[GRI403EDoc_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403F_ESG] ON 

INSERT [dbo].[GRI403F_ESG] ([GRI403FId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403FValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, 10, 18, CAST(56.00 AS Numeric(21, 2)), N'Male', 2, 2970, CAST(N'2023-10-23T19:27:59.640' AS DateTime), 2970, CAST(N'2023-10-25T12:03:54.800' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[GRI403F_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403FDoc_ESG] ON 

INSERT [dbo].[GRI403FDoc_ESG] ([GRI403FDocId], [GRIYear], [GRIMonth], [DiseaseTotal], [DiseaseRate], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, 10, N'32', N'32', N'DAADASDSAD DAS DSADSD', N'/Uploads/ESG/403F/Screenshot 2023-09-29 153018.png', 2970, CAST(N'2023-10-23T19:28:32.233' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GRI403FDoc_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403G_ESG] ON 

INSERT [dbo].[GRI403G_ESG] ([GRI403GId], [GRIYear], [GRIMonth], [DescriptionId], [GRI403GValues], [Gender], [UnitId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 2023, 10, 19, CAST(2.00 AS Numeric(21, 2)), N'Male', 2, 2970, CAST(N'2023-10-26T16:04:45.370' AS DateTime), 2970, CAST(N'2023-10-26T17:02:46.563' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[GRI403G_ESG] OFF
GO
SET IDENTITY_INSERT [dbo].[GRI403GDoc_ESG] ON 

INSERT [dbo].[GRI403GDoc_ESG] ([GRI403GDocId], [GRIYear], [GRIMonth], [OccupationalTotal], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 0, 0, N'undefined', N'TEST2', N'/Uploads/ESG/403G/Truck Park Issue.pdf', 2970, CAST(N'2023-10-26T16:08:45.250' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GRI403GDoc_ESG] ([GRI403GDocId], [GRIYear], [GRIMonth], [OccupationalTotal], [Comment], [SupDoc], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, 2023, 10, N'dsds 1', N'dsdsd                     2', N'/Uploads/ESG/403G/LFZ.jpg', 2970, CAST(N'2023-10-26T17:20:55.253' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GRI403GDoc_ESG] OFF
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403A_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403A_CRUD]
@GRI403AId INT,
@GRIYearA INT,
@OccupHealthA VARCHAR,
@ScopeWorkerA VARCHAR,
@OccupHealthServiceA VARCHAR,
@CommentA VARCHAR,
@SupportDocA VARCHAR,
@CreatedBy int,
@IsActive bit,
@Flag int, 
@OutError VARCHAR(50) OUTPUT
AS 
BEGIN
    IF(@Flag=1) 
  BEGIN
    IF not exists (select top 1 (1) from GRI403A_ESG where GRIYearA = @GRIYearA and CreatedBy = @CreatedBy)
	BEGIN
	   INSERT INTO GRI403A_ESG 
	   (
	      GRIYearA,OccupHealthA,ScopeWorkerA,OccupHealthServiceA,CommentA,SupportDocA,CreatedBy,CreatedDate,IsActive
	   )
	   VALUES
	   (
	       @GRIYearA,@OccupHealthA,@ScopeWorkerA,@OccupHealthServiceA,@CommentA,@SupportDocA,@CreatedBy,getdate(),@IsActive
	   )
	   SET @OutError='Record inserted successfully.'
	END
	ELSE  IF(@Flag=2) 
	BEGIN
	    UPDATE GRI403A_ESG  SET
		       GRIYearA = @GRIYearA,
		       OccupHealthA = @OccupHealthA,
			   ScopeWorkerA = @ScopeWorkerA,
			   OccupHealthServiceA = @OccupHealthServiceA,
			   CommentA = @CommentA,
			   SupportDocA = @SupportDocA,
			   ModifiedBy = @CreatedBy,
			   ModifiedDate = getdate(),
			   IsActive = @IsActive
			   WHERE GRIYearA = @GRIYearA and CreatedBy = @CreatedBy
			   SET @OutError='Record updated successfully.'
	END
END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403C_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403C_CRUD]
@GRI403CId INT,
@GRIYearC INT,
@OrgImpC BIT,
@OrgImpDescC VARCHAR,
@PerEmpC BIT,
@PerEmpDescC VARCHAR,
@CommentC VARCHAR,
@SupDocC VARCHAR,
@CreatedBy int,
@IsActive bit,
@Flag int, 
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
     IF(@Flag=1) 
  BEGIN
    IF not exists (select top 1 (1) from GRI403C_ESG where GRIYearC = @GRIYearC and CreatedBy = @CreatedBy)
    BEGIN
	   INSERT INTO GRI403C_ESG 
	   (
	      GRIYearC,OrgImpC,OrgImpDescC,PerEmpC,PerEmpDescC,CommentC,SupDocC,CreatedBy,CreatedDate,IsActive
	   )
	   VALUES
	   (
	       @GRIYearC,@OrgImpC,@OrgImpDescC,@PerEmpC,@PerEmpDescC,@CommentC,@SupDocC,@CreatedBy,getdate(),@IsActive
	   )
	   SET @OutError='Record inserted successfully.'
	END
		ELSE  IF(@Flag=2) 
	BEGIN
	    UPDATE GRI403C_ESG  SET
		       GRIYearC= @GRIYearC,
		       OrgImpC = @OrgImpC,
			   OrgImpDescC = @OrgImpDescC,
			   PerEmpC = @PerEmpC,
			   PerEmpDescC = @PerEmpDescC,
			   CommentC = @CommentC,
			   SupDocC = @SupDocC,
			   ModifiedBy = @CreatedBy,
			   ModifiedDate = getdate(),
			   IsActive = @IsActive
			   WHERE GRIYearC = @GRIYearC and CreatedBy = @CreatedBy
			   SET @OutError='Record updated successfully.'
END
END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403D_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ESG_GRI403D_CRUD]
@GRI403DId int,
@GRIYear int,
@GRIMonth int,
@DescriptionId int,
@GRI403DValues numeric(21,2),
@Gender varchar(20),
@UnitId int,
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
As
Begin
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403D_ESG where DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403D_ESG(GRIYear,GRIMonth,DescriptionId,GRI403DValues,Gender,UnitId,CreatedBy,CreatedDate,IsActive)
			VALUES (@GRIYear,@GRIMonth,@DescriptionId,@GRI403DValues,@Gender,@UnitId,@CreatedBy,GETDATE(),@IsActive)
		end
		else
		begin
			UPDATE GRI403D_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403DValues = @GRI403DValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy 
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
		UPDATE GRI403D_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403DValues = @GRI403DValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE GRI403DId = @GRI403DId 
	END
End
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403D_G]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[ESG_GRI403D_G]
@CreatedBy int,
@GRIYear int,
@MonthId int
As
BEGIN
	select GRI403DId,GRIYear,GRIMonth,gri403D.DescriptionId,de.[Description],GRI403DValues,Gender,UnitId,gri403D.CreatedBy	
	from GRI403D_ESG gri403D
	inner join Description_ESG de
	on de.DescriptionId = gri403D.DescriptionId

	where gri403D.IsActive = 1 and gri403D.CreatedBy = @CreatedBy and GRIYear = @GRIYear and GRIMonth = @MonthId
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403DDoc_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ESG_GRI403DDoc_CRUD]
@GRI403DDocId int,
@GRIYear int,
@GRIMonth int,
@InjuriesCont varchar(max),
@InjuryRate varchar(150),
@Comment varchar(max),
@SupDoc varchar(max),
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403DDoc_ESG where  GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403DDoc_ESG (GRIYear,GRIMonth,InjuriesCont,InjuryRate,Comment,SupDoc,CreatedBy,CreatedDate,IsActive)
			VALUES(@GRIYear,@GRIMonth,@InjuriesCont,@InjuryRate,@Comment,@SupDoc,@CreatedBy,GETDATE(),@IsActive)
		end	
		else
		begin
			UPDATE GRI403DDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  InjuriesCont = @InjuriesCont,
									  InjuryRate= @InjuryRate,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403DDocId = @GRI403DDocId
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
			UPDATE GRI403DDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  InjuriesCont = @InjuriesCont,
									  InjuryRate= @InjuryRate,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403DDocId = @GRI403DDocId
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403DDOC_G]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[ESG_GRI403DDOC_G]
@CreatedBy int,
@GRIYear int,
@MonthId int
As
Begin
	select  GRI403DDocId,GRIYear,GRIMonth,InjuriesCont,InjuryRate,Comment,SupDoc,CreatedBy from GRI403DDoc_ESG gri403D
	where gri403D.IsActive = 1 and gri403D.CreatedBy = @CreatedBy and GRIYear = @GRIYear and GRIMonth = @MonthId
End

GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403E_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403E_CRUD]
@GRI403EId int,
@GRIYear int,
@GRIMonth int,
@DescriptionId int,
@GRI403EValues numeric(21,2),
@Gender varchar(20),
@UnitId int,
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
   Begin
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403E_ESG where DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403E_ESG(GRIYear,GRIMonth,DescriptionId,GRI403EValues,Gender,UnitId,CreatedBy,CreatedDate,IsActive)
			VALUES (@GRIYear,@GRIMonth,@DescriptionId,@GRI403EValues,@Gender,@UnitId,@CreatedBy,GETDATE(),@IsActive)
		end
		else
		begin
			UPDATE GRI403E_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403EValues = @GRI403EValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy 
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
		UPDATE GRI403E_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403EValues = @GRI403EValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE GRI403EId = @GRI403EId 
	END
END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403EDoc_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403EDoc_CRUD]
@GRI403EDocId int,
@GRIYear int,
@GRIMonth int,
@InjuriesCount varchar(max),
@InjuryRate varchar(150),
@Comment varchar(max),
@SupDoc varchar(max),
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403EDoc_ESG where  GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403EDoc_ESG (GRIYear,GRIMonth,InjuriesCount,InjuryRate,Comment,SupDoc,CreatedBy,CreatedDate,IsActive)
			VALUES(@GRIYear,@GRIMonth,@InjuriesCount,@InjuryRate,@Comment,@SupDoc,@CreatedBy,GETDATE(),@IsActive)
		end	
		else
		begin
			UPDATE GRI403EDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  InjuriesCount = @InjuriesCount,
									  InjuryRate= @InjuryRate,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403EDocId = @GRI403EDocId
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
			UPDATE GRI403EDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  InjuriesCount = @InjuriesCount,
									  InjuryRate= @InjuryRate,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403EDocId = @GRI403EDocId
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403F_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403F_CRUD]
@GRI403FId int,
@GRIYear int,
@GRIMonth int,
@DescriptionId int,
@GRI403FValues numeric(21,2),
@Gender varchar(20),
@UnitId int,
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
   Begin
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403F_ESG where DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403F_ESG(GRIYear,GRIMonth,DescriptionId,GRI403FValues,Gender,UnitId,CreatedBy,CreatedDate,IsActive)
			VALUES (@GRIYear,@GRIMonth,@DescriptionId,@GRI403FValues,@Gender,@UnitId,@CreatedBy,GETDATE(),@IsActive)
		end
		else
		begin
			UPDATE GRI403F_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403FValues = @GRI403FValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy 
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
		UPDATE GRI403F_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403FValues = @GRI403FValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE GRI403FId = @GRI403FId 
	END
END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403FDoc_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403FDoc_CRUD]
@GRI403FDocId int,
@GRIYear int,
@GRIMonth int,
@DiseaseTotal varchar(max),
@DiseaseRate varchar(150),
@Comment varchar(max),
@SupDoc varchar(max),
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403FDoc_ESG where  GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403FDoc_ESG (GRIYear,GRIMonth,DiseaseTotal,DiseaseRate,Comment,SupDoc,CreatedBy,CreatedDate,IsActive)
			VALUES(@GRIYear,@GRIMonth,@DiseaseTotal,@DiseaseRate,@Comment,@SupDoc,@CreatedBy,GETDATE(),@IsActive)
		end	
		else
		begin
			UPDATE GRI403FDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  DiseaseTotal = @DiseaseTotal,
									  DiseaseRate= @DiseaseRate,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403FDocId = @GRI403FDocId
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
			UPDATE GRI403FDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  DiseaseTotal = @DiseaseTotal,
									  DiseaseRate= @DiseaseRate,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403FDocId = @GRI403FDocId
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403G_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403G_CRUD]
@GRI403GId int,
@GRIYear int,
@GRIMonth int,
@DescriptionId int,
@GRI403GValues numeric(21,2),
@Gender varchar(20),
@UnitId int,
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
   Begin
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403G_ESG where DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403G_ESG(GRIYear,GRIMonth,DescriptionId,GRI403GValues,Gender,UnitId,CreatedBy,CreatedDate,IsActive)
			VALUES (@GRIYear,@GRIMonth,@DescriptionId,@GRI403GValues,@Gender,@UnitId,@CreatedBy,GETDATE(),@IsActive)
		end
		else
		begin
			UPDATE GRI403G_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403GValues = @GRI403GValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE DescriptionId = @DescriptionId and GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy 
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
		UPDATE GRI403G_ESG SET	GRIYear = @GRIYear,
								GRIMonth = @GRIMonth,
								DescriptionId = @DescriptionId,
								GRI403GValues = @GRI403GValues,
								Gender = @Gender,
								UnitId = @UnitId,
								ModifiedBy = @CreatedBy,
								ModifiedDate= GETDATE(),
								IsActive = @IsActive
						  WHERE GRI403GId = @GRI403GId 
	END
END
END
GO
/****** Object:  StoredProcedure [dbo].[ESG_GRI403GDoc_CRUD]    Script Date: 08-05-2024 17:06:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESG_GRI403GDoc_CRUD]
@GRI403GDocId int,
@GRIYear int,
@GRIMonth int,
@OccupationalTotal varchar(max),
@Comment varchar(max),
@SupDoc varchar(max),
@CreatedBy int,
@IsActive bit,
@Flag INT,
@OutError VARCHAR(50) OUTPUT
AS
BEGIN
	IF(@Flag = 1)
	BEGIN
		IF not exists (select top 1 (1) from GRI403GDoc_ESG where  GRIYear = @GRIYear and GRIMonth = @GRIMonth and CreatedBy = @CreatedBy and IsActive = @IsActive)
		begin
			INSERT INTO GRI403GDoc_ESG (GRIYear,GRIMonth,OccupationalTotal,Comment,SupDoc,CreatedBy,CreatedDate,IsActive)
			VALUES(@GRIYear,@GRIMonth,@OccupationalTotal,@Comment,@SupDoc,@CreatedBy,GETDATE(),@IsActive)
		end	
		else
		begin
			UPDATE GRI403GDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  OccupationalTotal = @OccupationalTotal,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403GDocId = @GRI403GDocId
		end
	END
	ELSE IF(@Flag = 2)
	BEGIN
			UPDATE GRI403GDoc_ESG SET GRIYear = @GRIYear,
									  GRIMonth = @GRIMonth,
									  OccupationalTotal = @OccupationalTotal,
									  Comment = @Comment,
									  SupDoc = @SupDoc,
									  ModifiedBy = @CreatedBy,
									  ModifiedDate = GETDATE(),
									  IsActive = @IsActive
									  WHERE GRI403GDocId = @GRI403GDocId
	END
END
GO
