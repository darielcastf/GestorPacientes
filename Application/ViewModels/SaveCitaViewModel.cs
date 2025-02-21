using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveCitaViewModel
    {
        public int Id { get; set; }

        [Required]
        public int PacienteId { get; set; }

        [Required]
        public int MedicoId { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }

        [Required]
        public TimeSpan HoraCita { get; set; }

        [Required]
        public string CausaCita { get; set; }
        public int EstadoCita { get; set; }

        public int ConsultorioId { get; set; } // Hardcoded for testing
    }
}
