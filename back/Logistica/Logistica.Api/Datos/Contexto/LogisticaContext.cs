using Logistica.Api.Datos.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Logistica.Api.Datos.Contexto
{
    public class LogisticaContext : DbContext
    {
        public LogisticaContext(DbContextOptions<LogisticaContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }



        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<TipoLogistica> TipoLogistica { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<LugarEntrega> LugarEntrega { get; set; }
        public virtual DbSet<Envio> Envio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }



    }
}