using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SavePruebaLaboratorioViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la prueba")]
        public string NombrePrueba { get; set; }
        public int ConsultorioId { get; set; }
    }
}
