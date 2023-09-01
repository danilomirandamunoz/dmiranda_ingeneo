using Logistica.Api.Datos.Modelo;

namespace Logistica.Api.AccesoDatos.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> ObtenerPorUsername(string username);
    }
}
