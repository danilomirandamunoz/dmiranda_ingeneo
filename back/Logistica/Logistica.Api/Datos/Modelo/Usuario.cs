using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica.Api.Datos.Modelo
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("usuario")]
        public string Username { get; set; }
        [Column("clave")]
        public string Password { get; set; }
    }
}
