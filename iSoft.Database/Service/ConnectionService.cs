using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;

namespace iSoft.Database.Service
{
  public class ConnectionService
  {
    public async Task<List<Connection>> GetAllAsync(bool isContainDelete = false)
    {
      await using var context = new PostgresDbContext();
      var repository = new ConnectionRepository(context);
      return await repository.GetAllAsync(isContainDelete).ConfigureAwait(false);
    }

    public async Task<List<Connection>> GetAllWeightNotSynchronizedAsync()
    {
      await using var context = new PostgresDbContext();
      var repository = new ConnectionRepository(context);
      return await repository.GetAllWeightNotSynchronizedAsync().ConfigureAwait(false);
    }

    public async Task<Connection?> GetByIdAsync(Guid id)
    {
      await using var context = new PostgresDbContext();
      var repository = new ConnectionRepository(context);
      return await repository.GetByIdAsync(id).ConfigureAwait(false);
    }

    public async Task<Connection> AddOrUpdateAsync(Connection connection)
    {
      await using var context = new PostgresDbContext();
      var repository = new ConnectionRepository(context);
      return await repository.AddOrUpdateAsync(connection).ConfigureAwait(false);
    }
    public async Task<Connection> DeleteAsync(Connection connection)
    {
      await using var context = new PostgresDbContext();
      var repository = new ConnectionRepository(context);
      return await repository.AddOrUpdateAsync(connection).ConfigureAwait(false);
    }
  }
}
