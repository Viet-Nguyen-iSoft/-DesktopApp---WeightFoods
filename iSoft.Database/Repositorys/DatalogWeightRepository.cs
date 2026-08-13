using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.WebSockets;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Repositorys
{
  public class DatalogWeightRepository : GenericRepository<DatalogWeight, CommonDbContext>
  {
    public DatalogWeightRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<DatalogWeight>> GetAllDataByTime(DateTime start, DateTime end, eTypeData eTypeData = eTypeData.All) // getall
    {
      if (eTypeData== eTypeData.OnlyNotDelete)
      {
        var startTimeOnlyNotDelete = start.Date + new TimeSpan(0, 0, 0);
        var endTimeOnlyNotDelete = end.Date + new TimeSpan(23, 59, 59);
        return await this.Context.Set<DatalogWeight>()
                                  .Where(x => !x.DeletedFlag &&
                                  ((DateTime)(x.CreatedAt)) >= startTimeOnlyNotDelete &&
                                  ((DateTime)(x.CreatedAt)) <= endTimeOnlyNotDelete)
                                  .Include(x => x.ProductionOrder)
                                  .Include(x=>x.Production)
                                  .Include(x => x.Material)
                                  .Include(x => x.Employee)
                                  .ToListAsync();
      }
      else if (eTypeData == eTypeData.OnlyDelete)
      {
        var startTimeOnlyDelete = start.Date + new TimeSpan(0, 0, 0);
        var endTimeOnlyDelete = end.Date + new TimeSpan(23, 59, 59);
        return await this.Context.Set<DatalogWeight>()
                                  .Where(x => x.DeletedFlag &&
                                  ((DateTime)(x.CreatedAt)) >= startTimeOnlyDelete &&
                                  ((DateTime)(x.CreatedAt)) <= endTimeOnlyDelete)
                                  .Include(x => x.ProductionOrder)
                                  .Include(x => x.Production)
                                  .Include(x => x.Material)
                                  .Include(x => x.Employee)
                                  .ToListAsync();
      }
      else
      {
        var startTime = start.Date + new TimeSpan(0, 0, 0);
        var endTime = end.Date + new TimeSpan(23, 59, 59);
        return await this.Context.Set<DatalogWeight>()
                                  .Where(x =>
                                  ((DateTime)(x.CreatedAt)) >= startTime &&
                                  ((DateTime)(x.CreatedAt)) <= endTime)
                                  .Include(x => x.ProductionOrder)
                                  .Include(x => x.Material)
                                  .Include(x => x.Production)
                                  .Include(x => x.Employee)
                                  .ToListAsync();
      }  
    }


    //Data is not synchronized
    public async Task<List<DatalogWeight>> GetAllNotSynchronized()
    {

      return await this.Context.Set<DatalogWeight>()
                                 .Where(x => x.SyncFlag == false)
                                .Include(x => x.ProductionOrder)
                                .Include(x => x.Production)
                                .Include(x => x.Material)
                                .Include(x => x.MaterialDefect)
                                .Include(x => x.Employee)
                                .Include(x => x.Machine)
                                .Include(x=>x.TareCategory)
                                .Include(x=>x.DatalogDelivery)
                                .Include(x=>x.DeliverySchedule)
                                .ToListAsync();
    }

    public async Task<List<DatalogWeight>> GetAllNotIncludeSynchronized_Fixbug()
    {

      return await this.Context.Set<DatalogWeight>()
                                 .Where(x => x.DeletedFlag == false && x.DatalogDeliveryId!=null)
                                 .Include(x => x.Machine)
                                 .Include(x => x.DatalogDelivery)
                                .ToListAsync();
    }

    public async Task<List<DatalogWeight>> GetAllSynchronized()
    {

      return await this.Context.Set<DatalogWeight>()
                                 .Where(x => x.SyncFlag == false)
                                .ToListAsync();
    }
    public async Task<DatalogWeight> UpdateFlagDeleteAsync(long id, long idEmloyee)
    {
      try
      {
        await this.Context.Database.EnsureCreatedAsync();
        await this.Context.Database.BeginTransactionAsync();
        var rs = await this.Context.Set<DatalogWeight>()
              .FirstOrDefaultAsync(x => x.Id == id);

        if (rs != null)
        {
          rs.UpdatedAt = DateTime.UtcNow;
          rs.UpdatedBy = idEmloyee;
          rs.DeletedFlag = true;
          rs.SyncFlag = false;
          this.Context.Set<DatalogWeight>().Update(rs);
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


    public async Task<List<DatalogWeight>> GetRecordByPOAsync(long idPO)
    {
      try
      {
        return await this.Context.Set<DatalogWeight>()
                                    .Where(x => x.ProductionOrderId == idPO && x.DeletedFlag == false)
                                   .Include(x => x.ProductionOrder)
                                   .Include(x => x.Material)
                                   .Include(x => x.Employee)
                                   .Include(x => x.Machine)
                                   .ToListAsync();
      }
      catch (Exception )
      {
        throw;
      }
    }
    public async Task<List<DatalogWeight>> GetRecordByPOAsync(long idPO, DateTime dateTime, EnumInternalExternalStatus enumInternalExternal,EnumExportImport enumExportImport)
    {
      try
      {
        return await this.Context.Set<DatalogWeight>()
                                    .Where(x => x.ProductionOrderId == idPO && 
                                    x.DeletedFlag == false && 
                                    x.CreatedAt > dateTime && 
                                    x.DatalogDeliveryId == null && 
                                    x.InternalExternalStatus == enumInternalExternal && 
                                    x.eExportImport == enumExportImport
                                    )
                                   .Include(x => x.ProductionOrder)
                                   .Include(x => x.Material)
                                   .Include(x => x.MaterialDefect)
                                   .Include(x => x.Employee)
                                   .Include(x => x.Machine)
                                   .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogWeight>> GetRecordByRequestOtherAsync(long? employeeId, DateTime dateTime, EnumInternalExternalStatus enumInternalExternalStatus)
    {
      try
      {
        return await this.Context.Set<DatalogWeight>()
                                    .Where(x => x.EmployeeId == employeeId &&
                                    x.DeletedFlag == false && 
                                    x.CreatedAt > dateTime &&
                                    x.DatalogDeliveryId == null && 
                                    x.InternalExternalStatus == enumInternalExternalStatus &&
                                    x.EnumTypePO == EnumTypePO.RequestOther)
                                   .Include(x => x.Material)
                                   .Include(x => x.MaterialDefect)
                                   .Include(x => x.Employee)
                                   .Include(x => x.Machine)
                                   .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }
    public async Task<List<DatalogWeight>> GetRecordExpireAsync(DateTime dateTime)
    {
      try
      {
        return await this.Context.Set<DatalogWeight>()
                                    .Where(x => x.DeletedFlag == false && x.CreatedAt < dateTime && x.DatalogDeliveryId == null)
                                   .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<DatalogWeight?> GetDatalogWeightByAsync(long? id)
    {
      try
      {
        return await this.Context.Set<DatalogWeight>()
                                   .Where(x => x.Id == id)
                                   .Include (x => x.ProductionOrder)
                                   .Include(x => x.Material)
                                   .Include(x=>x.Employee).ThenInclude(x=>x.Departments)
                                   .FirstOrDefaultAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateData(DatalogWeight record,long idDelivery)
    {
      try
      {
        var rs = await this.Context.Set<DatalogWeight>()
                                    .FirstOrDefaultAsync(x => x.Id == record.Id);
        if (rs != null)
        {
          rs.DatalogDeliveryId = idDelivery;
          if (record.UserAllowWeightOverId!=null)
          {
            rs.UserAllowWeightOverId = record.UserAllowWeightOverId.Value;
          }
          if (record.DeliveryScheduleId != null)
          {
            rs.DeliveryScheduleId = record.DeliveryScheduleId.Value;
          }
          rs.EnumCheckData = record.EnumCheckData;
          rs.SyncFlag = false;
          rs.UpdatedAt = record.UpdatedAt;

          await Context.Database.EnsureCreatedAsync();
          await Context.Database.BeginTransactionAsync();
          Context.Set<DatalogWeight>().UpdateRange(rs);
          await Context.SaveChangesAsync();
          Context.Database.CommitTransaction();
          return true;
        }
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
