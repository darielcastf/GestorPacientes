using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Entities;
using Database.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResultadoLaboratorioService
    {
        private readonly ResultadoLaboratorioRepository _resultadoRepository;
        public ResultadoLaboratorioService(ApplicationContext dbContext)
        {
            _resultadoRepository = new(dbContext);
        }

        public async Task Update(SaveResultadoLaboratorioViewModel vm)
        {
            ResultadoLaboratorio resultado = new()
            {
                Id = vm.Id,
                PacienteId = vm.PacienteId,
                PruebaLaboratorioId = vm.PruebaLaboratorioId,
                Resultado = vm.Resultado,
                Estado = EstadoResultado.Completada,
                FechaRealizacion = vm.FechaRealizacion,
                ConsultorioId = vm.ConsultorioId
            };
            await _resultadoRepository.UpdateAsync(resultado);
        }


    

        public async Task Add(SaveResultadoLaboratorioViewModel vm)
        {
            ResultadoLaboratorio resultado = new();
            resultado.PacienteId = vm.PacienteId;
            resultado.PruebaLaboratorioId = vm.PruebaLaboratorioId;
            resultado.Resultado = vm.Resultado;
            resultado.Estado = EstadoResultado.Pendiente;
            resultado.FechaRealizacion = vm.FechaRealizacion;
            resultado.ConsultorioId = vm.ConsultorioId;
            await _resultadoRepository.AddAsync(resultado);
        }

        public async Task Delete(int Id)
        {
            var resultado = await _resultadoRepository.GetByIdAsync(Id);
            await _resultadoRepository.DeleteAsync(resultado);
        }

        public async Task<SaveResultadoLaboratorioViewModel> GetByIdSaveViewModel(int Id)
        {
            var resultado = await _resultadoRepository.GetByIdAsync(Id);

            SaveResultadoLaboratorioViewModel vm = new();
            vm.Id = Id;
            vm.PacienteId = resultado.PacienteId;
            vm.PruebaLaboratorioId = resultado.PruebaLaboratorioId;
            vm.Resultado = resultado.Resultado;
            vm.Estado = resultado.Estado;
            vm.FechaRealizacion = resultado.FechaRealizacion;
            vm.ConsultorioId = resultado.ConsultorioId;

            return vm;
        }

        public async Task<List<ResultadoLaboratorioViewModel>> GetAllViewModel(int consultorioId)
        {
            var resultadoList = await _resultadoRepository.GetAllAsync(consultorioId);
            return resultadoList.Select(resultado => new ResultadoLaboratorioViewModel
            {
                Id = resultado.Id,
                PacienteNombre = resultado.Paciente.Nombre + " " + resultado.Paciente.Apellido,
                CedulaPaciente = resultado.Paciente.Cedula,
                NombrePrueba = resultado.PruebaLaboratorio.NombrePrueba,
                Estado = resultado.Estado,
                FechaRealizacion = resultado.FechaRealizacion
            }).ToList();
        }

        public async Task<List<ResultadoLaboratorioViewModel>> GetByCedulaViewModel(string cedula, int consultorioId)
        {
            var resultadoList = await _resultadoRepository.GetByCedulaAsync(cedula, consultorioId);
            return resultadoList.Select(resultado => new ResultadoLaboratorioViewModel
            {
                Id = resultado.Id,
                PacienteNombre = resultado.Paciente.Nombre + " " + resultado.Paciente.Apellido,
                CedulaPaciente = resultado.Paciente.Cedula,
                NombrePrueba = resultado.PruebaLaboratorio.NombrePrueba,
                Estado = resultado.Estado,
                FechaRealizacion = resultado.FechaRealizacion
            }).ToList();
        }
    }
}
