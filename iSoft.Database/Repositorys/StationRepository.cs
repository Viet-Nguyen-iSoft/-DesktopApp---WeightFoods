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
  public class StationRepository : GenericRepository<Station, CommonDbContext>
  {
    public StationRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<Station>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<Station>()
          .ToListAsync();
      }
      else
      {
        return await this.Context.Set<Station>()
          .Where(x => !x.DeletedFlag)
          .ToListAsync();
      }  
    }
  }
}
