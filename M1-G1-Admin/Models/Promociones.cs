using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Promociones
    {
        [Key]
        public int promocion_id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal? descuentos { get; set; }
        public string? fecha_inicio { get; set; }
        public string?  fecha_fin { get; set; }

    }
}
