using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.VieiwModels.Usuarios
{
    public class SaveUsuariosViewmodel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Nombre { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Apellido { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Correo { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Usuario { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Contraseña { get; set; }
        public bool Rol { get; set; }

    }
}
