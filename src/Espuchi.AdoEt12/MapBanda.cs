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
        //-------------------------------------------------------------------------------------------
        public async Task AltaBanda(Banda banda)
            => await EjecutarComandoAsync("altaBanda", ConfigurarAltaBanda, PostAltaBanda, banda);
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
        //-------------------------------------------------------------------------------------------
        public async Task<Banda> BandaPorId(ushort IdBanda)
        {
            ConfigurarBandaPorId(IdBanda);
            return await ElementoDesdeSPAsync();
        }
        public void ConfigurarBandaPorId(ushort IdBanda)
        {
            SetComandoSP("BandaPorId");

            BP.CrearParametro("unIdBanda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(IdBanda)
            .AgregarParametro();
        }
        //-------------------------------------------------------------------------------------------
        public async Task ActualizarBanda(Banda banda)
            => await EjecutarComandoAsync("ActualizarBanda", ConfigurarActualizarBanda, banda);
        public void ConfigurarActualizarBanda(Banda banda)
        {
            SetComandoSP("ActualizarBanda");

            BP.CrearParametro("unIdBanda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(banda.IdBanda)
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
        //-------------------------------------------------------------------------------------------
        public async Task EliminarBanda(Banda banda)
            => await EjecutarComandoAsync("EliminarBanda", ConfigurarEliminarBanda, banda);

        private void ConfigurarEliminarBanda(Banda banda)
        {
            SetComandoSP("ElminarBanda");

            BP.CrearParametro("unIdBanda")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
            .SetValor(banda.IdBanda)
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
        //-------------------------------------------------------------------------------------------
        private void PostAltaBanda(Banda banda)
        {
            var paramIdBanda = GetParametro("unIdBanda");
            banda.IdBanda = Convert.ToUInt16(paramIdBanda.Value);
        }

        public async Task<List<Banda>> ObtenerBanda() =>  await ColeccionDesdeTablaAsync();
    }
}