using HSF.Database.Entities;
using iSoft.DatabaseServer.DbContexts;
using iSoft.DatabaseServer.Models;
using iSoft.DatabaseServer.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
    public async Task<List<MaterialEntity>> GetMaterialEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new MaterialEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<UserGroupEntity>> GetDepartmentEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new DepartmentEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<ProductionOrderEntity>> GetProductionOrderEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new ProductionOrderEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<UserEntity>> GetEmployeeEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new EmployeeEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<TareCategoryEntity>> GetTareCategoryEntities(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new TareCategoryEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<MachineEntity>> GetMachineEntities(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new MachineEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<FactoryEntity>> GetFactoryEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new FactoryEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
    public async Task<WeightTicketEntities?> GetWeightTicketEntityById(long? idSrc, Guid? machineId, DateTime dt)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new WeightTicketEntityRepository(context);
          return await repo.GetByIdSrcAsync(idSrc, machineId, dt);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<LaborProductivityRecognitionEntity>?> GetLaborDatalogEntitiesAsync()
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new LaborProductivityRecognitionEntityRepository(context);
          return await repo.GetAllDataAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<LaborProductivityRecognitionEntity>?> GetLaborDatalogEntitiesAsync(Guid? machineId)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new LaborProductivityRecognitionEntityRepository(context);
          return await repo.GetAllDataAsync(machineId);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateLaborDatalogEntitiesAsync(LaborProductivityRecognitionEntity record)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new LaborProductivityRecognitionEntityRepository(context);
          await repo.UpdateAsync(record);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task AddOrUpdateLaborDatalogEntitiesAsync(LaborProductivityRecognitionEntity record)
    {
      try
      {
        if (record != null)
        {
          using (var context = new PostgresDbContextServer())
          {
            var repo = new LaborProductivityRecognitionEntityRepository(context);
            var exits = await repo.GetByIdSrcAsync(record?.IdSrc, record?.DataMachineId, (DateTime)record.CreatedAt);

            if (exits != null)
            {
              //if (exits?.WeightTicketId!=null)
              //{
              //  exits.WeightTicketId = record?.WeightTicketId;
              //}  
              exits.CheckData = record.CheckData;
              exits.DeletedFlag = record?.DeletedFlag;
              exits.UpdatedAt = record?.UpdatedAt;
              await repo.UpdateAsync(exits);
            }
            else
            {
              await repo.AddAsync(record);
            }
          }
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
    public async Task AddRangeLaborDatalogEntitiesAsync(List<LaborProductivityRecognitionEntity> records)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<LaborProductivityRecognitionEntity, PostgresDbContextServer>(context);
          await repo.AddRangeAsync(records);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task AddDatalogEntitiesAsync(LaborProductivityRecognitionEntity record)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<LaborProductivityRecognitionEntity, PostgresDbContextServer>(context);
          await repo.AddAsync(record);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateRangeDatalogEntitiesAsync(List<LaborProductivityRecognitionEntity> records)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<LaborProductivityRecognitionEntity, PostgresDbContextServer>(context);
          await repo.UpdateRangeAsync(records);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<LaborProductivityRecognitionEntity?> GetDatalogEntitynByIdSrc(long idSrc, Guid? machineId, DateTime dateTime)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new LaborProductivityRecognitionEntityRepository(context);
          return await repo.GetByIdSrcAsync(idSrc, machineId, dateTime);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task AddRangeConnectionEntitiesAsync(List<ConnectionEntity> connectionEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<ConnectionEntity, PostgresDbContextServer>(context);
          await repo.AddRangeAsync(connectionEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task AddRangeWarningEntitiesAsync(List<WarningEntity> warningEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<WarningEntity, PostgresDbContextServer>(context);
          await repo.AddRangeAsync(warningEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateRangeConnectionEntitiesAsync(List<ConnectionEntity> connectionEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<ConnectionEntity, PostgresDbContextServer>(context);
          await repo.UpdateRangeAsync(connectionEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task UpdateRangeWarningEntityAsync(List<WarningEntity> warningEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new iSoft.DatabaseServer.Repositorys.GenericRepository<WarningEntity, PostgresDbContextServer>(context);
          await repo.UpdateRangeAsync(warningEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<ConnectionEntity>> GetConnectionWeightServerAsync()
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new ConnectionEntityRepository(context);
          return await repo.GetAllAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<WarningEntity>> GetWarningEntityServerAsync()
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new WarningEntityRepository(context);
          return await repo.GetAllAsync();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ProductionOrderEntity?> GetProductionOrderEntityByIdSrcAsync(Guid? idSrc)
    {
      try
      {
        if (idSrc == null || idSrc == Guid.Empty)
        {
          return null;
        }

        using (var context = new PostgresDbContextServer())
        {
          var repo = new ProductionOrderEntityRepository(context);
          return await repo.GetDataByIdSrcAsync((Guid)idSrc);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<MaterialEntity?> GetMaterialEntityByIdSrcAsync(Guid? idSrc)
    {
      try
      {
        if (idSrc == null || idSrc == Guid.Empty)
        {
          return null;
        }

        using (var context = new PostgresDbContextServer())
        {
          var repo = new MaterialEntityRepository(context);
          return await repo.GetDataByIdSrcAsync((Guid)idSrc);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<ProductEntity?> GetProductionEntityByIdSrcAsync(Guid? idSrc)
    {
      try
      {
        if (idSrc == null || idSrc == Guid.Empty)
        {
          return null;
        }

        using (var context = new PostgresDbContextServer())
        {
          var repo = new ProductionEntityRepository(context);
          return await repo.GetDataByIdSrcAsync((Guid)idSrc);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<MachineEntity?> GetMachineEntityByIdSrcAsync(Guid? idSrc)
    {
      try
      {
        if (idSrc == null || idSrc == Guid.Empty)
        {
          return null;
        }

        using (var context = new PostgresDbContextServer())
        {
          var repo = new MachineEntityRepository(context);
          return await repo.GetDataByIdSrcAsync((Guid)idSrc);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<DeliveryScheduleEntity?> GetDeliveryScheduleEntityByIdSrcAsync(Guid? idSrc)
    {
      try
      {
        if (idSrc == null || idSrc == Guid.Empty)
        {
          return null;
        }

        using (var context = new PostgresDbContextServer())
        {
          var repo = new DeliveryScheduleEntityRepository(context);
          return await repo.GetDataByIdSrcAsync((Guid)idSrc);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<TareCategoryEntity?> GetTareCategoryEntityByIdSrcAsync(Guid? idSrc)
    {
      try
      {
        if (idSrc == null || idSrc == Guid.Empty)
        {
          return null;
        }

        using (var context = new PostgresDbContextServer())
        {
          var repo = new TareCategoryEntityRepository(context);
          return await repo.GetDataByIdSrcAsync((Guid)idSrc);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task<UserEntity?> GetEmployeeEntityByIdSrcAsync(Guid? idSrc)
    {
      try
      {
        if (idSrc == null || idSrc == Guid.Empty)
        {
          return null;
        }

        using (var context = new PostgresDbContextServer())
        {
          var repo = new EmployeeEntityRepository(context);
          return await repo.GetDataByIdSrcAsync((Guid)idSrc);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateFactoryEntityAsync(List<FactoryEntity> factoryEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new GenericRepository<FactoryEntity, PostgresDbContextServer>(context);
          return await repo.UpdateRangeAsync(factoryEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateMachineEntityAsync(List<MachineEntity> machineEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new GenericRepository<MachineEntity, PostgresDbContextServer>(context);
          return await repo.UpdateRangeAsync(machineEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateMaterialEntityAsync(List<MaterialEntity> materialEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new GenericRepository<MaterialEntity, PostgresDbContextServer>(context);
          return await repo.UpdateRangeAsync(materialEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateProductionOrderEntityAsync(ProductionOrderEntity productionOrderEntity)
    {
      try
      {
        return true;
        //using (var context = new PostgresDbContextServer())
        //{
        //  var repo = new GenericRepository<ProductionOrderEntity, PostgresDbContextServer>(context);

        //  // Load entity cũ từ DB kèm quan hệ
        //  var existingOrder = await context.ProductionOrderEntities
        //      .Include(po => po.Materials) // nếu có Materials
        //      .FirstOrDefaultAsync(po => po.Id == productionOrderEntity.Id);

        //  if (existingOrder == null)
        //    throw new Exception($"ProductionOrder {productionOrderEntity.Id} not found");

        //  // Update các field cơ bản
        //  existingOrder.Name = productionOrderEntity.Name;
        //  existingOrder.Code = productionOrderEntity.Code;
        //  existingOrder.Description = productionOrderEntity.Description;
        //  existingOrder.eTypeProductionOrder = productionOrderEntity.eTypeProductionOrder;
        //  existingOrder.EffectiveFrom = productionOrderEntity.EffectiveFrom;
        //  existingOrder.EffectiveTo = productionOrderEntity.EffectiveTo;
        //  existingOrder.DeletedFlag = productionOrderEntity.DeletedFlag;
        //  existingOrder.SyncFlag = true;
        //  existingOrder.CreatedAt = productionOrderEntity.CreatedAt;
        //  existingOrder.UpdatedAt = productionOrderEntity.UpdatedAt;

        //  // ====== Materials (N-N) ======
        //  existingOrder.Materials.Clear();
        //  if (productionOrderEntity.Materials != null && productionOrderEntity.Materials.Count > 0)
        //  {
        //    var ids = productionOrderEntity.Materials.Select(m => m.Id).ToList();
        //    var matsFromDb = await context.MaterialEntities
        //        .Where(m => ids.Contains(m.Id))
        //        .ToListAsync();

        //    foreach (var m in matsFromDb)
        //    {
        //      existingOrder.Materials.Add(m);
        //    }
        //  }

        //  return await repo.UpdateAsync(existingOrder);
        //}
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> UpdateProductionEntityAsync(ProductEntity productionEntity)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new GenericRepository<ProductEntity, PostgresDbContextServer>(context);

          // Load entity cũ từ DB kèm quan hệ
          var existingOrder = await context.ProductionEntities
              .Include(po => po.Materials) // nếu có Materials
              .FirstOrDefaultAsync(po => po.Id == productionEntity.Id);

          if (existingOrder == null)
            throw new Exception($"ProductionOrder {productionEntity.Id} not found");

          // Update các field cơ bản
          existingOrder.Name = productionEntity.Name;
          existingOrder.Code = productionEntity.Code;
          existingOrder.Description = productionEntity.Description;
          existingOrder.DeletedFlag = productionEntity.DeletedFlag;
          existingOrder.SyncFlag = true;
          existingOrder.CreatedAt = productionEntity.CreatedAt;
          existingOrder.UpdatedAt = productionEntity.UpdatedAt;

          // ====== Materials (N-N) ======
          existingOrder.Materials.Clear();
          if (productionEntity.Materials != null && productionEntity.Materials.Count > 0)
          {
            var ids = productionEntity.Materials.Select(m => m.Id).ToList();
            var matsFromDb = await context.MaterialEntities
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();

            foreach (var m in matsFromDb)
            {
              existingOrder.Materials.Add(m);
            }
          }

          return await repo.UpdateAsync(existingOrder);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> UpdateEmployeeEntityAsync(List<UserEntity> employeeEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new GenericRepository<UserEntity, PostgresDbContextServer>(context);
          return await repo.UpdateRangeAsync(employeeEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool?> UpdateDatalogEntity(LaborProductivityRecognitionEntity laborProductivityRecognitionEntity)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new LaborProductivityRecognitionEntityRepository(context);
          return await repo.UpdateAsync(laborProductivityRecognitionEntity);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool?> UpdateWeightTicketEntity(WeightTicketEntities weightTicketEntities)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new WeightTicketEntityRepository(context);
          return await repo.UpdateAsync(weightTicketEntities);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
    public async Task<WeightTicketEntities> AddWeightTicketEntitiesAsync(WeightTicketEntities weightTicket)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new GenericRepository<WeightTicketEntities, PostgresDbContextServer>(context);
          return await repo.AddAsync(weightTicket);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<WeightTicketEntities>?> GetAllTicketEntitiesAsync_Fixbug()
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new WeightTicketEntityRepository(context);
          return await repo.GetAllAsync_Fixbug();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<WeightTicketEntities>?> GetAllTicketEntitiesAsync_Fixbug(Guid? machineId)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new WeightTicketEntityRepository(context);
          return await repo.GetAllAsync_Fixbug(machineId);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task<List<ProductEntity>> GetProductionEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new ProductionEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<MaterialSettingEntity>> GetProductionWeightEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new ProductionWeightEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task<List<MaterialTareEntity>> GetMaterialTareEntitys(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new MaterialTareEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }


    public async Task<List<MaterialGroupEntity>> GetMaterialGroupEntities(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new MaterialGroupEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DeliveryScheduleEntity>> GetDeliveryScheduleEntity(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new DeliveryScheduleEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<DeliveryScheduleMaterialEntity>> GetDeliveryScheduleMaterialEntity(bool isContainDelete = false)
    {
      try
      {
        using (var context = new PostgresDbContextServer())
        {
          var repo = new DeliveryScheduleMaterialEntityRepository(context);
          return await repo.GetAllAsync(isContainDelete);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
