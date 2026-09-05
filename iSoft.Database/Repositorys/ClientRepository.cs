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
  public class ClientRepository : GenericRepository<Client, CommonDbContext>
  {
    public ClientRepository(CommonDbContext context) : base(context)
    {
    }

    public Task<List<Client>> GetAllAsync(bool IsContainDelete = false)
    {
      var query = Context.Set<Client>().AsQueryable();
      if (!IsContainDelete)
        query = query.Where(x => !x.DeletedFlag);

      return query.ToListAsync();
    }
  }
}
