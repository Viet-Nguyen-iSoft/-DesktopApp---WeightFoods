using HelperManager;
using iSoft.Database.DTO;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcPageData : UserControl
  {
    public delegate void SendResfreshData();
    public event SendResfreshData? OnSendResfreshData;

    public delegate void SendReprinter(DatalogDetailDTO? datalogDetailDTO);
    public event SendReprinter? OnSendReprinter;
    public UcPageData()
    {
      InitializeComponent();
      CustomUI();


      this.cbbNumberData.SelectedIndex = 0;
      this.cbbNumberData.SelectedIndexChanged += CbbNumberData_SelectedIndexChanged;
      this.btnPrevious.Click += btnPrevious_Click;
      this.btnNext.Click += btnNext_Click;
      this.dgvBody.CellClick += dgvBody_CellClick;
    }

    private void CustomUI()
    {
      this.dgvBody.BorderStyle = BorderStyle.None;

      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel2;
      elipseControl0.CornerRadius = 20;
    }

    public int currentPage = 1;
    public int totalPage = 1;
    public int totalData = 1;
    public AppModulSupport _appModulSupport;

    private void CbbNumberData_SelectedIndexChanged(object? sender, EventArgs e)
    {
      if (PageSize == -1)
      {
        totalPage = 1;
      }
      else
      {
        totalPage = (int)Math.Ceiling(totalData / (double)PageSize);
        if (totalPage < 1) totalPage = 1;
      }

      SetInforPage(totalPage, currentPage);
      CheckReShowData();
    }
    private void btnPrevious_Click(object? sender, EventArgs e)
    {
      if (PageSize == -1)
      {
        totalPage = 1;
      }
      else
      {
        totalPage = (int)Math.Ceiling(totalData / (double)PageSize);
        if (totalPage < 1) totalPage = 1;
      }

      if (currentPage > 1)
      {
        currentPage--;
      }

      SetInforPage(totalPage, currentPage);
      CheckReShowData();
    }
    private void btnNext_Click(object? sender, EventArgs e)
    {
      if (PageSize == -1)
      {
        totalPage = 1;
      }
      else
      {
        totalPage = (int)Math.Ceiling(totalData / (double)PageSize);
        if (totalPage < 1) totalPage = 1;
      }

      if (currentPage < totalPage)
      {
        currentPage++;
      }

      SetInforPage(totalPage, currentPage);
      CheckReShowData();
    }

    public int PageSize
    {
      get
      {
        if (cbbNumberData.SelectedIndex != -1)
        {
          if (cbbNumberData.SelectedItem != "Tất cả")
          {
            return int.Parse(cbbNumberData.SelectedItem.ToString());
          }
          else
          {
            return -1;
          }
        }
        else
        {
          return -1;
        }
      }
    }

    public void ResetCurrentPage()
    {
      currentPage = 1;
    }


    private List<DatalogDetailDTO> _datalogDetailDTOs = new List<DatalogDetailDTO>();
    private List<DatalogOperationGroupDTO> _datalogOperationGroupDTOs = new List<DatalogOperationGroupDTO>();
    private List<DatalogPOGroupDTO> _datalogPOGroupDTOs = new List<DatalogPOGroupDTO>();
    private List<DatalogDetailDeleteDTO> _datalogDetailDTOsDelete = new List<DatalogDetailDeleteDTO>();
    private List<DatalogDeliveryDTO> _datalogDeliveryDTOs = new List<DatalogDeliveryDTO>();
    public void SetData<T>(List<T> listData, AppModulSupport appModulSupport)
    {
      try
      {
        _appModulSupport = appModulSupport;
        totalData = listData.Count;
        totalPage = (PageSize == -1) ? 1 : (int)Math.Ceiling(listData.Count / (double)PageSize);
        if (totalPage < 1) totalPage = 1;
        //switch (_appModulSupport)
        //{
        //  case AppModulSupport.HistoryDetail:
        //    _datalogDetailDTOs = listData as List<DatalogDetailDTO> ?? new List<DatalogDetailDTO>();
        //    break;
        //  case AppModulSupport.HistoryOperationgroup:
        //    _datalogOperationGroupDTOs = listData as List<DatalogOperationGroupDTO> ?? new List<DatalogOperationGroupDTO>();
        //    break;
        //  case AppModulSupport.HistoryPOGroup:
        //    _datalogPOGroupDTOs = listData as List<DatalogPOGroupDTO> ?? new List<DatalogPOGroupDTO>();
        //    break;
        //  case AppModulSupport.HistoryDelete:
        //    _datalogDetailDTOsDelete = listData as List<DatalogDetailDeleteDTO> ?? new List<DatalogDetailDeleteDTO>();
        //    break;
        //  case AppModulSupport.HistoryDelivery:
        //    _datalogDeliveryDTOs = listData as List<DatalogDeliveryDTO> ?? new List<DatalogDeliveryDTO>();
        //    break;
        //}

        SetInforPage(totalPage, currentPage);
        CheckReShowData();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void CheckReShowData()
    {
      try
      {
        //switch (_appModulSupport)
        //{
        //  case AppModulSupport.HistoryDetail:
        //    var datashow = GetPageData(_datalogDetailDTOs, PageSize, currentPage);
        //    ShowListDetail(datashow);
        //    break;
        //  case AppModulSupport.HistoryOperationgroup:
        //    var datashow2 = GetPageData(_datalogOperationGroupDTOs, PageSize, currentPage);
        //    ShowListGroupOP(datashow2);
        //    break;
        //  case AppModulSupport.HistoryPOGroup:
        //    var datashow3 = GetPageData(_datalogPOGroupDTOs, PageSize, currentPage);
        //    ShowListGroupPO(datashow3);
        //    break;
        //  case AppModulSupport.HistoryDelete:
        //    var datashow4 = GetPageData(_datalogDetailDTOsDelete, PageSize, currentPage);
        //    ShowListDetailDelete(datashow4);
        //    break;
        //  case AppModulSupport.HistoryDelivery:
        //    var datashow5 = GetPageData(_datalogDeliveryDTOs, PageSize, currentPage);
        //    ShowListDelivery(datashow5);
        //    break;
        //}
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private DatalogDetailDTO _datalogReprint;
    private void dgvBody_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0 && dgvBody.Columns[e.ColumnIndex].Name == "Reprint")
      {
        _datalogReprint = dgvBody?.Rows[e.RowIndex].DataBoundItem as DatalogDetailDTO;
        OnSendReprinter?.Invoke(_datalogReprint);
      }
      //else if (e.RowIndex >= 0 && dgvBody.Columns[e.ColumnIndex].Name == "Delete")
      //{
      //  var employeeDTO = dgvBody.Rows[e.RowIndex].DataBoundItem as DatalogDetailDTO;
      //  if (employeeDTO != null)
      //  {
      //    _idChange = employeeDTO.Id;
      //    FrmConfirm frmConfirm = new FrmConfirm($"Xác nhận xóa dữ liệu này ?", eImage.Confirm);
      //    frmConfirm.OnSendOKClicked += FrmConfirm_OnSendOKClicked; ;
      //    frmConfirm.ShowDialog();
      //  }
      //}
      else if (e.RowIndex >= 0 && dgvBody.Columns[e.ColumnIndex].Name == "Detail")
      {
        var datalogDeliveryDTO = dgvBody.Rows[e.RowIndex].DataBoundItem as DatalogDeliveryDTO;
        if (datalogDeliveryDTO != null)
        {
          //FrmDeliveryDetail frmDeliveryDetail = new FrmDeliveryDetail(datalogDeliveryDTO);
          //frmDeliveryDetail.ShowDialog();
        }
      }
    }

    private void FrmConfirm_OnSendOKClicked()
    {
      try
      {

      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }
    //  try
    //  {
    //    if (AppCore.Ins._dataManager.DataLogPrintLabel.Employee != null)
    //    {
    //      await AppCore.Ins.RemoveDatalog_Async(_idChange, AppCore.Ins._dataManager.DataLogPrintLabel.Employee.Id);
    //      OnSendResfreshData?.Invoke();
    //    }
    //    else
    //    {
    //      //await AppCore.Ins.RemoveDatalog_Async(_idChange, 16);
    //      //await SearchData(false);
    //      new FrmInformation().ShowMessage("Chưa đăng nhập", eImage.Warning);
    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
    //  }
    //}

    private void ShowListDetail<T>(List<T> dgv)
    {
      try
      {
        LoadDataDgv(dgv);

        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        btnDelete.Name = "Reprint";
        btnDelete.HeaderText = "";
        btnDelete.Text = "In lại";
        btnDelete.UseColumnTextForButtonValue = true;
        btnDelete.Width = 200;
        btnDelete.MinimumWidth = 200;
        btnDelete.Resizable = DataGridViewTriState.False;
        btnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        dgvBody.Columns.Add(btnDelete);

        dgvBody.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBody.Columns["Reprint"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["Gross"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["Net"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["Tare"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dgvBody.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void ShowListGroupOP<T>(List<T> dgv)
    {
      try
      {
        LoadDataDgv(dgv);

        dgvBody.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBody.Columns[dgvBody.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgvBody.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void ShowListGroupPO<T>(List<T> dgv)
    {
      try
      {
        LoadDataDgv(dgv);

        dgvBody.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBody.Columns[dgvBody.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgvBody.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void ShowListDetailDelete(List<DatalogDetailDeleteDTO> dgv)
    {
      try
      {
        LoadDataDgv(dgv);

        if (dgv.Count > 0)
        {
          foreach (var item in dgv)
          {
            item.UpdatedbyName = AppCore.Ins._employees.FirstOrDefault(x => x.Id == item.Updatedby)?.FullName ?? "N/A";
          }
        }

        dgvBody.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBody.Columns[dgvBody.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgvBody.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["Gross"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["Net"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns["Tare"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dgvBody.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void ShowListDelivery(List<DatalogDeliveryDTO> dgv)
    {
      try
      {
        LoadDataDgv(dgv);

        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        btnDelete.Name = "Detail";
        btnDelete.HeaderText = "";
        btnDelete.Text = "Chi tiết";
        btnDelete.UseColumnTextForButtonValue = true;
        btnDelete.Width = 200;
        btnDelete.MinimumWidth = 200;
        btnDelete.Resizable = DataGridViewTriState.False;
        btnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        dgvBody.Columns.Add(btnDelete);

        //Custom
        dgvBody.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgvBody.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        dgvBody.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBody.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void LoadDataDgv<T>(List<T> dgv)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadDataDgv(dgv);
        }));
        return;
      }

      try
      {
        if (dgvBody.Columns.Contains("Updated"))
        {
          dgvBody.Columns.Remove("Updated");
        }
        if (dgvBody.Columns.Contains("UpdatedByName"))
        {
          dgvBody.Columns.Remove("UpdatedByName");
        }
        if (dgvBody.Columns.Contains("Delete"))
        {
          dgvBody.Columns.Remove("Delete");
        }
        if (dgvBody.Columns.Contains("Detail"))
        {
          dgvBody.Columns.Remove("Detail");
        }
        if (dgvBody.Columns.Contains("MaterialGroup"))
        {
          dgvBody.Columns.Remove("MaterialGroup");
        }
        if (dgvBody.Columns.Contains("Reprint"))
        {
          dgvBody.Columns.Remove("Reprint");
        }

        dgvBody.DataSource = null;
        dgvBody.DataSource = dgv;
        dgvBody.ClearSelection();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void SetInforPage(int totalPage, int currentPage)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetInforPage(totalPage, currentPage);
        }));
        return;
      }

      this.lbTitlePage.Text = $"{currentPage}/{totalPage}";
    }

    public static List<T> GetPageData<T>(List<T> listData, int pageSize, int pageNumber)
    {
      try
      {
        if (pageSize <= 0)
        {
          return listData;
        }
        else
        {
          if (pageNumber <= 0) pageNumber = 1;
          return listData
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToList();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
