IF OBJECT_ID('dbo.usuarios_USSS129326', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.usuarios_USSS129326
    (
        idUsuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        usuario VARCHAR(35) NOT NULL UNIQUE,
        clave VARCHAR(35) NOT NULL,
        nombre VARCHAR(65) NOT NULL,
        direccion VARCHAR(85) NOT NULL,
        telefono VARCHAR(9) NOT NULL
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios_USSS129326)
BEGIN
    INSERT INTO dbo.usuarios_USSS129326 (usuario, clave, nombre, direccion, telefono)
    VALUES
        ('demoUSSS1', 'Clave129326A', 'Usuario inicial 1', 'Sin especificar', '000000001'),
        ('demoUSSS2', 'Clave129326B', 'Usuario inicial 2', 'Sin especificar', '000000002'),
        ('demoUSSS3', 'Clave129326C', 'Usuario inicial 3', 'Sin especificar', '000000003');
END;
GO
