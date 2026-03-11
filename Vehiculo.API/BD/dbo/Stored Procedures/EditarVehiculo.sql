CREATE PROCEDURE EditarVehiculo
	-- Add the parameters for the stored procedure here
	@id AS uniqueidentifier
	,@idmodelo AS uniqueidentifier
	,@placa AS VARCHAR(max)
	,@color AS VARCHAR(max)
	,@anio AS int
	,@precio AS decimal(18,0)
	,@correoPropietario AS VARCHAR (max)
	,@telefonoPropietario AS VARCHAR (max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
   BEGIN TRANSACTION
		UPDATE [dbo].[Vehiculo]
		   SET [idmodelo] = @idmodelo
			  ,[placa] = @placa
			  ,[color] = @color
			  ,[anio] = @anio
			  ,[precio] = @precio 
			  ,[correoPropietario] = @correoPropietario 
			  ,[telefonoPropietario] = @telefonoPropietario 
			WHERE [id] = @id
		SELECT @id
	COMMIT TRANSACTION
END