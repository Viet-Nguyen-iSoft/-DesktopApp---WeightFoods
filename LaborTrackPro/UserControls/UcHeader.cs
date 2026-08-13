using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcHeader : UserControl
  {
    public UcHeader()
    {
      InitializeComponent();
    }

    public bool HideBackButton
    {
      set
      {
        this.btnBack.Visible = !value;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Enter)
      {
        if (this.ActiveControl is Button btn && btn.Focused)
        {
          return true;
        }
        if (this.ActiveControl is RJButton btnRJ && btnRJ.Focused)
        {
          return true;
        }
        if (this.ActiveControl is UserControl uc && uc.Focused)
        {
          return true;
        }
        if (this.ActiveControl is DataGridView dgv && dgv.Focused)
        {
          return true;
        }
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void btnHome_Click(object sender, EventArgs e)
    {
      //FrmMain.Instance.ChangePage(AppModulSupport.Waiting);
      //AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Waiting;
      //AppCore.Ins.EndOfWeighingCycle();
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      
    }
  }
}
