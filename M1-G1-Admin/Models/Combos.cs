using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Combos
    {
        [Key]
        public int combo_id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? precio { get; set; }
        public bool? disponible { get; set; }



    }
}
