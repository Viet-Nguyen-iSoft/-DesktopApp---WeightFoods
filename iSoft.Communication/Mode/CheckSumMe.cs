using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Communication.Mode
{
  internal partial class CheckSumMe
  {

  }
  internal partial class CheckSumMe
  {
    public static byte Calculate(byte[] data)
    {
      byte sum = 0;
      foreach (byte b in data)
      {
        sum += b;
      }
      return sum;
    }
  }
}
