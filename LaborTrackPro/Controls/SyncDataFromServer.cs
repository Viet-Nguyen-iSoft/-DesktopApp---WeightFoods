using DocumentFormat.OpenXml.Vml.Office;
using HelperManager;
using HSF.Database.Entities;
using iSoft.Database.Models;
using iSoft.DatabaseServer.Models;
using iSoft.RabbitMq;
using LaborTrackPro.Setting;
using Sprache;
using System.Diagnostics;
using System.Net.NetworkInformation;
using static HelperManager.EnumData;
using static iSoft.RabbitMq.Message;
using static LaborTrackPro.EnumData;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Department = iSoft.Database.Models.Department;
using EnumMaterialType = iSoft.Database.EnumData.EnumMaterialType;
using Machine = iSoft.Database.Models.Machine;

namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
    public System.Timers.Timer _timerSyncData = new System.Timers.Timer();

    private bool _isSyncDataLocal = false;
    public string _ipServer = "127.0.0.1";

    private int filterPV = 0;
    private int filterSV = 5;

    private bool IsPingServer
    {
      get
      {
        Ping ping = new Ping();
        PingReply FindPLC = ping.Send(_ipServer, 500);
        return FindPLC.Status.ToString().Equals("Success");
      }
    }

    public void InitSyncDataServer()
    {
      if (_isSyncDataLocal)
      {
        //Timer Sync
        this._timerSyncData.Interval = (double)(_appConfig?.TimeSyncData ?? 5000);
        this._timerSyncData.Elapsed += _timerSyncData_Elapsed;
        this._timerSyncData.Start();
      }

      FrmSettingServer.Instance.OnSendEnableSyncData += Instance_OnSendEnableSyncData;
    }

    private void Instance_OnSendEnableSyncData(AppConfig appConfig)
    {
      _isSyncDataLocal = appConfig.IsAutoSyncData;
      if (appConfig.IsAutoSyncData)
      {
        InitSyncDataServer();
      }
      else
      {
        this._timerSyncData.Stop();
      }
    }

    private async void _timerSyncData_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        if (_timerSyncData == null)
          return;

        this._timerSyncData.Stop();
        if (IsPingServer)
        {
          //await SyncGroupMaterialSOS();
          await SyncDataFromServer();
          await SyncRecordFromLocal();
          ////await DebugData();
          ////await CheckSyncDataMaterialGroup();

          filterPV++;
          if (filterPV >= filterSV)
          {
            await CheckSyncData();
            filterPV = 0;
          }
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
      finally
      {
        if (_timerSyncData != null)
        {
          _timerSyncData.Start();
        }
      }
    }

    private async Task<bool> SyncRecordFromLocal()
    {
      try
      {
        await SyncDatalogs();

        await SyncDatalogsDelivery();

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task SyncGroupMaterialSOS()
    {
      try
      {
        bool rs = false;
        List<MaterialEntity> servers = await GetMaterialEntitys(isContainDelete: false);
        List<Material> locals = await AppCore.Ins.GetMaterialsAsync(isContainDelete: false);
        var materialGroups = await GetMaterialGroupsAsync();

        List<Material> updates = new List<Material>();

        foreach (var local in locals)
        {
          var rsS = servers.Where(x => x.Id == local.IdSrc).FirstOrDefault();
          if (rsS != null)
          {
            var group01 = rsS.MaterialGroupId;
            if (group01 != null)
            {
              var g = materialGroups?.Where(x => x.IdSrc == group01).FirstOrDefault();
              if (g != null)
              {
                local.MaterialGroupId = g.Id;
                updates.Add(local);
              }
            }
          }
        }

        if (updates.Count > 0)
        {
          await AppCore.Ins.UpdateMaterials(updates);
        }
      }
      catch (Exception)
      {

      }
    }

    private async Task DebugData()
    {
      try
      {
        int cntTotal = 0;
        int current = 0;
        var record = await GetLaborDatalogEntitiesAsync();
        var delivery = await GetAllTicketEntitiesAsync_Fixbug();

        cntTotal = record?.Count() ?? 0;

        if (record?.Count() > 0)
        {
          //All data local
          var dataSync = await GetAllDataLTPNotIncludeSynchronized_Fixbug();

          Guid guid = Guid.Parse("21782b55-4e7b-415d-a1dc-c4f037ae87e7");
          foreach (var entity in record)
          {
            if (entity.Id == guid)
            {

            }
            var rs = dataSync?.Where(x => x.Id == entity.IdSrc && x.CreatedAt == entity.CreatedAt).FirstOrDefault();
            if (rs != null)
            {
              //if (rs.IdSrc == 1180)
              //{

              //}  
              var de = delivery?.Where(x => x.IdSrc == rs?.DatalogDelivery?.Id && x.CreatedAt == rs.DatalogDelivery.CreatedAt).FirstOrDefault();
              if (de != null)
              {
                current++;

                entity.WeightTicketId = de.Id;

                await UpdateLaborDatalogEntitiesAsync(entity);
              }

            }

            Debug.WriteLine($"{current}/{cntTotal}");
          }
        }
      }
      catch (Exception)
      {

      }
    }

    private async Task CheckSyncData()
    {
      try
      {
        int cntTotal = 0;
        int current = 0;
        var record = await GetLaborDatalogEntitiesAsync(_machineCurrent?.IdSrc);
        var delivery = await GetAllTicketEntitiesAsync_Fixbug(_machineCurrent?.IdSrc);

        cntTotal = record?.Count() ?? 0;

        if (record?.Count() > 0)
        {
          //All data local
          var dataSync = await GetAllDataLTPNotIncludeSynchronized_Fixbug();
          foreach (var entity in record)
          {
            var rs = dataSync?.Where(x => x.Id == entity.IdSrc && x.CreatedAt == entity.CreatedAt).FirstOrDefault();
            if (rs != null)
            {
              var de = delivery?.Where(x => x.IdSrc == rs?.DatalogDelivery?.Id && x.CreatedAt == rs.DatalogDelivery.CreatedAt).FirstOrDefault();
              if (de != null)
              {
                current++;
                entity.WeightTicketId = de.Id;
                await UpdateLaborDatalogEntitiesAsync(entity);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async Task CheckSyncDataMaterialGroup()
    {
      try
      {
        List<Material> mrUpdates = new List<Material>();

        List<MaterialEntity> servers = await GetMaterialEntitys(isContainDelete: false);
        List<Material> locals = await AppCore.Ins.GetMaterialsAsync(isContainDelete: false);
        var materialGroups = await GetMaterialGroupsAsync();

        int numberTotal = locals.Count();
        int numberUpdate = 0;
        foreach (var local in locals)
        {
          if (local.MaterialGroupId==null)
          {
            var mrServer = servers?.FirstOrDefault(x => x.Id == local.IdSrc);
            if (mrServer != null && mrServer.MaterialGroupId != null)
            {
              var group = materialGroups?.FirstOrDefault(x => x.IdSrc == mrServer.MaterialGroupId);
              if (group != null)
              {
                local.MaterialGroupId = group.Id;
                mrUpdates.Add(local);
                numberUpdate++;
              }
            }
          }  
          

          Debug.WriteLine($"{numberUpdate}/{numberTotal}");
        }

        if (mrUpdates?.Count()>0)
        {
          foreach (var item in mrUpdates)
          {
            await AppCore.Ins.UpdateMaterial(item);
          }
        }

        Debug.WriteLine($"Done {numberUpdate}/{numberTotal}");
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async Task SyncDatalogs()
    {
      try
      {
        var dataSync = await GetAllDataLTPNotSynchronized();

        //New
        if (dataSync?.Count > 0)
        {
          foreach (var entity in dataSync)
          {
            LaborProductivityRecognitionEntity recognitionEntity = new LaborProductivityRecognitionEntity();
            recognitionEntity.Net = entity.Net;
            recognitionEntity.Tare = entity.Tare;
            recognitionEntity.CreatedAt = entity.CreatedAt;
            recognitionEntity.UpdatedAt = entity.UpdatedAt;
            recognitionEntity.DeletedFlag = entity.DeletedFlag;
            recognitionEntity.IdSrc = entity.Id;
            recognitionEntity.eTypeProduct = entity?.eTypeRecord;
            recognitionEntity.DeletedFlag = entity?.DeletedFlag;
            recognitionEntity.WasteFlag = entity?.eTypeRecord == eTypeRecord.Defective;
            recognitionEntity.CheckData = entity?.EnumCheckData ?? EnumCheckData.UnCheck;
            recognitionEntity.ImportExportStatus = (int)(entity?.eExportImport ?? 0);
            recognitionEntity.InternalExternalStatus = entity?.InternalExternalStatus;

            //Employee
            var employee = await GetEmployeeEntityByIdSrcAsync(entity?.Employee?.IdSrc);
            if (employee != null)
            {
              recognitionEntity.UserId = employee.Id;
            }

            //Production Order
            if (entity?.ProductionOrder != null)
            {
              var productionOrder = await GetProductionOrderEntityByIdSrcAsync(entity?.ProductionOrder?.IdSrc);
              if (productionOrder != null)
              {
                recognitionEntity.ProductionOrderId = productionOrder.Id;
              }
            }

            //Material
            if (entity?.Material != null)
            {
              var material = await GetMaterialEntityByIdSrcAsync(entity?.Material?.IdSrc);
              if (material != null)
              {
                recognitionEntity.MaterialId = material.Id;
                recognitionEntity.eTypeMaterial = (EnumMaterialType)((int)(material?.MaterialType ?? 0));
              }
            }

            //Material Defect
            if (entity?.MaterialDefect != null)
            {
              var materialDefect = await GetMaterialEntityByIdSrcAsync(entity?.MaterialDefect?.IdSrc);
              if (materialDefect != null)
              {
                recognitionEntity.MaterialLossId = materialDefect.Id;
                recognitionEntity.eTypeMaterial = (EnumMaterialType)((int)(materialDefect?.MaterialType ?? 0));
              }
            }

            //Material Tare
            if (entity?.MaterialTareId != null && entity?.MaterialTareId > 0)
            {
              var materialTare = await AppCore.Ins.GetMaterialsByIdAsync(entity?.MaterialTareId);
              if (materialTare != null)
              {
                recognitionEntity.MaterialTareId = materialTare.IdSrc;
              }
            }

            //User Allow Weight Over Id
            if (entity?.UserAllowWeightOverId != null && entity?.UserAllowWeightOverId > 0)
            {
              var employeeAllow = await AppCore.Ins.GetEmployeeByIdAsync(entity?.UserAllowWeightOverId);
              if (employeeAllow != null)
              {
                recognitionEntity.UserAllowWeightOverId = employeeAllow.IdSrc;
              }
            }

            //DeliveryScheduleId
            if (entity?.DeliveryScheduleId != null && entity?.DeliveryScheduleId > 0)
            {
              var deliverySchedule = await AppCore.Ins.GetDeliveryScheduleByIdAsync(entity?.DeliveryScheduleId);
              if (deliverySchedule != null)
              {
                recognitionEntity.DeliveryScheduleId = deliverySchedule.IdSrc;
              }
            }

            ////Production
            //if (entity?.Production != null)
            //{
            //  var product = await GetProductionEntityByIdSrcAsync(entity?.Production?.IdSrc);
            //  if (product != null)
            //  {
            //    recognitionEntity.ProductId = product.Id;
            //    recognitionEntity.eTypeMaterial = eMaterialType.FinshGoods;
            //  }
            //}

            //Machine
            var machine = await GetMachineEntityByIdSrcAsync(entity?.Machine?.IdSrc);
            if (machine != null)
            {
              recognitionEntity.DataMachineId = machine.Id;
            }

            //Tare
            var tare = await GetTareCategoryEntityByIdSrcAsync(entity?.TareCategory?.IdSrc);
            if (tare != null)
            {
              recognitionEntity.TareCategoryId = tare?.Id;
            }
            await AddOrUpdateLaborDatalogEntitiesAsync(recognitionEntity);

            SendRabbit(recognitionEntity, (DateTime)(recognitionEntity?.CreatedAt ?? DateTime.Now));
          }

          //Update Sync success
          dataSync.ForEach(x => x.SyncFlag = true);
          dataSync.ForEach(x => x.UpdatedAt = DateTime.Now);
          await UpdateRecordSyncSuccess(dataSync);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void SendRabbit(LaborProductivityRecognitionEntity record, DateTime dt)
    {
      try
      {
        if (record == null) return;

        WeightLoggingMessage weightLoggingMessage = new WeightLoggingMessage();
        weightLoggingMessage.LaborProductivityRecognitionId = record?.Id;
        weightLoggingMessage.DataMachineId = record?.DataMachineId;
        weightLoggingMessage.WeightValue = record?.Net;
        weightLoggingMessage.IdCardCode = "N/A";
        weightLoggingMessage.ExecuteAt = dt.ToUniversalTime();
        string json = JsonHelper.ToJson(weightLoggingMessage);
        if (!string.IsNullOrEmpty(json) && AppCore.Ins._enableRabbit == true)
        {
          RabbitMQImpService.Instance().Send(json, EnumTypeMessage.DatalogChange);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task SyncDatalogsDelivery()
    {
      try
      {
        var data = await GetAllDataDeliveryNotSynchronized();
        var datasNew = data?.Where(x => x.UpdatedAt == null).ToList();
        var datasUpdate = data?.Where(x => x.UpdatedAt != null).ToList();

        //New
        if (datasNew?.Count > 0)
        {
          foreach (var entity in datasNew)
          {
            WeightTicketEntities weightTicket = new WeightTicketEntities();
            weightTicket.Name = string.Empty;
            weightTicket.TypeWeight = (EnumWeightTicketType)entity.AreaInternalOrExternal;
            weightTicket.CreatedAt = entity.CreatedAt;
            weightTicket.UpdatedAt = entity.UpdatedAt;
            weightTicket.DeletedFlag = entity.DeletedFlag;
            weightTicket.IsAccept = false;
            weightTicket.Reason = string.Empty;
            weightTicket.IdSrc = entity.Id;

            //Production Order
            var productionOrder = await GetProductionOrderEntityByIdSrcAsync(entity.ProductionOrder?.IdSrc);
            if (productionOrder != null)
            {
              weightTicket.ProductionOrderId = productionOrder.Id;
            }

            //Employee
            var employeeDelivery = await GetEmployeeEntityByIdSrcAsync(entity?.EmployeeDeliver?.IdSrc);
            if (employeeDelivery != null)
            {
              weightTicket.UserDeliverId = employeeDelivery.Id;
            }

            var employeeReceive = await GetEmployeeEntityByIdSrcAsync(entity?.EmployeeReceive?.IdSrc);
            if (employeeReceive != null)
            {
              weightTicket.UserReceiveId = employeeReceive.Id;
            }

            var employeeQC = await GetEmployeeEntityByIdSrcAsync(entity?.EmployeeQC?.IdSrc);
            if (employeeQC != null)
            {
              weightTicket.UserQCId = employeeQC.Id;
            }

            //Machine
            var machine = await GetMachineEntityByIdSrcAsync(entity?.Machine?.IdSrc);
            if (machine != null)
            {
              weightTicket.DataMachineId = machine.Id;
            }

            //DeliverySchedule
            var deliverySchedule = await GetDeliveryScheduleEntityByIdSrcAsync(entity?.DeliverySchedule?.IdSrc);
            if (deliverySchedule != null)
            {
              weightTicket.DeliveryScheduleId = deliverySchedule.Id;
            }

            //Thêm mới
            WeightTicketEntities rs = await AddWeightTicketEntitiesAsync(weightTicket);

            if (rs != null)
            {
              //Datalogs
              if (entity?.DatalogWeights?.Count > 0)
              {
                foreach (var item in entity.DatalogWeights)
                {
                  var datalog = await GetDatalogEntitynByIdSrc(item.Id, item?.Machine?.IdSrc, (DateTime)item.CreatedAt);
                  if (datalog != null)
                  {
                    datalog.WeightTicketId = rs.Id;

                    //User Allow Weight Over Id
                    if (item?.UserAllowWeightOverId != null && item?.UserAllowWeightOverId > 0)
                    {
                      var employeeAllow = await AppCore.Ins.GetEmployeeByIdAsync(item?.UserAllowWeightOverId);
                      if (employeeAllow != null)
                      {
                        datalog.UserAllowWeightOverId = employeeAllow.IdSrc;
                      }
                    }

                    //DeliveryScheduleId
                    if (item?.DeliveryScheduleId != null && item?.DeliveryScheduleId > 0)
                    {
                      var schedule = await AppCore.Ins.GetDeliveryScheduleByIdAsync(item?.DeliveryScheduleId);
                      if (schedule != null)
                      {
                        datalog.DeliveryScheduleId = schedule.IdSrc;
                      }
                    }
                    datalog.UpdatedAt = DateTime.Now;
                    await UpdateDatalogEntity(datalog);

                    SendRabbit(datalog, (DateTime)(datalog?.UpdatedAt ?? DateTime.Now));
                  }
                }
              }
            }

            //Post API gửi PDF
            try
            {
              string fileName = $"Sumary{((DateTime)(rs?.CreatedAt)).ToString("yyyyMMddHHmmss")}";
              string pathFile = Application.StartupPath + $"Template\\OutputFiles\\{fileName}.pdf";
              if (File.Exists(pathFile))
              {
                var rsPost = await AppCore.Ins.UploadWeightTicketPdf(rs.ProductionOrderId, rs.Id, pathFile);
              }
            }
            catch (Exception ex)
            {
            }
          }

          //Update Sync success
          datasNew.ForEach(x => x.SyncFlag = true);
          await UpdateRangeDatalogDeliverySyncSuccess(datasNew);
        }

        //Update
        if (datasUpdate?.Count > 0)
        {
          foreach (var item in datasUpdate)
          {
            WeightTicketEntities? rsUpdate = await GetWeightTicketEntityById(item.Id, item.Machine?.IdSrc, (DateTime)item.CreatedAt);
            if (rsUpdate != null)
            {
              //Employee
              var employeeDelivery = await GetEmployeeEntityByIdSrcAsync(item?.EmployeeDeliver?.IdSrc);
              if (employeeDelivery != null)
              {
                rsUpdate.UserDeliverId = employeeDelivery.Id;
              }

              var employeeReceive = await GetEmployeeEntityByIdSrcAsync(item?.EmployeeReceive?.IdSrc);
              if (employeeReceive != null)
              {
                rsUpdate.UserReceiveId = employeeReceive.Id;
              }

              var employeeQC = await GetEmployeeEntityByIdSrcAsync(item?.EmployeeQC?.IdSrc);
              if (employeeQC != null)
              {
                rsUpdate.UserQCId = employeeQC.Id;
              }

              var deliverySchedule = await GetDeliveryScheduleEntityByIdSrcAsync(item?.DeliverySchedule?.IdSrc);
              if (deliverySchedule != null)
              {
                rsUpdate.DeliveryScheduleId = deliverySchedule.Id;
              }

              rsUpdate.DeletedFlag = item?.DeletedFlag;
              await UpdateWeightTicketEntity(rsUpdate);
            }
          }

          //Update Sync success
          datasUpdate.ForEach(x => x.SyncFlag = true);
          await UpdateRangeDatalogDeliverySyncSuccess(datasUpdate);
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private async Task SyncDataFromServer()
    {
      try
      {
        //Thông tin trạm cân
        if (await SyncFactory())
        {
          //await ReloadFactories();
          FrmMain.Instance.CallEvent(eTypeDataRefresh.Factory);
        }

        if (await SyncMachine())
        {
          await ReloadMachines();
          FrmMain.Instance.CallEvent(eTypeDataRefresh.Machine);
        }

        //if (await SyncTare())
        //{
        //  //await ReloadCategoryTares();
        //  FrmMain.Instance.CallEvent(eTypeDataRefresh.SettingTare);
        //}

        if (await SyncMaterialGroup())
        {
          await ReloadMaterialGroups();
        }

        //Thông tin sản xuất
        if (await SyncMaterial())
        {
          await ReloadMaterials();
          FrmMain.Instance.CallEvent(eTypeDataRefresh.Material);
        }

        //if (await SyncProduction())
        //{
        //  await ReloadProductions();
        //  FrmMain.Instance.CallEvent(eTypeDataRefresh.Production);
        //  FrmMain.Instance.CallEvent(eTypeDataRefresh.ProductionOrder);
        //}

        if (await SyncProductionOrder())
        {
          await ReloadProductionOrders();
          FrmMain.Instance.CallEvent(eTypeDataRefresh.ProductionOrder);
        }

        await SyncProductionWeight();
        //if (await SyncProductionWeight())
        //{
        //  await ReloadProductionWeights();
        //  FrmMain.Instance.CallEvent(eTypeDataRefresh.ProductionWeight);
        //  FrmMain.Instance.CallEvent(eTypeDataRefresh.ProductionOrder);
        //}




        //Phòng ban vs User
        //if (await SyncDepartment())
        //{
        //  await ReloadDepartments();
        //  FrmMain.Instance.CallEvent(eTypeDataRefresh.Department);
        //}

        //if (await SyncEmployee())
        //{
        //  await ReloadEmployees();
        //  FrmMain.Instance.CallEvent(eTypeDataRefresh.Employee);
        //}

        //Kế hoạch giao nhận
        if (await SyncDeliverySchedule())
        {
          await ReloadDeliverySchedule();
        }

        if (await SyncDeliveryScheduleMaterial())
        {
          await ReloadDeliveryScheduleMateriale();
        }
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private async Task<bool> SyncMachine()
    {
      try
      {
        bool rs = false;
        List<MachineEntity> servers = await GetMachineEntities(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<Machine> locals = await AppCore.Ins.GetMachinesAsync(isContainDelete: false);
          List<Factory> factoryLocals = await AppCore.Ins.GetFactoriesAsync(isContainDelete: true);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);
          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();


          if (needAdd?.Count() > 0)
          {
            List<Machine> machines = new List<Machine>();
            foreach (var item in needAdd)
            {
              Factory? factory = factoryLocals?.FirstOrDefault(x => x.IdSrc == item.DataFactoryId);
              Machine machine = new Machine();
              machine.Name = item.Name;
              machine.Code = item.Code;
              machine.Description = item.Description;
              machine.WeightDeviation = item.WeightDeviation;
              machine.FactoryId = factory?.Id;
              machine.CreatedAt = item.CreatedAt;
              machine.UpdatedAt = item.UpdatedAt;
              machine.DeletedFlag = item?.DeletedFlag ?? true;
              machine.IdSrc = item?.Id ?? Guid.NewGuid();
              machines.Add(machine);
            }
            if (machines?.Count() > 0)
              await AddRangeMachinesAsync(machines);
            rs = true;
          }

          if (needUpdate?.Count() > 0)
          {
            List<Machine> machines = new List<Machine>();
            foreach (var item in needUpdate)
            {
              var rdUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
              if (rdUpdate != null)
              {
                Factory? factory = factoryLocals?.FirstOrDefault(x => x.IdSrc == item.DataFactoryId);
                rdUpdate.Name = item.Name;
                rdUpdate.Code = item.Code;
                rdUpdate.Description = item.Description;
                rdUpdate.WeightDeviation = item.WeightDeviation;
                rdUpdate.FactoryId = factory?.Id;
                rdUpdate.UpdatedAt = item.UpdatedAt;
                rdUpdate.DeletedFlag = item?.DeletedFlag ?? true;
                machines.Add(rdUpdate);
              }
            }
            if (machines?.Count() > 0)
              await UpdateRangeMachineAsync(machines);
            rs = true;
          }

          if (needDelete?.Count() > 0)
          {
            List<Machine> machines = new List<Machine>();
            foreach (var item in needDelete)
            {
              var rdRemove = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (rdRemove != null)
              {
                rdRemove.DeletedFlag = true;
                rdRemove.UpdatedAt = DateTime.Now;
                machines.Add(rdRemove);
              }
            }
            if (machines?.Count() > 0)
              await UpdateRangeMachineAsync(machines);
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task<bool> SyncFactory()
    {
      try
      {
        bool rs = false;
        List<FactoryEntity> servers = await GetFactoryEntitys(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<Factory> locals = await AppCore.Ins.GetFactoriesAsync(isContainDelete: false);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);

          // ADD (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // DELETE (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // UPDATE (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          if (needAdd?.Count() > 0)
          {
            List<Factory> factoriesAdd = new List<Factory>();
            foreach (var item in needAdd)
            {
              Factory factory = new Factory();
              factory.Name = item.Name;
              factory.Code = item.Code;
              factory.Description = item.Description;
              factory.CreatedAt = item.CreatedAt;
              factory.UpdatedAt = item.UpdatedAt;
              factory.DeletedFlag = item?.DeletedFlag ?? true;
              factory.IdSrc = item?.Id ?? Guid.Empty;
              factoriesAdd.Add(factory);
            }
            await AddRangeFactoryiesAsync(factoriesAdd);
            rs = true;
          }

          if (needUpdate?.Count() > 0)
          {
            List<Factory> factoriesUpdate = new List<Factory>();
            foreach (var item in needUpdate)
            {
              var rdUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
              if (rdUpdate != null)
              {
                rdUpdate.Name = item.Name;
                rdUpdate.Code = item.Code;
                rdUpdate.Description = item.Description;
                rdUpdate.DeletedFlag = item?.DeletedFlag ?? true;
                rdUpdate.UpdatedAt = item?.UpdatedAt;
                factoriesUpdate.Add(rdUpdate);
              }
            }
            await UpdateRangeFactoryAsync(factoriesUpdate);
            rs = true;
          }

          if (needDelete?.Count() > 0)
          {
            List<Factory> factoriesRemove = new List<Factory>();
            foreach (var item in needDelete)
            {
              var rdRemove = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (rdRemove != null)
              {
                rdRemove.DeletedFlag = true;
                rdRemove.UpdatedAt = DateTime.Now;
                factoriesRemove.Add(rdRemove);
              }
            }
            await UpdateRangeFactoryAsync(factoriesRemove);
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task<bool> SyncMaterial()
    {
      try
      {
        bool rs = false;
        List<MaterialEntity> servers = await GetMaterialEntitys(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<Material> locals = await AppCore.Ins.GetMaterialsAsync(isContainDelete: false);
          List<CategoryTare> tareLocals = await AppCore.Ins.GetAllCategoryTareAsync(isContainDelete: false);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          if (needAdd?.Count() > 0)
          {
            List<Material> materials = new List<Material>();
            foreach (var item in needAdd)
            {
              Material material = new Material();
              try
              {
                material.Group = item.Group;
                material.Code = item.SerialCode;
                material.Name = item.Name;
                material.Note = item.Note;
                material.Grade = item.Specs;
                material.Supplier = item.Supplier;
                material.TareFlag = item.TareFlag;
                material.ValueTare = item.ValueTare;

                material.PathImage = item.PathImage;
                material.MaterialType = item.MaterialType;
                material.Description = item.Description;
                material.WeightConversion = item.WeightConversion;
                material.Unit = item.DVT;
                material.LOT = item.LOT;
                material.TargetUnit = item.TargetUnit;
                material.StockTaking = item.StockTaking;
                material.ExpiredDate = item.ExpiredDate;

                material.CreatedAt = item.CreatedAt;
                material.UpdatedAt = item.UpdatedAt;
                material.DeletedFlag = item?.DeletedFlag ?? true;
                material.IdSrc = item?.Id ?? Guid.Empty;

                //Tare
                if (item?.TareCategories?.Count > 0)
                {
                  foreach (var mr in item.TareCategories)
                  {
                    var tare = tareLocals.FirstOrDefault(x => x.IdSrc == mr.Id);
                    if (tare != null)
                    {
                      material.CategoryTares.Add(tare);
                    }
                  }
                }

                //Group
                var group = _materialGroups?.FirstOrDefault(x => x.IdSrc == item?.MaterialGroupId);
                if (group!=null)
                {
                  material.MaterialGroupId = group.Id;
                }  
              }
              catch (Exception)
              {

              }
              finally
              {
                materials.Add(material);
              }
            }
            if (materials?.Count() > 0)
              await AddRangeMaterialsAsync(materials);
            rs = true;
          }

          if (needUpdate?.Count() > 0)
          {
            foreach (var item in needUpdate)
            {
              List<CategoryTare> categoryTares = new List<CategoryTare>();
              var rdUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
              try
              {
                if (rdUpdate != null)
                {
                  rdUpdate.Group = item.Group;
                  rdUpdate.Code = item.SerialCode;
                  rdUpdate.Name = item.Name;
                  rdUpdate.Note = item.Note;
                  rdUpdate.Grade = item.Specs;
                  rdUpdate.Supplier = item.Supplier;
                  rdUpdate.TareFlag = item.TareFlag;
                  rdUpdate.ValueTare = item.ValueTare;

                  rdUpdate.PathImage = item.PathImage;
                  rdUpdate.MaterialType = item.MaterialType;
                  rdUpdate.Description = item.Description;
                  rdUpdate.WeightConversion = item.WeightConversion;
                  rdUpdate.Unit = item.DVT;
                  rdUpdate.LOT = item.LOT;
                  rdUpdate.TargetUnit = item.TargetUnit;
                  rdUpdate.StockTaking = item.StockTaking;
                  rdUpdate.ExpiredDate = item.ExpiredDate;

                  rdUpdate.UpdatedAt = item.UpdatedAt;
                  rdUpdate.DeletedFlag = item?.DeletedFlag ?? true;

                  //Tare
                  if (item?.TareCategories?.Count > 0)
                  {
                    foreach (var mr in item.TareCategories)
                    {
                      var material = tareLocals.FirstOrDefault(x => x.IdSrc == mr.Id);
                      if (material != null)
                      {
                        categoryTares.Add(material);
                      }
                    }
                  }

                  //Group
                  var group = _materialGroups?.FirstOrDefault(x => x.IdSrc == item?.MaterialGroupId);
                  if (group != null)
                  {
                    rdUpdate.MaterialGroupId = group.Id;
                  }
                }
              }
              catch (Exception)
              {

              }
              finally
              {
                if (rdUpdate != null)
                  await UpdateRangeMaterialsAsync(rdUpdate, categoryTares);
              }
            }
            rs = true;
          }

          if (needDelete?.Count() > 0)
          {
            List<Material> materialsRemove = new List<Material>();
            foreach (var item in needDelete)
            {
              var rdUpdate = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (rdUpdate != null)
              {
                rdUpdate.DeletedFlag = true;
                rdUpdate.UpdatedAt = DateTime.Now;
                materialsRemove.Add(rdUpdate);
              }
            }
            if (materialsRemove?.Count() > 0)
            {
              await UpdateRangeMaterialsAsync(materialsRemove);
            }
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task<bool> SyncProduction()
    {
      try
      {
        bool rs = false;
        List<ProductEntity> servers = await GetProductionEntitys(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<Production> locals = await GetProductionAsync(isContainDelete: false);
          List<Material> materiaLocals = await AppCore.Ins.GetMaterialsAsync(isContainDelete: true);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          //New
          if (needAdd?.Count() > 0)
          {
            List<Production> productions = new List<Production>();
            foreach (var item in needAdd)
            {
              Production production = new Production();
              production.Name = item.Name;
              production.Code = item.Code;
              production.Description = item.Description;
              production.CreatedAt = item.CreatedAt;
              production.UpdatedAt = item.UpdatedAt;
              production.DeletedFlag = item?.DeletedFlag ?? true;
              production.IdSrc = item?.Id ?? Guid.Empty;

              //Material
              if (item?.Materials?.Count() > 0)
              {
                foreach (var materialEntity in item.Materials)
                {
                  var rawMaterial = materiaLocals.FirstOrDefault(x => x.IdSrc == materialEntity.Id);
                  if (rawMaterial != null)
                  {
                    production.Materials.Add(rawMaterial);
                  }
                }
              }
              productions.Add(production);
            }

            if (productions?.Count() > 0)
              await AddRangeProductionsAsync(productions);
            rs = true;
          }

          //Update
          if (needUpdate?.Count() > 0)
          {
            List<Production> productions = new List<Production>();
            foreach (var item in needUpdate)
            {
              Production? productionUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
              if (productionUpdate != null)
              {
                productionUpdate.Name = item.Name;
                productionUpdate.Code = item.Code;
                productionUpdate.Description = item.Description;
                productionUpdate.CreatedAt = item.CreatedAt;
                productionUpdate.DeletedFlag = item?.DeletedFlag ?? true;
                productionUpdate.UpdatedAt = item?.UpdatedAt;
                productionUpdate.IdSrc = item?.Id ?? Guid.Empty;

                //Material
                List<Material> materials = new List<Material>();
                if (item?.Materials?.Count > 0)
                {
                  foreach (var materialEntity in item.Materials)
                  {
                    var material = materiaLocals.FirstOrDefault(x => x.IdSrc == materialEntity.Id);
                    if (material != null)
                    {
                      materials.Add(material);
                    }
                  }
                }

                if (productionUpdate != null)
                  await UpdateProductionAsync(productionUpdate, materials);
              }
            }
            rs = true;
          }

          //Remove
          if (needDelete?.Count() > 0)
          {
            List<Production> productionsRemove = new List<Production>();
            foreach (var item in needDelete)
            {
              Production? production = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (production != null)
              {
                production.Materials.Clear();
                production.DeletedFlag = true;
                production.UpdatedAt = DateTime.Now;
                productionsRemove.Add(production);
              }
            }

            if (productionsRemove?.Count() > 0)
              await UpdateRangeProductionsAsync(productionsRemove);
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task<bool> SyncProductionWeight()
    {
      try
      {
        bool rs = false;
        List<MaterialSettingEntity> servers = await GetProductionWeightEntitys(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<MaterialSetting> locals = await GetMaterialSettingsAsync(isContainDelete: false);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          if (needAdd?.Count() > 0 || needUpdate?.Count() > 0)
          {
            List<Material> materialLocals = await AppCore.Ins.GetMaterialsAsync(isContainDelete: true);
            List<ProductionOrder> productionOrderLocals = await GetProductionOrdersAsync(isContainDelete: true);

            //New
            if (needAdd?.Count() > 0)
            {
              List<MaterialSetting> productionWeights = new List<MaterialSetting>();
              foreach (var item in needAdd)
              {
                //var dataProduct = await GetProductionByIdSrcAsync(item.ProductId);
                var dataMaterial = materialLocals?.FirstOrDefault(x => x.IdSrc == item.MaterialId);
                var dataPO = productionOrderLocals?.FirstOrDefault(x => x.IdSrc == item.ProductionOrderId);
                //if (dataMaterial == null || dataPO == null)
                //{
                //  continue;
                //}

                MaterialSetting productionWeight = new MaterialSetting();
                if (dataMaterial != null)
                  productionWeight.MaterialId = dataMaterial.Id;
                if (dataPO != null)
                  productionWeight.ProductionOrderId = dataPO.Id;

                productionWeight.Setting = item.Weight;
                productionWeight.Loss = item.Loss;
                productionWeight.InternalExternalStatus = (item.InternalExternalStatus != null) ?
                                                             item.InternalExternalStatus :
                                                             EnumInternalExternalStatus.Internal;
                if (item.ImportExportStatus != null)
                {
                  productionWeight.ImportExportStatus = (item.ImportExportStatus == EnumExportImport.Import) ?
                                                    EnumExportImport.Import :
                                                    EnumExportImport.Export;
                }
                else
                {
                  productionWeight.ImportExportStatus = EnumExportImport.ImportExport;
                }

                productionWeight.CreatedAt = item.CreatedAt;
                productionWeight.UpdatedAt = item.UpdatedAt;
                productionWeight.DeletedFlag = item?.DeletedFlag ?? true;
                productionWeight.IdSrc = item?.Id ?? Guid.Empty;

                productionWeights.Add(productionWeight);
              }

              if (productionWeights?.Count() > 0)
                await AddRangeProductionWeightsAsync(productionWeights);
              rs = true;
            }

            //Update
            if (needUpdate?.Count() > 0)
            {
              List<MaterialSetting> productions = new List<MaterialSetting>();
              foreach (var item in needUpdate)
              {
                MaterialSetting? rsUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
                if (rsUpdate != null)
                {
                  var dataMaterial = await GetMaterialsByIdSrcAsync(item.MaterialId);
                  var dataPO = await GetProductionOrdersByIdSrcAsync(item.ProductionOrderId);

                  if (dataMaterial != null)
                    rsUpdate.MaterialId = dataMaterial?.Id;
                  if (dataPO != null)
                    rsUpdate.ProductionOrderId = dataPO?.Id;

                  rsUpdate.Setting = item.Weight;

                  if (item.ImportExportStatus != null)
                  {
                    rsUpdate.ImportExportStatus = (item.ImportExportStatus == EnumExportImport.Import) ?
                                                      EnumExportImport.Import :
                                                      EnumExportImport.Export;
                  }
                  else
                  {
                    rsUpdate.ImportExportStatus = EnumExportImport.ImportExport;
                  }
                  rsUpdate.CreatedAt = item.CreatedAt;
                  rsUpdate.DeletedFlag = item?.DeletedFlag ?? true;
                  rsUpdate.UpdatedAt = item?.UpdatedAt;
                  rsUpdate.IdSrc = item?.Id ?? Guid.Empty;

                  if (rsUpdate != null)
                    await UpdateMaterialSetting(rsUpdate);
                }
              }
              rs = true;
            }

          }

          //Delete
          if (needDelete?.Count() > 0)
          {
            List<MaterialSetting> materialSettings = new List<MaterialSetting>();
            foreach (var item in needDelete)
            {
              MaterialSetting? rsRemove = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (rsRemove != null)
              {
                rsRemove.DeletedFlag = true;
                rsRemove.UpdatedAt = DateTime.Now;
                materialSettings.Add(rsRemove);
              }
            }

            if (materialSettings?.Count() > 0)
              await UpdateRangeMaterialSetting(materialSettings);

            rs = true;
          }
        }
        return rs;
      }
      catch (Exception ex)
      {
        throw;
      }
    }



    private async Task<bool> SyncProductionOrder()
    {
      try
      {
        bool rs = false;
        List<ProductionOrderEntity> servers = await GetProductionOrderEntitys(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<ProductionOrder> locals = await GetProductionOrdersAsync(isContainDelete: false);

          var serverDict = servers.ToDictionary(x => x.Id);
          //var localDict = locals.ToDictionary(x => x.IdSrc);
          var localDict = locals
                          .GroupBy(x => x.IdSrc)
                          .ToDictionary(g => g.Key, g => g.Last());

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          //New
          if ((needAdd?.Count() > 0) || (needUpdate?.Count() > 0))
          {
            List<Production> productionsLocal = await GetProductionAsync(isContainDelete: true);
            List<Material> materiaLocal = await GetMaterialsAsync(isContainDelete: true);
            List<MaterialSetting> materiaSettingLocal = await GetMaterialSettingsAsync(isContainDelete: true);

            if (needAdd?.Count() > 0)
            {
              List<ProductionOrder> productionOrders = new List<ProductionOrder>();
              foreach (var item in needAdd)
              {
                ProductionOrder po = new ProductionOrder();
                po.Name = item.Name;
                po.ProductionOrderType = item?.ProductionOrderType ?? EnumProductionOrderType.LenhSanXuat;
                po.ProductionOrderCategory = item?.ProductionOrderCategory ?? EnumProductionOrderCategory.None;

                if (item?.IsProcessing == null)
                {
                  po.EnumProcessing = EnumProcessing.None;
                }
                else
                {
                  if (item?.IsProcessing == false)
                  {
                    po.EnumProcessing = EnumProcessing.Unprocessed;
                  }
                  else if (item?.IsProcessing == true)
                  {
                    po.EnumProcessing = EnumProcessing.Processing;
                  }
                }

                po.EffectiveFrom = item?.EffectiveFrom;
                po.EffectiveTo = item?.EffectiveTo;
                po.EffectiveFromExternal = item?.EffectiveFromExternal;
                po.EffectiveToExternal = item?.EffectiveToExternal;
                po.ApproveStatus = item?.ApproveStatus;
                po.WarningStatus = item?.WarningStatus;

                po.CreatedAt = item?.CreatedAt;
                po.UpdatedAt = item?.UpdatedAt;
                po.DeletedFlag = item?.DeletedFlag ?? true;
                po.IdSrc = item?.Id ?? Guid.Empty;

                //Materials
                if (item?.Materials?.Count > 0)
                {
                  foreach (var mr in item.Materials)
                  {
                    var material = materiaLocal.FirstOrDefault(x => x.IdSrc == mr.Id);
                    if (material != null)
                    {
                      po.Materials.Add(material);
                    }
                  }
                }

                //Product
                if (item?.Productions?.Count > 0)
                {
                  foreach (var pr in item.Productions)
                  {
                    var product = productionsLocal.FirstOrDefault(x => x.IdSrc == pr.Id);
                    if (product != null)
                    {
                      po.Productions.Add(product);
                    }
                  }
                }

                productionOrders.Add(po);
              }

              if (productionOrders?.Count() > 0)
                await AddRangeProductionOrdersAsync(productionOrders);
              rs = true;
            }

            //Update
            if (needUpdate?.Count() > 0)
            {
              List<ProductionOrder> productionOrdersUpdate = new List<ProductionOrder>();
              foreach (var item in needUpdate)
              {
                ProductionOrder? poUpdate = await GetProductionOrdersByIdSrcAsync(item.Id);
                if (poUpdate != null)
                {
                  poUpdate.Name = item.Name;
                  poUpdate.ProductionOrderType = item?.ProductionOrderType ?? EnumProductionOrderType.LenhSanXuat;
                  poUpdate.ProductionOrderCategory = item?.ProductionOrderCategory ?? EnumProductionOrderCategory.None;
                  if (item?.IsProcessing == null)
                  {
                    poUpdate.EnumProcessing = EnumProcessing.None;
                  }
                  else
                  {
                    if (item?.IsProcessing == false)
                    {
                      poUpdate.EnumProcessing = EnumProcessing.Unprocessed;
                    }
                    else if (item?.IsProcessing == true)
                    {
                      poUpdate.EnumProcessing = EnumProcessing.Processing;
                    }
                  }
                  poUpdate.ApproveStatus = item?.ApproveStatus;
                  poUpdate.WarningStatus = item?.WarningStatus;
                  poUpdate.EffectiveFrom = item?.EffectiveFrom;
                  poUpdate.EffectiveTo = item?.EffectiveTo;
                  poUpdate.EffectiveFromExternal = item?.EffectiveFromExternal;
                  poUpdate.EffectiveToExternal = item?.EffectiveToExternal;
                  poUpdate.CreatedAt = item?.CreatedAt;
                  poUpdate.DeletedFlag = item?.DeletedFlag ?? true;
                  poUpdate.UpdatedAt = item?.UpdatedAt;
                  poUpdate.IdSrc = item?.Id ?? Guid.Empty;

                  ////Materials
                  List<Material> materials = new List<Material>();
                  if (item?.Materials?.Count > 0)
                  {
                    foreach (var mr in item.Materials)
                    {
                      var material = materiaLocal.FirstOrDefault(x => x.IdSrc == mr.Id);
                      if (material != null)
                      {
                        materials.Add(material);
                      }
                    }
                  }

                  ////Product
                  List<Production> productions = new List<Production>();
                  if (item?.Productions?.Count > 0)
                  {
                    foreach (var pr in item.Productions)
                    {
                      var product = productionsLocal.FirstOrDefault(x => x.IdSrc == pr.Id);
                      if (product != null)
                      {
                        productions.Add(product);
                      }
                    }
                  }

                  if (poUpdate != null)
                    await UpdateProductionOrdersAsync(poUpdate, materials, productions);
                }
              }
              rs = true;
            }

          }

          //Remove
          if (needDelete?.Count() > 0)
          {
            List<ProductionOrder> productionOrdersRemove = new List<ProductionOrder>();
            foreach (var item in needDelete)
            {
              ProductionOrder? poRemove = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (poRemove != null)
              {
                poRemove.Materials.Clear();
                poRemove.Productions.Clear();
                poRemove.DeletedFlag = true;
                poRemove.UpdatedAt = DateTime.Now;

                productionOrdersRemove.Add(poRemove);
              }
            }

            if (productionOrdersRemove?.Count() > 0)
            {
              await UpdateProductionOrdersAsync(productionOrdersRemove);
              rs = true;
            }
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task<bool> SyncDepartment()
    {
      try
      {
        bool rs = false;
        List<UserGroupEntity> servers = await GetDepartmentEntitys(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<Department> locals = await AppCore.Ins.GetDepartmentsAsync(isContainDelete: false);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          //New
          if (needAdd?.Count() > 0)
          {
            List<Department> departments = new List<Department>();
            foreach (var item in needAdd)
            {
              Department department = new Department();
              department.Name = item.Name;
              department.Description = item.Description;
              department.EnumGroup = item.Group;
              department.CreatedAt = item.CreatedAt;
              department.UpdatedAt = item.UpdatedAt;
              department.IdSrc = item.Id;
              department.DeletedFlag = item?.DeletedFlag ?? true;

              departments.Add(department);
            }
            if (departments?.Count() > 0)
              await AddRangeDepartmentAsync(departments);
            rs = true;
          }

          //Update
          if (needUpdate?.Count() > 0)
          {
            List<Department> departmentUpdate = new List<Department>();
            foreach (var item in needUpdate)
            {
              var rdUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
              if (rdUpdate != null)
              {
                rdUpdate.Name = item.Name;
                rdUpdate.Description = item.Description;
                rdUpdate.EnumGroup = item.Group;
                rdUpdate.UpdatedAt = item.UpdatedAt;
                rdUpdate.DeletedFlag = item?.DeletedFlag ?? true;

                departmentUpdate.Add(rdUpdate);
              }
            }

            if (departmentUpdate?.Count() > 0)
              await UpdateRangeDepartmentAsync(departmentUpdate);
            rs = true;
          }

          //Remove
          if (needDelete?.Count() > 0)
          {
            List<Department> departmentRemove = new List<Department>();
            foreach (var item in needDelete)
            {
              var rdRemove = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (rdRemove != null)
              {
                rdRemove.UpdatedAt = DateTime.Now;
                rdRemove.DeletedFlag = true;
                departmentRemove.Add(rdRemove);
              }
            }

            if (departmentRemove?.Count() > 0)
              await UpdateRangeDepartmentAsync(departmentRemove);
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task<bool> SyncEmployee()
    {
      try
      {
        bool rs = false;
        List<UserEntity> servers = await GetEmployeeEntitys(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<Employee> locals = await AppCore.Ins.GetAllEmployeeAsync(isContainDelete: false);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();


          if ((needAdd?.Count() > 0) || (needUpdate?.Count() > 0))
          {
            List<Department> departmentLocal = await AppCore.Ins.GetDepartmentsAsync(isContainDelete: true);
            if (needAdd?.Count() > 0)
            {

              List<Employee> employees = new List<Employee>();
              foreach (var item in needAdd)
              {
                Employee employee = new Employee();
                employee.FullName = item.FullName;
                employee.Code = item.EmployeeCode;
                employee.IdCardCode = item.IdCardCode;
                employee.IsAllowOverWeight = item.IsAllowOverWeight;
                employee.CreatedAt = item.CreatedAt;
                employee.UpdatedAt = item.UpdatedAt;
                employee.DeletedFlag = item?.DeletedFlag ?? false;
                employee.IdSrc = item?.Id ?? Guid.Empty;

                //Department
                if (item?.UserGroups?.Count() > 0)
                {
                  foreach (var mr in item.UserGroups)
                  {
                    var department = departmentLocal.FirstOrDefault(x => x.IdSrc == mr.Id && x.DeletedFlag == false);
                    if (department != null)
                    {
                      employee?.Departments?.Add(department);
                    }
                  }
                }

                employees.Add(employee);
              }

              if (employees?.Count() > 0)
              {
                await AddRangeEmployeesAsync(employees);
                rs = true;
              }
            }

            if (needUpdate?.Count() > 0)
            {
              foreach (var item in needUpdate)
              {
                var rdUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
                if (rdUpdate != null)
                {
                  rdUpdate.FullName = item.FullName;
                  rdUpdate.Code = item.EmployeeCode;
                  rdUpdate.IdCardCode = item.IdCardCode;
                  rdUpdate.IsAllowOverWeight = item.IsAllowOverWeight;
                  rdUpdate.UpdatedAt = item.UpdatedAt;
                  rdUpdate.DeletedFlag = item?.DeletedFlag ?? true;

                  List<Department> departments = new List<Department>();
                  if (item?.UserGroups?.Count > 0)
                  {
                    foreach (var mr in item.UserGroups)
                    {
                      var department = departmentLocal.FirstOrDefault(x => x.IdSrc == mr.Id && x.DeletedFlag == false);
                      if (department != null)
                      {
                        departments.Add(department);
                      }
                    }
                  }
                  await UpdateRangeEmployeeAsync(rdUpdate, departments);
                  rs = true;
                }
              }
            }
          }  
          

          if (needDelete?.Count() > 0)
          {
            List<Employee> employees = new List<Employee>();
            foreach (var item in needDelete)
            {
              var rdUpdate = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (rdUpdate != null)
              {
                rdUpdate.Departments.Clear();
                rdUpdate.DeletedFlag = true;
                rdUpdate.UpdatedAt = DateTime.Now;
                employees.Add(rdUpdate);
              }
            }

            if (employees?.Count() > 0)
            {
              await UpdateRangeEmployeeAsync(employees);
              rs = true;
            }
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }


    private async Task<bool> SyncTare()
    {
      try
      {
        bool rs = false;
        List<TareCategoryEntity> servers = await GetTareCategoryEntities(isContainDelete: false);
        if (servers?.Count > 0)
        {
          List<CategoryTare> locals = await AppCore.Ins.GetAllCategoryTareAsync(isContainDelete: false);

          var serverDict = servers.ToDictionary(x => x.Id);
          var localDict = locals.ToDictionary(x => x.IdSrc);

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = locals
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          //Save DB
          if (needAdd?.Count() > 0)
          {
            List<CategoryTare> categoryTares = new List<CategoryTare>();
            foreach (var item in needAdd)
            {
              CategoryTare categoryTare = new CategoryTare();
              categoryTare.Code = item.TareCode;
              categoryTare.Name = item.Name;
              categoryTare.Value = item.Weight;
              categoryTare.Description = item.Description;
              categoryTare.TareGroup = item.TareGroup;
              categoryTare.CreatedAt = item.CreatedAt;
              categoryTare.UpdatedAt = item.UpdatedAt;
              categoryTare.DeletedFlag = item?.DeletedFlag ?? false;
              categoryTare.IdSrc = item?.Id ?? Guid.Empty;
              categoryTares.Add(categoryTare);
            }

            if (categoryTares?.Count() > 0)
              await AddRangeCategoryTaresAsync(categoryTares);
            rs = true;
          }

          if (needUpdate?.Count() > 0)
          {
            List<CategoryTare> categoryTaresUpdate = new List<CategoryTare>();
            foreach (var item in needUpdate)
            {
              var categoryTareUpdate = locals?.FirstOrDefault(x => x.IdSrc == item.Id);
              if (categoryTareUpdate != null)
              {
                categoryTareUpdate.Code = item.TareCode;
                categoryTareUpdate.Name = item.Name;
                categoryTareUpdate.Description = item.Description;
                categoryTareUpdate.Value = item.Weight;
                categoryTareUpdate.TareGroup = item.TareGroup;
                categoryTareUpdate.UpdatedAt = item.UpdatedAt;
                categoryTareUpdate.DeletedFlag = item?.DeletedFlag ?? true;
                categoryTaresUpdate.Add(categoryTareUpdate);
              }
            }

            if (categoryTaresUpdate?.Count() > 0)
              await UpdateRangeCategoryTareAsync(categoryTaresUpdate);
            rs = true;
          }

          if (needDelete?.Count() > 0)
          {
            List<CategoryTare> categoryTaresRemove = new List<CategoryTare>();
            foreach (var item in needDelete)
            {
              var categoryTareRemove = locals?.FirstOrDefault(x => x.Id == item.Id);
              if (categoryTareRemove != null)
              {
                categoryTareRemove.DeletedFlag = true;
                categoryTareRemove.UpdatedAt = DateTime.Now;
                categoryTaresRemove.Add(categoryTareRemove);
              }
            }
            if (categoryTaresRemove?.Count() > 0)
              await UpdateRangeCategoryTareAsync(categoryTaresRemove);
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

    private async Task<bool> SyncMaterialGroup()
    {
      var servers = await GetMaterialGroupEntities(isContainDelete: false)
                    ?? new List<MaterialGroupEntity>();

      var locals = _materialGroups?
          .Where(x => x != null)
          .ToList()
          ?? new List<MaterialGroup>();

      bool hasChanges = false;

      var serverDict = servers.ToDictionary(x => x.Id);

      // IdSrc là Guid? nên phải kiểm tra HasValue
      var localDict = locals
          .Where(x =>
              x.IdSrc.HasValue &&
              x.IdSrc.Value != Guid.Empty)
          .ToDictionary(
              x => x.IdSrc!.Value,
              x => x);

      // Server có nhưng local chưa có
      var needAdd = servers
          .Where(server => !localDict.ContainsKey(server.Id))
          .ToList();

      // Server và local cùng có nhưng UpdatedAt khác nhau
      var needUpdate = servers
          .Where(server =>
              localDict.TryGetValue(server.Id, out var local) &&
              local.UpdatedAt != server.UpdatedAt)
          .ToList();

      // Local có nhưng server không còn
      var needDelete = locals
          .Where(local =>
              local.IdSrc.HasValue &&
              local.IdSrc.Value != Guid.Empty &&
              !serverDict.ContainsKey(local.IdSrc.Value) &&
              local.DeletedFlag != true)
          .ToList();

      /*
       * Bước 1: Thêm mới.
       *
       * Chưa gán MaterialGroupParentId tại bước này vì parent có thể
       * cũng là bản ghi mới và chưa được sinh local Id.
       */
      if (needAdd.Count > 0)
      {
        var materialGroupsToAdd = new List<MaterialGroup>();

        foreach (var server in needAdd)
        {
          var materialGroup = new MaterialGroup
          {
            Name = server.Name,
            MaterialType = server.MaterialType,
            TypeName = server.TypeName,
            // Tạm thời xem là node gốc
            MaterialGroupParentId = null,

            CreatedAt = server.CreatedAt,
            UpdatedAt = server.UpdatedAt,
            DeletedFlag = server.DeletedFlag ?? false,
            IdSrc = server.Id
          };

          materialGroupsToAdd.Add(materialGroup);
        }

        await AddRangeMaterialGroupAsync(materialGroupsToAdd);

        /*
         * Sau AddRange/SaveChanges, EF sẽ gán local Id
         * vào các object vừa thêm.
         */
        foreach (var materialGroup in materialGroupsToAdd)
        {
          locals.Add(materialGroup);

          if (materialGroup.IdSrc.HasValue &&
              materialGroup.IdSrc.Value != Guid.Empty)
          {
            localDict[materialGroup.IdSrc.Value] = materialGroup;
          }
        }

        hasChanges = true;
      }

      // Bước 2: Cập nhật thông tin cơ bản
      if (needUpdate.Count > 0)
      {
        var materialGroupsToUpdate = new List<MaterialGroup>();

        foreach (var server in needUpdate)
        {
          if (!localDict.TryGetValue(server.Id, out var local))
            continue;

          local.Name = server.Name;
          local.MaterialType = server.MaterialType;
          local.TypeName = server.TypeName;
          local.UpdatedAt = server.UpdatedAt;
          local.DeletedFlag = server.DeletedFlag ?? false;

          materialGroupsToUpdate.Add(local);
        }

        if (materialGroupsToUpdate.Count > 0)
        {
          await UpdateRangeMaterialGroupAsync(materialGroupsToUpdate);
          hasChanges = true;
        }
      }

      // Bước 3: Soft delete các bản ghi local không còn trên server
      if (needDelete.Count > 0)
      {
        foreach (var local in needDelete)
        {
          local.DeletedFlag = true;
          local.UpdatedAt = DateTime.UtcNow;
        }

        await UpdateRangeMaterialGroupAsync(needDelete);
        hasChanges = true;
      }

      /*
       * Bước 4: Cập nhật parent.
       *
       * Server:
       *     MaterialGroupParentId = Guid của parent.
       *
       * Local:
       *     MaterialGroupParentId = Id kiểu long của parent.
       *
       * Guid.Empty được xem là không có parent và lưu local bằng 0.
       */
      var materialGroupsParentUpdate = new List<MaterialGroup>();

      foreach (var server in servers)
      {
        // Tìm chính material group local
        if (!localDict.TryGetValue(server.Id, out var local))
          continue;

        long parentLocalId = 0;

        // Nếu server có parent, tìm parent local theo IdSrc
        if (server.MaterialGroupParentId is Guid parentId &&
            parentId != Guid.Empty &&
            localDict.TryGetValue(parentId, out var localParent))
        {
          parentLocalId = localParent.Id;
        }

        // Chỉ cập nhật khi parent thay đổi
        if (local.MaterialGroupParentId != parentLocalId)
        {
          local.MaterialGroupParentId = parentLocalId;
          materialGroupsParentUpdate.Add(local);
        }
      }

      if (materialGroupsParentUpdate.Count > 0)
      {
        await UpdateRangeMaterialGroupAsync(
            materialGroupsParentUpdate);

        hasChanges = true;
      }

      return hasChanges;
    }

    //private async Task<bool> SyncMaterialGroup()
    //{
    //  try
    //  {
    //    bool rs = false;
    //    List<MaterialGroupEntity> servers = await GetMaterialGroupEntities(isContainDelete: false);
    //    if (servers?.Count > 0)
    //    {
    //      var serverDict = servers.ToDictionary(x => x.Id);
    //      var localDict = _materialGroups?.ToDictionary(x => x.IdSrc);

    //      // New (S có, L không có)
    //      var needAdd = servers
    //          .Where(s => !localDict.ContainsKey(s.Id))
    //          .ToList();

    //      // Remove (L có, S không có)
    //      var needDelete = _materialGroups
    //          .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
    //          .ToList();

    //      // Update (có cả 2 nhưng khác UpdatedAt)
    //      var needUpdate = servers
    //          .Where(s => localDict.ContainsKey(s.Id)
    //                   && localDict[s.Id].UpdatedAt != s.UpdatedAt)
    //          .ToList();

    //      //Save DB
    //      if (needAdd?.Count() > 0)
    //      {
    //        List<MaterialGroup> materialGroups = new List<MaterialGroup>();
    //        foreach (var item in needAdd)
    //        {
    //          MaterialGroup materialGroup = new MaterialGroup();
    //          materialGroup.Name = item.Name;
    //          materialGroup.MaterialType = item.MaterialType;
    //          materialGroup.CreatedAt = item.CreatedAt;
    //          materialGroup.UpdatedAt = item.UpdatedAt;
    //          materialGroup.DeletedFlag = item?.DeletedFlag ?? false;
    //          materialGroup.IdSrc = item?.Id ?? Guid.Empty;
    //          materialGroups.Add(materialGroup);
    //        }

    //        if (materialGroups?.Count() > 0)
    //          await AddRangeMaterialGroupAsync(materialGroups);
    //        rs = true;
    //      }

    //      if (needUpdate?.Count() > 0)
    //      {
    //        List<MaterialGroup> materialGroupsUpdate = new List<MaterialGroup>();
    //        foreach (var item in needUpdate)
    //        {
    //          var materialGroupUpdate = _materialGroups?.FirstOrDefault(x => x.IdSrc == item.Id);
    //          if (materialGroupUpdate != null)
    //          {
    //            materialGroupUpdate.Name = item.Name;
    //            materialGroupUpdate.MaterialType = item.MaterialType;
    //            materialGroupUpdate.UpdatedAt = item.UpdatedAt;
    //            materialGroupUpdate.DeletedFlag = item?.DeletedFlag ?? true;
    //            materialGroupsUpdate.Add(materialGroupUpdate);
    //          }
    //        }

    //        if (materialGroupsUpdate?.Count() > 0)
    //          await UpdateRangeMaterialGroupAsync(materialGroupsUpdate);
    //        rs = true;
    //      }

    //      if (needDelete?.Count() > 0)
    //      {
    //        List<MaterialGroup> materialGroupsRemove = new List<MaterialGroup>();
    //        foreach (var item in needDelete)
    //        {
    //          var categoryTareRemove = _materialGroups?.FirstOrDefault(x => x.Id == item.Id);
    //          if (categoryTareRemove != null)
    //          {
    //            categoryTareRemove.DeletedFlag = true;
    //            categoryTareRemove.UpdatedAt = DateTime.Now;
    //            materialGroupsRemove.Add(categoryTareRemove);
    //          }
    //        }
    //        if (materialGroupsRemove?.Count() > 0)
    //          await UpdateRangeMaterialGroupAsync(materialGroupsRemove);
    //        rs = true;
    //      }
    //    }
    //    return rs;
    //  }
    //  catch (Exception)
    //  {
    //    throw;
    //  }
    //}



    private async Task LoadDataFirst()
    {
      _deliverySchedulesRealtime = await AppCore.Ins.GetDeliveryScheduleAsync(isContainDelete: false);
      _deliveryScheduleMaterialsRealtime = await AppCore.Ins.GetDeliveryScheduleMaterialAsync(isContainDelete: false);
    }


    private async Task<bool> SyncDeliverySchedule()
    {
      try
      {
        bool rs = false;
        List<DeliveryScheduleEntity> servers = await GetDeliveryScheduleEntity(isContainDelete: false);
        if (servers?.Count > 0)
        {
          //var serverDict = servers.ToDictionary(x => x.Id);
          //var localDict = _deliverySchedulesRealtime.ToDictionary(x => x.IdSrc);

          var serverDict = servers
                          .GroupBy(x => x.Id)
                          .ToDictionary(
                              group => group.Key,
                              group => group.First()
                          );

          var localDict = _deliverySchedulesRealtime
                          .GroupBy(x => x.IdSrc)
                          .ToDictionary(
                              group => group.Key,
                              group => group.First()
                          );

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = _deliverySchedulesRealtime
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          //New
          if (needAdd?.Count() > 0)
          {
            List<DeliverySchedule> deliverySchedules = new List<DeliverySchedule>();
            foreach (var item in needAdd)
            {
              DeliverySchedule deliverySchedule = new DeliverySchedule();
              deliverySchedule.ImportExport = item.eTypeDeliverySchedule;
              deliverySchedule.TicketCode = item.TicketCode;
              deliverySchedule.DeliveryTimeRawMaterial = item.DeliveryTimeRawMaterial;
              deliverySchedule.DeliveryTimeMaterial = item.DeliveryTimeMaterial;
              deliverySchedule.DeliveryTimeSemiFinished = item.DeliveryTimeSemiFinished;
              deliverySchedule.DeliveryTimeYield = item.DeliveryTimeYield;

              if (item.ProductionOrderId != null)
              {
                var po = _productionOrders?.FirstOrDefault(x => x.IdSrc == item.ProductionOrderId);
                if (po != null)
                {
                  deliverySchedule.ProductionOrderId = po.Id;
                }
              }

              deliverySchedule.CreatedAt = item.CreatedAt;
              deliverySchedule.UpdatedAt = item.UpdatedAt;
              deliverySchedule.IdSrc = item.Id;
              deliverySchedule.DeletedFlag = item?.DeletedFlag ?? true;

              deliverySchedules.Add(deliverySchedule);
            }
            if (deliverySchedules?.Count() > 0)
              await AddRangeDeliveryScheduleAsync(deliverySchedules);
            rs = true;
          }

          //Update
          if (needUpdate?.Count() > 0)
          {
            List<DeliverySchedule> deliverySchedules = new List<DeliverySchedule>();
            foreach (var item in needUpdate)
            {
              var rdUpdate = _deliverySchedulesRealtime?.FirstOrDefault(x => x.IdSrc == item.Id);
              if (rdUpdate != null)
              {
                rdUpdate.ImportExport = item.eTypeDeliverySchedule;
                rdUpdate.TicketCode = item.TicketCode;
                rdUpdate.DeliveryTimeRawMaterial = item.DeliveryTimeRawMaterial;
                rdUpdate.DeliveryTimeMaterial = item.DeliveryTimeMaterial;
                rdUpdate.DeliveryTimeSemiFinished = item.DeliveryTimeSemiFinished;
                rdUpdate.DeliveryTimeYield = item.DeliveryTimeYield;

                if (item.ProductionOrderId != null)
                {
                  var po = _productionOrders?.FirstOrDefault(x => x.IdSrc == item.ProductionOrderId);
                  if (po != null)
                  {
                    rdUpdate.ProductionOrderId = po.Id;
                  }
                }
                rdUpdate.UpdatedAt = item.UpdatedAt;
                rdUpdate.DeletedFlag = item?.DeletedFlag ?? true;

                deliverySchedules.Add(rdUpdate);
              }
            }

            if (deliverySchedules?.Count() > 0)
              await UpdateRangeDeliveryScheduleAsync(deliverySchedules);
            rs = true;
          }

          //Remove
          if (needDelete?.Count() > 0)
          {
            List<DeliverySchedule> departmentsRemove = new List<DeliverySchedule>();
            foreach (var item in needDelete)
            {
              var rdRemove = _deliverySchedulesRealtime?.FirstOrDefault(x => x.Id == item.Id);
              if (rdRemove != null)
              {
                rdRemove.UpdatedAt = DateTime.Now;
                rdRemove.DeletedFlag = true;
                departmentsRemove.Add(rdRemove);
              }
            }

            if (departmentsRemove?.Count() > 0)
              await UpdateRangeDeliveryScheduleAsync(departmentsRemove);
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private async Task<bool> SyncDeliveryScheduleMaterial()
    {
      try
      {
        bool rs = false;
        List<DeliveryScheduleMaterialEntity> servers = await GetDeliveryScheduleMaterialEntity(isContainDelete: false);
        if (servers?.Count > 0)
        {
          //var serverDict = servers.ToDictionary(x => x.Id);
          //var localDict = _deliveryScheduleMaterialsRealtime.ToDictionary(x => x.IdSrc);

          var serverDict = servers
                            .GroupBy(x => x.Id)
                            .ToDictionary(
                                group => group.Key,
                                group => group.Last()
                            );

          var localDict = _deliveryScheduleMaterialsRealtime
                          .GroupBy(x => x.IdSrc)
                          .ToDictionary(
                              group => group.Key,
                              group => group.Last()
                          );

          // New (S có, L không có)
          var needAdd = servers
              .Where(s => !localDict.ContainsKey(s.Id))
              .ToList();

          // Remove (L có, S không có)
          var needDelete = _deliveryScheduleMaterialsRealtime
              .Where(l => !serverDict.ContainsKey(l?.IdSrc ?? Guid.Empty))
              .ToList();

          // Update (có cả 2 nhưng khác UpdatedAt)
          var needUpdate = servers
              .Where(s => localDict.ContainsKey(s.Id)
                       && localDict[s.Id].UpdatedAt != s.UpdatedAt)
              .ToList();

          //New
          if (needAdd?.Count() > 0)
          {
            List<DeliveryScheduleMaterial> deliveryScheduleMaterials = new List<DeliveryScheduleMaterial>();
            foreach (var item in needAdd)
            {
              DeliveryScheduleMaterial deliveryScheduleMaterial = new DeliveryScheduleMaterial();
              deliveryScheduleMaterial.Weight = item.Weight;
              deliveryScheduleMaterial.Quantity = item.Quantity;

              if (item.DeliveryScheduleId != null)
              {
                var deliverySchedule = _deliverySchedulesRealtime?.FirstOrDefault(x => x.IdSrc == item.DeliveryScheduleId);
                if (deliverySchedule != null)
                {
                  deliveryScheduleMaterial.DeliveryScheduleId = deliverySchedule.Id;
                }
              }

              if (item.MaterialId != null)
              {
                var material = _materials?.FirstOrDefault(x => x.IdSrc == item.MaterialId);
                if (material != null)
                {
                  deliveryScheduleMaterial.MaterialId = material.Id;
                }
              }

              deliveryScheduleMaterial.CreatedAt = item.CreatedAt;
              deliveryScheduleMaterial.UpdatedAt = item.UpdatedAt;
              deliveryScheduleMaterial.IdSrc = item.Id;
              deliveryScheduleMaterial.DeletedFlag = item?.DeletedFlag ?? true;

              deliveryScheduleMaterials.Add(deliveryScheduleMaterial);
            }
            if (deliveryScheduleMaterials?.Count() > 0)
              await AddRangeDeliveryScheduleMaterialAsync(deliveryScheduleMaterials);
            rs = true;
          }

          //Update
          if (needUpdate?.Count() > 0)
          {
            List<DeliveryScheduleMaterial> deliveryScheduleMaterials = new List<DeliveryScheduleMaterial>();
            foreach (var item in needUpdate)
            {
              var rdUpdate = _deliveryScheduleMaterialsRealtime?.FirstOrDefault(x => x.IdSrc == item.Id);
              if (rdUpdate != null)
              {
                rdUpdate.Weight = item.Weight;
                rdUpdate.Quantity = item.Quantity;

                if (item.DeliveryScheduleId != null)
                {
                  var deliverySchedule = _deliverySchedulesRealtime?.FirstOrDefault(x => x.IdSrc == item.DeliveryScheduleId);
                  if (deliverySchedule != null)
                  {
                    rdUpdate.DeliveryScheduleId = deliverySchedule.Id;
                  }
                }

                if (item.MaterialId != null)
                {
                  var material = _materials?.FirstOrDefault(x => x.IdSrc == item.MaterialId);
                  if (material != null)
                  {
                    rdUpdate.MaterialId = material.Id;
                  }
                }

                rdUpdate.UpdatedAt = item.UpdatedAt;
                rdUpdate.DeletedFlag = item?.DeletedFlag ?? true;

                deliveryScheduleMaterials.Add(rdUpdate);
              }
            }

            if (deliveryScheduleMaterials?.Count() > 0)
              await UpdateRangeDeliveryScheduleMaterialAsync(deliveryScheduleMaterials);
            rs = true;
          }

          //Remove
          if (needDelete?.Count() > 0)
          {
            List<DeliveryScheduleMaterial> deliveryScheduleMaterials = new List<DeliveryScheduleMaterial>();
            foreach (var item in needDelete)
            {
              var rdRemove = _deliveryScheduleMaterialsRealtime?.FirstOrDefault(x => x.Id == item.Id);
              if (rdRemove != null)
              {
                rdRemove.UpdatedAt = DateTime.Now;
                rdRemove.DeletedFlag = true;
                deliveryScheduleMaterials.Add(rdRemove);
              }
            }

            if (deliveryScheduleMaterials?.Count() > 0)
              await UpdateRangeDeliveryScheduleMaterialAsync(deliveryScheduleMaterials);
            rs = true;
          }
        }
        return rs;
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
