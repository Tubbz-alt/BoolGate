// Decompiled with JetBrains decompiler
// Type: Logical.ExpressionBox
// Assembly: BoolGate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F0D7661-EAFC-4F52-BA76-3A0ABDEAAD45
// Assembly location: C:\Program Files (x86)\Atom Softworks\BoolGate\BoolGate.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Logical
{
  public class ExpressionBox : Form
  {
    private IContainer components = (IContainer) null;
    private TruthTable truthtable = new TruthTable();
    private ToolStrip toolStrip1;
    private RichTextBox bexpText;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem bool2TruthBtn;
    private ToolStripMenuItem bool2DiagramBtn;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton addANDExp;
    private ToolStripButton addXORExp;
    private ToolStripButton addNANDExp;
    private ToolStripButton addNORExp;
    private ToolStripButton addXNORExp;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton addNOTExp;
    private ToolStripButton addORExp;
    private Gates.GateObject diagramStore;
    private int initWidth;

    public ExpressionBox()
    {
      this.InitializeComponent();
      this.initWidth = this.Width;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ExpressionBox));
      this.toolStrip1 = new ToolStrip();
      this.toolStripDropDownButton1 = new ToolStripDropDownButton();
      this.bool2TruthBtn = new ToolStripMenuItem();
      this.bool2DiagramBtn = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.addANDExp = new ToolStripButton();
      this.addORExp = new ToolStripButton();
      this.addXORExp = new ToolStripButton();
      this.addNANDExp = new ToolStripButton();
      this.addNORExp = new ToolStripButton();
      this.addXNORExp = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.addNOTExp = new ToolStripButton();
      this.bexpText = new RichTextBox();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.toolStrip1.Items.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.toolStripDropDownButton1,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.addANDExp,
        (ToolStripItem) this.addORExp,
        (ToolStripItem) this.addXORExp,
        (ToolStripItem) this.addNANDExp,
        (ToolStripItem) this.addNORExp,
        (ToolStripItem) this.addXNORExp,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.addNOTExp
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(416, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "⊕";
      this.toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.bool2TruthBtn,
        (ToolStripItem) this.bool2DiagramBtn
      });
      this.toolStripDropDownButton1.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.toolStripDropDownButton1.Image = (Image) componentResourceManager.GetObject("toolStripDropDownButton1.Image");
      this.toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
      this.toolStripDropDownButton1.Size = new Size(89, 22);
      this.toolStripDropDownButton1.Text = "Convert to...";
      this.bool2TruthBtn.Name = "bool2TruthBtn";
      this.bool2TruthBtn.Size = new Size(152, 22);
      this.bool2TruthBtn.Text = "Truth Table";
      this.bool2TruthBtn.Click += new EventHandler(this.bool2TruthBtn_Click);
      this.bool2DiagramBtn.Name = "bool2DiagramBtn";
      this.bool2DiagramBtn.Size = new Size(152, 22);
      this.bool2DiagramBtn.Text = "Circuit";
      this.bool2DiagramBtn.Click += new EventHandler(this.bool2DiagramBtn_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.addANDExp.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addANDExp.Image = (Image) componentResourceManager.GetObject("addANDExp.Image");
      this.addANDExp.ImageTransparentColor = Color.Magenta;
      this.addANDExp.Name = "addANDExp";
      this.addANDExp.Size = new Size(36, 22);
      this.addANDExp.Text = "AND";
      this.addANDExp.Click += new EventHandler(this.addANDExp_Click);
      this.addORExp.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addORExp.Image = (Image) componentResourceManager.GetObject("addORExp.Image");
      this.addORExp.ImageTransparentColor = Color.Magenta;
      this.addORExp.Name = "addORExp";
      this.addORExp.Size = new Size(27, 22);
      this.addORExp.Text = "OR";
      this.addORExp.Click += new EventHandler(this.addORExp_Click);
      this.addXORExp.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addXORExp.Image = (Image) componentResourceManager.GetObject("addXORExp.Image");
      this.addXORExp.ImageTransparentColor = Color.Magenta;
      this.addXORExp.Name = "addXORExp";
      this.addXORExp.Size = new Size(34, 22);
      this.addXORExp.Text = "XOR";
      this.addXORExp.Click += new EventHandler(this.addXORExp_Click);
      this.addNANDExp.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addNANDExp.Image = (Image) componentResourceManager.GetObject("addNANDExp.Image");
      this.addNANDExp.ImageTransparentColor = Color.Magenta;
      this.addNANDExp.Name = "addNANDExp";
      this.addNANDExp.Size = new Size(45, 22);
      this.addNANDExp.Text = "NAND";
      this.addNANDExp.Click += new EventHandler(this.addNANDExp_Click);
      this.addNORExp.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addNORExp.Image = (Image) componentResourceManager.GetObject("addNORExp.Image");
      this.addNORExp.ImageTransparentColor = Color.Magenta;
      this.addNORExp.Name = "addNORExp";
      this.addNORExp.Size = new Size(36, 22);
      this.addNORExp.Text = "NOR";
      this.addNORExp.Click += new EventHandler(this.addNORExp_Click);
      this.addXNORExp.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addXNORExp.Image = (Image) componentResourceManager.GetObject("addXNORExp.Image");
      this.addXNORExp.ImageTransparentColor = Color.Magenta;
      this.addXNORExp.Name = "addXNORExp";
      this.addXNORExp.Size = new Size(43, 22);
      this.addXNORExp.Text = "XNOR";
      this.addXNORExp.Click += new EventHandler(this.addXNORExp_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.addNOTExp.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addNOTExp.Image = (Image) componentResourceManager.GetObject("addNOTExp.Image");
      this.addNOTExp.ImageTransparentColor = Color.Magenta;
      this.addNOTExp.Name = "addNOTExp";
      this.addNOTExp.Size = new Size(36, 22);
      this.addNOTExp.Text = "NOT";
      this.addNOTExp.Click += new EventHandler(this.addNOTExp_Click);
      this.bexpText.BorderStyle = BorderStyle.None;
      this.bexpText.Dock = DockStyle.Fill;
      this.bexpText.Font = new Font("Corbel", 38.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.bexpText.Location = new Point(0, 25);
      this.bexpText.Multiline = false;
      this.bexpText.Name = "bexpText";
      this.bexpText.ScrollBars = RichTextBoxScrollBars.Horizontal;
      this.bexpText.Size = new Size(416, 67);
      this.bexpText.TabIndex = 1;
      this.bexpText.Text = "";
      this.bexpText.TextChanged += new EventHandler(this.bexpText_TextChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoValidate = AutoValidate.EnableAllowFocusChange;
      this.ClientSize = new Size(416, 92);
      this.Controls.Add((Control) this.bexpText);
      this.Controls.Add((Control) this.toolStrip1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = "ExpressionBox";
      this.Text = "Boolean Equation Editor";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void addExpression(string text)
    {
      int selectionStart = this.bexpText.SelectionStart;
      this.bexpText.Text = this.bexpText.Text.Insert(selectionStart, text);
      this.bexpText.Select(selectionStart, text.Length);
    }

    public Gates.GateObject getDiagram()
    {
      Gates.GateObject gateObject = this.diagramStore;
      this.diagramStore = (Gates.GateObject) null;
      return gateObject;
    }

    public void changeEquation(string eq)
    {
      this.bexpText.Text = eq;
      if (this.bexpText.TextLength <= 12)
        return;
      this.Width += (this.bexpText.TextLength - 12) * 15;
    }

    public string getEquation()
    {
      return this.bexpText.Text;
    }

    public void setEquation(string equation)
    {
      this.bexpText.Text = equation;
    }

    private void addANDExp_Click(object sender, EventArgs e)
    {
      this.addExpression("#.#");
    }

    private void addORExp_Click(object sender, EventArgs e)
    {
      this.addExpression("#+#");
    }

    private void addXORExp_Click(object sender, EventArgs e)
    {
      this.addExpression("#^#");
    }

    private void addNANDExp_Click(object sender, EventArgs e)
    {
      this.addExpression("`(#.#)");
    }

    private void addNORExp_Click(object sender, EventArgs e)
    {
      this.addExpression("`(#+#)");
    }

    private void addXNORExp_Click(object sender, EventArgs e)
    {
      this.addExpression("`(#^#)");
    }

    private void addNOTExp_Click(object sender, EventArgs e)
    {
      this.addExpression("`(#)");
    }

    private void showError(int pos, bool bracketError = false)
    {
      if (!bracketError)
      {
        int num = (int) MessageBox.Show((IWin32Window) this, "Invalid character found at " + (pos + 1).ToString() + ".", "Invalid Character in Equation!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.bexpText.Select(pos, 1);
      }
      else
      {
        int num1 = (int) MessageBox.Show((IWin32Window) this, "The brackets in the equation are not balenced!", "Bracket Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private bool checkEquation(string equation)
    {
      char[] chArray = new char[6]
      {
        '(',
        ')',
        '`',
        '+',
        '.',
        '^'
      };
      if (equation == "")
      {
        int num = (int) MessageBox.Show((IWin32Window) this, "This operation cannot be performed on an empty equation.", "Empty Equation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      int num1 = 0;
      int num2 = 0;
      for (int pos = 0; pos < equation.Length; ++pos)
      {
        if (!char.IsLetter(equation[pos]) && !Enumerable.Contains<char>((IEnumerable<char>) chArray, equation[pos]))
        {
          this.showError(pos, false);
          return false;
        }
        if (Enumerable.Contains<char>((IEnumerable<char>) chArray, equation[pos]))
        {
          if ((int) equation[pos] == 40)
            ++num1;
          else if ((int) equation[pos] == 41)
          {
            ++num2;
            if (pos + 1 <= equation.Length - 1 && char.IsLetter(equation[pos + 1]))
            {
              this.showError(pos + 1, false);
              return false;
            }
          }
          if (pos + 1 < equation.Length)
          {
            if ((int) equation[pos] == 96 && (int) equation[pos + 1] != 40)
            {
              this.showError(pos + 1, false);
              return false;
            }
            if (Enumerable.Contains<char>((IEnumerable<char>) chArray, equation[pos + 1]) && ((int) equation[pos] == 41 && (char.IsLetter(equation[pos + 1]) || (int) equation[pos + 1] == 40)))
            {
              this.showError(pos + 1, false);
              return false;
            }
          }
        }
        else if (pos + 1 <= equation.Length - 1 && char.IsLetter(equation[pos + 1]))
        {
          this.showError(pos + 1, false);
          return false;
        }
      }
      if (num2 != num1)
      {
        this.showError(0, true);
        return false;
      }
      if ((int) equation[equation.Length - 1] != 46 && (int) equation[equation.Length - 1] != 43 && ((int) equation[equation.Length - 1] != 94 && (int) equation[equation.Length - 1] != 40) && (int) equation[equation.Length - 1] != 96)
        return true;
      this.showError(equation.Length - 1, false);
      return false;
    }

    private void bool2TruthBtn_Click(object sender, EventArgs e)
    {
      if (!this.checkEquation(this.bexpText.Text))
        return;
      this.truthtable.createTruthTable(this.bexpText.Text, FileSave.grabOptions().useBinary);
      int num = (int) this.truthtable.ShowDialog();
    }

    private void bool2DiagramBtn_Click(object sender, EventArgs e)
    {
      if (!this.checkEquation(this.bexpText.Text))
        return;
      Gates.Output output = new Gates.Output(new Point(400, 200));
      ExpressionBox.Equation2DiagramConverter diagramConverter = new ExpressionBox.Equation2DiagramConverter();
      this.Close();
      this.diagramStore = diagramConverter.EquationToDiagram(this.getEquation(), "NONE", (Gates.GateObject) output);
    }

    private void bexpText_TextChanged(object sender, EventArgs e)
    {
      if (this.bexpText.TextLength <= 12 || this.Width - 10 * this.bexpText.TextLength > this.initWidth)
        return;
      this.Width += 20;
    }

    private class Equation2DiagramConverter
    {
      private List<Gates.GateObject> outputs = new List<Gates.GateObject>();

      public Tuple<Gates.GateObject, string, string> findLastGate(string equation)
      {
        if (equation.Length == 1)
          return new Tuple<Gates.GateObject, string, string>((Gates.GateObject) new Gates.Input(new Point(0, 0), equation[0].ToString()), "NONE", "NONE");
        char[] chArray = new char[3]
        {
          '+',
          '^',
          '.'
        };
        if ((int) equation[0] == 40 || (int) equation[0] == 96 && (int) equation[1] == 40)
        {
          bool flag = false;
          int num1 = 1;
          int num2 = 1;
          if ((int) equation[0] == 96)
            num2 = 2;
          for (int index = num2; index < equation.Length; ++index)
          {
            if ((int) equation[index] == 40 || (int) equation[index] == 40 && (int) equation[index] == 96)
              ++num1;
            else if ((int) equation[index] == 41)
              --num1;
            if (num1 == 0 && index == equation.Length - 1)
              flag = true;
            if (num1 == 0 && index != equation.Length - 1)
              break;
          }
          if (flag)
          {
            if ((int) equation[0] == 96)
            {
              equation = equation.Remove(0, 2);
              equation = equation.Remove(equation.Length - 1, 1);
              return new Tuple<Gates.GateObject, string, string>((Gates.GateObject) new Gates.NOTGate(new Point(0, 0)), equation, "NONE");
            }
            if ((int) equation[0] == 40)
            {
              equation = equation.Remove(0, 1);
              equation = equation.Remove(equation.Length - 1, 1);
            }
          }
        }
        int num = 0;
        for (int index = 0; index < chArray.Length; ++index)
        {
          for (int length = 0; length < equation.Length; ++length)
          {
            if ((int) equation[length] == 40)
              ++num;
            else if ((int) equation[length] == 41)
              --num;
            if (num == 0 && (int) equation[length] == (int) chArray[index])
            {
              string str1 = equation.Substring(0, length);
              string str2 = equation.Substring(length + 1);
              if ((int) chArray[index] == 46)
                return new Tuple<Gates.GateObject, string, string>((Gates.GateObject) new Gates.ANDGate(new Point(0, 0)), str1, str2);
              if ((int) chArray[index] == 94)
                return new Tuple<Gates.GateObject, string, string>((Gates.GateObject) new Gates.XORGate(new Point(0, 0)), str1, str2);
              if ((int) chArray[index] == 43)
                return new Tuple<Gates.GateObject, string, string>((Gates.GateObject) new Gates.ORGate(new Point(0, 0)), str1, str2);
            }
          }
        }
        return (Tuple<Gates.GateObject, string, string>) null;
      }

      public Gates.GateObject EquationToDiagram(string left, string right, Gates.GateObject node)
      {
        Point pos;
        if (left != "NONE")
        {
          Tuple<Gates.GateObject, string, string> lastGate = this.findLastGate(left);
          node.input1 = lastGate.Item1;
          if (lastGate.Item1.GetType() == typeof (Gates.Input))
          {
            bool flag = false;
            for (int index = 0; index < this.outputs.Count; ++index)
            {
              if (lastGate.Item1.getName() == this.outputs[index].getName())
              {
                node.input1 = this.outputs[index];
                flag = true;
                break;
              }
            }
            if (!flag)
              this.outputs.Add(lastGate.Item1);
          }
          pos = node.getPos();
          node.input1.setPos(new Point(pos.X - 70, pos.Y - 40));
          this.EquationToDiagram(lastGate.Item2, lastGate.Item3, node.input1);
        }
        if (right != "NONE")
        {
          Tuple<Gates.GateObject, string, string> lastGate = this.findLastGate(right);
          node.input2 = lastGate.Item1;
          if (lastGate.Item1.GetType() == typeof (Gates.Input))
          {
            bool flag = false;
            for (int index = 0; index < this.outputs.Count; ++index)
            {
              if (lastGate.Item1.getName() == this.outputs[index].getName())
              {
                node.input2 = this.outputs[index];
                flag = true;
                break;
              }
            }
            if (!flag)
              this.outputs.Add(lastGate.Item1);
          }
          pos = node.getPos();
          node.input2.setPos(new Point(pos.X - 70, pos.Y + 40));
          this.EquationToDiagram(lastGate.Item2, lastGate.Item3, node.input2);
        }
        return node;
      }
    }
  }
}
