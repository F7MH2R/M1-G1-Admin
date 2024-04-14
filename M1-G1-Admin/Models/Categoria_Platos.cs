using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Categoria_Platos
    {
        [Key]
        public int categoria_id { get; set; }
        public string? nombre { get; set; }
    }
}
