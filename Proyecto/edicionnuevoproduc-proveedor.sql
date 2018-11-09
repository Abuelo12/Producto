USE [Productos]
GO
/****** Object:  StoredProcedure [dbo].[nuevo prod_prove]    Script Date: 08/11/2018 22:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[nuevo prod_prove]
	-- Add the parameters for the stored procedure here
	@b int, @id_pp int, @precio numeric(8,5), @cantidad int, @id_producto int, @idcodigoP int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
     if @b = 1
	insert into prod_prove values (@precio,@cantidad,@id_producto,@idcodigoP);

	if @b =2
		SELECT * FROM prod_prove

		if @b =3
		UPDATE prod_prove SET Precio =@precio, cantidad =@cantidad,@id_producto =@id_producto, idcodigoP =@idcodigoP
		WHERE id_PP=@id_PP

		if @b=4
		DELETE FROM prod_prove WHERE id_PP=@id_pp

		if @b=5
		SELECT * FROM prod_prove
		WHERE id_PP =@id_pp

		if @b=6
		SELECT * FROM prod_prove
		WHERE Precio LIKE '%' + @precio+'%' 
END
