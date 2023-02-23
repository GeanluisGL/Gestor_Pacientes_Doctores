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
    public class ResultadosLRepository : GenericRepository<Resultados_Laboratorio>, IResultadosLRepository
    {
        private readonly ApplicationContext? _dbContext;

        public ResultadosLRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       /*
         public async Task AddAsync(Resultados_Laboratorio resultados)
          {
              await _dbContext.Set<Resultados_Laboratorio>().AddAsync(resultados);
              await _dbContext.SaveChangesAsync();
          }

          public async Task UpdateAsync(Resultados_Laboratorio resultados)
          {
              _dbContext.Entry(resultados).State = EntityState.Modified;
              await _dbContext.SaveChangesAsync();
          }

          public async Task DeleteAsync(Resultados_Laboratorio resultados)
          {
              _dbContext.Set<Resultados_Laboratorio>().Remove(resultados);
              await _dbContext.SaveChangesAsync();
          }

          public async Task<List<Resultados_Laboratorio>> GetAllAsync()
          {
              return await _dbContext.Set<Resultados_Laboratorio>().ToListAsync();
          }

          public async Task<List<Resultados_Laboratorio>> GetAllAsyncIncludeA()
          {
             return await _dbContext.Set<Resultados_Laboratorio>().Include(p => p.paciente).Include(g => g.pruebaLaboratorio  ).ToListAsync();
          }

          public async Task<Resultados_Laboratorio> GetByIdAsync(int id)
          {

              return await _dbContext.Set<Resultados_Laboratorio>().FindAsync(id);
          }*/
    }

}


