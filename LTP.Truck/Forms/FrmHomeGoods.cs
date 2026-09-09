using Common;
using iSoft.Communication.Interface;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LTP.Truck.Controls;
using LTP.Truck.Custom;
using System.Data;
using static Common.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmHomeGoods : Form
  {
    private List<Product> _products = new();
    private int _productGroupRefreshVersion;
    private int _tareRefreshVersion;
    private MessageDataOutput _msgDataWeight { get; set; } = new MessageDataOutput();
    private RecordTruckDTO _recordTruckDTO { get; set; }
    private CategoryTare? _categoryTare { get; set; }
    public FrmHomeGoods()
    {
      InitializeComponent();
      CustomUI();

      cbbTare.SelectedValueChanged += cbbTare_SelectedValueChanged;
      btnSearchHistorical.Click += btnSearchHistorical_Click;
      lbTare.Text = "0.000";
      this.Load += FrmHomeGoods_Load;
    }

    #region Instance
    private static FrmHomeGoods _Instance = null;
    public static FrmHomeGoods Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmHomeGoods();
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

      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = tableLayoutPanel3;
      elipseControl.CornerRadius = 20;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = tableLayoutPanel4;
      elipseControl01.CornerRadius = 20;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.TargetControl = tableLayoutPanel9;
      elipseControl02.CornerRadius = 20;

      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeight = 50;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      dgv.RowTemplate.Height = 60;
      dgv.MultiSelect = false;
      dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
      dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;
    }

    private async void FrmHomeGoods_Load(object? sender, EventArgs e)
    {
      try
      {
        await LoadDataFirst();
        await LoadHistorical();

        cbbProductGroup.SelectedIndex = -1;
        cbbTare.SelectedIndex = -1;

        //Đăng kí sự kiện
        cbbProductGroup.SelectedValueChanged += cbbProductGroup_SelectedValueChanged;

        FrmMain.Instance.OnChangeProductGroup += Instance_OnChangeProductGroup;
        FrmMain.Instance.OnChangeProduct += Instance_OnChangeProduct;
        FrmMain.Instance.OnChangeTare += Instance_OnChangeTare;
        AppCore.Ins.OnSendDataWeightGoods += Ins_OnSendDataWeightGoods;
      }
      catch (Exception ex)
      {

      }
    }

    private void Ins_OnSendDataWeightGoods(object? sender, MessageDataOutput e)
    {
      _msgDataWeight = e;
      SetDataWeight(e);
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

      //Tare
      if (_categoryTare != null)
      {
        lbGross.Text = (messageData.ValueWeight + (_categoryTare?.Value ?? 0.0)).ToString("F3");
      }
      else
      {
        lbGross.Text = messageData.ValueWeight.ToString("F3");
      }
    }

    private async void Instance_OnChangeTare(object? sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action(() => Instance_OnChangeTare(sender, e)));
        return;
      }

      var refreshVersion = ++_tareRefreshVersion;

      try
      {
        var categoryTares = await AppCore.Ins._categoryTareService.GetAllAsync();
        if (IsDisposed || Disposing || refreshVersion != _tareRefreshVersion)
          return;

        var selectedTareId = (cbbTare.SelectedItem as CategoryTare)?.Id;
        var selectedTareIndex = categoryTares.FindIndex(tare => tare.Id == selectedTareId);

        SetTare(categoryTares);
        cbbTare.SelectedIndex = selectedTareIndex;
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async void Instance_OnChangeProduct(object? sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action(() => Instance_OnChangeProduct(sender, e)));
        return;
      }

      var selectedProductId = (cbbProduct.SelectedItem as Product)?.Id;
      _products = await AppCore.Ins._productService.GetAllAsync();
      FillProduct(selectedProductId, preserveSelection: true);
    }

    private async void Instance_OnChangeProductGroup(object? sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action(() => Instance_OnChangeProductGroup(sender, e)));
        return;
      }

      var refreshVersion = ++_productGroupRefreshVersion;

      try
      {
        var productGroups = await AppCore.Ins._productGroupService.GetAllAsync();
        if (IsDisposed || Disposing || refreshVersion != _productGroupRefreshVersion)
          return;

        var selectedProductGroupId = (cbbProductGroup.SelectedItem as ProductGroup)?.Id;
        var selectedProductId = (cbbProduct.SelectedItem as Product)?.Id;
        var selectedGroupIndex = productGroups.FindIndex(group => group.Id == selectedProductGroupId);

        cbbProductGroup.SelectedValueChanged -= cbbProductGroup_SelectedValueChanged;
        try
        {
          SetProductGroup(productGroups);
          cbbProductGroup.SelectedIndex = selectedGroupIndex;
          FillProduct(selectedProductId, preserveSelection: true);
        }
        finally
        {
          cbbProductGroup.SelectedValueChanged += cbbProductGroup_SelectedValueChanged;
        }
      }
      catch (Exception)
      {
      }
    }

    private async Task LoadDataFirst()
    {
      _products = await AppCore.Ins._productService.GetAllAsync();
      var productGroups = await AppCore.Ins._productGroupService.GetAllAsync();
      var categoryTares = await AppCore.Ins._categoryTareService.GetAllAsync();

      SetProductGroup(productGroups);
      SetTare(categoryTares);
    }

    private void SetProductGroup(List<ProductGroup> productGroups)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetProductGroup(productGroups);
        }));
        return;
      }

      cbbProductGroup.DisplayMember = nameof(ProductGroup.Name);
      cbbProductGroup.ValueMember = nameof(ProductGroup.Id);
      cbbProductGroup.DataSource = productGroups;
    }
    private void SetTare(List<CategoryTare> categoryTares)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetTare(categoryTares);
        }));
        return;
      }

      cbbTare.DisplayMember = nameof(CategoryTare.Name);
      cbbTare.ValueMember = nameof(CategoryTare.Id);
      cbbTare.DataSource = categoryTares;
    }

    private void cbbTare_SelectedValueChanged(object? sender, EventArgs e)
    {
      _categoryTare = cbbTare.SelectedItem as CategoryTare;
      if (_categoryTare != null)
      {
        lbTare.Text = _categoryTare?.Value?.ToString("0.000") ?? string.Empty;
      }
      else
      {
        lbTare.Text = 0.0.ToString("0.000") ?? string.Empty;
      }
    }

    private void cbbProductGroup_SelectedValueChanged(object? sender, EventArgs e)
    {
      FillProduct();
    }

    private void FillProduct()
    {
      FillProduct(null, preserveSelection: false);
    }

    private void FillProduct(Guid? selectedProductId, bool preserveSelection)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          FillProduct(selectedProductId, preserveSelection);
        }));
        return;
      }

      if (cbbProductGroup.SelectedItem is not ProductGroup selectedProductGroup)
      {
        cbbProduct.DataSource = null;
        return;
      }

      var products = _products
        .Where(product => product.ProductGroupId == selectedProductGroup.Id)
        .ToList();

      cbbProduct.DisplayMember = nameof(Product.Name);
      cbbProduct.ValueMember = nameof(Product.Id);
      cbbProduct.DataSource = products;

      if (!preserveSelection)
        return;

      if (selectedProductId.HasValue &&
        products.Any(product => product.Id == selectedProductId.Value))
      {
        cbbProduct.SelectedValue = selectedProductId.Value;
      }
      else
      {
        cbbProduct.SelectedIndex = -1;
      }
    }

    private async void btnLoadLicensePlate_Click(object sender, EventArgs e)
    {
      btnLoadLicensePlate.Enabled = false;
      try
      {
        await ShowFirstWeighingRecordsAsync();
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
        if (!IsDisposed && !Disposing)
          MessageBox.Show(this, "Không thể tải danh sách phiếu cân lần 1. Vui lòng thử lại.",
            "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        if (!IsDisposed && !Disposing)
          btnLoadLicensePlate.Enabled = true;
      }
    }

    private async Task ShowFirstWeighingRecordsAsync()
    {
      var filtered = await AppCore.Ins._recordTruckService.GetFirstWeighingRecordsAsync();
      if (IsDisposed || Disposing)
        return;

      if (filtered.Count == 0)
      {
        using var popupMsg = new PopupConfirm("Không có phiếu đã cân lần 1 đang chờ cân lần 2 !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupMsg.ShowDialog();
        return;
      }

      using var popup = new LTP.Truck.Popup.PopupLoadMD();
      var records = iSoft.Database.DTOHelper.ConvertRecordTruckDTO(filtered.ToList());
      popup.SetData(records);
      popup.OnSendData += (data, type) =>
      {
        if (data is iSoft.Database.DTO.RecordTruckDTO selectedRecord)
        {
          _recordTruckDTO = selectedRecord;
          txtLicensePlate.Texts = selectedRecord.LicensePlate ?? string.Empty;
          txtNameDriver.Texts = selectedRecord.NameDriver ?? string.Empty;
          txtIdCard.Texts = selectedRecord.IdCard ?? string.Empty;
        }
      };
      popup.ShowDialog(this);
    }

    private async void btnPrint_Click(object sender, EventArgs e)
    {
      if (_recordTruckDTO?.RecordTruck is not RecordTruck selectedRecordTruck)
      {
        using var popupMsg = new PopupConfirm("Vui lòng chọn biển số xe !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupMsg.ShowDialog();
        return;
      }

      if (cbbProductGroup.SelectedItem is not ProductGroup selectedProductGroup)
      {
        using var popupMsg = new PopupConfirm("Vui lòng chọn nhóm sản phẩm !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupMsg.ShowDialog(this);
        cbbProductGroup.Focus();
        return;
      }

      if (cbbProduct.SelectedItem is not Product selectedProduct)
      {
        using var popupMsg = new PopupConfirm("Vui lòng chọn sản phẩm !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupMsg.ShowDialog(this);
        cbbProduct.Focus();
        return;
      }

      if (cbbTare.SelectedItem is not CategoryTare selectedTare)
      {
        using var popupMsg = new PopupConfirm("Vui lòng chọn Tare !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupMsg.ShowDialog(this);
        cbbTare.Focus();
        return;
      }

      var recordWeight = new RecordWeight
      {
        ProductId = selectedProduct.Id,
        CategoryTareId = selectedTare.Id,
        RecordTruckId = selectedRecordTruck.Id,
        Net = _msgDataWeight.ValueWeight,
        Tare = selectedTare.Value ?? 0.0,
        StationId = AppCore.Ins._station?.Id,
        CreatedAt = DateTime.UtcNow,
        EnableFlag = true
      };

      btnPrint.Enabled = false;
      try
      {
        await AppCore.Ins._recordWeightService.AddOrUpdateAsync(recordWeight);

        //In máy in
        var printDTO = new DTOPrintLabel()
        {
          ProductGroup = selectedProductGroup?.Name ?? string.Empty,
          Product = selectedProduct?.Name ?? string.Empty,
          TypeTare = selectedTare?.Name ?? string.Empty,
          Net = recordWeight?.Net ?? 0.0,
          Tare = recordWeight?.Tare ?? 0.0,
          Datetime = recordWeight?.CreatedAt?.ToString("dd-MM-yyyy HH:mm:ss"),
          Operator = "Admin"
        };
        AppCore.Ins.PrinterLabel(AppCore.Ins._appConfig?.NamePrint, printDTO);

        try
        {
          await LoadHistorical();
        }
        catch (Exception ex)
        {
          HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
        }
        if (!IsDisposed && !Disposing)
        {
          using var popupMsg = new PopupConfirm("Lưu phiếu cân thành công.",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
          popupMsg.ShowDialog(this);
        }
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
        if (!IsDisposed && !Disposing)
        {
          using var popupMsg = new PopupConfirm("Không thể lưu phiếu cân. Vui lòng thử lại !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
          popupMsg.ShowDialog(this);
        }
      }
      finally
      {
        if (!IsDisposed && !Disposing)
          btnPrint.Enabled = true;
      }
    }

    private async void btnSearchHistorical_Click(object? sender, EventArgs e)
    {
      btnSearchHistorical.Enabled = false;
      try
      {
        await LoadHistorical();
      }
      catch (Exception ex)
      {
        HelperManager.LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
        if (!IsDisposed && !Disposing)
        {
          using var popupMsg = new PopupConfirm("Không thể tải lịch sử cân. Vui lòng thử lại !",
            EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
          popupMsg.ShowDialog(this);
        }
      }
      finally
      {
        if (!IsDisposed && !Disposing)
          btnSearchHistorical.Enabled = true;
      }
    }

    private async Task LoadHistorical()
    {
      var fromDate = dtpFrom.Value.Date;
      var toDate = dtpTo.Value.Date;
      if (fromDate > toDate)
      {
        using var popup = new PopupConfirm("Ngày bắt đầu không được lớn hơn ngày kết thúc.",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popup.ShowDialog(this);
        return;
      }

      var fromUtc = fromDate.ToUniversalTime();
      var toUtcExclusive = toDate.AddDays(1).ToUniversalTime();
      var searchKey = txtSearchKey.Texts.Trim();
      var records = await AppCore.Ins._recordWeightService.GetAllAsync();

      var filteredRecords = records.Where(record =>
      {
        var createdAtUtc = record.CreatedAt?.ToUniversalTime();
        return createdAtUtc >= fromUtc && createdAtUtc < toUtcExclusive;
      });

      if (!string.IsNullOrWhiteSpace(searchKey))
      {
        filteredRecords = filteredRecords.Where(record => new[]
        {
          record.Product?.Code,
          record.Product?.Name,
          record.Product?.ProductGroup?.Code,
          record.Product?.ProductGroup?.Name,
          record.CategoryTare?.Code,
          record.CategoryTare?.Name,
          record.RecordTruck?.NoLabelAuto,
          record.RecordTruck?.NoLabelManual,
          record.RecordTruck?.LicensePlate,
          record.RecordTruck?.NameDriver,
          record.RecordTruck?.IdCard
        }.Any(value => value?.Contains(searchKey, StringComparison.OrdinalIgnoreCase) == true));
      }

      SetDgvHistorical(DTOHelper.ConvertRecordWeightDTO(filteredRecords.ToList()));
    }

    private void SetDgvHistorical(List<RecordWeightDTO> records)
    {
      if (InvokeRequired)
      {
        Invoke(new Action(() => SetDgvHistorical(records)));
        return;
      }

      dgv.DataSource = records;

      if (dgv.Columns.Contains(nameof(RecordWeightDTO.RecordWeight)))
        dgv.Columns[nameof(RecordWeightDTO.RecordWeight)].Visible = false;

      var autoSizeColumns = new[]
      {
        nameof(RecordWeightDTO.No),
        nameof(RecordWeightDTO.Datetime),
        nameof(RecordWeightDTO.LicensePlate),
        nameof(RecordWeightDTO.ProductGroup),
        nameof(RecordWeightDTO.CategoryTare),
        nameof(RecordWeightDTO.Net),
        nameof(RecordWeightDTO.Tare),
      };
      foreach (var columnName in autoSizeColumns)
      {
        if (dgv.Columns.Contains(columnName))
          dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }

      var weightColumns = new[]
      {
        nameof(RecordWeightDTO.Net),
        nameof(RecordWeightDTO.Tare),
      };
      foreach (var columnName in weightColumns)
      {
        if (dgv.Columns.Contains(columnName))
          dgv.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      }

      if (dgv.Columns.Contains(nameof(RecordWeightDTO.No)))
        dgv.Columns[nameof(RecordWeightDTO.No)].DefaultCellStyle.Alignment =
          DataGridViewContentAlignment.MiddleCenter;
    }
  }
}
