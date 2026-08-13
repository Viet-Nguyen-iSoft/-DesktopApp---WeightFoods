using iSoft.Database.DTO;
using iSoft.Database.Models;
using LaborTrackPro.Controls;
using Org.BouncyCastle.Math.Field;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using static HelperManager.EnumData;
using static iSoft.Database.EnumData;
using static LaborTrackPro.Helper.DTO;
using Path = System.IO.Path;

namespace LaborTrackPro.Printer
{
  public class PrinterHelper
  {
    [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
    public static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

    [DllImport("winspool.Drv", EntryPoint = "ClosePrinter")]
    public static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
    public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] ref DOCINFOA di);

    [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter")]
    public static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter")]
    public static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter")]
    public static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true)]
    public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DOCINFOA
    {
      [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
      [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
      [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
    }

    /// <summary>
    /// Hàm dùng để gửi lệnh in cho máy in Zebra
    /// </summary>
    /// <param name="printerName"></param>
    /// <param name="zplCommand"></param>
    /// <returns></returns>
    public static bool SendStringToPrinter(string printerName, string zplCommand)
    {
      IntPtr hPrinter;
      DOCINFOA di = new DOCINFOA
      {
        pDocName = "Zebra Print Job",
        pDataType = "RAW"
      };

      if (OpenPrinter(printerName.Normalize(), out hPrinter, IntPtr.Zero))
      {
        if (StartDocPrinter(hPrinter, 1, ref di))
        {
          StartPagePrinter(hPrinter);
          IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(zplCommand);
          WritePrinter(hPrinter, pBytes, zplCommand.Length, out _);
          Marshal.FreeCoTaskMem(pBytes);
          EndPagePrinter(hPrinter);
          EndDocPrinter(hPrinter);
        }
        ClosePrinter(hPrinter);
        return true;
      }
      return false;
    }


    /// <summary>
    /// Hàm dùng để tạo nhiều file html theo phòng ban
    /// </summary>
    /// <param name="templatePath"></param>
    /// <param name="outputFolder"></param>
    /// <param name="informationDelivery"></param>
    /// <param name="contents"></param>
    /// 
    private static int GetLocalIndex(int no)
    {
      return ((no - 1) % 12) + 1;
    }
    public static async Task<(bool Check, int CntSumary)> GenerateHtmlFilesFromTemplate(string templatePath, string table, string tableSumary, string outputFolder, InformationDelivery informationDelivery, bool checkAlarm = false)
    {
      try
      {
        int cntSumaries = 1;
        bool unalarm = true;
        if (!File.Exists(templatePath))
        {
          throw new FileNotFoundException("Không tìm thấy file HTML!");
        }

        if (informationDelivery.DepartmentList == null || informationDelivery.DepartmentList?.Count() <= 0)
        {
          throw new FileNotFoundException("Không tìm thấy thông tin phòng ban!");
        }

        double totalWeight = Math.Round((double)informationDelivery.LaborProductivityRecognitions?.Sum(x => x.Net), 3);
        // Tạo thư mục đích nếu chưa tồn tại
        Directory.CreateDirectory(outputFolder);

        // Lặp qua danh sách contents
        string formNameVI = string.Empty;
        string formNameEN = string.Empty;

        string totalWeightVI = string.Empty;
        string totalWeightEN = string.Empty;

        if (informationDelivery.EnumInternalExternal == EnumInternalExternalStatus.Internal)
        {
          if (informationDelivery.EnumExportImport == EnumExportImport.Export)
          {
            //Nhận hàng
            formNameVI = "PHIẾU NHẬN HÀNG NỘI VI";
            formNameEN = "INTERNAL RECEIVING";

            totalWeightVI = "Tổng đã nhận";
            totalWeightEN = "Total received";
          }
          else if (informationDelivery.EnumExportImport == EnumExportImport.Import)
          {
            //Trả hàng
            formNameVI = "PHIẾU TRẢ HÀNG NỘI VI";
            formNameEN = "INTERNAL WAREHOUSE RETURN";

            totalWeightVI = "Tổng đã trả";
            totalWeightEN = "Total returned";
          }
        }
        else
        {
          if (informationDelivery.EnumExportImport == EnumExportImport.Export)
          {
            //Xuất hàng
            formNameVI = "PHIẾU XUẤT HÀNG NGOẠI VI";
            formNameEN = "EXTERNAL GOODS ISSUE";

            totalWeightVI = "Tổng đã xuất";
            totalWeightEN = "Total issued";
          }
          else if (informationDelivery.EnumExportImport == EnumExportImport.Import)
          {
            //Nhập hàng
            formNameVI = "PHIẾU NHẬP HÀNG NGOẠI VI";
            formNameEN = "EXTERNAL GOODS RECEIPT";

            totalWeightVI = "Tổng đã nhập";
            totalWeightEN = "Total received";
          }
        }


        foreach (var content in informationDelivery.DepartmentList)
        {
          // Đọc nội dung template HTML
          string template = File.ReadAllText(templatePath);
          string templateTable = File.ReadAllText(table);
          string templateTableSumary = File.ReadAllText(tableSumary);

          string result = template.Replace("{department}", content)

                                  .Replace("{form_name_vi}", formNameVI)
                                  .Replace("{form_name_en}", formNameEN)
                                  .Replace("{total_weight_vi}", totalWeightVI)
                                  .Replace("{total_weight_en}", totalWeightEN)
                                  .Replace("{product_order}", informationDelivery?.PO)
                                  .Replace("{dt1}", informationDelivery?.Datetime.ToString("dd/MM/yyyy"))
                                  .Replace("{dt2}", informationDelivery?.Datetime.ToString("HH:mm dd/MM/yyyy"))

                                  .Replace("{department_delivered}", informationDelivery?.DeliveryEmployee?.Departments?.FirstOrDefault()?.Name)
                                  .Replace("{full_name_delivered}", informationDelivery?.DeliveryEmployee?.FullName)

                                  .Replace("{department_received}", informationDelivery?.ReceivingEmployee?.Departments?.FirstOrDefault()?.Name)
                                  .Replace("{full_name_received}", informationDelivery?.ReceivingEmployee?.FullName)

                                  .Replace("{full_name_warehouse}", informationDelivery?.ReceivingEmployee?.FullName)

                                  .Replace("{full_name_qc}", informationDelivery?.QCEmployee?.FullName)

                                  .Replace("{totalPage}", $"{informationDelivery?.DepartmentList.Length ?? 0}")
                                  .Replace("{NoPage}", $"");

          List<MaterialSummaryDTO>? summaries = informationDelivery?.MaterialDelivaryDTOs
                                              .Where(x => x.MaterialDefect != null || x.Material != null)
                                              .GroupBy(x => new
                                              {
                                                // Phân biệt cùng một Id nhưng thuộc hai nhóm khác nhau
                                                IsDefect = x.MaterialDefect != null,

                                                MaterialId = x.MaterialDefect != null
                                                      ? x.MaterialDefect.Id
                                                      : x.Material!.Id
                                              })
                                              .Select(group =>
                                              {
                                                MaterialDeliveryDTO first = group.First();

                                                return new MaterialSummaryDTO
                                                {
                                                  Material = first.Material,

                                                  MaterialDefect = group.Key.IsDefect
                                                        ? first.MaterialDefect
                                                        : null,

                                                  Code = first.CodeMaterial,
                                                  Name = first.NameMaterial,

                                                  TotalWeight = group.Sum(x => x.NetValue ?? 0),

                                                  MaterialDeliveryDTOs = group.ToList()
                                                };
                                              })
                                              .ToList();

          cntSumaries = summaries?.Count()??1;
          string tableDetails = string.Empty;
          string tableSumaries = string.Empty;
          if (summaries!=null && summaries?.Count()>0)
          {
            int no_detail = 1;
            int no_sumary = 1;
            foreach (var sumary in summaries)
            {
              MaxValueCheckAlarm maxValue = new MaxValueCheckAlarm();
              bool mrDefect = sumary.MaterialDefect != null;
              Material? material = sumary?.Material;

              if (informationDelivery?.EnumInternalExternal == EnumInternalExternalStatus.Internal)
              {
                
                maxValue = await AppCore.Ins.GetMaxValueInternal(informationDelivery?.ProductionOrder,
                                                                                    informationDelivery?.Machine,
                                                                                    material,
                                                                                    informationDelivery?.DeliveryEmployee?.Departments?.FirstOrDefault()?.IdSrc,
                                                                                    informationDelivery?.ReceivingEmployee?.Departments?.FirstOrDefault()?.IdSrc,
                                                                                    informationDelivery?.EnumTyCheckAlarm,
                                                                                    mrDefect);
              }
              else
              {
                maxValue = await AppCore.Ins.GetMaxValueExternal(informationDelivery?.ProductionOrder,
                  informationDelivery?.Machine,
                  material,
                  informationDelivery?.EnumExportImport
                  );
              }

              double bonusSaiso = 0.0;

              //Detail 
              var dataTable = sumary?.MaterialDeliveryDTOs?.ToArray();

              if (dataTable?.Count() > 0)
              {
                for (int no = 1; no <= dataTable?.Count(); no++)
                {
                  string tempTableDetal = templateTable;
                  tempTableDetal = tempTableDetal.Replace("{no}", (no_detail++).ToString("D2"));
                  tempTableDetal = tempTableDetal.Replace("{code}", dataTable?[no - 1].CodeMaterial ?? "");
                  tempTableDetal = tempTableDetal.Replace("{name}", dataTable?[no - 1].NameMaterial ?? "");
                  //tempTableDetal = tempTableDetal.Replace("{description}", dataTable?[no - 1].DescriptionMaterial ?? "");
                  tempTableDetal = tempTableDetal.Replace("{description}", BreakLineByLength(dataTable?[no - 1].DescriptionMaterial ?? "", 17));

                  tempTableDetal = tempTableDetal.Replace("{unit}", dataTable?[no - 1].Unit ?? "");
                  tempTableDetal = tempTableDetal.Replace("{qty}", dataTable?[no - 1].Quality ?? "");
                  tempTableDetal = tempTableDetal.Replace("{weight}", dataTable?[no - 1].Net ?? "");
                  tempTableDetal = tempTableDetal.Replace("{operator}", dataTable?[no - 1].Operator ?? "");
                  tempTableDetal = tempTableDetal.Replace("{time_weight}", ((DateTime)dataTable[no - 1]?.CreatedAt).ToString("dd/MM/yyyy HH:mm:ss") ?? "");
                  tempTableDetal = tempTableDetal.Replace("{lot}", "");

                  tableDetails = tableDetails + tempTableDetal;

                  if ((dataTable?[no - 1].GrossValue ?? 0.0) <= 1000.0)
                  {
                    double saiso = 35.0 / 1000.0;
                    bonusSaiso += saiso;
                  }
                  else
                  {
                    double saiso = 60.0 / 1000.0;
                    bonusSaiso += saiso;
                  }
                }
              }

              //Sumary
              string tempSumary = templateTableSumary;
              tempSumary = tempSumary.Replace("{no_sum}", no_sumary.ToString("D2"));
              tempSumary = tempSumary.Replace("{code_sum}", sumary?.Code ?? "");
              tempSumary = tempSumary.Replace("{name_sum}", sumary?.Name ?? "");
              tempSumary = tempSumary.Replace("{weight_sum}", (sumary?.TotalWeight ?? 0.0).ToString("F3"));

              //Check cảnh báo
              bool check = (maxValue?.CheckAlarm ?? false) && (informationDelivery?.IsCheckAlarm ?? false);
              if ((sumary?.TotalWeight ?? 0.0) > ((maxValue?.MaxValue ?? 0.0) + bonusSaiso) && check)
              {
                tempSumary = tempSumary.Replace("{color_row}", "FF6A6A");
                unalarm = false;
              }
              else
              {
                tempSumary = tempSumary.Replace("{color_row}", "FFFFFF");
              }

              string total = $"{((maxValue?.TotalActualInKg ?? 0.0) + (sumary?.TotalWeight ?? 0.0)).ToString("F3")} / {((maxValue?.SettingInKg ?? 0.0).ToString("F3"))}";
              tempSumary = tempSumary.Replace("{total_received_sum}", total);

              tableSumaries = tableSumaries + tempSumary;

              no_sumary++;
            }
          }  













          //var dataTable = informationDelivery?.MaterialDelivaryDTOs?.ToArray();

          
          
          //for (int no = 1; no <= dataTable?.Count(); no++)
          //{
          //  string temp = templateTable;
          //  temp = temp.Replace("{no}", no.ToString());
          //  temp = temp.Replace("{code}", dataTable?[no - 1].CodeMaterial ?? "");
          //  temp = temp.Replace("{name}", dataTable?[no - 1].NameMaterial ?? "");
          //  temp = temp.Replace("{description}", dataTable?[no - 1].DescriptionMaterial ?? "");
          //  temp = temp.Replace("{unit}", dataTable?[no - 1].Unit ?? "");
          //  temp = temp.Replace("{qty}", dataTable?[no - 1].Quality ?? "");
          //  temp = temp.Replace("{weight}", dataTable?[no - 1].Net ?? "");
          //  temp = temp.Replace("{operator}", dataTable?[no - 1].Operator ?? "");
          //  temp = temp.Replace("{time_weight}", ((DateTime)dataTable[no - 1]?.CreatedAt).ToString("dd/MM/yyyy HH:mm:ss") ?? "");
          //  temp = temp.Replace("{lot}", "");

          //  tables = tables + temp;

          //  //if (informationDelivery?.MaxValueCheckAlarm!=null)
          //  //{
          //  //  if ((dataTable?[no - 1].GrossValue ?? 0.0) <= 1000.0)
          //  //  {
          //  //    double saiso = ((informationDelivery?.MaxValueCheckAlarm?.ToleranceBelowTon) ?? 0.0) / 1000.0;
          //  //    bonusSaiso += saiso;
          //  //  }
          //  //  else
          //  //  {
          //  //    double saiso = ((informationDelivery?.MaxValueCheckAlarm?.TolerancePerTon) ?? 0.0) / 1000.0;
          //  //    bonusSaiso += saiso;
          //  //  }
          //  //}

          //  if ((dataTable?[no - 1].GrossValue ?? 0.0) <= 1000.0)
          //  {
          //    double saiso = 35.0 / 1000.0;
          //    bonusSaiso += saiso;
          //  }
          //  else
          //  {
          //    double saiso = 60.0 / 1000.0;
          //    bonusSaiso += saiso;
          //  }
          //}

          /////
          //var sumarys = dataTable?
          //            .GroupBy(x => new
          //            {
          //              x.Material,
          //              x.CodeMaterial,
          //              x.NameMaterial
          //            })
          //            .Select(g => new MaterialSummaryDTO
          //            {
          //              Material = g.Key.Material,
          //              Code = g.Key.CodeMaterial,
          //              Name = g.Key.NameMaterial,
          //              TotalWeight = g.Sum(x =>
          //              {
          //                double.TryParse(x.Net, out double net);
          //                return net;
          //              })
          //            })
          //            .ToList();

         
         
          //foreach (var sumary in sumarys)
          //{
          //  Material? material = sumary?.Material; 
          //  bool mrDefect = material?.MaterialType == (int)EnumMaterialType.MRsDefect;
          //  MaxValueCheckAlarm maxValue = await AppCore.Ins.GetMaxValueInternal(informationDelivery?.ProductionOrder,
          //                                                                      informationDelivery?.Machine,
          //                                                                      material,
          //                                                                      informationDelivery?.DeliveryEmployee?.Departments?.FirstOrDefault()?.IdSrc,
          //                                                                      informationDelivery?.ReceivingEmployee?.Departments?.FirstOrDefault()?.IdSrc,
          //                                                                      informationDelivery?.EnumTyCheckAlarm, 
          //                                                                      mrDefect);



          //  string temp = templateTableSumary;
          //  temp = temp.Replace("{no_sum}", no_sumary.ToString("D2"));
          //  temp = temp.Replace("{code_sum}", sumary?.Code ?? "");
          //  temp = temp.Replace("{name_sum}", sumary?.Name ?? "");
          //  temp = temp.Replace("{weight_sum}", (sumary?.TotalWeight ?? 0.0).ToString("F3"));
          //  //temp = temp.Replace("{total_received}", dataTable?[no - 1].Unit ?? "");

          //  //Check cảnh báo
          //  if ((sumary?.TotalWeight ?? 0.0) > ((maxValue?.MaxValue ?? 0.0) + bonusSaiso) && maxValue?.CheckAlarm == true)
          //  {
          //    result = result.Replace("{color_row}", "FF6A6A");
          //    unalarm = false;
          //  }
          //  else
          //  {
          //    result = result.Replace("{color_row}", "FFFFFF");
          //  }

          //  string total = $"{((maxValue?.TotalActualInKg ?? 0.0) + (sumary?.TotalWeight ?? 0.0)).ToString("F3")} / {((maxValue?.SettingInKg ?? 0.0).ToString("F3"))}";
          //  result = result.Replace("{total_received_sum}", total);

          //  tableSumaries = tableSumaries + temp;
          //}

          //Sumary
          //var sumaryFirst = sumarys?.FirstOrDefault();
          //result = result.Replace("{code_sum}", sumaryFirst?.Code ?? "");
          //result = result.Replace("{name_sum}", sumaryFirst?.Name ?? "");
          //result = result.Replace("{sum_weight}", (Math.Round(sumaryFirst?.TotalWeight ?? 0.0, 3)).ToString("F3") ?? "");

          //Check cảnh báo
          //if ((sumaryFirst?.TotalWeight ?? 0.0) > ((informationDelivery?.MaxValueCheckAlarm?.MaxValue ?? 0.0) + bonusSaiso) && informationDelivery?.MaxValueCheckAlarm?.CheckAlarm == true)
          //{
          //  result = result.Replace("{color_row}", "FF6A6A");
          //  unalarm = false;
          //}
          //else
          //{
          //  result = result.Replace("{color_row}", "FFFFFF");
          //}

          //string total = $"{((informationDelivery?.MaxValueCheckAlarm?.TotalActualInKg ?? 0.0) + (sumaryFirst?.TotalWeight ?? 0.0)).ToString("F3")} / {((informationDelivery?.MaxValueCheckAlarm?.SettingInKg ?? 0.0).ToString("F3"))}";
          //result = result.Replace("{total_received}", total);

          result = result.Replace("{table}", tableDetails);
          result = result.Replace("{table_sumary}", tableSumaries);

          //Kiểu PO
          switch (informationDelivery?.ProductionOrder?.ProductionOrderType)
          {
            case EnumProductionOrderType.LenhSanXuat:
              result = result.Replace("{product_order_type_vi}", "Lệnh sản xuất");
              result = result.Replace("{product_order_type_en}", "Production Order");
              break;
            case EnumProductionOrderType.LenhThuNghiem:
              result = result.Replace("{product_order_type_vi}", "Lệnh thử nghiệm");
              result = result.Replace("{product_order_type_en}", "Trial Order");
              break;
            case EnumProductionOrderType.LenhDuPhong:
              result = result.Replace("{product_order_type_vi}", "Lệnh dự phòng");
              result = result.Replace("{product_order_type_en}", "Reserve Stock Order");
              break;
            case EnumProductionOrderType.LenhLayMau:
              result = result.Replace("{product_order_type_vi}", "Lệnh lấy mẫu");
              result = result.Replace("{product_order_type_en}", "Sample Order");
              break;
            default:
              result = result.Replace("{product_order_type_vi}", "Lệnh sản xuất");
              result = result.Replace("{product_order_type_en}", "Production Order");
              break;
          }

          // Đặt tên file xuất ra, ví dụ: Sales.html, HR.html, IT.html
          string outputPath = Path.Combine(outputFolder, $"{content}.html");

          // Ghi file ra đĩa
          File.WriteAllText(outputPath, result);
        }

        return (unalarm, cntSumaries);
      }
      catch (Exception)
      {
        throw;
      }
    }

    private static string BreakLineByLength(string? text, int length = 20)
    {
      if (string.IsNullOrEmpty(text))
        return string.Empty;

      return string.Join(
          "<br/>",
          Enumerable.Range(0, (text.Length + length - 1) / length)
              .Select(i => text.Substring(
                  i * length,
                  Math.Min(length, text.Length - i * length)))
      );
    }

    public static bool GenerateHtmlFilesFromTemplateV2(string templatePath, string table01, string outputFolder, InformationDelivery informationDelivery)
    {
      try
      {
        bool unalarm = true;
        if (!File.Exists(templatePath))
        {
          throw new FileNotFoundException("Không tìm thấy file HTML!");
        }

        if (informationDelivery.DepartmentList == null || informationDelivery.DepartmentList?.Count() <= 0)
        {
          throw new FileNotFoundException("Không tìm thấy thông tin phòng ban!");
        }

        int N = informationDelivery.LaborProductivityRecognitions?.Count() ?? 0;
        int numberPage = (N + 12 - 1) / 12;
        int numberCopy = informationDelivery.DepartmentList?.Count() ?? 0;
        double totalWeight = Math.Round((double)informationDelivery.LaborProductivityRecognitions?.Sum(x => x.Net), 3);
        // Tạo thư mục đích nếu chưa tồn tại
        Directory.CreateDirectory(outputFolder);

        // Lặp qua danh sách contents
        int numberPageCurrent = 0;
        foreach (var content in informationDelivery.DepartmentList)
        {
          numberPageCurrent++;
          // Đọc nội dung template HTML
          string template = File.ReadAllText(templatePath);
          string templateTable01 = File.ReadAllText(table01);

          string result = template.Replace("{Department}", content)
                                  //.Replace("{Internal ☐}", informationDelivery?.IsInternal == true ? "☑" : "□")
                                  //.Replace("{External ☐}", informationDelivery?.IsInternal == false ? "☑" : "□")
                                  .Replace("{ProductOder}", informationDelivery?.PO)
                                  .Replace("{DT1}", informationDelivery?.Datetime.ToString("dd/MM/yyyy"))
                                  .Replace("{DT2}", informationDelivery?.Datetime.ToString("HH:mm dd/MM/yyyy"))

                                  .Replace("{DeliveryDepartment}", informationDelivery?.DeliveryEmployee?.Departments?.FirstOrDefault()?.Name)
                                  .Replace("{DeliveryName}", informationDelivery?.DeliveryEmployee?.FullName)
                                  .Replace("{ReceiveDepartment}", informationDelivery?.ReceivingEmployee?.Departments?.FirstOrDefault()?.Name)
                                  .Replace("{ReceiveName}", informationDelivery?.ReceivingEmployee?.FullName)
                                  .Replace("{QCName}", informationDelivery?.QCEmployee?.FullName)
                                  .Replace("{NumberPage}", $"{numberPageCurrent}/{numberCopy}")
                                  .Replace("{totalPage}", $"{informationDelivery?.DepartmentList.Length ?? 0}")
                                  .Replace("{NoPage}", $"");

          var dataTable = informationDelivery?.MaterialDelivaryDTOs?.ToArray();

          string tables01 = string.Empty;

          for (int no = 1; no <= dataTable?.Count(); no++)
          {
            int index = 1;
            string temp = templateTable01;
            temp = temp.Replace("{no" + (index).ToString("00") + "}", no.ToString());
            temp = temp.Replace("{code" + (index).ToString("00") + "}", dataTable?[no - 1].CodeMaterial ?? "");
            temp = temp.Replace("{name" + (index).ToString("00") + "}", dataTable?[no - 1].NameMaterial ?? "");
            temp = temp.Replace("{description" + (index).ToString("00") + "}", dataTable?[no - 1].DescriptionMaterial ?? "");
            temp = temp.Replace("{unit" + (index).ToString("00") + "}", dataTable?[no - 1].Unit ?? "");
            temp = temp.Replace("{quantity" + (index).ToString("00") + "}", dataTable?[no - 1].Quality ?? "");
            temp = temp.Replace("{weight" + (index).ToString("00") + "}", dataTable?[no - 1].Net ?? "");
            temp = temp.Replace("{person" + (index).ToString("00") + "}", dataTable?[no - 1].Operator ?? "");
            temp = temp.Replace("{time" + (index).ToString("00") + "}", ((DateTime)dataTable[no - 1]?.CreatedAt).ToString("dd/MM/yyyy HH:mm:ss") ?? "");
            temp = temp.Replace("{lot" + (index).ToString("00") + "}", "");

            tables01 = tables01 + temp;
          }

          /////
          string tables02 = string.Empty;
          var sumary = dataTable?
                      .GroupBy(x => new
                      {
                        x.Material,
                        x.CodeMaterial,
                        x.NameMaterial
                      })
                      .Select(g => new MaterialSummaryDTO
                      {
                        Material = g.Key.Material,
                        Code = g.Key.CodeMaterial,
                        Name = g.Key.NameMaterial,
                        TotalWeight = g.Sum(x =>
                        {
                          double.TryParse(x.Net, out double net);
                          return net;
                        })
                      })
                      .ToList();

          bool check = informationDelivery?.DeliveryEmployee != null &&
                            informationDelivery?.ReceivingEmployee != null &&
                            informationDelivery?.QCEmployee != null;


          result = result.Replace("{table01}", tables01);
          result = result.Replace("{table02}", tables02);

          // Đặt tên file xuất ra, ví dụ: Sales.html, HR.html, IT.html
          string outputPath = Path.Combine(outputFolder, $"{content}.html");

          // Ghi file ra đĩa
          File.WriteAllText(outputPath, result);
        }

        return unalarm;
      }
      catch (Exception)
      {
        throw;
      }
    }

    //private static async Task<double> GetMaxValue(ProductionOrder productionOrder, Machine machine, Material material)
    //{
    //  try
    //  {
    //    bool unvalid = productionOrder == null || machine == null || material == null;
    //    if (unvalid)
    //    {
    //      return -404;
    //    }

    //    GetMaxAllowedValueRequestModel getMaxAllowedValueRequestModel = new GetMaxAllowedValueRequestModel();
    //    getMaxAllowedValueRequestModel.ProductionOrderId = productionOrder.IdSrc;
    //    getMaxAllowedValueRequestModel.DataMachineId = machine.IdSrc;
    //    getMaxAllowedValueRequestModel.MaterialId = material.IdSrc;

    //    string json = JsonHelper.ToJson(getMaxAllowedValueRequestModel);
    //    var rs = await AppCore.Ins.GetMaxWeightExport(getMaxAllowedValueRequestModel);

    //    if (rs.Status == "Success")
    //    {
    //      return rs.Data.MaxValue;
    //    }
    //    else
    //    {
    //      return -404;
    //    }
    //  }
    //  catch (Exception)
    //  {
    //    return -404;
    //  }
    //}


    /// <summary>
    /// In một file qua tên máy in cụ thể.
    /// </summary>
    /// <param name="filePath">Đường dẫn đầy đủ tới file cần in.</param>
    /// <param name="printerName">Tên máy in (ví dụ: "Microsoft Print to PDF").</param>
    public static void PrintFile(string filePath, string printerName)
    {
      if (!File.Exists(filePath))
      {
        Console.WriteLine("❌ Không tìm thấy file cần in.");
        return;
      }

      try
      {
        ProcessStartInfo psi = new ProcessStartInfo
        {
          FileName = filePath,
          Verb = "PrintTo",
          Arguments = $"\"{printerName}\"",
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden
        };

        using (Process p = new Process())
        {
          p.StartInfo = psi;
          p.Start();
          p.WaitForExit(10000); // đợi tối đa 10 giây
        }

        Console.WriteLine($"✅ Đã gửi lệnh in tới máy in: {printerName}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"⚠️ Lỗi khi in: {ex.Message}");
      }
    }



    public static void PrinterLabel(string printer, DTOPrintLabel dTOPrintLabel)
    {
      try
      {
        Brush brush = Brushes.Black;
        Font fontTitlePhieuCan = new Font("Arial", 20, FontStyle.Bold);

        Font fontTitle = new Font("Arial", 12, FontStyle.Regular);
        Font fontData = new Font("Arial", 12, FontStyle.Bold);
        Font fontDataMR = new Font("Arial", 10, FontStyle.Bold);
        Font fontDataLittle = new Font("Arial", 10, FontStyle.Bold);


        // 30–60: rất mờ | 80–120: mờ vừa
        Brush watermarkBrush = new SolidBrush(Color.FromArgb(80, Color.Black));
        Font watermarkFont = new Font("Arial", 40, FontStyle.Bold);

        PrintDocument pd = new PrintDocument();
        pd.PrinterSettings.PrinterName = printer;
        pd.DefaultPageSettings.PaperSize = new PaperSize("Label80x100", 315, 394);
        //pd.DefaultPageSettings.PaperSize = new PaperSize("Label80x100", 415, 394);
        pd.DefaultPageSettings.Margins = new Margins(30, 0, 0, 0);

        int startY = 60;
        int startX = 60;
        int offset_Y = 30;

        startX = 10;

        pd.PrintPage += (sender, e) =>
        {
          e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
          e.Graphics.TranslateTransform(-e.PageSettings.HardMarginX, -e.PageSettings.HardMarginY);
          // ===== WATERMARK MỜ =====
          if (dTOPrintLabel.IsDefect)
          {
            e.Graphics.TranslateTransform(60, 220);
            e.Graphics.RotateTransform(-40);

            e.Graphics.DrawString(
                "PHE PHAM",
                watermarkFont,
                watermarkBrush,
                0,
                0
            );

            e.Graphics.ResetTransform();
          }

          e.Graphics.DrawString("PHIẾU CÂN", fontTitlePhieuCan, brush, new PointF(80, 15));

          int k = 0;

          e.Graphics.DrawString("Lệnh sản xuất:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y))); k++;
          e.Graphics.DrawString(dTOPrintLabel.PoName, fontDataLittle, brush, new PointF(startX, startY - 5 + (k * offset_Y))); k++;

          e.Graphics.DrawString(dTOPrintLabel.Material, fontDataMR, brush, new PointF(startX, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Mã nguyên liệu:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.CodeMaterial, fontData, brush, new PointF(startX + 120, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Net:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.Net, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Ngày:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.Date, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Người cân:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.OpName, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;

          e.Graphics.DrawString("Phòng ban:", fontTitle, brush, new PointF(startX, startY + (k * offset_Y)));
          e.Graphics.DrawString(dTOPrintLabel.Department, fontData, brush, new PointF(startX + 90, startY + (k * offset_Y))); k++;
        };

        pd.Print();
      }
      catch (Exception)
      {
        throw;
      }
    }


  }

  public class DTOPrintLabel
  {
    public string? TitleLabel { get; set; }
    public string? PoName { get; set; }
    public string? Material { get; set; }
    public string? CodeMaterial { get; set; }
    public string? Net { get; set; }
    public string? Date { get; set; }
    public string? OpName { get; set; }
    public string? Department { get; set; }
    public string? TareName { get; set; }

    public bool IsDefect { get; set; } = false;
    public string? InternalExternal { get; set; }

  }
}
