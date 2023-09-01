using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica.Api.Datos.Modelo
{
    [Table("lugarentrega")]
    public class LugarEntrega
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idtipologistica")]
        public int TipoLogisticaId { get; set; }
        public TipoLogistica TipoLogistica { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
