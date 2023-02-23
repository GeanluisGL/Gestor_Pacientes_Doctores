using D_B.Core.Domain.Entities;
using D_P.Infrastucture.Persistence.Repositories;

namespace D_P.Core.Application.Interfaces.Repository

{
    public interface IPacienteRepository : IGenericRepository<Pacientes>
    {
        //Task AddAsync(Pacientes pacientes);
        //Task DeleteAsync(Pacientes pacientes);
        //Task<List<Pacientes>> GetAllViewModel();
        //Task<Pacientes> GetByIdAsync(int id);
        //Task UpdateAsync(Pacientes pacientes);
    }
}