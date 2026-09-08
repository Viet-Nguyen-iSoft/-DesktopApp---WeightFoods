using DocumentFormat.OpenXml.Wordprocessing;
using LaborTrackPro.Helper;
using iSoft.Database.Models;
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

namespace LTP.Truck.Forms
{
  public partial class FrmHomeGoods : Form
  {
    private List<Product> _products = new();

    public FrmHomeGoods()
    {
      InitializeComponent();
      CustomUI();
      this.Load += FrmHomeGoods_Load;
      cbbProductGroup.SelectedValueChanged += cbbProductGroup_SelectedValueChanged;
    }

    #region Instance
    private static FrmHomeGoods _Instance = null;
    public static FrmHomeGoods Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmHomeGoods();
        return _Instance;
      }
    }
    #endregion

    private void CustomUI()
    {
      ElipseControl elipseControl = new ElipseControl();
      elipseControl.TargetControl = tableLayoutPanel3;
      elipseControl.CornerRadius = 20;

      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.TargetControl = tableLayoutPanel4;
      elipseControl01.CornerRadius = 20;

      //ElipseControl elipseControl02 = new ElipseControl();
      //elipseControl02.TargetControl = tableLayoutPanel7;
      //elipseControl02.CornerRadius = 20;

      //ElipseControl elipseControl03 = new ElipseControl();
      //elipseControl03.TargetControl = tableLayoutPanel9;
      //elipseControl03.CornerRadius = 20;
    }

    private async void FrmHomeGoods_Load(object? sender, EventArgs e)
    {
      try
      {
        await LoadData();

        cbbProductGroup.SelectedIndex = -1;
      }
      catch (Exception ex)
      {

      }
    }

    private async Task LoadData()
    {
      var categoryTares = await AppCore.Ins._categoryTareService.GetAllAsync();
      var productGroups = await AppCore.Ins._productGroupService.GetAllAsync();
      var products = await AppCore.Ins._productService.GetAllAsync();

      _products = products;
      SetProductGroup(productGroups);

      //cbbProduct.DisplayMember = nameof(Product.Name);
      //cbbProduct.ValueMember = nameof(Product.Id);
      //cbbProduct.DataSource = products;

      //cbbTare.DisplayMember = nameof(CategoryTare.Value);
      //cbbTare.ValueMember = nameof(CategoryTare.Id);
      //cbbTare.DataSource = categoryTares;
    }

    private void SetProductGroup(List<ProductGroup> productGroups)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetProductGroup(productGroups);
        }));
        return;
      }

      cbbProductGroup.DisplayMember = nameof(ProductGroup.Name);
      cbbProductGroup.ValueMember = nameof(ProductGroup.Id);
      cbbProductGroup.DataSource = productGroups;
    }

    private void cbbProductGroup_SelectedValueChanged(object? sender, EventArgs e)
    {
      FillProduct();
    }

    private void FillProduct()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          FillProduct();
        }));
        return;
      }

      if (cbbProductGroup.SelectedItem is not ProductGroup selectedProductGroup)
      {
        cbbProduct.DataSource = null;
        return;
      }

      var products = _products
        .Where(product => product.ProductGroupId == selectedProductGroup.Id)
        .ToList();

      cbbProduct.DisplayMember = nameof(Product.Name);
      cbbProduct.ValueMember = nameof(Product.Id);
      cbbProduct.DataSource = products;
    }
  }
}
