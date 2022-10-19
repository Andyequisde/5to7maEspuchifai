using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Espuchi.Core;
using System.Data;

namespace Espuchi.AdoEt12
{
    public class MapBanda : Mapeador<Banda>
    {
        public MapBanda(AdoAGBD ado) : base(ado)
            => Tabla = "Banda";

        public override Banda ObjetoDesdeFila(DataRow fila)
            => new Banda(
                nombre: fila["nombre"].ToString()!,
                fundacion: Convert.ToInt32(fila["fundacion"])
                )
            {
                IdBanda = Convert.ToUInt16(fila["IdBanda"])
            };

        public void AltaBanda(Banda banda)
            => EjecutarComandoCon("altaBanda", ConfigurarAltaBanda, PostAltaBanda, banda);

        public Banda BandaPorId(ushort IdBanda)
        {
            ConfigurarBandaPorId(IdBanda);
            return ElementoDesdeSP();
        }

        private void ConfigurarBandaPorId(ushort IdBanda)
        {
            SetComandoSP("BandaPorId");

            BP.CrearParametro("unIdBanda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(IdBanda)
            .AgregarParametro();
        }

        private void ConfigurarAltaBanda(Banda banda)
        {
            SetComandoSP("altaBanda");

            BP.CrearParametroSalida("unIdBanda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(banda.Nombre)
            .AgregarParametro();

            BP.CrearParametro("unaFundacion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Year)
            .SetValor(banda.Fundacion)
            .AgregarParametro();
        }
        private void PostAltaBanda(Banda banda)
        {
            var paramIdBanda = GetParametro("unIdBanda");
            banda.IdBanda = Convert.ToUInt16(paramIdBanda.Value);
        }

        public List<Banda> ObtenerBanda() => ColeccionDesdeTabla();
    }
}