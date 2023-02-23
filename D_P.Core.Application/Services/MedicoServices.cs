    using D_B.Core.Domain.Entities;
using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Medicos;
using D_P.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_P.Core.Application.VieiwModels.Pacientes;

namespace D_P.Core.Application.Services
{
    public class MedicoServices : IMedicosServices
    {
        private readonly IMedicoRepository _medicosrepository;

        //Inyeccion de dependencia
        public MedicoServices(IMedicoRepository medicosrepositoy)
        {
            _medicosrepository = medicosrepositoy;
        }

        public async Task Update(SaveMedicosViewModel vm)
        {
            Medicos Medicos = await _medicosrepository.GetByIdAsync(vm.Id);
            Medicos.Id = vm.Id;
            Medicos.Nombre = vm.Nombre;
            Medicos.Apellido = vm.Apellido;
            Medicos.Cedula = vm.Cedula;
            Medicos.correo = vm.correo;
            Medicos.Telefono = vm.Telefono;
            Medicos.FotoFileUrl = vm.FotoFileUrl;


            await _medicosrepository.UpdateAsync(Medicos);
        }

        public async Task<SaveMedicosViewModel> Add(SaveMedicosViewModel vm)
        {
            Medicos Medicos = new();
            Medicos.Nombre = vm.Nombre;
            Medicos.Apellido = vm.Apellido;
            Medicos.Cedula = vm.Cedula;
            Medicos.correo = vm.correo;
            Medicos.Telefono = vm.Telefono;
            Medicos.FotoFileUrl = vm.FotoFileUrl;
            Medicos.Id = vm.Id;

            Medicos = await _medicosrepository.AddAsync(Medicos);

            SaveMedicosViewModel Medicosvm = new();
            Medicosvm.Nombre = Medicos.Nombre;
            Medicosvm.Apellido = Medicos.Apellido;
            Medicosvm.Cedula = Medicos.Cedula;
            Medicosvm.correo = Medicos.correo;
            Medicosvm.Telefono = Medicos.Telefono;
            Medicosvm.FotoFileUrl = Medicos.FotoFileUrl;
            Medicosvm.Id = Medicos.Id;

            return Medicosvm;
        }

        public async Task Delete(int id)
        {
            var Medicos = await _medicosrepository.GetByIdAsync(id);
            await _medicosrepository.DeleteAsync(Medicos);
        }

        public async Task<SaveMedicosViewModel> GetByIdSaveViewModel(int id)
        {
            var Medicos = await _medicosrepository.GetByIdAsync(id);

            SaveMedicosViewModel vm = new();
            vm.Id = Medicos.Id;
            vm.Nombre = Medicos.Nombre;
            vm.Apellido = Medicos.Apellido;
            vm.Cedula= Medicos.Cedula;
            vm.correo = Medicos.correo;
            vm.Telefono = Medicos.Telefono;
            vm.FotoFileUrl = Medicos.FotoFileUrl;


            return vm;
        }

        /*Documentacion de lo donde me quedo
        Entendi de que manera se toman y se muestran en un view y su logica, hay que cambiar los tomadores como Medicos desde 
        un Icollection a un namevariable? y en los que dan como los doctores y pacientes, dejarlos como IColletion SEGUIR CON LEONARDO*/
        public async Task<List<MedicosViewmodel>> GetAllViewModel()
        {
            var medicoList = await _medicosrepository.GetAllWithIncludeAsync(new List<string> { "citas" });

            return medicoList.Select(Medicos => new MedicosViewmodel
            {
            Id = Medicos.Id, 
            Nombre = Medicos.Nombre,
            Apellido = Medicos.Apellido,
            Cedula = Medicos.Cedula,
            correo = Medicos.correo,
            Telefono = Medicos.Telefono,
            FotoFileUrl = Medicos.FotoFileUrl,


        }).ToList();
        }


       }
}
