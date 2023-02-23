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
    public class UsuariosRepository : GenericRepository<Usuarios>, IUsuariosRepository
    {
        private readonly ApplicationContext? _dbContext;

        public UsuariosRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Usuarios usuarios)
        {
            await _dbContext.Set<Usuarios>().AddAsync(usuarios);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuarios usuarios)
        {
            _dbContext.Entry(usuarios).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuarios usuarios)
        {
            _dbContext.Set<Usuarios>().Remove(usuarios);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Usuarios>> GetAllAsync()
        {
            return await _dbContext.Set<Usuarios>().ToListAsync();
        }

        public async Task<Usuarios> GetByIdAsync(int id)
        {

            return await _dbContext.Set<Usuarios>().FindAsync(id);
        }
    }
}

