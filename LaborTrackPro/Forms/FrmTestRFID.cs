using LaborTrackPro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestConnectPrinter;
using static System.Windows.Forms.AxHost;

namespace LaborTrackPro.Forms
{
  public partial class FrmTestRFID : Form
  {
    public FrmTestRFID()
    {
      InitializeComponent();
    }

    #region Instance
    private static FrmTestRFID _Instance = null;
    public static FrmTestRFID Instance
    {
      get
      {
        if (_Instance == null) _Instance = new FrmTestRFID();
        return _Instance;
      }
    }
    #endregion


    private void button1_Click(object sender, EventArgs e)
    {
      DTOPrint dTOPrint = new DTOPrint();
      dTOPrint.ProductionOrder = "PO Test 01";
      dTOPrint.MaterialCode = "2025";
      dTOPrint.MaterialName = "Hạt điều SW320";
      dTOPrint.Datetime = DateTime.Now.ToString("hh:MM dd/mm/yyyy");
      dTOPrint.Weight = "1000.325";
      dTOPrint.Qty = "1000.325";

      string zpl = ZebraPrinterTcpHelper.GetRfidLabel(textBox2.Text, dTOPrint);
      ZebraPrinterTcpHelper.PrintLabelWeight("192.168.3.200", 9100, zpl);
    }

    public static string GetRfidZplFromHex(string hex)
    {
      if (string.IsNullOrWhiteSpace(hex))
        throw new ArgumentException(
            "Mã Hex không được để trống.");

      // Cho phép đầu vào có dấu cách hoặc dấu gạch ngang.
      hex = Regex.Replace(hex, @"[\s-]", "")
          .ToUpperInvariant();

      if (!Regex.IsMatch(hex, @"\A[0-9A-F]+\z"))
        throw new ArgumentException(
            "Dữ liệu chứa ký tự không hợp lệ. Hex chỉ gồm 0-9 và A-F.");

      if (hex.Length % 2 != 0)
        throw new ArgumentException(
            "Mã Hex phải có số ký tự chẵn vì 2 ký tự Hex tương ứng 1 byte.");

      int byteLength = hex.Length / 2;

      if (byteLength > 64)
        throw new ArgumentException(
            "Dữ liệu Hex vượt quá giới hạn 64 byte.");

      return
          "^XA\r\n" +
          $"^RFW,H,0,{byteLength},3\r\n" +
          $"^FD{hex}^FS\r\n" +
          "^PQ1\r\n" +
          "^XZ";
    }


    public static string StringToHex(string value)
    {
      if (string.IsNullOrEmpty(value))
        return string.Empty;

      byte[] bytes = Encoding.UTF8.GetBytes(value);

      return BitConverter
          .ToString(bytes)
          .Replace("-", "");
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      try
      {
        var data = StringToHex(textBox1.Text);
        textBox2.Text = data.ToString();
      }
      catch (Exception)
      {

      }
      //string hex = RfidConverter.StringToHex(textBox1.Text);
      //textBox2.Text = hex;
      // Kết quả: 69736F667400

      //string text = RfidConverter.HexToString(hex);
      // Kết quả: isoft
    }

    public static class RfidConverter
    {
      // Chuyển string thành HEX UTF-8
      public static string StringToHex(string value, bool addRfidPadding = true)
      {
        if (value == null)
          throw new ArgumentNullException(nameof(value));

        byte[] bytes = Encoding.UTF8.GetBytes(value);

        string hex = BitConverter
            .ToString(bytes)
            .Replace("-", "");

        // RFID thường ghi theo word 2 byte
        if (addRfidPadding && bytes.Length % 2 != 0)
        {
          hex += "00";
        }

        return hex;
      }

      // Chuyển HEX UTF-8 thành string
      public static string HexToString(string hex)
      {
        if (string.IsNullOrWhiteSpace(hex))
          return string.Empty;

        // Chấp nhận cả "69 73 6F" và "69-73-6F"
        hex = hex
            .Replace(" ", "")
            .Replace("-", "");

        if (hex.Length % 2 != 0)
          throw new ArgumentException(
              "Chuỗi HEX phải có số ký tự chẵn.",
              nameof(hex)
          );

        byte[] bytes = new byte[hex.Length / 2];

        for (int i = 0; i < bytes.Length; i++)
        {
          bytes[i] = Convert.ToByte(
              hex.Substring(i * 2, 2),
              16
          );
        }

        // Loại bỏ byte 00 dùng để đệm RFID
        return Encoding.UTF8
            .GetString(bytes)
            .TrimEnd('\0');
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      EnumStatusConnect status = ZebraPrinterTcpHelper.GetStatusPrint("192.168.3.200");
      lbStatusPrinter.Text = status.ToString();
    }
  }
}
