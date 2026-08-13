using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class EmployeeEntityRepository : GenericRepository<UserEntity, CommonDbContext>
  {
    public EmployeeEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<UserEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<UserEntity>()
              .Include(x=>x.UserGroups)
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<UserEntity>()
              .Where(e => e.DeletedFlag == false)
              .Include(x => x.UserGroups)
              .ToListAsync();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<UserEntity?> GetDataByIdSrcAsync(Guid guid)
    {
      try
      {
        return await this.Context.Set<UserEntity>().AsNoTracking()
             .FirstOrDefaultAsync(e => e.Id == guid);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
