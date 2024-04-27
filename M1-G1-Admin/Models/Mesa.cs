using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Mesa
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "El número de asientos es requerido.")]
        [Display(Name = "Número de Asientos")]
        public int numero_asientos { get; set; }
        [Required(ErrorMessage = "El número de mesa es requerido.")]
        [Display(Name = "Número de Mesa")]
        public int numero_mesa { get; set; }
        [Display(Name = "Seleccione el estado de la Mesa")]
        public bool? estado_mesa { get; set; }
    }
}
