using HelperManager;
using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using LaborTrackPro.Service;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.EnumData;
using Connection = iSoft.Database.Models.Connection;
using Control = System.Windows.Forms.Control;
using Station = iSoft.Database.Models.Station;

namespace LaborTrackPro.Controls
{
  public partial class AppCore
  {
    #region Instance
    private static AppCore _ins = new AppCore();
    public static AppCore Ins
    {
      get
      {
        return _ins == null ? _ins = new AppCore() : _ins;
      }
    }
    #endregion

    #region Event
    public delegate void SendDataWeight(MessageDataOutputWeight messageDataOutputWeight);
    public event SendDataWeight? OnSendDataWeight;

    public delegate void SendDataRfid(object? sender, MessageDataOutput e);
    public event SendDataRfid? OnSendDataRfid;

    public delegate void SendStatusDevice(MessageDataEvent messageDataEvent);
    public event SendStatusDevice? OnSendStatusDevice;

    public delegate void SendStatusConnectServer(EnumStatusConnectTcp enumStatusConnectTcp);
    public event SendStatusConnectServer? OnSendStatusConnectServer;

    public delegate void SendEndOfWeighingCycle();
    public event SendEndOfWeighingCycle? OnSendEndOfWeighingCycle;

    public delegate void SendEndOfWeighingDeliveryCycle();
    public event SendEndOfWeighingDeliveryCycle? OnSendEndOfWeighingDeliveryCycle;

    public event EventHandler<bool>? OnSendStatusConnectHID;
    public event EventHandler<EnumStatusConnectTcp>? OnSendStatusConnectWeight;
    public event EventHandler<List<Product>>? OnSendChangeTare;
    #endregion

    public ManagerData _dataManager = new ManagerData();
    public bool _isAdmin = true;
    public bool _isPrinterLabel = true;
    public bool _enableRabbit = false;
    public bool _alarm = false;
    public int _delivery_permit_hour = 2;
    public int _timeout_backhome_minute = 1;
    public string _ipPrintLabel = "";
    public bool _isTopMost = true;
    public string _inforLine { get; set; }
    public IdleMonitor _idle = new IdleMonitor();

    public S7NetService _s7NetService { get; set; }
   
    public void Init()
    {
      try
      {
        // LoadDataConfig().Wait();

        // _enableRabbit = (Environment.GetEnvironmentVariable("IS_ENABLE_RABBITMQ").ToLower() == "true");

        // _hostAPI = Environment.GetEnvironmentVariable("HOST_API");
        // _baseAPI = Environment.GetEnvironmentVariable("URL_API");
        // _apiKey = Environment.GetEnvironmentVariable("API_KEY");

        // _isPrinterLabel = (Environment.GetEnvironmentVariable("IS_PRINTER_LABEL").ToLower() == "true");
        // _delivery_permit_hour = int.Parse(Environment.GetEnvironmentVariable("HOUR_DELIVERY"));
        // _isAdmin = (Environment.GetEnvironmentVariable("IS_ADMIN").ToLower() == "true");

        // _timeout_backhome_minute = int.Parse(Environment.GetEnvironmentVariable("TIME_OUT_BACKHOME"));
        // _alarm = (Environment.GetEnvironmentVariable("ALARM").ToLower() == "true");

        if (!Directory.Exists(_folderFileLog))
          Directory.CreateDirectory(_folderFileLog);

        // _isTopMost = !_isAdmin;

        // _dataManager.DataLogPrintLabel = new DataLogPrintLabel();
        // _dataManager.DataLogDelivery = new DataLogDeliveryManager();
        //_dataManager.Machine = _machineCurrent;

        // _inforLine = _appConfig.Version + " - " + _machineCurrent?.Name ?? string.Empty;
        // _ipPrintLabel = _appConfig?.NamePrinter ?? string.Empty;

        // if (_alarm)
        // {
        //   _s7NetService = new S7NetService();
        //   _s7NetService.Connect("192.168.3.202", 1000, 500, 1);
        // }  

        StartShowUI();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Lỗi khởi động chương trình !");
        Environment.Exit(1);
      }
    }

    public void InitIdle()
    {
      _idle.TimeoutMinutes = AppCore.Ins._timeout_backhome_minute;

      _idle.Timeout += () =>
      {
        ShowHomePage();
      };
      _idle.Start();
    }

    public void ResetIdle()
    {
      _idle.Reset();
    }

    private void ShowHomePage()
    {
      if (AppCore.Ins._dataManager.EnumStepOperation != EnumStepOperation.Waiting)
      {
        AppCore.Ins._dataManager.EnumStepOperation = EnumStepOperation.Waiting;
        FrmMain.Instance.ChangePage(AppModulSupport.Waiting);
      }
    }

    public async Task StartData()
    {
      InitSyncDataServer();
      await LoadDataFirst();
      await StartPollingRemoveRecordExpiredAsync();
    }


    public List<ProductGroup> _materialGroups = new List<ProductGroup>();
    public List<Product> _materials = new List<Product>();
    public List<Product> _materialTares = new List<Product>();

    public List<Department> _departments = new List<Department>();
    public List<Employee> _employees = new List<Employee>();

    public List<Station> _machines = new List<Station>();
    public Station? _machineCurrent { get; set; }
    //public List<Factory> _factories = new List<Factory>();

    public Connection? _connectionsWeight { get; set; }
    public Connection? _connectionsHID { get; set; }


    public AppConfig _appConfig = new AppConfig();
    //public string _pathFileTemplate = Application.StartupPath + "Template\\TemplateDeliveryHtml.html";
    public string _pathFileTemplate = Application.StartupPath + "Template\\TemplateHtml.html";
    public string _pathFileTemplateTable01 = Application.StartupPath + "Template\\TemplateHtmlTable01.html";
    public string _pathFileTemplateTable02 = Application.StartupPath + "Template\\TemplateHtmlTable02.html";
    public string _folderOutput = Application.StartupPath + "Template\\OutputFiles";
    public string _folderFileLog = Application.StartupPath + "Logs";
    public async Task LoadDataConfig()
    {
      try
      {
        _appConfig = await AppCore.Ins.GetAppConfigAsync();

        _materialGroups = await GetMaterialGroupsAsync();
        _materials = await AppCore.Ins.GetMaterialsAsync();
        _materialTares = await GetMaterialTaresAsync();

        _departments = await AppCore.Ins.GetDepartmentsAsync();
        _employees = await AppCore.Ins.GetAllEmployeeAsync();

        //Thông tin các trạm cân và hiện tại
        _machines = await AppCore.Ins.GetMachinesAsync();
        _machineCurrent = _machines?.FirstOrDefault(x => x.Id == _appConfig?.MachineId);


        //Kết nối thiết bị
        var connection = await AppCore.Ins.GetConnectionAsync();
        _connectionsWeight = connection?.Where(x => x.eDevice == eDevice.WeightTcp).FirstOrDefault();
        _connectionsHID = connection?.Where(x => x.eDevice == eDevice.HidTcp).FirstOrDefault();

        //Thông tin đồng bộ dữ liệu
        _isSyncDataLocal = _appConfig?.IsAutoSyncData ?? false;
        _ipServer = Environment.GetEnvironmentVariable("DB_CONFIG_ADDRESS_SERVER");
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task ReloadEmployees()
    {
      _employees = await AppCore.Ins.GetAllEmployeeAsync();
    }

    public async Task ReloadDepartments()
    {
      _departments = await AppCore.Ins.GetDepartmentsAsync();
    }

    public async Task ReloadMaterialGroups()
    {
      _materialGroups = await GetMaterialGroupsAsync();
    }


    public async Task ReloadMaterials()
    {
      _materials = await GetMaterialsAsync();
      _materialTares = await GetMaterialTaresAsync();

      OnSendChangeTare?.Invoke(this, _materialTares);
    }

    public async Task ReloadMachines()
    {
      _machines = await AppCore.Ins.GetMachinesAsync();
    }

    public void LogAction(string name, eAction eAction)
    {
      try
      {
        LogAction logAction = new LogAction();
        logAction.Name = name;
        logAction.eAction = eAction;
        logAction.CreatedAt = DateTime.Now;
        AppCore.Ins.AddLogAction(logAction);
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }


    public string ConvertUcToZpl_Final01(Panel uc, int printerDpi = 203, double userScale = 1.0)
    {
      // Hệ số chuyển pixel -> dot (theo DPI) kết hợp scale tay
      double scale = (printerDpi / 96.0) * userScale;

      var sb = new System.Text.StringBuilder();
      sb.Append("^XA");
      sb.AppendLine("^PW800");
      sb.AppendLine("^LL1000");
      sb.AppendLine("^LH0,0");
      sb.AppendLine("^LS0");

      void TraverseControls(Control parent, int offsetX, int offsetY)
      {
        foreach (Control c in parent.Controls)
        {
          int x = (int)((offsetX + c.Left) * scale) - 30;
          int y = (int)((offsetY + c.Top) * scale);

          if (c is Label lbl)
          {
            int fontHeight = (int)(lbl.Font.Size * scale * 1.2);
            sb.AppendLine($"^FO{x},{y}^A0N,{fontHeight},0^FD{lbl.Text}^FS");
          }
          else if (c is TextBox txt)
          {
            int fontHeight = (int)(txt.Font.Size * scale * 1.2);
            sb.AppendLine($"^FO{x},{y}^A0N,{fontHeight},0^FD{txt.Text}^FS");
          }
          else if (c.Tag != null && c.Tag.ToString().StartsWith("BC:"))
          {
            string code = c.Tag.ToString().Substring(3);
            sb.AppendLine($"^FO{x},{y}^BCN,100,Y,N,N^FD{code}^FS");
          }
          else if (c.Tag != null && c.Tag.ToString().StartsWith("QR:"))
          {
            string qr = c.Tag.ToString().Substring(3);
            sb.AppendLine($"^FO{x},{y}^BQN,2,6^FDLA,{qr}^FS");
          }

          if (c.HasChildren)
            TraverseControls(c, offsetX + c.Left, offsetY + c.Top);
        }
      }

      TraverseControls(uc, 0, 0);
      sb.Append("^XZ");

      return sb.ToString();
    }


    public (string Name, string Code) ProcessingDataForDirectItem(DataLogPrintLabel? dataLogPrintLabel)
    {
      EnumMaterialType eMaterialType = (EnumMaterialType)(dataLogPrintLabel?.EnumMaterialType ?? 0);
      string code = "";
      string name = eMaterialType switch
      {
        EnumMaterialType.RawMaterial => "Nguyên liệu: ",
        EnumMaterialType.Material => "Vật tư: ",
        EnumMaterialType.FinshGoods => "Thành phẩm: ",
        EnumMaterialType.SemiFinishedGoods => "Bán thành phẩm: ",
        EnumMaterialType.Spice => "Gia vị:",
        EnumMaterialType.Chemical => "Hóa chất: ",
        EnumMaterialType.MRsDefect => "Phế phẩm: ",
        _ => "N/A"
      };

      if (eMaterialType == EnumMaterialType.MRsDefect)
      {
        name += (dataLogPrintLabel?.MaterialDefect?.Name ?? "N/A") + " " + (dataLogPrintLabel?.MaterialDefect?.Grade ?? "");
        code = $"Mã phế phẩm: {dataLogPrintLabel?.MaterialDefect?.Code ?? "N/A"}";
      }
      else if (eMaterialType == EnumMaterialType.RawMaterial)
      {
        name += (dataLogPrintLabel?.Material?.Name ?? "N/A") + " " + (dataLogPrintLabel?.Material?.Grade ?? "");
        code = $"Mã nguyên liệu: {dataLogPrintLabel?.Material?.Code ?? "N/A"}";
      }
      else if (eMaterialType == EnumMaterialType.Material)
      {
        name += (dataLogPrintLabel?.Material?.Name ?? "N/A") + " " + (dataLogPrintLabel?.Material?.Grade ?? "");
        code = $"Mã vật tư: {dataLogPrintLabel?.Material?.Code ?? "N/A"}";
      }
      else if (eMaterialType == EnumMaterialType.SemiFinishedGoods)
      {
        name += (dataLogPrintLabel?.Material?.Name ?? "N/A") + " " + (dataLogPrintLabel?.Material?.Grade ?? "");
        code = $"Mã bán thành phẩm: {dataLogPrintLabel?.Material?.Code ?? "N/A"}";
      }
      else if (eMaterialType == EnumMaterialType.FinshGoods)
      {
        name += (dataLogPrintLabel?.Material?.Name ?? "N/A") + " " + (dataLogPrintLabel?.Material?.Grade ?? "");
        code = $"Mã thành phẩm: {dataLogPrintLabel?.Material?.Code ?? "N/A"}";
      }

      return (name, code);
    }
  }

  public class ManagerData
  {
    public EnumStepOperation EnumStepOperation { get; set; } = EnumStepOperation.Waiting;
    public EnumModeFunction EnumModeFunction { get; set; } = EnumModeFunction.None;
    public EnumProductionOrderType EnumProductionOrderType { get; set; } = EnumProductionOrderType.None;
    public EnumProductionOrderCategory EnumProductionOrderCategory { get; set; } = EnumProductionOrderCategory.None;

    public EnumInternalExternalStatus EnumInternalExternalStatus { get; set; } = EnumInternalExternalStatus.None;
    public EnumExportImport EnumExportImport { get; set; }


    public DataLogPrintLabel DataLogPrintLabel = new DataLogPrintLabel();

    public DataLogDeliveryManager DataLogDelivery = new DataLogDeliveryManager();
    public Station? Machine { get; set; }
  }


  public class DataLogPrintLabel
  {
    public EnumMaterialType EnumMaterialType { get; set; }
    public double Net { get; set; } = 0;
    public double Tare { get; set; } = 0;
    public Employee? Employee { get; set; }
    public Product? Material { get; set; }
    public Product? MaterialDefect { get; set; }
    public List<Product?>? Materials { get; set; } = new List<Product?>();

    public EnumTypeTare TypeTare { get; set; } = EnumTypeTare.None;
    public Product? MaterialForTare { get; set; }
  }

  public class DataLogDeliveryManager
  {
    public Employee? EmployeeDelivery { get; set; }
    public Employee? EmployeeReceiving { get; set; }
    public Employee? EmployeeReceivingFirst { get; set; }
    public Employee? EmployeeQC { get; set; }
    public List<RecordFoods>? DatalogWeights { get; set; } = new List<RecordFoods>();
    public List<MaterialDeliveryDTO>? MaterialDelivaryDTOs { get; set; } = new List<MaterialDeliveryDTO>();
    public bool IsDelivery { get; set; }
  }

  public class MessageDataEvent
  {
    public long? ConnectionId { get; set; }
    public string? NameDevice { get; set; }
    public bool IsConnect { get; set; }

  }

  public class InforPrinter
  {
    public string? TitleLabel { get; set; }
    public double Net { get; set; } = 0;
    public double Tare { get; set; } = 0;
    public string? ProductionOrder { get; set; }
    public string? Operator { get; set; }
    public string? Department { get; set; }
    public string? Datetime { get; set; }
    public string? NameMR { get; set; }

    public bool IsDefect { get; set; } = false;
    public string? CodeMR { get; set; }
    public int NumberCopy { get; set; }
    public string? TareName { get; set; }

    public string? InternalExternal { get; set; }

  }









}
