using Application.Repository;
using Application.ViewModels;
using Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CitaService
    {
        private readonly CitaRepository _citaRepository;

        public CitaService(CitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public async Task Add(SaveCitaViewModel vm)
        {
            Cita cita = new()
            {
                PacienteId = vm.PacienteId,
                MedicoId = vm.MedicoId,
                FechaCita = vm.FechaCita,
                HoraCita = vm.HoraCita,
                CausaCita = vm.CausaCita,
                ConsultorioId = vm.ConsultorioId
            };
            await _citaRepository.AddAsync(cita);
        }

        public async Task Update(SaveCitaViewModel vm)
        {
            Cita cita = new()
            {
                Id = vm.Id,
                PacienteId = vm.PacienteId,
                MedicoId = vm.MedicoId,
                FechaCita = vm.FechaCita,
                HoraCita = vm.HoraCita,
                CausaCita = vm.CausaCita,
                ConsultorioId = vm.ConsultorioId
            };
            await _citaRepository.UpdateAsync(cita);
        }

        public async Task Delete(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            await _citaRepository.DeleteAsync(cita);
        }

        public async Task<SaveCitaViewModel> GetByIdSaveViewModel(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            return new SaveCitaViewModel
            {
                Id = cita.Id,
                PacienteId = cita.PacienteId,
                MedicoId = cita.MedicoId,
                FechaCita = cita.FechaCita,
                HoraCita = cita.HoraCita,
                CausaCita = cita.CausaCita,
                ConsultorioId = cita.ConsultorioId
            };
        }

        public async Task<List<CitaViewModel>> GetAllViewModel(int consultorioId)
        {
            var citaList = await _citaRepository.GetAllAsync(consultorioId);
            return citaList.Select(cita => new CitaViewModel
            {
                Id = cita.Id,
                PacienteNombre = cita.Paciente.Nombre + " " + cita.Paciente.Apellido,
                MedicoNombre = cita.Medico.Nombre + " " + cita.Medico.Apellido,
                FechaCita = cita.FechaCita,
                HoraCita = cita.HoraCita,
                CausaCita = cita.CausaCita,
                Estado = cita.Estado
            }).ToList();
        }
    }
}
