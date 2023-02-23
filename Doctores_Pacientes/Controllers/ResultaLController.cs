    using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.PruebaLaboratorio;
using D_P.Core.Application.VieiwModels.Resultados_Laboral;
using Microsoft.AspNetCore.Mvc;

namespace Doctores_Pacientes.Controllers
{
    public class ResultaLController : Controller
    {
        private readonly IResultadoLaboratorioServices _resultLaboratorioServices;
        private readonly IpruebaLaboratorioServices _pruebaLServices;
        private readonly IPacientesServices _pacienteServices;


        public ResultaLController(IResultadoLaboratorioServices resultLaboratorioServices, IpruebaLaboratorioServices pruebaLaboratorio, IPacientesServices pacientesServices) 
        { 
            _resultLaboratorioServices= resultLaboratorioServices;
            _pruebaLServices = pruebaLaboratorio;
            _pacienteServices = pacientesServices;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _resultLaboratorioServices.GetAllViewModel());
        }


        #region Save
        public async Task<IActionResult> Save()
        {
            SaveResultadoLaboratorioViewModel vm = new();
            vm.pacientes = await _pacienteServices.GetAllViewModel();
            vm.prueba = await _pruebaLServices.GetAllViewModel();



            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveResultadoLaboratorioViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
                vm.pacientes = await _pacienteServices.GetAllViewModel();
                vm.prueba = await _pruebaLServices.GetAllViewModel();
              //  return View("Save", vm);
            //}

            await _resultLaboratorioServices.Add(vm);
            return RedirectToRoute(new { controller = "ResultaL", action = "Index" });

        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            SaveResultadoLaboratorioViewModel vm = await _resultLaboratorioServices.GetByIdSaveViewModel(id);
            vm.pacientes = await _pacienteServices.GetAllViewModel();
            vm.prueba = await _pruebaLServices.GetAllViewModel();
            return View("Save",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveResultadoLaboratorioViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            vm.pacientes = await _pacienteServices.GetAllViewModel();
            vm.prueba = await _pruebaLServices.GetAllViewModel();
                //return View("Save", vm);
            //}

            await _resultLaboratorioServices.Update(vm);
            return RedirectToRoute(new { controller = "ResultaL", action = "Index" });
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _resultLaboratorioServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _resultLaboratorioServices.Delete(id);
            return RedirectToRoute(new { controller = "ResultaL", action = "Index" });
        }

        #endregion
    }
}
