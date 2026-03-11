CREATE   PROCEDURE [dbo].[ObtenerMarcas]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  
        id,
        Nombre
    FROM Marcas
END