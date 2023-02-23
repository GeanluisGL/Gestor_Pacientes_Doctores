using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.VieiwModels.Resultados_Laboral
{
    public class ResultadosLaboratorioViewModel
    {

        public int Id { get; set; }
        public string? PacienteName { get; set; }
        public string? PacienteApellido { get; set; }
        public string? PacienteCedula { get; set; }
        public int? PacienteID { get; set; }
        public string? PruebaLab { get; set; }
        public int? PruebaID { get; set; }
        public int? status { get; set; }

    }
}
