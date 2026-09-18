using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;

namespace iSoft.Database.Service
{
  public class PermissionService
  {
    public async Task<List<Permission>> GetAllAsync(bool isContainDelete = false)
    {
      await using var context = new MySqlDbContext();
      var repository = new PermissionRepository(context);
      return await repository.GetAllAsync(isContainDelete).ConfigureAwait(false);
    }

    public async Task<Permission?> GetByIdAsync(
      Guid id,
      bool isContainDelete = false)
    {
      await using var context = new MySqlDbContext();
      var repository = new PermissionRepository(context);
      return await repository.GetByIdAsync(id, isContainDelete).ConfigureAwait(false);
    }

    public async Task<Permission?> GetByCodeAsync(
      string permissionCode,
      bool isContainDelete = false)
    {
      await using var context = new MySqlDbContext();
      var repository = new PermissionRepository(context);
      return await repository.GetByCodeAsync(permissionCode, isContainDelete)
        .ConfigureAwait(false);
    }

    public async Task<Permission> AddOrUpdateAsync(Permission permission)
    {
      await using var context = new MySqlDbContext();
      var repository = new PermissionRepository(context);
      return await repository.AddOrUpdateAsync(permission).ConfigureAwait(false);
    }

    public async Task<Permission> DeleteAsync(Permission permission)
    {
      await using var context = new MySqlDbContext();
      var repository = new PermissionRepository(context);
      return await repository.DeleteAsync(permission).ConfigureAwait(false);
    }
  }
}
