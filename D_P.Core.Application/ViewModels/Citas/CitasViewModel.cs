using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.VieiwModels.Citas
{
    public class CitasViewModel
    {

        public int Id { get; set; }
        
        //Foreing Keys
        public int? NombrePacienteID { get; set; }
        public string? NombrePacientes { get; set; }

        public int? NombreDoctorID { get; set; }
        
        public string? NombreDoctor { get; set; }
        //End
        public DateTime? FechaHora { get; set; }
        public string? Causa { get; set; }
        public int? Estado { get; set; }
        public string? DescripccionEstado { get; set; }

    }
}
