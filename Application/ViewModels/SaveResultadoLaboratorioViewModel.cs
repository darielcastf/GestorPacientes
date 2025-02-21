using Database.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveResultadoLaboratorioViewModel
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }
        public int PruebaLaboratorioId { get; set; }
        public string NombrePrueba { get; set; }
        public string Resultado { get; set; }
        public EstadoResultado Estado { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public int ConsultorioId { get; set; }
    }
}
