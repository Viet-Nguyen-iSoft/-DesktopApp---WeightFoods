using HSF.Database.Entities;
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
  public class MaterialTareEntityRepository : GenericRepository<MaterialTareEntity, CommonDbContext>
  {
    public MaterialTareEntityRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MaterialTareEntity>> GetAllAsync(bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<MaterialTareEntity>()
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<MaterialTareEntity>()
            .Where(e => e.DeletedFlag == false)
             .ToListAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
