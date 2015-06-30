// Decompiled with JetBrains decompiler
// Type: Logical.MainForm
// Assembly: BoolGate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F0D7661-EAFC-4F52-BA76-3A0ABDEAAD45
// Assembly location: C:\Program Files (x86)\Atom Softworks\BoolGate\BoolGate.exe

using Logical.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Logical
{
  public class MainForm : Form
  {
    public static bool __lineTool = false;
    public static bool __cutTool = false;
    public static bool __panTool = false;
    public static bool __pointerTool = true;
    private IContainer components = (IContainer) null;
    private ExpressionBox boolbox = new ExpressionBox();
    private About aboutbox = new About();
    private Options optionbox = new Options();
    private string usedPath = "";
    public string[] alphabet = new string[25]
    {
      "A",
      "B",
      "C",
      "D",
      "E",
      "F",
      "G",
      "H",
      "I",
      "J",
      "K",
      "L",
      "M",
      "N",
      "O",
      "P",
      "R",
      "S",
      "T",
      "U",
      "V",
      "W",
      "X",
      "Y",
      "Z"
    };
    public List<string> listnames = new List<string>();
    public int alphacount = 0;
    public int objectNameCount = 1;
    public int timePast = 0;
    public bool trial = false;
    private ToolStripMenuItem truthTableToolStripMenuItem;
    private ToolStripMenuItem booleanExpressionToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripMenuItem viewHelpToolStripMenuItem;
    private SplitContainer splitContainer1;
    private ListView listGates;
    private ToolStrip diaTool;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem createToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private MenuStrip menu;
    private ToolStripMenuItem fileToolStripMenuItem1;
    private ToolStripMenuItem fileToolStripMenuItem2;
    private ToolStripMenuItem toolsToolStripMenuItem1;
    private ToolStripMenuItem helpToolStripMenuItem1;
    private ToolStripMenuItem newBtn;
    private ToolStripMenuItem openBtn;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem saveBtn;
    private ToolStripMenuItem saveAsBtn;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripMenuItem exitBtn;
    private ToolStripMenuItem boolBtn;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripMenuItem convertToToolStripMenuItem;
    private ToolStripMenuItem booleanExpressionToolStripMenuItem1;
    private ToolStripMenuItem truthTableToolStripMenuItem1;
    private ToolStripMenuItem helpBtn;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripMenuItem aboutBtn;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButton2;
    private ToolStripButton toolStripButton4;
    private ToolStripButton toolStripButton3;
    private ToolStripButton toolStripButton5;
    private ToolStripButton toolStripButton6;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton toolStripButton7;
    private ToolStripButton toolStripButton8;
    private ToolStripMenuItem editToolStripMenuItem1;
    private ToolStripMenuItem cWireBtn;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripMenuItem deleteBtn;
    private ToolStripSeparator toolStripSeparator10;
    private ToolStripMenuItem simBtn;
    private ToolStripMenuItem stopBtn;
    private ToolStripSeparator toolStripSeparator11;
    private ToolStripMenuItem optionBtn;
    private ContextMenuStrip diagramContext;
    private ToolStripMenuItem deleteBtnContext;
    private ToolStripMenuItem fileToolStripMenuItem3;
    private ToolStripMenuItem newSessionBtn;
    private ToolStripSeparator toolStripSeparator12;
    private ToolStripMenuItem openFileBtn;
    private ToolStripSeparator toolStripSeparator13;
    private ToolStripMenuItem saveFileBtn;
    private ToolStripMenuItem saveAsFileBtn;
    private ToolStripMenuItem exitMBtn;
    private ToolStripMenuItem toolsToolStripMenuItem2;
    private ToolStripMenuItem boolEqBtn;
    private ToolStripMenuItem convertToToolStripMenuItem1;
    private ToolStripMenuItem conv2EquationBtn;
    private ToolStripMenuItem truthTableBtn;
    private ToolStripSeparator toolStripSeparator17;
    private ToolStripMenuItem optionsBtn;
    private ToolStripMenuItem helpToolStripMenuItem2;
    private ToolStripMenuItem showAboutBtn;
    private ToolStripButton simulateBtn;
    private ToolStripButton stopSimBtn;
    private ToolStripSeparator toolStripSeparator18;
    private ToolStripSeparator toolStripSeparator19;
    private ToolStripComboBox setInputBox;
    private ToolStripMenuItem setInputBtn;
    private ToolStripButton addWireBtn;
    private OpenFileDialog openFileDia;
    private SaveFileDialog saveFileDia;
    private ToolStripButton cutWireTool;
    private ToolStripSeparator toolStripSeparator15;
    private ToolStripButton pointerButton;
    private ToolStripButton panTool;
    private ToolStripMenuItem cutBtnContext;
    private ToolStripMenuItem copyBtnContext;
    private ToolStripMenuItem pasteBtnContext;
    private gateArea area;
    private Timer trialTimer;
    private ToolStripSeparator toolStripSeparator20;
    private Gates.GateObject selectedGate;
    private Gates.GateObject objectStore;
    private bool objectCut;
    private Point contextClickPos;

    public MainForm()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.splitContainer1 = new SplitContainer();
      this.listGates = new ListView();
      this.area = new gateArea();
      this.diagramContext = new ContextMenuStrip(this.components);
      this.cutBtnContext = new ToolStripMenuItem();
      this.copyBtnContext = new ToolStripMenuItem();
      this.pasteBtnContext = new ToolStripMenuItem();
      this.deleteBtnContext = new ToolStripMenuItem();
      this.toolStripSeparator19 = new ToolStripSeparator();
      this.setInputBox = new ToolStripComboBox();
      this.setInputBtn = new ToolStripMenuItem();
      this.diaTool = new ToolStrip();
      this.pointerButton = new ToolStripButton();
      this.panTool = new ToolStripButton();
      this.toolStripSeparator18 = new ToolStripSeparator();
      this.addWireBtn = new ToolStripButton();
      this.cutWireTool = new ToolStripButton();
      this.toolStripSeparator15 = new ToolStripSeparator();
      this.simulateBtn = new ToolStripButton();
      this.stopSimBtn = new ToolStripButton();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newToolStripMenuItem = new ToolStripMenuItem();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.saveToolStripMenuItem = new ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.editToolStripMenuItem = new ToolStripMenuItem();
      this.toolsToolStripMenuItem = new ToolStripMenuItem();
      this.createToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.menu = new MenuStrip();
      this.fileToolStripMenuItem3 = new ToolStripMenuItem();
      this.newSessionBtn = new ToolStripMenuItem();
      this.toolStripSeparator12 = new ToolStripSeparator();
      this.openFileBtn = new ToolStripMenuItem();
      this.toolStripSeparator13 = new ToolStripSeparator();
      this.saveFileBtn = new ToolStripMenuItem();
      this.saveAsFileBtn = new ToolStripMenuItem();
      this.toolStripSeparator20 = new ToolStripSeparator();
      this.exitMBtn = new ToolStripMenuItem();
      this.toolsToolStripMenuItem2 = new ToolStripMenuItem();
      this.boolEqBtn = new ToolStripMenuItem();
      this.convertToToolStripMenuItem1 = new ToolStripMenuItem();
      this.conv2EquationBtn = new ToolStripMenuItem();
      this.truthTableBtn = new ToolStripMenuItem();
      this.toolStripSeparator17 = new ToolStripSeparator();
      this.optionsBtn = new ToolStripMenuItem();
      this.helpToolStripMenuItem2 = new ToolStripMenuItem();
      this.showAboutBtn = new ToolStripMenuItem();
      this.fileToolStripMenuItem2 = new ToolStripMenuItem();
      this.newBtn = new ToolStripMenuItem();
      this.openBtn = new ToolStripMenuItem();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.saveBtn = new ToolStripMenuItem();
      this.saveAsBtn = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.exitBtn = new ToolStripMenuItem();
      this.editToolStripMenuItem1 = new ToolStripMenuItem();
      this.deleteBtn = new ToolStripMenuItem();
      this.toolsToolStripMenuItem1 = new ToolStripMenuItem();
      this.cWireBtn = new ToolStripMenuItem();
      this.toolStripSeparator9 = new ToolStripSeparator();
      this.boolBtn = new ToolStripMenuItem();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.convertToToolStripMenuItem = new ToolStripMenuItem();
      this.booleanExpressionToolStripMenuItem1 = new ToolStripMenuItem();
      this.truthTableToolStripMenuItem1 = new ToolStripMenuItem();
      this.toolStripSeparator10 = new ToolStripSeparator();
      this.simBtn = new ToolStripMenuItem();
      this.stopBtn = new ToolStripMenuItem();
      this.toolStripSeparator11 = new ToolStripSeparator();
      this.optionBtn = new ToolStripMenuItem();
      this.helpToolStripMenuItem1 = new ToolStripMenuItem();
      this.helpBtn = new ToolStripMenuItem();
      this.toolStripSeparator8 = new ToolStripSeparator();
      this.aboutBtn = new ToolStripMenuItem();
      this.fileToolStripMenuItem1 = new ToolStripMenuItem();
      this.openFileDia = new OpenFileDialog();
      this.saveFileDia = new SaveFileDialog();
      this.toolStripButton5 = new ToolStripButton();
      this.toolStripButton6 = new ToolStripButton();
      this.toolStripButton7 = new ToolStripButton();
      this.toolStripButton8 = new ToolStripButton();
      this.toolStripButton1 = new ToolStripButton();
      this.toolStripButton2 = new ToolStripButton();
      this.toolStripButton4 = new ToolStripButton();
      this.toolStripButton3 = new ToolStripButton();
      this.truthTableToolStripMenuItem = new ToolStripMenuItem();
      this.booleanExpressionToolStripMenuItem = new ToolStripMenuItem();
      this.optionsToolStripMenuItem = new ToolStripMenuItem();
      this.viewHelpToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.trialTimer = new Timer(this.components);
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.diagramContext.SuspendLayout();
      this.diaTool.SuspendLayout();
      this.menu.SuspendLayout();
      this.SuspendLayout();
      this.splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.splitContainer1.Location = new Point(0, 24);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.listGates);
      this.splitContainer1.Panel2.Controls.Add((Control) this.area);
      this.splitContainer1.Panel2.Controls.Add((Control) this.diaTool);
      this.splitContainer1.Size = new Size(820, 586);
      this.splitContainer1.SplitterDistance = 160;
      this.splitContainer1.TabIndex = 1;
      this.listGates.Activation = ItemActivation.TwoClick;
      this.listGates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.listGates.BackColor = SystemColors.InactiveBorder;
      this.listGates.BorderStyle = BorderStyle.None;
      this.listGates.Location = new Point(0, 0);
      this.listGates.MultiSelect = false;
      this.listGates.Name = "listGates";
      this.listGates.Size = new Size(161, 586);
      this.listGates.TabIndex = 0;
      this.listGates.TileSize = new Size(80, 80);
      this.listGates.UseCompatibleStateImageBehavior = false;
      this.listGates.Click += new EventHandler(this.listGates_Click);
      this.area.BackColor = SystemColors.InactiveBorder;
      this.area.ContextMenuStrip = this.diagramContext;
      this.area.Dock = DockStyle.Fill;
      this.area.Location = new Point(0, 25);
      this.area.Name = "area";
      this.area.Size = new Size(656, 561);
      this.area.TabIndex = 1;
      this.area.MouseDown += new MouseEventHandler(this.area_MouseDown);
      this.diagramContext.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.cutBtnContext,
        (ToolStripItem) this.copyBtnContext,
        (ToolStripItem) this.pasteBtnContext,
        (ToolStripItem) this.deleteBtnContext,
        (ToolStripItem) this.toolStripSeparator19,
        (ToolStripItem) this.setInputBox,
        (ToolStripItem) this.setInputBtn
      });
      this.diagramContext.Name = "diagramContext";
      this.diagramContext.Size = new Size(182, 147);
      this.cutBtnContext.Image = (Image) componentResourceManager.GetObject("cutBtnContext.Image");
      this.cutBtnContext.Name = "cutBtnContext";
      this.cutBtnContext.Size = new Size(181, 22);
      this.cutBtnContext.Text = "Cut";
      this.cutBtnContext.Click += new EventHandler(this.cutBtnContext_Click);
      this.copyBtnContext.Image = (Image) componentResourceManager.GetObject("copyBtnContext.Image");
      this.copyBtnContext.Name = "copyBtnContext";
      this.copyBtnContext.Size = new Size(181, 22);
      this.copyBtnContext.Text = "Copy";
      this.copyBtnContext.Click += new EventHandler(this.copyBtnContext_Click);
      this.pasteBtnContext.Image = (Image) componentResourceManager.GetObject("pasteBtnContext.Image");
      this.pasteBtnContext.Name = "pasteBtnContext";
      this.pasteBtnContext.Size = new Size(181, 22);
      this.pasteBtnContext.Text = "Paste";
      this.pasteBtnContext.Click += new EventHandler(this.pasteBtnContext_Click);
      this.deleteBtnContext.Image = (Image) componentResourceManager.GetObject("deleteBtnContext.Image");
      this.deleteBtnContext.Name = "deleteBtnContext";
      this.deleteBtnContext.Size = new Size(181, 22);
      this.deleteBtnContext.Text = "Delete";
      this.deleteBtnContext.Click += new EventHandler(this.deleteBtnContext_Click);
      this.toolStripSeparator19.Name = "toolStripSeparator19";
      this.toolStripSeparator19.Size = new Size(178, 6);
      this.setInputBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.setInputBox.Items.AddRange(new object[2]
      {
        (object) "1",
        (object) "0"
      });
      this.setInputBox.Name = "setInputBox";
      this.setInputBox.Size = new Size(121, 23);
      this.setInputBtn.Name = "setInputBtn";
      this.setInputBtn.Size = new Size(181, 22);
      this.setInputBtn.Text = "Set Input Value";
      this.setInputBtn.Click += new EventHandler(this.setInputBtn_Click);
      this.diaTool.GripStyle = ToolStripGripStyle.Hidden;
      this.diaTool.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.pointerButton,
        (ToolStripItem) this.panTool,
        (ToolStripItem) this.toolStripSeparator18,
        (ToolStripItem) this.addWireBtn,
        (ToolStripItem) this.cutWireTool,
        (ToolStripItem) this.toolStripSeparator15,
        (ToolStripItem) this.simulateBtn,
        (ToolStripItem) this.stopSimBtn
      });
      this.diaTool.Location = new Point(0, 0);
      this.diaTool.Name = "diaTool";
      this.diaTool.RenderMode = ToolStripRenderMode.Professional;
      this.diaTool.Size = new Size(656, 25);
      this.diaTool.TabIndex = 0;
      this.diaTool.Text = "diaTools";
      this.pointerButton.Checked = true;
      this.pointerButton.CheckState = CheckState.Checked;
      this.pointerButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.pointerButton.Image = (Image) componentResourceManager.GetObject("pointerButton.Image");
      this.pointerButton.ImageTransparentColor = Color.Magenta;
      this.pointerButton.Name = "pointerButton";
      this.pointerButton.Size = new Size(23, 22);
      this.pointerButton.Text = "Pointer Tool";
      this.pointerButton.Click += new EventHandler(this.pointerButton_Click);
      this.panTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.panTool.Image = (Image) componentResourceManager.GetObject("panTool.Image");
      this.panTool.ImageTransparentColor = Color.Magenta;
      this.panTool.Name = "panTool";
      this.panTool.Size = new Size(23, 22);
      this.panTool.Text = "Pan Tool";
      this.panTool.Click += new EventHandler(this.panTool_Click);
      this.toolStripSeparator18.Name = "toolStripSeparator18";
      this.toolStripSeparator18.Size = new Size(6, 25);
      this.addWireBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.addWireBtn.Image = (Image) componentResourceManager.GetObject("addWireBtn.Image");
      this.addWireBtn.ImageTransparentColor = Color.Magenta;
      this.addWireBtn.Name = "addWireBtn";
      this.addWireBtn.Size = new Size(23, 22);
      this.addWireBtn.Text = "Wire Tool";
      this.addWireBtn.Click += new EventHandler(this.addWireBtn_Click);
      this.cutWireTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.cutWireTool.Image = (Image) componentResourceManager.GetObject("cutWireTool.Image");
      this.cutWireTool.ImageTransparentColor = Color.Magenta;
      this.cutWireTool.Name = "cutWireTool";
      this.cutWireTool.Size = new Size(23, 22);
      this.cutWireTool.Text = "Wire Cut Tool";
      this.cutWireTool.Click += new EventHandler(this.cutWireTool_Click);
      this.toolStripSeparator15.Name = "toolStripSeparator15";
      this.toolStripSeparator15.Size = new Size(6, 25);
      this.simulateBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.simulateBtn.Image = (Image) componentResourceManager.GetObject("simulateBtn.Image");
      this.simulateBtn.ImageTransparentColor = Color.Magenta;
      this.simulateBtn.Name = "simulateBtn";
      this.simulateBtn.Size = new Size(23, 22);
      this.simulateBtn.Text = "Simulate Diagram";
      this.simulateBtn.Click += new EventHandler(this.simulateBtn_Click);
      this.stopSimBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.stopSimBtn.Image = (Image) componentResourceManager.GetObject("stopSimBtn.Image");
      this.stopSimBtn.ImageTransparentColor = Color.Magenta;
      this.stopSimBtn.Name = "stopSimBtn";
      this.stopSimBtn.Size = new Size(23, 22);
      this.stopSimBtn.Text = "Stop Simulation";
      this.stopSimBtn.Click += new EventHandler(this.stopSimBtn_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(6, 25);
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new Size(152, 22);
      this.newToolStripMenuItem.Text = "New";
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new Size(152, 22);
      this.openToolStripMenuItem.Text = "Open";
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new Size(152, 22);
      this.saveToolStripMenuItem.Text = "Save";
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new Size(152, 22);
      this.saveAsToolStripMenuItem.Text = "Save As...";
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(149, 6);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(152, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new Size(39, 20);
      this.editToolStripMenuItem.Text = "Edit";
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new Size(48, 20);
      this.toolsToolStripMenuItem.Text = "Tools";
      this.createToolStripMenuItem.Name = "createToolStripMenuItem";
      this.createToolStripMenuItem.Size = new Size(152, 22);
      this.createToolStripMenuItem.Text = "Create";
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(149, 6);
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(149, 6);
      this.menu.BackColor = SystemColors.Control;
      this.menu.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.fileToolStripMenuItem3,
        (ToolStripItem) this.toolsToolStripMenuItem2,
        (ToolStripItem) this.helpToolStripMenuItem2
      });
      this.menu.Location = new Point(0, 0);
      this.menu.Name = "menu";
      this.menu.RenderMode = ToolStripRenderMode.Professional;
      this.menu.Size = new Size(820, 24);
      this.menu.TabIndex = 0;
      this.menu.Text = "menu";
      this.fileToolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.newSessionBtn,
        (ToolStripItem) this.toolStripSeparator12,
        (ToolStripItem) this.openFileBtn,
        (ToolStripItem) this.toolStripSeparator13,
        (ToolStripItem) this.saveFileBtn,
        (ToolStripItem) this.saveAsFileBtn,
        (ToolStripItem) this.toolStripSeparator20,
        (ToolStripItem) this.exitMBtn
      });
      this.fileToolStripMenuItem3.Name = "fileToolStripMenuItem3";
      this.fileToolStripMenuItem3.Size = new Size(37, 20);
      this.fileToolStripMenuItem3.Text = "File";
      this.newSessionBtn.Image = (Image) componentResourceManager.GetObject("newSessionBtn.Image");
      this.newSessionBtn.Name = "newSessionBtn";
      this.newSessionBtn.Size = new Size(152, 22);
      this.newSessionBtn.Text = "New";
      this.newSessionBtn.Click += new EventHandler(this.newSessionBtn_Click);
      this.toolStripSeparator12.Name = "toolStripSeparator12";
      this.toolStripSeparator12.Size = new Size(149, 6);
      this.openFileBtn.Image = (Image) componentResourceManager.GetObject("openFileBtn.Image");
      this.openFileBtn.Name = "openFileBtn";
      this.openFileBtn.Size = new Size(152, 22);
      this.openFileBtn.Text = "Open";
      this.openFileBtn.Click += new EventHandler(this.openFileBtn_Click);
      this.toolStripSeparator13.Name = "toolStripSeparator13";
      this.toolStripSeparator13.Size = new Size(149, 6);
      this.saveFileBtn.Image = (Image) componentResourceManager.GetObject("saveFileBtn.Image");
      this.saveFileBtn.Name = "saveFileBtn";
      this.saveFileBtn.Size = new Size(152, 22);
      this.saveFileBtn.Text = "Save";
      this.saveFileBtn.Click += new EventHandler(this.saveFileBtn_Click);
      this.saveAsFileBtn.Image = (Image) componentResourceManager.GetObject("saveAsFileBtn.Image");
      this.saveAsFileBtn.Name = "saveAsFileBtn";
      this.saveAsFileBtn.Size = new Size(152, 22);
      this.saveAsFileBtn.Text = "Save As..";
      this.saveAsFileBtn.Click += new EventHandler(this.saveAsFileBtn_Click);
      this.toolStripSeparator20.Name = "toolStripSeparator20";
      this.toolStripSeparator20.Size = new Size(149, 6);
      this.exitMBtn.Image = (Image) componentResourceManager.GetObject("exitMBtn.Image");
      this.exitMBtn.Name = "exitMBtn";
      this.exitMBtn.Size = new Size(152, 22);
      this.exitMBtn.Text = "Exit";
      this.exitMBtn.Click += new EventHandler(this.exitMBtn_Click);
      this.toolsToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.boolEqBtn,
        (ToolStripItem) this.convertToToolStripMenuItem1,
        (ToolStripItem) this.toolStripSeparator17,
        (ToolStripItem) this.optionsBtn
      });
      this.toolsToolStripMenuItem2.Name = "toolsToolStripMenuItem2";
      this.toolsToolStripMenuItem2.Size = new Size(48, 20);
      this.toolsToolStripMenuItem2.Text = "Tools";
      this.boolEqBtn.Image = (Image) componentResourceManager.GetObject("boolEqBtn.Image");
      this.boolEqBtn.Name = "boolEqBtn";
      this.boolEqBtn.Size = new Size(201, 22);
      this.boolEqBtn.Text = "Boolean Equation Editor";
      this.boolEqBtn.Click += new EventHandler(this.boolEqBtn_Click);
      this.convertToToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.conv2EquationBtn,
        (ToolStripItem) this.truthTableBtn
      });
      this.convertToToolStripMenuItem1.Image = (Image) componentResourceManager.GetObject("convertToToolStripMenuItem1.Image");
      this.convertToToolStripMenuItem1.Name = "convertToToolStripMenuItem1";
      this.convertToToolStripMenuItem1.Size = new Size(201, 22);
      this.convertToToolStripMenuItem1.Text = "Convert To...";
      this.conv2EquationBtn.Image = (Image) componentResourceManager.GetObject("conv2EquationBtn.Image");
      this.conv2EquationBtn.Name = "conv2EquationBtn";
      this.conv2EquationBtn.Size = new Size(167, 22);
      this.conv2EquationBtn.Text = "Boolean Equation";
      this.conv2EquationBtn.Click += new EventHandler(this.conv2EquationBtn_Click);
      this.truthTableBtn.Image = (Image) componentResourceManager.GetObject("truthTableBtn.Image");
      this.truthTableBtn.Name = "truthTableBtn";
      this.truthTableBtn.Size = new Size(167, 22);
      this.truthTableBtn.Text = "Truth Table";
      this.truthTableBtn.Click += new EventHandler(this.truthTableBtn_Click);
      this.toolStripSeparator17.Name = "toolStripSeparator17";
      this.toolStripSeparator17.Size = new Size(198, 6);
      this.optionsBtn.Image = (Image) componentResourceManager.GetObject("optionsBtn.Image");
      this.optionsBtn.Name = "optionsBtn";
      this.optionsBtn.Size = new Size(201, 22);
      this.optionsBtn.Text = "Options";
      this.optionsBtn.Click += new EventHandler(this.optionsBtn_Click);
      this.helpToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.showAboutBtn
      });
      this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
      this.helpToolStripMenuItem2.Size = new Size(44, 20);
      this.helpToolStripMenuItem2.Text = "Help";
      this.showAboutBtn.Image = (Image) componentResourceManager.GetObject("showAboutBtn.Image");
      this.showAboutBtn.Name = "showAboutBtn";
      this.showAboutBtn.Size = new Size(152, 22);
      this.showAboutBtn.Text = "About";
      this.showAboutBtn.Click += new EventHandler(this.showAboutBtn_Click);
      this.fileToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.newBtn,
        (ToolStripItem) this.openBtn,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.saveBtn,
        (ToolStripItem) this.saveAsBtn,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.exitBtn
      });
      this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
      this.fileToolStripMenuItem2.Size = new Size(37, 20);
      this.fileToolStripMenuItem2.Text = "File";
      this.newBtn.Image = (Image) componentResourceManager.GetObject("newBtn.Image");
      this.newBtn.Name = "newBtn";
      this.newBtn.Size = new Size(123, 22);
      this.newBtn.Text = "New";
      this.openBtn.Image = (Image) componentResourceManager.GetObject("openBtn.Image");
      this.openBtn.Name = "openBtn";
      this.openBtn.Size = new Size(123, 22);
      this.openBtn.Text = "Open";
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(120, 6);
      this.saveBtn.Image = (Image) componentResourceManager.GetObject("saveBtn.Image");
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new Size(123, 22);
      this.saveBtn.Text = "Save";
      this.saveAsBtn.Image = (Image) componentResourceManager.GetObject("saveAsBtn.Image");
      this.saveAsBtn.Name = "saveAsBtn";
      this.saveAsBtn.Size = new Size(123, 22);
      this.saveAsBtn.Text = "Save As...";
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(120, 6);
      this.exitBtn.Image = (Image) componentResourceManager.GetObject("exitBtn.Image");
      this.exitBtn.Name = "exitBtn";
      this.exitBtn.Size = new Size(123, 22);
      this.exitBtn.Text = "Exit";
      this.editToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.deleteBtn
      });
      this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
      this.editToolStripMenuItem1.Size = new Size(39, 20);
      this.editToolStripMenuItem1.Text = "Edit";
      this.deleteBtn.Image = (Image) componentResourceManager.GetObject("deleteBtn.Image");
      this.deleteBtn.Name = "deleteBtn";
      this.deleteBtn.Size = new Size(107, 22);
      this.deleteBtn.Text = "Delete";
      this.toolsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.cWireBtn,
        (ToolStripItem) this.toolStripSeparator9,
        (ToolStripItem) this.boolBtn,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.convertToToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator10,
        (ToolStripItem) this.simBtn,
        (ToolStripItem) this.stopBtn,
        (ToolStripItem) this.toolStripSeparator11,
        (ToolStripItem) this.optionBtn
      });
      this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
      this.toolsToolStripMenuItem1.Size = new Size(48, 20);
      this.toolsToolStripMenuItem1.Text = "Tools";
      this.cWireBtn.Image = (Image) componentResourceManager.GetObject("cWireBtn.Image");
      this.cWireBtn.Name = "cWireBtn";
      this.cWireBtn.Size = new Size(209, 22);
      this.cWireBtn.Text = "Create Wire";
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new Size(206, 6);
      this.boolBtn.Image = (Image) componentResourceManager.GetObject("boolBtn.Image");
      this.boolBtn.Name = "boolBtn";
      this.boolBtn.Size = new Size(209, 22);
      this.boolBtn.Text = "Boolean Expression Editor";
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(206, 6);
      this.convertToToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.booleanExpressionToolStripMenuItem1,
        (ToolStripItem) this.truthTableToolStripMenuItem1
      });
      this.convertToToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("convertToToolStripMenuItem.Image");
      this.convertToToolStripMenuItem.Name = "convertToToolStripMenuItem";
      this.convertToToolStripMenuItem.Size = new Size(209, 22);
      this.convertToToolStripMenuItem.Text = "Convert To...";
      this.booleanExpressionToolStripMenuItem1.Image = (Image) componentResourceManager.GetObject("booleanExpressionToolStripMenuItem1.Image");
      this.booleanExpressionToolStripMenuItem1.Name = "booleanExpressionToolStripMenuItem1";
      this.booleanExpressionToolStripMenuItem1.Size = new Size(175, 22);
      this.booleanExpressionToolStripMenuItem1.Text = "Boolean Expression";
      this.truthTableToolStripMenuItem1.Image = (Image) componentResourceManager.GetObject("truthTableToolStripMenuItem1.Image");
      this.truthTableToolStripMenuItem1.Name = "truthTableToolStripMenuItem1";
      this.truthTableToolStripMenuItem1.Size = new Size(175, 22);
      this.truthTableToolStripMenuItem1.Text = "Truth Table";
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new Size(206, 6);
      this.simBtn.Image = (Image) componentResourceManager.GetObject("simBtn.Image");
      this.simBtn.Name = "simBtn";
      this.simBtn.Size = new Size(209, 22);
      this.simBtn.Text = "Simulate Diagram";
      this.stopBtn.Image = (Image) componentResourceManager.GetObject("stopBtn.Image");
      this.stopBtn.Name = "stopBtn";
      this.stopBtn.Size = new Size(209, 22);
      this.stopBtn.Text = "Stop Simulation";
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new Size(206, 6);
      this.optionBtn.Image = (Image) componentResourceManager.GetObject("optionBtn.Image");
      this.optionBtn.Name = "optionBtn";
      this.optionBtn.Size = new Size(209, 22);
      this.optionBtn.Text = "Options";
      this.helpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.helpBtn,
        (ToolStripItem) this.toolStripSeparator8,
        (ToolStripItem) this.aboutBtn
      });
      this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
      this.helpToolStripMenuItem1.Size = new Size(44, 20);
      this.helpToolStripMenuItem1.Text = "Help";
      this.helpBtn.Image = (Image) componentResourceManager.GetObject("helpBtn.Image");
      this.helpBtn.Name = "helpBtn";
      this.helpBtn.Size = new Size((int) sbyte.MaxValue, 22);
      this.helpBtn.Text = "View Help";
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new Size(124, 6);
      this.aboutBtn.Image = (Image) componentResourceManager.GetObject("aboutBtn.Image");
      this.aboutBtn.Name = "aboutBtn";
      this.aboutBtn.Size = new Size((int) sbyte.MaxValue, 22);
      this.aboutBtn.Text = "About";
      this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
      this.fileToolStripMenuItem1.Size = new Size(37, 20);
      this.fileToolStripMenuItem1.Text = "File";
      this.openFileDia.Filter = "Logical Save Files|*.lsv";
      this.saveFileDia.Filter = "Logical Save Files|*.lsv|All files|*.*";
      this.toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton5.Image = (Image) componentResourceManager.GetObject("toolStripButton5.Image");
      this.toolStripButton5.ImageTransparentColor = Color.Magenta;
      this.toolStripButton5.Name = "toolStripButton5";
      this.toolStripButton5.Size = new Size(23, 20);
      this.toolStripButton5.Text = "Simulate Diagram";
      this.toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton6.Image = (Image) componentResourceManager.GetObject("toolStripButton6.Image");
      this.toolStripButton6.ImageTransparentColor = Color.Magenta;
      this.toolStripButton6.Name = "toolStripButton6";
      this.toolStripButton6.Size = new Size(23, 20);
      this.toolStripButton6.Text = "Stop Simulation";
      this.toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton7.Image = (Image) componentResourceManager.GetObject("toolStripButton7.Image");
      this.toolStripButton7.ImageTransparentColor = Color.Magenta;
      this.toolStripButton7.Name = "toolStripButton7";
      this.toolStripButton7.Size = new Size(23, 20);
      this.toolStripButton7.Text = "Draw Wire";
      this.toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton8.Image = (Image) componentResourceManager.GetObject("toolStripButton8.Image");
      this.toolStripButton8.ImageTransparentColor = Color.Magenta;
      this.toolStripButton8.Name = "toolStripButton8";
      this.toolStripButton8.Size = new Size(23, 20);
      this.toolStripButton8.Text = "Delete Object";
      this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = (Image) componentResourceManager.GetObject("toolStripButton1.Image");
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(23, 20);
      this.toolStripButton1.Text = "toolStripButton1";
      this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton2.Image = (Image) componentResourceManager.GetObject("toolStripButton2.Image");
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(23, 20);
      this.toolStripButton2.Text = "toolStripButton2";
      this.toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton4.Image = (Image) componentResourceManager.GetObject("toolStripButton4.Image");
      this.toolStripButton4.ImageTransparentColor = Color.Magenta;
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButton4.Size = new Size(23, 20);
      this.toolStripButton4.Text = "toolStripButton4";
      this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton3.Image = (Image) componentResourceManager.GetObject("toolStripButton3.Image");
      this.toolStripButton3.ImageTransparentColor = Color.Magenta;
      this.toolStripButton3.Name = "toolStripButton3";
      this.toolStripButton3.Size = new Size(23, 20);
      this.toolStripButton3.Text = "toolStripButton3";
      this.truthTableToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("truthTableToolStripMenuItem.Image");
      this.truthTableToolStripMenuItem.Name = "truthTableToolStripMenuItem";
      this.truthTableToolStripMenuItem.Size = new Size(181, 22);
      this.truthTableToolStripMenuItem.Text = "Truth Table";
      this.booleanExpressionToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("booleanExpressionToolStripMenuItem.Image");
      this.booleanExpressionToolStripMenuItem.Name = "booleanExpressionToolStripMenuItem";
      this.booleanExpressionToolStripMenuItem.Size = new Size(181, 22);
      this.booleanExpressionToolStripMenuItem.Text = "Boolean Expression";
      this.optionsToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("optionsToolStripMenuItem.Image");
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new Size(181, 22);
      this.optionsToolStripMenuItem.Text = "Options";
      this.viewHelpToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("viewHelpToolStripMenuItem.Image");
      this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
      this.viewHelpToolStripMenuItem.Size = new Size(181, 22);
      this.viewHelpToolStripMenuItem.Text = "View Help";
      this.aboutToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("aboutToolStripMenuItem.Image");
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(181, 22);
      this.aboutToolStripMenuItem.Text = "About";
      this.trialTimer.Interval = 60000;
      this.trialTimer.Tick += new EventHandler(this.trialTimer_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.ClientSize = new Size(820, 610);
      this.Controls.Add((Control) this.splitContainer1);
      this.Controls.Add((Control) this.menu);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menu;
      this.Name = "MainForm";
      this.Text = "BoolGate";
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new EventHandler(this.MainForm_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.diagramContext.ResumeLayout(false);
      this.diaTool.ResumeLayout(false);
      this.diaTool.PerformLayout();
      this.menu.ResumeLayout(false);
      this.menu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.createListView();
      this.stopSimBtn.Enabled = false;
      Gates.Output output = new Gates.Output(new Point(400, 215));
      Gates.Input input1 = new Gates.Input(new Point(50, 130), "A");
      Gates.Input input2 = new Gates.Input(new Point(50, 300), "B");
      this.alphacount = 1;
      this.area.AddGate((Gates.GateObject) output);
      this.area.AddGate((Gates.GateObject) input1);
      this.area.AddGate((Gates.GateObject) input2);
      this.setupObjectNameList();
      this.listnames.Remove("A");
      this.listnames.Remove("B");
      if (!this.trial)
        return;
      this.trialTimer.Start();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.boolbox.Dispose();
    }

    private void setupObjectNameList()
    {
      this.listnames.AddRange((IEnumerable<string>) this.alphabet);
    }

    public void createListView()
    {
      ImageList imageList = new ImageList();
      this.listGates.LargeImageList = imageList;
      imageList.ImageSize = new Size(100, 50);
      imageList.Images.Add((Image) new Bitmap((Image) Resources.AND1));
      this.listGates.Items.Add(new ListViewItem("AND", imageList.Images.Count - 1));
      imageList.Images.Add((Image) new Bitmap((Image) Resources.OR1));
      this.listGates.Items.Add(new ListViewItem("OR", imageList.Images.Count - 1));
      imageList.Images.Add((Image) new Bitmap((Image) Resources.XOR1));
      this.listGates.Items.Add(new ListViewItem("XOR", imageList.Images.Count - 1));
      imageList.Images.Add((Image) new Bitmap((Image) Resources.NOT1));
      this.listGates.Items.Add(new ListViewItem("NOT", imageList.Images.Count - 1));
      imageList.Images.Add((Image) new Bitmap((Image) Resources.NAND1));
      this.listGates.Items.Add(new ListViewItem("NAND", imageList.Images.Count - 1));
      imageList.Images.Add((Image) new Bitmap((Image) Resources.NOR1));
      this.listGates.Items.Add(new ListViewItem("NOR", imageList.Images.Count - 1));
      imageList.Images.Add((Image) new Bitmap((Image) Resources.XNOR1));
      this.listGates.Items.Add(new ListViewItem("XNOR", imageList.Images.Count - 1));
      imageList.Images.Add((Image) new Bitmap((Image) Resources.Input));
      this.listGates.Items.Add(new ListViewItem("Input", imageList.Images.Count - 1));
    }

    private void listGates_Click(object sender, EventArgs e)
    {
      string text = this.listGates.SelectedItems[0].Text;
      if (text == "AND")
        this.area.AddGate((Gates.GateObject) new Gates.ANDGate(new Point(10, 10)));
      else if (text == "OR")
        this.area.AddGate((Gates.GateObject) new Gates.ORGate(new Point(10, 10)));
      else if (text == "XOR")
        this.area.AddGate((Gates.GateObject) new Gates.XORGate(new Point(10, 10)));
      else if (text == "NOT")
        this.area.AddGate((Gates.GateObject) new Gates.NOTGate(new Point(10, 10)));
      else if (text == "NAND")
        this.area.AddGate((Gates.GateObject) new Gates.NANDGate(new Point(10, 10)));
      else if (text == "NOR")
        this.area.AddGate((Gates.GateObject) new Gates.NORGate(new Point(10, 10)));
      else if (text == "XNOR")
      {
        this.area.AddGate((Gates.GateObject) new Gates.XNORGate(new Point(10, 10)));
      }
      else
      {
        if (!(text == "Input"))
          return;
        if (this.listnames.Count > 0)
        {
          this.area.AddGate((Gates.GateObject) new Gates.Input(new Point(10, 10), this.listnames[0]));
          this.listnames.Remove(this.listnames[0]);
        }
        else
        {
          if (this.objectNameCount > 9)
          {
            this.objectNameCount = 1;
            ++this.alphacount;
          }
          this.area.AddGate((Gates.GateObject) new Gates.Input(new Point(10, 10), this.alphabet[this.alphacount] + this.objectNameCount.ToString()));
          ++this.objectNameCount;
        }
      }
    }

    private void addWireBtn_Click(object sender, EventArgs e)
    {
      if (MainForm.__lineTool)
        return;
      this.Cursor = Cursors.Cross;
      MainForm.__pointerTool = false;
      MainForm.__lineTool = true;
      MainForm.__panTool = false;
      MainForm.__cutTool = false;
      this.pointerButton.Checked = false;
      this.panTool.Checked = false;
      this.cutWireTool.Checked = false;
      this.addWireBtn.Checked = true;
    }

    private void panTool_Click(object sender, EventArgs e)
    {
      if (MainForm.__panTool)
        return;
      this.Cursor = Cursors.SizeAll;
      MainForm.__pointerTool = false;
      MainForm.__lineTool = false;
      MainForm.__panTool = true;
      MainForm.__cutTool = false;
      this.pointerButton.Checked = false;
      this.addWireBtn.Checked = false;
      this.cutWireTool.Checked = false;
      this.panTool.Checked = true;
    }

    private void pointerButton_Click(object sender, EventArgs e)
    {
      if (MainForm.__pointerTool)
        return;
      this.Cursor = Cursors.Default;
      MainForm.__pointerTool = true;
      MainForm.__lineTool = false;
      MainForm.__panTool = false;
      MainForm.__cutTool = false;
      this.addWireBtn.Checked = false;
      this.panTool.Checked = false;
      this.cutWireTool.Checked = false;
      this.pointerButton.Checked = true;
    }

    private void cutWireTool_Click(object sender, EventArgs e)
    {
      if (MainForm.__cutTool)
        return;
      this.Cursor = Cursors.Default;
      MainForm.__pointerTool = false;
      MainForm.__lineTool = false;
      MainForm.__panTool = false;
      MainForm.__cutTool = true;
      this.addWireBtn.Checked = false;
      this.panTool.Checked = false;
      this.pointerButton.Checked = false;
      this.cutWireTool.Checked = true;
    }

    private void boolEqBtn_Click(object sender, EventArgs e)
    {
      int num = (int) this.boolbox.ShowDialog();
      Gates.GateObject diagram1 = this.boolbox.getDiagram();
      List<Gates.GateObject> diagram2 = new List<Gates.GateObject>();
      diagram2.Add(diagram1);
      if (diagram1 == null)
        return;
      this.area.setDiagram(diagram2);
      this.area.forceRedraw();
    }

    private void simulateBtn_Click(object sender, EventArgs e)
    {
      this.addWireBtn.Enabled = false;
      this.simulateBtn.Enabled = false;
      this.stopSimBtn.Enabled = true;
      this.listGates.Enabled = false;
      this.menu.Enabled = false;
      if (this.area.SimulateDiagram())
        return;
      this.addWireBtn.Enabled = true;
      this.simulateBtn.Enabled = true;
      this.stopSimBtn.Enabled = false;
      this.listGates.Enabled = true;
      this.menu.Enabled = true;
    }

    private void stopSimBtn_Click(object sender, EventArgs e)
    {
      this.addWireBtn.Enabled = true;
      this.simulateBtn.Enabled = true;
      this.stopSimBtn.Enabled = false;
      this.listGates.Enabled = true;
      this.menu.Enabled = true;
      this.area.stopSimulation();
    }

    private void area_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.contextClickPos = new Point(e.X, e.Y);
      this.selectedGate = this.area.getGateIndex(e.X, e.Y);
      if (this.selectedGate == null || this.selectedGate.GetType() == typeof (Gates.Output))
      {
        this.setInputBox.Enabled = false;
        this.deleteBtnContext.Enabled = false;
        this.setInputBtn.Enabled = false;
        this.cutBtnContext.Enabled = false;
        this.copyBtnContext.Enabled = false;
        if (this.objectStore == null)
          this.pasteBtnContext.Enabled = false;
        else
          this.pasteBtnContext.Enabled = true;
      }
      else if (this.selectedGate.GetType() == typeof (Gates.Input))
      {
        this.setInputBox.Enabled = true;
        this.deleteBtnContext.Enabled = true;
        this.setInputBtn.Enabled = true;
        this.cutBtnContext.Enabled = true;
        this.copyBtnContext.Enabled = true;
        this.pasteBtnContext.Enabled = false;
        this.setInputBox.Text = this.selectedGate.in1val.ToString();
      }
      else
      {
        this.setInputBox.Enabled = false;
        this.deleteBtnContext.Enabled = true;
        this.copyBtnContext.Enabled = true;
        this.cutBtnContext.Enabled = true;
        this.pasteBtnContext.Enabled = false;
        this.setInputBtn.Enabled = false;
      }
    }

    private void setInputBtn_Click(object sender, EventArgs e)
    {
      this.selectedGate.in1val = (int) Convert.ToInt16(this.setInputBox.Text);
    }

    private void deleteBtnContext_Click(object sender, EventArgs e)
    {
      if (this.selectedGate == null)
        return;
      if (this.selectedGate.GetType() == typeof (Gates.Input))
        this.listnames.Insert(0, this.selectedGate.getName());
      this.area.deleteGate(this.selectedGate);
    }

    private void conv2EquationBtn_Click(object sender, EventArgs e)
    {
      this.boolbox.changeEquation(this.area.ConvDiaToEquation());
      int num = (int) this.boolbox.ShowDialog();
    }

    private void truthTableBtn_Click(object sender, EventArgs e)
    {
      if (!(this.area.ConvDiaToEquation() != "ERR"))
        return;
      TruthTable truthTable = new TruthTable();
      truthTable.createTruthTable(this.area.ConvDiaToEquation(), FileSave.grabOptions().useBinary);
      truthTable.Show();
    }

    public bool checkSave()
    {
      switch (MessageBox.Show((IWin32Window) this, "This action will modify the current session. Do you wish to save before continuing?", "Logical", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
      {
        case DialogResult.Yes:
          this.saveFileDia.InitialDirectory = FileSave.grabOptions().defaultPath;
          int num = (int) this.saveFileDia.ShowDialog();
          this.saveFile(this.saveFileDia.FileName);
          return true;
        case DialogResult.No:
          return true;
        default:
          return false;
      }
    }

    public void setDiagram(List<Gates.GateObject> diagram)
    {
      this.area.setDiagram(diagram);
    }

    private void saveAsFileBtn_Click(object sender, EventArgs e)
    {
      this.saveFileDia.InitialDirectory = FileSave.grabOptions().defaultPath;
      int num = (int) this.saveFileDia.ShowDialog();
      this.saveFile(this.saveFileDia.FileName);
    }

    private void openFileBtn_Click(object sender, EventArgs e)
    {
      if (!this.checkSave())
        return;
      this.openFileDia.InitialDirectory = FileSave.grabOptions().defaultPath;
      int num = (int) this.openFileDia.ShowDialog();
      string fileName = this.openFileDia.FileName;
      if (fileName != "")
      {
        FileSave.SaveData saveData = FileSave.loadFile(fileName);
        this.area.setDiagram(saveData.diagram);
        this.boolbox.setEquation(saveData.equation);
        this.area.setProcessing(saveData.processing);
        this.usedPath = fileName;
        this.Text = "Logical - " + fileName;
        this.area.forceRedraw();
      }
    }

    private void saveFile(string path)
    {
      if (!(path != ""))
        return;
      FileSave.saveFile(this.boolbox.getEquation(), this.area.getDiagram(), this.area.getProcessing(), path);
      this.usedPath = path;
      this.Text = "Logical - " + path;
    }

    private void saveFileBtn_Click(object sender, EventArgs e)
    {
      if (this.usedPath == "")
      {
        this.saveFileDia.InitialDirectory = FileSave.grabOptions().defaultPath;
        int num = (int) this.saveFileDia.ShowDialog();
        this.saveFile(this.saveFileDia.FileName);
      }
      else
        this.saveFile(this.usedPath);
    }

    private void exitMBtn_Click(object sender, EventArgs e)
    {
      if (!this.checkSave())
        return;
      this.Close();
    }

    private void newSessionBtn_Click(object sender, EventArgs e)
    {
      if (!this.checkSave())
        return;
      Gates.Output output = new Gates.Output(new Point(400, 115));
      Gates.Input input1 = new Gates.Input(new Point(50, 30), "A");
      Gates.Input input2 = new Gates.Input(new Point(50, 200), "B");
      List<Gates.GateObject> diagram = new List<Gates.GateObject>();
      diagram.Add((Gates.GateObject) output);
      diagram.Add((Gates.GateObject) input1);
      diagram.Add((Gates.GateObject) input2);
      this.boolbox.setEquation("");
      this.alphacount = 1;
      this.area.setDiagram(diagram);
      this.area.forceRedraw();
    }

    private void showAboutBtn_Click(object sender, EventArgs e)
    {
      int num = (int) this.aboutbox.ShowDialog();
    }

    private void optionsBtn_Click(object sender, EventArgs e)
    {
      int num = (int) this.optionbox.ShowDialog();
    }

    private void cutBtnContext_Click(object sender, EventArgs e)
    {
      if (this.selectedGate == null)
        return;
      this.objectStore = Utilities.DeepClone<Gates.GateObject>(this.selectedGate);
      this.area.deleteGate(this.selectedGate);
      this.objectCut = true;
    }

    private void copyBtnContext_Click(object sender, EventArgs e)
    {
      if (this.selectedGate == null)
        return;
      this.objectStore = Utilities.DeepClone<Gates.GateObject>(this.selectedGate);
      this.objectCut = false;
    }

    private void pasteBtnContext_Click(object sender, EventArgs e)
    {
      this.objectStore.setPos(this.contextClickPos);
      if (this.objectCut)
      {
        this.area.AddGate(Utilities.DeepClone<Gates.GateObject>(this.objectStore));
        this.objectStore = (Gates.GateObject) null;
      }
      else if (this.objectStore.GetType() != typeof (Gates.Input))
      {
        this.area.AddGate(Utilities.DeepClone<Gates.GateObject>(this.objectStore));
      }
      else
      {
        if (this.objectCut || !(this.objectStore.GetType() == typeof (Gates.Input)))
          return;
        if (this.listnames.Count > 0)
        {
          this.objectStore.setName(this.listnames[0]);
          this.listnames.RemoveAt(0);
        }
        else
        {
          if (this.objectNameCount > 9)
          {
            this.objectNameCount = 1;
            ++this.alphacount;
          }
          this.objectStore.setName(this.alphabet[this.alphacount] + this.objectNameCount.ToString());
          ++this.objectNameCount;
        }
        this.area.AddGate(Utilities.DeepClone<Gates.GateObject>(this.objectStore));
      }
    }

    private void trialTimer_Tick(object sender, EventArgs e)
    {
      ++this.timePast;
    }
  }
}
