using HelperManager;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.UserControls;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;
using static LaborTrackPro.Helper.DTO;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmDetailMRs : Form
  {
    public FrmDetailMRs()
    {
      InitializeComponent();
      CustomUI();
    }

    #region Instance
    private static FrmDetailMRs _Instance = null;
    public static FrmDetailMRs Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmDetailMRs();
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

      InitScrollButton();
    }

    #region Scroll
    private System.Windows.Forms.Timer? _scrollTimer;
    private int _scrollDirection = 0; // -1 = Up, 1 = Down
    private void InitScrollButton()
    {
      _scrollTimer = new System.Windows.Forms.Timer();
      _scrollTimer.Interval = 30; // tốc độ cuộn
      _scrollTimer.Tick += ScrollTimer_Tick;

      // UP
      btnUp.MouseDown += BtnUp_MouseDown;
      btnUp.MouseUp += BtnScroll_MouseUp;
      btnUp.MouseLeave += BtnScroll_MouseUp;

      // DOWN
      btnDown.MouseDown += BtnDown_MouseDown;
      btnDown.MouseUp += BtnScroll_MouseUp;
      btnDown.MouseLeave += BtnScroll_MouseUp;
    }

    private void ScrollTimer_Tick(object? sender, EventArgs e)
    {
      int currentY = Math.Abs(flowLayoutPanel.AutoScrollPosition.Y);

      int scrollStep = 20;

      int newY = currentY + (_scrollDirection * scrollStep);

      if (newY < 0)
        newY = 0;

      flowLayoutPanel.AutoScrollPosition = new Point(0, newY);
    }

    private void BtnUp_MouseDown(object? sender, MouseEventArgs e)
    {
      _scrollDirection = -1;
      _scrollTimer?.Start();
    }

    private void BtnDown_MouseDown(object? sender, MouseEventArgs e)
    {
      _scrollDirection = 1;
      _scrollTimer?.Start();
    }

    private void BtnScroll_MouseUp(object? sender, EventArgs e)
    {
      _scrollTimer?.Stop();
    }

    #endregion

    public EnumGroupData _enumGroupData { get; set; }
    public EnumMaterialType _eMaterialType { get; set; }
    public async Task LoadItemMaterial()
    {
      EnumInternalExternalStatus enumInternalExternal = AppCore.Ins._dataManager?.EnumInternalExternalStatus ?? EnumInternalExternalStatus.None;
      EnumExportImport eExportImport = AppCore.Ins._dataManager?.EnumExportImport ?? EnumExportImport.None;
      _eMaterialType = (EnumMaterialType)(AppCore.Ins._dataManager?.DataLogPrintLabel?.EnumMaterialType ?? EnumMaterialType.None);

      if (_eMaterialType == EnumMaterialType.MRsDefect)
      {
        _eMaterialType = (EnumMaterialType)(AppCore.Ins._dataManager?.DataLogPrintLabel.Material?.MaterialType ?? 0);
      }

      var po = await AppCore.Ins.GetPOByIdAsync(AppCore.Ins._dataManager?.ProductionOrder?.Id);
      AppCore.Ins._dataManager.ProductionOrder = po;

      //Lấy danh sách nguyên liệu vật tư
      if (enumInternalExternal == EnumInternalExternalStatus.Internal)
      {
        var listMR = po?.MaterialSettings?
                    .Where(x => x.InternalExternalStatus == enumInternalExternal &&
                                x.Material?.MaterialType == (int)_eMaterialType &&
                                x.DeletedFlag == false
                                )?
                    .Select(x => x.Material)
                    .ToList();
        ShowGroupLevel1(listMR);
      }
      else if (enumInternalExternal == EnumInternalExternalStatus.External)
      {
        var listMR = po?.MaterialSettings?
                    .Where(x => x.InternalExternalStatus == enumInternalExternal &&
                                x.ImportExportStatus == eExportImport &&
                                x.Material?.MaterialType == (int)_eMaterialType &&
                                x.DeletedFlag == false
                                )?
                    .Select(x => x.Material)
                    .ToList();
        ShowGroupLevel1(listMR);
      }
    }

    public void ShowGroupLevel1(List<Material?>? materials)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowGroupLevel1(materials);
        }));
        return;
      }

      _enumGroupData = EnumGroupData.Level1;
      SetTitle(_eMaterialType);

      flowLayoutPanel.Controls.Clear();
      if (materials?.Count() > 0)
      {
        List<GroupMaterialDTO> result = materials
                                        .GroupBy(x => x?.MaterialGroup?.Name ?? "Chưa phân nhóm")
                                        .Select(group => new GroupMaterialDTO
                                        {
                                          GroupStr = group.Key,
                                          Materials = group?.ToList()?? new List<Material>()
                                        })
                                        .ToList();

        if (result!=null && result?.Count()>0)
        {
          int _margin = 3;
          double he_so = result?.Count > 6 ? 2.1 : 1.35;
          Size sizePanel = new Size(flowLayoutPanel.Width, flowLayoutPanel.Height);
          int w = (int)(sizePanel.Width / 3 - (_margin * 3) * he_so);
          int h = sizePanel.Height / 2 - (_margin * 7);
          sizePanel = new Size(w, h);

          foreach (var group in result)
          {
            var uc = new UcProductItem
            {
              ItemTitleName = group?.GroupStr??string.Empty,
              ItemTitleCode = "",
              TagData = group,
              VisibleCode = false,
              Margin = new Padding(_margin),
              Defect = false,
            };
            uc.SizeCus = sizePanel;
            uc.FontSize(40);
            uc.OnSendClickItem += Uc_OnSendClickItemGroupLevel1;
            flowLayoutPanel.Controls.Add(uc);
          }

          if (result?.Count() > 6)
          {
            Panel pnlSpace = new Panel();
            pnlSpace.Height = 20;
            pnlSpace.Width = flowLayoutPanel.Width;
            flowLayoutPanel.Controls.Add(pnlSpace);
          }
        }  
      }
    }

    private void Uc_OnSendClickItemGroupLevel1(object? sender, object? e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          Uc_OnSendClickItemGroupLevel1(sender, e);
        }));
        return;
      }

      _enumGroupData = EnumGroupData.Level2;
      SetTitle(_eMaterialType);

      flowLayoutPanel.Controls.Clear();
      var rs = e as GroupMaterialDTO;
      if (rs != null)
      {
        List<Material> materials = rs?.Materials??new List<Material>();
        if (materials?.Count()>0)
        {
          List<GroupMaterialDTO> groups = materials
                                        .GroupBy(x => x?.MaterialGroup?.TypeName ?? x?.MaterialGroup?.Name ?? "Chưa phân nhóm")
                                        .Select(group => new GroupMaterialDTO
                                        {
                                          GroupStr = group.Key,
                                          Materials = group?.ToList() ?? new List<Material>()
                                        })
                                        .ToList();

          if (groups != null && groups?.Count() > 0)
          {
            int _margin = 3;
            double he_so = groups?.Count > 6 ? 2.1 : 1.35;
            Size sizePanel = new Size(flowLayoutPanel.Width, flowLayoutPanel.Height);
            int w = (int)(sizePanel.Width / 3 - (_margin * 3) * he_so);
            int h = sizePanel.Height / 2 - (_margin * 7);
            sizePanel = new Size(w, h);

            foreach (var group in groups)
            {
              var uc = new UcProductItem
              {
                ItemTitleName = group?.GroupStr ?? string.Empty,
                ItemTitleCode = "",
                TagData = group,
                VisibleCode = false,
                Margin = new Padding(_margin),
                Defect = false,
              };
              uc.SizeCus = sizePanel;
              uc.FontSize(40);
              uc.OnSendClickItem += Uc_OnSendClickItemGroupLevel2;
              flowLayoutPanel.Controls.Add(uc);
            }

            if (groups?.Count() > 6)
            {
              Panel pnlSpace = new Panel();
              pnlSpace.Height = 20;
              pnlSpace.Width = flowLayoutPanel.Width;
              flowLayoutPanel.Controls.Add(pnlSpace);
            }
          }
        }  
      }
      else
      {
        new FrmInformation().ShowMessage("Không tìm thấy nguyên liệu !", eImage.Warning);
        return;
      }
    }

    private void Uc_OnSendClickItemGroupLevel2(object? sender, object? e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          Uc_OnSendClickItemGroupLevel2(sender, e);
        }));
        return;
      }

      _enumGroupData = EnumGroupData.Detail;
      SetTitle(_eMaterialType);

      flowLayoutPanel.Controls.Clear();

      var rs = e as GroupMaterialDTO;
      if (rs != null)
      {
        List<Material> materials = rs?.Materials ?? new List<Material>();
        if (materials?.Count() > 0)
        {
          materials = materials.OrderBy(x => x.Code).ToList();

          int _margin = 3;
          double he_so = materials?.Count > 6 ? 2.1 : 1.35;
          Size sizePanel = new Size(flowLayoutPanel.Width, flowLayoutPanel.Height);
          int w = (int)(sizePanel.Width / 3 - (_margin * 3) * he_so);
          int h = sizePanel.Height / 2 - (_margin * 7);
          sizePanel = new Size(w, h);

          foreach (var g in materials)
          {
            var material = g;
            string name = $"{material?.Name ?? ""} {material?.Grade ?? ""}";
            var uc = new UcProductItem
            {
              ItemTitleName = name,
              ItemTitleCode = material?.Code ?? "",
              TagData = material,
              Margin = new Padding(_margin),
              Defect = false,
            };
            uc.SizeCus = sizePanel;
            uc.OnSendClickItem += Uc_OnSendClickItem;
            flowLayoutPanel.Controls.Add(uc);
          }

          if (materials?.Count() > 6)
          {
            Panel pnlSpace = new Panel();
            pnlSpace.Height = 20;
            pnlSpace.Width = flowLayoutPanel.Width;
            flowLayoutPanel.Controls.Add(pnlSpace);
          }
        }
      }
      else
      {
        new FrmInformation().ShowMessage("Không tìm thấy nguyên liệu !", eImage.Warning);
        return;
      }
    }


    public void ShowGroupLevel2(List<Material?>? materials)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowGroupLevel2(materials);
        }));
        return;
      }

      flowLayoutPanel.Controls.Clear();
      if (materials?.Count() > 0)
      {
        List<GroupMaterialDTO> result = materials
                                        .GroupBy(x => x?.MaterialGroup?.Name ?? "Chưa phân nhóm")
                                        .Select(group => new GroupMaterialDTO
                                        {
                                          GroupStr = group.Key,
                                          Materials = group?.ToList() ?? new List<Material>()
                                        })
                                        .ToList();

        if (result != null && result?.Count() > 0)
        {
          int _margin = 3;
          double he_so = result?.Count > 6 ? 2.1 : 1.35;
          Size sizePanel = new Size(flowLayoutPanel.Width, flowLayoutPanel.Height);
          int w = (int)(sizePanel.Width / 3 - (_margin * 3) * he_so);
          int h = sizePanel.Height / 2 - (_margin * 7);
          sizePanel = new Size(w, h);

          foreach (var group in result)
          {
            var uc = new UcProductItem
            {
              ItemTitleName = group?.GroupStr ?? string.Empty,
              ItemTitleCode = "",
              TagData = group,
              VisibleCode = false,
              Margin = new Padding(_margin),
              Defect = false,
            };
            uc.SizeCus = sizePanel;
            uc.FontSize(40);
            uc.OnSendClickItem += Uc_OnSendClickItemGroupLevel2;
            flowLayoutPanel.Controls.Add(uc);
          }

          if (result?.Count() > 6)
          {
            Panel pnlSpace = new Panel();
            pnlSpace.Height = 20;
            pnlSpace.Width = flowLayoutPanel.Width;
            flowLayoutPanel.Controls.Add(pnlSpace);
          }
        }
      }
    }

    
    private async void Uc_OnSendClickItem(object? sender, object? e)
    {
      var rs = e as Material;
      if (rs != null)
      {
        AppCore.Ins._dataManager.DataLogPrintLabel.Material = rs;

        if (AppCore.Ins._dataManager.EnumInternalExternalStatus == EnumInternalExternalStatus.Internal)
        {
          if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Export)
          {
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.OperationPrint);
          }
          else if (AppCore.Ins._dataManager.EnumExportImport == EnumExportImport.Import)
          {
            await FrmPageOperation.Instance.ChangePage(AppModulSupport.OpRMs_BTP_Defect);
          }
        }
        else
        {
          await FrmPageOperation.Instance.ChangePage(AppModulSupport.OperationPrint);
        }  
      }
      else
      {
        new FrmInformation().ShowMessage("Không tìm thấy nguyên liệu !", eImage.Warning);
        return;
      }
    }

    public void SetTitle(EnumMaterialType? eMaterialTypeData)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetTitle(eMaterialTypeData);
        }));
        return;
      }

      switch (eMaterialTypeData)
      {
        case EnumMaterialType.Material:
          switch (_enumGroupData)
          {
            case EnumGroupData.Level1:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 1 Vật tư";
              break;
            case EnumGroupData.Level2:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 2 Vật tư";
              break;
            case EnumGroupData.Detail:
              this.ucTitleFrm.Title = "Chọn Vật tư";
              break;
            default:
              this.ucTitleFrm.Title = "";
              break;
          }
          break;
        case EnumMaterialType.RawMaterial:
          switch (_enumGroupData)
          {
            case EnumGroupData.Level1:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 1 Nguyên liệu sống";
              break;
            case EnumGroupData.Level2:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 2 Nguyên liệu sống";
              break;
            case EnumGroupData.Detail:
              this.ucTitleFrm.Title = "Chọn Nguyên liệu sống";
              break;
            default:
              this.ucTitleFrm.Title = "";
              break;
          }
          break;
        case EnumMaterialType.FinshGoods:
          switch (_enumGroupData)
          {
            case EnumGroupData.Level1:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 1 Thành phẩm";
              break;
            case EnumGroupData.Level2:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 2 Thành phẩm";
              break;
            case EnumGroupData.Detail:
              this.ucTitleFrm.Title = "Chọn Thành phẩm";
              break;
            default:
              this.ucTitleFrm.Title = "";
              break;
          }
          break;
        case EnumMaterialType.SemiFinishedGoods:
          switch (_enumGroupData)
          {
            case EnumGroupData.Level1:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 1 Bán thành phẩm";
              break;
            case EnumGroupData.Level2:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 2 Bán thành phẩm";
              break;
            case EnumGroupData.Detail:
              this.ucTitleFrm.Title = "Chọn Bán thành phẩm";
              break;
            default:
              this.ucTitleFrm.Title = "";
              break;
          }
          break;
        case EnumMaterialType.MRsDefect:
          switch (_enumGroupData)
          {
            case EnumGroupData.Level1:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 1 Phế phẩm";
              break;
            case EnumGroupData.Level2:
              this.ucTitleFrm.Title = "Chọn nhóm cấp 2 Phế phẩm";
              break;
            case EnumGroupData.Detail:
              this.ucTitleFrm.Title = "Chọn Phế phẩm";
              break;
            default:
              this.ucTitleFrm.Title = "";
              break;
          }
          break;
        default:
          this.ucTitleFrm.Title = "N/A";
          break;
      }
    }


    private void btnUp_Click(object sender, EventArgs e)
    {
      int currentY = Math.Abs(flowLayoutPanel.AutoScrollPosition.Y);

      int newY = Math.Max(0, currentY - flowLayoutPanel.Height);

      flowLayoutPanel.AutoScrollPosition = new Point(0, newY);
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      int currentY = Math.Abs(flowLayoutPanel.AutoScrollPosition.Y);
      flowLayoutPanel.AutoScrollPosition = new Point(0, currentY + flowLayoutPanel.Height);
    }
  }
}
