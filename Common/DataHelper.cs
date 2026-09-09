using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public static class DataHelper
  {
    public static bool IsOn(PictureBox picture)
    {
      var s= picture.Image == Properties.Resources.switch_on;
      var e= picture.Image == Properties.Resources.switch_off;

      return s && e;
    }
  }
}
