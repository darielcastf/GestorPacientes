using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class CitaRepository
    {
        private readonly ApplicationContext _dbcontext;

        public CitaRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Cita cita)
        {
            await _dbcontext.Citas.AddAsync(cita);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cita cita)
        {
            _dbcontext.Entry(cita).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cita cita)
        {
            _dbcontext.Citas.Remove(cita);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Cita> GetByIdAsync(int id)
        {
            return await _dbcontext.Citas.FindAsync(id);
        }

        public async Task<List<Cita>> GetAllAsync(int consultorioId)
        {
            return await _dbcontext.Citas
                .Where(c => c.ConsultorioId == consultorioId)
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToListAsync();
        }
    }
}
