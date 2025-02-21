using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Enums;

namespace Database.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public string CausaCita { get; set; }
        public EstadoCita Estado { get; set; }
        public int ConsultorioId {  get; set; }

        // Navigation Properties
        public Consultorio Consultorio { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public int EstadoCita { get; set; }
    }
}
