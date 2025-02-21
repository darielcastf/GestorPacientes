using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PruebaLaboratorioService
    {
        private readonly PruebaLaboratorioRepository _pruebaRepository;
        public PruebaLaboratorioService(ApplicationContext dbContext)
        {
            _pruebaRepository = new(dbContext);
        }

        public async Task Update(SavePruebaLaboratorioViewModel vm)
        {
            PruebaLaboratorio prueba = new()
            {
                Id = vm.Id,
                NombrePrueba = vm.NombrePrueba,
                ConsultorioId = vm.ConsultorioId
            };
            await _pruebaRepository.UpdateAsync(prueba);
        }

        public async Task Add(SavePruebaLaboratorioViewModel vm)
        {
            PruebaLaboratorio prueba = new();
            prueba.NombrePrueba = vm.NombrePrueba;
            prueba.ConsultorioId = vm.ConsultorioId;
            await _pruebaRepository.AddAsync(prueba);
        }

        public async Task Delete(int Id)
        {
            var prueba = await _pruebaRepository.GetByIdAsync(Id);
            await _pruebaRepository.DeleteAsync(prueba);
        }

        public async Task<SavePruebaLaboratorioViewModel> GetByIdSaveViewModel(int Id)
        {
            var prueba = await _pruebaRepository.GetByIdAsync(Id);
            SavePruebaLaboratorioViewModel vm = new()
            {
                Id = prueba.Id,  // Usar el Id del objeto recuperado
                NombrePrueba = prueba.NombrePrueba,
                ConsultorioId = prueba.ConsultorioId
            };
            return vm;
        }

        public async Task<List<PruebaLaboratorioViewModel>> GetAllViewModel(int consultorioId)
        {
            var pruebaList = await _pruebaRepository.GetAllAsync(consultorioId);
            return pruebaList.Select(prueba => new PruebaLaboratorioViewModel
            {
                Id = prueba.Id,
                NombrePrueba = prueba.NombrePrueba,
                ConsultorioId = prueba.ConsultorioId
            }).ToList();
        }
    }
}
