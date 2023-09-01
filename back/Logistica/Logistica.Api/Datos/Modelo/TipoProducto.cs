using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica.Api.Datos.Modelo
{
    [Table("tipoproducto")]
    public class TipoProducto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
