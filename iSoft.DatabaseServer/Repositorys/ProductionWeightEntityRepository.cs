using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using iSoft.DatabaseServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Repositorys
{
  public class ProductionWeightEntityRepository : GenericRepository<MaterialSettingEntity, CommonDbContext>
  {
    public ProductionWeightEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MaterialSettingEntity>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<MaterialSettingEntity>().AsNoTracking()
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<MaterialSettingEntity>().AsNoTracking()
              .Where(e => e.DeletedFlag == false)
              .ToListAsync();
      }
    }
  }
}
