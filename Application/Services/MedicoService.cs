using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MedicoService
    {
        private readonly MedicoRepository _medicoRepository;
        public MedicoService(ApplicationContext dbContext)
        {
            _medicoRepository = new(dbContext);
        }

        public async Task Update(SaveMedicoViewModel vm)
        {
            Medico medico = new();
            medico.Id = vm.Id;
            medico.Nombre = vm.Nombre;
            medico.Apellido = vm.Apellido;
            medico.Correo = vm.Correo;
            medico.Telefono = vm.Telefono;
            medico.Foto = vm.Foto;
            medico.ConsultorioId = vm.ConsultorioId;
            await _medicoRepository.UpdateAsync(medico);
        }

        public async Task Add(SaveMedicoViewModel vm)
        {
            Medico medico = new();
            medico.Nombre = vm.Nombre;
            medico.Apellido = vm.Apellido;
            medico.Correo = vm.Correo;
            medico.Telefono = vm.Telefono;
            medico.Foto = vm.Foto;
            medico.ConsultorioId = vm.ConsultorioId;
            await _medicoRepository.AddAsync(medico);
        }

        public async Task Delete(int Id)
        {
            var medico = await _medicoRepository.GetByIdAsync(Id);
            await _medicoRepository.DeleteAsync(medico);
        }

        public async Task<SaveMedicoViewModel> GetByIdSaveViewModel(int Id)
        {
            var medico = await _medicoRepository.GetByIdAsync(Id);

            SaveMedicoViewModel vm = new();
            vm.Id = Id;
            vm.Nombre = medico.Nombre;
            vm.Apellido = medico.Apellido;
            vm.Correo = medico.Correo;
            vm.Telefono = medico.Telefono;
            vm.Foto = medico.Foto;
            vm.ConsultorioId = medico.ConsultorioId;

            return vm;
        }

        public async Task<List<MedicoViewModel>> GetAllViewModel(int consultorioId)
        {
            var medicoList = await _medicoRepository.GetAllAsync(consultorioId);
            return medicoList.Select(medico => new MedicoViewModel
            {
                Id = medico.Id,
                Nombre = medico.Nombre,
                Apellido = medico.Apellido,
                Correo = medico.Correo,
                Telefono = medico.Telefono,
                Foto = medico.Foto
            }).ToList();
        }
    }
}
