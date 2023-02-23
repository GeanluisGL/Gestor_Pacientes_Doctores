using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.PruebaLaboratorio;
using Microsoft.AspNetCore.Mvc;

namespace Doctores_Pacientes.Controllers
{
    public class PruebasLController : Controller
    {
        private readonly IpruebaLaboratorioServices _pruebaLaboratorio;

        public PruebasLController(IpruebaLaboratorioServices pruebaLaboratorioServices) 
        { 
            _pruebaLaboratorio= pruebaLaboratorioServices;
        } 

        public async Task<IActionResult> Index()
        {
            return View(await _pruebaLaboratorio.GetAllViewModel());
        }

        public IActionResult Save()
        {
            return View("Save", new SavePruebasViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Save(SavePruebasViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            await _pruebaLaboratorio.Add(vm);
            return RedirectToRoute(new { controller = "PruebasL", action = "Index" });

        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("Save", await _pruebaLaboratorio.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePruebasViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            await _pruebaLaboratorio.Update(vm);
            return RedirectToRoute(new { controller = "PruebasL", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pruebaLaboratorio.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _pruebaLaboratorio.Delete(id);
            return RedirectToRoute(new { controller = "PruebasL", action = "Index" });
        }

      
    }
}
