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
  public class RecordTruckRepository : GenericRepository<RecordTruck, CommonDbContext>
  {
    public RecordTruckRepository(CommonDbContext context) : base(context)
    {
    }

    public Task<List<RecordTruck>> GetAllAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<RecordTruck>()
        .Include(x => x.Client)
        .Include(x => x.TypeGoods)
        .Include(x => x.Warehouse)
        .AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag);
      return query.ToListAsync();
    }

    public async Task<RecordTruck> AddOrUpdateAsync(RecordTruck recordTruck)
    {
      if (recordTruck == null)
      {
        throw new ArgumentNullException(nameof(recordTruck));
      }

      await Context.Database.EnsureCreatedAsync();
      var records = Context.Set<RecordTruck>();
      var existingRecord = recordTruck.Id == 0
        ? null
        : await records.FindAsync(recordTruck.Id);

      if (existingRecord == null)
      {
        await records.AddAsync(recordTruck);
      }
      else
      {
        Context.Entry(existingRecord).CurrentValues.SetValues(recordTruck);
      }

      await Context.SaveChangesAsync();
      return existingRecord ?? recordTruck;
    }
  }
}
