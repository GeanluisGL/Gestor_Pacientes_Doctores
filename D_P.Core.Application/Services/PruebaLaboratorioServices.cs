using D_B.Core.Domain.Entities;
using D_P.Core.Application.Interfaces.Repository;
using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Citas;
using D_P.Core.Application.VieiwModels.Pacientes;
using D_P.Core.Application.VieiwModels.PruebaLaboratorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.Services
{
    public class PruebaLaboratorioServices : IpruebaLaboratorioServices
    {
        private readonly IPruebaLaboratorioRepository _pruebaLaboratorioRepository;

        //Inyeccion de dependencia
        public PruebaLaboratorioServices(IPruebaLaboratorioRepository pruebaLaboratorioRepository)
        {
            _pruebaLaboratorioRepository = pruebaLaboratorioRepository;
        }

        public async Task Update(SavePruebasViewModel vm)
        {
            PruebaLaboratorio prueba = await _pruebaLaboratorioRepository.GetByIdAsync(vm.Id);
            prueba.Id = vm.Id;
            prueba.Prueba_Nombre = vm.Prueba_Nombre;
           


            await _pruebaLaboratorioRepository.UpdateAsync(prueba);
        }

        public async Task<SavePruebasViewModel> Add(SavePruebasViewModel vm)
        {
            PruebaLaboratorio prueba = new();
            prueba.Id = vm.Id;
            prueba.Prueba_Nombre = vm.Prueba_Nombre;

            prueba = await _pruebaLaboratorioRepository.AddAsync(prueba);

            SavePruebasViewModel pruebavm = new();
            pruebavm.Id = prueba.Id;
            pruebavm.Prueba_Nombre = prueba.Prueba_Nombre;


            return pruebavm;
        }

        public async Task Delete(int id)
        {
            var Medicos = await _pruebaLaboratorioRepository.GetByIdAsync(id);
            await _pruebaLaboratorioRepository.DeleteAsync(Medicos);
        }

        public async Task<SavePruebasViewModel> GetByIdSaveViewModel(int id)
        {
            var prueba = await _pruebaLaboratorioRepository.GetByIdAsync(id);

            SavePruebasViewModel vm = new();

            vm.Id = prueba.Id;
            vm.Prueba_Nombre = prueba.Prueba_Nombre;
            

            return vm;
        }

        /*Documentacion de lo donde me quedo
        Entendi de que manera se toman y se muestran en un view y su logica, hay que cambiar los tomadores como Medicos desde 
        un Icollection a un namevariable? y en los que dan como los doctores y pacientes, dejarlos como IColletion SEGUIR CON LEONARDO*/
        public async Task<List<PruebasViewModel>> GetAllViewModel()
        {
            var pruebalList = await _pruebaLaboratorioRepository.GetAllWithIncludeAsync(new List<string> { "resultados_Laboratorios" });

            return pruebalList.Select(prueba => new PruebasViewModel
            {
                Prueba_Nombre = prueba.Prueba_Nombre,
                Id = prueba.Id,
            }).ToList();


        }

    }
}
