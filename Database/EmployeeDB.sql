USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 26-Oct-2020 5:41:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](500) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 26-Oct-2020 5:41:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](500) NULL,
	[Department] [nvarchar](500) NULL,
	[JoiningDate] [date] NULL,
	[PhotoFileName] [nvarchar](500) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (7, N'IT')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (8, N'Support')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (9, N'MIS')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (10, N'Accounts')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (11, N'HR')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (12, N'Marketing')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (13, N'Sales')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (14, N'Production')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (1, N'Saiful Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'me.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (2, N'Imam Hossain', N'IT', CAST(N'2020-01-01' AS Date), N'you.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (5, N'Naimul Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'naimul.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (6, N'Saidul Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'saidul.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (7, N'Sirajul Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'sirajul.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (8, N'Mominul Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'mominul.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (9, N'Ashraful Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'ashraful.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (10, N'Rakibul Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'rakib.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (11, N'Kamrul Islam', N'MIS', CAST(N'2020-10-10' AS Date), N'kamrul.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (12, N'Sabbir Ahmed', N'MIS', CAST(N'2020-10-10' AS Date), N'sabbir.png')
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeName], [Department], [JoiningDate], [PhotoFileName]) VALUES (13, N'Lokamn Hosan', N'MIS', CAST(N'2020-10-10' AS Date), N'lokman.png')
SET IDENTITY_INSERT [dbo].[Employee] OFF
