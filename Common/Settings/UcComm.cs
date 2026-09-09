using Common.Custom;
using iSoft.Database.Models;
using static Common.EnumData;
using static HelperManager.EnumData;

namespace Common.Settings
{
  public partial class UcComm : UserControl
  {
    public event Action<Connection?> OnSendDataDetail;
    public Connection? Connection { get; set; }
    public string CommName
    {
      get => lbCommName.Text;
      set => lbCommName.Text = value;
    }

    public string Information
    {
      get => lbInfor.Text;
      set => lbInfor.Text = value;
    }

    public UcComm()
    {
      InitializeComponent();
      CustomUI();
    }
    private void CustomUI()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 20;
      elipseControl01.TargetControl = this;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 20;
      elipseControl02.TargetControl = tableLayoutPanel3;
    }

    private void btnDetail_Click(object sender, EventArgs e)
    {
      OnSendDataDetail?.Invoke(Connection);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {

    }
  }
}
