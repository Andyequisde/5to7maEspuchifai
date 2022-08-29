DROP PROCEDURE IF EXISTS altaBanda;
DROP PROCEDURE IF EXISTS altaAlbun;
DROP PROCEDURE IF EXISTS altaCancion;
DROP PROCEDURE IF EXISTS Reproducir;
DROP PROCEDURE IF EXISTS registarCliente;
DROP FUNCTION IF EXISTS CantidadReproduccionesBanda;
DROP PROCEDURE IF EXISTS buscar;


DELIMITER $$
CREATE PROCEDURE altaBanda (out unIdBanda SMALLINT,unNombre VARCHAR(45),unaFundacion YEAR)
BEGIN
    start transaction;
        INSERT INTO Banda(Nombre, Fundacion)
            VALUES (unNombre, unaFundacion);
        SET unIdBanda = last_insert_id();
    COMMIT;
END $$

DELIMITER $$
CREATE PROCEDURE altaAlbun(out unIdAlbun SMALLINT, unIdBanda SMALLINT, unNombre VARCHAR(45), unLanzamiento DATE, unCantRepro INT)
BEGIN
    start transaction;
        INSERT INTO Albun(idBanda, nombre, lanzamiento, cantRepro)
            VALUES (unIdBanda, unNombre, unLanzamiento, unCantRepro);
        SET unIdAlbun = last_insert_id();
    COMMIT;
END $$

DELIMITER $$
CREATE PROCEDURE altaCancion(out unIdCancion SMALLINT, unIdAlbun SMALLINT, unNombre VARCHAR(45), unNro_Orden TINYINT UNSIGNED, unCantRepro INT)
BEGIN
    start transaction;
        INSERT INTO Cancion(idAlbun, nombre, nro_Orden, cantRepro)
            VALUES (unIdAlbun, unNombre, unNro_Orden, unCantRepro);
        SET unIdCancion = last_insert_id();
    commit;
END $$

DELIMITER $$
CREATE PROCEDURE Reproducir(unIdCliente SMALLINT, unIdCancion SMALLINT, unMomento_reproduccion DATETIME)
BEGIN
INSERT INTO Reproduccion(idCliente, idCancion, momento_reproduccion)
	VALUES (unIdCliente, unIdCancion, unMomento_reproduccion);
END $$

DELIMITER $$
CREATE PROCEDURE registarCliente(out unIdCliente SMALLINT, unNombre VARCHAR(45), unApellido VARCHAR(45), unEmail VARCHAR(45), unaContrasena CHAR(65))
BEGIN
    start transaction;
        INSERT INTO Cliente(nombre, apellido, email, contrasena)
            VALUES (unNombre, unApellido, unEmail, SHAD2(unaContrasena, 666));
        SET unIdCliente = last_insert_id();
    commit;
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
