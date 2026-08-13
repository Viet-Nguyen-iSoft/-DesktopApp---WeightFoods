using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class FrmChangeTare : Form
  {
    public event EventHandler<Material>? OnSendOKClicked;

    public FrmChangeTare()
    {
      InitializeComponent();
      CustomUI();
      InitScrollButton();
      this.FormClosed += FrmChangeTare_FormClosed;
      this.Shown += FrmChangeTare_Shown;
      AppCore.Ins.OnSendChangeTare += Ins_OnSendChangeTare;
      this.FormClosed += FrmChangeTare_FormClosed1;
    }

    private void FrmChangeTare_FormClosed1(object? sender, FormClosedEventArgs e)
    {
      AppCore.Ins.OnSendChangeTare -= Ins_OnSendChangeTare;
    }

    private List<Material> _materials { get;set; }
    public FrmChangeTare(List<Material> materials) :this()
    {
      _materials = materials;
    }

    private void CustomUI()
    {
      this.TopMost = AppCore.Ins._isTopMost;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 20;
      elipseControl01.TargetControl = flowLayoutPanel;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 20;
      elipseControl02.TargetControl = flowLayoutPanel;

      ucTitleFrm.FunctionButton(eTypeButton.Close);
      ucTitleFrm.OnSendClosePopup += UcTitleFrm_OnSendClosePopup;
      ucTitleFrm.Title = "Chọn loại Tare";
      ucTitleFrm.Image = Properties.Resources.icon_function;
    }

    private void UcTitleFrm_OnSendClosePopup()
    {
      this.Close();
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
      btnUp.Click += btnUp_Click;

      // DOWN
      btnDown.MouseDown += BtnDown_MouseDown;
      btnDown.MouseUp += BtnScroll_MouseUp;
      btnDown.MouseLeave += BtnScroll_MouseUp;
      btnDown.Click += btnDown_Click;

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

    private void btnUp_Click(object? sender, EventArgs e)
    {
      int currentY = Math.Abs(flowLayoutPanel.AutoScrollPosition.Y);

      int newY = Math.Max(0, currentY - flowLayoutPanel.Height);

      flowLayoutPanel.AutoScrollPosition = new Point(0, newY);
    }

    private void btnDown_Click(object? sender, EventArgs e)
    {
      int currentY = Math.Abs(flowLayoutPanel.AutoScrollPosition.Y);
      flowLayoutPanel.AutoScrollPosition = new Point(0, currentY + flowLayoutPanel.Height);
    }

    #endregion

    private void FrmChangeTare_Shown(object? sender, EventArgs e)
    {
      ShowItem(_materials);
    }

    private void Ins_OnSendChangeTare(object? sender, List<Material> e)
    {
      _materials = e;
      ShowItem(_materials);
    }

    public void ShowItem(List<Material> materials)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowItem(materials);
        }));
        return;
      }

      flowLayoutPanel.Controls.Clear();
      if (materials?.Count()>0)
      {
        int _margin = 3;
        double he_so = materials?.Count > 6 ? 2.1 : 1.35;
        Size sizePanel = new Size(flowLayoutPanel.Width, flowLayoutPanel.Height);
        int w = (int)(sizePanel.Width / 3 - (_margin * 3) * he_so);
        int h = sizePanel.Height / 2 - (_margin * 7);
        sizePanel = new Size(w, h);

        foreach (var g in materials)
        {
          var uc = new UcProductItem
          {
            ItemTitleName = $"{g?.Name} {g?.Grade}",
            ItemTitleCode = $"{g?.Code}",
            VisibleCode = true,
            TagData = g,
            Margin = new Padding(_margin),
            Defect = false,
          };

          uc.SizeCus = sizePanel;
          uc.OnSendClickItem += Uc_OnSendClickItem;
          flowLayoutPanel.Controls.Add(uc);
        }
      }
    }

    private void Uc_OnSendClickItem(object? sender, object? e)
    {
      var rs = e as Material;
      if (rs != null)
      {
        OnSendOKClicked?.Invoke(this, rs);
        this.Close();
      }
      else
      {
        new FrmInformation().ShowMessage("Không tìm thấy Tare !", eImage.Warning);
        return;
      }
    }

    private void FrmChangeTare_FormClosed(object? sender, FormClosedEventArgs e)
    {
      this.Dispose();
    }

  }
}
