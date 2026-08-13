using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderHID
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.Load += Form1_Load;
    }

    private List<string> comList = SerialPort.GetPortNames()
    .OrderBy(x =>
    {
      var number = Regex.Match(x, @"\d+").Value;
      return int.TryParse(number, out int n) ? n : int.MinValue;
    })
    .ToList();
    private void Form1_Load(object sender, EventArgs e)
    {
      cbbCOM.Items.Clear();
      if (comList?.Count>0)
      {
        foreach (string comPort in comList)
        {
          cbbCOM.Items.Add(comPort);
        }
      }  
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private SerialPort _serialPort;
    private void btnConnect_Click(object sender, EventArgs e)
    {
      try
      {
        if (cbbCOM.SelectedItem == null)
        {
          lbStatus.Text = "Chọn COM kết nối !";
          lbStatus.ForeColor = Color.Black;
          return;
        }

        _serialPort = new SerialPort();
        _serialPort.PortName = cbbCOM.SelectedItem.ToString();
        _serialPort.BaudRate = 9600;
        _serialPort.DataBits = 8;
        _serialPort.Parity = Parity.None;
        _serialPort.StopBits = StopBits.One;
        _serialPort.Handshake = Handshake.None;
        _serialPort.Encoding = System.Text.Encoding.ASCII;
        _serialPort.DtrEnable = true;
        _serialPort.RtsEnable = true;

        _serialPort.DataReceived += SerialPort_DataReceived;

        _serialPort.Open();

        if (_serialPort.IsOpen)
        {
          lbStatus.Text = "Kết nối thành công.";
          lbStatus.ForeColor = Color.Green;
        }
        else
        {
          lbStatus.Text = "Kết nối thất bại!";
          lbStatus.ForeColor = Color.Red;
        }  
      }
      catch (Exception ex)
      {
        lbStatus.Text = "Kết nối thất bại!";
        lbStatus.ForeColor = Color.Red;
      }
    }


    private string _lastSerialData = "";
    private string _buffer = "";
    private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        string data = _serialPort.ReadExisting();
        _buffer += data;

        while (_buffer.Contains("\r\n"))
        {
          int index = _buffer.IndexOf("\r\n");
          string line = _buffer.Substring(0, index).Trim();
          _buffer = _buffer.Substring(index + 2);

          _lastSerialData = line;

          this.Invoke(new Action(() =>
          {
            if (IsJson(_lastSerialData))
            {
              Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(_lastSerialData);
              txtData.Text = myDeserializedClass.raw;
            }
          }));
        }
      }
      catch (Exception ex)
      {
        this.Invoke(new Action(() =>
        {
          MessageBox.Show("Lỗi đọc dữ liệu: " + ex.Message);
        }));
      }
    }
    public bool IsJson(string input)
    {
      if (string.IsNullOrWhiteSpace(input))
        return false;

      input = input.Trim();

      try
      {
        JsonDocument.Parse(input);
        return true;
      }
      catch
      {
        return false;
      }
    }

  }

  public class Root
  {
    public string type { get; set; }
    public int value { get; set; }
    public string hex { get; set; }
    public string raw { get; set; }
  }

}
