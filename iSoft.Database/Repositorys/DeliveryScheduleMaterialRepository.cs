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
  public class DeliveryScheduleMaterialRepository : GenericRepository<DeliveryScheduleMaterial, CommonDbContext>
  {
    public DeliveryScheduleMaterialRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<DeliveryScheduleMaterial>> GetAllDeliveryScheduleMaterial(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<DeliveryScheduleMaterial>()
                 .ToListAsync();
      }
      else
      {
        return await this.Context.Set<DeliveryScheduleMaterial>()
                 .Where(x => !x.DeletedFlag)
                 .ToListAsync();
      }
    }




  }
}