using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Contexto;
using Logistica.Api.Datos.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Logistica.Api.AccesoDatos.Repositorios
{
    public class EnvioRepositorio : Repositorio<Envio>, IEnvioRepositorio
    {

        private readonly LogisticaContext logisticaContext;

        public EnvioRepositorio(LogisticaContext logisticaContext) : base(logisticaContext)
        {
            this.logisticaContext = logisticaContext;
        }

        public async Task<List<Envio>> ObtenerEnviosPorIdCliente(int idCliente)
        {
            var res = await this.logisticaContext.Envio.Include(c => c.ClienteId).Where(x=>x.ClienteId == idCliente).ToListAsync();
            return res;
        }

        public async Task<List<Envio>> ObtenerEnviosPorIdTipoLogistica(int idTipoLogistica)
        {
            var res = await this.logisticaContext.Envio.Include(x=>x.LugarEntregaId).Include(c=>c.ClienteId).Where(x => x.LugarEntrega.TipoLogisticaId == idTipoLogistica).ToListAsync();
            return res;
        }
    }
}
