using Common;
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

namespace LTP.Truck.Forms
{
  public partial class PopupInputReason : Form
  {
    public string Reason { get; private set; } = string.Empty;

    public PopupInputReason()
    {
      InitializeComponent();
      StartPosition = FormStartPosition.CenterParent;
      Shown += (_, _) => txtReason.Focus();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      var reason = txtReason.Text.Trim();
      if (string.IsNullOrWhiteSpace(reason))
      {
        using var popupMsg = new PopupConfirm("Vui lòng nhập lý do xóa dữ liệu !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupMsg.ShowDialog();
        txtReason.Focus();
        return;
      }

      Reason = reason;
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}
