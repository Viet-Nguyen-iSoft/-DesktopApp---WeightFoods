using System.Diagnostics;
using System.IO.Compression;

namespace ApplyNewVersion
{
  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();

      progressBar1.Style = ProgressBarStyle.Marquee;
      progressBar1.MarqueeAnimationSpeed = 5;

      this.Shown += FrmMain_Shown;
    }

    private void FrmMain_Shown(object? sender, EventArgs e)
    {
      timer1.Start();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timer1.Stop();

      try
      {
        string folder = Directory.GetParent(Directory.GetParent(Application.StartupPath)!.FullName)!.FullName;
        var rs = GetLatestZipFile(folder);
        if (rs != null)
        {
          string folderSoftware = Directory.GetParent(
                      Directory.GetParent(
                          Directory.GetParent(
                              Application.StartupPath
                          )!.FullName
                      )!.FullName
                  )!.FullName;
          var rsApply = ApplyUpdate(rs, folderSoftware);
          label1.Text = rsApply.Item2;
          progressBar1.Visible = false;

          ReStartApp();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }

    public static string? GetLatestZipFile(string folderPath)
    {
      if (!Directory.Exists(folderPath))
        return null;


      return Directory.GetFiles(
              folderPath,
              "*.zip",
              SearchOption.TopDirectoryOnly)
          .OrderByDescending(
              File.GetLastWriteTime)
          .FirstOrDefault();
    }

    public static bool ApplyUpdateAsync(string zipPath)
    {
      try
      {
        string appFolder =
            AppDomain.CurrentDomain.BaseDirectory;


        string tempFolder =
            Path.Combine(
                Path.GetTempPath(),
                "LaborTrackPro_Update");


        // Xóa thư mục tạm cũ
        if (Directory.Exists(tempFolder))
          Directory.Delete(tempFolder, true);


        Directory.CreateDirectory(tempFolder);



        // Giải nén
        ZipFile.ExtractToDirectory(
            zipPath,
            tempFolder);



        // Copy đè file
        foreach (string file in Directory.GetFiles(
            tempFolder,
            "*",
            SearchOption.AllDirectories))
        {
          string relative =
              Path.GetRelativePath(
                  tempFolder,
                  file);


          string target =
              Path.Combine(
                  appFolder,
                  relative);


          string? folder =
              Path.GetDirectoryName(target);


          if (folder != null &&
             !Directory.Exists(folder))
          {
            Directory.CreateDirectory(folder);
          }


          File.Copy(
              file,
              target,
              true);
        }



        return true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        return false;
      }
    }


    public static (bool, string) ApplyUpdate(
    string zipPath,
    string folderSrc)
    {
      try
      {
        if (!File.Exists(zipPath))
        {
          return (false, "Không tìm thấy file zip");
        }


        if (!Directory.Exists(folderSrc))
        {
          Directory.CreateDirectory(folderSrc);
        }



        string tempFolder =
            Path.Combine(
                Path.GetTempPath(),
                "LaborTrackPro_Update");



        // Xóa thư mục tạm
        if (Directory.Exists(tempFolder))
          Directory.Delete(
              tempFolder,
              true);


        Directory.CreateDirectory(tempFolder);



        // Giải nén zip
        ZipFile.ExtractToDirectory(
            zipPath,
            tempFolder);



        // Copy dữ liệu
        foreach (string file in Directory.GetFiles(
            tempFolder,
            "*",
            SearchOption.AllDirectories))
        {
          string relative =
              Path.GetRelativePath(
                  tempFolder,
                  file);



          string target =
              Path.Combine(
                  folderSrc,
                  relative);



          string? folder =
              Path.GetDirectoryName(target);


          if (folder != null)
          {
            Directory.CreateDirectory(folder);
          }

          File.Copy(
              file,
              target,
              true);
        }

        return (true, "Cập nhật thành công");
      }
      catch (Exception)
      {
        return (false, "Cập nhật thất bại");
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ReStartApp()
    {
      string folderSoftware = Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetParent(
                            Application.StartupPath
                        )!.FullName
                    )!.FullName
                )!.FullName;

      string app = Path.Combine(folderSoftware, "LaborTrackPro.exe");
      Process.Start(app);

      Application.Exit();
    }

   
  }
}
