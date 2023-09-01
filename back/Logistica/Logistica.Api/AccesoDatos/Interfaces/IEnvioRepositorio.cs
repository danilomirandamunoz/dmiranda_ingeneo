using Logistica.Api.AccesoDatos.Repositorios;
using Logistica.Api.Datos.Modelo;

namespace Logistica.Api.AccesoDatos.Interfaces
{
    public interface IEnvioRepositorio: IRepositorio<Envio>
    {
        Task<List<Envio>> ObtenerEnviosPorIdCliente(int idCliente);
        Task<List<Envio>> ObtenerEnviosPorIdTipoLogistica(int idTipoLogistica);
    }
}
