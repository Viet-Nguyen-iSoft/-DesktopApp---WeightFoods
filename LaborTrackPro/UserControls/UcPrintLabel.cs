using HelperManager;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using LaborTrackPro.Custom;
using static LaborTrackPro.EnumData;

namespace LaborTrackPro.UserControls
{
  public partial class UcPrintLabel : UserControl
  {
    public UcPrintLabel()
    {
      InitializeComponent();
      CustomUI();
    }
    private void CustomUI()
    {
      ElipseControl elipseControl01 = new ElipseControl();
      elipseControl01.CornerRadius = 10;
      elipseControl01.TargetControl = panel1;

      ElipseControl elipseControl02 = new ElipseControl();
      elipseControl02.CornerRadius = 10;
      elipseControl02.TargetControl = this;
    }

    public Size SizeCus
    {
      set
      {
        this.Size = value;
      }
    }

    public void ShowInforOnLabel(InforPrinter inforPrinter)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          ShowInforOnLabel(inforPrinter);
        }));
        return;
      }

      try
      {
        this.lbNameLabel.Text = inforPrinter.TitleLabel;
        this.lbPO.Text = inforPrinter.ProductionOrder;
        this.lbMRName.Text = inforPrinter.NameMR;
        this.lbMRCode.Text = inforPrinter.CodeMR;
        this.lbNet.Text = $"{inforPrinter.Net} Kg";
        this.lbDate.Text = inforPrinter.Datetime;
        this.lbOperator.Text = inforPrinter.Operator;
        this.lbDepartment.Text = inforPrinter.Department;
        this.lbTare.Text = inforPrinter.TareName;
        this.lbInternalExternal.Text = inforPrinter.InternalExternal;
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    public Color BackColorUc
    {
      set
      {
        this.BackColor = value;
      }
    }

    private InforPrinter? _inforPrinter { get; set; }

    
   
    public void PrintSuccess()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          PrintSuccess();
        }));
        return;
      }
      picStatus.Visible = true;
    }

    public void UpdateInfor(InforPrinter? inforPrinter)
    {
      try
      {
        _inforPrinter = inforPrinter;
        UpdateValueOnLabel(eTagData.ProductionOrder, $"{inforPrinter?.ProductionOrder ?? "N/A"}");
        UpdateValueOnLabel(eTagData.Operator, $"{inforPrinter?.Operator ?? "N/A"}");
        UpdateValueOnLabel(eTagData.Department, $"{inforPrinter?.Department ?? "N/A"}");
        UpdateValueOnLabel(eTagData.Tare, $"{inforPrinter?.Tare ?? 0}  kg");
        UpdateValueOnLabel(eTagData.Net, $"{inforPrinter?.Net ?? 0}  kg");
        UpdateValueOnLabel(eTagData.Gross, $"{Math.Round((double)(inforPrinter.Tare + inforPrinter.Net), 2)}  kg");
        UpdateValueOnLabel(eTagData.Datetime, $"{inforPrinter?.Datetime ?? "N/A"}");
        UpdateValueOnLabel(eTagData.ItemProduct, $"{inforPrinter?.NameMR ?? "N/A"}");
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

    public void UpdateDepartment(string department)
    {
      UpdateValueOnLabel(eTagData.Department, department);
      _inforPrinter.Department = department;
    }


    public void UpdateProductionOrder(ProductionOrder? productionOrder)
    {
      UpdateValueOnLabel(eTagData.ProductionOrder, $"{productionOrder?.Name ?? "N/A"}");
    }
    public void UpdateEmployee(Employee? employee)
    {
      UpdateValueOnLabel(eTagData.Operator, $"{employee?.FullName ?? "N/A"}");
      UpdateValueOnLabel(eTagData.Department, $"{employee?.Departments?.FirstOrDefault()?.Name ?? "N/A"}");
    }
    public void UpdateDirectItem(string data)
    {
      UpdateValueOnLabel(eTagData.ItemProduct, data);
    }

    public void UpdateValueWeight(double tare, double net)
    {
      UpdateValueOnLabel(eTagData.Tare, $"{Math.Round(tare, 3)}  kg");
      UpdateValueOnLabel(eTagData.Net, $"{Math.Round(net, 3)}  kg");
      UpdateValueOnLabel(eTagData.Gross, $"{Math.Round(tare + net, 3)}  kg");
      UpdateValueOnLabel(eTagData.Datetime, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }
    public void UpdateDatetime()
    {
      UpdateValueOnLabel(eTagData.Datetime, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }

    private void UpdateValueOnLabel(eTagData eTagData, string value)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          UpdateValueOnLabel(eTagData, value);
        }));
        return;
      }
      try
      {
        string value_replace = string.Empty;
        switch (eTagData)
        {
          case EnumData.eTagData.Net:
            value_replace = "lbNet";
            break;
          case EnumData.eTagData.Tare:
            value_replace = "lbTare";
            break;
          case EnumData.eTagData.Gross:
            value_replace = "lbGross";
            break;
          case EnumData.eTagData.ProductionOrder:
            value_replace = "lbProductionOrder";
            break;
          case EnumData.eTagData.Operator:
            value_replace = "lbOperator";
            break;
          case EnumData.eTagData.Datetime:
            value_replace = "lbDatetime";
            break;
          case EnumData.eTagData.Department:
            value_replace = "lbDepartment";
            break;
          case EnumData.eTagData.ItemProduct:
            value_replace = "lbItemProduct";
            break;
        }

        var labels = panel1.Controls.OfType<Label>()
                                    .Where(l => l.Name == value_replace).ToList();
        if (labels?.Count > 0)
        {
          foreach (var label in labels)
          {
            if (label.Text != value)
              label.Text = value;
          }
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
      }
    }

  }
}
