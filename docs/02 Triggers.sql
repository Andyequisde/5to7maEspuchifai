CREATE TRIGGER aftInsReproduccion AFTER INSERT ON Reproduccion
FOR EACH ROW
BEGIN

    UPDATE  Cancion
    SET     cantRepro = cantRepro + 1
    WHERE   idCancion = new.idCancion
END

CREATE TRIGGER aftUpdtCancion AFTER UPDATE ON Cancion
FOR EACH ROW
BEGIN

    UPDATE  Album
    SET     cantRepro = cantRepro + new.cantRepro
    WHERE   idAlbum = new.idAlbum
END
