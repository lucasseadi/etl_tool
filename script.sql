USE [master]
GO
/****** Object:  Database [ETLTool]    Script Date: 05/02/2022 18:26:15 ******/
CREATE DATABASE [ETLTool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ETLTool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ETLTool.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ETLTool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ETLTool_log.ldf' , SIZE = 204800KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ETLTool] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ETLTool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ETLTool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ETLTool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ETLTool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ETLTool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ETLTool] SET ARITHABORT OFF 
GO
ALTER DATABASE [ETLTool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ETLTool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ETLTool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ETLTool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ETLTool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ETLTool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ETLTool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ETLTool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ETLTool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ETLTool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ETLTool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ETLTool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ETLTool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ETLTool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ETLTool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ETLTool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ETLTool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ETLTool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ETLTool] SET  MULTI_USER 
GO
ALTER DATABASE [ETLTool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ETLTool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ETLTool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ETLTool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ETLTool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ETLTool] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ETLTool] SET QUERY_STORE = OFF
GO
USE [ETLTool]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[c_custkey] [int] NOT NULL,
	[c_name] [nvarchar](50) NOT NULL,
	[c_address] [nvarchar](50) NOT NULL,
	[c_nationkey] [int] NOT NULL,
	[c_phone] [nchar](15) NOT NULL,
	[c_acctbal] [decimal](10, 2) NOT NULL,
	[c_mktsegment] [nvarchar](50) NOT NULL,
	[c_comment] [nvarchar](max) NULL,
	[c_revenue] [decimal](20, 2),
	[c_quantity] [int],
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[c_custkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lineitem]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lineitem](
	[l_lineitemkey] [int] IDENTITY(1,1) NOT NULL,
	[l_id] [int] NOT NULL,
	[l_orderkey] [int] NOT NULL,
	[l_ps_id] [int] NOT NULL,
	[l_linenumber] [int] NOT NULL,
	[l_quantity] [int] NOT NULL,
	[l_extendedprice] [decimal](10, 2) NOT NULL,
	[l_discount] [float] NOT NULL,
	[l_tax] [float] NOT NULL,
	[l_returnflag] [nchar](1) NOT NULL,
	[l_linestatus] [nchar](1) NOT NULL,
	[l_shipdate] [date] NOT NULL,
	[l_commitdate] [date] NOT NULL,
	[l_receiptdate] [date] NOT NULL,
	[l_shipinstruct] [nvarchar](50) NULL,
	[l_shipmode] [nvarchar](50) NOT NULL,
	[l_comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lineitem_1] PRIMARY KEY CLUSTERED 
(
	[l_lineitemkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monthsales]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monthsales](
	[ms_month] [int] NOT NULL,
	[ms_year] [int] NOT NULL,
	[ms_sales] [int] NOT NULL,
 CONSTRAINT [PK_Monthsales] PRIMARY KEY CLUSTERED 
(
	[ms_month] ASC,
	[ms_year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nation]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nation](
	[n_nationkey] [int] NOT NULL,
	[n_name] [nvarchar](50) NOT NULL,
	[n_regionkey] [int] NOT NULL,
	[n_comment] [nvarchar](max) NULL,
	[n_income] [decimal](20, 2),
	[n_prefshipmode] [nchar](10),
 CONSTRAINT [PK_Nation] PRIMARY KEY CLUSTERED 
(
	[n_nationkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[o_orderkey] [int] NOT NULL,
	[o_custkey] [int] NOT NULL,
	[o_orderstatus] [nchar](1) NOT NULL,
	[o_totalprice] [decimal](10, 2) NOT NULL,
	[o_orderdate] [date] NOT NULL,
	[o_orderpriority] [nvarchar](50) NOT NULL,
	[o_cleark] [nvarchar](50) NOT NULL,
	[o_shippriority] [int] NOT NULL,
	[o_comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[o_orderkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Part]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Part](
	[p_partkey] [int] NOT NULL,
	[p_name] [nvarchar](50) NOT NULL,
	[p_mfgr] [nvarchar](50) NOT NULL,
	[p_brand] [nvarchar](50) NOT NULL,
	[p_type] [nvarchar](50) NOT NULL,
	[p_size] [int] NOT NULL,
	[p_container] [nvarchar](50) NOT NULL,
	[p_retailprice] [decimal](10, 2) NOT NULL,
	[p_comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED 
(
	[p_partkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partsupp]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partsupp](
	[ps_key] [int] IDENTITY(1,1) NOT NULL,
	[ps_id] [int] NOT NULL,
	[ps_partkey] [int] NOT NULL,
	[ps_suppkey] [int] NOT NULL,
	[ps_availqty] [int] NULL,
	[ps_supplycost] [decimal](10, 2) NOT NULL,
	[ps_comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Partsupp] PRIMARY KEY CLUSTERED 
(
	[ps_key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[r_regionkey] [int] NOT NULL,
	[r_name] [nvarchar](50) NOT NULL,
	[r_comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[r_regionkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO	
/****** Object:  Table [dbo].[Revenue]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Revenue](
	[r_year] [decimal](4, 0) NOT NULL,
	[r_revenue] [decimal](20, 2) NOT NULL,
 CONSTRAINT [PK_Revenue] PRIMARY KEY CLUSTERED 
(
	[r_year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 05/02/2022 18:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[s_suppkey] [int] NOT NULL,
	[s_name] [nvarchar](50) NOT NULL,
	[s_address] [nvarchar](50) NOT NULL,
	[s_nationkey] [int] NOT NULL,
	[s_phone] [nchar](15) NOT NULL,
	[s_acctbal] [decimal](10, 2) NOT NULL,
	[s_comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[s_suppkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Nation] FOREIGN KEY([c_nationkey])
REFERENCES [dbo].[Nation] ([n_nationkey])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Nation]
GO
ALTER TABLE [dbo].[Nation]  WITH CHECK ADD  CONSTRAINT [FK_Nation_Region] FOREIGN KEY([n_regionkey])
REFERENCES [dbo].[Region] ([r_regionkey])
GO
ALTER TABLE [dbo].[Nation] CHECK CONSTRAINT [FK_Nation_Region]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([o_custkey])
REFERENCES [dbo].[Customer] ([c_custkey])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Nation] FOREIGN KEY([s_nationkey])
REFERENCES [dbo].[Nation] ([n_nationkey])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Nation]
GO
ALTER TABLE [dbo].[Monthsales]  WITH CHECK ADD  CONSTRAINT [CK_Monthsales] CHECK  (([ms_month]>=(1) AND [ms_month]<=(12)))
GO
ALTER TABLE [dbo].[Monthsales] CHECK CONSTRAINT [CK_Monthsales]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nation', @level2type=N'CONSTRAINT',@level2name=N'FK_Nation_Region'
GO
USE [master]
GO
ALTER DATABASE [ETLTool] SET  READ_WRITE 
GO
