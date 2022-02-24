﻿CREATE TABLE [dbo].[Proveedor]
(
	IdProovedor INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Proovedor PRIMARY KEY CLUSTERED(IdProovedor),
	Identificacion VARCHAR(250) NOT NULL,
    Nombre VARCHAR(250) NOT NULL,
	PrimerApellido VARCHAR(250) NOT NULL,
	SegundoApellido VARCHAR(250) NOT NULL,
	Edad INT NOT NULl,
	FechaNacimiento DATETIME NOT NULL 
)
WITH (DATA_COMPRESSION = page)
GO