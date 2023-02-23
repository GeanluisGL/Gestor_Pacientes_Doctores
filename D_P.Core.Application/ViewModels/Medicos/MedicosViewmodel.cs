using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.VieiwModels.Medicos
{
    public class MedicosViewmodel
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? correo { get; set; }
        public string? Telefono { get; set; }
        public string? Cedula { get; set; }
        public string? FotoFileUrl { get; set; }


    }
}
