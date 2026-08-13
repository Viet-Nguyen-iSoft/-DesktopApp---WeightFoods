using API;
using LaborTrackPro.Controls;

namespace LaborTrackPro.Forms
{
  public partial class PopupApplyVersionNew : Form
  {
    public event EventHandler<string>? OnSendApply;
    public PopupApplyVersionNew()
    {
      InitializeComponent();
      this.TopMost = AppCore.Ins._isTopMost;
      this.Load += PopupApplyVersionNew_Load;
      this.Shown += PopupApplyVersionNew_Shown;
    }

    private void PopupApplyVersionNew_Load(object? sender, EventArgs e)
    {
      lbVersionCurrent.Text = AppCore.Ins._appConfig.Version;
    }

    private GitHubReleaseDTO? GitHubReleaseDTO { get; set; }
    private async void PopupApplyVersionNew_Shown(object? sender, EventArgs e)
    {
      GitHubReleaseDTO = await ApiGetRelease.GetLatestReleaseAsync();
      if (GitHubReleaseDTO != null)
      {
        LoadInforVersion(GitHubReleaseDTO);
        CheckNewVersion();
      }
    }

    private async void btnDownload_Click(object sender, EventArgs e)
    {
      try
      {
        LockByDownload(true);
        string versionUpdate = GitHubReleaseDTO?.TagName.Replace(".", "_") ?? string.Empty;
        if (!string.IsNullOrEmpty(versionUpdate))
        {
          string folder = Path.Combine(Application.StartupPath, "Versions");

          if (!Directory.Exists(folder))
          {
            Directory.CreateDirectory(folder);
          }

          string pathFileZip = Path.Combine(folder, $"update_{versionUpdate}.zip");
          var ok = await ApiGetRelease.DownloadReleaseAsync(GitHubReleaseDTO, pathFileZip);
          if (ok)
          {
            btnApply.Visible = true;
            btnDownload.Visible = false;
          }
        }
        else
        {
          MessageBox.Show("Version lỗi");
        }
      }
      catch (Exception)
      {

      }
      finally
      {
        LockByDownload(false);
      }
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
      OnSendApply?.Invoke(this, GitHubReleaseDTO?.TagName ?? string.Empty);
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    public void LoadInforVersion(GitHubReleaseDTO gitHubRelease)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadInforVersion(gitHubRelease);
        }));
        return;
      }

      lbVersion.Text = gitHubRelease.TagName;
      txtCommit.Text = gitHubRelease.CommitMessage;
    }

    public void CheckNewVersion()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          CheckNewVersion();
        }));
        return;
      }


      picLoading.Visible = false;
      if (lbVersion.Text == lbVersionCurrent.Text)
      {
        btnDownload.Visible = false;
        txtCommit.Text = "Không có bản cập nhật";
      }
      else
      {
        btnDownload.Visible = true;
      }
    }

    public void LockByDownload(bool lockUI)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LockByDownload(lockUI);
        }));
        return;
      }

      this.Enabled = !lockUI;

      if (lockUI)
      {
        progressBar1.Visible = true;
        progressBar1.Style = ProgressBarStyle.Marquee;
        progressBar1.MarqueeAnimationSpeed = 10;
      }
      else
      {
        progressBar1.Visible = false;
      }
    }





  }
}
