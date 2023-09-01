
using System.Linq.Expressions;

namespace Logistica.Api.AccesoDatos.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> Obtener();
        Task<T> ObtenerPorId(int id);
        Task<T> Guardar(T entity);
        Task<List<T>> Obtener(params Expression<Func<T, object>>[]? includeExpressions);
        Task Actualizar(T entity);
        Task Eliminar(T entity);
    }
}
