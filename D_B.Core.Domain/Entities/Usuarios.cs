using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_B.Core.Domain.Entities
{
    public class Usuarios
    { 
        public int Id { get; set; }
        public string? Nombre {get; set;}
        public string? Apellido {get; set;}
        public string? Correo {get; set;}
        public string? Usuario {get; set;}
        public string? Contraseña {get; set;}
        public bool Rol  { get; set; }

    }
}
