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
    public class PruebaLaboratorioRepository : GenericRepository<PruebaLaboratorio>, IPruebaLaboratorioRepository
    {
        private readonly ApplicationContext? _dbContext;

        public PruebaLaboratorioRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       /* public async Task AddAsync(PruebaLaboratorio pruebaLaboratorio)
        {
            await _dbContext.Set<PruebaLaboratorio>().AddAsync(pruebaLaboratorio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PruebaLaboratorio pruebaLaboratorio)
        {
            _dbContext.Entry(pruebaLaboratorio).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PruebaLaboratorio pruebaLaboratorio)
        {
            _dbContext.Set<PruebaLaboratorio>().Remove(pruebaLaboratorio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<PruebaLaboratorio>> GetAllAsync()
        {
            return await _dbContext.Set<PruebaLaboratorio>().ToListAsync();
        }

        public async Task<PruebaLaboratorio> GetByIdAsync(int id)
        {

            return await _dbContext.Set<PruebaLaboratorio>().FindAsync(id);
        }*/
    }


}
