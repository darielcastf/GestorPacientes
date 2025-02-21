using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class HomeViewModel
    {
        public List<PacienteViewModel> Pacientes { get; set; }
        public List<MedicoViewModel> Medicos { get; set; }
        public List<PruebaLaboratorioViewModel> Pruebas { get; set; }
        public List<ResultadoLaboratorioViewModel> Resultado { get; set; }
        public List<CitaViewModel> Cita { get; set; } 
        
    }
}
