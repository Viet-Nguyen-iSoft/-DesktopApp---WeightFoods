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
  public class CategoryTareRepository : GenericRepository<CategoryTare, CommonDbContext>
  {
    public CategoryTareRepository(DbContext context) : base(context)
    {

    }

    public Task<List<CategoryTare>> GetAllAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<CategoryTare>().AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag);
      return query.ToListAsync();
    }
  }
}
