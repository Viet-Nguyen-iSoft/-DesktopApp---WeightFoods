using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Repositorys
{
  public class ProductionOrderEntityRepository : GenericRepository<ProductionOrderEntity, CommonDbContext>
  {
    public ProductionOrderEntityRepository(DbContext context) : base(context)
    {

    }
    public async Task<List<ProductionOrderEntity>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<ProductionOrderEntity>().AsNoTracking()
              //.Include(x=>x.Materials)
              //.Include(x=>x.Productions)
              .Include(x=>x.MaterialSettings)
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<ProductionOrderEntity>().AsNoTracking()
              .Where(e => e.DeletedFlag == false)
              //.Include(x => x.Materials)
              //.Include(x => x.Productions)
              .Include(x => x.MaterialSettings)
              .ToListAsync();
      }   
    }


    public async Task<ProductionOrderEntity?> GetDataByIdSrcAsync(Guid guid)
    {
      return await this.Context.Set<ProductionOrderEntity>().AsNoTracking()
             .FirstOrDefaultAsync(e => e.Id == guid);
    }

  }
}

