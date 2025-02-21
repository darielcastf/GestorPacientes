using Application.Repository;
using Application.ViewModels;
using Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PacienteService
    {
        private readonly PacienteRepository _pacienteRepository;

        public PacienteService(PacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task Add(SavePacienteViewModel vm)
        {
            Paciente paciente = new()
            {
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Cedula = vm.Cedula,
                Telefono = vm.Telefono,
                FechaNacimiento = vm.FechaNacimiento,
                Foto = vm.Foto,
                ConsultorioId = vm.ConsultorioId
            };
            await _pacienteRepository.AddAsync(paciente);
        }

        public async Task Update(SavePacienteViewModel vm)
        {
            Paciente paciente = new()
            {
                Id = vm.Id,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Cedula = vm.Cedula,
                Telefono = vm.Telefono,
                FechaNacimiento = vm.FechaNacimiento,
                Foto = vm.Foto,
                ConsultorioId = vm.ConsultorioId
            };
            await _pacienteRepository.UpdateAsync(paciente);
        }

        public async Task Delete(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            await _pacienteRepository.DeleteAsync(paciente);
        }

        public async Task<SavePacienteViewModel> GetByIdSaveViewModel(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            return new SavePacienteViewModel
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Cedula = paciente.Cedula,
                Telefono = paciente.Telefono,
                FechaNacimiento = paciente.FechaNacimiento,
                Foto = paciente.Foto,
                ConsultorioId = paciente.ConsultorioId
            };
        }

        public async Task<List<PacienteViewModel>> GetAllViewModel(int consultorioId)
        {
            var pacientes = await _pacienteRepository.GetAllAsync(consultorioId);
            return pacientes.Select(p => new PacienteViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                FechaNacimiento = p.FechaNacimiento.ToString("yyyy-MM-dd"),
                Foto = p.Foto
            }).ToList();
        }
    }
}
