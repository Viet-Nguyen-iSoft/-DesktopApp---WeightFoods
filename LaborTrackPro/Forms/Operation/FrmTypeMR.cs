using LaborTrackPro.Controls;
using LaborTrackPro.UserControls;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmTypeMR : Form
  {
    public FrmTypeMR()
    {
      InitializeComponent();

      CustomUI();

      this.itemMaterialRaw.OnSendItemClicked += ItemMaterialRaw_OnSendItemClicked;
      this.itemMaterial.OnSendItemClicked += ItemMaterialRaw_OnSendItemClicked;
      this.itemSemiFgs.OnSendItemClicked += ItemMaterialRaw_OnSendItemClicked;
      this.itemFGs.OnSendItemClicked += ItemMaterialRaw_OnSendItemClicked;
    }

    #region Instance
    private static FrmTypeMR _Instance = null;
    public static FrmTypeMR Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmTypeMR();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      this.ucTitleFrm.FunctionButton(eTypeButton.None);
      this.ucTitleFrm.Title = "Chọn nhóm nguyên liệu - vật tư";
      this.ucTitleFrm.Image = Properties.Resources.icon_type;

      this.itemMaterialRaw.Title = "NGUYÊN LIỆU SỐNG";
      this.itemMaterial.Title = "VẬT TƯ";
      this.itemSemiFgs.Title = "BÁN THÀNH PHẨM";
      this.itemFGs.Title = "THÀNH PHẨM";

      this.itemMaterialRaw.Key = ((int)EnumKey.MaterialRaw).ToString();
      this.itemMaterial.Key = ((int)EnumKey.Material).ToString();
      this.itemSemiFgs.Key = ((int)EnumKey.SemiFGs).ToString();
      this.itemFGs.Key = ((int)EnumKey.FGs).ToString();

      this.itemMaterialRaw.Image = Properties.Resources.icon_material_raw_color;
      this.itemMaterial.Image = Properties.Resources.icon_material_color;
      this.itemSemiFgs.Image = Properties.Resources.icon_ban_thanh_pham;
      this.itemFGs.Image = Properties.Resources.icon_Fgs_color;
    }

    private async void ItemMaterialRaw_OnSendItemClicked(object? sender, string e)
    {
      if (e == ((int)EnumKey.MaterialRaw).ToString())
      {
        AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType = EnumMaterialType.RawMaterial;
      }
      else if (e == ((int)EnumKey.Material).ToString())
      {
        AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType = EnumMaterialType.Material;
      }
      else if (e == ((int)EnumKey.SemiFGs).ToString())
      {
        AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType = EnumMaterialType.SemiFinishedGoods;
      }
      else if (e == ((int)EnumKey.FGs).ToString())
      {
        AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType = EnumMaterialType.FinshGoods;
      }

      AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.DetailMRs;
      await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpDetailMRs);
    }
  }


  public enum EnumKey
  {
    None,
    MaterialRaw,
    Material,
    SemiFGs,
    FGs,
  }
}
