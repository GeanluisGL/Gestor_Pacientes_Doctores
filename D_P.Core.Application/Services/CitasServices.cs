using D_B.Core.Domain.Entities;
using D_P.Core.Application.Interfaces.Repository;
using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Citas;
using D_P.Core.Application.VieiwModels.Medicos;
using D_P.Infrastucture.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.Services
{
    public class CitasServices : ICitasServices
    {
        private readonly ICitaRepository _citaRepository;

        //Inyeccion de dependencia
        public CitasServices(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public async Task Update(SaveCitaViewModel vm)
        {
            Citas citas = await _citaRepository.GetByIdAsync(vm.Id);
            citas.Id = vm.Id;
            citas.NombrePacienteID = vm.NombrePacienteID;
            citas.NombreDoctorID = vm.NombreDoctorID;
            citas.FechaHora = vm.FechaHora;
            citas.Causa = vm.Causa;
            citas.Estado = vm.Estado;
            citas.DescripccionEstado = vm.DescripccionEstado;

            await _citaRepository.UpdateAsync(citas);
        }

        public async Task<SaveCitaViewModel> Add(SaveCitaViewModel vm)
        {
            Citas citas = new();
            citas.NombrePacienteID = vm.NombrePacienteID;
            citas.NombreDoctorID = vm.NombreDoctorID;
            citas.FechaHora = vm.FechaHora;
            citas.Causa = vm.Causa;
            citas.Estado = vm.Estado;
            citas.DescripccionEstado = vm.DescripccionEstado;
            citas.Id = vm.Id;

            citas = await _citaRepository.AddAsync(citas);

            SaveCitaViewModel citasvm = new();
            citasvm.NombrePacienteID = citas.NombrePacienteID;
            citasvm.NombreDoctorID = citas.NombreDoctorID;
            citasvm.FechaHora = citas.FechaHora;
            citasvm.Causa = citas.Causa;
            citasvm.Estado = citas.Estado;
            citasvm.DescripccionEstado = citas.DescripccionEstado;

            return citasvm;
        }

        public async Task Delete(int id)
        {
            var citas = await _citaRepository.GetByIdAsync(id);
            await _citaRepository.DeleteAsync(citas);
        }

        public async Task<SaveCitaViewModel> GetByIdSaveViewModel(int id)
        {
            var citas = await _citaRepository.GetByIdAsync(id);

            SaveCitaViewModel vm = new();
            vm.Id = citas.Id;
            vm.NombrePacienteID = citas.NombrePacienteID;
            vm.NombreDoctorID = citas.NombreDoctorID;
            vm.FechaHora = citas.FechaHora;
            vm.Causa = citas.Causa;
            vm.Estado = citas.Estado;
            vm.DescripccionEstado = citas.DescripccionEstado;

            return vm;
        }

        /*Documentacion de lo donde me quedo
        Entendi de que manera se toman y se muestran en un view y su logica, hay que cambiar los tomadores como citas desde 
        un Icollection a un namevariable? y en los que dan como los doctores y pacientes, dejarlos como IColletion SEGUIR CON LEONARDO*/
        public async Task<List<CitasViewModel>> GetAllViewModel()
        {
            var citaList = await _citaRepository.GetAllWithIncludeAsync(new List<string> { "paciente", "medico" });

            return citaList.Select(citas => new CitasViewModel
            {
                NombrePacienteID = citas.paciente.Id,
                NombreDoctorID = citas.medico.Id,
                NombreDoctor = citas.medico.Nombre,
                NombrePacientes = citas.paciente.Nombre,
                Id = citas.Id,
                FechaHora = citas.FechaHora,
                Causa = citas.Causa,
                Estado = citas.Estado,
                DescripccionEstado = citas.DescripccionEstado

                

            }).ToList();
        }

     
    }
}
