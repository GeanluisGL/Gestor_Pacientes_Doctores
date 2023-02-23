using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Medicos;
using Microsoft.AspNetCore.Mvc;

namespace Doctores_Pacientes.Controllers
{
    public class MedicosController  : Controller
    {
        private readonly IMedicosServices _medicosServices;

        public MedicosController(IMedicosServices medicosServices) 
        {
            _medicosServices = medicosServices;
        } 

        public async Task<IActionResult> Index()
        {
            return View(await _medicosServices.GetAllViewModel());
        }

        public IActionResult Save()
        {
            return View("Save", new SaveMedicosViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveMedicosViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            SaveMedicosViewModel medicosevm = await _medicosServices.Add(vm);
            if(medicosevm != null && medicosevm.Id != 0)
            {
                medicosevm.FotoFileUrl = UploadFile(vm.Ffile, medicosevm.Id);
                await _medicosServices.Update(medicosevm);
            }
            
            
            return RedirectToRoute(new { controller = "Medicos", action = "Index" });


        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("Save", await _medicosServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveMedicosViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            //Para actualizar las fotos y se quede con la misma url que en la base de datos
            SaveMedicosViewModel medicosvm = await _medicosServices.GetByIdSaveViewModel(vm.Id);
            vm.FotoFileUrl = UploadFile(vm.Ffile, medicosvm.Id, true, medicosvm.FotoFileUrl); 

            await _medicosServices.Update(vm);
            return RedirectToRoute(new { controller = "Medicos", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _medicosServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _medicosServices.Delete(id);

            //Localizo el archivo
            string basePath = $"/Images/Doctores/{id}";
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

            return RedirectToRoute(new { controller = "Medicos", action = "Index" });
        }

        private string UploadFile(IFormFile file, int Id, bool? isEditMode = false, string imageUrl = "")
        {
            if ((bool)isEditMode)
            {
                if (file == null)
                {
                    return imageUrl;
                }
            }

            //Proceso para mandar a guardad la imagen en base a un base path que es el que se aloja en el equipo base
            string basePath = $"/Images/Doctores/{Id}";
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
