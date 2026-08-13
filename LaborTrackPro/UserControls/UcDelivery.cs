using iSoft.Database.Models;
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
  public partial class UcDelivery : UserControl
  {
    public UcDelivery()
    {
      InitializeComponent();
      CustomUI();
    }

    public Size SizeCus
    {
      set
      {
        this.Size = value;
      }
    }

    public string Code
    {
      get => lbCode.Text;
      set => lbCode.Text = value;
    }

    public string Value
    {
      get => lbValue.Text;
      set => lbValue.Text = value;
    }

    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel1;
      elipseControl0.CornerRadius = 20;
    }
  }
}
