using HelperManager;
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

namespace Common.Settings
{
  public partial class PopupChooseComm : Form
  {
    public event EventHandler<EnumCommunication>? OnSendConfirm;
    public PopupChooseComm()
    {
      InitializeComponent();
      this.Load += PopupChooseComm_Load;
    }

    private void PopupChooseComm_Load(object? sender, EventArgs e)
    {
      var items = Enum.GetValues<EnumCommunication>()
                  //.Where(x => x != EnumCommunication.None)
                  .Select(x => new
                  {
                    Value = x,
                    Description = EnumHelper.GetDescription(x)
                  })
                  .ToList();

      cbbConnectionType.DisplayMember = "Description";
      cbbConnectionType.ValueMember = "Value";
      cbbConnectionType.DataSource = items;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
      if (cbbConnectionType.SelectedValue is EnumCommunication type)
      {
        if (type == null || type == EnumCommunication.None)
        {
          PopupConfirm popupConfirm = new PopupConfirm("Vui lòng chọn loại truyền thông giao tiếp !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
          popupConfirm.ShowDialog();
          return;
        }

        OnSendConfirm?.Invoke(sender, type);
        this.Close();
      }
      else
      {
        PopupConfirm popupConfirm = new PopupConfirm("Không tìm thấy thông tin !", EnumTypeMsg.MessageManualClose, EnumImageMsg.Warning);
        popupConfirm.ShowDialog();
      }
    }
  }
}
