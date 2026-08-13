using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace TestConnectPrinter
{
  public class ZebraPrinterTcpHelper
  {
    public static EnumStatusConnect PrintLabelWeight(string ip, int port, string zpl, int timeoutConnectTcp = 500)
    {
      try
      {
        if (!IsPing(ip, timeoutConnectTcp))
        {
          return EnumStatusConnect.Disconnect;
        }

        string rsStr = GetPrinterStatus(ip, port);
        var rsStatus = ParseZebraHS(rsStr);

        if (rsStatus[0][1] == "1")
        {
          return EnumStatusConnect.PaperOut;
        }
        else if (rsStatus[0][2] == "1")
        {
          return EnumStatusConnect.Pause;
        }
        else if (rsStatus[0][10] == "1")
        {
          return EnumStatusConnect.OverTemperature;
        }
        else if (rsStatus[0][11] == "1")
        {
          return EnumStatusConnect.UnderTemperature;
        }

        PrintZebra(ip, zpl);


        return EnumStatusConnect.Sucess;
      }
      catch (Exception)
      {
        return EnumStatusConnect.Error;
      }
    }

    public static EnumStatusConnect GetStatusPrint(string ip, int port = 9100, int timeoutConnectTcp = 1000)
    {
      try
      {
        if (!IsPing(ip, timeoutConnectTcp))
        {
          return EnumStatusConnect.Disconnect;
        }

        string rsStr = GetPrinterStatus(ip, port);
        var rsStatus = ParseZebraHS(rsStr);

        if (rsStatus[0][1] == "1")
        {
          return EnumStatusConnect.PaperOut;
        }
        else if (rsStatus[0][2] == "1")
        {
          return EnumStatusConnect.Pause;
        }
        else if (rsStatus[0][10] == "1")
        {
          return EnumStatusConnect.OverTemperature;
        }
        else if (rsStatus[0][11] == "1")
        {
          return EnumStatusConnect.UnderTemperature;
        }

        return EnumStatusConnect.Sucess;
      }
      catch (Exception)
      {
        return EnumStatusConnect.Error;
      }
    }

    public static void PrintZebra(string ip, string zpl, int port = 9100)
    {
      using (TcpClient client = new TcpClient())
      {
        client.Connect(ip, port);

        using (NetworkStream stream = client.GetStream())
        {
          byte[] data = Encoding.UTF8.GetBytes(zpl);
          stream.Write(data, 0, data.Length);
          stream.Flush();
        }
      }
    }

    public static string GetPrinterStatus(string ip, int port)
    {
      return SendCommand(ip, "~HS", port);
    }

    public static string SendCommand(string ip, string command, int port = 9100)
    {
      using (TcpClient client = new TcpClient())
      {
        client.ReceiveTimeout = 3000;
        client.SendTimeout = 3000;

        client.Connect(ip, port);

        NetworkStream stream = client.GetStream();

        byte[] data = Encoding.ASCII.GetBytes(command);
        stream.Write(data, 0, data.Length);
        stream.Flush();

        byte[] buffer = new byte[4096];
        int bytes = stream.Read(buffer, 0, buffer.Length);

        return Encoding.ASCII.GetString(buffer, 0, bytes);
      }
    }


    public static bool IsPing(string ip, int timeoutConnectTcp = 500)
    {
      try
      {
        using (Ping ping = new Ping())
        {
          var reply = ping.Send(ip, timeoutConnectTcp);
          return reply.Status == IPStatus.Success;
        }
      }
      catch
      {
        return false;
      }
    }

    public static List<string[]> ParseZebraHS(string raw)
    {
      var result = new List<string[]>();

      if (string.IsNullOrWhiteSpace(raw))
        return result;

      // tách từng block
      var blocks = raw.Split('\n', StringSplitOptions.RemoveEmptyEntries);

      foreach (var block in blocks)
      {
        string line = block
            .Replace("\u0002", "")
            .Replace("\u0003", "")
            .Replace("\r", "")
            .Trim();

        if (!string.IsNullOrEmpty(line))
        {
          var fields = line.Split(',');
          result.Add(fields);
        }
      }

      return result;
    }


    public static void TestZT620()
    {
      var zplPrint = GetExternalGoodsLabelV3();
      PrintLabelWeight("192.168.3.200", 9100, zplPrint);
    }

    public static string GetExternalGoodsLabelV1()
    {
      return @"
^XA
^CI28
^PW1181
^LL1772
^LH0,0

^FX ===================== Border =====================
^FO20,20^GB1140,1730,3^FS

^FX ===================== Logo =======================
^FO40,40^XGE:LOGO.GRF,1,1^FS

^FX ===================== Title ======================
^FO260,35
^A0N,45,45
^FDTHẺ KHO HÀNG NHẬP NGOẠI VI^FS

^FO260,85
^A0N,30,30
^FDEXTERNAL GOODS RECEIPT STOCK CARD^FS

^FX ===================== Left Column =======================

^FO50,160^A0N,28,28^FDThời gian / Time:^FS
^FO50,195^A0N,26,26^FDDateTime^FS
^FO230,195^GB220,0,2^FS

^FO50,255^A0N,28,28^FDLệnh sản xuất:^FS
^FO50,290^A0N,26,26^FDProductionOrder^FS
^FO230,290^GB220,0,2^FS

^FO50,350^A0N,28,28^FDTên NVL:^FS
^FO50,385^A0N,26,26^FDMaterial^FS
^FO230,385^GB220,0,2^FS

^FO50,445^A0N,28,28^FDNhà cung cấp:^FS
^FO50,480^A0N,26,26^FDSupplier^FS
^FO230,480^GB220,0,2^FS

^FX ===================== Right Column =======================

^FO700,160^A0N,28,28^FDMa:^FS
^FO700,195^A0N,26,26^FDNo.^FS
^FO880,195^GB220,0,2^FS

^FO700,255^A0N,28,28^FDLot:^FS
^FO790,290^A0N,26,26^FD^FS
^FO880,290^GB220,0,2^FS

^FO700,350^A0N,28,28^FDKhối lượng:^FS
^FO700,385^A0N,26,26^FDWeight^FS
^FO910,385^GB180,0,2^FS

^FO700,445^A0N,28,28^FDSố lượng:^FS
^FO700,480^A0N,26,26^FDQuantity^FS
^FO910,480^GB180,0,2^FS

^FX ===================== QUALITY INSPECTION =====================

^FO20,520^GB1140,55,55^FS
^FO330,532^A0N,35,35^FDQUALITY INSPECTION^FS

^FO40,580^GB1100,230,2^FS

^FO40,635^GB1100,0,2^FS
^FO40,690^GB1100,0,2^FS
^FO40,745^GB1100,0,2^FS

^FO520,580^GB0,230,2^FS
^FO760,580^GB0,230,2^FS

^FO60,595^A@N,26,26,E:69296989.TTF^FDẨm / Moisture (%):^FS
^FO60,650^A@N,26,26,E:69296989.TTF^FDBể / Broken (%):^FS
^FO60,705^A@N,26,26,E:69296989.TTF^FDMuối / Salt (%):^FS
^FO60,760^A@N,26,26,E:69296989.TTF^FDThời gian đo / Time:^FS
^FO60,815^A@N,26,26,E:69296989.TTF^FDNgười phụ trách / Inspector:^FS

^FX ===================== QUALITY CONTROL TAG =====================

^FO20,840^GB1140,55,55^FS
^FO285,852^A0N,35,35^FDQUALITY CONTROL TAG^FS

^FX ===== Box 1 =====
^FO40,900^GB1100,200,2^FS
^FO420,980^A0N,32,32^FDDan the QC^FS
^FO390,1020^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 2 =====
^FO40,1120^GB1100,200,2^FS
^FO420,1200^A0N,32,32^FDDan the QC^FS
^FO390,1240^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 3 =====
^FO40,1340^GB1100,200,2^FS
^FO420,1420^A0N,32,32^FDDan the QC^FS
^FO390,1460^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 4 =====
^FO40,1560^GB1100,150,2^FS
^FO420,1620^A0N,32,32^FDDan the QC^FS
^FO390,1660^A0N,28,28^FD(QC Tag Here)^FS

^XZ";
    }
    public static string GetExternalGoodsLabelV3()
    {
      string logo = ImageToGFA(@"D:\Logo2.png", 35, 30);

      return $@"
^XA
^CI28
^PW1181
^LL1772
^LH0,0

^FO5,5^GB0,0,3^FS

{logo}

^FX ===================== Border =====================
^FO20,20^GB1140,1730,3^FS

^FX ===================== Logo =======================
^FO40,40^XGE:LOGO.GRF,1,1^FS

^FX ===================== Title ======================
^FO350,35
^A@N,45,45,E:69296989.TTF
^FDTHẺ KHO HÀNG NHẬP NGOẠI VI^FS

^FO450,85
^A0N,30,30
^FDEXTERNAL GOODS RECEIPT STOCK CARD^FS

^FX ===================== Left Column =======================

^FO50,160^A@N,28,28,E:69296989.TTF^FDThời gian / Time:^FS
^FO50,195^A0N,26,26^FDDateTime^FS
^FO230,195^GB220,0,2^FS

^FO50,255^A@N,28,28,E:69296989.TTF^FDLệnh sản xuất:^FS
^FO50,290^A0N,26,26^FDProductionOrder^FS
^FO230,290^GB220,0,2^FS

^FO50,350^A@N,28,28,E:69296989.TTF^FDTên NVL:^FS
^FO50,385^A0N,26,26^FDMaterial^FS
^FO230,385^GB220,0,2^FS

^FO50,445^A@N,28,28,E:69296989.TTF^FDNhà cung cấp:^FS
^FO50,480^A0N,26,26^FDSupplier^FS
^FO230,480^GB220,0,2^FS

^FX ===================== Right Column =======================

^FO700,160^A@N,28,28,E:69296989.TTF^FDMã:^FS
^FO700,195^A0N,26,26^FDNo.^FS
^FO880,195^GB220,0,2^FS

^FO700,255^A0N,28,28^FDLot:^FS
^FO790,290^A0N,26,26^FD^FS
^FO880,290^GB220,0,2^FS

^FO700,350^A@N,28,28,E:69296989.TTF^FDKhối lượng:^FS
^FO700,385^A0N,26,26^FDWeight^FS
^FO910,385^GB180,0,2^FS

^FO700,445^A@N,28,28,E:69296989.TTF^FDSố lượng:^FS
^FO700,480^A0N,26,26^FDQuantity^FS
^FO910,480^GB180,0,2^FS

^FX ===================== QUALITY INSPECTION =====================

^FO20,520^GB1140,55,2^FS
^FO380,532^A0N,35,35^FDQUALITY INSPECTION^FS

^FO40,580^GB1100,230,2^FS

^FO40,635^GB1100,0,2^FS
^FO40,690^GB1100,0,2^FS
^FO40,745^GB1100,0,2^FS

^FO520,580^GB0,230,2^FS
^FO760,580^GB0,230,2^FS

^FO60,595^A@N,26,26,E:69296989.TTF^FDẨm / Moisture (%):^FS
^FO60,650^A@N,26,26,E:69296989.TTF^FDBể / Broken (%):^FS
^FO60,705^A@N,26,26,E:69296989.TTF^FDMuối / Salt (%):^FS
^FO60,760^A@N,26,26,E:69296989.TTF^FDThời gian đo / Time:^FS
^FO60,815^A@N,26,26,E:69296989.TTF^FDNgười phụ trách / Inspector:^FS

^FX ===================== QUALITY CONTROL TAG =====================

^FO20,520^GB1140,55,2^FS
^FO375,852^A0N,35,35^FDQUALITY CONTROL TAG^FS

^FX ===== Box 1 =====
^FO40,900^GB1100,200,2^FS
^FO520,980^A0N,32,32^FDDan the QC^FS
^FO500,1020^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 2 =====
^FO40,1120^GB1100,200,2^FS
^FO520,1200^A0N,32,32^FDDan the QC^FS
^FO500,1240^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 3 =====
^FO40,1340^GB1100,200,2^FS
^FO520,1420^A0N,32,32^FDDan the QC^FS
^FO500,1460^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 4 =====
^FO40,1560^GB1100,150,2^FS
^FO520,1620^A0N,32,32^FDDan the QC^FS
^FO500,1660^A0N,28,28^FD(QC Tag Here)^FS

^XZ";
    }

    public static string GetExternalGoodsLabelV2()
    {
      string logo = ImageToGFA(@"D:\Logo2.png", 35, 30);

      return $@"
^XA
^CI28
^PW1181
^LL1772
^LH0,0

^FO5,5^GB0,0,3^FS

{logo}


^FX ===================== Border =====================
^FO20,20^GB1140,1730,3^FS

^FX ===================== Logo =======================
^FO40,40^XGE:LOGO.GRF,1,1^FS

^FX ===================== Title ======================
^FO260,35
^A0N,45,45
^FDTHẺ KHO HÀNG NHẬP NGOẠI VI^FS

^FO260,85
^A0N,30,30
^FDEXTERNAL GOODS RECEIPT STOCK CARD^FS

^FX ===================== Left Column =======================

^FO50,160^A0N,28,28^FDThời gian / Time:^FS
^FO50,195^A0N,26,26^FDDateTime^FS
^FO230,195^GB220,0,2^FS

^FO50,255^A0N,28,28^FDLệnh sản xuất:^FS
^FO50,290^A0N,26,26^FDProductionOrder^FS
^FO230,290^GB220,0,2^FS

^FO50,350^A0N,28,28^FDTên NVL:^FS
^FO50,385^A0N,26,26^FDMaterial^FS
^FO230,385^GB220,0,2^FS

^FO50,445^A0N,28,28^FDNhà cung cấp:^FS
^FO50,480^A0N,26,26^FDSupplier^FS
^FO230,480^GB220,0,2^FS

^FX ===================== Right Column =======================

^FO700,160^A0N,28,28^FDMa:^FS
^FO700,195^A0N,26,26^FDNo.^FS
^FO880,195^GB220,0,2^FS

^FO700,255^A0N,28,28^FDLot:^FS
^FO790,290^A0N,26,26^FD^FS
^FO880,290^GB220,0,2^FS

^FO700,350^A0N,28,28^FDKhối lượng:^FS
^FO700,385^A0N,26,26^FDWeight^FS
^FO910,385^GB180,0,2^FS

^FO700,445^A0N,28,28^FDSố lượng:^FS
^FO700,480^A0N,26,26^FDQuantity^FS
^FO910,480^GB180,0,2^FS

^FX ===================== QUALITY INSPECTION =====================

^FO20,520^GB1140,55,55^FS
^FO330,532^A0N,35,35^FDQUALITY INSPECTION^FS

^FO40,580^GB1100,230,2^FS

^FO40,635^GB1100,0,2^FS
^FO40,690^GB1100,0,2^FS
^FO40,745^GB1100,0,2^FS

^FO520,580^GB0,230,2^FS
^FO760,580^GB0,230,2^FS

^FO60,595^A@N,26,26,E:69296989.TTF^FDẨm / Moisture (%):^FS
^FO60,650^A@N,26,26,E:69296989.TTF^FDBể / Broken (%):^FS
^FO60,705^A@N,26,26,E:69296989.TTF^FDMuối / Salt (%):^FS
^FO60,760^A@N,26,26,E:69296989.TTF^FDThời gian đo / Time:^FS
^FO60,815^A@N,26,26,E:69296989.TTF^FDNgười phụ trách / Inspector:^FS

^FX ===================== QUALITY CONTROL TAG =====================

^FO20,840^GB1140,55,55^FS
^FO285,852^A0N,35,35^FDQUALITY CONTROL TAG^FS

^FX ===== Box 1 =====
^FO40,900^GB1100,200,2^FS
^FO420,980^A0N,32,32^FDDan the QC^FS
^FO390,1020^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 2 =====
^FO40,1120^GB1100,200,2^FS
^FO420,1200^A0N,32,32^FDDan the QC^FS
^FO390,1240^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 3 =====
^FO40,1340^GB1100,200,2^FS
^FO420,1420^A0N,32,32^FDDan the QC^FS
^FO390,1460^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 4 =====
^FO40,1560^GB1100,150,2^FS
^FO420,1620^A0N,32,32^FDDan the QC^FS
^FO390,1660^A0N,28,28^FD(QC Tag Here)^FS

^XZ";
    }

    public static string GetExternalGoodsLabel()
    {
      string logo = string.Empty;
      //      string logo = ImageToGFA(
      //    @"D:\Logo.png",
      //    1010,   // X
      //    25,     // Y
      //    120,    // Width
      //    60      // Height
      //);

      return $@"
^XA
^CI28
^PW1181
^LL1772
^LH0,0

^FO5,5^GB300,150,3^FS

{logo}


^FX ===================== Border =====================
^FO20,20^GB1140,1730,3^FS

^FX ===================== Logo =======================
^FO40,40^XGE:LOGO.GRF,1,1^FS

^FX ===================== Title ======================
^FO260,35
^A0N,45,45
^FDTHẺ KHO HÀNG NHẬP NGOẠI VI^FS

^FO260,85
^A0N,30,30
^FDEXTERNAL GOODS RECEIPT STOCK CARD^FS

^FX ===================== Left Column =======================

^FO50,160^A0N,28,28^FDThời gian / Time:^FS
^FO50,195^A0N,26,26^FDDateTime^FS
^FO230,195^GB220,0,2^FS

^FO50,255^A0N,28,28^FDLệnh sản xuất:^FS
^FO50,290^A0N,26,26^FDProductionOrder^FS
^FO230,290^GB220,0,2^FS

^FO50,350^A0N,28,28^FDTên NVL:^FS
^FO50,385^A0N,26,26^FDMaterial^FS
^FO230,385^GB220,0,2^FS

^FO50,445^A0N,28,28^FDNhà cung cấp:^FS
^FO50,480^A0N,26,26^FDSupplier^FS
^FO230,480^GB220,0,2^FS

^FX ===================== Right Column =======================

^FO700,160^A0N,28,28^FDMa:^FS
^FO700,195^A0N,26,26^FDNo.^FS
^FO880,195^GB220,0,2^FS

^FO700,255^A0N,28,28^FDLot:^FS
^FO790,290^A0N,26,26^FD^FS
^FO880,290^GB220,0,2^FS

^FO700,350^A0N,28,28^FDKhối lượng:^FS
^FO700,385^A0N,26,26^FDWeight^FS
^FO910,385^GB180,0,2^FS

^FO700,445^A0N,28,28^FDSố lượng:^FS
^FO700,480^A0N,26,26^FDQuantity^FS
^FO910,480^GB180,0,2^FS

^FX ===================== QUALITY INSPECTION =====================

^FO20,520^GB1140,55,55^FS
^FO330,532^A0N,35,35^FDQUALITY INSPECTION^FS

^FO40,580^GB1100,230,2^FS

^FO40,635^GB1100,0,2^FS
^FO40,690^GB1100,0,2^FS
^FO40,745^GB1100,0,2^FS

^FO520,580^GB0,230,2^FS
^FO760,580^GB0,230,2^FS

^FO60,595^A@N,26,26,E:69296989.TTF^FDẨm / Moisture (%):^FS
^FO60,650^A@N,26,26,E:69296989.TTF^FDBể / Broken (%):^FS
^FO60,705^A@N,26,26,E:69296989.TTF^FDMuối / Salt (%):^FS
^FO60,760^A@N,26,26,E:69296989.TTF^FDThời gian đo / Time:^FS
^FO60,815^A@N,26,26,E:69296989.TTF^FDNgười phụ trách / Inspector:^FS

^FX ===================== QUALITY CONTROL TAG =====================

^FO20,840^GB1140,55,55^FS
^FO285,852^A0N,35,35^FDQUALITY CONTROL TAG^FS

^FX ===== Box 1 =====
^FO40,900^GB1100,200,2^FS
^FO420,980^A0N,32,32^FDDan the QC^FS
^FO390,1020^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 2 =====
^FO40,1120^GB1100,200,2^FS
^FO420,1200^A0N,32,32^FDDan the QC^FS
^FO390,1240^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 3 =====
^FO40,1340^GB1100,200,2^FS
^FO420,1420^A0N,32,32^FDDan the QC^FS
^FO390,1460^A0N,28,28^FD(QC Tag Here)^FS

^FX ===== Box 4 =====
^FO40,1560^GB1100,150,2^FS
^FO420,1620^A0N,32,32^FDDan the QC^FS
^FO390,1660^A0N,28,28^FD(QC Tag Here)^FS

^XZ";
    }













    ///////////////////////
    ///
    public static string ImageToGFA(string imagePath, int x = 0, int y = 0)
    {
      using Bitmap original = new Bitmap(imagePath);

      Bitmap bmp = ToMono(original);

      int width = bmp.Width;
      int height = bmp.Height;

      int bytesPerRow = (width + 7) / 8;
      int totalBytes = bytesPerRow * height;

      StringBuilder hex = new StringBuilder(totalBytes * 2);

      Rectangle rect = new Rectangle(0, 0, width, height);

      BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

      int stride = data.Stride;
      byte[] buffer = new byte[stride * height];

      Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

      bmp.UnlockBits(data);

      for (int yPos = 0; yPos < height; yPos++)
      {
        byte current = 0;
        int bit = 0;

        for (int xPos = 0; xPos < width; xPos++)
        {
          int index = yPos * stride + xPos * 3;

          byte b = buffer[index];
          byte g = buffer[index + 1];
          byte r = buffer[index + 2];

          int gray = (r + g + b) / 3;

          bool black = gray < 128;

          current <<= 1;

          if (black)
            current |= 1;

          bit++;

          if (bit == 8)
          {
            hex.Append(current.ToString("X2"));
            current = 0;
            bit = 0;
          }
        }

        if (bit > 0)
        {
          current <<= (8 - bit);
          hex.Append(current.ToString("X2"));
        }
      }

      return $@"
^FO{x},{y}
^GFA,{totalBytes},{totalBytes},{bytesPerRow},{hex}";
    }

    private static Bitmap ToMono(Bitmap src)
    {
      Bitmap bmp = new Bitmap(src.Width, src.Height, PixelFormat.Format24bppRgb);

      using Graphics g = Graphics.FromImage(bmp);
      g.Clear(Color.White);
      g.DrawImage(src, 0, 0, src.Width, src.Height);

      Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

      BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

      int stride = data.Stride;

      byte[] buffer = new byte[stride * bmp.Height];

      Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

      for (int y = 0; y < bmp.Height; y++)
      {
        for (int x = 0; x < bmp.Width; x++)
        {
          int idx = y * stride + x * 3;

          byte b = buffer[idx];
          byte g2 = buffer[idx + 1];
          byte r = buffer[idx + 2];

          int gray = (r + g2 + b) / 3;

          byte value = gray < 128 ? (byte)0 : (byte)255;

          buffer[idx] = value;
          buffer[idx + 1] = value;
          buffer[idx + 2] = value;
        }
      }

      Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);

      bmp.UnlockBits(data);

      return bmp;
    }

    //public string GetRfidLabel(string rfidHex)
    //{
    //  if (string.IsNullOrWhiteSpace(rfidHex))
    //    throw new ArgumentException("Mã RFID không được để trống.");

    //  rfidHex = rfidHex
    //      .Replace(" ", "")
    //      .Replace("-", "")
    //      .Trim()
    //      .ToUpperInvariant();

    //  if (!Regex.IsMatch(rfidHex, @"\A[0-9A-F]{12}\z"))
    //  {
    //    throw new ArgumentException(
    //        "Mã RFID phải có đúng 12 ký tự Hex, chỉ gồm 0-9 và A-F.");
    //  }

    //  return
    //      "^XA\r\n" +
    //      "^RFW,H,,,A\r\n" +
    //      "^FD" + rfidHex + "^FS\r\n" +
    //      "^XZ";
    //}

    public static string GetRfidLabel(string rfidHex, DTOPrint dto)
    {
      if (string.IsNullOrWhiteSpace(rfidHex))
        throw new ArgumentException("Mã RFID không được để trống.");

      if (dto == null)
        throw new ArgumentNullException(nameof(dto));

      rfidHex = rfidHex
          .Replace(" ", "")
          .Replace("-", "")
          .Trim()
          .ToUpperInvariant();

      if (!Regex.IsMatch(rfidHex, @"\A[0-9A-F]{12}\z"))
      {
        throw new ArgumentException(
            "Mã RFID phải có đúng 12 ký tự Hex, chỉ gồm 0-9 và A-F.");
      }

      var zpl = new StringBuilder();

      zpl.AppendLine("^XA");

      // Mã hóa UTF-8, dùng cho dữ liệu tiếng Việt nếu máy in hỗ trợ.
      zpl.AppendLine("^CI28");

      // Ghi RFID.
      zpl.AppendLine("^RFW,H,,,A");
      zpl.AppendLine($"^FD{rfidHex}^FS");


      //// Thông số hiển thị
      int fontH = 50;
      int fontW = 50;
      double offset = 0.0;

      int fontH_Hight = 60;
      int fontW_Hight = 60;

      /////////////////////////////////////////////
      double row01 = 34.0 + offset;
      // Datetime
      zpl.AppendLine(
          $"^FO{MmToDots(52.0)},{MmToDots(row01)}");
      zpl.AppendLine(
          $"^A@N,{fontH_Hight},{fontW_Hight},E:69296989.TTF");
      zpl.AppendLine($"^FD{dto.Datetime}^FS");

      // Material Code
      zpl.AppendLine(
          $"^FO{MmToDots(120.0)},{MmToDots(row01)}");
      zpl.AppendLine(
          $"^A@N,{fontH_Hight},{fontW_Hight},E:69296989.TTF");
      zpl.AppendLine($"^FD{dto.MaterialCode}^FS");

      /////////////////////////////////////////////
      // In PO Code
      double row02 = 48.0 + offset;
      zpl.AppendLine(
          $"^FO{MmToDots(44.0)},{MmToDots(row02)}");
      zpl.AppendLine(
          $"^A@N,{fontH},{fontW},E:69296989.TTF");
      zpl.AppendLine($"^FD{dto.ProductionOrder}^FS");

      // Lot
      //zpl.AppendLine(
      //    $"^FO{MmToDots(44.0)},{MmToDots(46.0)}");
      //zpl.AppendLine(
      //    $"^A@N,{fontH},{fontW},E:69296989.TTF");
      //zpl.AppendLine($"^FD{dto.ProductionOrder}^FS");


      /////////////////////////////////////////////
      // Material Name
      double row03 = 61.0 + offset;
      zpl.AppendLine(
          $"^FO{MmToDots(32.0)},{MmToDots(row03)}");
      zpl.AppendLine(
          $"^A@N,{fontH},{fontW},E:69296989.TTF");
      zpl.AppendLine($"^FD{dto.MaterialName}^FS");

      // Weight
      zpl.AppendLine(
          $"^FO{MmToDots(135.0)},{MmToDots(row03)}");
      zpl.AppendLine(
          $"^A@N,{fontH_Hight},{fontW_Hight},E:69296989.TTF");
      zpl.AppendLine($"^FD{dto.Weight}^FS");


      //////////////////////////////////////////////
      // Quality
      double row04 = 76.0 + offset;
      zpl.AppendLine(
          $"^FO{MmToDots(135.0)},{MmToDots(row04)}");
      zpl.AppendLine(
          $"^A@N,{fontH_Hight},{fontW_Hight},E:69296989.TTF");
      zpl.AppendLine($"^FD{dto.Qty}^FS");


      zpl.AppendLine("^XZ");
      return zpl.ToString();
    }

    private static int MmToDots(double millimeters, int dpi = 300)
    {
      return (int)Math.Round(
          millimeters * dpi / 25.4,
          MidpointRounding.AwayFromZero);
    }

    //public static string GetRfidLabel(string rfidHex)
    //{
    //  if (string.IsNullOrWhiteSpace(rfidHex))
    //    throw new ArgumentException("Mã RFID không được để trống.");

    //  rfidHex = rfidHex
    //      .Replace(" ", "")
    //      .Replace("-", "")
    //      .Trim()
    //      .ToUpperInvariant();

    //  if (!Regex.IsMatch(rfidHex, @"\A[0-9A-F]{12}\z"))
    //  {
    //    throw new ArgumentException(
    //        "Mã RFID phải có đúng 12 ký tự Hex, chỉ gồm 0-9 và A-F.");
    //  }

    //  return
    //      "^XA\r\n" +
    //      "^RFW,H,,,A\r\n" +
    //      "^FD" + rfidHex + "^FS\r\n" +
    //      "^XZ";
    //}


    private static void AddText(StringBuilder zpl, string text)
    {
      if (string.IsNullOrWhiteSpace(text))
        return;

      zpl.AppendLine(
          $"^FO10,10^A0N,25,25^FH\\^FD{EscapeZpl(text)}^FS");
    }

    private static string FormatDateTime(DateTime? value)
    {
      return value?.ToString("HH:mm dd/MM/yyyy") ?? string.Empty;
    }

    private static string FormatDecimal(decimal? value)
    {
      return value?.ToString("0.##", CultureInfo.InvariantCulture)
             ?? string.Empty;
    }

    private static string EscapeZpl(string value)
    {
      if (string.IsNullOrEmpty(value))
        return string.Empty;

      // ^FH\ cho phép truyền các ký tự đặc biệt bằng mã hex.
      return value
          .Replace(@"\", "_5C")
          .Replace("^", "_5E")
          .Replace("~", "_7E");
    }
  }

  public class DTOPrint
  {
    public string? Datetime { get; set; }
    public string? MaterialCode { get; set; }
    public string? ProductionOrder { get; set; }
    public string? MaterialName { get; set; }
    public string? Weight { get; set; }
    public string? Qty { get; set; }
  }

  public enum EnumStatusConnect
  {
    None,
    Disconnect,
    Error,
    PaperOut,
    Pause,
    OverTemperature,
    UnderTemperature,
    Sucess,

  }

}
