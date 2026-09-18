using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.Database.Repositorys
{
  public class PermissionRepository : GenericRepository<Permission, CommonDbContext>
  {
    public PermissionRepository(CommonDbContext context) : base(context)
    {
    }

    public Task<List<Permission>> GetAllAsync(bool isContainDelete = false)
    {
      var query = Context.Set<Permission>()
        .Include(permission => permission.Users)
        .AsNoTracking()
        .AsQueryable();
      if (!isContainDelete)
        query = query.Where(permission => permission.DeletedFlag != true);

      return query
        .OrderBy(permission => permission.Order)
        .ThenBy(permission => permission.Name)
        .ToListAsync();
    }

    public Task<Permission?> GetByIdAsync(
      Guid id,
      bool isContainDelete = false)
    {
      var query = Context.Set<Permission>()
        .Include(permission => permission.Users)
        .AsNoTracking()
        .AsQueryable();
      if (!isContainDelete)
        query = query.Where(permission => permission.DeletedFlag != true);

      return query.FirstOrDefaultAsync(permission => permission.Id == id);
    }

    public Task<Permission?> GetByCodeAsync(
      string permissionCode,
      bool isContainDelete = false)
    {
      if (string.IsNullOrWhiteSpace(permissionCode))
        throw new ArgumentException(
          "Permission code is required.",
          nameof(permissionCode));

      var query = Context.Set<Permission>()
        .Include(permission => permission.Users)
        .AsNoTracking()
        .AsQueryable();
      if (!isContainDelete)
        query = query.Where(permission => permission.DeletedFlag != true);

      return query.FirstOrDefaultAsync(permission =>
        permission.PermissionCode == permissionCode);
    }

    public async Task<Permission> AddOrUpdateAsync(Permission permission)
    {
      ArgumentNullException.ThrowIfNull(permission);
      await Context.Database.EnsureCreatedAsync();

      var permissions = Context.Set<Permission>();
      var existingPermission = permission.Id == Guid.Empty
        ? null
        : await permissions.FindAsync(permission.Id);

      if (existingPermission == null)
      {
        if (permission.Id == Guid.Empty)
          permission.Id = Guid.NewGuid();

        permission.CreatedAt ??= DateTime.UtcNow;
        await permissions.AddAsync(permission);
      }
      else
      {
        permission.UpdatedAt = DateTime.UtcNow;
        Context.Entry(existingPermission).CurrentValues.SetValues(permission);
      }

      await Context.SaveChangesAsync();
      return existingPermission ?? permission;
    }

    public async Task<Permission> DeleteAsync(Permission permission)
    {
      ArgumentNullException.ThrowIfNull(permission);

      permission.DeletedFlag = true;
      permission.UpdatedAt = DateTime.UtcNow;
      return await AddOrUpdateAsync(permission);
    }
  }
}
