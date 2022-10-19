USE Espuchifai;

DROP PROCEDURE IF EXISTS altaBanda;
DROP PROCEDURE IF EXISTS altaAlbum;
DROP PROCEDURE IF EXISTS altaCancion;
DROP PROCEDURE IF EXISTS Reproducir;
DROP PROCEDURE IF EXISTS registarCliente;
DROP FUNCTION IF EXISTS CantidadReproduccionesBanda;
DROP PROCEDURE IF EXISTS buscar;
DROP PROCEDURE IF EXISTS BandaPorId;


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
CREATE PROCEDURE altaAlbum(out unIdAlbum SMALLINT, unBanda SMALLINT, unNombre VARCHAR(45), unLanzamiento DATE, unCantRepro INT)
BEGIN
    start transaction;
        INSERT INTO Album(Banda, Nombre, Lanzamiento, CantRepro)
            VALUES (unBanda, unNombre, unLanzamiento, unCantRepro);
        SET unIdAlbum = last_insert_id();
    COMMIT;
END $$

DELIMITER $$
CREATE PROCEDURE altaCancion(out unIdCancion SMALLINT, unAlbum SMALLINT, unNombre VARCHAR(45), unNroOrden TINYINT UNSIGNED, unCantRepro INT)
BEGIN
    start transaction;
        INSERT INTO Cancion(Album, Nombre, NroOrden, CantRepro)
            VALUES (unAlbun, unNombre, unNroOrden, unCantRepro);
        SET unIdCancion = last_insert_id();
    commit;
END $$

DELIMITER $$
CREATE PROCEDURE Reproducir(unCliente SMALLINT, unCancion SMALLINT, unMomentoRepro DATETIME)
BEGIN
INSERT INTO Reproduccion(Cliente, Cancion, MomentoRepro)
	VALUES (unCliente, unCancion, unMomentoRepro);
END $$

DELIMITER $$
CREATE PROCEDURE registarCliente(out unIdCliente SMALLINT, unNombre VARCHAR(45), unApellido VARCHAR(45), unEmail VARCHAR(45), unaContrasena CHAR(65))
BEGIN
    start transaction;
        INSERT INTO Cliente(Nombre, Apellido, Email, Contrasena)
            VALUES (unNombre, unApellido, unEmail, SHA2(unaContrasena, 256));
        SET unIdCliente = last_insert_id();
    commit;
END $$

DELIMITER $$
CREATE FUNCTION CantidadReproduccionesBanda(unIdBanda SMALLINT, fecha1 DATETIME, fecha2 DATETIME) RETURNS SMALLINT
READS SQL DATA 
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

DELIMITER $$
CREATE PROCEDURE BandaPorId (unIdBanda SMALLINT)
BEGIN
    SELECT *
    FROM Banda
    WHERE idBanda = unIdBanda;
END $$
