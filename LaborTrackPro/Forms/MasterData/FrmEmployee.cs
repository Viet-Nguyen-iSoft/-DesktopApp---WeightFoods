using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using System.Data;
using System.Threading.Tasks;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Setting
{
  public partial class FrmEmployee : Form
  {
    public FrmEmployee()
    {
      InitializeComponent();
      this.dgv.EnableHeadersVisualStyles = false;
      this.dgv.BorderStyle = BorderStyle.None;
      this.Load += FrmEmployee_Load;
      this.dgv.CellFormatting += DgvEmployee_CellFormatting;
      //FrmMain.Instance.OnSendChangeEmployee += Instance_OnSendChangeEmployee;
    }

    #region Instance
    private static FrmEmployee _Instance = null;
    public static FrmEmployee Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmEmployee();
        return _Instance;
      }
    }
    #endregion

    private async void FrmEmployee_Load(object? sender, EventArgs e)
    {
      await LoadDataEmployees();
    }

    private async void Instance_OnSendChangeEmployee()
    {
      await LoadDataEmployees();
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
      await LoadDataEmployees();
    }

    private async void txtSearch__TextChanged(object sender, EventArgs e)
    {
      await LoadDataEmployees();
    }

    private async Task LoadDataEmployees()
    {
      try
      {
        var employees = await AppCore.Ins.GetAllEmployeeAsync();
        var data = Search(employees, txtSearch.Texts);
        var dto = DTOHelper.ConvertEmployeeToDTO(data);
        ShowListEmployee(dto);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private List<Employee> Search(List<Employee> employees, string textSearch)
    {
      try
      {
        if (employees != null)
        {
          if (!string.IsNullOrWhiteSpace(textSearch))
          {
            string searchLower = TextHelper.RemoveDiacritics(textSearch).ToLower();
            return employees.Where(e =>
                TextHelper.RemoveDiacritics((e.FullName ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Code ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.IdCardCode ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.IdCardName ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Departments?.FirstOrDefault()?.Name ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Account ?? "")).ToLower().Contains(searchLower)
            )
            //.OrderBy(x => x.FullName).ThenBy(x => x.Department?.Name)
            .ToList();
          }
          else
          {
            return employees
            .ToList();
          }
        }
        else
        {
          return new List<Employee>();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
    private void btnAddNew_Click(object sender, EventArgs e)
    {

    }

    private async void Frm_OnSendAddNewEmployee()
    {
      this.txtSearch.Texts = "";
      await AppCore.Ins.ReloadEmployees();
      var dto = DTOHelper.ConvertEmployeeToDTO(AppCore.Ins._employees);
      ShowListEmployee(dto);
    }

    private void ShowListEmployee(List<EmployeeDTO> employeeDTOs)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowListEmployee(employeeDTOs);
        }));
        return;
      }

      dgv.DataSource = employeeDTOs;
      dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

      dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

      //dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

      dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgv.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }

    private void DgvEmployee_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
      if (dgv.Columns[e.ColumnIndex].Name == "Passwords" && e.Value != null)
      {
        e.Value = new string('*', e?.Value?.ToString()?.Length??0);
      }
    }

    private async void btnSyncData_Click(object sender, EventArgs e)
    {
      //try
      //{
      //  ShowStatusSyncData(true);
      //  await SyncData();
      //  ShowStatusSyncData(false);
      //}
      //catch (Exception)
      //{
      //  //TODO
      //}
    }

    private void ShowStatusSyncData(bool sync)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowStatusSyncData(sync);
        }));
        return;
      }

      btnSyncData.Text = sync ? "Đang đồng bộ" : "Đồng bộ";
    }

    private async Task SyncData()
    {
      try
      {
        var employeeLocal = await AppCore.Ins.GetAllEmployeeAsync(isContainDelete: false);
        if (employeeLocal?.Count() > 0)
        {
          var employeeServer = await AppCore.Ins.GetEmployeeEntitys(isContainDelete: true);
          var departmentLocal = await AppCore.Ins.GetDepartmentsAsync(isContainDelete: true);
          if (employeeServer?.Count() > 0)
          {
            List<Employee> employees = new List<Employee>();
            foreach (var employee in employeeLocal)
            {
              try
              {
                var isRs = employeeServer?.Where(x => x.Id == employee.IdSrc).FirstOrDefault();
                if (isRs != null)
                {
                  //var department = departmentLocal.FirstOrDefault(x => x.IdSrc == isRs.DepartmentId);
                  //employee.FullName = isRs.FullName;

                  //if (department != null)
                  //  employee.DepartmentId = department.Id;

                  employees.Add(employee);
                }
              }
              catch (Exception ex)
              {
                LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
              }
            }

            //await AppCore.Ins.UpdateRangeEmployeeAsync(employees);
            //FrmMain.Instance.CallEvent(eTypeDataRefresh.Employee);
          }
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }  
    }
  }
}

