using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Communication.EnumCommunication;

namespace iSoft.Communication.Mode
{
  public class StandardOhausOutputData
  {
    public double? IndicatedWeight;

    public double? TareWeight;

    public UnitOfWeight Unit;


    public static StandardOhausOutputData Decode(byte[] dataBytes, bool isChecksum = false)
    {
      var outputData = new StandardOhausOutputData();
      string dataStr = System.Text.Encoding.UTF8.GetString(dataBytes);
      outputData.IndicatedWeight = ParseWeight(dataStr);
      outputData.TareWeight = 0;
      outputData.Unit = UnitOfWeight.Kilograms;
      return outputData;
    }

    public static double ParseWeight(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
        return 0;
      string cleaned = input.Trim();
      string numberPart = new string(cleaned
          .Where(c => char.IsDigit(c) || c == '.' || c == '-')
          .ToArray());

      if (double.TryParse(numberPart, System.Globalization.NumberStyles.Any,
          System.Globalization.CultureInfo.InvariantCulture, out double result))
      {
        return Math.Round(result / 1000.0, 2);
      }
      return 0;
    }

  }
}
