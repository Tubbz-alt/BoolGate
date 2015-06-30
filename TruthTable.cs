using NCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Logical
{
  public class TruthTable : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView theTable;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem exportTableBtn;
    private SaveFileDialog saveTableDia;

    public TruthTable()
    {
      this.InitializeComponent();
    }

    private void exportTable(DataGridView grid, string path)
    {
      string str1 = "";
      for (int index = 0; index < grid.Columns.Count; ++index)
        str1 = index != 0 ? str1 + ", " + grid.Columns[index].HeaderText.ToString() : str1 + grid.Columns[index].HeaderText.ToString();
      string str2 = str1 + "\n";
      for (int index1 = 0; index1 < grid.Rows.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 < grid.Rows[index1].Cells.Count; ++index2)
          str2 = index2 != 0 ? str2 + ", " + grid.Rows[index1].Cells[index2].Value.ToString() : str2 + grid.Rows[index1].Cells[index2].Value.ToString();
        str2 += "\n";
      }
      StreamWriter streamWriter = new StreamWriter(path);
      streamWriter.WriteLine(str2);
      streamWriter.Close();
    }

    public void createTruthTable(string equation, bool usebinary)
    {
      if (equation == "")
        return;
      this.theTable.Rows.Clear();
      this.theTable.Columns.Clear();
      List<char> list = new List<char>();
      int startIndex1;
      for (startIndex1 = 0; startIndex1 < equation.Length; ++startIndex1)
      {
        if (char.IsLetter(equation[startIndex1]) && !list.Contains(equation[startIndex1]))
        {
          list.Add(equation[startIndex1]);
          this.theTable.Columns.Add(startIndex1.ToString(), equation[startIndex1].ToString());
        }
        if ((int) equation[startIndex1] == 96)
        {
          equation = equation.Remove(startIndex1, 1);
          equation = equation.Insert(startIndex1, "!");
        }
        else if ((int) equation[startIndex1] == 46)
        {
          equation = equation.Remove(startIndex1, 1);
          equation = equation.Insert(startIndex1, "&&");
        }
        else if ((int) equation[startIndex1] == 43)
        {
          equation = equation.Remove(startIndex1, 1);
          equation = equation.Insert(startIndex1, "||");
        }
      }
      this.theTable.Columns.Add("OUT", "Q");
      int num1 = (int) Math.Pow(2.0, (double) list.Count);
      for (startIndex1 = 0; startIndex1 < num1; ++startIndex1)
      {
        string str1 = Convert.ToString(startIndex1, 2).PadLeft(list.Count, '0');
        string[] strArray1 = new string[str1.Length];
        for (int index = 0; index < str1.Length; ++index)
          strArray1[index] = !usebinary ? ((int) str1[index] != 48 ? "True" : "False") : str1[index].ToString();
        string expression1 = equation;
        for (int index = 0; index < list.Count; ++index)
        {
          for (int startIndex2 = 0; startIndex2 < expression1.Length; ++startIndex2)
          {
            if ((int) expression1[startIndex2] == (int) list[index])
              expression1 = expression1.Remove(startIndex2, 1).Insert(startIndex2, strArray1[index].ToLower());
          }
        }
        Expression expression2 = new Expression(expression1);
        string[] strArray2 = new string[strArray1.Length + 1];
        for (int index = 0; index < strArray1.Length; ++index)
          strArray2[index] = strArray1[index];
        string str2 = expression2.Evaluate().ToString();
        if (str2 == "True" && usebinary)
        {
          strArray2[strArray2.Length - 1] = "1";
        }
        else
        {
          int num2 = !(str2 == "False") ? 1 : (!usebinary ? 1 : 0);
          strArray2[strArray2.Length - 1] = num2 != 0 ? str2 : "0";
        }
        this.theTable.Rows.Add((object[]) strArray2);
      }
    }

    private void exportTableBtn_Click(object sender, EventArgs e)
    {
      this.saveTableDia.InitialDirectory = FileSave.grabOptions().defaultPath;
      int num = (int) this.saveTableDia.ShowDialog();
      if (!(this.saveTableDia.FileName != ""))
        return;
      this.exportTable(this.theTable, this.saveTableDia.FileName);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TruthTable));
      this.theTable = new DataGridView();
      this.menuStrip1 = new MenuStrip();
      this.exportTableBtn = new ToolStripMenuItem();
      this.saveTableDia = new SaveFileDialog();
      ((ISupportInitialize) this.theTable).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.theTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.theTable.Dock = DockStyle.Fill;
      this.theTable.Location = new Point(0, 24);
      this.theTable.Name = "theTable";
      this.theTable.ReadOnly = true;
      this.theTable.Size = new Size(438, 289);
      this.theTable.TabIndex = 0;
      this.menuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.exportTableBtn
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(438, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      this.exportTableBtn.Name = "exportTableBtn";
      this.exportTableBtn.Size = new Size(93, 20);
      this.exportTableBtn.Text = "Export Table...";
      this.exportTableBtn.Click += new EventHandler(this.exportTableBtn_Click);
      this.saveTableDia.Filter = "CSV Files|*.csv";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(438, 313);
      this.Controls.Add((Control) this.theTable);
      this.Controls.Add((Control) this.menuStrip1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "TruthTable";
      this.Text = "Truth Table";
      ((ISupportInitialize) this.theTable).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
