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

namespace LaborTrackPro.Forms
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
      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = tableLayoutPanel3;
      elipseControl.CornerRadius = 20;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = tableLayoutPanel4;
      elipseControl01.CornerRadius = 20;
    }

  }
}
