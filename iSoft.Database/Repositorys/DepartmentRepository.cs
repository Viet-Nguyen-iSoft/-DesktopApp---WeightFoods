using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.Database.Repositorys
{
  public class DepartmentRepository : GenericRepository<Department, CommonDbContext>
  {
    public DepartmentRepository(DbContext context) : base(context)
    {

    }


    public async Task<List<Department>> GetAllDepartment(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<Department>()
                 .ToListAsync();
      }  
      else
      {
        return await this.Context.Set<Department>()
                 .Where(x => !x.DeletedFlag)
                 .ToListAsync();
      }  
    }

    public async Task<Department> GetByIdAsync(long id)
    {
      return await this.Context.Set<Department>()
        .FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<Department> UpdateFlagDeleteAsync(long id)
    {
      var rs = await this.Context.Set<Department>()
        .FirstOrDefaultAsync(x => x.Id == id);

      if (rs != null)
      {
        rs.DeletedFlag = true;    
        await this.Context.SaveChangesAsync();
      }

      return rs;
    }



  }
}
