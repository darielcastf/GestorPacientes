using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ConsultorioService
    {
        private readonly ConsultorioRepository _consultorioRepository;
        public ConsultorioService(ApplicationContext dbContext)
        {
            _consultorioRepository = new(dbContext);
        }

        public async Task<List<ConsultorioViewModel>> GetAllViewModel()
        {
            var consultorioList = await _consultorioRepository.GetAllAsync();
            return consultorioList.Select(consultorio => new ConsultorioViewModel
            {
                Id = consultorio.Id,
                NombreConsultorio = consultorio.NombreConsultorio
            }).ToList();
        }
    }
}
