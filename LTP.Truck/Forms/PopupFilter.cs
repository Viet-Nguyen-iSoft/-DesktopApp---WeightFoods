using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.EnumData;

namespace LTP.Truck.Forms
{
  public partial class PopupFilter : Form
  {
    public event Action<int, int>? OnSendData;
    public int StatusIndex => cbbStatus.SelectedIndex;
    public int TypeIndex => cbbType.SelectedIndex;

    public PopupFilter() : this(1, 0)
    {
    }

    public PopupFilter(int statusIndex, int typeIndex)
    {
      InitializeComponent();

      cbbStatus.SelectedIndex = NormalizeIndex(statusIndex, cbbStatus.Items.Count);
      cbbType.SelectedIndex = NormalizeIndex(typeIndex, cbbType.Items.Count);
      btnConfirm.Click += btnConfirm_Click;
      btnClose.Click += btnClose_Click;
      AcceptButton = btnConfirm;
      CancelButton = btnClose;
    }

    private static int NormalizeIndex(int index, int itemCount)
      => index >= 0 && index < itemCount ? index : 0;

    private void btnConfirm_Click(object? sender, EventArgs e)
    {
      OnSendData?.Invoke(StatusIndex, TypeIndex);
      Close();
    }

    private void btnClose_Click(object? sender, EventArgs e)
    {
      this.Close();
    }
  }
}
