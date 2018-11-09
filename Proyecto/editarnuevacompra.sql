USE [Productos]
GO
/****** Object:  StoredProcedure [dbo].[nuevaCompra]    Script Date: 08/11/2018 21:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[nuevaCompra] 
	-- Add the parameters for the stored procedure here
	@b int, @idcompra int, @fecha char(12), @precioC numeric(8,0), @cantidad int, @id_producto int, @idcodigoC int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @b = 1
	    insert into compra values (@fecha, @precioC, @cantidad, @id_producto,@idcodigoC);

    if @b =2
		SELECT * FROM compra

		if @b =3
		UPDATE compra SET fecha =@fecha, precioC =@precioC, cantidad =@cantidad, id_producto =@id_producto, idcodigoC =@idcodigoC
		WHERE idcompra =@idcompra

		if @b=4
		DELETE FROM compra WHERE idcompra=@idcompra

		if @b=5
		SELECT * FROM compra
		WHERE idcompra =@idcompra

		if @b=6
		SELECT * FROM compra
		WHERE fecha LIKE '%' + @fecha+'%' 

END
