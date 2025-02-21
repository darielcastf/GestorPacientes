using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Consultorio
    {
        public int Id { get; set; }
        public string NombreConsultorio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Medico> Medicos { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
