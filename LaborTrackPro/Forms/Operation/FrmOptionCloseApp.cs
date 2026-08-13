using iSoft.Database.Models;
using LaborTrackPro.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaborTrackPro
{
  public partial class FrmOptionCloseApp : Form
  {
    public event EventHandler? OnSendMini;
    public event EventHandler? OnSendRestart;
    public event EventHandler? OnSendClose;
    public event EventHandler? OnSendCheckUpdateVersion;

    public FrmOptionCloseApp()
    {
      InitializeComponent();
      this.Load += FrmOptionCloseApp_Load;
    }
    #region Instance
    private static FrmOptionCloseApp _Instance = null;

    public static FrmOptionCloseApp Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmOptionCloseApp();
        return _Instance;
      }
    }
    #endregion

    private void FrmOptionCloseApp_Load(object? sender, EventArgs e)
    {
      this.TopMost = true;
    }
    private void btnRestartApp_Click(object sender, EventArgs e)
    {
      OnSendRestart?.Invoke(this, e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      OnSendClose?.Invoke(this, e);
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnMini_Click(object sender, EventArgs e)
    {
      OnSendMini?.Invoke(this, e);
    }

    private void btnCheckVersion_Click(object sender, EventArgs e)
    {
      OnSendCheckUpdateVersion?.Invoke(this, e);
      this.Close();
    }
  }
}
