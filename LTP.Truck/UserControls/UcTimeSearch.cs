using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTP.Truck.UserControls
{
  public partial class UcTimeSearch : UserControl
  {
    public UcTimeSearch()
    {
      InitializeComponent();
      dtpDate.Format = DateTimePickerFormat.Custom;
      dtpDate.CustomFormat = "dd/MM/yyyy";
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DateTime Value
    {
      get => dtpDate.Value.Date
        .AddHours((double)hour.Value)
        .AddMinutes((double)minute.Value);
      set
      {
        dtpDate.Value = value.Date;
        hour.Value = value.Hour;
        minute.Value = value.Minute;
      }
    }
  }
}
