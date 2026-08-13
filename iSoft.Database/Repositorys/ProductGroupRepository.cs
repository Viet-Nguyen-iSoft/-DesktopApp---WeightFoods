using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Repositorys
{
  public class ProductGroupRepository : GenericRepository<Product, CommonDbContext>
  {
    public ProductGroupRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<ProductGroup>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<ProductGroup>().AsNoTracking()
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<ProductGroup>().AsNoTracking()
              .Where(e => !e.DeletedFlag)
              .ToListAsync();
      }
    }
    
  }
}