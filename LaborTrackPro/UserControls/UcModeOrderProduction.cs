using iSoft.Database.Models;
using LaborTrackPro.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcModeOrderProduction : UserControl
  {
    public delegate void SendUcClick(EnumProductionOrderType eModeOrderProduction);
    public event SendUcClick OnSendUcClick;
    public UcModeOrderProduction()
    {
      InitializeComponent();
      CustomUI();
    }
    private EnumProductionOrderType _eModeOrderProduction = new EnumProductionOrderType();
    public Bitmap Icon
    {
      set
      {
        picIcon.Image = value;
      }
    }
    public string Title
    {
      set
      {
        lbTitle.Text = value;
      }
    }
    public EnumProductionOrderType Mode
    {
      set
      {
        this._eModeOrderProduction = value;
      }
    }
    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel;
      elipseControl0.CornerRadius = 20;

      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = this;
      elipseControl1.CornerRadius = 20;
    }
    public void SetHighlight(bool isHighlight = false)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetHighlight(isHighlight);
        }));
        return;
      }

      tlpChoose.BackColor = isHighlight ? Color.FromArgb(57, 193, 255) : Color.FromArgb(159, 159, 159);
    }
    private void picIcon_Click(object sender, EventArgs e)
    {
      this.OnSendUcClick?.Invoke(this._eModeOrderProduction);
    }

    private void lbTitle_Click(object sender, EventArgs e)
    {
      this.OnSendUcClick?.Invoke(this._eModeOrderProduction);
    }

    private void tableLayoutPanel_Click(object sender, EventArgs e)
    {
      this.OnSendUcClick?.Invoke(this._eModeOrderProduction);
    }
  }
}
