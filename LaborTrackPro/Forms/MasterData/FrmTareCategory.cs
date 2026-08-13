using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Forms.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaborTrackPro.Forms.MasterData
{
  public partial class FrmTareCategory : Form
  {
    public FrmTareCategory()
    {
      InitializeComponent();
      this.Load += FrmTareCategory_Load;
      this.btnSearch.Click += BtnSearch_Click;
      FrmMain.Instance.OnSendChangeSettingTare += Instance_OnSendChangeSettingTare;
    }

    #region Instance
    private static FrmTareCategory _Instance = null;
    public static FrmTareCategory Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmTareCategory();
        return _Instance;
      }
    }
    #endregion

    private void FrmTareCategory_Load(object? sender, EventArgs e)
    {
      LoadDataTareCategories();
    }

    private void Instance_OnSendChangeSettingTare()
    {
      LoadDataTareCategories();
    }

    private async void BtnSearch_Click(object? sender, EventArgs e)
    {
      //await AppCore.Ins.ReloadCategoryTares();
      //LoadDataTareCategories();
    }

    private void LoadDataTareCategories()
    {
      //try
      //{
      //  var data = Search(AppCore.Ins._categoryTares, txtSearch.Texts);
      //  var dto = DTOHelper.ConvertCategoryTareToDTO(data);
      //  ShowDgv(dto);
      //}
      //catch (Exception ex)
      //{
      //  LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      //}
    }

    private void ShowDgv(List<CategoryTareDTO> categoryTareDTOs)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDgv(categoryTareDTOs);
        }));
        return;
      }

      dgv.DataSource = categoryTareDTOs;
      //dgvEmployee.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      //dgvEmployee.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

      //dgvEmployee.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      //dgvEmployee.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

      //dgvEmployee.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      //dgvEmployee.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }

    private List<CategoryTare> Search(List<CategoryTare> categoryTares, string textSearch)
    {
      try
      {
        if (categoryTares != null)
        {
          if (!string.IsNullOrWhiteSpace(textSearch))
          {
            string searchLower = TextHelper.RemoveDiacritics(textSearch).ToLower();

            return categoryTares.Where(e =>
                TextHelper.RemoveDiacritics((e.Name ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e?.Description ?? "")).ToLower().Contains(searchLower) ||
                TextHelper.RemoveDiacritics(((e?.Value??0).ToString())).ToLower().Contains(searchLower)
            )
            .OrderBy(x => x.Name)
            .ToList();
          }
          else
          {
            return categoryTares
            .OrderBy(x => x.Name)
            .ToList();
          }
        }
        else
        {
          return new List<CategoryTare>();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
