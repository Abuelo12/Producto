USE [Productos]
GO
/****** Object:  StoredProcedure [dbo].[nuevoProducto]    Script Date: 08/11/2018 22:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[nuevoProducto]
	-- Add the parameters for the stored procedure here
	@b int, @id_producto int, @descripcion varchar (50) 	 
AS	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @b = 1
	insert into Producto values(@descripcion);

	if @b =2
		SELECT * FROM Producto

		if @b =3
		UPDATE Producto SET descripcion=@descripcion
		WHERE @id_producto=@id_producto

		if @b=4
		DELETE FROM Producto WHERE id_producto =@id_producto

		if @b=5
		SELECT * FROM Producto
		WHERE id_producto =@id_producto

		if @b=6
		SELECT * FROM Producto
		WHERE descripcion LIKE '%' + @descripcion+'%' OR 
		id_producto LIKE '%'+ @id_producto+'%'
END
