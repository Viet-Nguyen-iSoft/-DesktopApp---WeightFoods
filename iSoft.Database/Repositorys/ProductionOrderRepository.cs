using iSoft.Database.DbContexts;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Repositorys
{
  public class ProductionOrderRepository : GenericRepository<ProductionOrder, CommonDbContext>
  {
    public ProductionOrderRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<ProductionOrder>> GetProductionOrdersAsync(bool isContainDeleteFlag = false)
    {
      if (isContainDeleteFlag)
      {
        return await this.Context.Set<ProductionOrder>().AsNoTracking()
                    .Include(o => o.Materials)
                    .ToListAsync();
      }
      else
      {
        return await this.Context.Set<ProductionOrder>().AsNoTracking()
                    .Where(x => !x.DeletedFlag)
                    .Include(o => o.Materials)
                    .ToListAsync();
      }  
    }

    public async Task<List<ProductionOrder>> GetProductionOrdersShowUIAsync()
    {
      try
      {
        DateTime dt = DateTime.Now.Date;
        return await this.Context.Set<ProductionOrder>().AsNoTracking()
                     .Where(x => !x.DeletedFlag &&
                     (dt < x.EffectiveFrom.Value ||
                      (dt >= x.EffectiveFrom.Value && dt <= x.EffectiveTo.Value)
                     ))
                     .Include(o => o.Materials)
                     .Include(o => o.Productions)
                     .ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<ProductionOrder?> GetPOByIdSrcAsync(Guid? Id)
    {
      return await this.Context.Set<ProductionOrder>().AsNoTracking()
                      .Where(x => x.IdSrc == Id)
                      .Include(o => o.Productions)
                      .FirstOrDefaultAsync();
    }

    public async Task<List<ProductionOrder>> GetProductionOrders_Async(DateTime dtCurrent)
    {
      return await this.Context.Set<ProductionOrder>()
                    .Where
                    (x=>
                        x.EffectiveFrom.Value.Date>= dtCurrent.Date &&
                        x.EffectiveTo.Value.Date <= dtCurrent.Date
                    )
                    //.Include(o => o.Materials).ThenInclude(x => x.MaterialTrans) ////CHECK
                    .Include(o => o.DatalogWeights)
                    .ToListAsync();
    }


    public async Task<ProductionOrder?> GetPOByIdAsync(long? Id)
    {
      return await this.Context.Set<ProductionOrder>().AsNoTracking()
                      .Where(x => x.Id == Id)
                      //.Include(o => o.Productions)
                      //.Include (o => o.DatalogWeights)
                      //.Include (o => o.Materials)
                      .Include (o => o.MaterialSettings).ThenInclude(o => o.Material).ThenInclude(o=>o.MaterialGroup).ThenInclude(x=>x.MaterialGroupParent)
                      .FirstOrDefaultAsync();
    }
  }

  public class WarningObj
  {
    public float ValueActual {  get; set; }
    public float ValueSetting {  get; set; }
    public List<DatalogWeight>? Records { get; set; }
    public DateTime? Datetime { get; set; }
  }
}
