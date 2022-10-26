USE Espuchifai;

DROP PROCEDURE IF EXISTS altaBanda;
DROP PROCEDURE IF EXISTS altaAlbum;
DROP PROCEDURE IF EXISTS altaCancion;
DROP PROCEDURE IF EXISTS Reproducir;
DROP PROCEDURE IF EXISTS registarCliente;
DROP FUNCTION IF EXISTS CantidadReproduccionesBanda;
DROP PROCEDURE IF EXISTS buscar;
DROP PROCEDURE IF EXISTS BandaPorId;
DROP PROCEDURE IF EXISTS ActualizarBanda;


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
CREATE PROCEDURE altaAlbum(out unIdAlbum SMALLINT, unIdBanda SMALLINT, unNombre VARCHAR(45), unLanzamiento DATE, unCantRepro INT)
BEGIN
    start transaction;
        INSERT INTO Album(idBanda, Nombre, Lanzamiento, CantRepro)
            VALUES (unIdBanda, unNombre, unLanzamiento, unCantRepro);
        SET unIdAlbum = last_insert_id();
    COMMIT;
END $$

DELIMITER $$
CREATE PROCEDURE altaCancion(out unIdCancion SMALLINT, unIdAlbum SMALLINT, unNombre VARCHAR(45), unNroOrden TINYINT UNSIGNED, unCantRepro INT)
BEGIN
    start transaction;
        INSERT INTO Cancion(idAlbum, Nombre, NroOrden, CantRepro)
            VALUES (unIdAlbun, unNombre, unNroOrden, unCantRepro);
        SET unIdCancion = last_insert_id();
    commit;
END $$

DELIMITER $$
CREATE PROCEDURE Reproducir(unIdCliente SMALLINT, unCancion SMALLINT, unMomentoRepro DATETIME)
BEGIN
INSERT INTO Reproduccion(idCliente, Cancion, MomentoRepro)
	VALUES (unIdCliente, unCancion, unMomentoRepro);
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

DELIMITER $$
CREATE PROCEDURE ActualizarBanda (unIdBanda SMALLINT, unNombre VARCHAR(45), unaFundacion YEAR)
BEGIN
    UPDATE Banda
    SEt Nombre = unNombre,
    Fundacion = unaFundacion
    WHERE idBanda = unIdBanda;
END $$

