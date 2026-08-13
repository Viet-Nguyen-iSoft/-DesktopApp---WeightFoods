using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using System.Data;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcProductItem : UserControl
  {
    public event EventHandler<object?>? OnSendClickItem;

    public object? TagData { get; set; }
    public bool IsDefect { get; set; } = false;
    public UcProductItem()
    {
      InitializeComponent();
      CustomUI();

      this.Click += UcProductItem_Click;
      this.lbName.Click += UcProductItem_Click;
      this.lbCode.Click += UcProductItem_Click;
    }

    public Size SizeCus
    {
      set
      {
        this.Size = value;
      }
    }

    private void CustomUI()
    {
      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = this;
      elipseControl.CornerRadius = 20;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = tableLayoutPanel1;
      elipseControl01.CornerRadius = 20;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.TargetControl = tableLayoutPanel2;
      elipseControl02.CornerRadius = 20;

      Defect = false;
    }

    private void UcProductItem_Click(object? sender, EventArgs e)
    {
      OnSendClickItem?.Invoke(this, TagData);
    }

    public string ItemTitleName
    {
      get => lbName.Text;
      set => lbName.Text = value;
    }

    public string ItemTitleCode
    {
      get => lbCode.Text;
      set => lbCode.Text = value;
    }
    public bool VisibleCode
    {
      get => lbCode.Visible;
      set => lbCode.Visible = value;
    }

    public void FontSize(int fontSize = 16)
    {
      lbName.Font = new Font(lbName.Font.FontFamily, fontSize, FontStyle.Bold);
    }

    public bool Defect
    {
      set
      {
        IsDefect = value;
        tableLayoutPanel1.BackColor = value ? Color.Red : Color.Green;
      }
      get
      {
        return IsDefect;
      }
    }
  }
}
