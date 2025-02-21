using Database.Enums;
using System;

namespace Application.ViewModels
{
    public class ResultadoLaboratorioViewModel
    {
        public int Id { get; set; }
        public string PacienteNombre { get; set; }
        public string CedulaPaciente { get; set; }
        public string NombrePrueba { get; set; }
        public EstadoResultado Estado { get; set; }
        public DateTime FechaRealizacion { get; set; }
    }
}
