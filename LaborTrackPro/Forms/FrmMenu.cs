using LaborTrackPro.Custom;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro
{
  public partial class FrmMenu : Form
  {
    public FrmMenu()
    {
      InitializeComponent();
      CustomUI();
    }
    #region Instance
    private static FrmMenu _Instance;
    public static FrmMenu Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmMenu();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 20;
      elipseControl01.TargetControl = tableLayoutPanel3;
    }

    private async void btnSetting_Click(object sender, EventArgs e)
    {
      //await FrmPageOperation.Instance.ChangePage(AppModulSupport.Setting);
    }

    private async void btnMasterData_Click(object sender, EventArgs e)
    {
      //await FrmPageOperation.Instance.ChangePage(AppModulSupport.MasterData);
    }

  }
}
