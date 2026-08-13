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
  public class DeliveryScheduleEntityRepository : GenericRepository<DeliveryScheduleEntity, CommonDbContext>
  {
    public DeliveryScheduleEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<DeliveryScheduleEntity>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<DeliveryScheduleEntity>()
            .ToListAsync();
      }
      else
      {
        return await this.Context.Set<DeliveryScheduleEntity>()
            .Where(e => e.DeletedFlag == false)
            .ToListAsync();
      }
    }

    public async Task<DeliveryScheduleEntity?> GetDataByIdSrcAsync(Guid guid)
    {
      try
      {
        return await this.Context.Set<DeliveryScheduleEntity>().AsNoTracking()
             .FirstOrDefaultAsync(e => e.Id == guid);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}