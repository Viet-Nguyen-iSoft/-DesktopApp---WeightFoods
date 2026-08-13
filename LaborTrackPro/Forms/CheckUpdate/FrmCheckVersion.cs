using LaborTrackPro.Custom;
using LaborTrackPro.Forms.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaborTrackPro.Forms.CheckUpdate
{
  public partial class FrmCheckVersion : Form
  {
    public FrmCheckVersion()
    {
      InitializeComponent();
      CustomUI();
    }

    #region Instance
    private static FrmCheckVersion _Instance = null;
    public static FrmCheckVersion Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmCheckVersion();
        return _Instance;
      }
    }
    #endregion
    private void CustomUI()
    {
      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = this.tableLayoutPanel2;
      elipseControl.CornerRadius = 20;

      ElipseControl elipseControl2 = new ElipseControl();
      elipseControl2.TargetControl = this.tableLayoutPanel5;
      elipseControl2.CornerRadius = 20;

      ElipseControl elipseControl3 = new ElipseControl();
      elipseControl3.TargetControl = this.tableLayoutPanel3;
      elipseControl3.CornerRadius = 20;
    }

    private bool isUpdate = false;
    private void picAutoUpdate_Click(object sender, EventArgs e)
    {
      isUpdate = !isUpdate;
      picAutoUpdate.Image = isUpdate ? Properties.Resources.icon_toggle_on :
                                         Properties.Resources.icon_toggle_off;
    }


  }
}
