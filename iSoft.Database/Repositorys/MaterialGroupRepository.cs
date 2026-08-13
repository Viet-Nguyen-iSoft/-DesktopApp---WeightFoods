using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Repositorys
{
  public class MaterialGroupRepository : GenericRepository<Material, CommonDbContext>
  {
    public MaterialGroupRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MaterialGroup>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<MaterialGroup>().AsNoTracking()
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<MaterialGroup>().AsNoTracking()
              .Where(e => !e.DeletedFlag)
              .ToListAsync();
      }
    }
    
  }
}