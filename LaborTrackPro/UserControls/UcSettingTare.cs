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
  public partial class UcSettingTare : UserControl
  {
    public delegate void SendSendOKClicked(Product material);
    public event SendSendOKClicked OnSendOKClicked;

    public Product _materialForTare { get; set; } 
    public UcSettingTare()
    {
      InitializeComponent();
      CustomUI();

      this.lbTitle.Click += LbTitle_Click;
    }

    private void LbTitle_Click(object? sender, EventArgs e)
    {
      OnSendOKClicked?.Invoke(_materialForTare);
    }

    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel1;
      elipseControl0.CornerRadius = 20;

      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = this;
      elipseControl1.CornerRadius = 20;
    }
    public Size SizeCus
    {
      set
      {
        this.Size = value;
      }
    }
    public string Title
    {
      set
      {
        this.lbTitle.Text = value;
      }
    }
  }
}
