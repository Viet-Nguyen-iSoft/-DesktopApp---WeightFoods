using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using Newtonsoft.Json;
using System.Data;
using System.Threading.Tasks;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Settings
{
  public partial class FrmMaterial : Form
  {
    public FrmMaterial()
    {
      InitializeComponent();
      this.cbbMaterialType.SelectedIndex = 0;
      this.Load += FrmSettingProductMaterial_Load;
      FrmMain.Instance.OnSendChangeMaterial += Instance_OnSendChangeMaterial;
      this.cbbMaterialType.SelectedIndexChanged += CbbMaterialType_SelectedIndexChanged;
    }
    #region Instance
    private static FrmMaterial _Instance = null;
    public static FrmMaterial Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmMaterial();
        return _Instance;
      }
    }
    #endregion

    private List<Material> materials = new List<Material>();
    private EnumMaterialType _eMaterialType = EnumMaterialType.None;
    private async void FrmSettingProductMaterial_Load(object? sender, EventArgs e)
    {
      await SearchData();
    }

    private async void Instance_OnSendChangeMaterial()
    {
      await SearchData();
    }

    private void CbbMaterialType_SelectedIndexChanged(object? sender, EventArgs e)
    {
      if (cbbMaterialType.SelectedIndex == 0)
      {
        _eMaterialType = EnumMaterialType.None;
      }
      else if (cbbMaterialType.SelectedIndex == 1)
      {
        _eMaterialType = EnumMaterialType.RawMaterial;
      }
      else if (cbbMaterialType.SelectedIndex == 2)
      {
        _eMaterialType = EnumMaterialType.Material;
      }
      else if (cbbMaterialType.SelectedIndex == 3)
      {
        _eMaterialType = EnumMaterialType.SemiFinishedGoods;
      }
      else if (cbbMaterialType.SelectedIndex == 4)
      {
        _eMaterialType = EnumMaterialType.FinshGoods;
      }
      else if (cbbMaterialType.SelectedIndex == 5)
      {
        _eMaterialType = EnumMaterialType.MRsDefect;
      }
    }
    
    private async Task SearchData()
    {
      try
      {
        materials = await AppCore.Ins.GetMaterialsAsync(_eMaterialType);
        var dto = DTOHelper.ConvertMaterialToDTO(materials);
        var rsDto = Search(dto, txtSearch.Texts);
        ShowDgv(rsDto);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }


    private async void btnSearch_Click(object sender, EventArgs e)
    {
      await SearchData();
    }

    private void txtSearch__TextChanged(object sender, EventArgs e)
    {
      try
      {
        var dto = DTOHelper.ConvertMaterialToDTO(AppCore.Ins._materials);
        var rsDto = Search(dto, txtSearch.Texts);
        ShowDgv(rsDto);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private List<MaterialDTO> Search(List<MaterialDTO> productDTOs, string textSearch)
    {
      try
      {
        if (productDTOs != null)
        {
          if (!string.IsNullOrWhiteSpace(textSearch))
          {
            string searchLower = TextHelper.RemoveDiacritics(textSearch).ToLower();
            return productDTOs.Where(e =>
                TextHelper.RemoveDiacritics((e.Type ?? "").ToLower()).Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Grade ?? "").ToLower()).Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Code ?? "").ToLower()).Contains(searchLower)
            )
            .ToList();
          }
          else
          {
            return productDTOs;
          }
        }
        else
        {
          return new List<MaterialDTO>();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void ShowDgv(List<MaterialDTO> productDTOs)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDgv(productDTOs);
        }));
        return;
      }

      try
      {
        dgvProductMaterial.DataSource = productDTOs;
        //dgvProductMaterial.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //dgvProductMaterial.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //dgvProductMaterial.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //dgvProductMaterial.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //dgvProductMaterial.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //dgvProductMaterial.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //dgvProductMaterial.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //dgvProductMaterial.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //dgvProductMaterial.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void btnSyncImage_Click(object sender, EventArgs e)
    {
      try
      {
        ShowStatusSyncData(true);
        ShowStatusSyncData(false);
      }
      catch (Exception)
      {
        //TODO
      }
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

      btnSyncImage.Text = sync ? "Đang đồng bộ" : "Đồng bộ";
    }
    

  }
}
