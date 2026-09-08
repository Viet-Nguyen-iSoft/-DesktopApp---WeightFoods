using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Repositorys
{
  public class AppConfigRepository : GenericRepository<AppConfig, CommonDbContext>
  {
    public AppConfigRepository(DbContext context) : base(context)
    {

    }
    public Task<List<AppConfig>> GetAllAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<AppConfig>().AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag);
      return query.ToListAsync();
    }
    public Task<AppConfig?> GetFirstOrDefaultAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<AppConfig>().AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag);
      return query.FirstOrDefaultAsync();
    }
  }
}
