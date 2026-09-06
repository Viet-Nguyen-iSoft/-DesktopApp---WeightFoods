using Common;
using iSoft.Communication.Interface;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LTP.Truck.Controls;
using LTP.Truck.Custom;
using LTP.Truck.Popup;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.EnumData;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmHome : Form
  {
    public FrmHome()
    {
      InitializeComponent();
      dgv.CellContentClick += dgv_CellContentClick;
      CustomUI();
      this.Load += FrmHome_Load;
    }

    #region Instance
    private static FrmHome _Instance = null;
    public static FrmHome Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmHome();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
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
      dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
      dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;
      dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
      dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
      dgv.RowHeadersDefaultCellStyle.SelectionBackColor = dgv.RowHeadersDefaultCellStyle.BackColor;
      dgv.RowHeadersDefaultCellStyle.SelectionForeColor = dgv.RowHeadersDefaultCellStyle.ForeColor;
      dgv.CellPainting += dgv_CellPainting;
    }

    private void FrmHome_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendDataWeight += Ins_OnSendDataWeight;
      CheckShowStatusButton(_recordTruck);
    }

    private void Ins_OnSendDataWeight(object? sender, MessageDataOutput e)
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
      _recordTruck.NoLabelAuto = DateTime.Now.ToString("yyyyMMddHHmmss");
      _recordTruck.NoLabelManual = txtNoLabel.Texts;
      _recordTruck.NameDriver = txtNameDriver.Texts;
      _recordTruck.LicensePlate = txtLicensePlate.Texts;
      _recordTruck.IdCard = txtIdCard.Texts;
      _recordTruck.Document = txtDocument.Texts;
      _recordTruck.CreatedAt = DateTime.UtcNow;
      _recordTruck.UpdatedAt = DateTime.UtcNow;

      await AppCore.Ins._recordTruckService.AddOrUpdateAsync(_recordTruck);
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
      _recordTruck.UpdatedAt = DateTime.UtcNow;

      await AppCore.Ins._recordTruckService.AddOrUpdateAsync(_recordTruck);
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

      ucItemWeightGoods.Value = (recordTruck.NetTime02 - recordTruck.NetTime01).ToString("F3");
      lbWeightTrigger.Text = recordTruck.NetTimeTemp.ToString("F3");
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      try
      {
        //_recordTruck.NoLabelAuto = DateTime.Now.ToString("yyyyMMddHHmmss");
        //_recordTruck.NoLabelManual = txtNoLabel.Texts;
        //_recordTruck.NameDriver = txtNameDriver.Texts;
        //_recordTruck.LicensePlate = txtLicensePlate.Texts;
        //_recordTruck.IdCard = txtIdCard.Texts;
        //_recordTruck.Document = txtDocument.Texts;
        //_recordTruck.CreatedAt = DateTime.UtcNow;
        //_recordTruck.UpdatedAt = DateTime.UtcNow;

        //await AppCore.Ins._recordTruckService.AddOrUpdateAsync(_recordTruck);

        PopupConfirm popupConfirm = new PopupConfirm("Lưu dữ liệu thành công.", EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupConfirm.ShowDialog();

        //Rst biến tạm
        _recordTruck = new RecordTruck();
        CheckShowStatusButton(_recordTruck);
      }
      catch (Exception ex)
      {

      }
    }

    private async void btnSearchHistorical_Click(object sender, EventArgs e)
    {
      await LoadHistorical();
    }

    private async Task LoadHistorical()
    {
      var rs = await AppCore.Ins._recordTruckService.GetAllAsync();
      var dto = DTOHelper.ConvertRecordTruckDTO(rs);
      SetDgvHistorical(dto);
    }

    private void dgv_CellContentClick(object? sender, DataGridViewCellEventArgs e)
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

      dgv.Columns["btnDetail"].DisplayIndex = dgv.Columns.Count - 1;

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

    private void btnDetail_Click(RecordTruckDTO recordTruckDto)
    {
      
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

      switch (itemMaterial.EnumTypeDataTruck)
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
  }
}
