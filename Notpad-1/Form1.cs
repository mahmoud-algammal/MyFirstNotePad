using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notpad_1
  {
  public partial class Form1: Form
    {
    public Form1()
      {
      InitializeComponent();
      }

    private void ButtonSave_Click(object sender, EventArgs e)
      {
      var dialog = new SaveFileDialog(); // متغير يرث ديالوج الحفظ
      dialog.Filter = "text file |*.txt"; // نوع الملفات المسموح بحفظها
      if (dialog.ShowDialog() == DialogResult.OK) // لو المستخدم ضغط اوك او حفظ
        {
        File.WriteAllText(dialog.FileName,richTxt1.Text);
        // الملفات.اكتب كل النص(اسم ملف الحفظ,النص المحفوظ) ش
        }
      }

    private void ButtonOpen_Click(object sender, EventArgs e)
      {
      var dialog = new OpenFileDialog();
      dialog.Filter = "text file |*.txt";
      if (dialog.ShowDialog() == DialogResult.OK)
        {
        richTxt1.Text = File.ReadAllText(dialog.FileName);
        }
      }

    private void ButtonCopy_Click(object sender, EventArgs e)
      {
      if (richTxt1.SelectedText != "") // لضمان وجود نص معلم عليه
        {
        Clipboard.Clear(); // تنظيف المحفوظات السابقة لتحل مكانها الحالية
        Clipboard.SetText(richTxt1.SelectedText);
        // النص المحتوى في الكليب بورد = النص المحدد
        }
      richTxt1.HideSelection = false;
      }

    private void ButtonPaste_Click(object sender, EventArgs e)
      {
      richTxt1.Text = richTxt1.Text + Clipboard.GetText();
      // النص = النص الحالي + النص المنسوخ في الكليب بورد
      }

    private void ButtonCut_Click(object sender, EventArgs e)
      {
      if (richTxt1.SelectedText != "") // لضمان وجود نص معلم عليه
        {
        Clipboard.Clear();
        Clipboard.SetText(richTxt1.SelectedText);
        richTxt1.SelectedText = "";
        }
      }

    private void ButtonPrint_Click(object sender, EventArgs e)
      {
      printPreviewDialog1.ShowDialog();
      }

    private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
      e.Graphics.DrawString(richTxt1.Text, richTxt1.Font, Brushes.Black, new Point(100, 100));
      }

    private void ButtonFont_Click(object sender, EventArgs e)
      {
      var dialog = new FontDialog();
      if (dialog.ShowDialog() == DialogResult.OK)
        {
        if (richTxt1.SelectedText == "")
          {
          richTxt1.Font = dialog.Font;
          }
        else richTxt1.SelectionFont = dialog.Font;
        }
      richTxt1.HideSelection = false;
      }

    private void RichTxt1_TextChanged(object sender, EventArgs e)
      {
      label14.Text = Convert.ToString(richTxt1.TextLength) + " Char";
      label15.Text = Convert.ToString(richTxt1.Text.Split(' ').Count()-1)+" Words";
      }

    private void ButtonBold_Click(object sender, EventArgs e)
      {
      if (richTxt1.SelectedText == "")
        {
        richTxt1.Font = new Font(richTxt1.Font, richTxt1.Font.Style ^ FontStyle.Bold);
        }
      else
        {
        richTxt1.SelectionFont = new Font(richTxt1.Font, richTxt1.SelectionFont.Style ^ FontStyle.Bold);
        }
      richTxt1.HideSelection = false;
      }

    private void ButtonLine_Click(object sender, EventArgs e)
      {
      if (richTxt1.SelectedText == "")
        {
        richTxt1.Font = new Font(richTxt1.Font, richTxt1.Font.Style ^ FontStyle.Underline);
        }
      else
        {
        richTxt1.SelectionFont = new Font(richTxt1.Font, richTxt1.SelectionFont.Style ^ FontStyle.Underline);
        }
      richTxt1.HideSelection = false;
      }

    private void ButtonLeft_Click(object sender, EventArgs e)
      {
      richTxt1.SelectionAlignment = HorizontalAlignment.Left; ;
      }

    private void ButtonRight_Click(object sender, EventArgs e)
      {
      richTxt1.SelectionAlignment = HorizontalAlignment.Right;
      }

    private void ButtonCenter_Click(object sender, EventArgs e)
      {
      richTxt1.SelectionAlignment = HorizontalAlignment.Center;
      }

    private void ButtonFcolor_Click(object sender, EventArgs e)
      {
      var clr_dialog = new ColorDialog();
      if (clr_dialog.ShowDialog() == DialogResult.OK)
        {
        if (richTxt1.SelectedText == "")
          {
          richTxt1.ForeColor = clr_dialog.Color;
          }
        else if (richTxt1.SelectedText != "")
          richTxt1.SelectionColor = clr_dialog.Color;
        richTxt1.HideSelection = false;
        }
      }

    private void ButtonBcolor_Click(object sender, EventArgs e)
      {
      var clr_dialog = new ColorDialog();
      if (clr_dialog.ShowDialog() == DialogResult.OK)
        {
          richTxt1.SelectionBackColor = clr_dialog.Color;
        }
      }

    private void BunifuSlider1_ValueChanged(object sender, EventArgs e)
      {
      if (bunifuSlider1.Value < 63) // اقل من 63 لأنها هي القيمة الأعلى التي لا يحدث عندها خطأ
        {
        richTxt1.ZoomFactor = bunifuSlider1.Value + 1; // +1 حتى لا تكون القيمة صفر فيحدث خطأ
        }
      }
    }
  }
