using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Repositorys
{
  public class ProductRepository : GenericRepository<Product, CommonDbContext>
  {
    public ProductRepository(CommonDbContext context) : base(context)
    {
    }

    public Task<List<Product>> GetAllAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<Product>().AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag).Include(x => x.ProductGroup);
      return query.ToListAsync();
    }
  }
}
