using Common;
using LTP.Truck.Controls;
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
using static LTP.Truck.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmWaiting : Form
  {
    public FrmWaiting()
    {
      InitializeComponent();
      this.Load += FrmWaiting_Load;
    }

    #region Instance
    private static FrmWaiting _Instance = null;
    public static FrmWaiting Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmWaiting();
        return _Instance;
      }
    }
    #endregion

    private void btnMenu_Click(object sender, EventArgs e)
    {
      Program.CloseApp();
    }

    private void FrmWaiting_Load(object? sender, EventArgs e)
    {
      ucPanelLogin1.OnSendLogin += UcPanelLogin1_OnSendLogin;
    }

    private void UcPanelLogin1_OnSendLogin(object? sender, EventArgs e)
    {
      if (ucPanelLogin1.Account=="admin" && ucPanelLogin1.Password == "admin")
      {
        FrmMain.Instance.ChangePage(EnumScreen.Operation);
        AppCore.Ins._employeeCurrent = AppCore.Ins._employees?.Where(x => x.Account == "admin").FirstOrDefault();
      }  
      else
      {
        using var popupMsg = new PopupConfirm("Tài khoản hoặc mật khẩu sai. Vui lòng thử lại !",
          EnumTypeMsg.MessageManualClose, EnumImageMsg.Information);
        popupMsg.ShowDialog(this);
      }  
    }
  }
}
