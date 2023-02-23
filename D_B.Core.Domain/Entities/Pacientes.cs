using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_B.Core.Domain.Entities
{
    public class Pacientes 
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Cedula { get; set; }
        public string? Fecha_Nacimiento { get; set; }
        public bool? Fumador { get; set; }
        public bool? alergias { get; set;}
        public string? FotoFileUrl { get; set; }


        public ICollection<Resultados_Laboratorio>? resultados_Laboratorio { get; set; }
        public ICollection<Citas>? citas { get; set; }
    }

}
