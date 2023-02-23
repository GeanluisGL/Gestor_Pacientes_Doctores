using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_B.Core.Domain.Entities
{
    public class PruebaLaboratorio 
    {
        public int Id { get; set; }
        public string? Prueba_Nombre { get; set; }

        public ICollection<Resultados_Laboratorio>? resultados_Laboratorios { get; set; }
    }
}
