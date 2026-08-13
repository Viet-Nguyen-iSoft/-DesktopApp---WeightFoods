using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class DepartmentEntityRepository : GenericRepository<UserGroupEntity, CommonDbContext>
  {
    public DepartmentEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<UserGroupEntity>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<UserGroupEntity>()
          //.Include(x=>x.Users)
            .ToListAsync();
      }
      else
      {
        return await this.Context.Set<UserGroupEntity>()
            .Where(e => e.DeletedFlag == false)
             //.Include(x => x.Users)
            .ToListAsync();
      }
    }
  }
}
