using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostSeguridadPersonalizada.Models
{
    [Table("DetallesDeportes")]
    public class DetalleDeporte
    {
        [Key]
        [Column("iddetalledeporte")]
        public int IdDetalle { get; set; }
        [Column("iddeporte")]
        public int IdDeporte { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("imagen")]
        public string Imagen {  get; set; }
    }
}
