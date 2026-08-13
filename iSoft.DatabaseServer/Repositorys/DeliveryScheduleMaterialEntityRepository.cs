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
  public class DeliveryScheduleMaterialEntityRepository : GenericRepository<DeliveryScheduleMaterialEntity, CommonDbContext>
  {
    public DeliveryScheduleMaterialEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<DeliveryScheduleMaterialEntity>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<DeliveryScheduleMaterialEntity>()
            .ToListAsync();
      }
      else
      {
        return await this.Context.Set<DeliveryScheduleMaterialEntity>()
            .Where(e => e.DeletedFlag == false)
            .ToListAsync();
      }
    }
  }
}