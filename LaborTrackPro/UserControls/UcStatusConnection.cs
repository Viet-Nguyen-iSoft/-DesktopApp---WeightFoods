using LaborTrackPro.Custom;
using static HelperManager.EnumData;

namespace LaborTrackPro.UC
{
  public partial class UcStatusConnection : UserControl
  {
    public UcStatusConnection()
    {
      InitializeComponent();

      ElipseControl el = new ElipseControl();
      el.CornerRadius = 10;
      el.TargetControl = tableLayoutPanel1;
    }

    public Size SizeCus
    {
      set
      {
        this.Size = value;
      }
    }

    public string NameDevice
    {
      set
      {
        this.lbStatus.Text = value;
      }
    }

    private Image IconStatus
    {
      get
      {
        return picIcon.Image;
      }
      set
      {
        picIcon.Image = value;
      }
    }
    public void SetStatus(string nameDevice, EnumStatusConnectTcp enumStatusConnectTcp)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetStatus(nameDevice, enumStatusConnectTcp);
        }));
        return;
      }

      switch (enumStatusConnectTcp)
      {
        case EnumStatusConnectTcp.None:
          break;
        case EnumStatusConnectTcp.Connect:
          lbStatus.Text = $"{nameDevice} Online";
          tableLayoutPanel1.BackColor = Color.FromArgb(40, 167, 68);
          break;
        case EnumStatusConnectTcp.Disconnect:
          lbStatus.Text = $"{nameDevice} Offline";
          tableLayoutPanel1.BackColor = Color.FromArgb(223, 47, 32);
          break;
        case EnumStatusConnectTcp.Connecting:
          break;
        default:
          break;
      }
    }

    public void SetIconDevice(EnumDevice eDevice)
    {
      switch (eDevice)
      {
        case EnumDevice.Weight:
          IconStatus = Properties.Resources.icon_scale;
          break;
        case EnumDevice.Rfid:
          IconStatus = Properties.Resources.icon_rfid; ;
          break;
        case EnumDevice.Server:
          IconStatus = Properties.Resources.icon_server;
          break;
      }
    }


  }
}
