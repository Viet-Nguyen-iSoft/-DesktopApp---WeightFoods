using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Service
{
  public class AppConfigService
  {
    public async Task<List<AppConfig>> GetAllAsync(bool IsContainDelete = false)
    {
      await using var context = new PostgresDbContext();
      var repository = new AppConfigRepository(context);
      return await repository.GetAllAsync(IsContainDelete).ConfigureAwait(false);
    }
    public async Task<AppConfig?> GetAppConfigAsync(bool IsContainDelete = false)
    {
      await using var context = new PostgresDbContext();
      var repository = new AppConfigRepository(context);
      return await repository.GetFirstOrDefaultAsync(IsContainDelete).ConfigureAwait(false);
    }

    public async Task<AppConfig> AddOrUpdateAsync(AppConfig appConfig)
    {
      await using var context = new PostgresDbContext();
      var repository = new AppConfigRepository(context);
      return await repository.AddOrUpdateAsync(appConfig).ConfigureAwait(false);
    }
  }
}
