using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Repositorys
{
  public class LaborProductivityRecognitionEntityRepository : GenericRepository<LaborProductivityRecognitionEntity, CommonDbContext>
  {
    public LaborProductivityRecognitionEntityRepository(DbContext context) : base(context)
    {

    }
    public async Task<LaborProductivityRecognitionEntity?> GetByIdSrcAsync(long? idSrc, Guid? machineId, DateTime dateTime)
    {
      return await this.Context.Set<LaborProductivityRecognitionEntity>()
            .Where(o => o.IdSrc == idSrc && o.DataMachineId == machineId && o.DeletedFlag == false && o.CreatedAt == dateTime)
            .Include(x=>x.WeightTicket).FirstOrDefaultAsync();
    }


    public async Task<List<LaborProductivityRecognitionEntity>?> GetAllDataAsync()
    {
      return await this.Context.Set<LaborProductivityRecognitionEntity>()
            .Where(o => o.DeletedFlag == false && o.WeightTicketId == null)
            .Include(x=>x.DataMachine)
            .ToListAsync();
    }

    public async Task<List<LaborProductivityRecognitionEntity>?> GetAllDataAsync(Guid? machineId)
    {
      return await this.Context.Set<LaborProductivityRecognitionEntity>()
            .Where(o => o.DeletedFlag == false && o.WeightTicketId == null && o.DataMachineId == machineId)
            .Include(x => x.DataMachine)
            .ToListAsync();
    }

  }
}
