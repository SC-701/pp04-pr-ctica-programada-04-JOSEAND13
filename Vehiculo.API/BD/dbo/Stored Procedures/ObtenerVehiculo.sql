CREATE PROCEDURE ObtenerVehiculo
	-- Add the parameters for the stored procedure here
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Vehiculo.id, Vehiculo.idmodelo, Vehiculo.placa, Vehiculo.color, Vehiculo.anio, Vehiculo.precio, Vehiculo.telefonoPropietario, Vehiculo.correoPropietario, Modelos.Nombre AS Modelo, Marcas.Nombre AS Marca
	FROM     Vehiculo INNER JOIN
					  Modelos ON Vehiculo.idmodelo = Modelos.id INNER JOIN
					  Marcas ON Modelos.idMarca = Marcas.id
	WHERE  (Vehiculo.id = @Id)
END