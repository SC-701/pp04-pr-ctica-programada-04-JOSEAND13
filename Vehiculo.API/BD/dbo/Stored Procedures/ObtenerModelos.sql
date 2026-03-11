CREATE PROCEDURE [dbo].[ObtenerModelos]
    @IdMarca UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Modelos.id,
        Modelos.idMarca,
        Modelos.Nombre
    FROM Modelos
    WHERE Modelos.idMarca = @IdMarca
END
GO

