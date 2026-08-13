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
  public class LogActionRepository : GenericRepository<LogAction, CommonDbContext>
  {
    public LogActionRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<LogAction>> GetAll_Async()
    {
      return await this.Context.Set<LogAction>().OrderByDescending(x=>x.Id).ToListAsync();
    }

    public async Task<List<LogAction>> GetLogByFillter(DateTime from, DateTime to, eAction eAction)
    {
      List<LogAction> logActions = new List<LogAction>();

      logActions = await this.Context.Set<LogAction>()
                                      .Where(x=>((DateTime)x.CreatedAt).Date >= from.Date
                                              &&((DateTime)x.CreatedAt).Date <= to.Date)
                                      .ToListAsync();
      if (eAction != eAction.AllAction)
      {
        logActions = logActions.Where(x => x.eAction == eAction).ToList();
      }

      return logActions;
    }

  }
}
