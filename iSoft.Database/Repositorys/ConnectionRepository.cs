using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using static HelperManager.EnumData;

namespace iSoft.Database.Repositorys
{
  public class ConnectionRepository : GenericRepository<Connection, CommonDbContext>
  {
    public ConnectionRepository(DbContext context) : base(context)
    {

    }

    public Task<List<Connection>> GetAllAsync(bool isContainDelete = false)
    {
      var query = Context.Set<Connection>()
        .Include(connection => connection.Station)
        .AsQueryable();

      if (!isContainDelete)
        query = query.Where(connection => !connection.DeletedFlag);

      return query.ToListAsync();
    }

    public Task<List<Connection>> GetAllWeightNotSynchronizedAsync()
    {
      return Context.Set<Connection>()
        .Where(connection =>
          connection.EnumDevice == EnumDevice.Weight &&
          !connection.DeletedFlag &&
          !connection.SyncFlag)
        .Include(connection => connection.Station)
        .ToListAsync();
    }

    public Task<Connection?> GetByIdAsync(Guid id)
    {
      return Context.Set<Connection>()
        .Include(connection => connection.Station)
        .FirstOrDefaultAsync(connection => connection.Id == id);
    }

    public async Task<Connection> AddOrUpdateAsync(Connection connection)
    {
      ArgumentNullException.ThrowIfNull(connection);

      connection.SyncFlag = false;
      await Context.Database.EnsureCreatedAsync();

      var records = Context.Set<Connection>();
      var existingRecord = connection.Id == Guid.Empty
        ? null
        : await records.FindAsync(connection.Id);

      if (existingRecord == null)
      {
        connection.CreatedAt = DateTime.UtcNow;
        await records.AddAsync(connection);
      }  
      else
      {
        connection.UpdatedAt = DateTime.UtcNow;
        Context.Entry(existingRecord).CurrentValues.SetValues(connection);
      }  
        
      await Context.SaveChangesAsync();
      return existingRecord ?? connection;
    }

    // Giữ tương thích với các điểm gọi cũ.
    public Task<List<Connection>> GetAllConnectionAsync()
      => GetAllAsync();

    public Task<List<Connection>> GetAllConnectionWeightAsync_SyncData()
      => GetAllWeightNotSynchronizedAsync();

    public Task<Connection?> GetConnectionByIdAsync(Guid? id)
      => !id.HasValue || id == Guid.Empty
        ? Task.FromResult<Connection?>(null)
        : GetByIdAsync(id.Value);

  }
}
