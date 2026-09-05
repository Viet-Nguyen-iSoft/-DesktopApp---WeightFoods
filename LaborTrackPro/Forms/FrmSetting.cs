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
  public partial class FrmSetting : Form
  {
    public FrmSetting()
    {
      InitializeComponent();
    }
    #region Instance
    private static FrmSetting _Instance = null;

    private void btnAddCommWeight_Click(object sender, EventArgs e)
    {

    }

    public static FrmSetting Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSetting();
        return _Instance;
      }
    }
    #endregion



  }
}
