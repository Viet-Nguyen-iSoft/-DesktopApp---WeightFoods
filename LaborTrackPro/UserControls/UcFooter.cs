using LaborTrackPro.Forms;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcFooter : UserControl
  {
    public UcFooter()
    {
      InitializeComponent();
    }

    public void SetVersion(string version)
    {
      this.label3.Text = this.label3.Text + " " + version;
    }

    private Dictionary<string, bool> _statusConnection = new Dictionary<string, bool>();
    public string Datetime
    {
      set
      {
        this.lbDatetime.Text = value;
      }
    }

    public bool UnLockMenu
    {
      set
      {
        this.picLockMenu.Image = value ? Properties.Resources.icon_unlock :
                                         Properties.Resources.icon_locked;
      }
    }

    public bool VisibleSetting
    {
      set
      {
        this.picLockMenu.Visible = value;
      }
    }

    private void picMenu_Click(object sender, EventArgs e)
    {
      //FrmPageOperation.Instance.ChangePage(AppModulSupport.Menu);
    }

    public void SetStatusServer(EnumStatusConnectTcp enumStatusConnectTcp)
    {
      ucStatusConnection1.SetStatus("Server", enumStatusConnectTcp);
    }

    public void SetStatusWeight(EnumStatusConnectTcp enumStatusConnectTcp)
    {
      ucStatusConnection2.SetStatus("Weight", enumStatusConnectTcp);
    }

  }
}
