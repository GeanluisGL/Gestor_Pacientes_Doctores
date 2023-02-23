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
    public class PacienteRepository : GenericRepository<Pacientes>, IPacienteRepository
    {
        private readonly ApplicationContext? _dbContext;

        public PacienteRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

    /*    public async Task AddAsync(Pacientes pacientes)
        {
            await _dbContext.Set<Pacientes>().AddAsync(pacientes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pacientes pacientes)
        {
            _dbContext.Entry(pacientes).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pacientes pacientes)
        {
            _dbContext.Set<Pacientes>().Remove(pacientes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pacientes>> GetAllViewModel()
        {
            return await _dbContext.Set<Pacientes>().ToListAsync();
        }

        public async Task<Pacientes> GetByIdAsync(int id)
        {

            return await _dbContext.Set<Pacientes>().FindAsync(id);
        }*/
    }

}
