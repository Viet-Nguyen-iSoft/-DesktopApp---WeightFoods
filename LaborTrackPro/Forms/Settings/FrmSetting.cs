using LaborTrackPro.Custom;
using LaborTrackPro.Forms.Settings;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Setting
{
  public partial class FrmSetting : Form
  {
    public delegate void SendLoadMachineClick();
    public event SendLoadMachineClick OnSendLoadMachineClick;
    public FrmSetting()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmSetting_Load;
    }



    #region Instance
    private static FrmSetting _Instance = null;
    public static FrmSetting Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSetting();
        return _Instance;
      }
    }
    #endregion
    private void CustomUI()
    {
      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = this.tableLayoutPanel2;
      elipseControl.CornerRadius = 20;
    }

    #region Call Form Child
    public void ChangePage(AppModulSupport appModulSupport)
    {
      switch (appModulSupport)
      {
        case AppModulSupport.SettingServer:
          OpenChildForm(appModulSupport, FrmSettingServer.Instance);
          break;
        case AppModulSupport.SettingPrinter:
          OpenChildForm(appModulSupport, FrmSettingPrinter.Instance);
          break;
        case AppModulSupport.SettingMachine:
          OpenChildForm(appModulSupport, FrmSettingMachine.Instance);
          break;
        case AppModulSupport.SettingDevice:
          OpenChildForm(appModulSupport, FrmSettingDevice.Instance);
          break;
      }
    }

    private Form CurrentForm;
    public void OpenChildForm(AppModulSupport modulSupport, Form ChildForm)
    {
      bool Is_same_form = false;
      if (this.pnlBody.Tag != null)
      {
        if (this.pnlBody.Tag is Tuple<AppModulSupport, Form>)
        {
          Tuple<AppModulSupport, Form> TagAsForm = (Tuple<AppModulSupport, Form>)(this.pnlBody.Tag);
          if (TagAsForm.Item1 == modulSupport)
          {
            Is_same_form = true;
          }
        }
      }
      if (Is_same_form == false)
      {
        if (CurrentForm != null)
        {
          CurrentForm.Visible = false;
        }
        this.pnlBody.Controls.Clear();
        this.pnlBody.Tag = Tuple.Create(modulSupport, ChildForm);
        CurrentForm = ChildForm;
        ChildForm.TopLevel = false;
        ChildForm.FormBorderStyle = FormBorderStyle.None;
        ChildForm.Dock = DockStyle.Fill;
        ChildForm.BringToFront();
        this.pnlBody.Controls.Add(ChildForm);
        ChildForm.Show();
      }

      ChangeColorButton(modulSupport);
    }

    private void ChangeColorButton(AppModulSupport appModulSupport)
    {
      switch (appModulSupport)
      {
        case AppModulSupport.SettingServer:
          DisableColorButton();
          SetHighlightButton(btnSettingServer, true);
          break;
        case AppModulSupport.SettingDevice:
          DisableColorButton();
          SetHighlightButton(btnCommunicationDevice, true);
          break;
        case AppModulSupport.SettingPrinter:
          DisableColorButton();
          SetHighlightButton(btnSettingPrinterDelivery, true);
          break;
        case AppModulSupport.SettingMachine:
          DisableColorButton();
          SetHighlightButton(btnSettingMachine, true);
          break;
      }
    }

    private void DisableColorButton()
    {
      SetHighlightButton(btnSettingServer);
      SetHighlightButton(btnSettingPrinterDelivery);
      SetHighlightButton(btnSettingMachine);
      SetHighlightButton(btnCommunicationDevice);
    }


    private void SetHighlightButton(Button button, bool isHighlight = false)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetHighlightButton(button, isHighlight);
        }));
        return;
      }

      if (isHighlight)
      {
        button.BackColor = Color.FromArgb(228, 148, 1);
        button.ForeColor = Color.White;
        button.Font = new Font(button.Font, FontStyle.Bold);
      }
      else
      {
        button.BackColor = Color.FromArgb(239, 242, 243);
        button.ForeColor = Color.Black;
        button.Font = new Font(button.Font, FontStyle.Regular);
      }
    }

    #endregion

    private void FrmSetting_Load(object? sender, EventArgs e)
    {
      ChangePage(AppModulSupport.SettingDevice);
    }

    private void btnSettingServer_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.SettingServer);
    }

    private void btnbtnSettingPrinterDelivery_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.SettingPrinter);
    }

    private void btnSettingMachine_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.SettingMachine);
    }

    private void btnCommunicationDevice_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.SettingDevice);
    }
  }
}
