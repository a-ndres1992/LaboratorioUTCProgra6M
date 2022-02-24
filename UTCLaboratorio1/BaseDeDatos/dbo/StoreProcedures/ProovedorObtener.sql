CREATE PROCEDURE [dbo].[ProovedorObtener]
	@IdProovedor INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT 
		 IdProovedor
		,Identificacion
		,Nombre
		,PrimerApellido
		,SegundoApellido
		,Edad
		,FechaNacimiento

	FROM 
		dbo.Proveedor
	WHERE 
		(@IdProovedor IS NULL OR @IdProovedor = IdProovedor)

END

