using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Espuchi.Core;
using System.Data;

namespace Espuchi.AdoEt12
{
    public class MapAlbum : Mapeador<Album>
    {
        public MapAlbum(AdoAGBD ado) : base(ado)
            => Tabla = "Album";
        public override Album ObjetoDesdeFila(DataRow fila)
            => new Album(
                nombre: fila["nombre"].ToString()!,
                lanzamiento: Convert.ToDateTime(fila["lanzamiento"]),
                cantRepro: Convert.ToInt32(fila["cantRepro"])
                )
                {
                    IdAlbum = Convert.ToUInt16(fila["idAlbum"])
                };
        
        public void AltaAlbum(Album album)
            => EjecutarComandoCon("altaAlbum", ConfigurarAltaAlbum, PostAltaAlbum, album);

        private void ConfigurarAltaAlbum(Album album)
        {
            SetComandoSP("altaAlbum");

            BP.CrearParametroSalida("unIdAlbum")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(album.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unLanzamiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .SetValor(album.Lanzamiento)
            .AgregarParametro();

            BP.CrearParametro("unaCantRepro")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Year)
            .SetValor(album.CantRepro)
            .AgregarParametro();
        }
        private void PostAltaAlbum(Album album)
        {
            var paramIdAlbum = GetParametro("unIdAlbum");
            album.IdAlbum = Convert.ToUInt16(paramIdAlbum.Value);
        }

        public List<Album> ObetenerAlbum() => ColeccionDesdeTabla();
        
    }
}