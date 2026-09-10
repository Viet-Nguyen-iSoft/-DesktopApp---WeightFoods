using Accessibility;
using Common;
using HelperManager;
using iSoft.Communication.Interface;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using iSoft.Database.Service;
using LTP.Truck.Controls;
using LTP.Truck.Custom;
using LTP.Truck.Popup;
using System.Data;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using static Common.EnumData;
using static iSoft.Database.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmHomeTruck : Form
  {
    private readonly ToolTip _deleteReasonToolTip = new()
    {
      OwnerDraw = true,
      ShowAlways = true
    };
    private readonly Font _deleteReasonToolTipFont = new("Segoe UI", 16F);
    private string _deleteReasonToolTipText = string.Empty;

    public FrmHomeTruck()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmHome_Load;
      this.Shown += FrmHomeTruck_Shown;
      this.Disposed += (_, _) =>
      {
        _deleteReasonToolTip.Dispose();
        _deleteReasonToolTipFont.Dispose();
      };
    }

    #region Instance
    private static FrmHomeTruck _Instance = null;
    public static FrmHomeTruck Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmHomeTruck();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      dtpFrom.Format = DateTimePickerFormat.Custom;
      dtpFrom.CustomFormat = "dd/MM/yyyy";

      dtpTo.Format = DateTimePickerFormat.Custom;
      dtpTo.CustomFormat = "dd/MM/yyyy";

      ucItemWeight01.Title = "KL cân lần 1 (Kg)";
      ucItemWeight02.Title = "KL cân lần 2 (Kg)";
      ucItemWeightGoods.Title = "KL hàng (Kg)";

      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = tableLayoutPanel3;
      elipseControl.CornerRadius = 20;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = tableLayoutPanel4;
      elipseControl01.CornerRadius = 20;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.TargetControl = tableLayoutPanel7;
      elipseControl02.CornerRadius = 20;

      ElipseControl elipseControl03 = new ElipseControl();
      elipseControl03.TargetControl = tableLayoutPanel9;
      elipseControl03.CornerRadius = 20;

      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeight = 50;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      dgv.RowTemplate.Height = 60;
      dgv.BorderStyle = BorderStyle.None;
      dgv.MultiSelect = false;
      dgv.ShowCellToolTips = false;
      dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
      dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;
      dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
      dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
      dgv.RowHeadersDefaultCellStyle.SelectionBackColor = dgv.RowHeadersDefaultCellStyle.BackColor;
      dgv.RowHeadersDefaultCellStyle.SelectionForeColor = dgv.RowHeadersDefaultCellStyle.ForeColor;
      dgv.CellPainting += dgv_CellPainting;
      dgv.CellContentClick += dgv_CellContentClick;
      dgv.CellMouseEnter += dgv_CellMouseEnter;
      dgv.CellMouseLeave += (_, _) => _deleteReasonToolTip.Hide(dgv);
      _deleteReasonToolTip.Popup += DeleteReasonToolTip_Popup;
      _deleteReasonToolTip.Draw += DeleteReasonToolTip_Draw;
    }

    private void FrmHome_Load(object? sender, EventArgs e)
    {
      cbbStatus.SelectedIndex = 1;
      cbbStatus.SelectedIndexChanged += CbbStatus_SelectedIndexChanged;
      cbbType.SelectedIndex = 0;
      cbbType.SelectedIndexChanged += CbbStatus_SelectedIndexChanged;
      AppCore.Ins.OnSendDataWeightTruck += Ins_OnSendDataWeightTruck;
      CheckShowStatusButton(_recordTruck);
    }

    private async void CbbStatus_SelectedIndexChanged(object? sender, EventArgs e)
    {
      await LoadHistorical();
    }

    private async void FrmHomeTruck_Shown(object? sender, EventArgs e)
    {
      await LoadHistorical();
    }

    private void Ins_OnSendDataWeightTruck(object? sender, MessageDataOutput e)
    {
      _msgDataWeight = e;
      SetDataWeight(e);
    }

    private async void btnLoadClient_Click(object sender, EventArgs e)
    {
      var clients = await AppCore.Ins._clientService.GetAllAsync(IsContainDelete: false);
      PopupLoadMD popupLoadMD = new PopupLoadMD();
      popupLoadMD.SetData(clients);
      popupLoadMD.OnSendData += PopupLoadMD_OnSendData;
      popupLoadMD.ShowDialog();
    }

    private async void btnLoadTypeGoods_Click(object sender, EventArgs e)
    {
      var typeGoods = await AppCore.Ins._typeGoodsService.GetAllAsync(IsContainDelete: false);
      PopupLoadMD popupLoadMD = new PopupLoadMD();
      popupLoadMD.SetData(typeGoods);
      popupLoadMD.OnSendData += PopupLoadMD_OnSendData;
      popupLoadMD.ShowDialog();
    }

    private async void btnLoadWarehouse_Click(object sender, EventArgs e)
    {
      var warehouses = await AppCore.Ins._warehouseService.GetAllAsync(IsContainDelete: false);
      PopupLoadMD popupLoadMD = new PopupLoadMD();
      popupLoadMD.SetData(warehouses);
      popupLoadMD.OnSendData += PopupLoadMD_OnSendData;
      popupLoadMD.ShowDialog();
    }

    private void PopupLoadMD_OnSendData(object arg1, Common.EnumData.EnumTypeData arg2)
    {
      switch (arg2)
      {
        case Common.EnumData.EnumTypeData.Client:
          var rsClient = arg1 as ClientDTO;
          SetData(txtClient, rsClient?.Name ?? string.Empty);

          if (rsClient != null)
          {
            _recordTruck.ClientId = rsClient?.Client?.Id;
          }
          break;
        case Common.EnumData.EnumTypeData.TypeGoods:
          var rsTypeGoods = arg1 as TypeGoodsDTO;
          SetData(txtTypeGoods, rsTypeGoods?.Name ?? string.Empty);

          if (rsTypeGoods != null)
          {
            _recordTruck.TypeGoodsId = rsTypeGoods?.TypeGoods?.Id;
          }
          break;
        case Common.EnumData.EnumTypeData.Warehouse:
          var rsWarehouse = arg1 as WareHouseDTO;
          SetData(txtWareHouse, rsWarehouse?.Name ?? string.Empty);

          if (rsWarehouse != null)
          {
            _recordTruck.WarehouseId = rsWarehouse?.Warehouse?.Id;
          }
          break;
        default:
          break;
      }
    }

    private void SetData(RJTextBox rJTextBox, string data)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetData(rJTextBox, data);
        }));
        return;
      }

      rJTextBox.Texts = data;
    }

    private void SetDataWeight(MessageDataOutput messageData)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetDataWeight(messageData);
        }));
        return;
      }

      lbWeightValue.Text = messageData.ValueWeight.ToString("F3");
    }

    private RecordTruck _recordTruck { get; set; } = new RecordTruck();
    private MessageDataOutput _msgDataWeight { get; set; } = new MessageDataOutput();
    private int _weightGoodsLoadVersion;
    private void btnTriggerWeight_Click(object sender, EventArgs e)
    {
      if (_msgDataWeight.ValueWeight <= 0)
      {
        PopupConfirm popupConfirm = new PopupConfirm("Giá trị cân ≤ 0 Kg !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
        return;
      }

      _recordTruck.NetTimeTemp = _msgDataWeight.ValueWeight;
      if (_recordTruck.EnumTypeDataTruck == EnumTypeDataTruck.None)
      {
        _recordTruck.EnumTypeDataTruck = EnumTypeDataTruck.WeightedTime01;
      }
      else if (_recordTruck.EnumTypeDataTruck == EnumTypeDataTruck.DoneTime01)
      {
        _recordTruck.EnumTypeDataTruck = EnumTypeDataTruck.WeightedTime02;
      }

      CheckShowStatusButton(_recordTruck);
    }

    private async void btnWeightTime01_Click(object sender, EventArgs e)
    {
      if (_recordTruck.NetTimeTemp <= 0)
      {
        PopupConfirm popupConfirm = new PopupConfirm("Giá trị cân ≤ 0 Kg !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
        return;
      }

      _recordTruck.NetTime01 = _recordTruck.NetTimeTemp;
      _recordTruck.NetTimeTemp = 0.0;
      _recordTruck.EnumTypeDataTruck = EnumTypeDataTruck.DoneTime01;
      CheckShowStatusButton(_recordTruck);

      //Save DB
      _recordTruck.NoLabelAuto = KeyHelper.CreateLabel(AppCore.Ins._appConfig?.Key);
      _recordTruck.NoLabelManual = txtNoLabel.Texts;
      _recordTruck.NameDriver = txtNameDriver.Texts;
      _recordTruck.LicensePlate = txtLicensePlate.Texts;
      _recordTruck.IdCard = txtIdCard.Texts;
      _recordTruck.Document = txtDocument.Texts;
      _recordTruck.StationId = AppCore.Ins._station?.Id;
      _recordTruck.EmployeeId = AppCore.Ins._employeeCurrent?.Id;
      _recordTruck.CreatedAt = DateTime.UtcNow;
      _recordTruck.UpdatedAt = DateTime.UtcNow;

      await AppCore.Ins._recordTruckService.AddOrUpdateAsync(_recordTruck);
      await LoadHistorical();
    }

    private async void btnWeightTime02_Click(object sender, EventArgs e)
    {
      if (_recordTruck.NetTimeTemp <= 0)
      {
        PopupConfirm popupConfirm = new PopupConfirm("Giá trị cân ≤ 0 Kg !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
        return;
      }

      _recordTruck.NetTime02 = _recordTruck.NetTimeTemp;
      _recordTruck.NetTimeTemp = 0.0;
      _recordTruck.EnumTypeDataTruck = EnumTypeDataTruck.DoneTime02;
      CheckShowStatusButton(_recordTruck);

      //Save DB
      _recordTruck.NoLabelAuto = DateTime.Now.ToString("yyyyMMddHHmmss");
      _recordTruck.NoLabelManual = txtNoLabel.Texts;
      _recordTruck.NameDriver = txtNameDriver.Texts;
      _recordTruck.LicensePlate = txtLicensePlate.Texts;
      _recordTruck.IdCard = txtIdCard.Texts;
      _recordTruck.Document = txtDocument.Texts;
      _recordTruck.StationId = AppCore.Ins._station?.Id;
      _recordTruck.EmployeeId = AppCore.Ins._employeeCurrent?.Id;
      _recordTruck.UpdatedAt = DateTime.UtcNow;

      await AppCore.Ins._recordTruckService.AddOrUpdateAsync(_recordTruck);
      await LoadHistorical();
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      if ((_recordTruck.EnumTypeDataTruck == EnumTypeDataTruck.DoneTime01) ||
          (_recordTruck.EnumTypeDataTruck == EnumTypeDataTruck.WeightedTime02))
      {
        _recordTruck.EnumTypeDataTruck = EnumTypeDataTruck.WeightedTime01;
        _recordTruck.NetTime01 = 0.0;
        CheckShowStatusButton(_recordTruck);
      }
      else if (_recordTruck.EnumTypeDataTruck == EnumTypeDataTruck.DoneTime02)
      {
        _recordTruck.NetTime02 = 0.0;
        _recordTruck.EnumTypeDataTruck = EnumTypeDataTruck.WeightedTime02;
        CheckShowStatusButton(_recordTruck);
      }
    }

    private void CheckShowStatusButton(RecordTruck recordTruck)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          CheckShowStatusButton(recordTruck);
        }));
        return;
      }

      switch (recordTruck.EnumTypeDataTruck)
      {
        case iSoft.Database.EnumData.EnumTypeDataTruck.None:
          btnWeightTime01.Enabled = true;
          btnWeightTime02.Enabled = false;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = "...";
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.WeightedTime01:
          btnWeightTime01.Enabled = true;
          btnWeightTime02.Enabled = false;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = "...";
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.DoneTime01:
          btnWeightTime01.Enabled = false;
          btnWeightTime02.Enabled = true;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = recordTruck.NetTime01.ToString("F3");
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.WeightedTime02:
          btnWeightTime01.Enabled = false;
          btnWeightTime02.Enabled = true;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = recordTruck.NetTime01.ToString("F3");
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.DoneTime02:
          btnWeightTime01.Enabled = false;
          btnWeightTime02.Enabled = false;
          btnPrint.Enabled = true;

          ucItemWeight01.Value = recordTruck.NetTime01.ToString("F3");
          ucItemWeight02.Value = recordTruck.NetTime02.ToString("F3");
          break;
        default:
          break;
      }

      _ = LoadWeightGoodsAsync(recordTruck.Id);
      lbWeightTrigger.Text = recordTruck.NetTimeTemp.ToString("F3");
    }

    private void ShowDataHistorical(RecordTruck recordTruck)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDataHistorical(recordTruck);
        }));
        return;
      }

      switch (recordTruck.EnumTypeDataTruck)
      {
        case iSoft.Database.EnumData.EnumTypeDataTruck.None:
          btnWeightTime01.Enabled = true;
          btnWeightTime02.Enabled = false;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = "...";
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.WeightedTime01:
          btnWeightTime01.Enabled = true;
          btnWeightTime02.Enabled = false;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = "...";
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.DoneTime01:
          btnWeightTime01.Enabled = false;
          btnWeightTime02.Enabled = true;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = recordTruck.NetTime01.ToString("F3");
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.WeightedTime02:
          btnWeightTime01.Enabled = false;
          btnWeightTime02.Enabled = true;
          btnPrint.Enabled = false;

          ucItemWeight01.Value = recordTruck.NetTime01.ToString("F3");
          ucItemWeight02.Value = "...";
          break;
        case iSoft.Database.EnumData.EnumTypeDataTruck.DoneTime02:
          btnWeightTime01.Enabled = false;
          btnWeightTime02.Enabled = false;
          btnPrint.Enabled = true;

          ucItemWeight01.Value = recordTruck.NetTime01.ToString("F3");
          ucItemWeight02.Value = recordTruck.NetTime02.ToString("F3");
          break;
        default:
          break;
      }

      double valueGoods = (recordTruck.NetTime02 - recordTruck.NetTime01);
      _ = LoadWeightGoodsAsync(recordTruck.Id);
      lbWeightTrigger.Text = recordTruck.NetTimeTemp.ToString("F3");

      if (valueGoods > 0 && recordTruck.NetTime01 > 0 && recordTruck.NetTime02 > 0)
      {
        txtTypeWeight.Texts = "Xuất hàng";
      }
      else if (valueGoods < 0 && recordTruck.NetTime01 > 0 && recordTruck.NetTime02 > 0)
      {
        txtTypeWeight.Texts = "Nhập hàng";
      }
      else
      {
        txtTypeWeight.Texts = "Chưa xác định";
      }


      //Show thông tin
      txtNoLabelAuto.Texts = recordTruck?.NoLabelAuto ?? string.Empty;
      txtNoLabel.Texts = recordTruck?.NoLabelManual ?? string.Empty;

      txtNameDriver.Texts = recordTruck?.NameDriver ?? string.Empty;
      txtLicensePlate.Texts = recordTruck?.LicensePlate ?? string.Empty;
      txtIdCard.Texts = recordTruck?.IdCard ?? string.Empty;
      txtDocument.Texts = recordTruck?.Document ?? string.Empty;

      txtClient.Texts = recordTruck?.Client?.Name ?? string.Empty;
      txtWareHouse.Texts = recordTruck?.Warehouse?.Name ?? string.Empty;
      txtTypeGoods.Texts = recordTruck?.TypeGoods?.Name ?? string.Empty;
    }

    private async Task LoadWeightGoodsAsync(Guid recordTruckId)
    {
      var loadVersion = ++_weightGoodsLoadVersion;

      try
      {
        var totalNet = recordTruckId != Guid.Empty
          ? await AppCore.Ins._recordWeightService.SumNetByRecordTruckIdAsync(recordTruckId)
          : 0.0;

        if (IsDisposed || Disposing || loadVersion != _weightGoodsLoadVersion)
          return;

        if (InvokeRequired)
        {
          BeginInvoke(new Action(() =>
          {
            if (loadVersion == _weightGoodsLoadVersion)
              ucItemWeightGoods.Value = totalNet.ToString("F3");
          }));
          return;
        }

        ucItemWeightGoods.Value = totalNet.ToString("F3");
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async void btnSearchHistorical_Click(object sender, EventArgs e)
    {
      await LoadHistorical();
    }

    private async Task LoadHistorical()
    {
      var fromDate = dtpFrom.Value.Date;
      var toDate = dtpTo.Value.Date;
      if (fromDate > toDate)
      {
        using var popup = new PopupConfirm("Ngày bắt đầu không được lớn hơn ngày kết thúc.",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popup.ShowDialog();
        return;
      }

      // Records are saved in UTC; the date pickers represent local calendar days.
      var fromUtc = fromDate.ToUniversalTime();
      var toUtcExclusive = toDate.AddDays(1).ToUniversalTime();
      var statusIndex = cbbStatus.SelectedIndex;
      var typeIndex = cbbType.SelectedIndex;
      var searchKey = txtSearchKey.Texts.Trim();

      // Hiển thị cả bản ghi đã xóa để người dùng có thể phục hồi.
      var rs = await AppCore.Ins._recordTruckService.GetAllAsync(true);
      var filtered = rs.Where(record =>
      {
        // Npgsql legacy timestamp mode returns local DateTime values.
        // Normalize both sides to UTC before comparing their clock values.
        var updatedAtUtc = record.UpdatedAt?.ToUniversalTime();
        return updatedAtUtc >= fromUtc && updatedAtUtc < toUtcExclusive;
      });

      filtered = typeIndex switch
      {
        1 => filtered.Where(record => !record.DeletedFlag),
        2 => filtered.Where(record => record.DeletedFlag),
        _ => filtered
      };

      filtered = statusIndex switch
      {
        1 => filtered.Where(record =>
          record.EnumTypeDataTruck == EnumTypeDataTruck.WeightedTime01 ||
          record.EnumTypeDataTruck == EnumTypeDataTruck.DoneTime01 ||
          record.EnumTypeDataTruck == EnumTypeDataTruck.WeightedTime02),
        2 => filtered.Where(record => record.EnumTypeDataTruck == EnumTypeDataTruck.DoneTime02),
        _ => filtered
      };

      if (!string.IsNullOrEmpty(searchKey))
      {
        filtered = filtered.Where(record => new[]
        {
          record.NoLabelAuto, record.NoLabelManual, record.LicensePlate,
          record.NameDriver, record.IdCard, record.Document,
          record.Client?.Name, record.TypeGoods?.Name, record.Warehouse?.Name
        }.Any(value => value?.Contains(searchKey, StringComparison.OrdinalIgnoreCase) == true));
      }

      var dto = DTOHelper.ConvertRecordTruckDTO(filtered.ToList());
      SetDgvHistorical(dto);
    }

    private async void dgv_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0 || e.ColumnIndex < 0)
        return;

      if (dgv.Rows[e.RowIndex].DataBoundItem is not RecordTruckDTO recordTruckDto)
        return;

      switch (dgv.Columns[e.ColumnIndex].Name)
      {
        case "btnDetail":
          btnDetail_Click(recordTruckDto);
          break;
        case "btnDelete":
          await ToggleDeletedFlagAsync(recordTruckDto);
          break;
      }
    }

    private async Task ToggleDeletedFlagAsync(RecordTruckDTO recordTruckDto)
    {
      if (recordTruckDto.RecordTruck is not RecordTruck recordTruck)
        return;

      try
      {
        if (!recordTruck.DeletedFlag)
        {
          using var inputReason = new PopupInputReason();
          if (inputReason.ShowDialog(this) != DialogResult.OK)
            return;
          recordTruck.ReasonDelete = inputReason.Reason;
          recordTruck.DeletedFlag = true;
        }
        else
        {
          recordTruck.DeletedFlag = false;
        }

        recordTruck.UpdatedAt = DateTime.UtcNow;
        await AppCore.Ins._recordTruckService.AddOrUpdateAsync(recordTruck);
        await LoadHistorical();
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
        using var popup = new PopupConfirm(
          "Không thể cập nhật trạng thái bản ghi. Vui lòng thử lại!",
          EnumTypeMsg.MessageManualClose,
          EnumImageMsg.Warning);
        popup.ShowDialog(this);
      }
    }

    public void SetDgvHistorical(List<RecordTruckDTO> dto)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetDgvHistorical(dto);
        }));
        return;
      }

      dgv.DataSource = dto;

      if (!dgv.Columns.Contains("btnDetail"))
      {
        dgv.Columns.Add(new DataGridViewButtonColumn
        {
          Name = "btnDetail",
          HeaderText = "",
          Text = "Chi tiết",
          UseColumnTextForButtonValue = true,
          AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
          Width = 150,
          Resizable = DataGridViewTriState.False,
          SortMode = DataGridViewColumnSortMode.NotSortable,
        });
      }

      if (!dgv.Columns.Contains("btnDelete"))
      {
        dgv.Columns.Add(new DataGridViewButtonColumn
        {
          Name = "btnDelete",
          HeaderText = "",
          UseColumnTextForButtonValue = false,
          AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
          Width = 120,
          Resizable = DataGridViewTriState.False,
          SortMode = DataGridViewColumnSortMode.NotSortable,
        });
      }

      dgv.Columns["btnDetail"].DisplayIndex = dgv.Columns.Count - 2;
      dgv.Columns["btnDelete"].DisplayIndex = dgv.Columns.Count - 1;

      foreach (DataGridViewRow row in dgv.Rows)
      {
        if (row.DataBoundItem is RecordTruckDTO item && item.RecordTruck != null)
        {
          var isDeleted = item.RecordTruck.DeletedFlag;
          row.Cells["btnDelete"].Value = isDeleted
            ? "Phục hồi"
            : "Xóa";
          var rowBackColor = isDeleted
            ? Color.Tomato
            : dgv.DefaultCellStyle.BackColor;
          row.DefaultCellStyle.BackColor = rowBackColor;
          row.DefaultCellStyle.SelectionBackColor = rowBackColor;
        }
      }

      var hiddenColumns = new[]
      {
        nameof(RecordTruckDTO.RecordTruck),
        nameof(RecordTruckDTO.EnumTypeDataTruck),
        nameof(RecordTruckDTO.Client),
        nameof(RecordTruckDTO.TypeGoods),
        nameof(RecordTruckDTO.Warehouse),
        nameof(RecordTruckDTO.NameDriver),
        nameof(RecordTruckDTO.IdCard),
        nameof(RecordTruckDTO.Document)
      };
      foreach (var columnName in hiddenColumns)
      {
        if (dgv.Columns.Contains(columnName))
          dgv.Columns[columnName].Visible = false;
      }

      var autoSizeColumns = new[]
      {
        nameof(RecordTruckDTO.No),
        nameof(RecordTruckDTO.Datetime),
        nameof(RecordTruckDTO.LicensePlate),
        nameof(RecordTruckDTO.NameDriver),
        nameof(RecordTruckDTO.IdCard),
        nameof(RecordTruckDTO.NetTime01),
        nameof(RecordTruckDTO.NetTime02)
      };
      foreach (var columnName in autoSizeColumns)
      {
        if (dgv.Columns.Contains(columnName))
          dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }

      if (dgv.Columns.Contains(nameof(RecordTruckDTO.Status)))
      {
        var statusColumn = dgv.Columns[nameof(RecordTruckDTO.Status)];
        statusColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        statusColumn.Width = 150;
        statusColumn.Resizable = DataGridViewTriState.False;
      }

      var alignmentMiddleRightColumns = new[]
      {
        nameof(RecordTruckDTO.NetTime01),
        nameof(RecordTruckDTO.NetTime02),
      };
      foreach (var columnName in alignmentMiddleRightColumns)
      {
        if (dgv.Columns.Contains(columnName))
          dgv.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      }

      var alignmentMiddleCenterColumns = new[]
      {
        nameof(RecordTruckDTO.No),
      };
      foreach (var columnName in alignmentMiddleCenterColumns)
      {
        if (dgv.Columns.Contains(columnName))
          dgv.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
    }

    private void dgv_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
    {
      _deleteReasonToolTip.Hide(dgv);
      _deleteReasonToolTipText = string.Empty;

      if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
        dgv.Columns[e.ColumnIndex].Name != "btnDelete" ||
        dgv.Rows[e.RowIndex].DataBoundItem is not RecordTruckDTO item ||
        item.RecordTruck?.DeletedFlag != true ||
        string.IsNullOrWhiteSpace(item.RecordTruck.ReasonDelete))
      {
        return;
      }

      var cellBounds = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
      _deleteReasonToolTipText = $"Lý do xóa: {item.RecordTruck.ReasonDelete}";
      _deleteReasonToolTip.Show(
        _deleteReasonToolTipText,
        dgv,
        cellBounds.Left,
        cellBounds.Bottom,
        10000);
    }

    private void DeleteReasonToolTip_Popup(object? sender, PopupEventArgs e)
    {
      if (string.IsNullOrEmpty(_deleteReasonToolTipText))
        return;

      var textSize = TextRenderer.MeasureText(
        _deleteReasonToolTipText,
        _deleteReasonToolTipFont,
        new Size(600, 0),
        TextFormatFlags.WordBreak);
      e.ToolTipSize = new Size(textSize.Width + 24, textSize.Height + 16);
    }

    private void DeleteReasonToolTip_Draw(object? sender, DrawToolTipEventArgs e)
    {
      e.Graphics.FillRectangle(Brushes.LightYellow, e.Bounds);
      e.DrawBorder();
      TextRenderer.DrawText(
        e.Graphics,
        e.ToolTipText,
        _deleteReasonToolTipFont,
        Rectangle.Inflate(e.Bounds, -12, -8),
        Color.Black,
        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
    }

    private void btnDetail_Click(RecordTruckDTO recordTruckDto)
    {
      if (recordTruckDto != null)
      {
        _recordTruck = recordTruckDto.RecordTruck;
        ShowDataHistorical(_recordTruck);
      }
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
      _recordTruck = new RecordTruck();
      ShowDataHistorical(_recordTruck);
    }


    #region Đường bo Status
    private void dgv_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
      if (e.RowIndex < 0)
        return;

      Color borderColor;
      Color backColor;
      Color textColor;

      if (dgv.Columns[e.ColumnIndex].DataPropertyName != nameof(RecordTruckDTO.Status))
        return;

      var itemMaterial = dgv.Rows[e.RowIndex].DataBoundItem as RecordTruckDTO;
      if (itemMaterial == null)
        return;

      e.PaintBackground(e.CellBounds, true);

      if (itemMaterial.RecordTruck?.DeletedFlag == true)
      {
        borderColor = Color.DarkRed;
        backColor = Color.Tomato;
        textColor = Color.White;
      }
      else switch (itemMaterial.EnumTypeDataTruck)
        {
          case EnumTypeDataTruck.WeightedTime01:
          case EnumTypeDataTruck.DoneTime01:
            //Xanh dương
            borderColor = Color.FromArgb(30, 64, 175);
            backColor = Color.FromArgb(219, 234, 254);
            textColor = borderColor;
            break;
          case EnumTypeDataTruck.WeightedTime02:
          case EnumTypeDataTruck.DoneTime02:
            //Xanh lá
            borderColor = Color.FromArgb(40, 167, 69);
            backColor = Color.FromArgb(220, 245, 228);
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
            itemMaterial.Status,
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
    #endregion


    public readonly RecordTruckService _recordTruckService = new();
    private void btnZero_Click(object sender, EventArgs e)
    {
      //RecordTruck? record = await _recordTruckService.GetDetailByIdAsync(_recordTruck.Id);

      //if (record == null)
      //  return;

      //Download(DateTime.Now, record);
    }

    private async void btnPrint_Click(object sender, EventArgs e)
    {
      try
      {
        RecordTruck? record = await _recordTruckService.GetDetailByIdAsync(_recordTruck.Id);

        if (record == null)
          return;


        //var recordWeightsByProduct = (record.RecordWeights ?? Enumerable.Empty<RecordWeight>())
        //.GroupBy(recordWeight => recordWeight.ProductId)
        //.Select(group => new
        //{
        //  ProductGroup = group.First().Product.ProductGroup?.Name,
        //  ProductName = group.First().Product?.Name ?? string.Empty,
        //  ProductCode = group.First().Product?.Code ?? string.Empty,
        //  SumNet = group.Sum(recordWeight => recordWeight.Net)
        //})
        //.ToList();

        await Download(DateTime.Now, record);


        PopupConfirm popupConfirm = new PopupConfirm("In phiếu giao nhận thành công.", EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupConfirm.ShowDialog();
      }
      catch (Exception ex)
      {
        PopupConfirm popupConfirm = new PopupConfirm("In phiếu giao nhận thất bại !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
      }
    }


    private async Task Download(DateTime dt, RecordTruck recordTruck)
    {
      string pathFileTemplateTable = Application.StartupPath + "Template\\TemplateTableHtml.html";
      string pathFileTemplate = Application.StartupPath + "Template\\TemplateHtml.html";
      string folderOutput = Application.StartupPath + "Template\\OutputFiles";


      string template = File.ReadAllText(pathFileTemplate);
      string table = File.ReadAllText(pathFileTemplateTable);
      string result = template.Replace("{{documentNo}}", "A26-00001")
                              .Replace("{documentNo}", "A26-00001")
                              .Replace("{{day}}", dt.Day.ToString())
                              .Replace("{day}", dt.Day.ToString())
                              .Replace("{{month}}", dt.Month.ToString())
                              .Replace("{month}", dt.Month.ToString())
                              .Replace("{{year}}", dt.Year.ToString())
                              .Replace("{year}", dt.Year.ToString())
                              .Replace("{{vehiclePlate}}", recordTruck.LicensePlate)
                              .Replace("{{sealNo}}", "")

                              .Replace("{{signPlace}}", "Đồng Nai")
                              .Replace("{{signDay}}", dt.Day.ToString())
                              .Replace("{{signMonth}}", dt.Month.ToString())
                              .Replace("{{signYear}}", dt.Year.ToString())
                              .Replace("{{sender.deptCode}}", "FCM")
                              .Replace("{{receiver.deptCode}}", "SES");


      var recordWeightsByProduct = (recordTruck.RecordWeights ?? Enumerable.Empty<RecordWeight>())
        .GroupBy(recordWeight => recordWeight.ProductId)
        .Select(group => new
        {
          ProductGroup = group.First().Product.ProductGroup?.Name,
          ProductName = group.First().Product?.Name ?? string.Empty,
          ProductCode = group.First().Product?.Code ?? string.Empty,
          SumNet = group.Sum(recordWeight => recordWeight.Net)
        })
        .ToList();


      string tableDetails = string.Empty;
      double value = 0.0;
      if (recordWeightsByProduct?.Count() > 0)
      {
        for (int no = 1; no <= recordWeightsByProduct?.Count(); no++)
        {
          string tempTableDetal = table;
          tempTableDetal = tempTableDetal.Replace("{{no}}", (no).ToString("D2"));
          tempTableDetal = tempTableDetal.Replace("{{name}}", recordWeightsByProduct[no-1].ProductName);
          tempTableDetal = tempTableDetal.Replace("{{code}}", recordWeightsByProduct[no - 1].ProductCode);
          tempTableDetal = tempTableDetal.Replace("{{quantity}}", recordWeightsByProduct[no - 1].SumNet.ToString("F3"));
          tempTableDetal = tempTableDetal.Replace("{{note}}", "");


          tableDetails = tableDetails + tempTableDetal;
          value += recordWeightsByProduct[no - 1].SumNet;
        }
      }

      result = result.Replace("{{totalQuantity}}", value.ToString("F3"));
      result = result.Replace("{table}", tableDetails);

      string outputPath = Path.Combine(folderOutput, $"{dt.ToString("yyMMddHHmmss")}.html");
      File.WriteAllText(outputPath, result);

      await CreateFile(outputPath);
    }


    private async Task<bool> CreateFile(string path)
    {
      try
      {
        string pdf = path.Replace(".html", ".pdf");
        await PdfHelper.HtmlToPdfAsync(path, pdf);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
