using D_B.Core.Domain.Entities;
using D_P.Core.Application.Interfaces.Repository;
using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Medicos;
using D_P.Core.Application.VieiwModels.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace D_P.Core.Application.Services
{
    public class PacientesServices : IPacientesServices
    {
        private readonly IPacienteRepository _pacientesrepository;

        //Inyeccion de dependencia
        public PacientesServices(IPacienteRepository pacientesrepositoy)
        {
            _pacientesrepository = pacientesrepositoy;
        }

        public async Task Update(SavePacientesViewModel vm)
        {
            Pacientes Pacientes = await _pacientesrepository.GetByIdAsync(vm.Id);
            Pacientes.Id= vm.Id;
            Pacientes.Nombre = vm.Nombre;
            Pacientes.Apellido = vm.Apellido;
            Pacientes.Telefono = vm.Telefono;
            Pacientes.Direccion = vm.Direccion;
            Pacientes.Cedula = vm.Cedula;
            Pacientes.Fecha_Nacimiento = vm.Fecha_Nacimiento;
            Pacientes.Fumador = vm.Fumador;
            Pacientes.alergias = vm.alergias;
            Pacientes.FotoFileUrl = vm.FotoFileUrl;


            await _pacientesrepository.UpdateAsync(Pacientes);
        }

        public async Task<SavePacientesViewModel> Add(SavePacientesViewModel vm)
        {
            Pacientes Pacientes = new();
            Pacientes.Id = vm.Id;
            Pacientes.Nombre = vm.Nombre;
            Pacientes.Apellido = vm.Apellido;
            Pacientes.Telefono = vm.Telefono;
            Pacientes.Direccion = vm.Direccion;
            Pacientes.Cedula = vm.Cedula;
            Pacientes.Fecha_Nacimiento = vm.Fecha_Nacimiento;
            Pacientes.Fumador = vm.Fumador;
            Pacientes.alergias = vm.alergias;
            Pacientes.FotoFileUrl = vm.FotoFileUrl;


          Pacientes =  await _pacientesrepository.AddAsync(Pacientes);
        
            SavePacientesViewModel pacientesVm = new();
            pacientesVm.Id = Pacientes.Id;
            pacientesVm.Nombre = Pacientes.Nombre;
            pacientesVm.Apellido = Pacientes.Apellido;
            pacientesVm.Telefono = Pacientes.Telefono;
            pacientesVm.Direccion = Pacientes.Direccion;
            pacientesVm.Cedula = Pacientes.Cedula;
            pacientesVm.Fecha_Nacimiento = Pacientes.Fecha_Nacimiento;
            pacientesVm.Fumador = Pacientes.Fumador;
            pacientesVm.alergias = Pacientes.alergias;
            pacientesVm.FotoFileUrl = Pacientes.FotoFileUrl;

            return pacientesVm;
        }

        public async Task Delete(int id)
        {
            var pacientes = await _pacientesrepository.GetByIdAsync(id);
            await _pacientesrepository.DeleteAsync(pacientes);
        }

        public async Task<SavePacientesViewModel> GetByIdSaveViewModel(int id)
        {
            var pacientes = await _pacientesrepository.GetByIdAsync(id);

            SavePacientesViewModel vm = new();
            
            vm.Id = pacientes.Id;
            vm.Nombre = pacientes.Nombre;
            vm.Apellido = pacientes.Apellido;
            vm.Telefono = pacientes.Telefono;
            vm.Direccion = pacientes.Direccion;
            vm.Cedula = pacientes.Cedula;
            vm.Fecha_Nacimiento = pacientes.Fecha_Nacimiento;
            vm.Fumador = pacientes.Fumador;
            vm.alergias = pacientes.alergias;
            vm.FotoFileUrl = pacientes.FotoFileUrl;

            return vm;
        }

        /*Documentacion de lo donde me quedo
        Entendi de que manera se toman y se muestran en un view y su logica, hay que cambiar los tomadores como Medicos desde 
        un Icollection a un namevariable? y en los que dan como los doctores y pacientes, dejarlos como IColletion SEGUIR CON LEONARDO*/
        public async Task<List<PacientesViewModel>> GetAllViewModel()
        {
            var pacientesList = await _pacientesrepository.GetAllWithIncludeAsync(new List<string> { "resultados_Laboratorio", "citas" });

            return pacientesList.Select(pacientes => new PacientesViewModel
            {
            Nombre = pacientes.Nombre,
            Apellido = pacientes.Apellido,
            Telefono = pacientes.Telefono,
            Direccion = pacientes.Direccion,
            Cedula = pacientes.Cedula,
            Fecha_Nacimiento = pacientes.Fecha_Nacimiento,
            Fumador = pacientes.Fumador,
            alergias = pacientes.alergias,
            FotoFileUrl = pacientes.FotoFileUrl,
            Id = pacientes.Id,

        }).ToList();
        }


    }
 
}
