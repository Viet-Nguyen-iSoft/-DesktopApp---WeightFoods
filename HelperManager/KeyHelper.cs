using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperManager
{
  public static class KeyHelper
  {
    public static string? CreateLabel(string? key)
    {
      return key + DateTime.Now.ToString("yyMMddHHmmss");
    }
  }
}
