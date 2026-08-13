using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class FactoryEntityRepository : GenericRepository<FactoryEntity, CommonDbContext>
  {
    public FactoryEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<FactoryEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<FactoryEntity>()
              .Include(x => x.DataMachines)
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<FactoryEntity>()
              .Where(e => e.DeletedFlag == false)
              .Include(x => x.DataMachines)
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
