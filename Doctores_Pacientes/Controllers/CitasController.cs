using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Citas;
using D_P.Infrastucture.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Doctores_Pacientes.Controllers
{
    public class CitasController : Controller
    {

        private readonly ICitasServices _services;
        private readonly IPacientesServices _pacienteServices;
        private readonly IMedicosServices _medicosServices;

        public CitasController(ICitasServices services, IPacientesServices pacientesServices, IMedicosServices medicosServices)
        { 
            _services = services;
            _medicosServices = medicosServices;
            _pacienteServices = pacientesServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllViewModel());
        
        }

        #region Save
        public async Task<IActionResult> Save()
        {
            SaveCitaViewModel vm = new();
            vm.pacientes = await _pacienteServices.GetAllViewModel();
            vm.medicos = await _medicosServices.GetAllViewModel();



            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveCitaViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
                vm.pacientes = await _pacienteServices.GetAllViewModel();
                vm.medicos = await _medicosServices.GetAllViewModel();
              //  return View("Save", vm);
            //}

            await _services.Add(vm);
            return RedirectToRoute(new { controller = "Citas", action = "Index" });

        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            SaveCitaViewModel vm = await _services.GetByIdSaveViewModel(id);
            vm.pacientes = await _pacienteServices.GetAllViewModel();
            vm.medicos = await _medicosServices.GetAllViewModel();
            return View("Save",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveCitaViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            vm.pacientes = await _pacienteServices.GetAllViewModel();
            vm.medicos = await _medicosServices.GetAllViewModel();
                //return View("Save", vm);
            //}

            await _services.Update(vm);
            return RedirectToRoute(new { controller = "Citas", action = "Index" });
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _services.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _services.Delete(id);
            return RedirectToRoute(new { controller = "Citas", action = "Index" });
        }

        #endregion
    }
}
