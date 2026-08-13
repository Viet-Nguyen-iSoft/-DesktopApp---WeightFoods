using DocumentFormat.OpenXml.Wordprocessing;
using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.Setting;
using System.Drawing.Printing;
using System.Threading.Tasks;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Settings
{
  public partial class FrmSettingPrinter : Form
  {
    public FrmSettingPrinter()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmSettingChoosePrinter_Load;
      this.Shown += FrmSettingPrinter_Shown;

      this.btnSaveIpPrintWeight.Click += BtnSaveIpPrintWeight_Click;
      this.btnUpNumberLabelWeight.Click += BtnUpNumberLabelWeight_Click;
      this.btnDownNumberLabelWeight.Click += BtnDownNumberLabelWeight_Click;

      this.btnSaveIpPrintA4.Click += BtnSaveIpPrintA4_Click;
    }

    private async void BtnSaveIpPrintA4_Click(object? sender, EventArgs e)
    {
      string namePrintChoose = cbbPrinterA4.SelectedItem.ToString();
      if (!string.IsNullOrEmpty(namePrintChoose))
      {
        AppCore.Ins._appConfig.NamePrinterA4 = namePrintChoose;
        if (await AppCore.Ins.UpdateAppConfig_Async(AppCore.Ins._appConfig))
        {
          new FrmInformation().ShowMessage("Lưu thông tin máy in thành công", eImage.Information);
        }
        else
        {
          new FrmInformation().ShowMessage("Lưu thông máy tin in thất bại", eImage.Warning);
        }
      }
      else
      {
        new FrmInformation().ShowMessage("Vui lòng điền IP máy in", eImage.Warning);
      }
    }

    private async void BtnDownNumberLabelWeight_Click(object? sender, EventArgs e)
    {
      try
      {
        int value = (int)numberLabelWeight.Value;
        if (value > 1)
        {
          value = value - 1;
          AppCore.Ins._appConfig.NumberLabelWeight = value;
          await AppCore.Ins.UpdateAppConfig_Async(AppCore.Ins._appConfig);

          SetNumberLabelWeight(value);
        }
      }
      catch (Exception)
      {
        //TODO
      }
    }

    private async void BtnUpNumberLabelWeight_Click(object? sender, EventArgs e)
    {
      try
      {
        int value = (int)numberLabelWeight.Value;
        value = value + 1;
        AppCore.Ins._appConfig.NumberLabelWeight = value;
        await AppCore.Ins.UpdateAppConfig_Async(AppCore.Ins._appConfig);

        SetNumberLabelWeight(value);
      }
      catch (Exception)
      {
        //TODO
      }
    }

    private void SetNumberLabelWeight(int value)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetNumberLabelWeight(value);
        }));
        return;
      }
      numberLabelWeight.Value = value;
    }

    private async void BtnSaveIpPrintWeight_Click(object? sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txtIpPrintWeight.Texts))
      {
        AppCore.Ins._appConfig.NamePrinter = txtIpPrintWeight.Texts.Trim();
        if (await AppCore.Ins.UpdateAppConfig_Async(AppCore.Ins._appConfig))
        {
          new FrmInformation().ShowMessage("Lưu thông tin máy in thành công", eImage.Information);
        }
        else
        {
          new FrmInformation().ShowMessage("Lưu thông máy tin in thất bại", eImage.Warning);
        }
      }
      else
      {
        new FrmInformation().ShowMessage("Vui lòng điền IP máy in", eImage.Warning);
      }
    }

    #region Instance
    private static FrmSettingPrinter _Instance = null;
    public static FrmSettingPrinter Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSettingPrinter();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      dgv.EnableHeadersVisualStyles = false;
      dgv.BorderStyle = BorderStyle.None;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = this.tableLayoutPanel2;
      elipseControl01.CornerRadius = 15;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.TargetControl = this.tableLayoutPanel3;
      elipseControl02.CornerRadius = 15;

      txtIpPrintWeight.TextAlign(HorizontalAlignment.Right);
    }

    private void FrmSettingChoosePrinter_Load(object? sender, EventArgs e)
    {
      dgv.CellClick += Dgv_CellContentClick;
    }
    private async void FrmSettingPrinter_Shown(object? sender, EventArgs e)
    {
      LoadPrintersA4();

      ShowSettingPrintWeight();

      var rs = await GetData(eTypeLabel.Delivery);
      var rsDTO = DTOHelper.ConvertSettingLabelDTO(rs);
      ShowDatagridview(rsDTO);
    }

    private void LoadPrintersA4()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadPrintersA4();
        }));
        return;
      }

      cbbPrinterA4.Items.Clear();

      foreach (string printer in PrinterSettings.InstalledPrinters)
      {
        cbbPrinterA4.Items.Add(printer);
      }
    }

    private void ShowSettingPrintWeight()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowSettingPrintWeight();
        }));
        return;
      }

      txtIpPrintWeight.Texts = AppCore.Ins._appConfig.NamePrinter??string.Empty;
      numberLabelWeight.Value = AppCore.Ins._appConfig.NumberLabelWeight ?? 1;

      cbbPrinterA4.SelectedItem = AppCore.Ins._appConfig.NamePrinterA4;
    }

    private async Task<List<SettingLabel>> GetData(eTypeLabel eTypeLabel)
    {
      return await AppCore.Ins.GetAllSettingLabelAsync(eTypeLabel);
    }

    private SettingLabelDTO _settingLabelDTO;
    private void ShowDatagridview<T>(List<T>? t)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDatagridview(t);
        }));
        return;
      }
      dgv.DataSource = null;
      dgv.DataSource = t;

      if (dgv.Columns.Contains("Edit"))
      {
        dgv.Columns.Remove("Edit");
      }
      DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
      btnEdit.Name = "Edit";
      btnEdit.HeaderText = "";
      btnEdit.Text = "Chỉnh sửa";
      btnEdit.UseColumnTextForButtonValue = true;
      btnEdit.Width = 200;
      btnEdit.MinimumWidth = 200;
      btnEdit.Resizable = DataGridViewTriState.False;
      btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      dgv.Columns.Add(btnEdit);


      if (dgv.Columns.Contains("Remove"))
      {
        dgv.Columns.Remove("Remove");
      }
      DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
      btnRemove.Name = "Remove";
      btnRemove.HeaderText = "";
      btnRemove.Text = "Xóa";
      btnRemove.UseColumnTextForButtonValue = true;
      btnRemove.Width = 200;
      btnRemove.MinimumWidth = 200;
      btnRemove.Resizable = DataGridViewTriState.False;
      btnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      dgv.Columns.Add(btnRemove);

      dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


      dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }


    private void Dgv_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
      try
      {
        if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex].Name == "Edit")
        {
          var rsChoose = (SettingLabelDTO)dgv.Rows[e.RowIndex].DataBoundItem;

          if (rsChoose != null)
          {
            FrmEditQualityNumberPrinter frm = new FrmEditQualityNumberPrinter(eTypeLabel.Delivery, rsChoose?.SettingLabel);
            frm.OnSaveClick += FrmEditQualityNumberPrinter_OnSaveClick;
            frm.ShowDialog();
          }
        }
        else if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex].Name == "Remove")
        {
          _settingLabelDTO = (SettingLabelDTO)dgv.Rows[e.RowIndex].DataBoundItem;

          if (_settingLabelDTO != null)
          {
            FrmConfirm frmConfirm = new FrmConfirm("Xác nhận xóa ?", eImage.Confirm);
            frmConfirm.OnSendOKClicked += FrmConfirm_OnSendOKClicked;
            frmConfirm.ShowDialog();
          }
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }
    private async void FrmConfirm_OnSendOKClicked()
    {
      await AppCore.Ins.RemoveSettingLabel(_settingLabelDTO.Id);
      var rs = await GetData(eTypeLabel.Delivery);
      var rsDTO = DTOHelper.ConvertSettingLabelDTO(rs);
      ShowDatagridview(rsDTO);
      await AppCore.Ins.ReloadSettingLabels();
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      FrmEditQualityNumberPrinter frmEditQualityNumberPrinter = new FrmEditQualityNumberPrinter(eTypeLabel.Delivery);
      frmEditQualityNumberPrinter.OnSaveClick += FrmEditQualityNumberPrinter_OnSaveClick;
      frmEditQualityNumberPrinter.ShowDialog();
    }

    private async void FrmEditQualityNumberPrinter_OnSaveClick(eTypeLabel eTypeLabel)
    {
      var rs = await GetData(eTypeLabel);
      var rsDTO = DTOHelper.ConvertSettingLabelDTO(rs);
      ShowDatagridview(rsDTO);
    }

  }
}
