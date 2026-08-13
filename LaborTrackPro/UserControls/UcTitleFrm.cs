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

namespace LaborTrackPro.UserControls
{
  public partial class UcTitleFrm : UserControl
  {
    public delegate void SendSearchUCClick(string txtSearch);
    public event SendSearchUCClick OnSendSearchUCClick;

    public delegate void SendReviewUCClick();
    public event SendReviewUCClick OnSendReviewUCClick;

    public delegate void SendClosePopup();
    public event SendClosePopup OnSendClosePopup;

    private eTypeButton _eTypeButton { get;set; }
    public UcTitleFrm()
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

    private void btnSearch_Click(object sender, EventArgs e)
    {
      switch (_eTypeButton)
      {
        case eTypeButton.ReviewDelivery:
          OnSendReviewUCClick?.Invoke();
          break;
        case eTypeButton.Close:
          OnSendClosePopup?.Invoke();
          break;
        default:
          break;
      }
    }

    public void FunctionButton(eTypeButton eTypeButton)
    {
      _eTypeButton = eTypeButton;
      switch (_eTypeButton)
      {
        case eTypeButton.None:
          btn.Visible = false;
          break;
        case eTypeButton.Search:
          btn.Visible = true;
          btn.Text = "Tìm kiếm";
          btn.Width = 200;
          break;
        case eTypeButton.ReviewDelivery:
          btn.Visible = true;
          btn.Text = "Xem biên bản giao nhận";
          btn.Width = 400;
          break;
        case eTypeButton.ScanRfid:
          btn.Visible = false;
          break;
        case eTypeButton.Close:
          btn.Visible = true;
          btn.Text = "Thoát";
          btn.Width = 200;
          break;
        default:
          break;
      }
    }

    public Bitmap Image
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
  }

  public enum eTypeButton
  {
    None,
    Search,
    ReviewDelivery,
    ScanRfid,
    Close,
  }
}
