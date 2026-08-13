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
  public class FactoryRepository : GenericRepository<Factory, CommonDbContext>
  {
    public FactoryRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<Factory>> GetAllAsync(bool isContainDeleteFlag)
    {
      try
      {
        if (isContainDeleteFlag)
        {
          return await this.Context.Set<Factory>()
            .Include(x => x.Machines)
            .ToListAsync();
        }
        else
        {
          return await this.Context.Set<Factory>()
            .Where(x => !x.DeletedFlag)
            .Include(x => x.Machines)
            .ToListAsync();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
