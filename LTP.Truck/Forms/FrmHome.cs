using iSoft.Database.DTO;
using iSoft.Database.Models;
using LTP.Truck.Controls;
using LTP.Truck.Custom;
using LTP.Truck.Popup;
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
  public partial class FrmHome : Form
  {
    public FrmHome()
    {
      InitializeComponent();
      CustomUI();
    }

    #region Instance
    private static FrmHome _Instance = null;
    public static FrmHome Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmHome();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ucItemWeight01.Title = "KL cân lần 1 (Kg)";
      ucItemWeight02.Title = "KL cân lần 2 (Kg)";
      ucItemWeightGoods.Title = "KL hàng (Kg)";

      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = tableLayoutPanel3;
      elipseControl.CornerRadius = 20;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = tableLayoutPanel4;
      elipseControl01.CornerRadius = 20;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.TargetControl = tableLayoutPanel7;
      elipseControl02.CornerRadius = 20;

      ElipseControl elipseControl03 = new ElipseControl();
      elipseControl03.TargetControl = tableLayoutPanel9;
      elipseControl03.CornerRadius = 20;
    }

    private async void btnLoadClient_Click(object sender, EventArgs e)
    {
      var clients = await AppCore.Ins._clientService.GetAllAsync(IsContainDelete: false);
      PopupLoadMD popupLoadMD = new PopupLoadMD();
      popupLoadMD.SetData(clients);
      popupLoadMD.OnSendData += PopupLoadMD_OnSendData;
      popupLoadMD.ShowDialog();
      
    }

    private void PopupLoadMD_OnSendData(object arg1, Common.EnumData.EnumTypeData arg2)
    {
      var rs = arg1 as ClientDTO;
      SetData(txtClient, rs?.Name ?? string.Empty);
    }

    private void SetData(RJTextBox rJTextBox, string data)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetData(rJTextBox, data);
        }));
        return;
      }

      rJTextBox.Texts = data;
    }
  }
}
