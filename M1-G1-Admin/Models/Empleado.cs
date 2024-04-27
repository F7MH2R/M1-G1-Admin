using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace M1_G1_Admin.Models
{
    public class Empleado
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Nombre Completo")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no debe exceder 100 caracteres.")]
        public string? nombre { get; set; }
        [DisplayName("DUI")]
        [Required(ErrorMessage = "El DUI es obligatorio.")]
        [RegularExpression("^[0-9]{8}-[0-9]$", ErrorMessage = "El formato del DUI es incorrecto ej. 12345678-9.")]
        public string? dui { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
       
        public DateTime? fecha_nacimiento { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression("^[0-9]{8,15}$", ErrorMessage = "El teléfono debe tener entre 8 y 15 dígitos.")]
        public string?  telefono { get; set; }
        [DisplayName("Dirección")]
        public string? direccion { get; set; }
        [DisplayName("Teléfono de Referencia")]
        [RegularExpression("^[0-9]{8,15}$", ErrorMessage = "El teléfono de referencia debe tener entre 8 y 15 dígitos.")]
        public string? telefono_referencia { get; set; }
        public int cargo_id { get; set; }
        [DisplayName("Disponible para Trabajar")]
        public bool disponible { get; set; }

        [DisplayName("Salario")]
        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un número positivo.")]
        public decimal salario { get; set; }
        [DisplayName("Fecha de Contratación")]
        public DateTime? fecha_contratacion { get; set; }

    }
}
