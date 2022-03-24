CREATE PROCEDURE [dbo].[ContactoObtener]
	@IdContacto INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT 
		 IdContacto
		,C.Identificacion
		,C.Nombre
		,C.PrimerApellido
		,C.SegundoApellido
		,P.IdProveedor
		,P.Nombre

	FROM 
		dbo.Contacto C
		 INNER JOIN dbo.Proveedor P 
		 ON C.IdProveedor = P.IdProveedor
	WHERE 
		(@IdContacto IS NULL OR @IdContacto = IdContacto)

END