using iSoft.DatabaseServer.DbContexts;
using iSoft.DatabaseServer.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class ConnectionEntityRepository : GenericRepository<ConnectionEntity, CommonDbContext>
  {
    public ConnectionEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<ConnectionEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<ConnectionEntity>()
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<ConnectionEntity>()
              .Where(e => e.DeletedFlag == false)
              .ToListAsync();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }

  }
}
