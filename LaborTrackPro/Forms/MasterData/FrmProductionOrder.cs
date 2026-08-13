using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using System.Threading.Tasks;

namespace LaborTrackPro.Forms.Settings
{
  public partial class SettingProductionOrder : Form
  {
    public SettingProductionOrder()
    {
      InitializeComponent();
      this.Load += FrmSettingProductionOrder_Load;
      FrmMain.Instance.OnSendChangeProductionOrder += Instance_OnSendChangeProductionOrder;
    }

    #region Instance
    private static SettingProductionOrder _Instance = null;

    public static SettingProductionOrder Instance
    {
      get
      {
        if (_Instance == null) _Instance = new SettingProductionOrder();
        return _Instance;
      }
    }
    #endregion

    private List<ProductionOrder> productionOrders;
    private async void FrmSettingProductionOrder_Load(object? sender, EventArgs e)
    {
      await SearchData();
    }

    private async Task SearchData()
    {
      try
      {
        productionOrders = await AppCore.Ins.GetProductionOrdersAsync();
        var rs = Search(productionOrders, txtSearch.Texts);
        var rsDto = DTOHelper.ConvertPOToDTO(rs);
        ShowDatagridview(rsDto);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private async void Instance_OnSendChangeProductionOrder()
    {
      await SearchData();
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
      await SearchData();
    }

    private async void txtSearch__TextChanged(object sender, EventArgs e)
    {
      await SearchData();
    }

    private void ShowDatagridview(List<ProductionOrderDTO> productionOrderDTOs)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowDatagridview(productionOrderDTOs);
        }));
        return;
      }

      try
      {
        dgv.AutoGenerateColumns = false;
        dgv.DataSource = productionOrderDTOs;
        dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgv.Columns[8].Width = 200;
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      //try
      //{
      //  if (e.RowIndex >= 0 && e.ColumnIndex == dgv.Columns["btnDetail"].Index)
      //  {
      //    var item = dgv.Rows[e.RowIndex].DataBoundItem as ProductionOrderDTO;
      //    if (item != null)
      //    {
      //      var productionOrder = productionOrders.FirstOrDefault(x => x.Id == item.Id);
      //      if (productionOrder != null)
      //      {
      //        FrmAddOrderProduct product = new FrmAddOrderProduct(productionOrder);
      //        product.ShowDialog();
      //        product.BringToFront();
      //      }
      //    }
      //  }
      //}
      //catch (Exception ex)
      //{
      //  LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      //}
    }

    private List<ProductionOrder> Search(List<ProductionOrder> productDTOs, string textSearch)
    {
      try
      {
        if (productDTOs!=null)
        {
          if (!string.IsNullOrWhiteSpace(textSearch))
          {
            string searchLower = TextHelper.RemoveDiacritics(textSearch).ToLower();
            return productDTOs.Where(e =>
              e.DeletedFlag == false && (
                TextHelper.RemoveDiacritics((e.Name ?? "").ToLower()).Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Code ?? "").ToLower()).Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Description ?? "").ToLower()).Contains(searchLower))
            )
            //.OrderBy(x => x.eTypeOrderProduction)
           // .ThenBy(x => x.Name)
            .ToList();
          }
          else
          {
            return productDTOs.Where(e => e.DeletedFlag == false)
           // .OrderBy(x => x.eTypeOrderProduction)
           // .ThenBy(x => x.Name)
            .ToList();
          }
        }
        else
        {
          return new List<ProductionOrder>();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


  }
}
