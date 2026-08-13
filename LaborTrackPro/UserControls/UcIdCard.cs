using LaborTrackPro.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaborTrackPro.UserControls
{
  public partial class UcIdCard : UserControl
  {
    public UcIdCard()
    {
      InitializeComponent();
      CustomUI();
    }
    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel1;
      elipseControl0.CornerRadius = 50;

      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = this;
      elipseControl1.CornerRadius = 50;
    }

    public string Title
    {
      set
      {
        this.lbTitle.Text = value;
      }
    }

    public string IdCardName
    {
      set
      {
        this.lbName.Text = value;
      }
    }

    public string DepartmentName
    {
      set
      {
        this.lbDepartment.Text = value;
      }
    }
  }
}
