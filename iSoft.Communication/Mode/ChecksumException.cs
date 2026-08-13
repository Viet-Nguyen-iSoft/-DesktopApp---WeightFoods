using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Communication.Mode
{
  public class ChecksumException : Exception
  {
    public ChecksumException() : base("Checksum data failed!")
    {
    }
  }
}
