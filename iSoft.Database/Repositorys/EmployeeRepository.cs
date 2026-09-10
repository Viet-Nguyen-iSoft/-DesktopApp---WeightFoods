using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Repositorys
{
  public class EmployeeRepository : GenericRepository<Employee, CommonDbContext>
  {
    public EmployeeRepository(DbContext context) : base(context)
    {

    }
    
  }
}
