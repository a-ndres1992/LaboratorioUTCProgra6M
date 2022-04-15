CREATE TABLE [dbo].[Contacto]
(
	IdContacto INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Contacto PRIMARY KEY CLUSTERED(IdContacto),
	IdProveedor INT NOT NULL CONSTRAINT FK_Contacto_Proveedor FOREIGN KEY(IdProveedor) REFERENCES dbo.Proveedor(IdProveedor),
	Identificacion VARCHAR(250) NOT NULL,
    Nombre VARCHAR(250) NOT NULL,
	PrimerApellido VARCHAR(250) NOT NULL,
	SegundoApellido VARCHAR(250) NOT NULL,

)
WITH (DATA_COMPRESSION = PAGE)
GO
