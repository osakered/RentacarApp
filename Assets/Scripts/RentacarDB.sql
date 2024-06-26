USE [RentacarDB]
GO
/****** Object:  Table [dbo].[Actions]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actions](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[ActionType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Availability]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Availability](
	[IDAvailability] [int] IDENTITY(1,1) NOT NULL,
	[AvailabilityState] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Availability] PRIMARY KEY CLUSTERED 
(
	[IDAvailability] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[IDCars] [int] IDENTITY(1,1) NOT NULL,
	[CarModel] [nvarchar](100) NOT NULL,
	[CarProdYear] [date] NOT NULL,
	[CarColor] [nvarchar](50) NOT NULL,
	[RegNumber] [nchar](10) NOT NULL,
	[IDAvailability] [int] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[IDCars] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[IDClients] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[PassportData] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[DLicenseNumber] [nchar](10) NOT NULL,
	[PhoneNumber] [text] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[IDClients] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[IDUsers] [int] NOT NULL,
	[LogTime] [datetime] NOT NULL,
	[ActionID] [int] NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rental]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rental](
	[IDRent] [int] IDENTITY(1,1) NOT NULL,
	[IDClients] [int] NOT NULL,
	[IDCars] [int] NOT NULL,
	[Cost] [money] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
 CONSTRAINT [PK_Rental] PRIMARY KEY CLUSTERED 
(
	[IDRent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IDRole] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IDRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Upkeep]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Upkeep](
	[IDUpkeep] [int] IDENTITY(1,1) NOT NULL,
	[IDCars] [int] NOT NULL,
	[BeginUpkeepDate] [date] NOT NULL,
	[EndUpkeepDate] [date] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Upkeep] PRIMARY KEY CLUSTERED 
(
	[IDUpkeep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27.05.2024 19:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IDUsers] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IDRole] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IDUsers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actions] ON 

INSERT [dbo].[Actions] ([ActionID], [ActionType]) VALUES (1, N'Добавление')
INSERT [dbo].[Actions] ([ActionID], [ActionType]) VALUES (2, N'Редактирование')
INSERT [dbo].[Actions] ([ActionID], [ActionType]) VALUES (3, N'Удаление')
SET IDENTITY_INSERT [dbo].[Actions] OFF
GO
SET IDENTITY_INSERT [dbo].[Availability] ON 

INSERT [dbo].[Availability] ([IDAvailability], [AvailabilityState]) VALUES (1, N'Недоступна')
INSERT [dbo].[Availability] ([IDAvailability], [AvailabilityState]) VALUES (2, N'Доступна')
SET IDENTITY_INSERT [dbo].[Availability] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (1, N'Mazda RX-7', CAST(N'2001-01-04' AS Date), N'Желтый', N'А321ТХ-56 ', 2)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (2, N'Honda Civic', CAST(N'2007-06-03' AS Date), N'Красный', N'Е456ВС-32 ', 1)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (3, N'Daewoo Matiz', CAST(N'2009-05-04' AS Date), N'Зеленый', N'А752НР-54 ', 1)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (4, N'Hyundai Solaris', CAST(N'2012-07-10' AS Date), N'Серый', N'К758МТ-13 ', 2)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (5, N'Lada Vesta', CAST(N'2018-06-30' AS Date), N'Голубой', N'Т453АК-43 ', 2)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (6, N'Nissan Silvia', CAST(N'2002-01-02' AS Date), N'Синий', N'М335ОР-40 ', 1)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (7, N'McLaren F1', CAST(N'1997-06-10' AS Date), N'Оранжевый', N'М290АК-01 ', 2)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (8, N'Lotus Elise', CAST(N'1996-10-08' AS Date), N'Желтый', N'Х496АВ-53 ', 1)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (9, N'Lada Vesta', CAST(N'1985-05-05' AS Date), N'Черный', N'Е308МВ-12 ', 2)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (10, N'Zeekr 001', CAST(N'2022-09-07' AS Date), N'Оранжевый', N'Т030УХ-79 ', 2)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (11, N'Haval F7', CAST(N'2018-06-23' AS Date), N'Коричневый', N'О777ВН-78 ', 1)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (12, N'Москвич 3', CAST(N'2024-03-08' AS Date), N'Белый', N'М003КТ-32 ', 1)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (13, N'BMW M5', CAST(N'2021-10-16' AS Date), N'Синий', N'А543КТ-43 ', 2)
INSERT [dbo].[Cars] ([IDCars], [CarModel], [CarProdYear], [CarColor], [RegNumber], [IDAvailability]) VALUES (14, N'Ford Mustang', CAST(N'2024-05-27' AS Date), N'Зеленый', N'Т543АК-32 ', 1)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([IDClients], [Address], [PassportData], [FullName], [DLicenseNumber], [PhoneNumber]) VALUES (1, N'Екатеринбург, ул. Фурманова, д. 35, кв. 3', N'4530 993480', N'Харитонов Борис Александрович', N'435323-24 ', N'88005553535')
INSERT [dbo].[Clients] ([IDClients], [Address], [PassportData], [FullName], [DLicenseNumber], [PhoneNumber]) VALUES (2, N'Самара, ул. Персиковая, д. 85', N'2754 884145', N'Сухачев Денис Владимирович', N'228335-10 ', N'+79094321654')
INSERT [dbo].[Clients] ([IDClients], [Address], [PassportData], [FullName], [DLicenseNumber], [PhoneNumber]) VALUES (3, N'Красногорск, ул. Речная, д. 8, кв. 15', N'4664 453987', N'Удачев Алан Викторович', N'423421-16 ', N'+79096547452')
INSERT [dbo].[Clients] ([IDClients], [Address], [PassportData], [FullName], [DLicenseNumber], [PhoneNumber]) VALUES (4, N'Владимир, ул. Мира, д. 32Б, кв. 49', N'3421 234325', N'Захаров Сергей Андреевич', N'324211-20 ', N'+79095436437')
INSERT [dbo].[Clients] ([IDClients], [Address], [PassportData], [FullName], [DLicenseNumber], [PhoneNumber]) VALUES (5, N'Саратов, ул. Бахметьевская, д. 10, кв. 3', N'4444 334671', N'Иванов Иван Иванович', N'342413-18 ', N'+79091312543')
INSERT [dbo].[Clients] ([IDClients], [Address], [PassportData], [FullName], [DLicenseNumber], [PhoneNumber]) VALUES (6, N'Геленджик, ул. Ленина, д. 34, кв. 1', N'1848 954821', N'Макаров Макар Макарович', N'876345-22 ', N'+79087623654')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([LogID], [IDUsers], [LogTime], [ActionID], [TableName]) VALUES (1, 2, CAST(N'2023-04-12T22:22:22.000' AS DateTime), 2, N'Пользователи')
INSERT [dbo].[Logs] ([LogID], [IDUsers], [LogTime], [ActionID], [TableName]) VALUES (2, 1, CAST(N'2024-01-01T00:00:01.000' AS DateTime), 1, N'Аренда')
INSERT [dbo].[Logs] ([LogID], [IDUsers], [LogTime], [ActionID], [TableName]) VALUES (3, 3, CAST(N'2024-04-12T15:43:12.000' AS DateTime), 3, N'Автомобили')
INSERT [dbo].[Logs] ([LogID], [IDUsers], [LogTime], [ActionID], [TableName]) VALUES (4, 1, CAST(N'2024-05-10T11:13:54.000' AS DateTime), 2, N'Обслуживание')
INSERT [dbo].[Logs] ([LogID], [IDUsers], [LogTime], [ActionID], [TableName]) VALUES (5, 3, CAST(N'2024-05-24T15:53:23.000' AS DateTime), 2, N'Обслуживание')
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Rental] ON 

INSERT [dbo].[Rental] ([IDRent], [IDClients], [IDCars], [Cost], [DateStart], [DateEnd]) VALUES (1, 1, 2, 720000.0000, CAST(N'2021-04-04' AS Date), CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Rental] ([IDRent], [IDClients], [IDCars], [Cost], [DateStart], [DateEnd]) VALUES (2, 2, 3, 50000.0000, CAST(N'2024-01-08' AS Date), CAST(N'2024-06-05' AS Date))
INSERT [dbo].[Rental] ([IDRent], [IDClients], [IDCars], [Cost], [DateStart], [DateEnd]) VALUES (3, 3, 6, 150000.0000, CAST(N'2023-09-09' AS Date), CAST(N'2024-07-01' AS Date))
INSERT [dbo].[Rental] ([IDRent], [IDClients], [IDCars], [Cost], [DateStart], [DateEnd]) VALUES (4, 4, 8, 30000.0000, CAST(N'2024-03-20' AS Date), CAST(N'2024-04-29' AS Date))
INSERT [dbo].[Rental] ([IDRent], [IDClients], [IDCars], [Cost], [DateStart], [DateEnd]) VALUES (5, 5, 11, 6000.0000, CAST(N'2024-03-20' AS Date), CAST(N'2024-03-23' AS Date))
INSERT [dbo].[Rental] ([IDRent], [IDClients], [IDCars], [Cost], [DateStart], [DateEnd]) VALUES (6, 6, 12, 7500.0000, CAST(N'2024-03-15' AS Date), CAST(N'2024-03-30' AS Date))
SET IDENTITY_INSERT [dbo].[Rental] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IDRole], [RoleName]) VALUES (1, N'Директор')
INSERT [dbo].[Roles] ([IDRole], [RoleName]) VALUES (2, N'Сисадмин')
INSERT [dbo].[Roles] ([IDRole], [RoleName]) VALUES (3, N'Менеджер')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Upkeep] ON 

INSERT [dbo].[Upkeep] ([IDUpkeep], [IDCars], [BeginUpkeepDate], [EndUpkeepDate], [Price]) VALUES (1, 12, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), 25000.0000)
INSERT [dbo].[Upkeep] ([IDUpkeep], [IDCars], [BeginUpkeepDate], [EndUpkeepDate], [Price]) VALUES (2, 2, CAST(N'2022-04-06' AS Date), CAST(N'2024-02-02' AS Date), 100000.0000)
INSERT [dbo].[Upkeep] ([IDUpkeep], [IDCars], [BeginUpkeepDate], [EndUpkeepDate], [Price]) VALUES (3, 9, CAST(N'2020-06-06' AS Date), CAST(N'2021-06-07' AS Date), 55000.0000)
SET IDENTITY_INSERT [dbo].[Upkeep] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([IDUsers], [Username], [Password], [IDRole]) VALUES (1, N'root', N'root', 2)
INSERT [dbo].[Users] ([IDUsers], [Username], [Password], [IDRole]) VALUES (2, N'Manager', N'Manager', 1)
INSERT [dbo].[Users] ([IDUsers], [Username], [Password], [IDRole]) VALUES (3, N'Director', N'Director', 3)
INSERT [dbo].[Users] ([IDUsers], [Username], [Password], [IDRole]) VALUES (4, N'123', N'123', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Availability] FOREIGN KEY([IDAvailability])
REFERENCES [dbo].[Availability] ([IDAvailability])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Availability]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Actions] FOREIGN KEY([ActionID])
REFERENCES [dbo].[Actions] ([ActionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Actions]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Users] FOREIGN KEY([IDUsers])
REFERENCES [dbo].[Users] ([IDUsers])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Users]
GO
ALTER TABLE [dbo].[Rental]  WITH CHECK ADD  CONSTRAINT [FK_Rental_Cars] FOREIGN KEY([IDCars])
REFERENCES [dbo].[Cars] ([IDCars])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rental] CHECK CONSTRAINT [FK_Rental_Cars]
GO
ALTER TABLE [dbo].[Rental]  WITH CHECK ADD  CONSTRAINT [FK_Rental_Clients] FOREIGN KEY([IDClients])
REFERENCES [dbo].[Clients] ([IDClients])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rental] CHECK CONSTRAINT [FK_Rental_Clients]
GO
ALTER TABLE [dbo].[Upkeep]  WITH CHECK ADD  CONSTRAINT [FK_Upkeep_Cars] FOREIGN KEY([IDCars])
REFERENCES [dbo].[Cars] ([IDCars])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Upkeep] CHECK CONSTRAINT [FK_Upkeep_Cars]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Roles] ([IDRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
