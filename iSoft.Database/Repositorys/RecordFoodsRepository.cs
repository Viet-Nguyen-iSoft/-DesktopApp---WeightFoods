using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.WebSockets;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Repositorys
{
  public class RecordFoodsRepository : GenericRepository<RecordWeight, CommonDbContext>
  {
    public RecordFoodsRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<RecordWeight>> GetAllDataByTime(DateTime start, DateTime end, eTypeData eTypeData = eTypeData.All) // getall
    {
      if (eTypeData== eTypeData.OnlyNotDelete)
      {
        var startTimeOnlyNotDelete = start.Date + new TimeSpan(0, 0, 0);
        var endTimeOnlyNotDelete = end.Date + new TimeSpan(23, 59, 59);
        return await this.Context.Set<RecordWeight>()
                                  .Where(x => !x.DeletedFlag &&
                                  ((DateTime)(x.CreatedAt)) >= startTimeOnlyNotDelete &&
                                  ((DateTime)(x.CreatedAt)) <= endTimeOnlyNotDelete)
                                  //.Include(x => x.ProductionOrder)
                                  //.Include(x=>x.Production)
                                  //.Include(x => x.Material)
                                  .Include(x => x.Employee)
                                  .ToListAsync();
      }
      else if (eTypeData == eTypeData.OnlyDelete)
      {
        var startTimeOnlyDelete = start.Date + new TimeSpan(0, 0, 0);
        var endTimeOnlyDelete = end.Date + new TimeSpan(23, 59, 59);
        return await this.Context.Set<RecordWeight>()
                                  //.Where(x => x.DeletedFlag &&
                                  //((DateTime)(x.CreatedAt)) >= startTimeOnlyDelete &&
                                  //((DateTime)(x.CreatedAt)) <= endTimeOnlyDelete)
                                  //.Include(x => x.ProductionOrder)
                                  //.Include(x => x.Production)
                                  //.Include(x => x.Material)
                                  //.Include(x => x.Employee)
                                  .ToListAsync();
      }
      else
      {
        var startTime = start.Date + new TimeSpan(0, 0, 0);
        var endTime = end.Date + new TimeSpan(23, 59, 59);
        return await this.Context.Set<RecordWeight>()
                                  //.Where(x =>
                                  //((DateTime)(x.CreatedAt)) >= startTime &&
                                  //((DateTime)(x.CreatedAt)) <= endTime)
                                  //.Include(x => x.ProductionOrder)
                                  //.Include(x => x.Material)
                                  //.Include(x => x.Production)
                                  //.Include(x => x.Employee)
                                  .ToListAsync();
      }  
    }


    //Data is not synchronized
    public async Task<List<RecordWeight>> GetAllNotSynchronized()
    {

      return await this.Context.Set<RecordWeight>()
                                // .Where(x => x.SyncFlag == false)
                                //.Include(x => x.ProductionOrder)
                                //.Include(x => x.Production)
                                //.Include(x => x.Material)
                                //.Include(x => x.MaterialDefect)
                                //.Include(x => x.Employee)
                                //.Include(x => x.Machine)
                                //.Include(x=>x.TareCategory)
                                //.Include(x=>x.DatalogDelivery)
                                //.Include(x=>x.DeliverySchedule)
                                .ToListAsync();
    }

    public async Task<List<RecordWeight>> GetAllNotIncludeSynchronized_Fixbug()
    {

      return await this.Context.Set<RecordWeight>()
                                 //.Where(x => x.DeletedFlag == false && x.DatalogDeliveryId!=null)
                                 //.Include(x => x.Machine)
                                 //.Include(x => x.DatalogDelivery)
                                .ToListAsync();
    }

    public async Task<List<RecordWeight>> GetAllSynchronized()
    {

      return await this.Context.Set<RecordWeight>()
                                 .Where(x => x.SyncFlag == false)
                                .ToListAsync();
    }
    public async Task<RecordWeight> UpdateFlagDeleteAsync(Guid id, Guid idEmloyee)
    {
      try
      {
        await this.Context.Database.EnsureCreatedAsync();
        await this.Context.Database.BeginTransactionAsync();
        var rs = await this.Context.Set<RecordWeight>()
              .FirstOrDefaultAsync(x => x.Id == id);

        if (rs != null)
        {
          rs.UpdatedAt = DateTime.UtcNow;
          rs.UpdatedBy = idEmloyee;
          rs.DeletedFlag = true;
          rs.SyncFlag = false;
          this.Context.Set<RecordWeight>().Update(rs);
          await this.Context.SaveChangesAsync();
          this.Context.Database.CommitTransaction();
        }

        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task<List<RecordWeight>> GetRecordByPOAsync(Guid idPO)
    {
      try
      {
        return await this.Context.Set<RecordWeight>()
                                   // .Where(x => x.ProductionOrderId == idPO && x.DeletedFlag == false)
                                   //.Include(x => x.ProductionOrder)
                                   //.Include(x => x.Material)
                                   //.Include(x => x.Employee)
                                   //.Include(x => x.Machine)
                                   .ToListAsync();
      }
      catch (Exception )
      {
        throw;
      }
    }
    public async Task<List<RecordWeight>> GetRecordByPOAsync(Guid idPO, DateTime dateTime, EnumInternalExternalStatus enumInternalExternal,EnumExportImport enumExportImport)
    {
      try
      {
        return await this.Context.Set<RecordWeight>()
                                   // .Where(x => x.ProductionOrderId == idPO && 
                                   // x.DeletedFlag == false && 
                                   // x.CreatedAt > dateTime && 
                                   // x.DatalogDeliveryId == null && 
                                   // x.InternalExternalStatus == enumInternalExternal && 
                                   // x.eExportImport == enumExportImport
                                   // )
                                   //.Include(x => x.ProductionOrder)
                                   //.Include(x => x.Material)
                                   //.Include(x => x.MaterialDefect)
                                   //.Include(x => x.Employee)
                                   //.Include(x => x.Machine)
                                   .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<RecordWeight>> GetRecordByRequestOtherAsync(Guid? employeeId, DateTime dateTime, EnumInternalExternalStatus enumInternalExternalStatus)
    {
      try
      {
        return await this.Context.Set<RecordWeight>()
                                    .Where(x => x.EmployeeId == employeeId &&
                                    x.DeletedFlag == false && 
                                    x.CreatedAt > dateTime //&&
                                    //x.DatalogDeliveryId == null && 
                                    //x.InternalExternalStatus == enumInternalExternalStatus &&
                                    //x.EnumTypePO == EnumTypePO.RequestOther
                                    )
                                   .Include(x => x.Employee)
                                   .Include(x => x.Station)
                                   .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }
    public async Task<List<RecordWeight>> GetRecordExpireAsync(DateTime dateTime)
    {
      try
      {
        return new List<RecordWeight>();
        //return await this.Context.Set<RecordFoods>()
        //                            .Where(x => x.DeletedFlag == false && x.CreatedAt < dateTime && x.DatalogDeliveryId == null)
        //                           .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<RecordWeight?> GetDatalogWeightByAsync(Guid? id)
    {
      try
      {
        return await this.Context.Set<RecordWeight>()
                                   //.Where(x => x.Id == id)
                                   //.Include (x => x.ProductionOrder)
                                   //.Include(x => x.Material)
                                   //.Include(x=>x.Employee).ThenInclude(x=>x.Departments)
                                   .FirstOrDefaultAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateData(RecordWeight record, Guid idDelivery)
    {
      try
      {
        var rs = await this.Context.Set<RecordWeight>()
                                    .FirstOrDefaultAsync(x => x.Id == record.Id);
        //if (rs != null)
        //{
        //  rs.DatalogDeliveryId = idDelivery;
        //  if (record.UserAllowWeightOverId!=null)
        //  {
        //    rs.UserAllowWeightOverId = record.UserAllowWeightOverId.Value;
        //  }
        //  if (record.DeliveryScheduleId != null)
        //  {
        //    rs.DeliveryScheduleId = record.DeliveryScheduleId.Value;
        //  }
        //  rs.EnumCheckData = record.EnumCheckData;
        //  rs.SyncFlag = false;
        //  rs.UpdatedAt = record.UpdatedAt;

        //  await Context.Database.EnsureCreatedAsync();
        //  await Context.Database.BeginTransactionAsync();
        //  Context.Set<RecordFoods>().UpdateRange(rs);
        //  await Context.SaveChangesAsync();
        //  Context.Database.CommitTransaction();
        //  return true;
        //}
        return false;
      }
      catch (Exception)
      {
        Context.Database.RollbackTransaction();
        throw;
      }
    }

  }
}
