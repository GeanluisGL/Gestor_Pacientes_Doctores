using D_B.Core.Domain.Entities;
using D_P.Infrastucture.Persistence.Repositories;

namespace D_P.Core.Application.Interfaces.Repository

{
    public interface ICitaRepository : IGenericRepository<Citas>
    {
        //Task AddAsync(Citas citas);
        //Task DeleteAsync(Citas citas);
        //Task<List<Citas>> GetAllAsync();
        //Task<Citas> GetByIdAsync(int id);
        //Task UpdateAsync(Citas citas);
    }
}