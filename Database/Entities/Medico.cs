using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string? Cedula { get; set; }
        public string Foto { get; set;}
        public int ConsultorioId { get; set; }        
        public Consultorio Consultorio { get; set; } // Navigation Property
        public ICollection<Cita> Citas { get; set; }

    }
}
