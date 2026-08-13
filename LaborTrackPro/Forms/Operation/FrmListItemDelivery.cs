using DocumentFormat.OpenXml.Bibliography;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Printer;
using LaborTrackPro.UserControls;
using Org.BouncyCastle.Math.Field;
using System.Drawing.Drawing2D;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;
using static LaborTrackPro.Helper.DTO;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmListItemDelivery : Form
  {
    public FrmListItemDelivery()
    {
      InitializeComponent();
      CustomUI();
      InitScrollButton();
      this.dgv.CellClick += dgvMaterial_CellClick;
    }

    #region Instance
    private static FrmListItemDelivery _Instance = null;
    public static FrmListItemDelivery Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmListItemDelivery();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      this.ucTitleFrm.FunctionButton(eTypeButton.ReviewDelivery);
      this.ucTitleFrm.Title = "Thông tin biên bản giao nhận";
      this.ucTitleFrm.Image = Properties.Resources.icon_delivery_note;
      this.ucTitleFrm.OnSendReviewUCClick += UcTitleFrm_OnSendReviewUCClick;

      this.dgv.RowTemplate.Height = 60;
      this.dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgv.DefaultCellStyle.SelectionBackColor = Color.White;
      this.dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

      this.dgv02.RowTemplate.Height = 60;
      this.dgv02.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgv02.DefaultCellStyle.SelectionBackColor = Color.White;
      this.dgv02.DefaultCellStyle.SelectionForeColor = Color.Black;

      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = tableLayoutPanel3;
      elipseControl1.CornerRadius = 20;

      ElipseControl elipseControl2 = new ElipseControl();
      elipseControl2.TargetControl = tableLayoutPanel4;
      elipseControl2.CornerRadius = 20;
    }

    private async void UcTitleFrm_OnSendReviewUCClick()
    {
      if (AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs?.Count <= 0)
      {
        FrmConfirm frmConfirm = new FrmConfirm("Không có thông tin dữ liệu cân được chọn !", eImage.Confirm, false);
        frmConfirm.ShowDialog();
        return;
      }

      await FrmPageOperation.Instance.ChangePage(AppModulSupport.ReviewDelivery);

      //else
      //{
      //  bool isSameMaterial = AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs?
      //                        .Select(x => new
      //                        {
      //                          x.DatalogWeight?.MaterialId,
      //                          x.DatalogWeight?.MaterialDefectId
      //                        })
      //                        .Distinct()
      //                        .Count() == 1;

      //  if (isSameMaterial)
      //  {
      //    await FrmPageOperation.Instance.ChangePage(AppModulSupport.ReviewDelivery);
      //  }
      //  else
      //  {
      //    FrmConfirm frmConfirm = new FrmConfirm("Biên bản giao nhận chỉ cho phép một \r\nnguyên liệu - vật tư !", eImage.Confirm, false);
      //    frmConfirm.ShowDialog();
      //  }
      //}
    }

    public async void ShowListData()
    {
      await LoadListMaterial();
    }

    private async Task LoadListMaterial()
    {
      if (AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceivingFirst == null)
      {
        new FrmInformation().ShowMessage("Không tìm thấy thông tin bên nhận !", eImage.Warning);
        return;
      }
      EnumInternalExternalStatus enumInternalExternalStatus = AppCore.Ins._dataManager.EnumInternalExternalStatus;
      EnumExportImport enumExportImport = AppCore.Ins._dataManager.EnumExportImport;

      if (AppCore.Ins._dataManager.DataLogDelivery.IsDelivery == true)
      {
        var data = AppCore.Ins._dataManager.ProductionOrder;
        List<DeliveryScheduleMaterial> deliveryScheduleMaterials = AppCore.Ins._dataManager.DeliverySchedule?.DeliveryScheduleMaterials ?? new List<DeliveryScheduleMaterial>();

        List<DatalogWeight>? records = new List<DatalogWeight>();
        if (data?.Id > 0)
        {
          DateTime dateTime = DateTime.Now.AddHours(-AppCore.Ins._delivery_permit_hour);
          records = await AppCore.Ins.GetRecordByPOAsync(data.Id, dateTime, enumInternalExternalStatus, enumExportImport);

          //Lọc theo người nhận cân
          if (records?.Count() > 0)
          {
            records = records?.Where(x => x.EmployeeId == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceivingFirst?.Id).ToList();

            //Lọc ra các nguyên liệu trong phiếu giao nhận

            if (deliveryScheduleMaterials?.Count() > 0 && records?.Count() > 0)
            {
              List<DatalogWeight>? recordsAfterFilter = new List<DatalogWeight>();
              foreach (var item in records)
              {
                //Phế
                if (item.MaterialDefectId!=null)
                {
                  bool ok = deliveryScheduleMaterials.Any(x => x.Material?.Code == item.MaterialDefect?.Code);
                  if (ok)
                  {
                    recordsAfterFilter.Add(item);
                  }
                }
                else
                {
                  bool ok = deliveryScheduleMaterials.Any(x => x.Material?.Code == item.Material?.Code);
                  if (ok)
                  {
                    recordsAfterFilter.Add(item);
                  }
                }  
              }

              AppCore.Ins._dataManager.DataLogDelivery.DatalogWeights = recordsAfterFilter;
              AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = DTOHelper.ConvertRecordToDeliveryDTO(recordsAfterFilter);

              ucTitleFrm.SetEnabelBtn(true);
            }
            else
            {
              ucTitleFrm.SetEnabelBtn(false);
              AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = new List<MaterialDeliveryDTO>();
            }
          }
          else
          {
            ucTitleFrm.SetEnabelBtn(false);
            AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = new List<MaterialDeliveryDTO>();
          }
        }
        else
        {
          ucTitleFrm.SetEnabelBtn(false);
          AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = new List<MaterialDeliveryDTO>();
        }

        ShowDatagridview(AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs);
        ShowDatagridview02(new List<DeliverySummaryDTO>());
        VisibleDgvSchedule(true);


        var selectedDTOs = dgv.Rows
                            .Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .Select(row => row.DataBoundItem)
                            .OfType<MaterialDeliveryDTO>()
                            .Where(dto => dto.Check == true)
                            .ToList();

        AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = selectedDTOs;
        AppCore.Ins._dataManager.DataLogDelivery.DatalogWeights = selectedDTOs.Select(dto => dto.DatalogWeight)
                                                                              .OfType<DatalogWeight>()
                                                                              .ToList();
      }
      else
      {
        var data = AppCore.Ins._dataManager.ProductionOrder;
        List<DeliveryScheduleMaterial> deliveryScheduleMaterials = AppCore.Ins._dataManager.DeliverySchedule?.DeliveryScheduleMaterials ?? new List<DeliveryScheduleMaterial>();

        List<DatalogWeight>? records = new List<DatalogWeight>();
        if (data?.Id > 0)
        {
          DateTime dateTime = DateTime.Now.AddHours(-AppCore.Ins._delivery_permit_hour);
          records = await AppCore.Ins.GetRecordByPOAsync(data.Id, dateTime, enumInternalExternalStatus, enumExportImport);

          //Lọc theo người nhận cân
          if (records?.Count() > 0)
          {
            records = records?.Where(x => x.EmployeeId == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceivingFirst?.Id).ToList();
            //Lọc ra các nguyên liệu trong phiếu giao nhận
            if (records?.Count() > 0)
            {
              AppCore.Ins._dataManager.DataLogDelivery.DatalogWeights = records;
              AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = DTOHelper.ConvertRecordToDeliveryDTO(records);

              ucTitleFrm.SetEnabelBtn(true);
            }
            else
            {
              ucTitleFrm.SetEnabelBtn(false);
              AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = new List<MaterialDeliveryDTO>();
            }
          }
          else
          {
            ucTitleFrm.SetEnabelBtn(false);
            AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = new List<MaterialDeliveryDTO>();
          }
        }
        else
        {
          ucTitleFrm.SetEnabelBtn(false);
          AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = new List<MaterialDeliveryDTO>();
        }

        ShowDatagridview(AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs);
        ShowDatagridview02(new List<DeliverySummaryDTO>());
        VisibleDgvSchedule(false);

        var selectedDTOs = dgv.Rows
                            .Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .Select(row => row.DataBoundItem)
                            .OfType<MaterialDeliveryDTO>()
                            .Where(dto => dto.Check == true)
                            .ToList();

        AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = selectedDTOs;
        AppCore.Ins._dataManager.DataLogDelivery.DatalogWeights = selectedDTOs.Select(dto => dto.DatalogWeight)
                                                                              .OfType<DatalogWeight>()
                                                                              .ToList();
      }
    }

    private void ShowDatagridview(List<MaterialDeliveryDTO>? t)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDatagridview(t);
        }));
        return;
      }


      //dgv.DataSource = null;

      if (!dgv.Columns.Contains("colCheck"))
      {
        var checkColumn = new DataGridViewCheckBoxColumn
        {
          Name = "colCheck",
          DataPropertyName = nameof(MaterialDeliveryDTO.Check),
          HeaderText = "Chọn",
          Width = 80,
          MinimumWidth = 50,
          AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
          Resizable = DataGridViewTriState.False,
          ReadOnly = true,
          DefaultCellStyle =
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter
        }
        };

        dgv.Columns.Insert(0, checkColumn);
      }

      if (t?.Count()>0)
      {
        t = t.OrderBy(x => x.CodeMaterial).ToList();
      }  

      dgv.DataSource = t;
      dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

      dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void ShowDatagridview02(List<DeliverySummaryDTO>? t)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDatagridview02(t);
        }));
        return;
      }

      dgv02.DataSource = t;
      dgv02.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

      dgv02.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv02.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      dgv02.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private void VisibleDgvSchedule(bool isVisible)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          VisibleDgvSchedule(isVisible);
        }));
        return;
      }

      tableLayoutPanel4.Visible = isVisible;
    }



    private async void dgvMaterial_CellClick(
    object? sender,
    DataGridViewCellEventArgs e)
    {
      try
      {
        if (e.RowIndex < 0)
          return;

        DataGridViewRow row = dgv.Rows[e.RowIndex];

        if (row.DataBoundItem is not MaterialDeliveryDTO mr)
          return;

        mr.Check = !(mr.Check ?? false);

        ApplyCheckStyle(row, mr.Check == true);

        dgv.ClearSelection();


        //Check data chọn
        var checkedItems = dgv.Rows
                          .Cast<DataGridViewRow>()
                          .Where(row => !row.IsNewRow)
                          .Select(row => row.DataBoundItem as MaterialDeliveryDTO)
                          .Where(item => item?.Check == true)
                          .Cast<MaterialDeliveryDTO>()
                          .ToList();

        if (AppCore.Ins._dataManager.DataLogDelivery.IsDelivery == true)
        {
          List<DeliverySummaryDTO> summaryDTOs = checkedItems
                                                .Where(x => x.MaterialDefect != null || x.Material != null)
                                                .GroupBy(x => new
                                                {
                                                  IsDefect = x.MaterialDefect != null,
                                                  Code = x.CodeMaterial
                                                })
                                                .Select(group =>
                                                {
                                                  MaterialDeliveryDTO first = group.First();

                                                  return new DeliverySummaryDTO
                                                  {
                                                    CodeMaterial = first.CodeMaterial,
                                                    NameMaterial = first.NameMaterial,
                                                    Unit = first.Unit,

                                                    Material = group.Key.IsDefect ? null : first.Material,
                                                    MaterialDefect = group.Key.IsDefect
                                                          ? first.MaterialDefect
                                                          : null,

                                                    Target = 0.0,
                                                    Actual = group.Sum(x => x.QualityValue ?? 0)
                                                  };
                                                })
                                                .ToList();



















          //////Sumary data
          //List<DeliverySummaryDTO> summaryDTOs = checkedItems
          //                                        .Where(x => x.Material != null)
          //                                        .GroupBy(x => x.Material!.Id)
          //                                        .Select(g =>
          //                                        {
          //                                          var first = g.First();

          //                                          return new DeliverySummaryDTO
          //                                          {
          //                                            Material = first.Material,
          //                                            MaterialDefect = first.MaterialDefect,
          //                                            CodeMaterial = first.CodeMaterial,
          //                                            NameMaterial = first.NameMaterial,
          //                                            Unit = first.Unit,
          //                                            Target = 0.0,
          //                                            Actual = g.Sum(x => x.QualityValue ?? 0),
          //                                          };
          //                                        })
          //                                        .ToList();

          if (summaryDTOs?.Count() > 0)
          {
            foreach (var summary in summaryDTOs)
            {
              double actual = 0.0;
              double actualReture = 0.0;
              double deviation = 0.0;
              double deviationReture = 0.0;
              bool checkalarm = false;
              bool mrDefect = false;

              GetMaxDeliverySchedule getMaxDelivery = new GetMaxDeliverySchedule();
              getMaxDelivery.DeliveryScheduleId = AppCore.Ins._dataManager.DeliverySchedule?.IdSrc;

              if (summary?.MaterialDefect != null)
              {
                getMaxDelivery.MaterialId = summary?.MaterialDefect?.IdSrc;
                getMaxDelivery.DataMachineId = AppCore.Ins._machineCurrent?.IdSrc;
                getMaxDelivery.TypeData = AppCore.Ins._dataManager.EnumExportImport;
                var rs = await AppCore.Ins.GetMaxWeightDeliverySchedule(getMaxDelivery);

                if (rs.Status == "Success")
                {
                  EnumTyCheckAlarm enumTyCheckAlarm = EnumTyCheckAlarm.None;
                  if (AppCore.Ins._dataManager?.ProductionOrder?.EnumProcessing == EnumProcessing.Processing)
                  {
                    if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Export;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Export_Internal;
                      }
                    }
                    else if (AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Import)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Import;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Import_Internal;
                      }
                    }
                  }
                  else if (AppCore.Ins._dataManager?.ProductionOrder?.EnumProcessing == EnumProcessing.Unprocessed)
                  {
                    if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Export;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Export_Internal;
                      }
                    }
                    else if (AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Import)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Import;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Import_Internal;
                      }
                    }
                  }
                  //PO có chế biến
                  if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Export)
                  {
                    // Giá trị cân được = Tổng cân dc - Sơ chế 
                    //Phòng nhận hàng
                    var departmentReceiving = AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceivingFirst?.Departments?.FirstOrDefault();
                    var dataExport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Export).ToList();
                    var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();

                    if (dataExport?.Count() > 0)
                    {
                      if (departmentReceiving?.EnumGroup != EnumGroup.SoChe)
                      {
                        foreach (var item in dataExport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                      else
                      {
                        foreach (var item in dataExport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }

                    if (dataImport?.Count() > 0)
                    {
                      //Phòng nhận hàng
                      if (departmentReceiving?.EnumGroup != EnumGroup.SoChe)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actualReture += item.Actual;
                            deviationReture += item.Deviation;
                          }
                        }
                      }
                      else
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actualReture += item.Actual;
                            deviationReture += item.Deviation;
                          }
                        }
                      }
                    }

                    checkalarm = (departmentReceiving?.EnumGroup != EnumGroup.SoChe);
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Export_Internal)
                  {
                    var dataExportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ExportInternal).ToList();
                    var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                    if (dataExportInternal?.Count() > 0)
                    {
                      foreach (var item in dataExportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.IdSrc)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }
                    }
                    if (dataImportInternal?.Count() > 0)
                    {
                      foreach (var item in dataImportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                        {
                          actualReture += item.Actual;
                          deviationReture += item.Deviation;
                        }
                      }
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Import)
                  {
                    if (!mrDefect)
                    {
                      var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      var departmentDelivery = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc);

                      if (departmentDelivery?.EnumGroup != EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                      else if (departmentDelivery?.EnumGroup == EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                    else
                    {
                      var dataImport = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      var departmentDelivery = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc);

                      if (departmentDelivery?.EnumGroup != EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                      else if (departmentDelivery?.EnumGroup == EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }

                      checkalarm = departmentDelivery?.EnumGroup != EnumGroup.SoChe;
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Import_Internal)
                  {
                    if (!mrDefect)
                    {
                      var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                    else
                    {
                      var dataImportInternal = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                  }

                  //PO sơ chế
                  if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Export)
                  {
                    var dataExport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Export).ToList();
                    var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                    if (dataExport?.Count() > 0)
                    {
                      foreach (var item in dataExport)
                      {
                        actual += item.Actual;
                        deviation += item.Deviation;
                      }
                    }

                    if (dataImport?.Count() > 0)
                    {
                      foreach (var item in dataImport)
                      {
                        actualReture += item.Actual;
                        deviationReture += item.Deviation;
                      }
                    }

                    checkalarm = true;
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Export_Internal)
                  {
                    var dataExportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ExportInternal).ToList();
                    var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                    if (dataExportInternal?.Count() > 0)
                    {
                      foreach (var item in dataExportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.IdSrc)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }
                    }
                    if (dataImportInternal?.Count() > 0)
                    {
                      foreach (var item in dataImportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                        {
                          actualReture += item.Actual;
                          deviationReture += item.Deviation;
                        }
                      }
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Import)
                  {
                    if (!mrDefect)
                    {
                      var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      if (dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }
                    }
                    else
                    {
                      var dataImport = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      if (dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }

                      checkalarm = true;
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Import_Internal)
                  {
                    if (!mrDefect)
                    {
                      var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                    else
                    {
                      var dataImportInternal = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                  }
                }
                summary.Target = (rs?.Data?.SettingInKg ?? 0.0) - actual;
              }
              else
              {
                getMaxDelivery.MaterialId = summary?.Material?.IdSrc;
                getMaxDelivery.DataMachineId = AppCore.Ins._machineCurrent?.IdSrc;
                getMaxDelivery.TypeData = AppCore.Ins._dataManager.EnumExportImport;
                var rs = await AppCore.Ins.GetMaxWeightDeliverySchedule(getMaxDelivery);

                if (rs.Status == "Success")
                {
                  EnumTyCheckAlarm enumTyCheckAlarm = EnumTyCheckAlarm.None;
                  if (AppCore.Ins._dataManager?.ProductionOrder?.EnumProcessing == EnumProcessing.Processing)
                  {
                    if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Export;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Export_Internal;
                      }
                    }
                    else if (AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Import)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Import;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_CheBien_Import_Internal;
                      }
                    }
                  }
                  else if (AppCore.Ins._dataManager?.ProductionOrder?.EnumProcessing == EnumProcessing.Unprocessed)
                  {
                    if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Export;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Export_Internal;
                      }
                    }
                    else if (AppCore.Ins._dataManager?.EnumExportImport == EnumExportImport.Import)
                    {
                      if (AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.Departments?.FirstOrDefault()?.EnumGroup == EnumGroup.Warehouse)
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Import;
                      }
                      else
                      {
                        enumTyCheckAlarm = EnumTyCheckAlarm.PO_SoChe_Import_Internal;
                      }
                    }
                  }
                  //PO có chế biến
                  if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Export)
                  {
                    // Giá trị cân được = Tổng cân dc - Sơ chế 
                    //Phòng nhận hàng
                    var departmentReceiving = AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceivingFirst?.Departments?.FirstOrDefault();
                    var dataExport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Export).ToList();
                    var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();

                    if (dataExport?.Count() > 0)
                    {
                      if (departmentReceiving?.EnumGroup != EnumGroup.SoChe)
                      {
                        foreach (var item in dataExport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                      else
                      {
                        foreach (var item in dataExport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }

                    if (dataImport?.Count() > 0)
                    {
                      //Phòng nhận hàng
                      if (departmentReceiving?.EnumGroup != EnumGroup.SoChe)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actualReture += item.Actual;
                            deviationReture += item.Deviation;
                          }
                        }
                      }
                      else
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actualReture += item.Actual;
                            deviationReture += item.Deviation;
                          }
                        }
                      }
                    }

                    checkalarm = (departmentReceiving?.EnumGroup != EnumGroup.SoChe);
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Export_Internal)
                  {
                    var dataExportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ExportInternal).ToList();
                    var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                    if (dataExportInternal?.Count() > 0)
                    {
                      foreach (var item in dataExportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.IdSrc)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }
                    }
                    if (dataImportInternal?.Count() > 0)
                    {
                      foreach (var item in dataImportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                        {
                          actualReture += item.Actual;
                          deviationReture += item.Deviation;
                        }
                      }
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Import)
                  {
                    if (!mrDefect)
                    {
                      var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      var departmentDelivery = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc);

                      if (departmentDelivery?.EnumGroup != EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                      else if (departmentDelivery?.EnumGroup == EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                    else
                    {
                      var dataImport = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      var departmentDelivery = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc);

                      if (departmentDelivery?.EnumGroup != EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup != EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                      else if (departmentDelivery?.EnumGroup == EnumGroup.SoChe && dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.EnumGroup == EnumGroup.SoChe)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }

                      checkalarm = departmentDelivery?.EnumGroup != EnumGroup.SoChe;
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_CheBien_Import_Internal)
                  {
                    if (!mrDefect)
                    {
                      var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                    else
                    {
                      var dataImportInternal = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                  }

                  //PO sơ chế
                  if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Export)
                  {
                    var dataExport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Export).ToList();
                    var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                    if (dataExport?.Count() > 0)
                    {
                      foreach (var item in dataExport)
                      {
                        actual += item.Actual;
                        deviation += item.Deviation;
                      }
                    }

                    if (dataImport?.Count() > 0)
                    {
                      foreach (var item in dataImport)
                      {
                        actualReture += item.Actual;
                        deviationReture += item.Deviation;
                      }
                    }

                    checkalarm = true;
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Export_Internal)
                  {
                    var dataExportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ExportInternal).ToList();
                    var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                    if (dataExportInternal?.Count() > 0)
                    {
                      foreach (var item in dataExportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.ReceiveDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeReceiving?.IdSrc)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }
                    }
                    if (dataImportInternal?.Count() > 0)
                    {
                      foreach (var item in dataImportInternal)
                      {
                        var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                        if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                        {
                          actualReture += item.Actual;
                          deviationReture += item.Deviation;
                        }
                      }
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Import)
                  {
                    if (!mrDefect)
                    {
                      var dataImport = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      if (dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }
                    }
                    else
                    {
                      var dataImport = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.Import).ToList();
                      if (dataImport?.Count() > 0)
                      {
                        foreach (var item in dataImport)
                        {
                          actual += item.Actual;
                          deviation += item.Deviation;
                        }
                      }

                      checkalarm = true;
                    }
                  }
                  else if (enumTyCheckAlarm == EnumTyCheckAlarm.PO_SoChe_Import_Internal)
                  {
                    if (!mrDefect)
                    {
                      var dataImportInternal = rs?.Data?.DataNormalByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                    else
                    {
                      var dataImportInternal = rs?.Data?.DataLossByDepartments?.Where(x => x.EnumTypeData == EnumTypeData.ImportInternal).ToList();
                      if (dataImportInternal?.Count() > 0)
                      {
                        foreach (var item in dataImportInternal)
                        {
                          var department = AppCore.Ins?._departments?.FirstOrDefault(x => x.IdSrc == item.DeliverDepartmentId);
                          if (department?.IdSrc == AppCore.Ins._dataManager?.DataLogDelivery?.EmployeeDelivery?.IdSrc)
                          {
                            actual += item.Actual;
                            deviation += item.Deviation;
                          }
                        }
                      }
                    }
                  }
                }
                summary.Target = (rs?.Data?.SettingInKg ?? 0.0) - actual;
              }
            }
          }


          ShowDatagridview02(summaryDTOs);
        }

        AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs = checkedItems;
        AppCore.Ins._dataManager.DataLogDelivery.DatalogWeights = checkedItems.Select(dto => dto.DatalogWeight)
                                                                              .OfType<DatalogWeight>()
                                                                              .ToList();
      }
      catch (Exception ex)
      {

      }
    }

    public void ApplyCheckedRowsStyle()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ApplyCheckedRowsStyle();
        }));
        return;
      }

      foreach (DataGridViewRow row in dgv.Rows)
      {
        if (row.IsNewRow)
          continue;

        if (row.DataBoundItem is not MaterialDeliveryDTO item)
          continue;

        ApplyCheckStyle(row, item.Check == true);
      }

      dgv.ClearSelection();
    }

    private void ApplyCheckStyle(
    DataGridViewRow row,
    bool isChecked)
    {
      Color backgroundColor = isChecked
          ? Color.FromArgb(232, 245, 233)
          : Color.White;

      Color foregroundColor = isChecked
          ? Color.FromArgb(27, 94, 32)
          : Color.Black;

      row.DefaultCellStyle.BackColor = backgroundColor;
      row.DefaultCellStyle.ForeColor = foregroundColor;

      // Khi người dùng click, màu không bị DataGridView đổi sang xanh dương
      row.DefaultCellStyle.SelectionBackColor = backgroundColor;
      row.DefaultCellStyle.SelectionForeColor = foregroundColor;
    }

    private void dgvMaterial_DataBindingComplete(
    object sender,
    DataGridViewBindingCompleteEventArgs e)
    {
      foreach (DataGridViewRow row in dgv.Rows)
      {
        if (row.DataBoundItem is MaterialDeliveryDTO item)
          ApplyCheckStyle(row, item.Check == true);
      }

      dgv.ClearSelection();
    }


    private void ReLoadListMaterial()
    {
      ShowDatagridview(AppCore.Ins._dataManager.DataLogDelivery.MaterialDelivaryDTOs);
    }

    private void dgv_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
      return;
      if (e.RowIndex < 0)
        return;

      Color borderColor;
      Color backColor;
      Color textColor;

      if (dgv.Columns[e.ColumnIndex].DataPropertyName != nameof(MaterialDeliveryDTO.ImportExportStatus))
        return;

      var itemMaterial = dgv.Rows[e.RowIndex].DataBoundItem as MaterialDeliveryDTO;
      if (itemMaterial == null)
        return;

      e.PaintBackground(e.CellBounds, true);

      switch (itemMaterial.eExportImport)
      {
        case EnumExportImport.Import:
          //Xanh lá
          borderColor = Color.FromArgb(40, 167, 69);
          backColor = Color.FromArgb(220, 245, 228);
          textColor = borderColor;
          break;
        case EnumExportImport.Export:
          //Xanh dương
          borderColor = Color.FromArgb(30, 64, 175);
          backColor = Color.FromArgb(219, 234, 254);
          textColor = borderColor;
          break;
        default:
          //Xám
          borderColor = Color.FromArgb(73, 80, 87);
          backColor = Color.FromArgb(222, 226, 230);
          textColor = borderColor;
          break;
      }

      var rectMaterial = new Rectangle(
          e.CellBounds.X + 8,
          e.CellBounds.Y + 8,
          e.CellBounds.Width - 16,
          e.CellBounds.Height - 16);

      using (GraphicsPath path = GetRoundRectangle(rectMaterial, 20))
      using (SolidBrush brush = new SolidBrush(backColor))
      using (Pen pen = new Pen(borderColor))
      using (SolidBrush textBrush = new SolidBrush(textColor))
      {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        e.Graphics.FillPath(brush, path);
        e.Graphics.DrawPath(pen, path);

        TextRenderer.DrawText(
            e.Graphics,
            itemMaterial.ImportExportStatus,
            e.CellStyle.Font,
            rectMaterial,
            textColor,
            TextFormatFlags.HorizontalCenter |
            TextFormatFlags.VerticalCenter);
      }
      e.Handled = true;
    }

    private GraphicsPath GetRoundRectangle(Rectangle rect, int radius)
    {
      GraphicsPath path = new GraphicsPath();

      int d = radius * 2;

      path.AddArc(rect.X, rect.Y, d, d, 180, 90);
      path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
      path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
      path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

      path.CloseFigure();

      return path;
    }



    #region Scroll
    private System.Windows.Forms.Timer? _scrollTimer;
    private int _scrollDirection; // -1 = Up, 1 = Down
    private bool _hasAutoScrolled;
    private void InitScrollButton()
    {
      _scrollTimer = new System.Windows.Forms.Timer
      {
        Interval = 30
      };

      _scrollTimer.Tick += ScrollTimer_Tick;

      // UP
      btnUp.MouseDown += BtnUp_MouseDown;
      btnUp.MouseUp += BtnScroll_MouseUp;
      btnUp.MouseLeave += BtnScroll_MouseUp;
      btnUp.Click += btnUp_Click;

      // DOWN
      btnDown.MouseDown += BtnDown_MouseDown;
      btnDown.MouseUp += BtnScroll_MouseUp;
      btnDown.MouseLeave += BtnScroll_MouseUp;
      btnDown.Click += btnDown_Click;
    }

    private void ScrollTimer_Tick(object? sender, EventArgs e)
    {
      _hasAutoScrolled = true;
      ScrollRows(_scrollDirection, 1);
    }

    private void BtnUp_MouseDown(object? sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      _scrollDirection = -1;
      _hasAutoScrolled = false;
      _scrollTimer?.Start();
    }

    private void BtnDown_MouseDown(object? sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      _scrollDirection = 1;
      _hasAutoScrolled = false;
      _scrollTimer?.Start();
    }

    private void BtnScroll_MouseUp(object? sender, EventArgs e)
    {
      _scrollTimer?.Stop();
    }

    private void btnUp_Click(object? sender, EventArgs e)
    {
      // Nếu vừa nhấn giữ để cuộn thì không cuộn thêm một trang.
      if (_hasAutoScrolled)
      {
        _hasAutoScrolled = false;
        return;
      }

      int pageSize = Math.Max(1, dgv.DisplayedRowCount(false));
      ScrollRows(-1, pageSize);
    }

    private void btnDown_Click(object? sender, EventArgs e)
    {
      if (_hasAutoScrolled)
      {
        _hasAutoScrolled = false;
        return;
      }

      int pageSize = Math.Max(1, dgv.DisplayedRowCount(false));
      ScrollRows(1, pageSize);
    }

    private void ScrollRows(int direction, int rowCount)
    {
      if (dgv.Rows.Count == 0)
        return;

      int currentIndex = dgv.FirstDisplayedScrollingRowIndex;

      if (currentIndex < 0)
        currentIndex = 0;

      int targetIndex = currentIndex;
      int movedRows = 0;

      while (movedRows < rowCount)
      {
        int nextIndex = targetIndex + direction;

        if (nextIndex < 0 || nextIndex >= dgv.Rows.Count)
          break;

        targetIndex = nextIndex;

        // Bỏ qua dòng ẩn và dòng bị cố định.
        if (dgv.Rows[targetIndex].Visible &&
            !dgv.Rows[targetIndex].Frozen)
        {
          movedRows++;
        }
      }

      // Tìm dòng hợp lệ gần nhất nếu vị trí hiện tại là dòng ẩn/frozen.
      while (targetIndex >= 0 &&
             targetIndex < dgv.Rows.Count &&
             (!dgv.Rows[targetIndex].Visible ||
              dgv.Rows[targetIndex].Frozen))
      {
        targetIndex += direction;
      }

      if (targetIndex >= 0 && targetIndex < dgv.Rows.Count)
        dgv.FirstDisplayedScrollingRowIndex = targetIndex;
    }

    #endregion
  }
}
