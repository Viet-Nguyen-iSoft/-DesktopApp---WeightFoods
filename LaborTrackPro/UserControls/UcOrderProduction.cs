using iSoft.Database.Models;
using LaborTrackPro.Custom;
using static iSoft.Database.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcOrderProduction : UserControl
  {
    public event EventHandler<object>? OnSendItemClicked;

    private object _tagData;
    public UcOrderProduction()
    {
      InitializeComponent();
      CustomUI();

      this.label1.Click += Item_Click;
      this.lbTitle.Click += Item_Click;
      this.tableLayoutPanel1.Click += Item_Click;
    }
    public UcOrderProduction(object obj, string mgs) : this()
    {
      _tagData = obj;
      SetData(mgs);
    }


    private void CustomUI()
    {
      ElipseControl elipseControl0 = new ElipseControl();
      elipseControl0.TargetControl = tableLayoutPanel1;
      elipseControl0.CornerRadius = 20;
    }

    private void Item_Click(object? sender, EventArgs e)
    {
      OnSendItemClicked?.Invoke(this.DataContext, _tagData);
    }

    public Size SizeCus
    {
      set
      {
        this.Size = value;
      }
    }

    private void SetData(string msg)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetData(msg);
        }));
        return;
      }

      lbTitle.Text = msg;
    }


  }
}
