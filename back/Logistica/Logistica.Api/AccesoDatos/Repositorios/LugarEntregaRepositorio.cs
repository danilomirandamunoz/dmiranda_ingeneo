using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Contexto;
using Logistica.Api.Datos.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Logistica.Api.AccesoDatos.Repositorios
{
    public class LugarEntregaRepositorio : Repositorio<LugarEntrega>, ILugarEntregaRepositorio
    {

        private readonly LogisticaContext logisticaContext;

        public LugarEntregaRepositorio(LogisticaContext logisticaContext) : base(logisticaContext)
        {
            this.logisticaContext = logisticaContext;
        }


        public Task<List<LugarEntrega>> ObtenerPorIdTipoLogistica(int id)
        {
            return this.logisticaContext.LugarEntrega.Where(x => x.TipoLogisticaId == id).ToListAsync();
        }

    }
}
