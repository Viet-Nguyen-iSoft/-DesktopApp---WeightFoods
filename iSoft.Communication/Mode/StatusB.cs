using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Communication.EnumCommunication;

namespace iSoft.Communication.Mode
{
  public partial class StatusB
  {
    public TypeOfWeight TypeOfWeight = TypeOfWeight.Gross;
    public Sign Sign = Sign.Negative;
    public OutOfRange OutOfRange = OutOfRange.False;
    public ActiveWeighingStatus ActiveWeighingStatus = ActiveWeighingStatus.Motion;
    public UnitOfWeight UnitOfWeight = UnitOfWeight.Kilograms;
    public ZeroNotCapturedAfterPowerUp ZeroNotCapturedAfterPowerUp = ZeroNotCapturedAfterPowerUp.No;

  }
  public partial class StatusB
  {
    public static StatusB Decode(byte statusByteB)
    {
      var StatusB = new StatusB();
      int statusByteB_bit0 = ((statusByteB & 0x01) / 0x01);
      int statusByteB_bit1 = ((statusByteB & 0x02) / 0x02);
      int statusByteB_bit2 = ((statusByteB & 0x04) / 0x04);
      int statusByteB_bit3 = ((statusByteB & 0x08) / 0x08);
      int statusByteB_bit4 = ((statusByteB & 0x10) / 0x10);
      int statusByteB_bit5 = ((statusByteB & 0x20) / 0x20); //always 1
      int statusByteB_bit6 = ((statusByteB & 0x40) / 0x40);
      int statusByteB_bit7 = ((statusByteB & 0x40) / 0x80); //always 0

      StatusB.TypeOfWeight = (TypeOfWeight)(statusByteB_bit0);
      StatusB.Sign = (Sign)(statusByteB_bit1);
      StatusB.OutOfRange = (OutOfRange)(statusByteB_bit2);
      StatusB.ActiveWeighingStatus = (ActiveWeighingStatus)(statusByteB_bit3);
      StatusB.UnitOfWeight = (UnitOfWeight)(statusByteB_bit4);
      StatusB.ZeroNotCapturedAfterPowerUp = (ZeroNotCapturedAfterPowerUp)(statusByteB_bit6);
      return StatusB;
    }

    public static byte Encode(StatusB statusB)
    {
      // Calculate the StatusB byte from the field values
      byte statusByteB = (byte)(
              ((int)statusB.TypeOfWeight) |
              ((int)statusB.Sign << 1) |
              ((int)statusB.OutOfRange << 2) |
              ((int)statusB.ActiveWeighingStatus << 3) |
              ((int)statusB.UnitOfWeight << 4) |
              1 << 5 |
              ((int)statusB.ZeroNotCapturedAfterPowerUp << 6)
          );
      return statusByteB;
    }
  }
}
