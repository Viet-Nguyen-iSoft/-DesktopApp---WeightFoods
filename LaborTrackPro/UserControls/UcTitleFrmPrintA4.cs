using HelperManager;
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
using static LaborTrackPro.UserControls.UcTitleFrm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LaborTrackPro.UserControls
{
  public partial class UcTitleFrmPrintA4 : UserControl
  {
    public delegate void SendPrinterUCClick();
    public event SendPrinterUCClick OnSendPrinterUCClick;

    public delegate void SendPermitOverWeightClick();
    public event SendPermitOverWeightClick OnSendPermitOverWeightClick;

    public UcTitleFrmPrintA4()
    {
      InitializeComponent();
      CustomUI();
    }
    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel3;
      elipseControl0.CornerRadius = 20;
    }

    private void btn_Click(object sender, EventArgs e)
    {
      OnSendPrinterUCClick?.Invoke();
    }

    public void SetStatus(StatusPrintA4 status)
    {
      if (status == StatusPrintA4.Idle)
      {
        lbStatus.Text = "Máy in sẵn sàng";
        lbStatus.ForeColor = Color.DarkGreen;
      }
      else if (status == StatusPrintA4.Printing)
      {
        lbStatus.Text = "Máy in đang in";
        lbStatus.ForeColor = Color.DarkGreen;
      }
      else if (status == StatusPrintA4.Error)
      {
        lbStatus.Text = "Máy in đang lỗi !";
        lbStatus.ForeColor = Color.Red;
      }
      else if (status == StatusPrintA4.NotFound)
      {
        lbStatus.Text = "Máy in không tìm thấy !";
        lbStatus.ForeColor = Color.Red;
      }
      else if (status == StatusPrintA4.Offline)
      {
        lbStatus.Text = "Máy in mất kết nối !";
        lbStatus.ForeColor = Color.Red;
      }
      else
      {
        lbStatus.Text = "Máy in lỗi không xác định !";
        lbStatus.ForeColor = Color.Red;
      }
    }

    public void VisibleButton(bool visible)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          VisibleButton(visible);
        }));
        return;
      }


      btn.Enabled = visible;
    }

    public void SetEnabelBtn(bool enable)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetEnabelBtn(enable);
        }));
        return;
      }


      if (enable)
      {
        btn.Enabled = true;
        btn.BackColor = Color.FromArgb(49, 68, 108);
      }
      else
      {
        btn.Enabled = false;
        btn.BackColor = Color.Gray;
      }
    }

    public void SetEnabelBtnPermitOverWeight(bool enable)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetEnabelBtnPermitOverWeight(enable);
        }));
        return;
      }


      btnPermitOverWeight.Visible = enable;
    }

    private void btnPermitOverWeight_Click(object sender, EventArgs e)
    {
      OnSendPermitOverWeightClick?.Invoke();
    }
  }
}
