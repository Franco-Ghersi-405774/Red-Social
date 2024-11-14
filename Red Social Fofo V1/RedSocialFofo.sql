use RedSocialFofo


-- Tabla Usuarios
CREATE TABLE Usuarios (
    id_usuario INT PRIMARY KEY IDENTITY,
	usuario varchar(100) not null,
    nombre NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    contraseña NVARCHAR(255) NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE(),
    biografia NVARCHAR(500),
    foto_perfil NVARCHAR(255)
);

-- Tabla Publicaciones
CREATE TABLE Publicaciones (
    id_publicacion INT PRIMARY KEY IDENTITY,
    id_usuario INT NOT NULL,
    contenido NVARCHAR(MAX),
    fecha_publicacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Publicaciones_Usuarios FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);

-- Tabla Comentarios
CREATE TABLE Comentarios (
    id_comentario INT PRIMARY KEY IDENTITY,
    id_publicacion INT NOT NULL,
    id_usuario INT NOT NULL,
    contenido NVARCHAR(500) NOT NULL,
    fecha_comentario DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Comentarios_Publicaciones FOREIGN KEY (id_publicacion) REFERENCES Publicaciones(id_publicacion),
    CONSTRAINT FK_Comentarios_Usuarios FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);

-- Tabla Tipos_Mensaje
CREATE TABLE Tipos_Mensaje (
    id_tipo_mensaje INT PRIMARY KEY IDENTITY,
    descripcion NVARCHAR(50) NOT NULL UNIQUE
);

-- Tabla Mensajes
CREATE TABLE Mensajes (
    id_mensaje INT PRIMARY KEY IDENTITY,
    id_emisor INT NOT NULL,
    id_receptor INT NOT NULL,
    contenido NVARCHAR(MAX), -- Texto del mensaje (si existe)
    imagen_url NVARCHAR(255), -- URL o ruta a la imagen (si existe)
    id_tipo_mensaje INT NOT NULL, -- Referencia al tipo de mensaje en Tipos_Mensaje
    fecha_envio DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Mensajes_Emisor FOREIGN KEY (id_emisor) REFERENCES Usuarios(id_usuario),
    CONSTRAINT FK_Mensajes_Receptor FOREIGN KEY (id_receptor) REFERENCES Usuarios(id_usuario),
    CONSTRAINT FK_Mensajes_TipoMensaje FOREIGN KEY (id_tipo_mensaje) REFERENCES Tipos_Mensaje(id_tipo_mensaje)
);

-- Tabla Likes (soporta likes en publicaciones y comentarios)
CREATE TABLE Likes (
    id_like INT PRIMARY KEY IDENTITY,
    id_usuario INT NOT NULL,
    id_objeto INT NOT NULL, -- ID del objeto al que se le da el like (publicación o comentario)
    tipo_objeto NVARCHAR(50) CHECK (tipo_objeto IN ('publicacion', 'comentario')), -- Define si es "publicacion" o "comentario"
    fecha_like DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Likes_Usuarios FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
    CONSTRAINT FK_Likes_Publicaciones FOREIGN KEY (id_objeto) REFERENCES Publicaciones(id_publicacion) ON DELETE CASCADE,
    CONSTRAINT FK_Likes_Comentarios FOREIGN KEY (id_objeto) REFERENCES Comentarios(id_comentario) ON DELETE CASCADE
);

-- Tabla Amistades
CREATE TABLE Amistades (
    id_amistad INT PRIMARY KEY IDENTITY,
    id_usuario1 INT NOT NULL,
    id_usuario2 INT NOT NULL,
    estado NVARCHAR(50) CHECK (estado IN ('pendiente', 'aceptado', 'rechazado')),
    fecha_solicitud DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Amistades_Usuario1 FOREIGN KEY (id_usuario1) REFERENCES Usuarios(id_usuario),
    CONSTRAINT FK_Amistades_Usuario2 FOREIGN KEY (id_usuario2) REFERENCES Usuarios(id_usuario)
);

-- Tabla Tipos_Notificaciones
CREATE TABLE Tipos_Notificaciones (
    id_tipo INT PRIMARY KEY IDENTITY,
    descripcion NVARCHAR(100) NOT NULL
);

-- Tabla Notificaciones
CREATE TABLE Notificaciones (
    id_notificacion INT PRIMARY KEY IDENTITY,
    id_usuario INT NOT NULL,
    tipo_notificacion INT NOT NULL,
    leido BIT DEFAULT 0,
    fecha_notificacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Notificaciones_Usuarios FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
    CONSTRAINT FK_Notificaciones_Tipos FOREIGN KEY (tipo_notificacion) REFERENCES Tipos_Notificaciones(id_tipo)
);



--------------------------------------------------------------------- INSERTS ------------------------------------------------------------------------------
select * from Usuarios

go

insert into Usuarios values('usuario','nombre','email','contraseña',GETDATE(),'Biografia','Foto de perfil URL',1)

INSERT INTO Usuarios VALUES('josephine', 'Josephine Roberts', 'josephine.roberts@gmail.com', 'Jos3ph!n3_R', GETDATE(), 'Aficionada de la literatura y los viajes.', 'https://i.pravatar.cc/300?img=1');
INSERT INTO Usuarios VALUES('marco_a', 'Marco Antonio', 'marco.antonio@gmail.com', 'Marco2023!', GETDATE(), 'Ingeniero de software y amante del café.', 'https://i.pravatar.cc/300?img=2');
INSERT INTO Usuarios VALUES('lucy_lu', 'Lucy Lawrence', 'lucy.lawrence@gmail.com', 'L4wr3nc3!', GETDATE(), 'Diseñadora gráfica con pasión por la fotografía.', 'https://i.pravatar.cc/300?img=3');
INSERT INTO Usuarios VALUES('m_johnson', 'Michael Johnson', 'm.johnson@gmail.com', 'M!ch@3l2024', GETDATE(), 'Entrenador personal y apasionado por la salud y el bienestar.', 'https://i.pravatar.cc/300?img=4');
INSERT INTO Usuarios VALUES('emily_c', 'Emily Carter', 'emily.carter@gmail.com', 'C@rt3r*Emily', GETDATE(), 'Cocinera profesional y exploradora de nuevas recetas.', 'https://i.pravatar.cc/300?img=5');
INSERT INTO Usuarios VALUES('david_b', 'David Brown', 'david.brown@gmail.com', 'D@v!d_B2023', GETDATE(), 'Historiador y ávido lector.', 'https://i.pravatar.cc/300?img=6');
INSERT INTO Usuarios VALUES('sara_k', 'Sara Kim', 'sara.kim@gmail.com', 'S@r@_K2024', GETDATE(), 'Amante del cine y escritora amateur.', 'https://i.pravatar.cc/300?img=7');
INSERT INTO Usuarios VALUES('tommy_v', 'Tommy Vargas', 'tommy.vargas@gmail.com', 'Tommy_V@rgas89', GETDATE(), 'Fanático del fútbol y entrenador juvenil.', 'https://i.pravatar.cc/300?img=8');
INSERT INTO Usuarios VALUES('megan_g', 'Megan Green', 'megan.green@gmail.com', 'M3g@n!Green', GETDATE(), 'Artista digital y diseñadora freelance.', 'https://i.pravatar.cc/300?img=9');
INSERT INTO Usuarios VALUES('leo_r', 'Leonardo Reyes', 'leonardo.reyes@gmail.com', 'LeoR!2023', GETDATE(), 'Ingeniero ambiental y defensor del planeta.', 'https://i.pravatar.cc/300?img=10');
INSERT INTO Usuarios VALUES('olivia_s', 'Olivia Smith', 'olivia.smith@gmail.com', 'Oliv!@S2023', GETDATE(), 'Estudiante de medicina y amante de los animales.', 'https://i.pravatar.cc/300?img=11');
INSERT INTO Usuarios VALUES('lucas_m', 'Lucas Martins', 'lucas.martins@gmail.com', 'Luk_M4rt!ns', GETDATE(), 'Músico y profesor de guitarra.', 'https://i.pravatar.cc/300?img=12');
INSERT INTO Usuarios VALUES('amy_b', 'Amy Brown', 'amy.brown@gmail.com', 'Br@wnAmy_2024', GETDATE(), 'Chef pastelera y aficionada de la repostería.', 'https://i.pravatar.cc/300?img=13');
INSERT INTO Usuarios VALUES('daniel_c', 'Daniel Carter', 'daniel.carter@gmail.com', 'D@n!elC#99', GETDATE(), 'Fotógrafo de naturaleza y viajero.', 'https://i.pravatar.cc/300?img=14');
INSERT INTO Usuarios VALUES('nina_p', 'Nina Perez', 'nina.perez@gmail.com', 'N!n@Perez21', GETDATE(), 'Estilista y asesora de imagen.', 'https://i.pravatar.cc/300?img=15');
INSERT INTO Usuarios VALUES('robert_t', 'Robert Torres', 'robert.torres@gmail.com', 'Rob3rt!T_24', GETDATE(), 'Ingeniero civil y corredor de maratones.', 'https://i.pravatar.cc/300?img=16');
INSERT INTO Usuarios VALUES('fiona_w', 'Fiona White', 'fiona.white@gmail.com', 'F!ona2024', GETDATE(), 'Escritora de blogs y viajera apasionada.', 'https://i.pravatar.cc/300?img=17');
INSERT INTO Usuarios VALUES('benjamin_l', 'Benjamin Lopez', 'benjamin.lopez@gmail.com', 'B3nj@m!n23', GETDATE(), 'Científico de datos y geek de la tecnología.', 'https://i.pravatar.cc/300?img=18');
INSERT INTO Usuarios VALUES('sophie_d', 'Sophie Davis', 'sophie.davis@gmail.com', 'Soph!eD#2023', GETDATE(), 'Psicóloga y amante del arte.', 'https://i.pravatar.cc/300?img=19');
INSERT INTO Usuarios VALUES('carlos_r', 'Carlos Ramirez', 'carlos.ramirez@gmail.com', 'C@rlos!Ram24', GETDATE(), 'Entusiasta del cine y crítico aficionado.', 'https://i.pravatar.cc/300?img=20');


go
-- Usuarios activos
UPDATE Usuarios SET Activo = 1 WHERE usuario IN ('josephine', 'marco_a', 'lucy_lu', 'emily_c', 'david_b', 'megan_g', 'leo_r', 'lucas_m', 'amy_b', 'fiona_w');

-- Usuarios inactivos
UPDATE Usuarios SET Activo = 0 WHERE usuario IN ('m_johnson', 'sara_k', 'tommy_v', 'olivia_s', 'daniel_c', 'nina_p', 'robert_t', 'benjamin_l', 'sophie_d', 'carlos_r');

go

ALTER TABLE Usuarios
ADD Activo BIT DEFAULT 1;


