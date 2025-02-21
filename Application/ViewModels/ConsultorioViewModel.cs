using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ConsultorioViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del Consultorio")]
        public string NombreConsultorio { get; set; }
    }
}
