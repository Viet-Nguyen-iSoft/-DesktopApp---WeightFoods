using iSoft.DatabaseServer.DbContexts;
using iSoft.DatabaseServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Repositorys
{
  public class WarningEntityRepository : GenericRepository<WarningEntity, CommonDbContext>
  {
    public WarningEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<WarningEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<WarningEntity>()
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<WarningEntity>()
              .Where(e => e.DeletedFlag == false)
              .ToListAsync();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }
  }
}
