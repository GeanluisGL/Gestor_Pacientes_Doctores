using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_B.Core.Domain.Entities
{
    public class Citas 
    {
        public int Id { get; set; }
        public int? NombrePacienteID { get; set; }
        public int? NombreDoctorID { get; set; }
        public DateTime? FechaHora { get; set; }
        public string? Causa { get; set; } 
        public int? Estado { get; set; }
        public string? DescripccionEstado { get; set; }
    
    public  Pacientes? paciente { get; set; }

    public  Medicos? medico { get; set; }

    }
}
