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

    public async Task<List<CategoryTare>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<CategoryTare>()
            .ToListAsync();
      }
      else
      {
        return await this.Context.Set<CategoryTare>()
            .Where(x => !x.DeletedFlag)
            .ToListAsync();
      }
    }

    public async Task<List<CategoryTare>> GetCategoryTareBuMaterialIdAsync(long? id)
    {
      return new List<CategoryTare>();
      //return await this.Context.Set<CategoryTare>()
      //      .Where(x => !x.DeletedFlag && x.MaterialId == id)
      //      .ToListAsync();

      //return await this.Context.Set<CategoryTare>()
      //     .Where(x => !x.DeletedFlag)
      //     .Include(x=>x.TareGroup)
      //     .ToListAsync();
    }
  }
}
