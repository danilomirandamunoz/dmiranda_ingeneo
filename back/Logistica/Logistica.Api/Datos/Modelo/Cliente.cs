using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica.Api.Datos.Modelo
{
    [Table("cliente")]
    public class Cliente
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }


    }
}
