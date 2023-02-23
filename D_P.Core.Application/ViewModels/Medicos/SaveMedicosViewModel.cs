using D_P.Core.Application.VieiwModels.Citas;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.VieiwModels.Medicos
{
    public class SaveMedicosViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Debe colocar el nombre del doctor")]
        public string? Nombre { get; set; }
        
        [Required(ErrorMessage = "Debe colocar el apellido del doctor")]
        public string? Apellido { get; set; }
        
        [Required(ErrorMessage = "Debe colocar el correo del doctor")]
        public string? correo { get; set; }
        
        [Required(ErrorMessage = "Debe colocar el telefono del doctor")]
        public string? Telefono { get; set; }
        
        [Required(ErrorMessage = "Debe colocar la cedula del doctor")]
        public string? Cedula { get; set; }

         
        public string? FotoFileUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Ffile { get; set; }

        public List<CitasViewModel>? citas { get; set; }
    }
}
