
SET IDENTITY_INSERT [dbo].[UserDetails] ON 
GO

INSERT [dbo].[UserDetails] ([UDID], [OrganizationID], [EmployeeName], [EmailId], [MobileNo], [DepartmentID], [ReportingToID], [Password], [InitialPasswordReset], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive], [saltKey], [isHOD], [ProfileImagePath]) VALUES (2220, 1, N'Kolawole Mate', N'kolawole.mate@tolaram.com', N'00000000000', NULL, 1, N'34-C3-BB-4E-7D-72-FB-4A-22-57-D5-9F-1D-FA-53-EA', 1, 1, CAST(N'2024-09-13T00:00:00.000' AS DateTime), NULL, NULL, 1, N'FnbPH5QHaT', NULL, NULL)
GO
INSERT [dbo].[UserDetails] ([UDID], [OrganizationID], [EmployeeName], [EmailId], [MobileNo], [DepartmentID], [ReportingToID], [Password], [InitialPasswordReset], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive], [saltKey], [isHOD], [ProfileImagePath]) VALUES (2221, 1, N'LFZ User', N'lfz@tolaram.com', N'000000', NULL, 1, N'34-C3-BB-4E-7D-72-FB-4A-22-57-D5-9F-1D-FA-53-EA', 1, 1, CAST(N'2024-09-16T00:00:00.000' AS DateTime), NULL, NULL, 1, N'FnbPH5QHaT', NULL, NULL)
GO
INSERT [dbo].[UserDetails] ([UDID], [OrganizationID], [EmployeeName], [EmailId], [MobileNo], [DepartmentID], [ReportingToID], [Password], [InitialPasswordReset], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive], [saltKey], [isHOD], [ProfileImagePath]) VALUES (2222, 26, N'FZU User', N'fzu@tolaram.com', N'000000', NULL, 1, N'34-C3-BB-4E-7D-72-FB-4A-22-57-D5-9F-1D-FA-53-EA', 1, 1, CAST(N'2024-09-16T00:00:00.000' AS DateTime), NULL, NULL, 1, N'FnbPH5QHaT', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
GO
