using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class MachineEntityRepository : GenericRepository<UserGroupEntity, CommonDbContext>
  {
    public MachineEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MachineEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<MachineEntity>().AsNoTracking()
           .ToListAsync();
        }
        else
        {
          return await this.Context.Set<MachineEntity>().AsNoTracking()
           .Where(e => e.DeletedFlag == false).ToListAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<MachineEntity?> GetDataByIdSrcAsync(Guid guid)
    {
      try
      {
        return await this.Context.Set<MachineEntity>().AsNoTracking()
             .FirstOrDefaultAsync(e => e.Id == guid);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
