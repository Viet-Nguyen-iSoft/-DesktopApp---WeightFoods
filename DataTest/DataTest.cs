using iSoft.Communication.Helper;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using System.Threading.Tasks;
using static iSoft.Communication.EnumCommunication;
using static iSoft.Database.EnumData;

namespace DataTest
{
  public partial class DataTest : Form
  {
    public DataTest()
    {
      InitializeComponent();
      this.Load += DataTest_Load;
    }

    public List<Factory> _factories = new List<Factory>();
    public List<Material> _materials = new List<Material>();
    public List<ProductionOrder> _productionOrders = new List<ProductionOrder>();
    public List<Employee>? _employees = new List<Employee>();
    public List<Connection> _connections = new List<Connection>();
    public List<Connection>? _connections_weight = new List<Connection>();
    private List<Connection>? _connections_rfid = new List<Connection>();

    public AppConfig _appConfig = new AppConfig();
    
    public List<Department> _departments = new List<Department>();

    private async void DataTest_Load(object? sender, EventArgs e)
    {
      await LoadDataConfig();
      this.btnReloadProductionOrder.Click += BtnReloadProductionOrder_Click;
      this.btnReloadEmployee.Click += BtnReloadEmployee_Click;
    }

    public async Task LoadDataConfig()
    {
      try
      {
        _productionOrders = await AppCore.Ins.GetProductionOrdersAsync();
        _employees = await AppCore.Ins.GetAllEmployeeAsync();
        if (_employees.Count > 0)
          _employees = _employees?.Where(x => x.FullName != "i-Soft").ToList();
        _factories = await AppCore.Ins.GetFactoriesAsync();

        LoadEmployee();
        LoadProductionOrder();
        SetStatusSaveRecord(eStatus.None);
        SetFactory(_factories);
        SetEmployee(_employees);
      }
      catch (Exception ex)
      {

      }
    }

    private void CbbFactory_SelectedIndexChanged(object? sender, EventArgs e)
    {
      var factory = (Factory)cbbFactory.SelectedItem;
      if (factory!=null)
      {
        SetMachine(factory.Machines.ToList());
      }
    }

    private void CbbMachine_SelectedIndexChanged(object? sender, EventArgs e)
    {
      _machineCurrent = (Machine)cbbMachine.SelectedItem;
    }


    private void BtnReloadProductionOrder_Click(object? sender, EventArgs e)
    {
      LoadProductionOrder();
    }

    private void BtnReloadEmployee_Click(object? sender, EventArgs e)
    {
      LoadEmployee();
    }

    private void LoadProductionOrder()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadProductionOrder();
        }));
        return;
      }

      dgvProductionOrder.DataSource = _productionOrders;
    }

    private void LoadEmployee()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadEmployee();
        }));
        return;
      }

      dgvEmployee.DataSource = _employees;
    }


    private Random rnd = new Random();
    private double _netCurrent = 0;
    private double _tareCurrent = 0;
    private Employee _employeeCurrent;
    private ProductionOrder? _productionOrderCurrent;
    private Production? _productionCurrent;
    private Material? _materialCurrent;
    public Machine? _machineCurrent = new Machine();
    private eMaterialType _eTypeMaterialCurrent;

    private double _net_min = 10.0;
    private double _net_max = 100.0;
    private double _tare_min = 1.0;
    private double _tare_max = 10.0;

    private bool _isPermitAdd = true;
    private async void btnRandom_Click(object sender, EventArgs e)
    {
      try
      {
        _isPermitAdd = true;
        //Cân
        _netCurrent = rnd.NextDouble() * (_net_max - _net_min) + _net_min;
        _tareCurrent = rnd.NextDouble() * (_tare_max - _tare_min) + _tare_min;

        SetValueWeight(_netCurrent, _tareCurrent);

        //Nhân viên
        _employeeCurrent = cbbEmployee.SelectedItem as Employee;


        //Lệnh SX
        int index_productionOrder_random = rnd.Next(0, _productionOrders.Count);
        _productionOrderCurrent = _productionOrders.ToArray()[index_productionOrder_random];
        SetProductionOrder(_productionOrderCurrent);

        //Sản phẩm
        var productions = _productionOrderCurrent.Productions;
        if (productions?.Count <= 0) return;

        int index_product_random = rnd.Next(0, productions.Count);
        _productionCurrent = productions.ToArray()[index_product_random];

        //Material
        var materials = _productionCurrent.Materials;
        if (materials?.Count <= 0) return;
        int index_material_random = rnd.Next(0, materials.Count);
        _materialCurrent = materials.ToArray()[index_material_random];
        SetProduct(_materialCurrent.Group ?? "N/A");

        //Loại dữ liệu
        int index_type_random = rnd.Next(0, 2);
        eTypeRecord eTypeRecord = (eTypeRecord)(index_type_random);
        //Machine
        if (_machineCurrent == null || _machineCurrent.Id <= 0)
        {
          _isPermitAdd = false;
        }

        if (_employeeCurrent == null || _employeeCurrent.Id <= 0)
        {
          _isPermitAdd = false;
        }


        if (_isPermitAdd)
        {
          DatalogWeight laborProductivityRecognition = new DatalogWeight();
          laborProductivityRecognition.Net = (float)_netCurrent;
          laborProductivityRecognition.Tare = (float)_tareCurrent;
          laborProductivityRecognition.CreatedAt = DateTime.Now;
          laborProductivityRecognition.EmployeeId = _employeeCurrent.Id;
          laborProductivityRecognition.ProductionOrderId = _productionOrderCurrent.Id;
          if (_materialCurrent.MaterialType == 1 || _materialCurrent.MaterialType == 2)
          {
            laborProductivityRecognition.ProductionId = _productionCurrent.Id;
          }
          else
          {
            laborProductivityRecognition.ProductionId = null;
          }  

          laborProductivityRecognition.MachineId = _machineCurrent.Id;
          laborProductivityRecognition.MaterialId = _materialCurrent.Id;
          laborProductivityRecognition.eTypeRecord = eTypeRecord;

          await AppCore.Ins.AddRecordAsync(laborProductivityRecognition);
          SetStatusSaveRecord(eStatus.Success);
        }
        else
        {
          SetStatusSaveRecord(eStatus.Fail);
        }
      }
      catch (Exception ex)
      {
        SetStatusSaveRecord(eStatus.Fail);
      }

    }
    private void SetValueWeight(double net, double tare)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetValueWeight(net, tare);
        }));
        return;
      }

      lbNet.Text = $"{Math.Round(net, 2)} kg";
      lbTare.Text = $"{Math.Round(tare, 2)} kg";
      lbGross.Text = $"{Math.Round(net + tare, 2)} kg";
    }

    private void SetStatusSaveRecord(eStatus eStatus)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetStatusSaveRecord(eStatus);
        }));
        return;
      }

      switch (eStatus)
      {
        case eStatus.None:
          lbStatus.Text = "Trạng thái: Chờ";
          lbStatus.ForeColor = Color.Black;
          break;
        case eStatus.Success:
          lbStatus.Text = "Trạng thái: Lưu thành công";
          lbStatus.ForeColor = Color.Green;
          break;
        case eStatus.Fail:
          lbStatus.Text = "Trạng thái: Lưu thất bại";
          lbStatus.ForeColor = Color.Red;
          break;
        default:
          break;
      }
    }

    private void SetProductionOrder(ProductionOrder productionOrder)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetProductionOrder(productionOrder);
        }));
        return;
      }

      lbProductionOrder.Text = productionOrder.Name;
    }
    private void SetProduct(string content)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetProduct(content);
        }));
        return;
      }

      lbProduction.Text = content;
    }

    private bool AutoRandom = false;
    private void btnAutoRandom_Click(object sender, EventArgs e)
    {
      AutoRandom = !AutoRandom;
      if (AutoRandom) timer1.Start();
      btnAutoRandom.BackColor = (AutoRandom) ? Color.Green : Color.White;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      try
      {
        timer1.Stop();
        btnRandom.PerformClick();
      }
      catch (Exception)
      {

      }
      finally
      {
        if (AutoRandom)
        {
          timer1.Start();
        }
      }
    }

    private void SetFactory(List<Factory> factories)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetFactory(factories);
        }));
        return;
      }

      cbbFactory.SelectedIndexChanged -= CbbFactory_SelectedIndexChanged;
      cbbFactory.DataSource = factories;
      cbbFactory.DisplayMember = "Name";
      cbbFactory.SelectedIndexChanged += CbbFactory_SelectedIndexChanged;
      if (factories.Count>0)
      {
        cbbFactory.SelectedIndex = -1;
      }  
    }

    private void SetEmployee(List<Employee>? employees)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetEmployee(employees);
        }));
        return;
      }

      cbbEmployee.DataSource = employees;
      cbbEmployee.DisplayMember = "FullName";
    }
    private void SetMachine(List<Machine> machines)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          SetMachine(machines);
        }));
        return;
      }

      cbbMachine.SelectedIndexChanged -= CbbMachine_SelectedIndexChanged;
      cbbMachine.DataSource = machines;
      cbbMachine.DisplayMember = "Name";
      cbbMachine.SelectedIndexChanged += CbbMachine_SelectedIndexChanged;
      if (machines.Count > 0)
      {
        cbbMachine.SelectedIndex = 0-1;
      }
    }
  }

  public enum eStatus
  { 
    None,
    Success,
    Fail
  }
}
