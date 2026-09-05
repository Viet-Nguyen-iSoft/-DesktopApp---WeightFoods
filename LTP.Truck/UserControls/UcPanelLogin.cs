using LTP.Truck.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTP.Truck.UserControls
{
  public partial class UcPanelLogin : UserControl
  {
    public event EventHandler? OnSendLogin;
    public UcPanelLogin()
    {
      InitializeComponent();
      CustomUI();
    }

    private void CustomUI()
    {
      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = this;
      elipseControl.CornerRadius = 50;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = tableLayoutPanel1;
      elipseControl01.CornerRadius = 50;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
      OnSendLogin?.Invoke(this, e);
    }
  }
}
