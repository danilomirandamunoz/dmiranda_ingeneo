using Logistica.Api.Datos.Modelo;
using System.Collections.Generic;

namespace Logistica.Api.AccesoDatos.Interfaces
{
    public interface ILugarEntregaRepositorio :IRepositorio<LugarEntrega>
    {
        Task<List<LugarEntrega>> ObtenerPorIdTipoLogistica(int id);
    }
}
