using iSoft.DatabaseServer.DbContexts;
using iSoft.DatabaseServer.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class ProductionEntityRepository : GenericRepository<ProductEntity, CommonDbContext>
  {
    public ProductionEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<ProductEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<ProductEntity>().AsNoTracking()
                .Include(x => x.Materials)//.ThenInclude(x => x.MaterialEntityTrans)
                .ToListAsync();
        }
        else
        {
          return await this.Context.Set<ProductEntity>().AsNoTracking()
                .Where(e => e.DeletedFlag == false)
                .Include(x => x.Materials)//.ThenInclude(x => x.MaterialEntityTrans)
                .ToListAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task<ProductEntity?> GetDataByIdSrcAsync(Guid guid)
    {
      try
      {
        return await this.Context.Set<ProductEntity>().AsNoTracking()
                 .FirstOrDefaultAsync(e => e.Id == guid);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
