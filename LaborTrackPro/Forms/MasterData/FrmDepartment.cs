using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using System.Data;

namespace LaborTrackPro.Forms.MasterData
{
  public partial class FrmDepartment : Form
  {
    public FrmDepartment()
    {
      InitializeComponent();
      this.Load += FrmDepartment_Load;
    }

    #region Instance
    private static FrmDepartment _Instance = null;
    public static FrmDepartment Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmDepartment();
        return _Instance;
      }
    }
    #endregion

    private void FrmDepartment_Load(object? sender, EventArgs e)
    {
      FrmMain.Instance.OnSendChangeDepartment += Instance_OnSendChangeDepartment;

      LoadDataDepartments();
    }

    private void Instance_OnSendChangeDepartment()
    {
      LoadDataDepartments();
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
      await AppCore.Ins.ReloadDepartments();
      LoadDataDepartments();
    }

    private void txtSearch__TextChanged(object sender, EventArgs e)
    {
      LoadDataDepartments();
    }

    private void LoadDataDepartments()
    {
      try
      {
        var data = Search(AppCore.Ins._departments, txtSearch.Texts);
        var dto = DTOHelper.ConvertDepartmentToDTO(data);
        ShowDepartment(dto);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private List<Department> Search(List<Department> departments, string textSearch)
    {
      try
      {
        if (departments != null)
        {
          if (!string.IsNullOrWhiteSpace(textSearch))
          {
            string searchLower = TextHelper.RemoveDiacritics(textSearch).ToLower();

            return departments.Where(e =>
                TextHelper.RemoveDiacritics((e.Name ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Description ?? "")).ToLower().Contains(searchLower)
            )
            .OrderBy(x => x.Name)
            .ToList();
          }
          else
          {
            return departments
                  .OrderBy(x => x.Name)
                  .ToList();
          }
        }
        else
        {
          return new List<Department>();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void ShowDepartment(List<DepartmentDTO> departmentDTOs)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDepartment(departmentDTOs);
        }));
        return;
      }

      try
      {
        dgv.DataSource = departmentDTOs;
        dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }



  }
}
