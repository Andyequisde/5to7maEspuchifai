DROP PROCEDURE IF EXISTS altaBanda;
DROP PROCEDURE IF EXISTS altaAlbun;
DROP PROCEDURE IF EXISTS altaCancion;
DROP PROCEDURE IF EXISTS Reproducir;
DROP PROCEDURE IF EXISTS registarCliente;
DROP FUNCTION IF EXISTS CantidadReproduccionesBanda;
DROP PROCEDURE IF EXISTS buscar;


DELIMITER $$
CREATE PROCEDURE altaBanda (unIdBanda SMALLINT,unNombre VARCHAR(45),unaFundacion YEAR)
BEGIN
INSERT INTO Banda(idBanda, nombre, fundacion)
	VALUES (unIdBanda, unNombre, unaFundacion);
END $$

DELIMITER $$
CREATE PROCEDURE altaAlbun(unIdAlbun SMALLINT, unIdBanda SMALLINT, unNombre VARCHAR(45), unLanzamiento DATE, unCantRepro INT)
BEGIN
INSERT INTO Albun(idAlbun, idBanda, nombre, lanzamiento, cantRepro)
	VALUES (unIdAlbun, unIdBanda, unNombre, unLanzamiento, unCantRepro);
END $$

DELIMITER $$
CREATE PROCEDURE altaCancion(unIdCancion SMALLINT, unIdAlbun SMALLINT, unNombre VARCHAR(45), unNro_Orden TINYINT UNSIGNED, unCantRepro INT)
BEGIN
INSERT INTO Cancion(idCancion, idAlbun, nombre, nro_Orden, cantRepro)
	VALUES (unIdCancion, unIdAlbun, unNombre, unNro_Orden, unCantRepro);
END $$

DELIMITER $$
CREATE PROCEDURE Reproducir(unIdReproduccion SMALLINT, unIdCliente SMALLINT, unIdCancion SMALLINT)
BEGIN
INSERT INTO Reproduccion(idReproduccion, idCliente, idCancion)
	VALUES (unIdReproduccion, unIdCliente, unIdCancion);
END $$

DELIMITER $$
CREATE PROCEDURE registarCliente(unIdCliente SMALLINT, unNombre VARCHAR(45), unApellido VARCHAR(45), unEmail VARCHAR(45), unaContrasena CHAR(65))
BEGIN
INSERT INTO Cliente(idCliente, nombre, apellido, email, contrasena)
    VALUES (unIdCliente, unNombre, unApellido, unEmail, SHAD2(unaContrasena, 666));
END $$

DELIMITER $$
CREATE FUNCTION CantidadReproduccionesBanda(unIdBanda SMALLINT, fecha1 DATETIME, fecha2 DATETIME) RETURNS SMALLINT
BEGIN
	DECLARE resultado SMALLINT;
    
    SELECT SUM(IdReproduccion) INTO resultado
    FROM Reproduccion
    WHERE idBanda = unIdBanda
    AND momento_reproduccion BETWEEN fecha1 AND fecha2;
    
    RETURN resultado;
END $$

DELIMITER $$
CREATE PROCEDURE buscar( unbuscar VARCHAR(45))
BEGIN
    SELECT nombre
    FROM cancion
    WHERE MATCH(nombre) 
    AGAINST(unbuscar IN NATURAL LANGUAGE MODE);
END $$
