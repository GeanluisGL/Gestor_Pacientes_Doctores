using D_B.Core.Domain.Entities;
using D_P.Infrastucture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_P.Core.Application.Interfaces.Repository;

namespace D_P.Infrastucture.Persistence.Repositories
{
    public class MedicoRepository : GenericRepository<Medicos>, IMedicoRepository
    {
        private readonly ApplicationContext _dbContext;

        public MedicoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /* public async Task AddAsync(Medicos medicos)
         {
             await _dbContext.Set<Medicos>().AddAsync(medicos);
             await _dbContext.SaveChangesAsync();
         }

         public async Task UpdateAsync(Medicos medicos)
         {
             _dbContext.Entry(medicos).State = EntityState.Modified;
             await _dbContext.SaveChangesAsync();
         }

         public async Task DeleteAsync(Medicos medicos)
         {
             _dbContext.Set<Medicos>().Remove(medicos);
             await _dbContext.SaveChangesAsync();
         }

         public async Task<List<Medicos>> GetAllAsync()
         {
             return await _dbContext.Set<Medicos>().ToListAsync();
         }

         public async Task<Medicos> GetByIdAsync(int id)
         {

             return await _dbContext.Set<Medicos>().FindAsync(id);
         }*/
    }
}
