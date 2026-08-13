using DocumentFormat.OpenXml.Bibliography;
using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;
using iSoft.DatabaseServer.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using Connection = iSoft.Database.Models.Connection;
using Department = iSoft.Database.Models.Department;
using Machine = iSoft.Database.Models.Machine;
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

    public async Task<Machine> GetMachineAsync()
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Machine, PostgresDbContext>(context);
        var rs = await repo.GetAllAsync();
        return rs?.FirstOrDefault(x => x.EnableFlag == true && x.DeletedFlag == false) ?? new Machine();
      }
    }

    public async Task<List<SettingLabel>?> GetSettingLabelsAsync()
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<SettingLabel, PostgresDbContext>(context);
        var rs = await repo.GetAllAsync();
        return rs?.Where(x => x.DeletedFlag == false).ToList() ?? new List<SettingLabel>();
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

    public async Task AddRangeMaterialGroupAsync(List<MaterialGroup> materialGroups)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<MaterialGroup, PostgresDbContext>(context);
        await repo.AddRangeAsync(materialGroups);
      }
    }

    public async Task AddRangeMachinesAsync(List<Machine> machines)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Machine, PostgresDbContext>(context);
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

    public async Task<List<MaterialGroup>> GetMaterialGroupsAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialGroupRepository(context);
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

    public async Task RemoveSettingLabel(long id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new SettingLabelRepository(context);
        await repo.RemoveByIdAsync(id);
      }
    }
    public async Task AddRangeMaterialsAsync(List<Material> materials)
    {
      //using (var context = new PostgresDbContext())
      //{
      //  var repo = new iSoft.Database.Repositorys.GenericRepository<Material, PostgresDbContext>(context);
      //  await repo.AddRangeAsync(materials);
      //}

      try
      {
        foreach (var mr in materials)
        {
          using (var context = new PostgresDbContext())
          {
            foreach (var rm in mr.CategoryTares)
              context.Entry(rm).State = EntityState.Unchanged;
            await context.AddAsync(mr);
            await context.SaveChangesAsync();
          }
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateRangeMaterialsAsync(List<Material> materials)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Material, PostgresDbContext>(context);
        await repo.UpdateRangeAsync(materials);
      }
    }


    public async Task UpdateRangeMaterialsAsync(Material material, List<CategoryTare>? categoryTares)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<Material, PostgresDbContext>(context);

          // Load entity cũ từ DB kèm quan hệ
          var existingMaterial = await context.Materials
              .Include(po => po.CategoryTares) // nếu có CategoryTares
              .FirstOrDefaultAsync(po => po.Id == material.Id);

          if (existingMaterial == null)
            throw new Exception($"Material {material.Id} not found");

          // Update các field cơ bản
          existingMaterial.Group = material.Group;
          existingMaterial.Name = material.Name;
          existingMaterial.Grade = material.Grade;
          existingMaterial.Code = material.Code;
          existingMaterial.Unit = material.Unit;
          existingMaterial.LOT = material.LOT;
          existingMaterial.Supplier = material.Supplier;
          existingMaterial.Supplier = material.Unit;
          existingMaterial.ExpiredDate = material.ExpiredDate;
          existingMaterial.Note = material.Note;
          existingMaterial.LossPercent = material.LossPercent;
          existingMaterial.CodeLoss = material.CodeLoss;
          existingMaterial.WeightConversion = material.WeightConversion;
          existingMaterial.UnitConversion = material.UnitConversion;
          existingMaterial.StockTaking = material.StockTaking;
          existingMaterial.TareFlag = material.TareFlag;
          existingMaterial.ValueTare = material.ValueTare;
          existingMaterial.Description = material.Description;
          existingMaterial.TargetUnit = material.TargetUnit;
          existingMaterial.PathImage = material.PathImage;
          existingMaterial.MaterialType = material.MaterialType;
          existingMaterial.DeletedFlag = material.DeletedFlag;
          existingMaterial.CreatedAt = material.CreatedAt;
          existingMaterial.UpdatedAt = material.UpdatedAt;
          existingMaterial.IdSrc = material.IdSrc;
          existingMaterial.MaterialGroupId = material.MaterialGroupId;

          // ====== CategoryTares (N-N) ======
          existingMaterial.CategoryTares.Clear();
          if (categoryTares?.Count() > 0)
          {
            var ids = categoryTares.Select(m => m.Id).ToList();
            var matsFromDb = await context.CategoryTares
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();

            foreach (var m in matsFromDb)
              existingMaterial.CategoryTares.Add(m);
          }

          await repo.UpdateAsync(existingMaterial);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task AddRangeProductionOrdersAsync(List<ProductionOrder> productionOrders)
    {
      try
      {
        foreach (var po in productionOrders)
        {
          using (var context = new PostgresDbContext())
          {
            foreach (var rm in po.Materials)
              context.Entry(rm).State = EntityState.Unchanged;

            foreach (var rm in po.Productions)
              context.Entry(rm).State = EntityState.Unchanged;

            foreach (var rm in po.MaterialSettings)
              context.Entry(rm).State = EntityState.Unchanged;
            await context.AddAsync(po);
            await context.SaveChangesAsync();
          }
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

   
    public async Task UpdateProductionOrdersAsync(ProductionOrder productionOrder, List<Material>? materials, List<Production> productions)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<ProductionOrder, PostgresDbContext>(context);

          // Load entity cũ từ DB kèm quan hệ
          var existingOrder = await context.ProductionOrders
              .Include(po => po.Materials) // nếu có Materials
              .Include(po => po.Productions) // nếu có Productions
              .FirstOrDefaultAsync(po => po.Id == productionOrder.Id);

          if (existingOrder == null)
            throw new Exception($"ProductionOrder {productionOrder.Id} not found");

          // Update các field cơ bản
          existingOrder.Name = productionOrder.Name;
          existingOrder.Code = productionOrder.Code;
          existingOrder.Description = productionOrder.Description;
          existingOrder.ProductionOrderType = productionOrder.ProductionOrderType;
          existingOrder.ProductionOrderCategory = productionOrder.ProductionOrderCategory;
          existingOrder.EnumProcessing = productionOrder.EnumProcessing;
          existingOrder.EffectiveFrom = productionOrder.EffectiveFrom;
          existingOrder.EffectiveTo = productionOrder.EffectiveTo;
          existingOrder.EffectiveFromExternal = productionOrder.EffectiveFromExternal;
          existingOrder.EffectiveToExternal = productionOrder.EffectiveToExternal;
          existingOrder.ApproveStatus = productionOrder.ApproveStatus;
          existingOrder.WarningStatus = productionOrder.WarningStatus;
          existingOrder.DeletedFlag = productionOrder.DeletedFlag;
          existingOrder.CreatedAt = productionOrder.CreatedAt;
          existingOrder.UpdatedAt = productionOrder.UpdatedAt;
          existingOrder.IdSrc = productionOrder.IdSrc;

          // ====== Materials (N-N) ======
          existingOrder.Materials.Clear();
          if (materials?.Count() > 0)
          {
            var ids = materials.Select(m => m.Id).ToList();
            var matsFromDb = await context.Materials
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();

            foreach (var m in matsFromDb)
              existingOrder.Materials.Add(m);
          }

          // ====== Productions (N-N) ======
          existingOrder.Productions.Clear();
          if (productions?.Count() > 0)
          {
            var ids = productions.Select(m => m.Id).ToList();
            var matsFromDb = await context.Productions
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();

            foreach (var m in matsFromDb)
              existingOrder.Productions.Add(m);
          }

          await repo.UpdateAsync(existingOrder);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateProductionOrdersAsync(List<ProductionOrder> productionOrders)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<ProductionOrder, PostgresDbContext>(context);
          await repo.UpdateRangeAsync(productionOrders);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateProductionAsync(Production production, List<Material>? materials)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<Production, PostgresDbContext>(context);

          // Load entity cũ từ DB kèm quan hệ
          var existingOrder = await context.Productions
              .Include(po => po.Materials) // nếu có Materials
              .FirstOrDefaultAsync(po => po.Id == production.Id);

          if (existingOrder == null)
            throw new Exception($"ProductionOrder {production.Id} not found");

          // Update các field cơ bản
          existingOrder.Name = production.Name;
          existingOrder.Code = production.Code;
          existingOrder.Description = production.Description;
          existingOrder.DeletedFlag = production.DeletedFlag;
          existingOrder.CreatedAt = production.CreatedAt;
          existingOrder.UpdatedAt = production.UpdatedAt;
          existingOrder.IdSrc = production.IdSrc;

          // ====== Materials (N-N) ======
          existingOrder.Materials.Clear();
          if (materials != null && materials.Count > 0)
          {
            var ids = materials.Select(m => m.Id).ToList();
            var matsFromDb = await context.Materials
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();

            foreach (var m in matsFromDb)
              existingOrder.Materials.Add(m);
          }

          await repo.UpdateAsync(existingOrder);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task UpdateRangeProductionsAsync(List<Production> productions)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<Production, PostgresDbContext>(context);
          await repo.UpdateRangeAsync(productions);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task AddRangeFactoryiesAsync(List<Factory> factories)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Factory, PostgresDbContext>(context);
        foreach (var po in factories)
        {
          foreach (var rm in po.Machines)
          {
            context.Attach(rm);
          }
        }
        await repo.AddRangeAsync(factories);
      }
    }

    public async Task AddProductionOrdersAsync(ProductionOrder productionOrder)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<ProductionOrder, PostgresDbContext>(context);
        await repo.AddAsync(productionOrder);
      }
    }

    public async Task<List<Material>> GetMaterialsAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task<List<Material>> GetMaterialTaresAsync()
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        return await repo.GetMaterialTaresAsync();
      }
    }

    public async Task UpdateMaterial(Material material)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        await repo.UpdateMaterial(material);
      }
    }

    public async Task UpdateMaterials(List<Material> materials)
    {
      if (materials is null || materials.Count == 0)
        return;

      await using var context = new PostgresDbContext();
      var repo = new MaterialRepository(context);

      await repo.UpdateMaterials(materials);
    }

    public async Task<List<MaterialSetting>> GetMaterialSettingsAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialSettingRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task<Material?> GetMaterialsByIdAsync(long? id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        return await repo.GetMaterialsByIdAsync(id);
      }
    }

    public async Task<List<Material>> GetMaterialsAsync(EnumMaterialType eMaterialType)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        return await repo.GetAllAsync(eMaterialType);
      }
    }

    public async Task<List<Material>> GetMaterialsDefectAsync(Material material, EnumMaterialType eMaterialType = EnumMaterialType.MRsDefect)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        return await repo.GetMaterialsDefectAsync(material, (int)eMaterialType);
      }
    }
    public async Task<Material?> GetMaterialsByIdSrcAsync(Guid? guid)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        return await repo.GetMaterialsByIdSrcAsync(guid);
      }
    }


    public async Task<List<Production>> GetProductionsAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }
    public async Task<Production?> GetProductionByIdSrcAsync(Guid? guid)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionRepository(context);
        return await repo.GetProductionByIdSrcAsync(guid);
      }
    }

    public async Task<List<MaterialSetting>> GetProductionWeightsAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionWeightRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task UpdateMaterials(Material material)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Material, PostgresDbContext>(context);
        await repo.UpdateAsync(material);
      }
    }

    public async Task UpdateMaterialSetting(MaterialSetting productionWeight)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<MaterialSetting, PostgresDbContext>(context);
          await repo.UpdateAsync(productionWeight);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task UpdateRangeMaterialSetting(List<MaterialSetting> materialSettings)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<MaterialSetting, PostgresDbContext>(context);
          await repo.UpdateRangeAsync(materialSettings);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<DatalogWeight> AddRecordAsync(DatalogWeight laborProductivityRecognition)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<DatalogWeight, PostgresDbContext>(context);
          return await repo.AddAsync(laborProductivityRecognition);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogWeight>> GetRecordByTime(DateTime start, DateTime end, eTypeData eTypeData)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.GetAllDataByTime(start, end, eTypeData);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<List<DatalogDelivery>> GetDeliveryByTime(DateTime start, DateTime end)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogDeliveryRepository(context);
          return await repo.GetHistoricalAsync(start, end);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogWeight>?> GetAllDataLTPNotSynchronized()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.GetAllNotSynchronized();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogWeight>> GetAllDataLTPNotIncludeSynchronized_Fixbug()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.GetAllNotIncludeSynchronized_Fixbug();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task<bool> UpdateRecordSyncSuccess(List<DatalogWeight> record)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<DatalogWeight, PostgresDbContext>(context);
          return await repo.UpdateRangeAsync(record);
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

    public async Task<List<DeliverySchedule>> GetDeliveryScheduleAsync(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DeliveryScheduleRepository(context);
          return await repo.GetAllDeliverySchedule(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DeliverySchedule>> GetDataDeliveryScheduleAsync(
                                                                        long? materialId,
                                                                        long? productionOrderId,
                                                                        EnumExportImport? enumExportImport
                                                                        )
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DeliveryScheduleRepository(context);
          return await repo.GetDataDeliverySchedulesAsync(materialId, productionOrderId, enumExportImport);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DeliverySchedule>> GetDataDeliveryScheduleAsync(
                                                                            long? productionOrderId,
                                                                            EnumExportImport? enumExportImport
                                                                           )
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DeliveryScheduleRepository(context);
          return await repo.GetDataDeliverySchedulesAsync(productionOrderId, enumExportImport);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DeliveryScheduleMaterial>> GetDeliveryScheduleMaterialAsync(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DeliveryScheduleMaterialRepository(context);
          return await repo.GetAllDeliveryScheduleMaterial(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<Factory>> GetFactoriesAsync(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new FactoryRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<List<Machine>> GetMachinesAsync(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new MachineRepository(context);
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

    public async Task<List<ProductionOrder>> GetProductionOrdersAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionOrderRepository(context);
        return await repo.GetProductionOrdersAsync(isContainDelete);
      }
    }

    public async Task<List<ProductionOrder>> GetProductionOrdersShowUIAsync()
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionOrderRepository(context);
        return await repo.GetProductionOrdersShowUIAsync();
      }
    }

    public async Task<List<ProductionOrder>> GetAllProductionOrdersAsync()
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionOrderRepository(context);
        return await repo.GetProductionOrdersAsync();
      }
    }

    public async Task<List<Production>> GetProductionAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionRepository(context);
        return await repo.GetAllAsync(isContainDelete);
      }
    }

    public async Task<List<MaterialSetting>> GetMaterialSettingAsync(bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionWeightRepository(context);
        return await repo.GetAllAsync(isContainDelete);
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

    public async Task AddRangeDeliveryScheduleAsync(List<DeliverySchedule> deliverySchedules)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<DeliverySchedule, PostgresDbContext>(context);
        await repo.AddRangeAsync(deliverySchedules);
      }
    }

    public async Task AddRangeDeliveryScheduleMaterialAsync(List<DeliveryScheduleMaterial> deliveryScheduleMaterials)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<DeliveryScheduleMaterial, PostgresDbContext>(context);
        await repo.AddRangeAsync(deliveryScheduleMaterials);
      }
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

    public async Task UpdateRangeDeliveryScheduleAsync(List<DeliverySchedule> deliverySchedules)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<DeliverySchedule, PostgresDbContext>(context);
        await repo.UpdateRangeAsync(deliverySchedules);
      }
    }

    public async Task UpdateRangeDeliveryScheduleMaterialAsync(List<DeliveryScheduleMaterial> deliveryScheduleMaterials)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<DeliveryScheduleMaterial, PostgresDbContext>(context);
        await repo.UpdateRangeAsync(deliveryScheduleMaterials);
      }
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
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<Employee, PostgresDbContext>(context);

          // Load entity cũ từ DB kèm quan hệ
          var existingEmployee = await context.Employees
              .Include(po => po.Departments) // nếu có Departments
              .FirstOrDefaultAsync(po => po.Id == employee.Id);

          if (existingEmployee == null)
            throw new Exception($"Department {employee.Id} not found");

          // Update các field cơ bản
          existingEmployee.FullName = employee.FullName;
          existingEmployee.Account = employee.Account;
          existingEmployee.Passwords = employee.Passwords;
          existingEmployee.Code = employee.Code;
          existingEmployee.IdCardCode = employee.IdCardCode;
          existingEmployee.IdCardName = employee.IdCardName;
          existingEmployee.IsAllowOverWeight = employee.IsAllowOverWeight;
          existingEmployee.DeletedFlag = employee.DeletedFlag;
          existingEmployee.CreatedAt = employee.CreatedAt;
          existingEmployee.UpdatedAt = employee.UpdatedAt;
          existingEmployee.IdSrc = employee.IdSrc;

          // ====== Departments (N-N) ======
          existingEmployee?.Departments?.Clear();
          if (departments?.Count() > 0)
          {
            var ids = departments.Select(m => m.Id).ToList();
            var empFromDb = await context?.Departments?
                .Where(m => ids.Contains(m.Id))?
                .ToListAsync();

            foreach (var m in empFromDb)
              existingEmployee?.Departments?.Add(m);
          }

          await repo.UpdateAsync(existingEmployee);
        }
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

    public async Task<bool> UpdateRangeMaterialGroupAsync(List<MaterialGroup> materialGroups)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<MaterialGroup, PostgresDbContext>(context);
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

    public async Task<DeliverySchedule?> GetDeliveryScheduleByIdAsync(long? id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new DeliveryScheduleRepository(context);
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
    public async Task<bool> UpdateRangeMachineAsync(List<Machine> machines)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Machine, PostgresDbContext>(context);
        return await repo.UpdateRangeAsync(machines);
      }
    }
    public async Task<bool> UpdateRangeFactoryAsync(List<Factory> factories)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<Factory, PostgresDbContext>(context);
        return await repo.UpdateRangeAsync(factories);
      }
    }

    public async Task<DatalogWeight> RemoveDatalog_Async(long id, long idEmloyee)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.UpdateFlagDeleteAsync(id, idEmloyee);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task UpdateRangeConnectionAsync(List<Connection> connections)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<Connection, PostgresDbContext>(context);
          await repo.UpdateRangeAsync(connections);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task UpdateRangeWarningAsync(List<Warning> warnings)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<Warning, PostgresDbContext>(context);
          await repo.UpdateRangeAsync(warnings);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<List<Connection>> GetConnectionWeightLocalAsync()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new ConnectionRepository(context);
          return await repo.GetAllConnectionWeightAsync_SyncData();
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

    public async Task<List<Warning>> GetWarningLocalAsync()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new WarningRepository(context);
          return await repo.GetAllWarningAsync();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public async Task<List<DatalogWeight>?> GetRecordByPOAsync(long idPO, DateTime dt, EnumInternalExternalStatus enumInternalExternalStatus, EnumExportImport enumExportImport)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.GetRecordByPOAsync(idPO, dt, enumInternalExternalStatus, enumExportImport);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogWeight>?> GetRecordByRequestOtherAsync(long? employeeId, DateTime dt, EnumInternalExternalStatus enumInternalExternalStatus)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.GetRecordByRequestOtherAsync(employeeId, dt, enumInternalExternalStatus);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogWeight>> GetDataExpire(DateTime dt)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.GetRecordExpireAsync(dt);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<DatalogWeight?> GetDatalogWeightByAsync(long? id)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.GetDatalogWeightByAsync(id);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public async Task<bool> UpdateRecordAsync(List<DatalogWeight> datalogWeights)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.UpdateRangeAsync(datalogWeights);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<DatalogDelivery> AddDelivery(DatalogDelivery datalogDelivery)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<DatalogDelivery, PostgresDbContext>(context);
          return await repo.AddAsync(datalogDelivery);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> UpdateRecordAsync(long idRecordDelivery, DatalogWeight laborProductivityRecognition)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogWeightRepository(context);
          return await repo.UpdateData(laborProductivityRecognition, idRecordDelivery);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DatalogDelivery>?> GetAllDataDeliveryNotSynchronized()
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new DatalogDeliveryRepository(context);
          return await repo.GetAllNotSynchronized();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateDatalogDeliverySyncSuccess(DatalogDelivery datalogDeliveries)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<DatalogDelivery, PostgresDbContext>(context);
          return await repo.UpdateAsync(datalogDeliveries);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> UpdateRangeDatalogDeliverySyncSuccess(List<DatalogDelivery> datalogDeliveries)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          var repo = new iSoft.Database.Repositorys.GenericRepository<DatalogDelivery, PostgresDbContext>(context);
          return await repo.UpdateRangeAsync(datalogDeliveries);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task AddRangeProductionsAsync(List<Production> productions)
    {
      foreach (var po in productions)
      {
        using (var context = new PostgresDbContext())
        {
          foreach (var rm in po.Materials)
            context.Entry(rm).State = EntityState.Unchanged;

          context.Add(po);
          await context.SaveChangesAsync();
        }
      }
    }

    public async Task AddRangeProductionWeightsAsync(List<MaterialSetting> productionWeights)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<MaterialSetting, PostgresDbContext>(context);
        await repo.AddRangeAsync(productionWeights);
      }
    }

    public async Task<ProductionOrder?> GetProductionOrdersByIdSrcAsync(Guid? id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new ProductionOrderRepository(context);
        return await repo.GetPOByIdSrcAsync(id);
      }
    }

    public async Task<ProductionOrder?> GetPOByIdAsync(long? poId)
    {
      try
      {
        using (var context = new PostgresDbContext())
        {
          //Lấy thông tin PO
          var repo = new ProductionOrderRepository(context);
          return await repo.GetPOByIdAsync(poId);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<SettingLabel> AddSettingLabelAsync(SettingLabel department)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new SettingLabelRepository(context);
        return await repo.AddAsync(department);
      }
    }

    public async Task<bool> UpdateSettingLabelAsync(SettingLabel department)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new SettingLabelRepository(context);
        return await repo.UpdateAsync(department);
      }
    }

    public async Task<List<SettingLabel>> GetAllSettingLabelAsync(eTypeLabel eTypeLabel, bool isContainDelete = false)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new SettingLabelRepository(context);
        return await repo.GetAllAsync(eTypeLabel, isContainDelete);
      }
    }

    public async Task<List<CategoryTare>> GetAllCategoryTareByMaterialIdAsync(long? id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new CategoryTareRepository(context);
        return await repo.GetCategoryTareBuMaterialIdAsync(id);
      }
    }


    public async Task<Material?> GetAllCategoryTareByMaterialAsync(Material material)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialRepository(context);
        return await repo.GetAllCategoryTareByMaterialAsync(material);
      }
    }

    public async Task AddRangeMaterialTareAsync(List<MaterialTare> materialTares)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<MaterialTare, PostgresDbContext>(context);
        await repo.AddRangeAsync(materialTares);
      }
    }

    public async Task UpdateMaterialTareAsync(List<MaterialTare> materialTares)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new iSoft.Database.Repositorys.GenericRepository<MaterialTare, PostgresDbContext>(context);
        await repo.UpdateRangeAsync(materialTares);
      }
    }

    public async Task<MaterialTare?> GetMaterialTareByIdSrcAsync(Guid? id)
    {
      using (var context = new PostgresDbContext())
      {
        var repo = new MaterialTareRepository(context);
        return await repo.GetMaterialTareByIdSrcAsync(id);
      }
    }

    
  }
}
