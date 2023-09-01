using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Contexto;
using Logistica.Api.Datos.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Logistica.Api.AccesoDatos.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {

        private readonly LogisticaContext logisticaContext;

        public UsuarioRepositorio(LogisticaContext logisticaContext) : base(logisticaContext)
        {
            this.logisticaContext = logisticaContext;
        }


        public async Task<Usuario> ObtenerPorUsername(string username)
        {
            return await this.logisticaContext.Usuario.Where(x => x.Username == username).FirstOrDefaultAsync();
        }

    }
}
