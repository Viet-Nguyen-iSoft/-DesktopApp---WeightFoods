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
  public partial class UcItemMode : UserControl
  {
    public event EventHandler<string>? OnSendItemClicked;
    public UcItemMode()
    {
      InitializeComponent();
      CustomUI();
      this.picIcon.Click += On_Click;
      this.tableLayoutPanel.Click += On_Click;
      this.lbTitle.Click += On_Click;
    }

    private string _key { get; set; }
    public UcItemMode(string key) : this()
    {
      _key = key;
    }
    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel;
      elipseControl0.CornerRadius = 20;

      ElipseControl elipseControl1 = new ElipseControl();
      elipseControl1.TargetControl = this;
      elipseControl1.CornerRadius = 20;
    }

    public Bitmap Image
    {
      set
      {
        picIcon.Image = value;
      }
    }
    public string Title
    {
      set
      {
        lbTitle.Text = value;
      }
    }
    public string Key
    {
      set
      {
        _key = value;
      }
    }

    public static bool Connect = false;
    public bool Connected
    {
      set
      {
        Connect = value;
        picConnect.Image = value ?
                            Properties.Resources.icon_connected :
                            Properties.Resources.icon_disconnected;
      }
      get
      {
        return Connect;
      }
    }

    public bool VisibleStatus
    {
      set
      {
        picConnect.Visible = value;
      }
    }
    public void Highlight(bool isHighlight = true)
    {
      tlpChoose.BackColor = isHighlight ? Color.FromArgb(57, 193, 255) : Color.FromArgb(159, 159, 159);
      //tableLayoutPanel.BackColor = isHighlight ? Color.FromArgb(57, 193, 200) : Color.FromArgb(217, 217, 217);
    }
    private void On_Click(object? sender, EventArgs e)
    {
      OnSendItemClicked?.Invoke(this, _key);
    }

  }
}
