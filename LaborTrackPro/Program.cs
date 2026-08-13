using HelperManager;
using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using LaborTrackPro.Controls;
using static HelperManager.EnumData;

namespace LaborTrackPro
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();

      //Khởi tạo Db
      InitDb().GetAwaiter().GetResult();

      //Log Start App
      AppCore.Ins.LogAction("Start App", eAction.StartApp);
#if RELEASE
      PdfHelper.InitAsync().GetAwaiter().GetResult();
#endif

      //Start Form
      AppCore.Ins.Init();
#if RELEASE
      PdfHelper.DisposeAsync().GetAwaiter().GetResult();
#endif
    }

    public static void StartApp()
    {
      Application.Restart();
    }

    public static void CloseApp()
    {
      Application.Exit();
    }

    static async Task<bool> InitDb()
    {
      try
      {
        using (var db = new PostgresDbContext())
        {
          try
          {
            await db.Database.EnsureCreatedAsync();
            await db.Database.BeginTransactionAsync();

            if (db?.AppConfigs?.Count() <= 0)
            {
              await db.AppConfigs.AddAsync(new AppConfig
              {
                IpServer = "10.0.0.45", //"100.101.165.42",
                PortServer = 6902,
                MachineCode = "HSF01",
                //JsonConfigLabelPrint = "[{\"Text\":\"PHIEU CAN\",\"X\":88,\"Y\":19,\"FontName\":\"Times New Roman\",\"FontSize\":16,\"FontStyle\":0,\"Tag\":\"PHIEU CAN\"},{\"Text\":\"Nguoi Can:\",\"X\":3,\"Y\":298,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Nguoi Can:\"},{\"Text\":\"Gross:\",\"X\":3,\"Y\":106,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Gross:\"},{\"Text\":\"Net:\",\"X\":3,\"Y\":154,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Net:\"},{\"Text\":\"Tare:\",\"X\":3,\"Y\":204,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Tare:\"},{\"Text\":\"Ngay:\",\"X\":4,\"Y\":251,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Ngay:\"},{\"Text\":\"Phong ban:\",\"X\":3,\"Y\":344,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Phong ban:\"},{\"Text\":\"Lenh san xuat:\",\"X\":3,\"Y\":60,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Lenh san xuat:\"},{\"Text\":\"{Net}\",\"X\":120,\"Y\":153,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Net}\"},{\"Text\":\"{Tare}\",\"X\":121,\"Y\":204,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Tare}\"},{\"Text\":\"{Gross}\",\"X\":121,\"Y\":104,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Gross}\"},{\"Text\":\"{Lenh san xuat}\",\"X\":120,\"Y\":61,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{L\\u1EC7nh s\\u1EA3n xu\\u1EA5t}\"},{\"Text\":\"{Nguoi can}\",\"X\":122,\"Y\":297,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Ng\\u01B0\\u1EDDi c\\u00E2n}\"},{\"Text\":\"{Thoi gian}\",\"X\":120,\"Y\":254,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Th\\u1EDDi gian}\"},{\"Text\":\"{Phong ban}\",\"X\":121,\"Y\":345,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Ph\\u00F2ng ban}\"}]",
                JsonConfigLabelPrint = "[{\"Text\":\"PHIEU CAN\",\"X\":88,\"Y\":19,\"FontName\":\"Times New Roman\",\"FontSize\":16,\"FontStyle\":0,\"Tag\":\"PHIEU CAN\"},{\"Text\":\"Nguoi Can:\",\"X\":3,\"Y\":221,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Nguoi Can:\"},{\"Text\":\"Net:\",\"X\":3,\"Y\":141,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Net:\"},{\"Text\":\"Ngay:\",\"X\":2,\"Y\":180,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Ngay:\"},{\"Text\":\"Phong ban:\",\"X\":3,\"Y\":260,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Phong ban:\"},{\"Text\":\"Lenh san xuat:\",\"X\":3,\"Y\":60,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"Lenh san xuat:\"},{\"Text\":\"{Net}\",\"X\":121,\"Y\":140,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Net}\"},{\"Text\":\"{Lenh san xuat}\",\"X\":120,\"Y\":61,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Lenh san xuat}\"},{\"Text\":\"{Nguoi can}\",\"X\":121,\"Y\":221,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Nguoi can}\"},{\"Text\":\"{Thoi gian}\",\"X\":121,\"Y\":181,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Thoi gian}\"},{\"Text\":\"{Phong ban}\",\"X\":121,\"Y\":261,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{Phong ban}\"},{\"Text\":\"{San pham}\",\"X\":3,\"Y\":100,\"FontName\":\"Times New Roman\",\"FontSize\":13,\"FontStyle\":0,\"Tag\":\"{San pham}\"}]",
                JsonConfigLabelPrintGeneral = "{\"Width\":80,\"Height\":100,\"FontName\":\"AcadEref\",\"FontSize\":500}",
                NamePrinter = "",
                NamePrinterA4 = "",
                TimeDelayPrinter = 1000,
                TimeDurationPrinter = 2000,
                IsAutoSyncData = true,
                TimeSyncData = 3000,
                DeletedFlag = false,
                EnableFlag = true,
                SyncFlag = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
              });
            }

            if (db?.Connections?.Any(x => x.eDevice == eDevice.WeightTcp) == false)
            {
              TcpClientJson tcpClientJson = new TcpClientJson();
              tcpClientJson.IP = "192.168.3.100";
              tcpClientJson.Port = 4305;

              await db.Connections.AddAsync(new Connection
              {
                Name = "Cân 1.5 tấn",
                Code = "IS0001",
                eCommunicationType = eCommunicationType.TcpClient,
                eDevice = eDevice.WeightTcp,
                JsonStrConfig = JsonHelper.ToJson(tcpClientJson),
                DeletedFlag = false,
                EnableFlag = true,
                SyncFlag = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
              });
            }

            if (db?.Connections?.Any(x => x.eDevice == eDevice.HidTcp) == false)
            {
              TcpClientJson tcpClientJson = new TcpClientJson();
              tcpClientJson.IP = "192.168.3.201";
              tcpClientJson.Port = 8080;

              await db.Connections.AddAsync(new Connection
              {
                Name = "HID",
                Code = "IS0002",
                eCommunicationType = eCommunicationType.TcpClient,
                eDevice = eDevice.HidTcp,
                JsonStrConfig = JsonHelper.ToJson(tcpClientJson),
                DeletedFlag = false,
                EnableFlag = true,
                SyncFlag = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
              });
            }

            await db!.SaveChangesAsync();
            await db.Database.CommitTransactionAsync();
          }
          catch (Exception ex)
          {
            db.Database.RollbackTransaction();
            AppCore.Ins.LogAction(ex.ToString(), eAction.Error);
          }
          return true;
        }
      }
      catch (Exception ex)
      {
        LogHelper.LogErrorToFileLog(ex, AppCore.Ins._folderFileLog);
        return false;
      }
    }



  }
}