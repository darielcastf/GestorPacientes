using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ResultadoLaboratorioRepository
    {
        private readonly ApplicationContext _dbcontext;
        public ResultadoLaboratorioRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(ResultadoLaboratorio resultado)
        {
            await _dbcontext.ResultadosLaboratorio.AddAsync(resultado);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ResultadoLaboratorio resultado)
        {
            _dbcontext.Entry(resultado).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ResultadoLaboratorio resultado)
        {
            _dbcontext.Set<ResultadoLaboratorio>().Remove(resultado);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<ResultadoLaboratorio>> GetAllAsync(int consultorioId)
        {
            return await _dbcontext.ResultadosLaboratorio
                .Include(r => r.Paciente)
                .Include(r => r.PruebaLaboratorio)
                .Where(r => r.ConsultorioId == consultorioId)
                .ToListAsync();
        }

        public async Task<ResultadoLaboratorio> GetByIdAsync(int Id)
        {
            return await _dbcontext.ResultadosLaboratorio
                .Include(r => r.Paciente)
                .Include(r => r.PruebaLaboratorio)
                .FirstOrDefaultAsync(r => r.Id == Id);
        }

        // Implementación del método GetByCedulaAsync
        public async Task<List<ResultadoLaboratorio>> GetByCedulaAsync(string cedula, int consultorioId)
        {
            return await _dbcontext.ResultadosLaboratorio
                .Include(r => r.Paciente)
                .Include(r => r.PruebaLaboratorio)
                .Where(r => r.Paciente.Cedula == cedula && r.ConsultorioId == consultorioId)
                .ToListAsync();
        }
    }
}
