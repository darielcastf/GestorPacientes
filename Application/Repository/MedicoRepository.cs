using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class MedicoRepository
    {
        private readonly ApplicationContext _dbcontext;
        public MedicoRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Medico medico)
        {
            await _dbcontext.Medicos.AddAsync(medico);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medico medico)
        {
            _dbcontext.Entry(medico).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Medico medico)
        {
            _dbcontext.Set<Medico>().Remove(medico);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Medico>> GetAllAsync(int consultorioId)
        {
            return await _dbcontext.Medicos
                .Where(m => m.ConsultorioId == consultorioId)
                .ToListAsync();
        }

        public async Task<Medico> GetByIdAsync(int Id)
        {
            return await _dbcontext.Medicos.FindAsync(Id);
        }
    }
}
