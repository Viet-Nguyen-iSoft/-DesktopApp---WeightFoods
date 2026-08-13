using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.UserControls;
using System.Threading.Tasks;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;
using static LaborTrackPro.Helper.DTO;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmListMRs_BTP_Defect : Form
  {
    public FrmListMRs_BTP_Defect()
    {
      InitializeComponent();
      CustomUI();
    }

    #region Instance
    private static FrmListMRs_BTP_Defect _Instance = null;
    public static FrmListMRs_BTP_Defect Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmListMRs_BTP_Defect();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = flowLayoutPanel;
      elipseControl1.CornerRadius = 20;

      ucTitleFrm.FunctionButton(eTypeButton.None);
      ucTitleFrm.Image = Properties.Resources.icon_function;
    }

    public void LoadItemMaterial()
    {
      var material = AppCore.Ins._dataManager.DataLogPrintLabel?.Material;
      if (material == null)
      {
        new FrmInformation().ShowMessage("Không tìm thấy nguyên liệu !", eImage.Warning);
        return;
      }

      List<Material>? listDefect = new List<Material>();
      var rsExportImport = AppCore.Ins._dataManager.EnumExportImport;
      if (rsExportImport == EnumExportImport.Import)
      {
        listDefect = AppCore.Ins._materials?.Where(x => x.MaterialType == (int)EnumMaterialType.MRsDefect && x.Code.Contains(material?.Code ?? string.Empty)).ToList();
      }

      ShowItemMaterials(material, listDefect);
    }

    public void ShowItemMaterials(Material material, List<Material>? materialDefects)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowItemMaterials(material, materialDefects);
        }));
        return;
      }

      this.ucTitleFrm.Title = EnumHelper.GetEnumDescription((EnumMaterialType)material.MaterialType) + " và các phế phẩm";
      this.flowLayoutPanel.Controls.Clear();

      int margin = 10;
      Size sizePanel = new Size(flowLayoutPanel.Width, flowLayoutPanel.Height);
      int w = (int)(sizePanel.Width / 3 - (margin * 2) * 1.35);
      int h = sizePanel.Height / 2 - (margin * 3);
      sizePanel = new Size(w, h);

      if (material != null)
      {
        string name = $"{material?.Name ?? ""} {material?.Grade ?? ""}";
        var ucSrc = new UcProductItem
        {
          ItemTitleName = name,
          ItemTitleCode = material?.Code ?? "",
          TagData = material,
          Margin = new Padding(margin),
          Defect = false,
        };
        ucSrc.SizeCus = sizePanel;
        ucSrc.OnSendClickItem += Uc_OnSendClickItem;
        flowLayoutPanel.Controls.Add(ucSrc);
      }

      if (materialDefects?.Count()>0)
      {
        materialDefects = materialDefects.OrderBy(x => x.Code).ToList();
        foreach (var itemMaterial in materialDefects)
        {
          string name = $"{itemMaterial?.Name ?? ""} {itemMaterial?.Grade ?? ""}";
          var ucSrc = new UcProductItem
          {
            ItemTitleName = name,
            ItemTitleCode = itemMaterial?.Code ?? "",
            TagData = itemMaterial,
            Margin = new Padding(margin),
            Defect = true,
          };
          ucSrc.SizeCus = sizePanel;
          ucSrc.OnSendClickItem += Uc_OnSendClickItem;
          flowLayoutPanel.Controls.Add(ucSrc);
        }
      }
    }


    private async void Uc_OnSendClickItem(object? sender, object? e)
    {
      var rs = e as Material;
      if (rs!=null)
      {
        EnumMaterialType enumMaterialType = (EnumMaterialType)(rs?.MaterialType ?? 0);
        AppCore.Ins._dataManager.DataLogPrintLabel.EnumMaterialType = enumMaterialType;

        if (enumMaterialType == EnumMaterialType.MRsDefect)
        {
          AppCore.Ins._dataManager.DataLogPrintLabel.MaterialDefect = rs;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OperationPrint);
        }
        else
        {
          AppCore.Ins._dataManager.DataLogPrintLabel.Material = rs;
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OperationPrint);
        }
      }   
    }

  }
}
