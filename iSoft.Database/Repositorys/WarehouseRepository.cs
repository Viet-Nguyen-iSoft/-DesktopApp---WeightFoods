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
  public class WarehouseRepository : GenericRepository<Warehouse, CommonDbContext>
  {
    public WarehouseRepository(CommonDbContext context) : base(context)
    {
    }

    public Task<List<Warehouse>> GetAllAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<Warehouse>().AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag);
      return query.ToListAsync();
    }
  }
}
