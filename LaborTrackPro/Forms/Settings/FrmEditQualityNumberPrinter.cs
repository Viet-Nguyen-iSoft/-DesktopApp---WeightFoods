using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using System.Threading.Tasks;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Settings
{
  public partial class FrmEditQualityNumberPrinter : Form
  {
    public delegate void SaveClick(eTypeLabel eTypeLabel);
    public event SaveClick OnSaveClick;

    private eTypeLabel _eTypeLabel;
    private SettingLabel _settingLabel;
    private int _numberCopy = 1;
    public FrmEditQualityNumberPrinter()
    {
      InitializeComponent();
      this.TopMost = true;
    }
    #region Instance
    private static FrmEditQualityNumberPrinter _Instance = null;
    public static FrmEditQualityNumberPrinter Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmEditQualityNumberPrinter();
        return _Instance;
      }
    }
    #endregion
    public FrmEditQualityNumberPrinter(eTypeLabel eTypeLabel) : this()
    {
      _eTypeLabel = eTypeLabel;
    }
    public FrmEditQualityNumberPrinter(eTypeLabel eTypeLabel, SettingLabel settingLabel) : this()
    {
      _eTypeLabel = eTypeLabel;
      _settingLabel = settingLabel;
    }

    private void FrmEditQualityNumberPrinter_Load(object sender, EventArgs e)
    {
      if (_settingLabel!=null)
      {
        this.btnSave.Text = "Cập nhật";
        txtTitleName.Texts = _settingLabel.Name ?? "N/A";
        txtNumberPrint.Texts = (_settingLabel?.NumberCopy ?? 0).ToString();
        _numberCopy = _settingLabel?.NumberCopy ?? 1;
      }  
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private async void btnSave_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtTitleName.Texts))
      {
        new FrmInformation().ShowMessage("Vui lòng điền tên tiêu đề phiếu in", eImage.Warning);
        return;
      }

      
      if (!int.TryParse(txtNumberPrint.Texts, out _numberCopy) || _numberCopy <= 0)
      {
        new FrmInformation().ShowMessage("Số lượng nhãn in không hợp lệ !", eImage.Warning);
        return;
      }

      try
      {
        if (_settingLabel==null)
        {
          SettingLabel settingLabel = new SettingLabel();
          settingLabel.Name = txtTitleName.Texts;
          settingLabel.NumberCopy = _numberCopy;
          settingLabel.eTypeLabel = _eTypeLabel;
          settingLabel.DeletedFlag = false;
          settingLabel.CreatedAt = DateTime.Now;
          settingLabel.UpdatedAt = DateTime.Now;
          await AppCore.Ins.AddSettingLabelAsync(settingLabel);
        }
        else
        {
          _settingLabel.Name = txtTitleName.Texts;
          _settingLabel.NumberCopy = _numberCopy;
          _settingLabel.UpdatedAt = DateTime.Now;
          await AppCore.Ins.UpdateSettingLabelAsync(_settingLabel);
        }  

          OnSaveClick.Invoke(_eTypeLabel);
        this.Close();
      }
      catch (Exception ex)
      {
        //TODO
      }
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
      _numberCopy++;
      txtNumberPrint.Texts = _numberCopy.ToString();
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      if (_numberCopy > 1)
      {
        _numberCopy--;
        txtNumberPrint.Texts = _numberCopy.ToString();
      }
    }

    private void txtNumericNumberPrint__TextChanged(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtNumberPrint.Texts))
      {
        _numberCopy = int.Parse(txtNumberPrint.Texts);
      }
    }

    private void txtNumericNumberPrint_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
      {
        e.Handled = true;
      }
    }
  }
}
