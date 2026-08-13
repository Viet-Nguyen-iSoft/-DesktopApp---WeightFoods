using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Setting;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.Forms.Settings
{
  public partial class FrmSettingMachine : Form
  {
    private Color colorDisable = Color.Gray;
    public FrmSettingMachine()
    {
      InitializeComponent();
      this.dgvMachine.EnableHeadersVisualStyles = false;
      this.dgvMachine.BorderStyle = BorderStyle.None;

      this.Load += FrmSettingMachine_Load;
      FrmSetting.Instance.OnSendLoadMachineClick += Instance_OnSendLoadMachineClick;
      FrmMain.Instance.OnSendChangeFactory += Instance_OnSendChangeFactory_Machine;
      FrmMain.Instance.OnSendChangeMachine += Instance_OnSendChangeFactory_Machine;
    }

    private void Instance_OnSendChangeFactory_Machine()
    {
      LoadMachine();
    }

    #region Instance
    private static FrmSettingMachine _Instance = null;
    public static FrmSettingMachine Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmSettingMachine();
        return _Instance;
      }
    }
    #endregion

    private void FrmSettingMachine_Load(object? sender, EventArgs e)
    {
      LoadMachine();
    }

    private void Instance_OnSendLoadMachineClick()
    {
      LoadMachine();
    }


    private void LoadMachine()
    {
      var dto = DTOHelper.ConvertMachineToDTO(AppCore.Ins._machines);
      ShowDatagridview(dto);
    }

    private void ShowDatagridview<T>(List<T>? t)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(async () =>
        {
          ShowDatagridview(t);
        }));
        return;
      }
      dgvMachine.DataSource = null;
      dgvMachine.DataSource = t;
      dgvMachine.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      dgvMachine.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgvMachine.Columns[1].Width = 200;
      dgvMachine.Columns[2].Width = 200;
    }


    private void dgvMachine_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      dgvMachine.DefaultCellStyle.SelectionBackColor = dgvMachine.DefaultCellStyle.BackColor;
      dgvMachine.RowsDefaultCellStyle.SelectionBackColor = dgvMachine.RowsDefaultCellStyle.BackColor;

      foreach (DataGridViewRow row in dgvMachine.Rows)
      {
        var machine = row.DataBoundItem as MachineDTO;
        if (machine != null)
        {
          dgvMachine.Rows[row.Index].DefaultCellStyle.BackColor =
            (machine.Enable) ? Color.White : colorDisable;
        }
        else
        {
          dgvMachine.Rows[row.Index].DefaultCellStyle.BackColor = colorDisable;
        }

        row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
        row.DefaultCellStyle.SelectionForeColor = row.DefaultCellStyle.ForeColor;
      }
    }

    private void dgvMachine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex >= 0)
      {
        foreach (DataGridViewRow row in dgvMachine.Rows)
        {
          var machine = row.DataBoundItem as MachineDTO;
          if (machine != null)
          {
            if (row.Index != e.RowIndex)
            {
              machine.Enable = false;
              dgvMachine.Rows[row.Index].DefaultCellStyle.BackColor = colorDisable;
            }
            else
            {
              dgvMachine.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
              machine.Enable = true;
            }

          }
          else
          {
            dgvMachine.Rows[row.Index].DefaultCellStyle.BackColor = colorDisable;
          }
          row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
          row.DefaultCellStyle.SelectionForeColor = row.DefaultCellStyle.ForeColor;
        }

      }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
      bool changeFlag = false;
      try
      {
        if (dgvMachine.Rows.Count > 0)
        {
          List<Machine> machineUpdate = new List<Machine>();
          foreach (DataGridViewRow row in dgvMachine.Rows)
          {
            var machine = row.DataBoundItem as MachineDTO;
            if (machine != null)
            {
              var mc = AppCore.Ins._machines?.FirstOrDefault(x => x.Id == machine.Id);

              if (mc != null)
              {
                if (mc.EnableFlag != machine.Enable)
                {
                  mc.EnableFlag = machine.Enable;
                  changeFlag = true;
                }
                mc.UpdatedAt = DateTime.Now;
                machineUpdate.Add(mc);
              }
            }
          }
          if (changeFlag)
          {
            var a = await AppCore.Ins.UpdateRangeMachineAsync(machineUpdate);
            new FrmInformation().ShowMessage("Lưu thông máy thành công", eImage.Information);
            await AppCore.Ins.ReloadMachines();
            LoadMachine();
          }
          else
          {
            new FrmInformation().ShowMessage("Không có dữ liệu cần cập nhật.", eImage.Information);
          }
        }
        else
        {
          new FrmInformation().ShowMessage("Không có dữ liệu cần cập nhật.", eImage.Information);
        }
      }
      catch (Exception ex)
      {
        new FrmInformation().ShowMessage("Lưu thông máy thất bại", eImage.Warning);
      }
    }
  }
}
