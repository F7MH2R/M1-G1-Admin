using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Platos
    {
        [Key]
        public int plato_id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal? precio { get; set; }
        public int disponible { get; set; }
        public int categoria_id { get; set; }


    }
}
