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
  public class DatalogDeliveryRepository : GenericRepository<DatalogDelivery, CommonDbContext>
  {
    public DatalogDeliveryRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<DatalogDelivery>?> GetAllNotSynchronized()
    {
      try
      {
        return await this.Context.Set<DatalogDelivery>()
                                     .Where(x => x.SyncFlag == false)
                                     .Include(x => x.Machine)
                                     .Include(x => x.ProductionOrder)
                                     .Include(x => x.EmployeeDeliver)
                                     .Include(x => x.EmployeeReceive)
                                     .Include(x => x.EmployeeQC)
                                     .Include(x => x.DatalogWeights).ThenInclude(x => x.Material)
                                     .Include(x => x.DeliverySchedule)
                                    .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogDelivery>> GetHistoricalAsync(DateTime start, DateTime end)
    {
      try
      {
        var startTime = start.Date + new TimeSpan(0, 0, 0);
        var endTime = end.Date + new TimeSpan(23, 59, 59);

        return await this.Context.Set<DatalogDelivery>()
                                     .Where
                                           (x => x.DeletedFlag == false && 
                                           ((DateTime)(x.CreatedAt)) >= startTime &&
                                            ((DateTime)(x.CreatedAt)) <= endTime
                                      )
                                     .Include(x => x.Machine)
                                     .Include(x => x.ProductionOrder)
                                     .Include(x => x.EmployeeDeliver)
                                     .Include(x => x.EmployeeReceive)
                                     .Include(x => x.EmployeeQC)
                                     .Include(x => x.DatalogWeights)
                                    .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
