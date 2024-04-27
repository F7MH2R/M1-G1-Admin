using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Platos
    {
        [Key]
        public int plato_id { get; set; }
        [Required(ErrorMessage = "El nombre del plato es requerido.")]
        [Display(Name = "Nombre del Plato")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "La descripción es requerida.")]
        [Display(Name = "Descripción del Plato")]
        public string? descripcion { get; set; }
        [Required(ErrorMessage = "El precio es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        [Display(Name = "Precio")]
        public decimal? precio { get; set; }
        [Display(Name = "Disponible")]
        public bool? disponible { get; set; }
        [Required(ErrorMessage = "La categoría es requerida.")]
        [Display(Name = "Categoría")]
        public int categoria_id { get; set; }
        [Display(Name = "¿Seleccion si tiene Bebida?")]
        public bool? es_bebida { get; set; }
    }
}
