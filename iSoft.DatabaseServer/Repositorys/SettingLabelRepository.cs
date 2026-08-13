using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.Repositorys
{
  public class SettingLabelRepository : GenericRepository<SettingLabel, CommonDbContext>
  {
    public SettingLabelRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<SettingLabel>> GetAllAsync(eTypeLabel eTypeLabel, bool isContainDelete = false)
    {
      try
      {
        if (isContainDelete)
        {
          return await this.Context.Set<SettingLabel>()
            .Where(x => x.eTypeLabel == eTypeLabel)
              .ToListAsync();
        }
        else
        {
          return await this.Context.Set<SettingLabel>()
              .Where(e => e.DeletedFlag == false && e.eTypeLabel == eTypeLabel)
              .ToListAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task RemoveByIdAsync(long id)
    {
      try
      {
        var entity = await this.Context.Set<SettingLabel>()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
          return;

        entity.DeletedFlag = true;

        await this.Context.SaveChangesAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
