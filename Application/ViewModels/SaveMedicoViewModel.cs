using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveMedicoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del medico")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe colocar el apellido del medico")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe colocar el correo del medico")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Debe colocar el numero telefonico del medico")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Debe colocar la cedula del medico")]
        public string Foto { get; set; }
        public int ConsultorioId { get; set; }
    }
}
