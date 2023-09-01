using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Logistica.Api.Datos.Modelo
{
    [Table("envio")]
    public class Envio
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("idcliente")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("idtipoproducto")]
        public int TipoProductoId { get; set; }

        public TipoProducto? TipoProducto { get; set; }

        [Column("cantidadproducto")]
        public int CantidadProducto { get; set; }

        [Column("fecharegistro")]
        public DateTime FechaRegistro { get; set; }

        [Column("fechaentrega")]
        public DateTime FechaEntrega { get; set; }

        [Column("idlugarentrega")]
        public int LugarEntregaId { get; set; }

        public LugarEntrega? LugarEntrega { get; set; }

        [Column("precioenvio")]
        public int PrecioEnvio { get; set; }

        [Column("numerovehiculoflota")]
        public string NumeroVehiculoFlota { get; set; }

        [Column("numeroguia")]
        public string NumeroGuia { get; set; }



    }
}
