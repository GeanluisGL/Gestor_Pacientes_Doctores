using D_P.Core.Application.VieiwModels.Citas;
using D_P.Core.Application.VieiwModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.Interfaces.Services
{
    public interface IUsuariosServices : IGenericServices<SaveUsuariosViewmodel, UsuariosViewModel>
    {
    }
}
