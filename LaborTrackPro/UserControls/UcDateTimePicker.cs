using LaborTrackPro.Custom;

namespace LaborTrackPro.UserControls
{

  public partial class UcDateTimePicker : UserControl
  {
    public delegate void SendUCClick();
    public event SendUCClick OnSendUCClick;
    public UcDateTimePicker()
    {
      InitializeComponent();
      CustomUI();
      this.lbDateTime.Click += lbDateTime_Click;
    }

    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel1;
      elipseControl0.CornerRadius = 10;

      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = lbDateTime;
      elipseControl1.CornerRadius = 10;
    }

    public void setLabelTime(string txt)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          setLabelTime(txt);
        }));
        return;
      }
      lbDateTime.Text = txt;
    }

    private void lbDateTime_Click(object? sender, EventArgs e)
    {
      OnSendUCClick?.Invoke();
    }
  }
}
