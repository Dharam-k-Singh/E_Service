


SET IDENTITY_INSERT [dbo].[M_Department] ON
GO
INSERT [dbo].[M_Department] ([DepartmentId], [DepartmentName], [DepartmentEmailId], [EscalationEmailLevel1], [NoOfDaysForEscalation], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (14, N'Sustainability', N'kolawole.mate@tolaram.com', N'vishal.shah@tolaram.com ', 8, 57, CAST(N'2024-09-10T04:39:51.600' AS DateTime), 57, CAST(N'2024-09-16T13:46:51.827' AS DateTime), 1)
GO
INSERT [dbo].[M_Department] ([DepartmentId], [DepartmentName], [DepartmentEmailId], [EscalationEmailLevel1], [NoOfDaysForEscalation], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (15, N'Medical', N'tega.oscar@tolaram.com', N'kareem.oladunni@tolaram.com,ashish.khemka@lftzc.com', 8, 57, CAST(N'2024-09-10T05:00:00.407' AS DateTime), 57, CAST(N'2024-09-10T05:09:01.490' AS DateTime), 1)
GO
INSERT [dbo].[M_Department] ([DepartmentId], [DepartmentName], [DepartmentEmailId], [EscalationEmailLevel1], [NoOfDaysForEscalation], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [IsActive]) VALUES (16, N'Facility Management', N' rajesh.lama@tolaram.com', N'swaraj.agarwal@tolaram.com', 8, 57, CAST(N'2024-09-10T05:01:23.047' AS DateTime), NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[M_Department] OFF
GO