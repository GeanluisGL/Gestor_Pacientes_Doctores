using D_P.Core.Application.VieiwModels.Citas;
using D_P.Infrastucture.Persistence.Repositories;

namespace D_P.Core.Application.Interfaces.Services
{
    public interface ICitasServices : IGenericServices<SaveCitaViewModel, CitasViewModel>
    {
    }
}