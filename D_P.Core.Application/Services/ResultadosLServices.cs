using D_B.Core.Domain.Entities;
using D_P.Core.Application.Interfaces.Repository;
using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Medicos;
using D_P.Core.Application.VieiwModels.PruebaLaboratorio;
using D_P.Core.Application.VieiwModels.Resultados_Laboral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.Services
{
    public class ResultadosLServices : IResultadoLaboratorioServices
    {
        private readonly IResultadosLRepository _resultadosLaboratoriorepository;

        //Inyeccion de dependencia
        public ResultadosLServices(IResultadosLRepository resultadosLaboratorio)
        {
            _resultadosLaboratoriorepository = resultadosLaboratorio;
        }

        public async Task Update(SaveResultadoLaboratorioViewModel vm)
        {
            Resultados_Laboratorio resultados_Laboratorio = await _resultadosLaboratoriorepository.GetByIdAsync(vm.Id);
            resultados_Laboratorio.Id = vm.Id;
            resultados_Laboratorio.PacienteID = vm.PacienteID;
            resultados_Laboratorio.PruebaLab = vm.PruebaLab;
            resultados_Laboratorio.status = vm.status;
            await _resultadosLaboratoriorepository.UpdateAsync(resultados_Laboratorio);
        }

        public async Task<SaveResultadoLaboratorioViewModel> Add(SaveResultadoLaboratorioViewModel vm)
        {
            Resultados_Laboratorio resultados_Laboratorio = new();
            resultados_Laboratorio.Id = vm.Id;
            resultados_Laboratorio.PacienteID = vm.PacienteID;
            resultados_Laboratorio.PruebaLab = vm.PruebaLab;
            resultados_Laboratorio.status = vm.status;


            resultados_Laboratorio = await _resultadosLaboratoriorepository.AddAsync(resultados_Laboratorio);

            SaveResultadoLaboratorioViewModel resultados_Laboratoriovm = new();
            resultados_Laboratoriovm.Id = resultados_Laboratorio.Id;
            resultados_Laboratoriovm.PacienteID = resultados_Laboratorio.PacienteID;
            resultados_Laboratoriovm.PruebaLab = resultados_Laboratorio.PruebaLab;
            resultados_Laboratoriovm.status = resultados_Laboratorio.status;

            return resultados_Laboratoriovm;
        }

        public async Task Delete(int id)
        {
            var resultados_Laboratorio = await _resultadosLaboratoriorepository.GetByIdAsync(id);
            await _resultadosLaboratoriorepository.DeleteAsync(resultados_Laboratorio);
        }

        public async Task<SaveResultadoLaboratorioViewModel> GetByIdSaveViewModel(int id)
        {
            var resulT = await _resultadosLaboratoriorepository.GetByIdAsync(id);

            SaveResultadoLaboratorioViewModel vm = new();
            vm.Id = resulT.Id;
            vm.PacienteID = resulT.PacienteID;
            vm.PruebaLab = resulT.PruebaLab;
            vm.status = resulT.status;
            
            return vm;
        }

        /*Documentacion de lo donde me quedo
        Entendi de que manera se toman y se muestran en un view y su logica, hay que cambiar los tomadores como Medicos desde 
        un Icollection a un namevariable? y en los que dan como los doctores y pacientes, dejarlos como IColletion SEGUIR CON LEONARDO*/
        public async Task<List<ResultadosLaboratorioViewModel>> GetAllViewModel()
        {
            var ResultadosList = await _resultadosLaboratoriorepository.GetAllWithIncludeAsync(new List<string> { "paciente", "pruebaLaboratorio" });

            return ResultadosList.Select(result => new ResultadosLaboratorioViewModel
            {
              Id = result.Id,
              PacienteID = result.paciente.Id,
              PacienteName = result.paciente.Nombre,
              PacienteApellido = result.paciente.Apellido,
              PacienteCedula = result.paciente.Cedula,
              PruebaLab = result.pruebaLaboratorio.Prueba_Nombre,
              PruebaID = result.pruebaLaboratorio.Id,
              status = result.status
            }).ToList();
        }


    }
}
