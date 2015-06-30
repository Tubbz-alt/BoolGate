using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Logical
{
  public class Options : Form
  {
    private IContainer components = (IContainer) null;
    private Button okBtn;
    private GroupBox groupBox1;
    private CheckBox useTrueFalseCheck;
    private GroupBox groupBox2;
    private Label label1;
    private Button choosePathBtn;
    private TextBox defaultPathTxt;
    private Button cancelBtn;
    private FolderBrowserDialog chooseFolderDialog;

    public Options()
    {
      this.InitializeComponent();
    }

    public void grabOptions()
    {
      FileSave.OptionData optionData = FileSave.grabOptions();
      if (optionData.defaultPath != null)
      {
        this.useTrueFalseCheck.Checked = !optionData.useBinary;
        this.defaultPathTxt.Text = optionData.defaultPath;
      }
      else
      {
        this.useTrueFalseCheck.Checked = false;
        this.defaultPathTxt.Text = "C:/";
        FileSave.saveOptions("C:/", true);
      }
    }

    private void choosePathBtn_Click(object sender, EventArgs e)
    {
      int num = (int) this.chooseFolderDialog.ShowDialog();
      if (this.chooseFolderDialog.SelectedPath == null)
        return;
      this.defaultPathTxt.Text = this.chooseFolderDialog.SelectedPath;
    }

    private void Options_Load(object sender, EventArgs e)
    {
      this.grabOptions();
    }

    private void okBtn_Click(object sender, EventArgs e)
    {
      FileSave.saveOptions(this.defaultPathTxt.Text, !this.useTrueFalseCheck.Checked);
      this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.grabOptions();
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Options));
      this.okBtn = new Button();
      this.groupBox1 = new GroupBox();
      this.useTrueFalseCheck = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.label1 = new Label();
      this.choosePathBtn = new Button();
      this.defaultPathTxt = new TextBox();
      this.cancelBtn = new Button();
      this.chooseFolderDialog = new FolderBrowserDialog();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.okBtn.Location = new Point(20, 188);
      this.okBtn.Name = "okBtn";
      this.okBtn.Size = new Size(92, 27);
      this.okBtn.TabIndex = 1;
      this.okBtn.Text = "Ok";
      this.okBtn.UseVisualStyleBackColor = true;
      this.okBtn.Click += new EventHandler(this.okBtn_Click);
      this.groupBox1.Controls.Add((Control) this.useTrueFalseCheck);
      this.groupBox1.Location = new Point(20, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(200, 52);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "General";
      this.useTrueFalseCheck.AutoSize = true;
      this.useTrueFalseCheck.Location = new Point(15, 23);
      this.useTrueFalseCheck.Name = "useTrueFalseCheck";
      this.useTrueFalseCheck.Size = new Size(100, 17);
      this.useTrueFalseCheck.TabIndex = 0;
      this.useTrueFalseCheck.Text = "Use True/False";
      this.useTrueFalseCheck.UseVisualStyleBackColor = true;
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.choosePathBtn);
      this.groupBox2.Controls.Add((Control) this.defaultPathTxt);
      this.groupBox2.Location = new Point(20, 70);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(200, 112);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "File Settings";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 23);
      this.label1.Name = "label1";
      this.label1.Size = new Size(169, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Default file path for saving/loading";
      this.choosePathBtn.Location = new Point(6, 73);
      this.choosePathBtn.Name = "choosePathBtn";
      this.choosePathBtn.Size = new Size(187, 27);
      this.choosePathBtn.TabIndex = 5;
      this.choosePathBtn.Text = "Choose Path...";
      this.choosePathBtn.UseVisualStyleBackColor = true;
      this.choosePathBtn.Click += new EventHandler(this.choosePathBtn_Click);
      this.defaultPathTxt.Location = new Point(7, 47);
      this.defaultPathTxt.Name = "defaultPathTxt";
      this.defaultPathTxt.Size = new Size(186, 20);
      this.defaultPathTxt.TabIndex = 0;
      this.cancelBtn.Location = new Point(121, 188);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new Size(92, 27);
      this.cancelBtn.TabIndex = 5;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new EventHandler(this.cancelBtn_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoValidate = AutoValidate.EnableAllowFocusChange;
      this.ClientSize = new Size(236, 223);
      this.Controls.Add((Control) this.cancelBtn);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.okBtn);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = "Options";
      this.Text = "Options";
      this.Load += new EventHandler(this.Options_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
