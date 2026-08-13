using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using iSoft.DatabaseServer.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class MaterialGroupEntityRepository : GenericRepository<MaterialGroupEntity, CommonDbContext>
  {
    public MaterialGroupEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MaterialGroupEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<MaterialGroupEntity>()
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<MaterialGroupEntity>()
            .Where(e => e.DeletedFlag == false)
             .ToListAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
