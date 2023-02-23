using D_P.Core.Application.VieiwModels.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.Interfaces.Services
{
    public interface IPacientesServices : IGenericServices<SavePacientesViewModel, PacientesViewModel>
    {
    }
}
