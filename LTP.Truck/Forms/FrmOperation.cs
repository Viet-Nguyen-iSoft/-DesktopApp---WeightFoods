using HelperManager;
using LTP.Truck.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LTP.Truck.EnumData;

namespace LTP.Truck.Forms
{
  public partial class FrmOperation : Form
  {
    private readonly Dictionary<Button, (Color BackColor, Color ForeColor, Color MouseOverColor, Color MouseDownColor)> _menuButtonColors = new();
    private bool _masterDataExpanded;

    public FrmOperation()
    {
      InitializeComponent();
      InitializeMenuSelection();
      SetMasterDataExpanded(false);
      this.Load += FrmOperation_Load;
    }

    private void InitializeMenuSelection()
    {
      Button[] menuButtons =
      {
        btnHomeTruck, btnHomeGoods, btnSetting, btnMasterData,
        btnClient, btnTypeGoods, btnWarehouse, btnTare, btnGroupProduct, btnProduct
      };

      foreach (Button button in menuButtons)
      {
        _menuButtonColors.Add(button, (button.BackColor, button.ForeColor,
          button.FlatAppearance.MouseOverBackColor, button.FlatAppearance.MouseDownBackColor));
        button.Click += MenuButton_Click;
      }
    }

    private void MenuButton_Click(object? sender, EventArgs e)
    {
      if (sender is Button button)
        CheckMenuButton(button);
    }

    private void CheckMenuButton(Button selectedButton)
    {
      Color choose = Color.FromArgb(255, 204, 204);
      bool selectedChild = IsMasterDataChild(selectedButton);
      Button selectedMainButton = selectedChild ? btnMasterData : selectedButton;

      Button? selectedChildButton = selectedChild ? selectedButton
        : selectedButton == btnMasterData ? btnClient : null;

      foreach (var entry in _menuButtonColors)
      {
        Button button = entry.Key;
        var originalColors = entry.Value;
        bool mainSelected = button == selectedMainButton;
        bool childSelected = button == selectedChildButton;
        button.BackColor = mainSelected ? choose : originalColors.BackColor;
        button.ForeColor = mainSelected ? Color.Red
          : childSelected ? Color.Red : originalColors.ForeColor;
        button.FlatAppearance.MouseOverBackColor = mainSelected ? choose : originalColors.MouseOverColor;
        button.FlatAppearance.MouseDownBackColor = mainSelected ? choose : originalColors.MouseDownColor;
      }
    }

    private bool IsMasterDataChild(Button button)
    {
      return button == btnClient || button == btnTypeGoods || button == btnWarehouse
        || button == btnTare || button == btnGroupProduct || button == btnProduct;
    }

    private void SetMasterDataExpanded(bool expanded)
    {
      _masterDataExpanded = expanded;
      flowLayoutPanel1.SuspendLayout();
      try
      {
        foreach (Button button in _menuButtonColors.Keys)
        {
          if (IsMasterDataChild(button))
            button.Visible = expanded;
        }
      }
      finally
      {
        flowLayoutPanel1.ResumeLayout(true);
      }
    }

    #region Instance
    private static FrmOperation _Instance = null;
    public static FrmOperation Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmOperation();
        return _Instance;
      }
    }
    #endregion

    private void btnClose_Click(object sender, EventArgs e)
    {
      Program.CloseApp();
    }

    private void FrmOperation_Load(object? sender, EventArgs e)
    {
      this.btnHomeTruck.Click += btnHomeTruck_Click;
      this.btnHomeTruck.PerformClick();

      this.btnClient.Click += BtnClient_Click;
      this.btnTypeGoods.Click += BtnTypeGoods_Click;
      this.btnWarehouse.Click += BtnWarehouse_Click;
      this.btnTare.Click += BtnTare_Click;
      this.btnGroupProduct.Click += BtnGroupProduct_Click;
      this.btnProduct.Click += BtnProduct_Click;
    }

    private async void BtnProduct_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_Product);
    }

    private async void BtnGroupProduct_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_GroupProduct);
    }

    private async void BtnTare_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_Tare);
    }

    private async void BtnWarehouse_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_Warehouse);
    }

    private async void BtnTypeGoods_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_TypeGoods);
    }
    private async void BtnClient_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.MD_Client);
    }
    private async void btnMasterData_Click(object sender, EventArgs e)
    {
      SetMasterDataExpanded(!_masterDataExpanded);
      await ChangePage(EnumScreen.MD_Client);
    }


    private async void btnHomeTruck_Click(object? sender, EventArgs e)
    {
      await ChangePage(EnumScreen.HomeTruck);
    }
    private async void btnHomeGoods_Click(object sender, EventArgs e)
    {
      await ChangePage(EnumScreen.HomeGoods);
    }
    private async void btnSetting_Click(object sender, EventArgs e)
    {
      await ChangePage(EnumScreen.Setting);
    }


    #region ChangePage
    public async Task ChangePage(EnumScreen appModulSupport, bool actionBack = false)
    {
      try
      {
        switch (appModulSupport)
        {
          case EnumScreen.HomeTruck:
            OpenChildForm(appModulSupport, FrmHomeTruck.Instance);
            break;
          case EnumScreen.HomeGoods:
            OpenChildForm(appModulSupport, FrmHomeGoods.Instance);
            break;
          case EnumScreen.Setting:
            OpenChildForm(appModulSupport, FrmSetting.Instance);
            break;
          case EnumScreen.MD_Client:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.Client);
            break;
          case EnumScreen.MD_TypeGoods:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.TypeGoods);
            break;
          case EnumScreen.MD_Warehouse:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.Warehouse);
            break;
          case EnumScreen.MD_Tare:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.Tare);
            break;
          case EnumScreen.MD_GroupProduct:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.GroupProduct);
            break;
          case EnumScreen.MD_Product:
            OpenChildForm(appModulSupport, FrmMasterData.Instance);
            await FrmMasterData.Instance.LoadData(EnumTypeMasterData.Product);
            break;
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    private Form CurrentForm;
    public void OpenChildForm(EnumScreen modulSupport, Form childForm)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          OpenChildForm(modulSupport, childForm);
        }));
        return;
      }

      bool Is_same_form = false;
      if (this.panelMain.Tag != null)
      {
        if (this.panelMain.Tag is Tuple<EnumScreen, Form>)
        {
          Tuple<EnumScreen, Form> TagAsForm = (Tuple<EnumScreen, Form>)(this.panelMain.Tag);
          if (TagAsForm.Item1 == modulSupport)
          {
            Is_same_form = true;
          }
        }
      }
      if (Is_same_form == false)
      {
        if (CurrentForm != null)
        {
          CurrentForm.Visible = false;
        }
        this.panelMain.Controls.Clear();
        this.panelMain.Tag = Tuple.Create(modulSupport, childForm);
        CurrentForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        childForm.BringToFront();
        this.panelMain.Controls.Add(childForm);
        childForm.Show();
      }
    }
    #endregion

  }
}
