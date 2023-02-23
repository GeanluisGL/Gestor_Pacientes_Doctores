using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace Doctores_Pacientes.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacientesServices _pacientesServices;

        public PacientesController(IPacientesServices pacientesServices) 
        {
            _pacientesServices = pacientesServices;
        } 

        public async Task<IActionResult> Index()
        {
            return View(await _pacientesServices.GetAllViewModel());
        }

        public IActionResult Save()
        {
            return View("Save", new SavePacientesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Save(SavePacientesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            SavePacientesViewModel pacientevm = await _pacientesServices.Add(vm);
            if(pacientevm != null && pacientevm.Id != 0)
            {
                pacientevm.FotoFileUrl = UploadFile(vm.Ffile, pacientevm.Id);
                await _pacientesServices.Update(pacientevm);
            }
            
            
            return RedirectToRoute(new { controller = "Pacientes", action = "Index" });


        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("Save", await _pacientesServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePacientesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            //Para actualizar las fotos y se quede con la misma url que en la base de datos
            SavePacientesViewModel pacientevm = await _pacientesServices.GetByIdSaveViewModel(vm.Id);
            vm.FotoFileUrl = UploadFile(vm.Ffile, pacientevm.Id, true, pacientevm.FotoFileUrl); 

            await _pacientesServices.Update(vm);
            return RedirectToRoute(new { controller = "Pacientes", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pacientesServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _pacientesServices.Delete(id);

            //Localizo el archivo
            string basePath = $"/Images/Pacientes/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //Si existe la ruta buscada
            if(Directory.Exists(path))
            {
                //Para cada archivo de foto
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach(FileInfo file in directoryInfo.GetFiles())
                {
                    //Borra la foto
                    file.Delete();
                }

                //Con la carpeta
                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    //Borra la carpeta
                    folder.Delete(true);
                }

                //Borra la ruta
                Directory.Delete(path);
            }

            return RedirectToRoute(new { controller = "Pacientes", action = "Index" });
        }

        private string UploadFile(IFormFile file, int Id, bool ? isEditMode = false, string imageUrl = "")
        {
            if((bool)isEditMode )
            {
                if(file == null)
                {
                return imageUrl; 
                }
            }  

            //Proceso para mandar a guardad la imagen en base a un base path que es el que se aloja en el equipo base
            string basePath = $"/Images/Pacientes/{Id}";
            //Y el path que es el que lo devuelve desde la vista 
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //Create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Da un nombre unico a la imagen al guardarla
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new FileInfo(path);
            string fileName = guid + fileInfo.Extension;

            string filenamewithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(filenamewithPath, FileMode.Create))
            {
                file.CopyTo(stream);

            }

            //Para borrar la vieja imagen en el momento de actualizarla
            if ((bool)isEditMode)
            {

                //El [^1] se utiliza para señalar la ultima posicion
                string[] oldImagePath = imageUrl.Split('/');
                string OldImageP = oldImagePath[^1];
                string completeImageOldPath = Path.Combine(path, OldImageP);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);    
                }
            }
                return $"{basePath}/{fileName}";
        }
    }
}
