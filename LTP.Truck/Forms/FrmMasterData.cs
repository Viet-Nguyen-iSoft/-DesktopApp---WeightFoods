using iSoft.Database;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Helper;
using LTP.Truck.Controls;
using LTP.Truck.Custom;
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
using static LTP.Truck.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmMasterData : Form
  {
    public FrmMasterData()
    {
      InitializeComponent();
      CustomUI();
    }

    #region Instance
    private static FrmMasterData _Instance = null;
    public static FrmMasterData Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmMasterData();
        return _Instance;
      }
    }
    #endregion


    private void CustomUI()
    {
      //ElipseControl elipseControl = new ElipseControl();
      //elipseControl.TargetControl = tableLayoutPanel3;
      //elipseControl.CornerRadius = 20;

      //ElipseControl elipseControl01 = new ElipseControl();
      //elipseControl01.TargetControl = tableLayoutPanel4;
      //elipseControl01.CornerRadius = 20;

      //ElipseControl elipseControl02 = new ElipseControl();
      //elipseControl02.TargetControl = tableLayoutPanel7;
      //elipseControl02.CornerRadius = 20;

      //ElipseControl elipseControl03 = new ElipseControl();
      //elipseControl03.TargetControl = tableLayoutPanel9;
      //elipseControl03.CornerRadius = 20;

      dgv.EnableHeadersVisualStyles = false;
      dgv.ColumnHeadersHeight = 50;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      dgv.RowTemplate.Height = 60;
      dgv.BorderStyle = BorderStyle.None;
      dgv.MultiSelect = false;
      dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
      dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;
      dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
      dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
      dgv.RowHeadersDefaultCellStyle.SelectionBackColor = dgv.RowHeadersDefaultCellStyle.BackColor;
      dgv.RowHeadersDefaultCellStyle.SelectionForeColor = dgv.RowHeadersDefaultCellStyle.ForeColor;

    }

    public async Task LoadData(EnumTypeMasterData enumTypeMaster)
    {
      switch (enumTypeMaster)
      {
        case EnumTypeMasterData.Client:
          var rsClient = await AppCore.Ins._clientService.GetAllAsync();
          var dtoClient = DTOHelper.ConvertClientDTO(rsClient);
          SetDgv(enumTypeMaster, dtoClient);
          break;
        case EnumTypeMasterData.TypeGoods:
          var rsTypeGoods = await AppCore.Ins._typeGoodsService.GetAllAsync();
          var dtoTypeGoods = DTOHelper.ConvertTypeGoodsDTO(rsTypeGoods);
          SetDgv(enumTypeMaster, dtoTypeGoods);
          break;
        case EnumTypeMasterData.Warehouse:
          var rsWarehouse = await AppCore.Ins._warehouseService.GetAllAsync();
          var dtoWarehouse = DTOHelper.ConvertWareHouseDTO(rsWarehouse);
          SetDgv(enumTypeMaster, dtoWarehouse);
          break;
        default:
          break;
      }
    }

    public void SetDgv<T>(EnumTypeMasterData enumTypeMasterData, List<T>? values)
    {
      dgv.DataSource = values;

      if (enumTypeMasterData == EnumTypeMasterData.Client)
      {
        var autoSizeColumns = new[]
         {
            nameof(ClientDTO.No),
          };
        foreach (var columnName in autoSizeColumns)
        {
          if (dgv.Columns.Contains(columnName))
            dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        var alignmentMiddleCenterColumns = new[]
        {
            nameof(TypeGoodsDTO.No),
          };
        foreach (var columnName in alignmentMiddleCenterColumns)
        {
          if (dgv.Columns.Contains(columnName))
            dgv.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
      }
      else if (enumTypeMasterData == EnumTypeMasterData.TypeGoods)
      {
        var autoSizeColumns = new[]
        {
          nameof(TypeGoodsDTO.No),
        };
        foreach (var columnName in autoSizeColumns)
        {
          if (dgv.Columns.Contains(columnName))
            dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        var alignmentMiddleCenterColumns = new[]
        {
            nameof(TypeGoodsDTO.No),
          };
        foreach (var columnName in alignmentMiddleCenterColumns)
        {
          if (dgv.Columns.Contains(columnName))
            dgv.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
      }
      else if (enumTypeMasterData == EnumTypeMasterData.Warehouse)
      {
        var autoSizeColumns = new[]
        {
          nameof(WareHouseDTO.No),
        };
        foreach (var columnName in autoSizeColumns)
        {
          if (dgv.Columns.Contains(columnName))
            dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        var alignmentMiddleCenterColumns = new[]
        {
          nameof(WareHouseDTO.No),
        };
        foreach (var columnName in alignmentMiddleCenterColumns)
        {
          if (dgv.Columns.Contains(columnName))
            dgv.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
      }
    }
  }
}
