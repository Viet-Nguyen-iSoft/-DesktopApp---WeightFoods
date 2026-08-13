namespace LaborTrackPro.Forms
{
  public class MyButton : Button
  {
    public MyButton()
    {
      this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
    }
  }

  public partial class FrmDatetimePicker : Form
  {
    public delegate void SendDatetime(DateTime dateTime);
    public event SendDatetime? OnSendDatetime;
    public FrmDatetimePicker()
    {
      InitializeComponent();
      this.Load += FrmDatetimePicker_Load;
      this.Shown += FrmDatetimePicker_Shown;
    }

    private int _yearCurrent;
    private int _monthCurrent;
    private Size _size;
    private void FrmDatetimePicker_Load(object? sender, EventArgs e)
    {
      DateTime dateTime = DateTime.Now;
      _yearCurrent = dateTime.Year;
      _monthCurrent = dateTime.Month;
      this.lbDatetimeCurrent.Text = dateTime.ToString("yyyy - MM - dd");
    }
    private void FrmDatetimePicker_Shown(object? sender, EventArgs e)
    {
      int w = flowLayoutPanel1.Width / 7 - 6;
      int h = 50;
      _size = new Size(w, h);
      LoadMonthCalendar(_yearCurrent, _monthCurrent, _size);
    }


    private void LoadMonthCalendar(int year, int month, Size size)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          LoadMonthCalendar(year, month, size);
        }));
        return;
      }

      this.lbYearCurrent.Text = _yearCurrent.ToString();
      this.lbMonthCurrent.Text = $"Tháng {_monthCurrent}";

      flowLayoutPanel1.Controls.Clear();

      // Ngày đầu tiên của tháng
      DateTime firstDayOfMonth = new DateTime(year, month, 1);

      // Tìm Thứ 2 đầu tuần chứa ngày đầu tiên của tháng
      int delta = DayOfWeek.Monday - firstDayOfMonth.DayOfWeek;
      if (delta > 0) delta -= 7; // nếu firstDay là CN thì lùi lại 6 ngày
      DateTime startDate = firstDayOfMonth.AddDays(delta);

      // Tạo lịch 6 tuần (42 ngày)
      for (int i = 0; i < 42; i++)
      {
        DateTime day = startDate.AddDays(i);

        MyButton btn = new MyButton();
        btn.Text = day.Day.ToString();
        btn.Tag = day;
        btn.Width = 60;
        btn.Height = 50;
        btn.Font = new Font("Roboto", 20, FontStyle.Regular);

        // Ngày trong tháng khác thì mờ đi
        if (day.Month != month)
        {
          btn.ForeColor = Color.Gray;
        }

        // Hôm nay thì tô màu
        if (day == DateTime.Today)
        {
          btn.BackColor = Color.LightGreen;
        }
        btn.DoubleClick += Btn_DoubleClick;
        btn.Size = size;
        flowLayoutPanel1.Controls.Add(btn);
      }
    }

    private void Btn_DoubleClick(object? sender, EventArgs e)
    {
      if (sender is Button btn && btn.Tag is DateTime d)
      {
        OnSendDatetime?.Invoke(d);
        this.BeginInvoke(new Action(() => this.Close()));
      }
    }

    private void btnBackYear_Click(object sender, EventArgs e)
    {
      _yearCurrent -= 1;
      LoadMonthCalendar(_yearCurrent, _monthCurrent, _size);
    }

    private void btnNextYear_Click(object sender, EventArgs e)
    {
      _yearCurrent += 1;
      LoadMonthCalendar(_yearCurrent, _monthCurrent, _size);
    }

    private void btnBackMonth_Click(object sender, EventArgs e)
    {
      if (_monthCurrent > 1)
      {
        _monthCurrent -= 1;
      }
      else
      {
        _yearCurrent -= 1;
        _monthCurrent = 12;
      }
      LoadMonthCalendar(_yearCurrent, _monthCurrent, _size);
    }

    private void btnNextMonth_Click(object sender, EventArgs e)
    {
      if (_monthCurrent < 12)
      {
        _monthCurrent += 1;
      }
      else
      {
        _yearCurrent += 1;
        _monthCurrent = 1;
      }
      LoadMonthCalendar(_yearCurrent, _monthCurrent, _size);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnToday_Click(object sender, EventArgs e)
    {
      DateTime dateTime = DateTime.Now;
      _yearCurrent = dateTime.Year;
      _monthCurrent = dateTime.Month;
      LoadMonthCalendar(_yearCurrent, _monthCurrent, _size);
    }
  }
}
