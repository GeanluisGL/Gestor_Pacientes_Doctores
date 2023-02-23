using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_B.Core.Domain.Entities
{
    public class Resultados_Laboratorio 
    {
        public int Id { get; set; }
        public int? PacienteID { get; set;}
        public int PruebaLab { get; set;}
        public int? status { get; set;}

        //Navigaation Properties
        public Pacientes paciente { get; set; }
        public PruebaLaboratorio pruebaLaboratorio { get; set; }


    }
}
