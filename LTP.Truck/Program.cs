using HelperManager;
using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using LTP.Truck.Controls;
using static HelperManager.EnumData;

namespace LTP.Truck
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

      //Start Form
      AppCore.Ins.Init();
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

            //if (db?.AppConfigs?.Count() <= 0)
            //{
            //  await db.AppConfigs.AddAsync(new AppConfig
            //  {
            //    IpServer = "10.0.0.45", //"100.101.165.42",
            //    PortServer = 6902,
            //    MachineCode = "HSF01",
            //    NamePrinter = "",
            //    NamePrinterA4 = "",
            //    TimeDelayPrinter = 1000,
            //    TimeDurationPrinter = 2000,
            //    IsAutoSyncData = true,
            //    TimeSyncData = 3000,
            //    DeletedFlag = false,
            //    EnableFlag = true,
            //    SyncFlag = true,
            //    CreatedAt = DateTime.Now,
            //    UpdatedAt = DateTime.Now,
            //  });
            //}

            await db!.SaveChangesAsync();
            await db.Database.CommitTransactionAsync();
          }
          catch (Exception ex)
          {
            db.Database.RollbackTransaction();
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