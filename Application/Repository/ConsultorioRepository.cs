using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ConsultorioRepository
    {
        private readonly ApplicationContext _dbcontext;
        public ConsultorioRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Consultorio consultorio)
        {
            await _dbcontext.Consultorios.AddAsync(consultorio);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Consultorio>> GetAllAsync()
        {
            return await _dbcontext.Consultorios.ToListAsync();
        }

        public async Task<Consultorio> GetByIdAsync(int Id)
        {
            return await _dbcontext.Consultorios.FindAsync(Id);
        }

        public async Task UpdateAsync(Consultorio consultorio)
        {
            _dbcontext.Entry(consultorio).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Consultorio consultorio)
        {
            _dbcontext.Set<Consultorio>().Remove(consultorio);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
