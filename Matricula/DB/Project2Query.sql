USE [Matricula]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[IdCarrera] [int] IDENTITY(1,1) NOT NULL,
	[Carrera] [varchar](150) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[IdCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[IdCarrera] [int] NOT NULL,
	[Materia] [varchar](150) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Creditos] [int] NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IdRol] [int] NOT NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Carrera] ON 
GO
INSERT [dbo].[Carrera] ([IdCarrera], [Carrera], [Estado]) VALUES (1, N'Ingeniería en Sistemas', 1)
GO
INSERT [dbo].[Carrera] ([IdCarrera], [Carrera], [Estado]) VALUES (2, N'Ingeniería en Producción', 1)
GO
SET IDENTITY_INSERT [dbo].[Carrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 
GO
INSERT [dbo].[Materia] ([IdMateria], [IdCarrera], [Materia], [Estado], [Creditos]) VALUES (1, 1, N'Programación IV', 1, 5)
GO
INSERT [dbo].[Materia] ([IdMateria], [IdCarrera], [Materia], [Estado], [Creditos]) VALUES (2, 1, N'Bases de datos', 1, 6)
GO
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
GO
INSERT [dbo].[Rol] ([IdRol], [Nombre]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Rol] ([IdRol], [Nombre]) VALUES (2, N'Usuario')
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
INSERT [dbo].[Usuario] ([Usuario], [Password], [IdRol], [IdUsuario]) VALUES (N'admin', N'1234', 1, NULL)
GO
INSERT [dbo].[Usuario] ([Usuario], [Password], [IdRol], [IdUsuario]) VALUES (N'user', N'1234', 2, NULL)
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD  CONSTRAINT [FK_Materia_Carrera] FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carrera] ([IdCarrera])
GO
ALTER TABLE [dbo].[Materia] CHECK CONSTRAINT [FK_Materia_Carrera]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAutentica]
@user varchar(50),
@password varchar(50)
AS
BEGIN
	
	--se crea el select con la información de autenticación y el rol, agregar la información del usuario.
	select usuario,U.idrol,R.nombre as rol from Usuario u inner join rol r on U.idrol=R.idrol
	where usuario=@user and Password=@password

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertaCarrera]
@nombre varchar(150),
@idCarrera int output,
@cod_error int output,
@msg_error varchar(max) output
AS
BEGIN
	--define las variables de salida
	set @cod_error=0
	set @msg_error=''

	BEGIN TRY
		
		
		INSERT INTO Carrera(Carrera,Estado)
		VALUES(@nombre,1)

		set @idCarrera=SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
		--SI DA ERROR RETORNE LOS VALORES DE ERROR DEL SQL
		SET @cod_error=@@ERROR
		SET @msg_error=ERROR_MESSAGE()
	END CATCH
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSeleccionaCarreras]
@idCarrera int
AS
BEGIN
	select * from Carrera
	where
		(@idCarrera is null or IdCarrera=@idCarrera)

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- TABLAS ADMINISTRACION/GESTION ESTUDIANTIL

CREATE TABLE EstadoEstudiante (
	IdEstadoEstudiante INT PRIMARY KEY IDENTITY(1,1),
	EstadoEstudiante NVARCHAR(30) NOT NULL -- Activo, Inactivo, Matriculado, Graduado
);

INSERT INTO EstadoEstudiante (EstadoEstudiante) 
	VALUES ('Activo'), ('Inactivo'), ('Matriculado'), ('Graduado');

CREATE TABLE TipoIdentificacion (
	IdTipoIdentificacion INT PRIMARY KEY IDENTITY(1,1),
	TipoIdentificacion NVARCHAR(30) NOT NULL -- Cedula, Pasaporte, CarnetResidente
);

INSERT INTO TipoIdentificacion (TipoIdentificacion)
	VALUES ('Cedula'), ('Pasaporte'), ('CarnetResidente');

CREATE TABLE Estudiante (
	IdEstudiante INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(45) NOT NULL,
	ApellidoPaterno NVARCHAR(45) NOT NULL,
	ApellidoMaterno NVARCHAR(45), -- PUEDE SER NULL
	Identificacion INT NOT NULL,
	FechaNacimiento DATE NOT NULL DEFAULT GETDATE(),
	FechaIngreso DATE NOT NULL DEFAULT GETDATE(),
	IdEstadoEstudiante INT NOT NULL, -- FK,
	IdTipoIdentificacion INT NOT NULL, -- FK
	IdCarrera INT NOT NULL -- FK
	CONSTRAINT FK_ESTUDIANTE_ID_ESTADO_ES FOREIGN KEY (IdEstadoEstudiante) REFERENCES EstadoEstudiante (IdEstadoEstudiante),
	CONSTRAINT FK_ESTUDIANTE_ID_TIPO_ID FOREIGN KEY (IdTipoIdentificacion) REFERENCES TipoIdentificacion (IdTipoIdentificacion),
	CONSTRAINT FK_ESTUDIANTE_ID_CARRERA FOREIGN KEY (IdCarrera) REFERENCES Carrera (IdCarrera)
);

INSERT INTO Estudiante (Nombre, ApellidoPaterno, ApellidoMaterno, Identificacion, IdEstadoEstudiante, IdTipoIdentificacion, IdCarrera)
	VALUES ('Kevin', 'Velez', 'Salazar', 118940941, 1, 1,1);

-- TABLAS ADMINISTRACION/GESTION GRUPOS/CURSOS

CREATE TABLE Horario (
	IdHorario INT PRIMARY KEY IDENTITY(1,1),
	Horario NVARCHAR(30) NOT NULL -- Lunes a Sabado
);

INSERT INTO Horario (Horario)
	VALUES ('Lunes'), ('Martes'), ('Miercoles'), ('Jueves'), ('Viernes'), ('Sabado');

CREATE TABLE EstadoGrupo (
	IdEstadoGrupo INT PRIMARY KEY IDENTITY(1,1),
	EstadoGrupo NVARCHAR(30) NOT NULL
);

INSERT INTO EstadoGrupo (EstadoGrupo)
	VALUES ('Abierto'), ('Cerrado');

CREATE TABLE Grupo (
	IdGrupo INT PRIMARY KEY IDENTITY(1,1),
	NumeroGrupo INT NOT NULL,
	Cupo INT NOT NULL,
	IdMateria INT NOT NULL, -- FK
	IdHorario INT NOT NULL, -- FK
	IdEstadoGrupo INT NOT NULL, -- FK
	CONSTRAINT FK_GRUPO_ID_MATERIA FOREIGN KEY (IdMateria) REFERENCES Materia (IdMateria),
	CONSTRAINT FK_GRUPO_ID_HORARIO FOREIGN KEY (IdHorario) REFERENCES Horario (IdHorario),
	CONSTRAINT FK_GRUPO_ID_ESTADO_GR FOREIGN KEY (IdEstadoGrupo) REFERENCES EstadoGrupo (IdEstadoGrupo)
);

INSERT INTO Grupo (NumeroGrupo, Cupo, IdMateria, IdHorario, IdEstadoGrupo)
	VALUES (1,10,1,1,1);

CREATE TABLE Matricula (
    IdMatricula INT PRIMARY KEY IDENTITY(1,1),
    IdEstudiante INT NOT NULL,
    IdGrupo INT NOT NULL,
    FechaMatricula DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Matricula_Estudiante FOREIGN KEY (IdEstudiante) REFERENCES Estudiante(IdEstudiante),
    CONSTRAINT FK_Matricula_Grupo FOREIGN KEY (IdGrupo) REFERENCES Grupo(IdGrupo)
);

-- STORED PROCEDURE GESTION MATRICULA
CREATE PROCEDURE spMatricular
    @idEstudiante INT,
    @idGrupo INT,
    @cod_error INT OUTPUT,
    @msg_error VARCHAR(MAX) OUTPUT
AS
BEGIN
    SET @cod_error = 0;
    SET @msg_error = '';

    BEGIN TRY
        INSERT INTO Matricula (IdEstudiante, IdGrupo)
        VALUES (@idEstudiante, @idGrupo);
    END TRY
    BEGIN CATCH
        SET @cod_error = ERROR_NUMBER();
        SET @msg_error = ERROR_MESSAGE();
    END CATCH
END

-- STORED PROCEDURE GESTION ESTUDIANTES

CREATE PROCEDURE [dbo].[spBuscarEstudiantes]
    @IdEstudiante INT = NULL,
    @Nombre NVARCHAR(45) = NULL,
    @ApellidoPaterno NVARCHAR(45) = NULL,
    @ApellidoMaterno NVARCHAR(45) = NULL,
    @Identificacion INT = NULL,
    @IdEstadoEstudiante INT = NULL,
    @IdTipoIdentificacion INT = NULL,
    @IdCarrera INT = NULL
AS
BEGIN
    SELECT 
        e.IdEstudiante,
        e.Nombre,
        e.ApellidoPaterno,
        e.ApellidoMaterno,
        e.Identificacion,
        e.FechaNacimiento,
        e.FechaIngreso,
        e.IdEstadoEstudiante,
        e.IdTipoIdentificacion,
        e.IdCarrera
    FROM Estudiante e
    WHERE 
        (@IdEstudiante IS NULL OR e.IdEstudiante = @IdEstudiante) AND
        (@Nombre IS NULL OR e.Nombre LIKE '%' + @Nombre + '%') AND
        (@ApellidoPaterno IS NULL OR e.ApellidoPaterno LIKE '%' + @ApellidoPaterno + '%') AND
        (@ApellidoMaterno IS NULL OR e.ApellidoMaterno LIKE '%' + @ApellidoMaterno + '%') AND
        (@Identificacion IS NULL OR e.Identificacion = @Identificacion) AND
        (@IdEstadoEstudiante IS NULL OR e.IdEstadoEstudiante = @IdEstadoEstudiante) AND
        (@IdTipoIdentificacion IS NULL OR e.IdTipoIdentificacion = @IdTipoIdentificacion) AND
        (@IdCarrera IS NULL OR e.IdCarrera = @IdCarrera)
END

CREATE PROCEDURE [dbo].[spCrearEstudiante]
    @Nombre NVARCHAR(45),
    @ApellidoPaterno NVARCHAR(45),
    @ApellidoMaterno NVARCHAR(45),
    @Identificacion INT,
    @FechaNacimiento DATE,
    @FechaIngreso DATE,
    @IdEstadoEstudiante INT,
    @IdTipoIdentificacion INT,
    @IdCarrera INT,
    @IdEstudiante INT OUTPUT,
    @cod_error INT OUTPUT,
    @msg_error NVARCHAR(256) OUTPUT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Estudiante 
        (
            Nombre, ApellidoPaterno, ApellidoMaterno, Identificacion, 
            FechaNacimiento, FechaIngreso, IdEstadoEstudiante, 
            IdTipoIdentificacion, IdCarrera
        )
        VALUES 
        (
            @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Identificacion, 
            @FechaNacimiento, @FechaIngreso, @IdEstadoEstudiante, 
            @IdTipoIdentificacion, @IdCarrera
        )

        SET @IdEstudiante = SCOPE_IDENTITY()
        SET @cod_error = 0
        SET @msg_error = 'Success'
    END TRY
    BEGIN CATCH
        SET @cod_error = ERROR_NUMBER()
        SET @msg_error = ERROR_MESSAGE()
    END CATCH
END

CREATE PROCEDURE [dbo].[spListarEstudiantes]
AS
BEGIN
    SELECT 
        e.IdEstudiante,
        e.Nombre,
        e.ApellidoPaterno,
        e.ApellidoMaterno,
        e.Identificacion,
        e.FechaNacimiento,
        e.FechaIngreso,
        e.IdEstadoEstudiante,
        e.IdTipoIdentificacion,
        e.IdCarrera
    FROM Estudiante e
END

CREATE PROCEDURE [dbo].[spBuscarEstudiantePorId]
    @IdEstudiante INT
AS
BEGIN
    SELECT 
        e.IdEstudiante,
        e.Nombre,
        e.ApellidoPaterno,
        e.ApellidoMaterno,
        e.Identificacion,
        e.FechaNacimiento,
        e.FechaIngreso,
        e.IdEstadoEstudiante,
        e.IdTipoIdentificacion,
        e.IdCarrera
    FROM Estudiante e
    WHERE e.IdEstudiante = @IdEstudiante
END

-- STORED PROCEDURE GESTION GRUPOS

CREATE PROCEDURE [dbo].[spCrearGrupos]
    @NumeroGrupo INT,
    @Cupo INT,
    @IdMateria INT,
    @IdHorario INT,
    @IdEstadoGrupo INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Grupo (NumeroGrupo, Cupo, IdMateria, IdHorario, IdEstadoGrupo)
    VALUES (@NumeroGrupo, @Cupo, @IdMateria, @IdHorario, @IdEstadoGrupo);
    
    SELECT SCOPE_IDENTITY() AS IdGrupo; -- Return the newly inserted IdGrupo
END

CREATE PROCEDURE [dbo].[spObtenerGrupos]
AS
BEGIN
    SELECT 
        g.IdGrupo,
        g.NumeroGrupo,
        g.Cupo,
        m.IdMateria,
        m.Materia,
        h.Horario,
        e.EstadoGrupo
    FROM 
        Grupo g
    INNER JOIN 
        Materia m ON g.IdMateria = m.IdMateria
    INNER JOIN 
        Horario h ON g.IdHorario = h.IdHorario
    INNER JOIN 
        EstadoGrupo e ON g.IdEstadoGrupo = e.IdEstadoGrupo
END

-- Stored Procedure to get Materias
CREATE PROCEDURE [dbo].[spObtenerMaterias]
AS
BEGIN
    SELECT IdMateria, Materia
    FROM Materia
END

-- Stored Procedure to get Horarios
CREATE PROCEDURE [dbo].[spObtenerHorarios]
AS
BEGIN
    SELECT IdHorario, Horario
    FROM Horario
END

-- Stored Procedure to get Estados
CREATE PROCEDURE [dbo].[spObtenerEstados]
AS
BEGIN
    SELECT IdEstadoGrupo, EstadoGrupo
    FROM EstadoGrupo
END

-- STORED PROCEDURES GESTION MATERIAS

CREATE PROCEDURE [dbo].[spSeleccionaMaterias]
@IdCarrera INT,
@IdMateria INT
AS
BEGIN
    SELECT m.IdCarrera, m.IdMateria, m.Materia, m.Creditos, c.Carrera
    FROM Materia m
    INNER JOIN Carrera c ON m.IdCarrera = c.IdCarrera
    WHERE (@idCarrera IS NULL OR m.IdCarrera = @idCarrera)
      AND (@idMateria IS NULL OR m.IdMateria = @idMateria)
END
GO

CREATE PROCEDURE [dbo].[spCrearMateria]
@IdCarrera INT,
@Materia VARCHAR(150),
@Creditos INT
AS
BEGIN
    INSERT INTO Materia (IdCarrera, Materia, Creditos, Estado)
    VALUES (@IdCarrera, @Materia, @Creditos, 1);
    
    SELECT SCOPE_IDENTITY() AS IdMateria;
END
GO

CREATE PROCEDURE [dbo].[spActualizarMateria]
@IdMateria INT,
@IdCarrera INT,
@Materia VARCHAR(150),
@Creditos INT
AS
BEGIN
    UPDATE Materia
    SET IdCarrera = @IdCarrera,
        Materia = @Materia,
        Creditos = @Creditos
    WHERE IdMateria = @IdMateria;
END
GO
