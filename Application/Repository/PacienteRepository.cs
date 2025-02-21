using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PacienteRepository
    {
        private readonly ApplicationContext _dbContext;

        public PacienteRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _dbContext.Pacientes.AddAsync(paciente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _dbContext.Entry(paciente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Paciente paciente)
        {
            _dbContext.Pacientes.Remove(paciente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _dbContext.Pacientes.FindAsync(id);
        }

        public async Task<List<Paciente>> GetAllAsync(int consultorioId)
        {
            return await _dbContext.Pacientes
                .Where(p => p.ConsultorioId == consultorioId)
                .ToListAsync();
        }
    }
}
