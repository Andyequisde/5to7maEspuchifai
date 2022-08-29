DROP DATABASE IF EXISTS Espuchifai;
CREATE DATABASE Espuchifai;
USE Espuchifai;
	CREATE TABLE Banda (
	idBanda SMALLINT AUTO_INCREMENT,
	nombre VARCHAR(45) NOT NULL,
	fundacion YEAR,
	PRIMARY KEY (idBanda)
);
	CREATE TABLE Album (
	idAlbum SMALLINT AUTO_INCREMENT,
	idBanda SMALLINT AUTO_INCREMENT,
	nombre VARCHAR(45) NOT NULL,
	lanzamiento DATE NOT NULL,
	CantRepro INT NOT NULL
	PRIMARY KEY (idAlbum),
	CONSTRAINT fk_Album_Banda FOREIGN KEY (idBanda)
	REFERENCES Banda (idBanda)
);
	CREATE TABLE Cancion (
	idCancion SMALLINT AUTO_INCREMENT,
	idAlbum SMALLINT AUTO_INCREMENT,
	nombre VARCHAR(45) NOT NULL,
	nro_orden TINYINT UNSIGNED NOT NULL,
	CantRepro INT NOT NULL
	PRIMARY KEY (idCancion),
	CONSTRAINT fk_Cancion_Album FOREIGN KEY (idAlbum)
	REFERENCES Album (idAlbum)
);
	CREATE TABLE Cliente (
	idCliente SMALLINT AUTO_INCREMENT,
	nombre VARCHAR(45) NOT NULL,
	apellido VARCHAR(45) NOT NULL,
	email VARCHAR(45) NOT NULL,
	contrasena CHAR(65) NOT NULL,
	PRIMARY KEY (idCliente)
);
	CREATE TABLE Reproduccion (
	idCliente SMALLINT,
	idCancion SMALLINT,
	momento_reproduccion DATETIME NOT NULL,
	PRIMARY KEY (idCliente, idCancion, momento_reproduccion),
	CONSTRAINT fk_Reproduccion_Cliente FOREIGN KEY (idCliente)
	REFERENCES Cliente (idCliente),
	CONSTRAINT fk_Reproduccion_Cancion FOREIGN KEY (idCancion)
	REFERENCES Cancion (idCancion)
);
