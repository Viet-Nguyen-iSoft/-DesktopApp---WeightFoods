using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;

namespace iSoft.Database.Repositorys
{
  public class DeliveryScheduleRepository : GenericRepository<DeliverySchedule, CommonDbContext>
  {
    public DeliveryScheduleRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<DeliverySchedule>> GetAllDeliverySchedule(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<DeliverySchedule>()
                 .ToListAsync();
      }
      else
      {
        return await this.Context.Set<DeliverySchedule>()
                 .Where(x => !x.DeletedFlag)
                 .ToListAsync();
      }
    }


    public async Task<List<DeliverySchedule>> GetDataDeliverySchedulesAsync(
    long? materialId,
    long? productionOrderId,
    EnumExportImport? enumExportImport,
    CancellationToken cancellationToken = default)
    {
      return await this.Context.Set<DeliverySchedule>()
          .AsNoTracking()
          .Include(x => x.ProductionOrder)
          .Include(x => x.DeliveryScheduleMaterials!)
              .ThenInclude(x => x.Material)
          .Where(x =>
              !x.DeletedFlag &&
              x.ProductionOrderId == productionOrderId &&
              x.DeliveryScheduleMaterials != null &&
              x.DeliveryScheduleMaterials.Any(m =>
                  m.MaterialId == materialId &&
                  !m.DeletedFlag) &&
              x.ImportExport == enumExportImport
              )
          .OrderBy(x => x.DeliveryTimeMaterial)
          .ToListAsync(cancellationToken);
    }

    public async Task<List<DeliverySchedule>> GetDataDeliverySchedulesAsync(
    long? productionOrderId,
    EnumExportImport? enumExportImport,
    CancellationToken cancellationToken = default)
    {
      DateTime currentTime = DateTime.Now;
      DateTime fromTime = currentTime.AddMinutes(-30);
      DateTime toTime = currentTime.AddMinutes(30);

      //return await Context.Set<DeliverySchedule>()
      //  .AsNoTracking()
      //  .Include(x => x.ProductionOrder)
      //  .Include(x => x.DeliveryScheduleMaterials!)
      //      .ThenInclude(x => x.Material)
      //  .Where(x =>
      //      !x.DeletedFlag &&
      //      x.ProductionOrderId == productionOrderId &&
      //      x.ImportExport == enumExportImport &&

      //      (
      //          (x.DeliveryTimeMaterial.HasValue &&
      //           x.DeliveryTimeMaterial.Value >= fromTime &&
      //           x.DeliveryTimeMaterial.Value <= toTime)

      //          ||

      //          (x.DeliveryTimeRawMaterial.HasValue &&
      //           x.DeliveryTimeRawMaterial.Value >= fromTime &&
      //           x.DeliveryTimeRawMaterial.Value <= toTime)

      //          ||

      //          (x.DeliveryTimeSemiFinished.HasValue &&
      //           x.DeliveryTimeSemiFinished.Value >= fromTime &&
      //           x.DeliveryTimeSemiFinished.Value <= toTime)

      //          ||

      //          (x.DeliveryTimeYield.HasValue &&
      //           x.DeliveryTimeYield.Value >= fromTime &&
      //           x.DeliveryTimeYield.Value <= toTime)
      //      )
      //  )
      //  //.OrderBy(x =>
      //  //    x.DeliveryTimeMaterial ??
      //  //    x.DeliveryTimeRawMaterial ??
      //  //    x.DeliveryTimeSemiFinished ??
      //  //    x.DeliveryTimeYield)
      //  .OrderByDescending(x => x.TicketCode)
      //  .ToListAsync(cancellationToken);

      return await this.Context.Set<DeliverySchedule>()
          .AsNoTracking()
          .Include(x => x.ProductionOrder)
          .Include(x => x.DeliveryScheduleMaterials!)
              .ThenInclude(x => x.Material)
          .Where(x =>
              !x.DeletedFlag &&
              x.ProductionOrderId == productionOrderId &&
              x.ImportExport == enumExportImport
              )
          .OrderByDescending(x => x.TicketCode)
          .ToListAsync(cancellationToken);
    }

    public async Task<DeliverySchedule?> GetByIdAsync(long? id)
    {
      return await this.Context.Set<DeliverySchedule>()
        .FirstOrDefaultAsync(x => x.Id == id);
    }

  }
}