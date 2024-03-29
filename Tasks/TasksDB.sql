USE [TasksDB]
GO
/****** Object:  StoredProcedure [dbo].[LoginProcedure]    Script Date: 4/3/2023 4:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LoginProcedure]
@Flag varchar(50) = ''
as
begin
if @Flag ='Read'
begin
select * from Login
end
if @Flag ='Delete'
begin
delete from Login
end
end
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/3/2023 4:16:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Csvs]    Script Date: 4/3/2023 4:16:29 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 4/3/2023 4:16:29 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 4/3/2023 4:16:29 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 4/3/2023 4:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 4/3/2023 4:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionsId] [int] IDENTITY(1,1) NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [JobRole]) VALUES (1, N'Gulshan1', N'Kumar', N'Dot Net')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeesAddresses] ON 
GO
INSERT [dbo].[EmployeesAddresses] ([Id], [City], [AddressType], [Country], [EmployeeId]) VALUES (1, N'Delhi', N'Home', N'India', 1)
GO
INSERT [dbo].[EmployeesAddresses] ([Id], [City], [AddressType], [Country], [EmployeeId]) VALUES (2, N'Noida', N'Office', N'India', 1)
GO
SET IDENTITY_INSERT [dbo].[EmployeesAddresses] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230107055150_Init', N'7.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230402060714_Init', N'7.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230402065234_TblEmpandAdd', N'7.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230409070134_AddtblContext', N'7.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230422100333_TblLinqUser', N'7.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230608123725_CascadeDropReady', N'7.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230613161202_AddJqStudent', N'7.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230613161409_AddJqStudent', N'7.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230723132254_VrggrlTask', N'7.0.4')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (1, N'New Summer', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (2, N'New Winter', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (3, N'New Dresses', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (4, N'New Tops', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (5, N'New Skirts', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (6, N'New Pants', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (7, N'New Accessories', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (8, N'Tees', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (9, N'Camis/Tanks', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (10, N'Knit Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (11, N'Tie Front Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (12, N'Strapless Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (13, N'Long Sleeve Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (14, N'Jumpers / Sweaters', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (15, N'Bandanas', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (16, N'Vests', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (17, N'Corsets/Bustiers', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (18, N'Mini Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (19, N'Midi Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (20, N'Maxi Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (21, N'Knit Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (22, N'Formal Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (23, N'Skirts +', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (24, N'Playsuits / Jumpsuits', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (25, N'Pants', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (26, N'Jeans', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (27, N'Shorts', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (28, N'Sets', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (29, N'Jumpers/Sweaters', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (30, N'Jackets', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (31, N'Knitwear +', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (32, N'Swim', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (33, N'Shop by Collection', 7)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (34, N'Shop by Occasion', 7)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (35, N'Home', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (36, N'Jewellery  +', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (37, N'Hair Accessories +', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (38, N'Shoes +', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (39, N'Bags', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (40, N'Sale Tops', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (41, N'Sale Dresses / Playsuits', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (42, N'Sale Accessories', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (43, N'Sale Bottoms', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (44, N'Sale Outerwear', 9)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Contexts] ON 
GO
INSERT [dbo].[Contexts] ([Id], [Name], [Enrolled]) VALUES (1, N'Prince', CAST(N'2023-04-09T12:42:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Contexts] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
GO
INSERT [dbo].[Countries] ([Cid], [CName]) VALUES (1, N'India')
GO
INSERT [dbo].[Countries] ([Cid], [CName]) VALUES (2, N'Shrilanka')
GO
INSERT [dbo].[Countries] ([Cid], [CName]) VALUES (3, N'Usa')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 
GO
INSERT [dbo].[Images] ([Id], [ImagePath]) VALUES (2, N'0df7d3f3-759d-4073-b039-ef92272e3cff-Atta.jpg')
GO
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[JqStudents] ON 
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (1, N'Gulshan')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (2, N'Ankit')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (3, N'Sahil')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (4, N'Tarun')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (5, N'Pankaj')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (6, N'Akash')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (7, N'Rishabh')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (8, N'Tarun')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (9, N'Shushil')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (10, N'Ronish')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (11, N'Pankaj')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (12, N'Arun')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (13, N'Varun')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (14, N'Manish')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (15, N'Kunal')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (16, N'Aradhya')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (17, N'Pooja')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (18, N'Vimla')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (19, N'Nirmala')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (20, N'Akansh')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (21, N'Tanya')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (22, N'Anamika')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (23, N'Dolly')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (24, N'Aman')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (25, N'Anchal')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (26, N'Vikas')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (27, N'Suraj')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (28, N'Gagan')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (29, N'Sonu')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (30, N'Laxman')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (31, N'Ram')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (32, N'Shyam')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (33, N'Shivani')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (34, N'Poonam')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (35, N'Farah')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (36, N'Janvi')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (37, N'Kajal')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (38, N'Monika')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (39, N'Vicky')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (40, N'Ankit')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (41, N'Sohal')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (42, N'Virat')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (43, N'Fatima')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (44, N'Sharukh')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (45, N'Gori')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (46, N'Arnav')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (47, N'Trivani')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (48, N'Koshliya')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (49, N'Radhika')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (50, N'Khushbu')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (51, N'Sonu')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (52, N'Monu')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (53, N'Mridul')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (54, N'Uday')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (55, N'Bhavna')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (56, N'Ishant')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (57, N'OmPrakah')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (58, N'Sagar')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (59, N'Sidharth')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (60, N'Abhishek')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (61, N'Sumit')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (62, N'Ranveer')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (63, N'Tanu')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (64, N'Manu')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (65, N'Gourav')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (66, N'Sourabh')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (67, N'Irfan')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (68, N'Kamal')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (69, N'Zafran')
GO
INSERT [dbo].[JqStudents] ([Sid], [Sname]) VALUES (70, N'Bhola')
GO
SET IDENTITY_INSERT [dbo].[JqStudents] OFF
GO
SET IDENTITY_INSERT [dbo].[LinqUser] ON 
GO
INSERT [dbo].[LinqUser] ([Id], [Name]) VALUES (1, N'Gulshan')
GO
INSERT [dbo].[LinqUser] ([Id], [Name]) VALUES (2, N'Sumit')
GO
INSERT [dbo].[LinqUser] ([Id], [Name]) VALUES (3, N'Pankaj')
GO
INSERT [dbo].[LinqUser] ([Id], [Name]) VALUES (4, N'Sunil')
GO
INSERT [dbo].[LinqUser] ([Id], [Name]) VALUES (5, N'Radhika')
GO
SET IDENTITY_INSERT [dbo].[LinqUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (1, N'New')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (2, N'Most Loved')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (3, N'Tops')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (4, N'Dresses')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (5, N'Clothing')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (6, N'Back In Stock')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (7, N'Shop By')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (8, N'Accessories')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (9, N'Sale')
GO
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
INSERT [dbo].[Questions] ([QuestionsId], [Question1], [Question2], [Question3], [Car1Q], [Car2Q], [Bike1Q], [Bike2Q], [radio], [Car], [Bike]) VALUES (1, N'ABC', N'ABC', N'ABC', N'ABC', N'ABC', N'ABC', N'ABC', 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[States] ON 
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (1, 1, N'Delhi')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (2, 1, N'UP')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (3, 1, N'Bihar')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (4, 2, N'Colombo')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (5, 2, N'Gampaha')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (6, 2, N'Kalutara')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (7, 3, N'California')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (8, 3, N'Texas')
GO
INSERT [dbo].[States] ([Sid], [Cid], [SName]) VALUES (9, 3, N'Floriada')
GO
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (1, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (2, N'Ankit', 25)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (3, N'Sahil', 21)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (4, N'Tarun', 23)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (5, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (6, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (7, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (8, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (9, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (10, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (11, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (12, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (13, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (14, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (15, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (16, N'Ankit', 25)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (17, N'Sahil', 21)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (18, N'Tarun', 23)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (19, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (20, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (21, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (22, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (23, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (24, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (25, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (26, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (27, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (28, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (29, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (30, N'Ankit', 25)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (31, N'Sahil', 21)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (32, N'Tarun', 23)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (33, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (34, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (35, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (36, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (37, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (38, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (39, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (40, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (41, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (42, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (43, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (44, N'Ankit', 25)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (45, N'Sahil', 21)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (46, N'Tarun', 23)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (47, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (48, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (49, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (50, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (51, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (52, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (53, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (54, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (55, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (56, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (57, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (58, N'Ankit', 25)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (59, N'Sahil', 21)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (60, N'Tarun', 23)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (61, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (62, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (63, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (64, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (65, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (66, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (67, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (68, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (69, N'Gulshan', 27)
GO
INSERT [dbo].[Student] ([Sid], [Sname], [Age]) VALUES (70, N'Gulshan', 27)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategories] ON 
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (1, N'Wedding Guest Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (2, N'Vintage Inspired', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (3, N'Party Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (4, N'Festival Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (5, N'White Party', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (6, N'Linen Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (7, N'Summer Vacation Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (8, N'WorkWear Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (9, N'Denim Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (10, N'Take The Style Quiz', 34, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (11, N'Vintage Cool Girl', 34, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (12, N'Modern Music', 34, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (13, N'Everyday It Girl', 34, 7)
GO
SET IDENTITY_INSERT [dbo].[SubCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 
GO
INSERT [dbo].[Teachers] ([Id], [Country], [State]) VALUES (20, 1, 2)
GO
INSERT [dbo].[Teachers] ([Id], [Country], [State]) VALUES (21, 2, 4)
GO
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230107055150_Init', N'7.0.1')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (1, N'New Summer', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (2, N'New Winter', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (3, N'New Dresses', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (4, N'New Tops', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (5, N'New Skirts', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (6, N'New Pants', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (7, N'New Accessories', 1)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (8, N'Tees', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (9, N'Camis/Tanks', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (10, N'Knit Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (11, N'Tie Front Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (12, N'Strapless Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (13, N'Long Sleeve Tops', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (14, N'Jumpers / Sweaters', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (15, N'Bandanas', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (16, N'Vests', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (17, N'Corsets/Bustiers', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (18, N'Mini Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (19, N'Midi Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (20, N'Maxi Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (21, N'Knit Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (22, N'Formal Dresses', 4)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (23, N'Skirts +', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (24, N'Playsuits / Jumpsuits', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (25, N'Pants', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (26, N'Jeans', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (27, N'Shorts', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (28, N'Sets', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (29, N'Jumpers/Sweaters', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (30, N'Jackets', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (31, N'Knitwear +', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (32, N'Swim', 5)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (33, N'Shop by Collection', 7)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (34, N'Shop by Occasion', 7)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (35, N'Home', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (36, N'Jewellery  +', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (37, N'Hair Accessories +', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (38, N'Shoes +', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (39, N'Bags', 8)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (40, N'Sale Tops', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (41, N'Sale Dresses / Playsuits', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (42, N'Sale Accessories', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (43, N'Sale Bottoms', 9)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [MenuId]) VALUES (44, N'Sale Outerwear', 9)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (1, N'New')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (2, N'Most Loved')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (3, N'Tops')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (4, N'Dresses')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (5, N'Clothing')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (6, N'Back In Stock')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (7, N'Shop By')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (8, N'Accessories')
GO
INSERT [dbo].[Menus] ([MenuId], [MenuName]) VALUES (9, N'Sale')
GO
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [MenuId], [CategoryId], [SubCategoryId], [ProductName], [ProductImage], [ProductPrice], [ProductQuantity], [ProductSize], [ProductColor], [ProductDescription]) VALUES (1, 0, 0, 0, N'Demo', NULL, 600, 1, N'25px', N'Red', N'Good')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategories] ON 
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (1, N'Wedding Guest Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (2, N'Vintage Inspired', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (3, N'Party Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (4, N'Festival Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (5, N'White Party', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (6, N'Linen Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (7, N'Summer Vacation Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (8, N'WorkWear Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (9, N'Denim Edit', 33, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (10, N'Take The Style Quiz', 34, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (11, N'Vintage Cool Girl', 34, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (12, N'Modern Music', 34, 7)
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [SubCategoryName], [CategoryId], [MenuId]) VALUES (13, N'Everyday It Girl', 34, 7)
GO
SET IDENTITY_INSERT [dbo].[SubCategories] OFF
GO
