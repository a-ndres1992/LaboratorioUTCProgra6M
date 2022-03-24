CREATE PROCEDURE [dbo].[ProveedorLista]
	AS 
	BEGIN
	SET NOCOUNT ON

	SELECT
		IdProveedor,
		Nombre
	FROM dbo.Proveedor
	END

	