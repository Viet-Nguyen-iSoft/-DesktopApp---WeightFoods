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
      //AppCore.Ins.LogAction("Start App", eAction.StartApp);
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

            if (db?.Connections?.Any(x => x.EnumDevice == EnumDevice.WeightTcp) == false)
            {
              TcpClientJson tcpClientJson = new TcpClientJson();
              tcpClientJson.IP = "192.168.3.100";
              tcpClientJson.Port = 4305;

              await db.Connections.AddAsync(new Connection
              {
                Name = "Cân 1.5 tấn",
                Code = "IS0001",
                EnumCommunicationType = EnumCommunicationType.TcpClient,
                EnumDevice = EnumDevice.WeightTcp,
                JsonStrConfig = JsonHelper.ToJson(tcpClientJson),
                DeletedFlag = false,
                EnableFlag = true,
                SyncFlag = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
              });
            }

            if (db?.Connections?.Any(x => x.EnumDevice == EnumDevice.HidTcp) == false)
            {
              TcpClientJson tcpClientJson = new TcpClientJson();
              tcpClientJson.IP = "192.168.3.201";
              tcpClientJson.Port = 8080;

              await db.Connections.AddAsync(new Connection
              {
                Name = "HID",
                Code = "IS0002",
                EnumCommunicationType = EnumCommunicationType.TcpClient,
                EnumDevice = EnumDevice.HidTcp,
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