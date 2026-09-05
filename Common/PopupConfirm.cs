using Common.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.EnumData;

namespace Common
{
  public partial class PopupConfirm : Form
  {
    public event EventHandler<EnumResponsible>? OnSendConfirm;
    public PopupConfirm()
    {
      InitializeComponent();
      CustomUI();
    }

    private void CustomUI()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 20;
      elipseControl01.TargetControl = this;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 20;
      elipseControl02.TargetControl = tableLayoutPanel1;

      ElipseControl elipseControl03 = new ElipseControl();
      elipseControl03.CornerRadius = 20;
      elipseControl03.TargetControl = tableLayoutPanel2;
    }

    public PopupConfirm(string title, EnumTypeMsg enumTypeMsg, EnumImageMsg eImage) : this()
    {
      this.lbInformation.Text = title;

      switch (enumTypeMsg)
      {
        case EnumTypeMsg.Confirm:
          this.btnConfirm.Visible = true;
          this.btnClose.Visible = true;
          break;
        case EnumTypeMsg.MessageManualClose:
          this.btnConfirm.Visible = false;
          this.btnClose.Visible = true;
          break;
        case EnumTypeMsg.MessageAutoClose:
          this.btnConfirm.Visible = false;
          this.btnClose.Visible = false;
          this.tableLayoutPanel3.Visible = false;
          break;
      }
      
      switch (eImage)
      {
        case EnumImageMsg.Confirm:
          this.picIcon.Image = Properties.Resources.Confirm;
          break;
        case EnumImageMsg.Question:
          this.picIcon.Image = Properties.Resources.Question;
          break;
        case EnumImageMsg.Warning:
          this.picIcon.Image = Properties.Resources.Warning;
          break;
        case EnumImageMsg.Information:
          this.picIcon.Image = Properties.Resources.Info;
          break;
      }
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      OnSendConfirm?.Invoke(sender, EnumResponsible.Confirm);
      this.Close();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      OnSendConfirm?.Invoke(sender, EnumResponsible.Cancel);
      this.Close();
    }
  }
}
