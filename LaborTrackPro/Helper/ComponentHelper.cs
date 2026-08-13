using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborTrackPro.Helper
{
  public static class ComponentHelper
  {
    public static void CustomLabel(Label lb, string value)
    {
      int positionX = lb.Left + lb.Width / 2;
      lb.Text = value;
      lb.Left = positionX - lb.Width / 2;
    }
  }
}
