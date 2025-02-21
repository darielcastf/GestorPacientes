using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Enums;


namespace Database.Entities
{
    public class ResultadoLaboratorio
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int PruebaLaboratorioId { get; set; }
        public string Resultado {  get; set; }
        public EstadoResultado Estado { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public int ConsultorioId { get; set; }

        // Navigation Properties
        public Consultorio Consultorio { get; set; }
        public Paciente Paciente { get; set; }
        public PruebaLaboratorio PruebaLaboratorio { get; set; }
    }
}
