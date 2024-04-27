using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Combos
    {
        [Key]
        public int combo_id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        [Display(Name = "Nombre del Combo")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "La descripción es requerida.")]
        [Display(Name = "Descripción")]
        public string? descripcion { get; set; }
  
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El precio es requerido.")]
        [Display(Name = "Precio")]
        public decimal? precio { get; set; }

        [Required(ErrorMessage = "Seleccione si tiene disponible.")]
        [Display(Name = "¿Tiene disponible?")]
        public bool? disponible { get; set; }



    }
}
