using System;
using Database.Enums;

namespace Application.ViewModels
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public string PacienteNombre { get; set; }
        public string MedicoNombre { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public string CausaCita { get; set; }
        public EstadoCita Estado { get; set; }
    }
}
