using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PruebaLaboratorioRepository
    {
        private readonly ApplicationContext _dbcontext;
        public PruebaLaboratorioRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(PruebaLaboratorio prueba)
        {
            await _dbcontext.PruebasLaboratorio.AddAsync(prueba);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PruebaLaboratorio prueba)
        {
            var existingPrueba = await _dbcontext.PruebasLaboratorio.FindAsync(prueba.Id);
            if (existingPrueba != null)
            {
                _dbcontext.Entry(existingPrueba).CurrentValues.SetValues(prueba);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(PruebaLaboratorio prueba)
        {
            _dbcontext.Set<PruebaLaboratorio>().Remove(prueba);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<PruebaLaboratorio>> GetAllAsync(int consultorioId)
        {
            return await _dbcontext.PruebasLaboratorio
                .Where(p => p.ConsultorioId == consultorioId)
                .ToListAsync();
        }

        public async Task<PruebaLaboratorio> GetByIdAsync(int Id)
        {
            return await _dbcontext.PruebasLaboratorio.FindAsync(Id);
        }
    }
}
