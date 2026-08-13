using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace LaborTrackPro.Printer
{
  public partial class TestPrinter : Form
  {
    public TestPrinter()
    {
      InitializeComponent();
    }
    #region Instance
    private static TestPrinter _Instance = null;

    public static TestPrinter Instance
    {
      get
      {
        if (_Instance == null) _Instance = new TestPrinter();
        return _Instance;
      }
    }
    #endregion



    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        string sourceFile = Application.StartupPath + @"\Template\PhieuGiaoNhan.docx";
        string outputFile = Application.StartupPath + @"\Template\PhieuGiaoNhan01.docx";

        // Mở file
        using (var doc = DocX.Load(sourceFile))
        {
          // Thay thế tất cả {tag} bằng "Chế biến"
          doc.ReplaceText("{content}", "Chế biến", false, System.Text.RegularExpressions.RegexOptions.None);

          // Lưu lại thành file mới
          doc.SaveAs(outputFile);
        }

        MessageBox.Show("Đã thay thế và lưu file thành công!");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Lỗi: " + ex.Message);
      }
    }

  }
}
