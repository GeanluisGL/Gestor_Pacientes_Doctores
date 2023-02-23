using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.VieiwModels.Pacientes
{
    public class SavePacientesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del paciente")]
        [DataType(DataType.Text)]
        public string? Nombre { get; set; }


        [Required(ErrorMessage = "Debe colocar apellido del paciente")]
        [DataType(DataType.Text)]
        public string? Apellido { get; set; }
        

        [Required(ErrorMessage = "Debe colocar el telefono del paciente")]
        [DataType(DataType.Text)]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Debe colocar la direccion del paciente")]
        [DataType(DataType.Text)]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Debe colocar la cedula del paciente")]
        [DataType(DataType.Text)]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "Debe colocar la fecha de nacimiento del paciente")]
        [DataType(DataType.Date)]
        public string? Fecha_Nacimiento { get; set; }

        public bool? Fumador { get; set; }
        public bool? alergias { get; set; }
        public string? FotoFileUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Ffile { get; set; }
    }
}
