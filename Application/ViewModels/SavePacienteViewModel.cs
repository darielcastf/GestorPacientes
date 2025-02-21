using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePacienteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del paciente")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe colocar el apellido del paciente")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe colocar la cedula del paciente.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe colocar el numero telefonico del paciente")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Debe colocar la fecha de naciemiento del paciente")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe colocar la foto del paciente")]
        public string Foto { get; set; }
        public int ConsultorioId { get; set; }
    }
}
