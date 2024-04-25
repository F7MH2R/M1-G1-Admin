using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Mesa
    {
        [Key]
        public int id { get; set; }
        public int numero_asientos { get; set; }
        public int numero_mesa { get; set; }
        public bool? estado_mesa { get; set; }
    }
}
