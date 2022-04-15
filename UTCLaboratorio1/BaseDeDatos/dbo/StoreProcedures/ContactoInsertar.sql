CREATE PROCEDURE [dbo].[ContactoInsertar]
	@Identificacion VARCHAR(250),
	@IdProveedor INT,
	@Nombre VARCHAR(250),
	@PrimerApellido VARCHAR(250),
	@SegundoApellido VARCHAR(250)
AS
BEGIN
	SET NOCOUNT ON
		BEGIN TRANSACTION TRASA
			BEGIN TRY

				INSERT INTO dbo.Contacto
		        (   Identificacion
				   ,IdProveedor
				   ,Nombre
				   ,PrimerApellido
				   ,SegundoApellido
				   
				)
				VALUES
				(
					@Identificacion
				   ,@IdProveedor
				   ,@Nombre
				   ,@PrimerApellido
				   ,@SegundoApellido
				  
				)
				COMMIT TRANSACTION TRASA
				SELECT 0 AS CodeError, '' AS MsgError

			END TRY

			BEGIN CATCH

				SELECT
					ERROR_NUMBER() AS CodeError,
					ERROR_MESSAGE() AS MsgError
				ROLLBACK TRANSACTION TRASA

			END CATCH
END
