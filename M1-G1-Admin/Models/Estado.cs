using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Estado
    {
        [Key]
        public int id_estado { get; set; }
        public string? tipo_estado { get; set; }

    }
}
