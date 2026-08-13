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
  public class MaterialTareRepository : GenericRepository<MaterialTare, CommonDbContext>
  {
    public MaterialTareRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<MaterialTare>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<MaterialTare>().AsNoTracking()
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<MaterialTare>().AsNoTracking()
              .Where(e => !e.DeletedFlag)
              .ToListAsync();
      }
    }

    public async Task<MaterialTare?> GetMaterialTareByIdSrcAsync(Guid? Id)
    {
      return await this.Context.Set<MaterialTare>().AsNoTracking()
                      .Where(x => x.IdSrc == Id)
                      .FirstOrDefaultAsync();
    }



  }
}
