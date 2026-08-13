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
  public class WeightTicketEntityRepository : GenericRepository<WeightTicketEntities, CommonDbContext>
  {
    public WeightTicketEntityRepository(DbContext context) : base(context)
    {

    }
    public async Task<WeightTicketEntities?> GetByIdSrcAsync(long? idSrc, Guid? machineId, DateTime dateTime)
    {
      return await this.Context.Set<WeightTicketEntities>()
            .Where(o => o.IdSrc == idSrc && o.DataMachineId == machineId && o.CreatedAt== dateTime).FirstOrDefaultAsync();
    }

    public async Task<List<WeightTicketEntities>?> GetAllAsync_Fixbug()
    {
      return await this.Context.Set<WeightTicketEntities>()
            .Where(o => o.DeletedFlag == false).ToListAsync();
    }

    public async Task<List<WeightTicketEntities>?> GetAllAsync_Fixbug(Guid? machineId)
    {
      return await this.Context.Set<WeightTicketEntities>()
            .Where(o => o.DeletedFlag == false && o.DataMachineId == machineId).ToListAsync();
    }
  }
}
