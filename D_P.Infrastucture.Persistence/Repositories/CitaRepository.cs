using D_B.Core.Domain.Entities;
using D_P.Infrastucture.Persistence.Contexts;
using D_P.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_P.Core.Application.Interfaces.Repository;

namespace D_P.Infrastucture.Persistence.Repositories
{
    public class CitaRepository : GenericRepository<Citas>, ICitaRepository
    {
        private readonly ApplicationContext? _dbContext;

        public CitaRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       /* public async Task AddAsync(Citas citas)
        {
            await _dbContext.Set<Citas>().AddAsync(citas);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Citas citas)
        {
            _dbContext.Entry(citas).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Citas citas)
        {
            _dbContext.Set<Citas>().Remove(citas);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Citas>> GetAllAsync()
        {
            return await _dbContext.Set<Citas>().Include(m => m.medico).Include(p => p.paciente).ToListAsync();
        }

        public async Task<Citas> GetByIdAsync(int id)
        {

            return await _dbContext.Set<Citas>().FindAsync(id);
        }*/
    }
}
