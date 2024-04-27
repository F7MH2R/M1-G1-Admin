using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Promociones
    {
        [Key]
        public int promocion_id { get; set; }
        [Required(ErrorMessage = "El nombre de la promoción es requerido.")]
        [Display(Name = "Nombre de la Promoción")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "La descripción es requerida.")]
        [Display(Name = "Descripción de la Promoción")]
        public string? descripcion { get; set; }
        [Required(ErrorMessage = "El descuento es requerido.")]
        [Range(0.01, 100.00, ErrorMessage = "El descuento debe ser entre 0.01% y 100%.")]
        [Display(Name = "Descuento")]
        public decimal? descuento { get; set; }
        [Required(ErrorMessage = "La fecha de inicio es requerida.")]
        [Display(Name = "Fecha de Inicio")]
        public DateTime? fecha_inicio { get; set; }
        [Required(ErrorMessage = "La fecha de finalización es requerida.")]
        [Display(Name = "Fecha de Fin")]
        public DateTime?  fecha_fin { get; set; }

    }
}
