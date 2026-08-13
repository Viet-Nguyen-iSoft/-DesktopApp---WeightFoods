using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using LaborTrackPro.UserControls;
using static HelperManager.EnumData;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Operation
{
  public partial class PopupScanRfid : Form
  {
    public delegate void SendSearchUCClick(eScanRfid eScanRfid, Employee employee);
    public event SendSearchUCClick OnSendSearchUCClick;

    public PopupScanRfid()
    {
      InitializeComponent();
      this.TopMost = AppCore.Ins._isTopMost;
      this.Load += PopupScanRfid_Load;
    }

    private eScanRfid _scanRfid { get;set;}
    private Employee _employee { get; set; }
    public PopupScanRfid(eScanRfid eScanRfid) : this()
    {
      _scanRfid = eScanRfid;
      if (eScanRfid == eScanRfid.ScanDelivery)
      {
        ucTitleFrm.Title = "Thông tin bên giao";
        ucIdCard.Title = "Thông tin bên giao";
        ucTitleFrm.Image = Properties.Resources.icon_info;
        ucTitleFrm.FunctionButton(eTypeButton.ScanRfid);
      }
      else if (eScanRfid == eScanRfid.ScanQC)
      {
        ucTitleFrm.Title = "Thông tin bộ phận chất lượng (QC)";
        ucIdCard.Title = "Thông tin bộ phận chất lượng (QC)";
        ucTitleFrm.Image = Properties.Resources.icon_info;
        ucTitleFrm.FunctionButton(eTypeButton.ScanRfid);
        this.btnConfirm.Enabled = false;
      }
      else if (eScanRfid == eScanRfid.ScanReceiving)
      {
        ucTitleFrm.Title = "Thông tin bên nhận";
        ucIdCard.Title = "Thông tin bên nhận";
        ucTitleFrm.Image = Properties.Resources.icon_info;
        ucTitleFrm.FunctionButton(eTypeButton.ScanRfid);
        this.btnConfirm.Enabled = false;
      }
      else if (eScanRfid == eScanRfid.PermitWeightOver)
      {
        ucTitleFrm.Title = "Xác nhận cho phép cân vượt ngưỡng";
        ucIdCard.Title = "Thông tin thẻ";
        ucTitleFrm.Image = Properties.Resources.icon_info;
        ucTitleFrm.FunctionButton(eTypeButton.ScanRfid);
        this.btnConfirm.Enabled = false;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Enter)
      {
        if (this.ActiveControl is Button btn && btn.Focused)
        {
          return true;
        }
        if (this.ActiveControl is RJButton btnRJ && btnRJ.Focused)
        {
          return true;
        }
        if (this.ActiveControl is UserControl uc && uc.Focused)
        {
          return true;
        }
        if (this.ActiveControl is DataGridView dgv && dgv.Focused)
        {
          return true;
        }
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void PopupScanRfid_Load(object? sender, EventArgs e)
    {
      AppCore.Ins.OnSendDataRfid += Ins_OnSendDataRfid;
    }

    private void Ins_OnSendDataRfid(object? sender, MessageDataOutput e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          Ins_OnSendDataRfid(sender, e);
        }));
        return;
      }

      try
      {
        string data = e?.DataAsString ?? string.Empty ;
        if (!string.IsNullOrEmpty(data))
        {
          _employee = AppCore.Ins._employees?.FirstOrDefault(x => x.IdCardCode == data && !x.DeletedFlag);
          if (_employee!=null)
          {
            if (_scanRfid == eScanRfid.ScanQC)
            {
              var department = _employee.Departments.FirstOrDefault(x => x.DeletedFlag == false);
              if (department != null)
              {
                SetInforIdCard(_employee);
                if (department.EnumGroup == EnumGroup.QC)
                {
                  this.btnConfirm.Enabled = true;
                }
                else
                {
                  this.btnConfirm.Enabled = false;
                  new FrmInformation().ShowMessage("Thẻ này không thuộc phòng QC !", eImage.Warning);
                  return;
                }  
              }
              else
              {
                this.btnConfirm.Enabled = false;
                new FrmInformation().ShowMessage("Thẻ chưa mapping thông tin phòng ban !", eImage.Warning);
                return;
              }
            }
            if (_scanRfid == eScanRfid.ScanReceiving)
            {
              SetInforIdCard(_employee);
              if (AppCore.Ins._dataManager.DataLogDelivery.EmployeeReceivingFirst?.Id != _employee.Id)
              {
                this.btnConfirm.Enabled = false;
                new FrmInformation().ShowMessage("Thông tin bên nhận chưa khớp với lần quét trước đó !", eImage.Warning);
                return;
              }
              else
              {
                this.btnConfirm.Enabled = true;
              }
            }
            else if (_scanRfid == eScanRfid.PermitWeightOver)
            {
              var permit = _employee?.IsAllowOverWeight ?? false;
              this.btnConfirm.Enabled = permit;
              SetInforIdCard(_employee);
            }
            else
            {
              SetInforIdCard(_employee);
            }  
          }
          else
          {
            new FrmInformation().ShowMessage("Không tìm thấy thông tin !", eImage.Warning);
            return;
          }  
        }
        else
        {
          SetInforIdCard(null);
          new FrmInformation().ShowMessage("Thẻ có mã trống, kiểm tra lại !", eImage.Warning);
          return;
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    public void SetInforIdCard(Employee? employee)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetInforIdCard(employee);
        }));
        return;
      }

      if (employee != null)
      {
        ucIdCard.IdCardName = employee?.FullName ?? "N/A";
        ucIdCard.DepartmentName = employee?.Departments?.FirstOrDefault()?.Name ?? "N/A";
      }
      else
      {
        ucIdCard.IdCardName = "...";
        ucIdCard.DepartmentName = "...";
      }
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      if (_employee != null)
      {
        AppCore.Ins.OnSendDataRfid -= Ins_OnSendDataRfid;
        OnSendSearchUCClick?.Invoke(_scanRfid, _employee);
        this.Close();
      }
      else
      {
        new FrmInformation().ShowMessage("Không tìm thấy nhân viên.\r\nVui lòng quét thẻ !", eImage.Warning);
        return;
      }
    }


    private void btnCancel_Click(object sender, EventArgs e)
    {
      AppCore.Ins.OnSendDataRfid -= Ins_OnSendDataRfid;
      this.Close();
    }


  }


}
