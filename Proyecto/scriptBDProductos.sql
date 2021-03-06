USE [Productos]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 12/10/2018 8:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idcodigoC] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[telef] [char](15) NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcodigoC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[compra]    Script Date: 12/10/2018 8:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[compra](
	[idcompra] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [char](12) NOT NULL,
	[precioC] [numeric](8, 0) NOT NULL,
	[cantidad] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[idcodigoC] [int] NOT NULL,
 CONSTRAINT [PK_compra] PRIMARY KEY CLUSTERED 
(
	[idcompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[prod_prove]    Script Date: 12/10/2018 8:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prod_prove](
	[id_PP] [int] IDENTITY(1,1) NOT NULL,
	[Precio] [numeric](8, 5) NOT NULL,
	[cantidad] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[idcodigoP] [int] NOT NULL,
 CONSTRAINT [PK_prod_prove] PRIMARY KEY CLUSTERED 
(
	[id_PP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/10/2018 8:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_procuto] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 12/10/2018 8:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[idcodigoP] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](20) NOT NULL,
	[telefono] [char](15) NOT NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idcodigoP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD  CONSTRAINT [FK_ciente_idcodigoC] FOREIGN KEY([idcodigoC])
REFERENCES [dbo].[cliente] ([idcodigoC])
GO
ALTER TABLE [dbo].[compra] CHECK CONSTRAINT [FK_ciente_idcodigoC]
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD  CONSTRAINT [FK_producto_id_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[compra] CHECK CONSTRAINT [FK_producto_id_producto]
GO
ALTER TABLE [dbo].[prod_prove]  WITH CHECK ADD  CONSTRAINT [FK_prod_prove_id_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[prod_prove] CHECK CONSTRAINT [FK_prod_prove_id_producto]
GO
ALTER TABLE [dbo].[prod_prove]  WITH CHECK ADD  CONSTRAINT [FK_proveedor_idcodigoP] FOREIGN KEY([idcodigoP])
REFERENCES [dbo].[proveedor] ([idcodigoP])
GO
ALTER TABLE [dbo].[prod_prove] CHECK CONSTRAINT [FK_proveedor_idcodigoP]
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD  CONSTRAINT [CH_precioC] CHECK  (([precioC]>(0)))
GO
ALTER TABLE [dbo].[compra] CHECK CONSTRAINT [CH_precioC]
GO
ALTER TABLE [dbo].[prod_prove]  WITH CHECK ADD  CONSTRAINT [CH_precio] CHECK  (([precio]>(0)))
GO
ALTER TABLE [dbo].[prod_prove] CHECK CONSTRAINT [CH_precio]
GO
/****** Object:  StoredProcedure [dbo].[nuevoProveedor]    Script Date: 12/10/2018 8:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Saira Urbina
-- Create date:
-- Description:	
-- =============================================
CREATE PROCEDURE  [dbo].[nuevoProveedor]
	@b INT,	@idcodigoP INT, @nombre VARCHAR(50), @direccion VARCHAR(20),@telefono CHAR(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @b=1
		INSERT INTO proveedor VALUES(@nombre, @direccion, @telefono); 
END

GO
