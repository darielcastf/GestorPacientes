using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class PruebaLaboratorio
    {
        public int Id { get; set; }
        public string NombrePrueba { get; set; }
        public int ConsultorioId { get; set; }

        // Navigation Property
        public Consultorio Consultorio { get; set; }

        public ICollection<ResultadoLaboratorio> ResultadosLaboratorio { get; set; }
    }
}
