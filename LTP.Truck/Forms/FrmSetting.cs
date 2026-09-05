using Common.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTP.Truck.Forms
{
  public partial class FrmSetting : Form
  {
    private readonly Color _primaryColor = Color.FromArgb(51, 108, 181);
    private Panel? _connectionEditor;
    private TableLayoutPanel? _settingFields;

    public FrmSetting()
    {
      InitializeComponent();
    }
    #region Instance
    private static FrmSetting _Instance = null;
    public static FrmSetting Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSetting();
        return _Instance;
      }
    }
    #endregion


    private void btnAddCommWeight_Click(object sender, EventArgs e)
    {
      PopupChooseComm popupChooseComm = new PopupChooseComm();
      popupChooseComm.OnSendConfirm += PopupChooseComm_OnSendConfirm;
      popupChooseComm.ShowDialog();
    }

    private void PopupChooseComm_OnSendConfirm(object? sender, Common.EnumData.EnumCommunication e)
    {
      
    }
  }
}
