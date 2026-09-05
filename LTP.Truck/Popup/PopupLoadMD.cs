using Common;
using iSoft.Database;
using iSoft.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;
using static Common.EnumData;

namespace LTP.Truck.Popup
{
  public partial class PopupLoadMD : Form
  {
    public event Action<object, EnumTypeData>? OnSendData;

    private EnumTypeData _enumTypeData {  get; set; }
    public PopupLoadMD()
    {
      InitializeComponent();
      CustomUI();
    }

    private void CustomUI()
    {
      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeight = 50;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      dgv.RowTemplate.Height = 60;
      dgv.BorderStyle = BorderStyle.None;
      dgv.MultiSelect = false;
    }

    public void SetData<T>(List<T> items)
    {
      if (items == null)
        throw new ArgumentNullException(nameof(items));

      if (typeof(T) == typeof(Client))
      {
        _enumTypeData = EnumTypeData.Client;

        var dto = DTOHelper.ConvertClientDTO(items as List<Client>);
        dgv.DataSource = dto;

        dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      if (dgv.SelectedRows.Count > 0)
      {
        DataGridViewRow row = dgv.SelectedRows[0];
        OnSendData?.Invoke(row.DataBoundItem, _enumTypeData);
        this.Close();
      }
      else
      {
        PopupConfirm popupConfirm = new PopupConfirm("Vui lòng chọn dữ liệu cần chọn !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
      }

      
    }
  }
}
