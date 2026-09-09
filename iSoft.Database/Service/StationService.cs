using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;

namespace iSoft.Database.Service
{
  public class StationService
  {
    public async Task<List<Station>> GetAllAsync(bool isContainDelete = false)
    {
      await using var context = new PostgresDbContext();
      var repository = new StationRepository(context);
      return await repository.GetAllAsync(isContainDelete).ConfigureAwait(false);
    }
    public async Task<Station?> GetFirstDataStation(bool isContainDelete = false)
    {
      await using var context = new PostgresDbContext();
      var repository = new StationRepository(context);
      return await repository.GetFirstDataStationAsync().ConfigureAwait(false);
    }
  }
}
