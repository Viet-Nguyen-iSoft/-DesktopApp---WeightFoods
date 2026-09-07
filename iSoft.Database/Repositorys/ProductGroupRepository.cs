using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Repositorys
{
  public class ProductGroupRepository : GenericRepository<ProductGroup, CommonDbContext>
  {
    public ProductGroupRepository(CommonDbContext context) : base(context)
    {
    }

    public Task<List<ProductGroup>> GetAllAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<ProductGroup>().AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag);
      return query.ToListAsync();
    }

  }
}