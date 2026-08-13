using HelperManager;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro
{
  public partial class FrmInformation : Form
  {
    public FrmInformation()
    {
      InitializeComponent();
      CustomUI();
      this.FormClosed += FrmInformation_FormClosed;
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
      elipseControl03.TargetControl = tableLayoutPanel4;
    }

    public void ShowMessage(string information, eImage nameImage)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowMessage(information, nameImage);
        }));
        return;
      }
      try
      {
        this.lbInformation.Text = information;
        switch (nameImage)
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

        timerInformation.Enabled = true;
        this.ShowDialog();
        this.BringToFront();
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void timerInformation_Tick(object sender, EventArgs e)
    {
      timerInformation.Stop();
      this.Close();
    }

    private void FrmInformation_FormClosed(object? sender, FormClosedEventArgs e)
    {
      timerInformation.Dispose();
    }
  }
}
