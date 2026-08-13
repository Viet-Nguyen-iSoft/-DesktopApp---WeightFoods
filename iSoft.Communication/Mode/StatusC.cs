using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Communication.EnumCommunication;

namespace iSoft.Communication.Mode
{
  public partial class StatusC
  {
    public WeightDescription WeightDescription = WeightDescription.SelectedByStatusByteB;
    public PrintRequest PrintRequest = PrintRequest.False;
    public ExpandData ExpandDataOrNormal = ExpandData.Normal;
  }
  public partial class StatusC
  {
    public static StatusC Decode(byte statusByteC)
    {
      var statusC = new StatusC();
      int statusByteC_bit0 = ((statusByteC & 0x01) / 0x01);
      int statusByteC_bit1 = ((statusByteC & 0x02) / 0x02);
      int statusByteC_bit2 = ((statusByteC & 0x04) / 0x04);
      int statusByteC_bit3 = ((statusByteC & 0x08) / 0x08);
      int statusByteC_bit4 = ((statusByteC & 0x10) / 0x10);
      int statusByteC_bit5 = ((statusByteC & 0x20) / 0x20); //always 1
      int statusByteC_bit6 = ((statusByteC & 0x40) / 0x40); //always 0
      int statusByteC_bit7 = ((statusByteC & 0x40) / 0x80); //always 0

      statusC.WeightDescription = (WeightDescription)(statusByteC & 0x07);
      statusC.PrintRequest = (PrintRequest)(statusByteC_bit3);
      statusC.ExpandDataOrNormal = (ExpandData)(statusByteC_bit4);
      return statusC;
    }

    public static byte Encode(StatusC statusC)
    {
      byte statusByteC = (byte)(((byte)statusC.WeightDescription));
      statusByteC |= (byte)(((byte)statusC.PrintRequest) << 3);
      statusByteC |= (byte)(((byte)statusC.ExpandDataOrNormal) << 4);
      statusByteC |= 1 << 5;
      statusByteC |= 0 << 6;

      return statusByteC;
    }
  }
}
