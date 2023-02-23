using D_P.Core.Application.VieiwModels.Pacientes;
using D_P.Core.Application.VieiwModels.PruebaLaboratorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace D_P.Core.Application.VieiwModels.Resultados_Laboral
{
    public class SaveResultadoLaboratorioViewModel
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el paciente")]
        public int? PacienteID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la prueba")]
        public int PruebaLab { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar estado la prueba")]
        public int? status { get; set; }
        public List<PacientesViewModel> pacientes { get; set; }
        public List<PruebasViewModel> prueba { get; set; }

     
    }
}
