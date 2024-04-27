using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Cargo
    {
        [Key] 
        public int id_cargo { get; set; }
        [Display(Name = "Tipo de cargo")]
        public string? tipo_cargo { get; set; }

    }
}
