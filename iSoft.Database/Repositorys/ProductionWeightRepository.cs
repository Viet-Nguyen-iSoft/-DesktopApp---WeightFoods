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
  public class ProductionWeightRepository : GenericRepository<MaterialSetting, CommonDbContext>
  {
    public ProductionWeightRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MaterialSetting>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<MaterialSetting>().AsNoTracking()
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<MaterialSetting>().AsNoTracking()
              .Where(e => !e.DeletedFlag)
              .ToListAsync();
      }
    }
  }

}
