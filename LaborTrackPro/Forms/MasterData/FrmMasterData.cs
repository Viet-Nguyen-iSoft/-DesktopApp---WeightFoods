using LaborTrackPro.Custom;
using LaborTrackPro.Forms.MasterData;
using LaborTrackPro.Setting;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Settings
{
  public partial class FrmMasterData : Form
  {
    public FrmMasterData()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmMasterData_Load;
    }

    #region Instance
    private static FrmMasterData _Instance = null;
    public static FrmMasterData Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmMasterData();
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
        case AppModulSupport.Employee:
          OpenChildForm(appModulSupport, FrmEmployee.Instance);
          break;
        case AppModulSupport.Department:
          OpenChildForm(appModulSupport, FrmDepartment.Instance);
          break;
        case AppModulSupport.ProductionOrder:
          OpenChildForm(appModulSupport, SettingProductionOrder.Instance);
          break;
        case AppModulSupport.Product:
          OpenChildForm(appModulSupport, FrmProduction.Instance);
          break;
        case AppModulSupport.Material:
          OpenChildForm(appModulSupport, FrmMaterial.Instance);
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
        case AppModulSupport.Employee:
          DisableColorButton();
          SetHighlightButton(btnEmployee, true);
          break;
        case AppModulSupport.Department:
          DisableColorButton();
          SetHighlightButton(btnDepartment, true);
          break;
        case AppModulSupport.ProductionOrder:
          DisableColorButton();
          SetHighlightButton(btnOrderProduct, true);
          break;
        case AppModulSupport.Product:
          DisableColorButton();
          SetHighlightButton(btnProduct, true);
          break;
        case AppModulSupport.Material:
          DisableColorButton();
          SetHighlightButton(btnMaterial, true);
          break;
      }
    }

    private void DisableColorButton()
    {
      SetHighlightButton(btnEmployee);
      SetHighlightButton(btnDepartment);
      SetHighlightButton(btnOrderProduct);
      SetHighlightButton(btnProduct);
      SetHighlightButton(btnMaterial);
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

    private void FrmMasterData_Load(object? sender, EventArgs e)
    {
      ChangePage(AppModulSupport.Employee);
    }

    private void btnEmployee_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.Employee);
    }

    private void btnDepartment_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.Department);
    }

    private void btnOrderProduct_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.ProductionOrder);
    }

    private void btnMaterial_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.Material);
    }

    private void btnProduct_Click(object sender, EventArgs e)
    {
      ChangePage(AppModulSupport.Product);
    }
  }
}
