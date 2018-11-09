USE [Productos]
GO
/****** Object:  StoredProcedure [dbo].[nuevoCliente]    Script Date: 08/11/2018 21:59:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[nuevoCliente]
	-- Add the parameters for the stored procedure here
	@b int, @idcliente int ,@nombres varchar(50), @direccion varchar (50), @telef char(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @b = 1
	       insert into cliente values (@nombres,@direccion,@telef);

		     if @b =2
		SELECT * FROM cliente

		if @b =3
		UPDATE cliente SET nombres=@nombres, direccion=@direccion, telef=@telef
		WHERE @idcliente=@idcliente

		if @b=4
		DELETE FROM cliente WHERE idcodigoC=@idcliente

		if @b=5
		SELECT * FROM cliente
		WHERE idcodigoC =@idcliente

		if @b=6
		SELECT * FROM cliente
		WHERE nombres LIKE '%' + @nombres+'%' OR 
		direccion LIKE '%'+ @direccion+'%'
END
