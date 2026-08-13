using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro
{
  public partial class FrmConfirm : Form
  {
    public delegate void SendSendOKClicked();
    public event SendSendOKClicked OnSendOKClicked;

    public FrmConfirm()
    {
      InitializeComponent();
      CustomUI();
    }

    private void CustomUI()
    {
      this.TopMost = AppCore.Ins._isTopMost;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 20;
      elipseControl01.TargetControl = this;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 20;
      elipseControl02.TargetControl = tableLayoutPanel1;

      ElipseControl elipseControl03 = new ElipseControl();
      elipseControl03.CornerRadius = 20;
      elipseControl03.TargetControl = tableLayoutPanel2;
    }

    public FrmConfirm(string title, eImage eImage, bool visibleConfirm = true) : this()
    {
      this.lbInformation.Text = title;
      this.btnConfirm.Visible = visibleConfirm;

      switch (eImage)
      {
        case eImage.Confirm:
          this.picIcon.Image = Properties.Resources.icon_confirm;
          break;
        case eImage.Question:
          this.picIcon.Image = Properties.Resources.icon_question;
          break;
        case eImage.Warning:
          this.picIcon.Image = Properties.Resources.icon_warning;
          break;
        case eImage.Information:
          this.picIcon.Image = Properties.Resources.icon_information;
          break;
      }
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      OnSendOKClicked?.Invoke();
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
