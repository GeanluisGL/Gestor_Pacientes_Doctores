using D_B.Core.Domain.Entities;
using D_P.Infrastucture.Persistence.Repositories;

namespace D_P.Core.Application.Interfaces.Repository
{
    public interface IMedicoRepository : IGenericRepository<Medicos>
    {
        //Task AddAsync(Medicos medicos);
        //Task DeleteAsync(Medicos medicos);
        //Task<List<Medicos>> GetAllAsync();
        //Task<Medicos> GetByIdAsync(int id);
        //Task UpdateAsync(Medicos medicos);
    }
}