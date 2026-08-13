using HelperManager;
using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using System.Data;

namespace LaborTrackPro.Forms.MasterData
{
  public partial class FrmProduction : Form
  {
    public FrmProduction()
    {
      InitializeComponent();
      this.Load += FrmProduction_Load;
      this.dgv.CellClick += dgv_CellClick;
      FrmMain.Instance.OnSendChangeProduction += Instance_OnSendChangeProduction;
    }

    #region Instance
    private static FrmProduction _Instance = null;

    public static FrmProduction Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmProduction();
        return _Instance;
      }
    }
    #endregion

    private List<Production> _productions = new List<Production>();

    private async void FrmProduction_Load(object? sender, EventArgs e)
    {
      await SearchData();
    }
    private async void btnSearch_Click(object sender, EventArgs e)
    {
      await SearchData();
    }

    private async void Instance_OnSendChangeProduction()
    {
      await SearchData();
    }

    private async Task SearchData()
    {
      try
      {
        _productions = await AppCore.Ins.GetProductionsAsync();
        var rsDto = ProcessingData(_productions, txtSearch.Texts);
        ShowDatagridview(rsDto);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private List<ProductionDTO> ProcessingData(List<Production> productions, string txtSearch)
    {
      try
      {
        var rs = Search(productions, txtSearch);
        return DTOHelper.ConvertProductionToDTO(rs);
      }
      catch (Exception)
      {
        throw;
      }
    }

    private List<Production> Search(List<Production> productions, string textSearch)
    {
      try
      {
        if (productions != null)
        {
          if (!string.IsNullOrWhiteSpace(textSearch))
          {
            string searchLower = TextHelper.RemoveDiacritics(textSearch).ToLower();
            return productions.Where(e =>
              e.DeletedFlag == false && (
                TextHelper.RemoveDiacritics((e.Name ?? "").ToLower()).Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Code ?? "").ToLower()).Contains(searchLower) ||
                TextHelper.RemoveDiacritics((e.Description ?? "").ToLower()).Contains(searchLower))
            )
            .OrderBy(x => x.Name)
            .ToList();
          }
          else
          {
            return productions.Where(e => e.DeletedFlag == false)
            .OrderBy(x => x.Name)
            .ToList();
          }
        }
        else
        {
          return new List<Production>();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void ShowDatagridview(List<ProductionDTO> productionDTOs)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(async () =>
        {
          ShowDatagridview(productionDTOs);
        }));
        return;
      }

      try
      {
        dgv.AutoGenerateColumns = false;
        dgv.DataSource = productionDTOs;
        dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dgv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgv.Columns[7].Width = 200;
      }
      catch (Exception)
      {
      }
    }

    private void dgv_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
      //try
      //{
      //  if (e.RowIndex >= 0 && e.ColumnIndex == dgv.Columns["btnDetail"].Index)
      //  {
      //    var item = dgv.Rows[e.RowIndex].DataBoundItem as ProductionDTO;
      //    if (item != null)
      //    {
      //      var productionOrder = _productions.FirstOrDefault(x => x.Id == item.Id);
      //      if (productionOrder != null)
      //      {
      //        FrmAddProduction product = new FrmAddProduction(productionOrder);
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
  }
}
