using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class MaterialEntityRepository : GenericRepository<MaterialEntity, CommonDbContext>
  {
    public MaterialEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MaterialEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<MaterialEntity>()
              .Include(x => x.MaterialGroup)
              //.Include(x => x.TareCategories)
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<MaterialEntity>()
            .Where(e => e.DeletedFlag == false)
             .Include(x => x.MaterialGroup)
             //.Include(x => x.TareCategories)
             .ToListAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<MaterialEntity?> GetDataByIdSrcAsync(Guid guid)
    {
      return await this.Context.Set<MaterialEntity>().AsNoTracking()
             .FirstOrDefaultAsync(e => e.Id == guid);
    }
  }
}
