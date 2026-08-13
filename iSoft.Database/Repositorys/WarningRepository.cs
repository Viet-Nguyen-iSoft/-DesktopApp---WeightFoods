using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.Database.Repositorys
{
  public class WarningRepository : GenericRepository<Warning, CommonDbContext>
  {
    public WarningRepository(DbContext context) : base(context)
    {

    }

    public async Task AddOrUpdate(Warning warning)
    {
      try
      {
        var rs = await this.Context.Set<Warning>()
                       .Where
                       (x =>
                           x.ProductionId == warning.ProductionOrderId &&
                           x.MaterialId == warning.MaterialId
                       )
                       .FirstOrDefaultAsync();
        if (rs != null)
        {
          rs.Weight = warning.Weight;
          rs.UpdatedAt = DateTime.Now;
          this.Context.Set<Warning>().Update(rs);
        }
        else
        {
          await this.Context.Set<Warning>().AddAsync(warning);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<List<Warning>> GetAllWarningAsync()
    {
      try
      {
        return await this.Context.Set<Warning>()
        .Where(x => !x.DeletedFlag && !x.SyncFlag).ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
