CREATE PROCEDURE [dbo].[ContactoActualizar]
	@IdContacto INT,
	@IdProveedor INT,
	@Identificacion VARCHAR(250),
	@Nombre VARCHAR(250),
	@PrimerApellido VARCHAR(250),
	@SegundoApellido VARCHAR(250)
AS
Begin
	SET NOCOUNT ON
		BEGIN TRANSACTION TRASA
			BEGIN TRY

				UPDATE dbo.Contacto SET
					IdProveedor  = @IdProveedor
		           ,Identificacion = @Identificacion
				   ,Nombre = @Nombre
				   ,PrimerApellido = @PrimerApellido
				   ,SegundoApellido = @SegundoApellido
				
				WHERE
					IdContacto = @IdContacto

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
