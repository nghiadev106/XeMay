USE [XeMay]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/10/2022 1:33:48 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriesNew]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriesNew](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ShowHome] [bit] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_CategoriesNew] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ParentId] [bigint] NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [nvarchar](500) NULL,
	[DisplayOrder] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ShowHome] [bit] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [bigint] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Phone] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[Content] [text] NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[CategoryId] [bigint] NULL,
	[Logo] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[IsNew] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[EditDate] [datetime] NULL,
	[Url] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderName] [nvarchar](500) NOT NULL,
	[OrderAddress] [nvarchar](500) NOT NULL,
	[OrderEmail] [nvarchar](500) NULL,
	[OrderPhone] [int] NOT NULL,
	[OrderNote] [nvarchar](500) NULL,
	[TotalMoney] [decimal](18, 0) NULL,
	[PaymentStatus] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NULL,
	[Path] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[CategoryId] [bigint] NULL,
	[Logo] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[Price] [decimal](18, 0) NULL,
	[PriceDiscount] [decimal](18, 0) NULL,
	[IsNew] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[EditDate] [datetime] NULL,
	[Url] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Status] [int] NULL,
	[Engine] [int] NULL,
	[Year] [int] NULL,
	[BrandId] [bigint] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slides]    Script Date: 6/10/2022 1:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slides](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Logo] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
	[Status] [int] NULL,
	[DisplayOrder] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Slides] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'630a4bea-2ceb-46ab-b26d-0854287bf13c', N'admin', N'ADMIN', N'admin@gmail.com', N'admin@gmail.com', 1, N'AQAAAAEAACcQAAAAEDVVxU5cqemmkrHx2w7DXR3pSfWcVsm9I0MO+ykCl7NAcXhhfP7Hl5wgaTkSJP85uA==', N'UQUDWAPTGCCH6GAA3ZT6CXR4RKDQA6BX', N'74342c66-d5f1-4ad7-b80c-1df22c2d1c9f', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [Description], [Url], [CreateDate], [Status]) VALUES (1, N'Honda', N'Honda', N'honda', CAST(N'2022-06-10T10:27:24.820' AS DateTime), 1)
INSERT [dbo].[Brand] ([Id], [Name], [Description], [Url], [CreateDate], [Status]) VALUES (2, N'Yamaha', N'Yamaha', N'yamaha', CAST(N'2022-06-10T10:27:42.493' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoriesNew] ON 

INSERT [dbo].[CategoriesNew] ([Id], [Name], [Description], [Url], [DisplayOrder], [CreateDate], [ShowHome], [Status]) VALUES (1, N'tin mới', N'ko', N'tin-moi', 1, CAST(N'2022-04-14T00:44:12.873' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[CategoriesNew] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [ParentId], [Description], [Url], [DisplayOrder], [CreateDate], [ShowHome], [Status]) VALUES (1, N'Samsung', NULL, N'Ti vi', N'samsung', 2, CAST(N'2022-04-13T21:40:05.777' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([Id], [Name], [ParentId], [Description], [Url], [DisplayOrder], [CreateDate], [ShowHome], [Status]) VALUES (2, N'Sony', NULL, N'Sony', N'sony', 3, CAST(N'2022-04-13T21:40:25.897' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([Id], [Name], [ParentId], [Description], [Url], [DisplayOrder], [CreateDate], [ShowHome], [Status]) VALUES (3, N'Lg', NULL, N'Lg', N'lg', 1, CAST(N'2022-04-20T00:41:18.847' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([Id], [Name], [ParentId], [Description], [Url], [DisplayOrder], [CreateDate], [ShowHome], [Status]) VALUES (4, N'Sharp', NULL, N'Sharp', N'sharp', 4, CAST(N'2022-04-20T00:42:12.893' AS DateTime), 1, 1)
INSERT [dbo].[Category] ([Id], [Name], [ParentId], [Description], [Url], [DisplayOrder], [CreateDate], [ShowHome], [Status]) VALUES (5, N'Panasonic', NULL, N'Panasonic', N'panasonic', 5, CAST(N'2022-04-20T00:42:32.017' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [Name], [CategoryId], [Logo], [Description], [Detail], [IsNew], [CreateDate], [EditDate], [Url], [DisplayOrder], [Status]) VALUES (1, N'Mạnh Mẽ & Cuốn Hút với đồng hồ mặt rắn L’Duchen Silver Snake', 1, N'/uploads/b8123772-beed-4cfc-824a-fcb4b5bbeb9c.jpg', N'Thương hiệu đồng hồ Thụy Sỹ L’Duchen đã mở rộng bộ sưu tập Art Collection của mình với mẫu đồng hồ mặt rắn – L’Duchen Silver snake mã hiệu D 161.11.23 dây da cao cấp phiên bản giới hạn.', N'<p><span style="font-weight: bolder; color: rgb(0, 0, 0); font-family: Quicksand, sans-serif; font-size: 16px;"><em>Thương hiệu đồng hồ Thụy Sỹ L’Duchen đã mở rộng bộ sưu tập Art Collection của mình với mẫu đồng hồ mặt rắn – L’Duchen Silver snake mã hiệu D 161.11.23 dây da cao cấp phiên bản giới hạn.</em></span><br></p>', 1, CAST(N'2022-04-14T00:46:03.617' AS DateTime), CAST(N'2022-06-05T23:29:49.157' AS DateTime), N'manh-me-cuon-hut-voi-dong-ho-mat-ran-l’duchen-silver-snake', 1, 1)
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [OrderName], [OrderAddress], [OrderEmail], [OrderPhone], [OrderNote], [TotalMoney], [PaymentStatus], [CreatedDate]) VALUES (1, N'nghia', N'hưng Yên', N'nghgh@gmail.com', 797979766, N'koo', CAST(2099997 AS Decimal(18, 0)), 0, CAST(N'2023-05-18T19:28:31.240' AS DateTime))
INSERT [dbo].[Order] ([Id], [OrderName], [OrderAddress], [OrderEmail], [OrderPhone], [OrderNote], [TotalMoney], [PaymentStatus], [CreatedDate]) VALUES (2, N'nghia', N'hưng Yên', N'nghgh@gmail.com', 797979766, N'koo', CAST(2099997 AS Decimal(18, 0)), 0, CAST(N'2022-04-17T19:30:08.773' AS DateTime))
INSERT [dbo].[Order] ([Id], [OrderName], [OrderAddress], [OrderEmail], [OrderPhone], [OrderNote], [TotalMoney], [PaymentStatus], [CreatedDate]) VALUES (3, N'nghia', N'hưng Yên', N'nghgh@gmail.com', 797979766, N'koo', CAST(2099997 AS Decimal(18, 0)), 0, CAST(N'2022-04-18T19:30:26.077' AS DateTime))
INSERT [dbo].[Order] ([Id], [OrderName], [OrderAddress], [OrderEmail], [OrderPhone], [OrderNote], [TotalMoney], [PaymentStatus], [CreatedDate]) VALUES (4, N'nghia', N'09999', NULL, 797979766, NULL, CAST(699999 AS Decimal(18, 0)), 0, CAST(N'2022-04-20T00:15:06.820' AS DateTime))
INSERT [dbo].[Order] ([Id], [OrderName], [OrderAddress], [OrderEmail], [OrderPhone], [OrderNote], [TotalMoney], [PaymentStatus], [CreatedDate]) VALUES (5, N'Đỗ Văn Nghĩa', N'11111', N'nghia123@gmail.com', 12211111, N'koooo', CAST(1589999 AS Decimal(18, 0)), 0, CAST(N'2023-04-20T23:40:27.497' AS DateTime))
INSERT [dbo].[Order] ([Id], [OrderName], [OrderAddress], [OrderEmail], [OrderPhone], [OrderNote], [TotalMoney], [PaymentStatus], [CreatedDate]) VALUES (6, N'qqqqqqq', N'ddddd', N'test23@gmail.com', 0, N'koo', CAST(6999999 AS Decimal(18, 0)), 0, CAST(N'2022-06-05T10:14:59.517' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedDate]) VALUES (1, 1, 2, CAST(699999 AS Decimal(18, 0)), 3, CAST(N'2022-04-18T19:28:31.650' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedDate]) VALUES (2, 2, 2, CAST(699999 AS Decimal(18, 0)), 3, CAST(N'2022-04-18T19:30:08.843' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedDate]) VALUES (3, 3, 2, CAST(699999 AS Decimal(18, 0)), 3, CAST(N'2022-04-18T19:30:36.903' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedDate]) VALUES (4, 4, 3, CAST(699999 AS Decimal(18, 0)), 1, CAST(N'2022-04-20T00:15:07.283' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedDate]) VALUES (5, 5, 2, CAST(699999 AS Decimal(18, 0)), 1, CAST(N'2022-04-20T23:40:27.493' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedDate]) VALUES (6, 5, 4, CAST(890000 AS Decimal(18, 0)), 1, CAST(N'2022-04-20T23:40:27.493' AS DateTime))
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedDate]) VALUES (7, 6, 2, CAST(6999999 AS Decimal(18, 0)), 1, CAST(N'2022-06-05T10:14:59.513' AS DateTime))
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (23, 4, N'/uploads/11af8d89-2559-4172-953a-14d28f5922da.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (24, 4, N'/uploads/ca650292-a8e8-4613-ba1e-e9cc38134271.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (25, 4, N'/uploads/2e138ddb-37da-42b9-9108-aeab97b22517.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (26, 3, N'/uploads/abfd9046-459d-4595-8f03-bd4eacc7a692.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (27, 3, N'/uploads/4ea19e9d-26f1-4406-a436-dbe761c5876a.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (28, 2, N'/uploads/c4e7ed3d-15ae-41b1-bd48-87fb687c1787.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (29, 2, N'/uploads/4be6e5be-1a58-40d1-994c-310ffa5be296.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (30, 1, N'/uploads/7e4a7ecb-a5e6-4d03-b631-0ab38a431561.jpg')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path]) VALUES (31, 1, N'/uploads/adeb27c5-f2fd-434d-a0ec-a4cdff221726.jpg')
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [CategoryId], [Logo], [Description], [Detail], [Price], [PriceDiscount], [IsNew], [CreateDate], [EditDate], [Url], [DisplayOrder], [Status], [Engine], [Year], [BrandId]) VALUES (1, N'Google Tivi Sony 4K 65 inch XR-65X90J VN3', 3, N'/uploads/e89f8016-c681-4b48-a507-54f4a17348c1.jpg', N'Google Tivi Sony 4K 65 inch XR-65X90J VN3', N'<h2 style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; font-size: 16px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: Roboto, sans-serif; vertical-align: baseline; color: rgb(63, 63, 63);">Đặc điểm nổi bật</h2><ul style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; font-size: 16px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; font-family: Roboto, sans-serif; vertical-align: baseline; list-style: none; width: 620px; display: flex; flex-wrap: wrap; color: rgb(0, 0, 0);"><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Google Tivi Sony có độ phân giải 4K sắc nét gấp 4 lần so với TV Full HD</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Công nghệ đèn nền Full Array LED, Local Dimming tái hiện hình ảnh chân thực</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Công nghệ XR 4K Upscaling tự động nâng cấp hình ảnh lên 4K sắc nét, chi tiết</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Công nghệ tương phản XR Contrast Booster 5 cho hình ảnh sống động như thật</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);"><a href="https://www.nguyenkim.com/nhung-tinh-nang-noi-bat-cua-tivi-sony-the-he-moi.html#cong-nghe-xr-triluminos-pro-la-gi" target="_blank" rel="noopener noreferrer" title="Công nghệ XR Triluminos PRO" style="margin: 0px; padding: 0px; border-width: 0px 0px 2px; border-top-style: initial; border-right-style: initial; border-bottom-style: dashed; border-left-style: initial; border-bottom-color: rgb(26, 126, 255); border-image: initial; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline; transition: all 0.2s ease 0s; color: rgb(26, 126, 255); border-top-color: rgb(237, 51, 36) !important; border-right-color: rgb(237, 51, 36) !important; border-left-color: rgb(237, 51, 36) !important;">Công nghệ XR Triluminos PRO</a>&nbsp;mở rộng hàng tỷ màu sắc, tăng cường độ bão hòa</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Trải nghiệm âm thanh đắm chìm nhờ Âm thanh từ màn hình Acoustics Multi-Audio</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);"><a href="https://www.nguyenkim.com/nhung-tinh-nang-noi-bat-cua-tivi-sony-the-he-moi.html#cong-nghe-am-thanh-chan-thuc-song-dong-va-sac-sao" target="_blank" rel="noopener noreferrer" title="Công nghệ nâng cấp âm thanh vòm 3D" style="margin: 0px; padding: 0px; border-width: 0px 0px 2px; border-top-style: initial; border-right-style: initial; border-bottom-style: dashed; border-left-style: initial; border-bottom-color: rgb(26, 126, 255); border-image: initial; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline; transition: all 0.2s ease 0s; color: rgb(26, 126, 255); border-top-color: rgb(237, 51, 36) !important; border-right-color: rgb(237, 51, 36) !important; border-left-color: rgb(237, 51, 36) !important;">Công nghệ nâng cấp âm thanh vòm 3D</a>&nbsp;tái tạo âm thanh đa chiều, sống động</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Hệ điều hành Android 10 với các ứng dụng sẵn có: Youtube, Netflix, FPT Play, Clip TV,...</li></ul>', CAST(9000000 AS Decimal(18, 0)), CAST(7999999 AS Decimal(18, 0)), 1, CAST(N'2022-04-13T21:43:38.120' AS DateTime), CAST(N'2022-06-04T14:09:42.367' AS DateTime), N'google-tivi-sony-4k-65-inch-xr-65x90j-vn3', 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Products] ([Id], [Name], [CategoryId], [Logo], [Description], [Detail], [Price], [PriceDiscount], [IsNew], [CreateDate], [EditDate], [Url], [DisplayOrder], [Status], [Engine], [Year], [BrandId]) VALUES (2, N'Android Tivi Sony 4K 50 inch KD-50X75 VN3', 2, N'/uploads/490fa3fb-2cf1-41eb-b5d1-c4f9eb4ce19c.png', N'Android Tivi Sony 4K 50 inch KD-50X75 VN3', N'<h2 style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; font-size: 16px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: Roboto, sans-serif; vertical-align: baseline; color: rgb(63, 63, 63);">Đặc điểm nổi bật</h2><ul style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; font-size: 16px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; font-family: Roboto, sans-serif; vertical-align: baseline; list-style: none; width: 620px; display: flex; flex-wrap: wrap; color: rgb(0, 0, 0);"><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Tivi Sony có độ phân giải 4K hiển thị hình ảnh sắc nét gấp 4 lần Full HD</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Bộ xử lý X1 4K HDR Processor giảm nhiễu, nâng cao chất lượng hình ảnh</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Công nghệ Direct LED Frame Dimming&nbsp;tăng độ tương phản cho hình ảnh</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Hỗ trợ&nbsp;<a href="https://www.nguyenkim.com/tat-tan-tat-nhung-gi-ban-can-biet-ve-tivi-hdr-hdr10-va-hdr10.html" target="_blank" rel="noopener noreferrer" title="HDR10" style="margin: 0px; padding: 0px; border-width: 0px 0px 2px; border-top-style: initial; border-right-style: initial; border-bottom-style: dashed; border-left-style: initial; border-bottom-color: rgb(26, 126, 255); border-image: initial; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline; transition: all 0.2s ease 0s; color: rgb(26, 126, 255); border-top-color: rgb(237, 51, 36) !important; border-right-color: rgb(237, 51, 36) !important; border-left-color: rgb(237, 51, 36) !important;">HDR10</a>, HLG tăng chi tiết hình ảnh, sắc trắng tinh khiết, sắc đen sâu</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Công nghệ XR200, Auto mode cho hình ảnh chuyển động nhanh mượt mà</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Thưởng thức âm thanh vòm sống động với<a href="https://www.nguyenkim.com/cung-ban-tim-hieu-ve-cong-nghe-am-thanh-dolby-home-theater.html" style="margin: 0px; padding: 0px; border-width: 0px 0px 2px; border-top-style: initial; border-right-style: initial; border-bottom-style: dashed; border-left-style: initial; border-bottom-color: rgb(26, 126, 255); border-image: initial; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline; transition: all 0.2s ease 0s; color: rgb(26, 126, 255); border-top-color: rgb(237, 51, 36) !important; border-right-color: rgb(237, 51, 36) !important; border-left-color: rgb(237, 51, 36) !important;">&nbsp;công nghệ âm thanh Dolby Audio</a></li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Cho phép tùy chọn âm thanh theo nội dung xem phim, ca nhạc, bóng đá,...</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);"><a href="https://www.nguyenkim.com/phan-biet-internet-tv-android-tv-va-smart-tv.html" style="margin: 0px; padding: 0px; border-width: 0px 0px 2px; border-top-style: initial; border-right-style: initial; border-bottom-style: dashed; border-left-style: initial; border-bottom-color: rgb(26, 126, 255); border-image: initial; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: inherit; vertical-align: baseline; transition: all 0.2s ease 0s; color: rgb(26, 126, 255); border-top-color: rgb(237, 51, 36) !important; border-right-color: rgb(237, 51, 36) !important; border-left-color: rgb(237, 51, 36) !important;">Android Tivi&nbsp;</a>sở hữu hệ điều hành Android 10 với kho ứng dụng giải trí đa dạng</li></ul>', CAST(8999999 AS Decimal(18, 0)), CAST(6999999 AS Decimal(18, 0)), 1, CAST(N'2022-04-13T23:06:59.683' AS DateTime), CAST(N'2022-06-10T10:32:12.810' AS DateTime), N'android-tivi-sony-4k-50-inch-kd-50x75-vn3', 2, 1, 150, 2022, 2)
INSERT [dbo].[Products] ([Id], [Name], [CategoryId], [Logo], [Description], [Detail], [Price], [PriceDiscount], [IsNew], [CreateDate], [EditDate], [Url], [DisplayOrder], [Status], [Engine], [Year], [BrandId]) VALUES (3, N'Ti vi fjfjjf', 1, N'/uploads/49253dd6-6592-4a45-9b0c-ffbde9dfb0a4.jpg', N'Ti vi', N'<p>Đồng hồ Calvin Klein Nữ K4E2<br></p>', CAST(799999 AS Decimal(18, 0)), CAST(699999 AS Decimal(18, 0)), 1, CAST(N'2022-04-14T00:11:45.007' AS DateTime), CAST(N'2022-06-10T10:31:53.620' AS DateTime), N'ti-vi-fjfjjf', 3, 1, 155, 2020, 1)
INSERT [dbo].[Products] ([Id], [Name], [CategoryId], [Logo], [Description], [Detail], [Price], [PriceDiscount], [IsNew], [CreateDate], [EditDate], [Url], [DisplayOrder], [Status], [Engine], [Year], [BrandId]) VALUES (4, N'Exciter', 2, N'/uploads/8d3bfb69-2a58-4f79-adcd-a896eb196731.png', N'Exciter', N'<h2 style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; font-size: 16px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-weight: 700; font-stretch: inherit; line-height: inherit; font-family: Roboto, sans-serif; vertical-align: baseline; color: rgb(63, 63, 63);">Đặc điểm nổi bật</h2><ul style="margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding: 0px; font-size: 16px; border: 0px; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; font-family: Roboto, sans-serif; vertical-align: baseline; list-style: none; width: 620px; display: flex; flex-wrap: wrap; color: rgb(0, 0, 0);"><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Màn hình FullHD 43 inch cho hình ảnh sống động</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Công nghệ hình ảnh HDR nâng cao độ tương phản</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Hệ điều hành Android 8.0 trang bị nhiều ứng dụng</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Chiếu nội dung từ di động qua tính năng Screen Mirroring</li><li class="short-descr-col-1" style="margin: 0px 0px 10px 20px; padding: 0px; font-size: 14px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; line-height: 1.5em; font-family: inherit; vertical-align: baseline; width: calc(100% - 20px); text-indent: -10px; color: rgb(63, 63, 63);">Điều khiển giọng nói thông minh&nbsp;dễ dàng cho việc tìm kiếm</li></ul>', CAST(9900000 AS Decimal(18, 0)), CAST(9000000 AS Decimal(18, 0)), 1, CAST(N'2022-04-20T00:46:18.333' AS DateTime), CAST(N'2022-06-10T10:31:40.793' AS DateTime), N'exciter', 11, 1, 150, 2019, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Slides] ON 

INSERT [dbo].[Slides] ([Id], [Name], [Logo], [Link], [Status], [DisplayOrder], [CreateDate]) VALUES (1, N'slide 2', N'/uploads/1aa35f93-dddd-4663-a164-0e190dc9ccf4.png', N'kkkkk', 1, 1, CAST(N'2021-09-07T16:31:05.600' AS DateTime))
INSERT [dbo].[Slides] ([Id], [Name], [Logo], [Link], [Status], [DisplayOrder], [CreateDate]) VALUES (2, N'slide 2', N'/uploads/cd4b80f3-2d80-462e-92e2-11e64e5659f2.png', N'kkkkk', 1, 2, CAST(N'2021-09-07T16:33:44.903' AS DateTime))
INSERT [dbo].[Slides] ([Id], [Name], [Logo], [Link], [Status], [DisplayOrder], [CreateDate]) VALUES (4, N'slide 3', N'/uploads/5765135d-8be4-40ce-9cba-7c57f259dbae.png', N'slide 3', 1, NULL, CAST(N'2022-06-04T14:17:14.207' AS DateTime))
SET IDENTITY_INSERT [dbo].[Slides] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_CategoriesNew] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CategoriesNew] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_CategoriesNew]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Products]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brand]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category]
GO
