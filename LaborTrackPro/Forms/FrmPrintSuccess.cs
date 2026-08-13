using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaborTrackPro.Forms
{
  public partial class FrmPrintSuccess : Form
  {
    private System.Timers.Timer _tmrCloseFrm = new System.Timers.Timer();
    public delegate void SendPrintDone();
    public event SendPrintDone OnSendPrintDone;

    public FrmPrintSuccess()
    {
      InitializeComponent();

      _tmrCloseFrm.Interval = 3000;
      _tmrCloseFrm.Elapsed += _tmrCloseFrm_Elapsed;
      _tmrCloseFrm.Start();
    } 

    private void _tmrCloseFrm_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
      try
      {
        _tmrCloseFrm.Stop();
        OnSendPrintDone?.Invoke();
      }
      catch (Exception ex)
      {

      }
      finally
      {
        if (this.InvokeRequired)
        {
          this.Invoke(new Action(() => this.Close()));
        }
        else
        {
          this.Close();
        }
      }
    }
  }
}
