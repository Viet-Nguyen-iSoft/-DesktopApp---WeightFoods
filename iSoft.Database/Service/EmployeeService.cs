using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.Database.Service
{
  public class EmployeeService
  {
    public async Task<List<Employee>> GetAllAsync(bool isContainDelete = false)
    {
      await using var context = new MySqlDbContext();

      var query = context.Set<Employee>().AsQueryable();
      if (!isContainDelete)
        query = query.Where(employee => !employee.DeletedFlag);

      return await query
        .Include(employee => employee.Departments)
        .ToListAsync()
        .ConfigureAwait(false);
    }
  }
}
