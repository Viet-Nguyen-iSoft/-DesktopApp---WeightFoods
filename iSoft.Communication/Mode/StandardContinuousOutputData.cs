using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Communication.EnumCommunication;

namespace iSoft.Communication.Mode
{
  public class StandardContinuousOutputData
  {
    public byte[] DataBytes;

    // byte 0
    public readonly byte StartChar = 0x02; // STX | Start of text
    // byte 1
    public StatusA StatusA;
    // byte 2
    public StatusB StatusB;
    // byte 3
    public StatusC StatusC;
    // byte 4
    public double? IndicatedWeight;

    public double? TareWeight;

    public UnitOfWeight Unit;

    public readonly byte CarriageReturnChar = 0x0D; // CR


    public bool CheckSumEnabled;

    public StandardContinuousOutputData()
    {
    }

    public StandardContinuousOutputData(byte[] bytes, bool isCheckSum = false) : this()
    {
      this.DataBytes = bytes;
      if (bytes.Length == 18 && isCheckSum)
      {
        this.CheckSumEnabled = true;
        if (!CheckSumOK()) throw new ChecksumException();
      }
    }

    public bool CheckSumOK()
    {
      var len = DataBytes.Length;
      var data = DataBytes.Take(len - 1).ToArray();
      var sum = CheckSumMe.Calculate(data);

      return sum == DataBytes[len - 1];
    }

    public string CalculateCheckSum(byte[] data)
    {
      byte sum = 0;
      foreach (var b in data)
      {
        sum += b;
      }
      string hexValue = (sum % 256).ToString("X");
      return hexValue.Replace("0x", "");
    }

    public static StandardContinuousOutputData Decode(byte[] dataBytes, bool isChecksum = false)
    {
      var outputData = new StandardContinuousOutputData(dataBytes, isChecksum);
      outputData.StatusA = StatusA.Decode(dataBytes[1]);
      outputData.StatusB = StatusB.Decode(dataBytes[2]);
      outputData.StatusC = StatusC.Decode(dataBytes[3]);

      double? _indicatedWeight;
      double? _taredWeight;


      int MSD_index = 4;
      int LSD_index = 9;
      _indicatedWeight = decodeWeightValue(dataBytes, outputData.StatusA, MSD_index, LSD_index, outputData.StatusB.Sign);

      MSD_index = 10;
      LSD_index = 15;
      _taredWeight = decodeWeightValue(dataBytes, outputData.StatusA, MSD_index, LSD_index);

      outputData.IndicatedWeight = _indicatedWeight;
      outputData.TareWeight = _taredWeight;

      if (outputData.StatusC.WeightDescription == WeightDescription.SelectedByStatusByteB)
      {
        //check status B
        outputData.Unit = outputData.StatusB.UnitOfWeight;
      }
      else if (outputData.StatusC.WeightDescription == WeightDescription.Grams)
      {
        outputData.Unit = UnitOfWeight.Grams;
      }
      else if (outputData.StatusC.WeightDescription == WeightDescription.Ounces)
      {
        outputData.Unit = UnitOfWeight.Ounces;
      }

      return outputData;
    }

    private static double? decodeWeightValue(byte[] dataBytes, StatusA statusA, int MSD_index, int LSD_index, Sign sign = Sign.Positive)
    {
      if (dataBytes.Length != 16 && dataBytes.Length != 18)
        throw new Exception("Độ dài data chưa đúng!");

      double? _weightValue = null;
      string value = "";
      for (int i = MSD_index; (i <= LSD_index); i++)
      {
        if (dataBytes[i] != 0x0D)
        {
          if (dataBytes[i] >= 0x30)
          {
            value = value + Convert.ToChar(dataBytes[i]);
          }
        }
      }
      value = value.Trim();
      try
      {
        value = value.Trim();
        _weightValue = Convert.ToDouble(value); //value / 10;

        if (statusA.DecimalPointLocation == DecimalPointLocation.XXXXX00)
        {
          _weightValue = _weightValue * 100;
          value = String.Format("{0}", _weightValue.ToString());
        }
        else if (statusA.DecimalPointLocation == DecimalPointLocation.XXXXX0)
        {
          _weightValue = _weightValue * 10;
        }
        else if (statusA.DecimalPointLocation == DecimalPointLocation.XXXXX_X)
        {
          _weightValue = _weightValue / 10;
        }
        else if (statusA.DecimalPointLocation == DecimalPointLocation.XXXX_XX)
        {
          _weightValue = _weightValue / 100;
        }
        else if (statusA.DecimalPointLocation == DecimalPointLocation.XXX_XXX)
        {
          _weightValue = _weightValue / 1000;
        }
        else if (statusA.DecimalPointLocation == DecimalPointLocation.XX_XXXX)
        {
          _weightValue = _weightValue / 1000;
        }
        else if (statusA.DecimalPointLocation == DecimalPointLocation.X_XXXXX)
        {
          _weightValue = _weightValue / 10000;
        }
        else if (statusA.DecimalPointLocation == DecimalPointLocation.XXXXXX)
        {
          ;
        }
      }
      catch { }
      _weightValue = sign == Sign.Positive ? _weightValue : -_weightValue;
      return _weightValue;
    }

    private static double? decodeIndicaltedWeightValue(byte[] dataBytes, StandardContinuousOutputData outputData, int MSD_index, int LSD_index)
    {
      double? _weightValue = null;
      string value = "";
      for (int i = MSD_index; (i <= LSD_index); i++)
      {
        if (dataBytes[i] != 0x0D)
        {
          if (dataBytes[i] >= 0x30)
          {
            value = value + Convert.ToChar(dataBytes[i]);
          }
        }
      }
      value = value.Trim();
      try
      {
        //value = value.Split(' ')[0];
        value = value.Trim();
        _weightValue = Convert.ToDouble(value); //value / 10;
        string sign = outputData.StatusB.Sign == Sign.Positive ? "+" : "-";

        if (outputData.StatusB.Sign == Sign.Negative)
        {
          sign = "-";
        }
        if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.XXXXX00)
        {
          //double_value = double_value * 100;
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
        else if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.XXXXX0)
        {
          //double_value = double_value * 10;
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
        else if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.XXXXXX)
        {
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
        else if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.XXXXX_X)
        {
          _weightValue = _weightValue / 10;
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
        else if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.XXXX_XX)
        {
          _weightValue = _weightValue / 100;
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
        else if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.XXX_XXX)
        {
          _weightValue = _weightValue / 1000;
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
        else if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.XX_XXXX)
        {
          _weightValue = _weightValue / 1000;
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
        else if (outputData.StatusA.DecimalPointLocation == DecimalPointLocation.X_XXXXX)
        {
          _weightValue = _weightValue / 10000;
          value = String.Format("{0}{1}", sign, _weightValue.ToString());
        }
      }
      catch { }

      return _weightValue;
    }

    public static byte[] Encode(StandardContinuousOutputData standardContinuousOutputData)
    {
      byte[] data = new byte[18];

      // Start Char
      data[0] = standardContinuousOutputData.StartChar;

      // Status byte A
      StatusA statusA = standardContinuousOutputData.StatusA;
      data[1] = StatusA.Encode(statusA);

      // Status byte B
      StatusB statusB = standardContinuousOutputData.StatusB;
      data[2] = StatusB.Encode(statusB);

      // Status byte C
      StatusC statusC = standardContinuousOutputData.StatusC;
      data[3] = StatusC.Encode(statusC);

      // Indicated Weight
      var indicatedWeight = standardContinuousOutputData.IndicatedWeight;
      var indicatedWeightStr = indicatedWeight.ToString().Trim('-').Trim('+').Trim(' ').Replace(".", string.Empty).PadLeft(6, ' ');
      var indicatedWeightData = Encoding.ASCII.GetBytes(indicatedWeightStr);

      data[4] = indicatedWeightData[0]; // MSD
      data[5] = indicatedWeightData[1];
      data[6] = indicatedWeightData[2];
      data[7] = indicatedWeightData[3];
      data[8] = indicatedWeightData[4];
      data[9] = indicatedWeightData[5]; // LSD

      // Tare Weight
      var tareWeight = standardContinuousOutputData.TareWeight;
      var tareWeightStr = tareWeight.ToString().Trim('-').Trim('+').Trim(' ').Replace(".", string.Empty).PadLeft(6, ' ');
      var tareWeighttData = Encoding.ASCII.GetBytes(tareWeightStr);

      data[10] = tareWeighttData[0]; // MSD
      data[11] = tareWeighttData[1];
      data[12] = tareWeighttData[2];
      data[13] = tareWeighttData[3];
      data[14] = tareWeighttData[4];
      data[15] = tareWeighttData[5]; // LSD

      // Carriage Return
      data[16] = standardContinuousOutputData.CarriageReturnChar;
      data[17] = CheckSumMe.Calculate(data);

      return data;
    }
  }
}
