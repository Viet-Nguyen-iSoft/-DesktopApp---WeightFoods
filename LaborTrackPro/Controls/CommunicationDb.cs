using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;
using Microsoft.EntityFrameworkCore;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using Connection = iSoft.Database.Models.Connection;
using Department = iSoft.Database.Models.Department;
using Station = iSoft.Database.Models.Station;
namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
    public async Task<Connection> AddConnection(Connection connection)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Connection, PostgresDbContext>(context);
        return await repo.AddAsync(connection);
      }
    }

    public async Task<bool> UpdateConnection(Connection connection)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Connection, PostgresDbContext>(context);
        return await repo.UpdateAsync(connection);
      }
    }

    public async Task<Connection> CheckAddNewOrUpdate(Connection connection)
    {
      if (connection.Id > 0)
      {
        connection.UpdatedAt = DateTime.Now;
        await UpdateConnection(connection);
        return connection;
      }
      else
      {
        connection.CreatedAt = DateTime.Now;
        return await AddConnection(connection);
      }
    }

    public async Task<AppConfig> GetAppConfigAsync()
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<AppConfig, PostgresDbContext>(context);
        var rs = await repo.GetAllAsync();
        if (rs != null)
        {
          return rs?.FirstOrDefault() ?? new AppConfig();
        }
        else
        {
          return new AppConfig();
        }
      }
    }

    public async Task<bool> UpdateAppConfig_Async(AppConfig appConfig)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<AppConfig, PostgresDbContext>(context);
        return await repo.UpdateAsync(appConfig);
      }
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Employee, PostgresDbContext>(context);
        return await repo.AddAsync(employee);
      }
    }

    public async Task AddRangeEmployeesAsync(List<Employee> employees)
    {
      //using (var context = new PostgresDbContext())
      //{
      //  var repo = new iSoft.Database.Repositorys.GenericRepository<Employee, PostgresDbContext>(context);
      //  await repo.AddRangeAsync(employees);
      //}

      try
      {
        foreach (var employee in employees)
        {
          using (var context = new PostgresDbContext())
          {
            foreach (var rm in employee.Departments)
              context.Entry(rm).State = EntityState.Unchanged;

            await context.AddAsync(employee);
            await context.SaveChangesAsync();
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task AddRangeCategoryTaresAsync(List<CategoryTare> categoryTares)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<CategoryTare, PostgresDbContext>(context);
        await repo.AddRangeAsync(categoryTares);
      }
    }

    public async Task AddRangeMaterialGroupAsync(List<ProductGroup> materialGroups)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<ProductGroup, PostgresDbContext>(context);
        await repo.AddRangeAsync(materialGroups);
      }
    }

    public async Task AddRangeMachinesAsync(List<Station> machines)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Station, PostgresDbContext>(context);
        await repo.AddRangeAsync(machines);
      }
    }


    public async Task<List<Employee>> GetAllEmployeeAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new EmployeeRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task<List<Employee>> GetAllEmployeeNotIncludeAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new EmployeeRepository(context);
        return await repo.GetAllNotIncludeAsync(isContainDelete);
      }
    }

    public async Task<List<CategoryTare>> GetAllCategoryTareAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new CategoryTareRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task<List<ProductGroup>> GetMaterialGroupsAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductGroupRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task<Employee?> FindEmployeeByAccount(string account, string password)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new EmployeeRepository(context);
        return await repo.GetEmployeeByAccount(account, password);
      }
    }

    public async Task AddRangeMaterialsAsync(List<Product> materials)
    {
      //using (var context = new PostgresDbContext())
      //{
      //  var repo = new iSoft.Database.Repositorys.GenericRepository<Material, PostgresDbContext>(context);
      //  await repo.AddRangeAsync(materials);
      //}

      //try
      //{
      //  foreach (var mr in materials)
      //  {
      //    using (var context = new PostgresDbContext())
      //    {
      //      foreach (var rm in mr.CategoryTares)
      //        context.Entry(rm).State = EntityState.Unchanged;
      //      await context.AddAsync(mr);
      //      await context.SaveChangesAsync();
      //    }
      //  }
      //}
      //catch (Exception)
      //{
      //  throw;
      //}
    }

    public async Task UpdateRangeMaterialsAsync(List<Product> materials)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Product, PostgresDbContext>(context);
        await repo.UpdateRangeAsync(materials);
      }
    }


    public async Task UpdateRangeMaterialsAsync(Product material, List<CategoryTare>? categoryTares)
    {
      //try
      //{
      //  using (var context = new PostgresDbContext())
      //  {
      //    var repo = new iSoft.Database.Repositorys.GenericRepository<Product, PostgresDbContext>(context);

      //    // Load entity cũ từ DB kèm quan hệ
      //    var existingMaterial = await context.Materials
      //        .Include(po => po.CategoryTares) // nếu có CategoryTares
      //        .FirstOrDefaultAsync(po => po.Id == material.Id);

      //    if (existingMaterial == null)
      //      throw new Exception($"Material {material.Id} not found");

      //    // Update các field cơ bản
      //    existingMaterial.Group = material.Group;
      //    existingMaterial.Name = material.Name;
      //    existingMaterial.Grade = material.Grade;
      //    existingMaterial.Code = material.Code;
      //    existingMaterial.Unit = material.Unit;
      //    existingMaterial.LOT = material.LOT;
      //    existingMaterial.Supplier = material.Supplier;
      //    existingMaterial.Supplier = material.Unit;
      //    existingMaterial.ExpiredDate = material.ExpiredDate;
      //    existingMaterial.Note = material.Note;
      //    existingMaterial.LossPercent = material.LossPercent;
      //    existingMaterial.CodeLoss = material.CodeLoss;
      //    existingMaterial.WeightConversion = material.WeightConversion;
      //    existingMaterial.UnitConversion = material.UnitConversion;
      //    existingMaterial.StockTaking = material.StockTaking;
      //    existingMaterial.TareFlag = material.TareFlag;
      //    existingMaterial.ValueTare = material.ValueTare;
      //    existingMaterial.Description = material.Description;
      //    existingMaterial.TargetUnit = material.TargetUnit;
      //    existingMaterial.PathImage = material.PathImage;
      //    existingMaterial.MaterialType = material.MaterialType;
      //    existingMaterial.DeletedFlag = material.DeletedFlag;
      //    existingMaterial.CreatedAt = material.CreatedAt;
      //    existingMaterial.UpdatedAt = material.UpdatedAt;
      //    existingMaterial.IdSrc = material.IdSrc;
      //    existingMaterial.MaterialGroupId = material.MaterialGroupId;

      //    // ====== CategoryTares (N-N) ======
      //    existingMaterial.CategoryTares.Clear();
      //    if (categoryTares?.Count() > 0)
      //    {
      //      var ids = categoryTares.Select(m => m.Id).ToList();
      //      var matsFromDb = await context.CategoryTares
      //          .Where(m => ids.Contains(m.Id))
      //          .ToListAsync();

      //      foreach (var m in matsFromDb)
      //        existingMaterial.CategoryTares.Add(m);
      //    }

      //    await repo.UpdateAsync(existingMaterial);
      //  }
      //}
      //catch (Exception)
      //{
      //  throw;
      //}
    }








    public async Task<List<Product>> GetMaterialsAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task<List<Product>> GetMaterialTaresAsync()
    {
      //using (var context = new PostgresDbContext())
      //{
      //  var repo = new ProductRepository(context);
      //  return await repo.GetMaterialTaresAsync();
      //}

      return new List<Product>();
    }



  

    public async Task UpdateMaterials(Product material)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Product, PostgresDbContext>(context);
        await repo.UpdateAsync(material);
      }
    }



    public async Task<RecordWeight> AddRecordAsync(RecordWeight laborProductivityRecognition)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<RecordWeight, PostgresDbContext>(context);
          return await repo.AddAsync(laborProductivityRecognition);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<RecordWeight>> GetRecordByTime(DateTime start, DateTime end, eTypeData eTypeData)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.GetAllDataByTime(start, end, eTypeData);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }




    public async Task<List<RecordWeight>> GetAllDataLTPNotIncludeSynchronized_Fixbug()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.GetAllNotIncludeSynchronized_Fixbug();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }




    public async Task<List<Department>> GetDepartmentsAsync(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DepartmentRepository(context);
          return await repo.GetAllDepartment(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }








    public async Task<List<Station>> GetMachinesAsync(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new StationRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public LogAction AddLogAction(LogAction logAction)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<LogAction, PostgresDbContext>(context);
        return repo.Add(logAction);
      }
    }


    public async Task<List<LogAction>> GetLogAction_Async()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new LogActionRepository(context);
          var rs = await repo.GetAll_Async();
          if (rs != null)
          {
            return rs;
          }
          else
          {
            return new List<LogAction>();
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<List<LogAction>> GetLogAction_Async(DateTime from, DateTime to, eAction eAction)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new LogActionRepository(context);
          var rs = await repo.GetLogByFillter(from, to, eAction);
          if (rs != null)
          {
            return rs;
          }
          else
          {
            return new List<LogAction>();
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public async Task<Department> AddDepartmentAsync(Department department)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Department, PostgresDbContext>(context);
        return await repo.AddAsync(department);
      }
    }

    public async Task AddRangeDepartmentAsync(List<Department> departments)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Department, PostgresDbContext>(context);
        await repo.AddRangeAsync(departments);
      }

      //try
      //{
      //  foreach (var department in departments)
      //  {
      //    using (var context = new PostgresDbContext())
      //    {
      //      foreach (var rm in department.Employees)
      //        context.Entry(rm).State = EntityState.Unchanged;

      //      await context.AddAsync(department);
      //      await context.SaveChangesAsync();
      //    }
      //  }
      //}
      //catch (Exception ex)
      //{
      //  throw ex;
      //}
    }


    public async Task<Department> RemoveDepartment_Async(long id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new DepartmentRepository(context);
        return await repo.UpdateFlagDeleteAsync(id);
      }
    }

    public async Task<bool> UpdateDepartmentAsync(Department department)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Department, PostgresDbContext>(context);
        return await repo.UpdateAsync(department);
      }
    }
    public async Task UpdateRangeDepartmentAsync(List<Department> department)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Department, PostgresDbContext>(context);
        await repo.UpdateRangeAsync(department);
      }

      //try
      //{
      //  using (var context = new PostgresDbContext())
      //  {
      //    var repo = new iSoft.Database.Repositorys.GenericRepository<Department, PostgresDbContext>(context);

      //    // Load entity cũ từ DB kèm quan hệ
      //    var existingDepartment = await context.Departments
      //        .Include(po => po.Employees) // nếu có Materials
      //        .FirstOrDefaultAsync(po => po.Id == department.Id);

      //    if (existingDepartment == null)
      //      throw new Exception($"Department {department.Id} not found");

      //    // Update các field cơ bản
      //    existingDepartment.Name = department.Name;
      //    existingDepartment.Description = department.Description;
      //    existingDepartment.DeletedFlag = department.DeletedFlag;
      //    existingDepartment.CreatedAt = department.CreatedAt;
      //    existingDepartment.UpdatedAt = department.UpdatedAt;
      //    existingDepartment.IdSrc = department.IdSrc;

      //    // ====== Materials (N-N) ======
      //    existingDepartment?.Employees?.Clear();
      //    if (employees?.Count() > 0)
      //    {
      //      var ids = employees.Select(m => m.Id).ToList();
      //      var empFromDb = await context?.Employees?
      //          .Where(m => ids.Contains(m.Id))?
      //          .ToListAsync();

      //      foreach (var m in empFromDb)
      //        existingDepartment?.Employees?.Add(m);
      //    }

      //    await repo.UpdateAsync(existingDepartment);
      //  }
      //}
      //catch (Exception ex)
      //{
      //  throw ex;
      //}
    }



    public async Task<bool> UpdateRangeEmployeeAsync(List<Employee> employees)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<Employee, PostgresDbContext>(context);
          return await repo.UpdateRangeAsync(employees);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateRangeEmployeeAsync(Employee employee, List<Department> departments)
    {
      try
      {
        //using (var context = new PostgresDbContext())
        //{
        //  var repo = new iSoft.Database.Repositorys.GenericRepository<Employee, PostgresDbContext>(context);

        //  // Load entity cũ từ DB kèm quan hệ
        //  var existingEmployee = await context.Employees
        //      .Include(po => po.Departments) // nếu có Departments
        //      .FirstOrDefaultAsync(po => po.Id == employee.Id);

        //  if (existingEmployee == null)
        //    throw new Exception($"Department {employee.Id} not found");

        //  // Update các field cơ bản
        //  existingEmployee.FullName = employee.FullName;
        //  existingEmployee.Account = employee.Account;
        //  existingEmployee.Passwords = employee.Passwords;
        //  existingEmployee.Code = employee.Code;
        //  existingEmployee.IdCardCode = employee.IdCardCode;
        //  existingEmployee.IdCardName = employee.IdCardName;
        //  existingEmployee.IsAllowOverWeight = employee.IsAllowOverWeight;
        //  existingEmployee.DeletedFlag = employee.DeletedFlag;
        //  existingEmployee.CreatedAt = employee.CreatedAt;
        //  existingEmployee.UpdatedAt = employee.UpdatedAt;
        //  existingEmployee.IdSrc = employee.IdSrc;

        //  // ====== Departments (N-N) ======
        //  existingEmployee?.Departments?.Clear();
        //  if (departments?.Count() > 0)
        //  {
        //    var ids = departments.Select(m => m.Id).ToList();
        //    var empFromDb = await context?.Departments?
        //        .Where(m => ids.Contains(m.Id))?
        //        .ToListAsync();

        //    foreach (var m in empFromDb)
        //      existingEmployee?.Departments?.Add(m);
        //  }

        //  await repo.UpdateAsync(existingEmployee);
        //}
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateRangeCategoryTareAsync(List<CategoryTare> categoryTares)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<CategoryTare, PostgresDbContext>(context);
        return await repo.UpdateRangeAsync(categoryTares);
      }
    }

    public async Task<bool> UpdateRangeMaterialGroupAsync(List<ProductGroup> materialGroups)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<ProductGroup, PostgresDbContext>(context);
        return await repo.UpdateRangeAsync(materialGroups);
      }
    }


    public async Task<Department> GetDepartmentById_Async(long id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new DepartmentRepository(context);
        return await repo.GetByIdAsync(id);
      }
    }

    public async Task<Employee> RemoveEmployee_Async(long id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new EmployeeRepository(context);
        return await repo.UpdateFlagDeleteAsync(id);
      }
    }

    public async Task<Employee?> GetEmployeeByIdAsync(long? id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new EmployeeRepository(context);
        return await repo.GetByIdAsync(id);
      }
    }



    public async Task<bool> UpdateEmployee_Async(Employee employee)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Employee, PostgresDbContext>(context);
        return await repo.UpdateAsync(employee);
      }
    }
    public async Task<bool> UpdateRangeMachineAsync(List<Station> machines)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Station, PostgresDbContext>(context);
        return await repo.UpdateRangeAsync(machines);
      }
    }


    public async Task<RecordWeight> RemoveDatalog_Async(long id, long idEmloyee)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.UpdateFlagDeleteAsync(id, idEmloyee);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

   
    public async Task<List<Connection>> GetConnectionAsync()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new ConnectionRepository(context);
          return await repo.GetAllConnectionAsync();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public async Task<Connection?> GetConnectionByIdAsync(long? id)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new ConnectionRepository(context);
          return await repo.GetConnectionByIdAsync(id);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }




    public async Task<List<RecordWeight>?> GetRecordByPOAsync(long idPO, DateTime dt, EnumInternalExternalStatus enumInternalExternalStatus, EnumExportImport enumExportImport)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.GetRecordByPOAsync(idPO, dt, enumInternalExternalStatus, enumExportImport);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<RecordWeight>?> GetRecordByRequestOtherAsync(long? employeeId, DateTime dt, EnumInternalExternalStatus enumInternalExternalStatus)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.GetRecordByRequestOtherAsync(employeeId, dt, enumInternalExternalStatus);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<RecordWeight>> GetDataExpire(DateTime dt)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.GetRecordExpireAsync(dt);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<RecordWeight?> GetDatalogWeightByAsync(long? id)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.GetDatalogWeightByAsync(id);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public async Task<bool> UpdateRecordAsync(List<RecordWeight> datalogWeights)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.UpdateRangeAsync(datalogWeights);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public async Task<bool> UpdateRecordAsync(long idRecordDelivery, RecordWeight laborProductivityRecognition)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new RecordFoodsRepository(context);
          return await repo.UpdateData(laborProductivityRecognition, idRecordDelivery);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }





  







  }
}
