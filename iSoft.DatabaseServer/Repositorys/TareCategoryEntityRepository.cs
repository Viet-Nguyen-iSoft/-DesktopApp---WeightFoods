using iSoft.DatabaseServer.DbContexts;
using iSoft.DatabaseServer.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class TareCategoryEntityRepository : GenericRepository<TareCategoryEntity, CommonDbContext>
  {
    public TareCategoryEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<TareCategoryEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<TareCategoryEntity>()
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<TareCategoryEntity>()
              .Where(e => e.DeletedFlag == false)
              .ToListAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<TareCategoryEntity?> GetDataByIdSrcAsync(Guid guid)
    {
      try
      {
        return await this.Context.Set<TareCategoryEntity>().AsNoTracking()
             .FirstOrDefaultAsync(e => e.Id == guid);
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
