using HelperManager;
using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using LaborTrackPro.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperManager.EnumData;

namespace LTP.Truck.Controls
{
  public partial class AppCore
  {
    private void StartShowUI()
    {
      Application.Run(FrmMain.Instance);
    }

    
  }
}
