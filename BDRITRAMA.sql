USE [RITRAMA]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 07/20/2019 23:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[Proveedor_ID] [nvarchar](10) NOT NULL,
	[Proveedor_Name] [nvarchar](200) NULL,
	[Preveedor_Cat] [nvarchar](20) NULL,
	[Preveedor_Dir] [nvarchar](200) NULL,
	[Preveedor_email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Provaider] PRIMARY KEY CLUSTERED 
(
	[Proveedor_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 07/20/2019 23:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[Product_ID] [nvarchar](25) NOT NULL,
	[Product_Name] [nvarchar](200) NULL,
	[Product_Descrip] [nvarchar](200) NULL,
	[Product_Ref] [nvarchar](20) NULL,
	[Codebar] [nvarchar](128) NULL,
	[Existencia] [numeric](18, 2) NULL,
	[Category_ID] [nvarchar](50) NULL,
	[Tipo_MP] [bit] NULL,
	[Tipo_PT] [bit] NULL,
	[anulado] [bit] NULL,
	[fisico] [numeric](18, 2) NULL,
	[inventario_inicial] [numeric](18, 2) NULL,
	[salidas] [numeric](18, 2) NULL,
	[existencia_final] [numeric](18, 2) NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 07/20/2019 23:08:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [nvarchar](10) NOT NULL,
	[Customer_Name] [nvarchar](200) NULL,
	[Customer_Category] [nvarchar](10) NULL,
	[Customer_Dir] [text] NULL,
	[Customer_Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
