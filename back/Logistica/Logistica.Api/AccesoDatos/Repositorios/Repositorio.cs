using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Contexto;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Logistica.Api.AccesoDatos.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly LogisticaContext logisticaContext;

        public Repositorio(LogisticaContext logisticaContext)
        {
            this.logisticaContext = logisticaContext;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return logisticaContext.Set<T>();
            }
        }

        public async Task<T> Guardar(T entity)
        {
            EntitySet.Add(entity);
            await logisticaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> Obtener()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> ObtenerPorId(int id)
        {
            var entity = await EntitySet.FindAsync(id);
            EntitySet.Entry(entity).State = EntityState.Detached;
            return entity;
           
        }

        public async Task<List<T>> Obtener(params Expression<Func<T, object>>[]? includeExpressions)
        {
            IQueryable<T> set = EntitySet;

            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }

            return await set.ToListAsync();
        }

        public async Task Actualizar(T entity)
        {
            EntitySet.Update(entity);
            await logisticaContext.SaveChangesAsync();
        }

        public async Task Eliminar(T entity)
        {
            EntitySet.Remove(entity);
            await logisticaContext.SaveChangesAsync();
        }

    }
}
