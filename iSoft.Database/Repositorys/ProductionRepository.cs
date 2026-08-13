using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Repositorys
{
  public class ProductionRepository : GenericRepository<Production, CommonDbContext>
  {
    public ProductionRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<Production>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<Production>().AsNoTracking()
              .Include(x => x.Materials)
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<Production>().AsNoTracking()
              .Where(e => !e.DeletedFlag)
              .Include(x => x.Materials)
              .ToListAsync();
      }
    }

    public async Task<Production?> GetProductionByIdSrcAsync(Guid? guid)
    {
      return await this.Context.Set<Production>().AsNoTracking()
                     .Where(x => x.IdSrc == guid)
                     .FirstOrDefaultAsync();
    }

  }
}
