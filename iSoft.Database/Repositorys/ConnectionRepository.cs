using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using static HelperManager.EnumData;

namespace iSoft.Database.Repositorys
{
  public class ConnectionRepository : GenericRepository<Connection, CommonDbContext>
  {
    public ConnectionRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<Connection>> GetAllConnectionWeightAsync_SyncData()
    {
      try
      {
        return await this.Context.Set<Connection>()
        .Where(x => x.EnumDevice == EnumDevice.Weight && !x.DeletedFlag && !x.SyncFlag)
        //.Include(x=>x.Machine)
        .ToListAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<Connection>> GetAllConnectionAsync()
    {
      try
      {
        return await this.Context.Set<Connection>()
        .Where(x => !x.DeletedFlag)
        //.Include(x=>x.Machine)
        .ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<Connection?> GetConnectionByIdAsync(long? id)
    {
      try
      {
        return await this.Context.Set<Connection>()
                      .Where(x => x.Id == id).FirstOrDefaultAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
