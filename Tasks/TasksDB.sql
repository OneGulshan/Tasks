USE [TasksDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
	[MenuId] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[City_Id] [int] IDENTITY(1,1) NOT NULL,
	[City_Name] [nvarchar](max) NULL,
	[S_Id] [int] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[City_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contexts]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contexts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Enrolled] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Contexts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Cid] [int] IDENTITY(1,1) NOT NULL,
	[CName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Csvs]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Csvs](
	[MemberId] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[StartDate] [nvarchar](max) NULL,
	[EndDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_Csvs] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Std_Id] [int] IDENTITY(1,1) NOT NULL,
	[Std_Name] [nvarchar](max) NULL,
	[Std_Class] [nvarchar](max) NULL,
	[Std_School] [nvarchar](max) NULL,
	[Std_Address] [nvarchar](max) NULL,
	[Std_Mobile] [nvarchar](max) NULL,
	[Std_Image] [nvarchar](max) NULL,
	[C_Id] [int] NOT NULL,
	[S_Id] [int] NOT NULL,
	[City_Id] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Std_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[JobRole] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesAddresses]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](max) NULL,
	[AddressType] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeesAddresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Start] [datetime2](7) NOT NULL,
	[ThemeColor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experiences]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiences](
	[ExperienceId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Degree] [nvarchar](max) NULL,
	[PassingYear] [nvarchar](max) NULL,
	[Percentage] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionsId] [int] NOT NULL,
	[Question1] [nvarchar](max) NULL,
	[Question2] [nvarchar](max) NULL,
	[Question3] [nvarchar](max) NULL,
	[Car1Q] [nvarchar](max) NULL,
	[Car2Q] [nvarchar](max) NULL,
	[Bike1Q] [nvarchar](max) NULL,
	[Bike2Q] [nvarchar](max) NULL,
	[radio] [int] NOT NULL,
	[Car] [bit] NOT NULL,
	[Bike] [bit] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[Cid] [int] NOT NULL,
	[SName] [nvarchar](max) NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategories]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategories](
	[SubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
 CONSTRAINT [PK_SubCategories] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhotoPath] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[FName] [nvarchar](max) NULL,
	[MName] [nvarchar](max) NULL,
	[LName] [nvarchar](max) NULL,
	[DOB] [datetime2](7) NULL,
	[Gender] [int] NULL,
	[ContactNo] [bigint] NULL,
	[Email] [nvarchar](max) NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [int] NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230107055150_Init', N'7.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230402060714_Init', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230402065234_TblEmpandAdd', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230409070134_AddtblContext', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230422100333_TblLinqUser', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230613161202_AddJqStudent', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230613161409_AddJqStudent', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230723132254_VrggrlTask', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230723153929_AddAutoMapper', N'8.0.1')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (1, N'New Summer', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (2, N'Vegetables', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (3, N'Fruits', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (4, N'Washing Machine', 1002)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (5, N'New Skirts', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (6, N'New Pants', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (7, N'New Accessories', 1)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (8, N'Tees', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (9, N'Camis/Tanks', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (10, N'Knit Tops', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (11, N'Tie Front Tops', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (12, N'Strapless Tops', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (13, N'Long Sleeve Tops', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (14, N'Jumpers / Sweaters', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (15, N'Bandanas', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (16, N'Vests', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (17, N'Corsets/Bustiers', 3)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (18, N'Mini Dresses', 4)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (19, N'Midi Dresses', 4)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (20, N'Maxi Dresses', 4)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (21, N'Knit Dresses', 4)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (22, N'Formal Dresses', 4)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (23, N'Skirts +', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (24, N'Playsuits / Jumpsuits', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (25, N'Pants', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (26, N'Jeans', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (27, N'Shorts', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (28, N'Sets', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (29, N'Jumpers/Sweaters', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (30, N'Jackets', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (31, N'Knitwear +', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (32, N'Swim', 5)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (33, N'Shop by Collection', 7)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (34, N'Shop by Occasion', 7)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (35, N'Home', 8)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (36, N'Jewellery  +', 8)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (37, N'Hair Accessories +', 8)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (38, N'Shoes +', 8)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (39, N'Bags', 8)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (40, N'Sale Tops', 9)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (41, N'Sale Dresses / Playsuits', 9)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (42, N'Sale Accessories', 9)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (43, N'Sale Bottoms', 9)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (44, N'Sale Outerwear', 9)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([City_Id], [City_Name], [S_Id]) VALUES (1, N'Patna', 2)
INSERT [dbo].[Cities] ([City_Id], [City_Name], [S_Id]) VALUES (3, N'New Delhi', 1)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Contexts] ON 

INSERT [dbo].[Contexts] ([Id], [Name], [Enrolled]) VALUES (3, N'Ankit Kumar', CAST(N'2024-06-16T16:38:00.0000000' AS DateTime2))
INSERT [dbo].[Contexts] ([Id], [Name], [Enrolled]) VALUES (2002, N'Hare Krishna', CAST(N'2024-06-16T16:32:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Contexts] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Cid], [CName]) VALUES (1, N'India')
INSERT [dbo].[Countries] ([Cid], [CName]) VALUES (2, N'Usa')
INSERT [dbo].[Countries] ([Cid], [CName]) VALUES (4, N'Shrilanka')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
INSERT [dbo].[Csvs] ([MemberId], [Email], [StartDate], [EndDate]) VALUES (1, N'gk@gmail.com', N'02-02-2023', N'03-02-2023')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Std_Id], [Std_Name], [Std_Class], [Std_School], [Std_Address], [Std_Mobile], [Std_Image], [C_Id], [S_Id], [City_Id]) VALUES (2, N'Gulshan', N'MCA', N'IGNOU', N'Rani Bagh', N'09911065342', N'2f225039-2365-4fb0-9555-d04d3aadbc7d-MyPhoto.jpeg', 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [JobRole]) VALUES (1004, N'Gulshan', N'Kumar', N'DotNet')
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [JobRole]) VALUES (2005, N'Hare', N'Krishna', N'2345')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (1, N'Meating', N'Today is my meating', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (2, N'Meating', N'Today is my meating', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (3, N'Meating', N'Today is my meating', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (4, N'Meating', N'Today is my Meating', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'red')
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (5, N'Meating', N'Today is my Meating', CAST(N'2024-06-14T17:18:32.8866667' AS DateTime2), N'Blue')
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (7, N'Food', N'Food Time', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'red')
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (1002, N'Test', N'Test', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'blue')
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (1003, N'Test', N'Test', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'red')
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (1004, N'Thu Jun 20 2024 00:00:00 GMT+0530 (India Standard Time)', N'Test', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'red')
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (1006, N'Tue May 28 2024 00:00:00 GMT+0530 (India Standard Time)', N'Test', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'blue')
INSERT [dbo].[Events] ([EventId], [Subject], [Description], [Start], [ThemeColor]) VALUES (1009, N'Tue Jun 04 2024 00:00:00 GMT+0530 (India Standard Time)', N'Test', CAST(N'2024-06-04T00:00:00.0000000' AS DateTime2), N'blue')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
INSERT [dbo].[Experiences] ([ExperienceId], [Id], [Degree], [PassingYear], [Percentage]) VALUES (1, 2002, N'BCA', N'2012', 60)
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [ImagePath]) VALUES (1, N'1adce7bd-8af1-49e2-b16a-99fb3bcfde4f-Car2_2000.jpg')
INSERT [dbo].[Images] ([Id], [ImagePath]) VALUES (2, N'0df7d3f3-759d-4073-b039-ef92272e3cff-Atta.jpg')
INSERT [dbo].[Images] ([Id], [ImagePath]) VALUES (3, N'97cdae85-185c-4c47-b704-f0814bf3d386-Car2_2000.jpg')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
INSERT [dbo].[Logins] ([Id], [Email], [Password]) VALUES (4, N'Hello4@Gmail.com', N'Hello@123')
INSERT [dbo].[Logins] ([Id], [Email], [Password]) VALUES (6, N'Hello@Gmail.com', N'Hello@123')
INSERT [dbo].[Logins] ([Id], [Email], [Password]) VALUES (8, N'Hello@Gmail.com', N'Hello@123')
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 

INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (1, N'Grocery')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (2, N'Most Loved')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (3, N'Tops')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (4, N'Dresses')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (5, N'Clothing')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (6, N'Back In Stock')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (7, N'Shop By')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (8, N'Accessories')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (9, N'Sale')
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (1002, N'Electronic')
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
INSERT [dbo].[Questions] ([QuestionsId], [Question1], [Question2], [Question3], [Car1Q], [Car2Q], [Bike1Q], [Bike2Q], [radio], [Car], [Bike]) VALUES (1, N'a', N'a', N'a', N'a', N'a', N'b', N'a', 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (1, 1, N'Delhi')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (2, 1, N'Bihar')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (3, 1, N'Uttar Pradesh')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (4, 2, N'California')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (5, 2, N'Texas')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (6, 2, N'Florida')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (7, 4, N'Saran')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (8, 4, N'Patna')
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (10, 4, N'Muzaffarpur')
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategories] ON 

INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (1, N'Wedding Guest Edit', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (2, N'Vintage Inspired', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (3, N'Party Edit', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (4, N'Festival Edit', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (5, N'White Party', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (6, N'Linen Edit', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (7, N'Summer Vacation Edit', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (8, N'WorkWear Edit', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (9, N'Denim Edit', 33, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (10, N'Take The Style Quiz', 34, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (11, N'Vintage Cool Girl', 34, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (12, N'Modern Music', 34, 7)
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (13, N'Everyday It Girl', 34, 7)
SET IDENTITY_INSERT [dbo].[SubCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([Id], [PhotoPath], [Code], [FName], [MName], [LName], [DOB], [Gender], [ContactNo], [Email], [Age]) VALUES (2002, N'c88710a4-85ab-4012-af5e-ef6ae95835c7-Profile.jpg', N'Sup_2002', N'Gulshan', N'Singh', N'Kumar', CAST(N'1996-01-24T00:00:00.0000000' AS DateTime2), 0, 7689979875, N'gulshankumar.mailid01@gmail.com', 28)
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [Country], [State]) VALUES (1, 2, 5)
INSERT [dbo].[Teachers] ([Id], [Country], [State]) VALUES (20, 1, 2)
INSERT [dbo].[Teachers] ([Id], [Country], [State]) VALUES (22, 1, 1)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
/****** Object:  Index [IX_EmployeesAddresses_EmployeeId]    Script Date: 6/16/2024 11:26:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeesAddresses_EmployeeId] ON [dbo].[EmployeesAddresses]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeesAddresses]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesAddresses_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeesAddresses] CHECK CONSTRAINT [FK_EmployeesAddresses_Employee_EmployeeId]
GO
/****** Object:  StoredProcedure [dbo].[LoginProcedure]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter Proc LoginProcedure
@Flag varchar(50),  
@Id int  
As  
Begin  
if(@Flag='Delete')  
begin  
Delete From Logins Where Id=@Id  
End  
if(@Flag='Edit')  
begin  
Select Email,Password From Logins Where Id=@Id  
End  
if(@Flag='Check')  
begin  
SELECT Id FROM Logins WHERE Id = @Id;  
End  
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Employee]    Script Date: 6/16/2024 11:26:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[SP_Employee]
As
Begin
Select * From Employee
End
GO
USE [master]
GO
ALTER DATABASE [TasksDB] SET  READ_WRITE 
GO
Select * From Employees

----------------------------------------------------------
Create Table Employee -- For Web API
(
	Id int primary key identity,
	Name Varchar(50),
	City Varchar(50)
)

Select * From Csvs