using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using D_P.Core.Application.VieiwModels.Medicos;
using D_P.Core.Application.VieiwModels.Pacientes;

namespace D_P.Core.Application.VieiwModels.Citas
{
    public class SaveCitaViewModel
    {
        public int Id { get; set; }
        
        //Foreing Key
        [Range(1, int.MaxValue, ErrorMessage = "Campo obligatorio")]
        public int? NombrePacienteID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Campo obligatorio")]
        public int? NombreDoctorID { get; set; }
        //End

        public DateTime? FechaHora { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string? Causa { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Campo obligatorio")]
        public int? Estado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string? DescripccionEstado { get; set; }
    
        public List<MedicosViewmodel>? medicos { get; set; }
        public List<PacientesViewModel>? pacientes { get; set; }

    }
}
