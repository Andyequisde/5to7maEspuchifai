USE Espuchifai;

INSERT INTO Banda (idBanda, Nombre, Fundacion)
    VALUES (1, 'ElSinNombre', 1999);

INSERT INTO Album (idAlbum, idBanda, Nombre, Lanzamiento, CantRepro)
    VALUES (10, 1, 'Nose', '2004/03/21', 3);

INSERT INTO Cancion (idCancion, idAlbum, Nombre, NroOrden, CantRepro)
    VALUES (20, 10, 'Leyends Never Die', 1, 2),
            (21, 10, 'Alone PT II', 2, 3);

CALL registarCliente(@idMero, 'Yo mero', 'Secret', 'yomero.secret@gmail.com', '123456');
