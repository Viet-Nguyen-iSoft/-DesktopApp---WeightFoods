using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Communication.EnumCommunication;

namespace iSoft.Communication.Mode
{
  public partial class StatusA
  {
    public DecimalPointLocation DecimalPointLocation;
    public BuildCode BuildCode;
  }

  public partial class StatusA
  {

    public static StatusA Decode(byte statusByteA)
    {
      var StatusA = new StatusA();
      bool statusByteA_bit0 = ((statusByteA & 0x01) == 0x01);
      bool statusByteA_bit1 = ((statusByteA & 0x02) == 0x02);
      bool statusByteA_bit2 = ((statusByteA & 0x04) == 0x04);

      /* Build code */
      bool statusByteA_bit3 = ((statusByteA & 0x08) == 0x08);
      bool statusByteA_bit4 = ((statusByteA & 0x10) == 0x10);

      bool statusByteA_bit5 = ((statusByteA & 0x20) == 0x20); //always 1
      bool statusByteA_bit6 = ((statusByteA & 0x40) == 0x40); //always 0
      bool statusByteA_bit7 = ((statusByteA & 0x40) == 0x80); //always 0

      StatusA.DecimalPointLocation = (DecimalPointLocation)(statusByteA & 0x07);
      if ((statusByteA_bit4 == true) && (statusByteA_bit3 == true))
      {
        StatusA.BuildCode = BuildCode.X5;
      }
      else if ((statusByteA_bit4 == true) && (statusByteA_bit3 == false))
      {
        StatusA.BuildCode = BuildCode.X2;
      }
      else if ((statusByteA_bit4 == false) && (statusByteA_bit3 == true))
      {
        StatusA.BuildCode = BuildCode.X1;
      }
      else
      {
        StatusA.BuildCode = BuildCode.NotUsed;
      }
      return StatusA;
    }

    public static byte Encode(StatusA statusA)
    {
      // Calculate the StatusA byte from the field values
      byte statusByteA = (byte)(
        ((int)statusA.DecimalPointLocation) |
        ((int)statusA.BuildCode) << 3 |
        1 << 5 |
        0 << 6
        );

      return statusByteA;
    }
  }
}
