using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string? Direccion {  get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool? Fumador { get; set; }
        public bool? Alergias { get; set; }
        public string Foto { get; set; }
        public int ConsultorioId { get; set; }
        public Consultorio Consultorio { get; set; } // Navigation Property
        public ICollection<ResultadoLaboratorio> ResultadosLaboratorio { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}
