using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Logical
{
  public class gateArea : Panel
  {
    private List<Gates.GateObject> connectedGates = new List<Gates.GateObject>();
    private List<Gates.GateObject> processingList = new List<Gates.GateObject>();
    private List<Point[]> wireList = new List<Point[]>();
    private int wireHighlight = -1;
    private bool isClicked = false;
    private bool mouseDown = false;
    private bool drawingWire = false;
    private Point wireStart = new Point();
    private Point wireEnd = new Point();
    private bool simulating = false;
    private int mouseX = -1;
    private int mouseY = -1;
    private int mouseXAfter = -1;
    private int mouseYAfter = -1;
    private IContainer components = (IContainer) null;
    private Gates.GateObject gatePointer;
    private Tuple<Gates.GateObject, Point, string> firstClick;

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 32;
        return createParams;
      }
    }

    public gateArea()
    {
      this.InitializeComponent();
      this.isClicked = false;
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      for (int index = 0; index < this.connectedGates.Count; ++index)
        this.renderGates(this.connectedGates[index], e);
      Pen pen = new Pen(Color.Black, 2f);
      if (!this.drawingWire)
        return;
      e.Graphics.DrawLines(pen, this.calculatePoints(this.wireStart, this.wireEnd));
    }

    public Gates.GateObject getGateIndex(int mx, int my)
    {
      for (int index = this.connectedGates.Count - 1; index >= 0; --index)
      {
        if (this.connectedGates == null)
        {
          this.connectedGates.Remove((Gates.GateObject) null);
        }
        else
        {
          Point pos = this.connectedGates[index].getPos();
          if (mx >= pos.X - 30 && mx <= pos.X + 70)
          {
            if (my >= pos.Y - 30 && my <= pos.Y + 50)
              return this.connectedGates[index];
          }
          else
          {
            gateArea.ObjectFinder objectFinder = new gateArea.ObjectFinder();
            objectFinder.findRecursive(this.connectedGates[index], mx, my);
            Gates.GateObject gateObject = objectFinder.output;
            if (gateObject != null)
              return gateObject;
          }
        }
      }
      return (Gates.GateObject) null;
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      this.drawingWire = false;
      this.isClicked = !this.isClicked;
      if (e.Button != MouseButtons.Left)
        return;
      if (MainForm.__lineTool)
      {
        if (this.firstClick == null)
        {
          this.gatePointer = (Gates.GateObject) null;
          this.drawingWire = true;
          this.firstClick = this.getclickedConnection(e.X, e.Y);
          if (this.firstClick == null)
          {
            this.isClicked = false;
            this.drawingWire = false;
            return;
          }
          this.wireStart = this.firstClick.Item2;
        }
        else
        {
          Tuple<Gates.GateObject, Point, string> tuple = this.getclickedConnection(e.X, e.Y);
          if (tuple != null)
            this.connectGates(this.firstClick.Item1, this.firstClick.Item3, tuple.Item1, tuple.Item3);
          this.firstClick = (Tuple<Gates.GateObject, Point, string>) null;
        }
      }
      else if (MainForm.__cutTool)
      {
        this.wireHighlight = this.getClickedWire(e.X, e.Y);
        if (this.wireHighlight != -1)
        {
          this.gatePointer = (Gates.GateObject) null;
          Point[] pointArray = this.wireList[this.wireHighlight];
          Point point = pointArray[pointArray.Length - 1];
          Tuple<Gates.GateObject, Point, string> tuple = this.getclickedConnection(point.X, point.Y);
          if (tuple.Item3 == "Left")
            tuple.Item1.input1 = (Gates.GateObject) null;
          else if (tuple.Item3 == "Right")
            tuple.Item1.input2 = (Gates.GateObject) null;
        }
      }
      this.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left && MainForm.__pointerTool)
        this.gatePointer = this.getGateIndex(e.X, e.Y);
      base.OnMouseDown(e);
      this.mouseDown = true;
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      this.gatePointer = (Gates.GateObject) null;
      this.mouseDown = false;
      this.mouseX = -1;
      this.mouseY = -1;
      this.mouseXAfter = -1;
      this.mouseYAfter = -1;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (this.mouseDown && this.gatePointer != null && MainForm.__pointerTool)
        this.gatePointer.setPos(new Point(e.X - 25, e.Y - 25));
      else if (MainForm.__lineTool && this.drawingWire && this.wireStart != new Point())
        this.wireEnd = new Point(e.X, e.Y);
      else if (MainForm.__panTool && this.mouseDown)
      {
        if (this.mouseX == -1 && this.mouseY == -1)
        {
          this.mouseX = e.X;
          this.mouseY = e.Y;
        }
        else if (this.mouseXAfter == -1 && this.mouseYAfter == -1)
        {
          this.mouseXAfter = e.X;
          this.mouseYAfter = e.Y;
        }
        else
        {
          for (int index = 0; index < this.connectedGates.Count; ++index)
            this.panEnvironment(this.mouseX - this.mouseXAfter, this.mouseY - this.mouseYAfter);
          this.mouseX = -1;
          this.mouseY = -1;
          this.mouseXAfter = -1;
          this.mouseYAfter = -1;
        }
      }
      else if (MainForm.__cutTool)
        this.wireHighlight = this.getClickedWire(e.X, e.Y);
      this.Invalidate();
    }

    private int getClickedWire(int mx, int my)
    {
      for (int index1 = 0; index1 < this.wireList.Count; ++index1)
      {
        for (int index2 = 0; index2 < this.wireList[index1].Length - 1; ++index2)
        {
          if (this.checkWireIntersection(new Point(mx, my), this.wireList[index1][index2], this.wireList[index1][index2 + 1]))
          {
            this.wireHighlight = index1;
            return this.wireHighlight;
          }
        }
      }
      return -1;
    }

    private void panEnvironment(int deltamx, int deltamy)
    {
      for (int index = 0; index < this.processingList.Count; ++index)
      {
        Point pos = this.processingList[index].getPos();
        pos.X += (int) Math.Round((double) -deltamx * 0.5);
        pos.Y += (int) Math.Round((double) -deltamy * 0.5);
        this.processingList[index].setPos(pos);
      }
    }

    private float getDistancePoints(Point p1, Point p2)
    {
      return (float) (int) Math.Sqrt(Math.Pow((double) (p1.X - p2.X), 2.0) + Math.Pow((double) (p1.Y - p2.Y), 2.0));
    }

    private bool checkWireIntersection(Point pointer, Point wire1, Point wire2)
    {
      return pointer.Y <= wire1.Y + 3 && pointer.Y >= wire1.Y - 3 && (pointer.X <= Math.Max(wire1.X, wire2.X) + 2 && pointer.X >= Math.Min(wire1.X, wire2.X) - 2 || wire1.X - wire2.X == 0) || wire1.X == wire2.X && (pointer.X >= wire1.X - 2 && pointer.X <= wire1.X + 2) && (pointer.Y <= Math.Max(wire1.Y, wire2.Y) + 2 && pointer.Y >= Math.Min(wire1.Y, wire2.Y) - 2);
    }

    private Tuple<Gates.GateObject, Point, string> getclickedConnection(int mx, int my)
    {
      Gates.GateObject gateIndex = this.getGateIndex(mx, my);
      if (gateIndex == null)
        return (Tuple<Gates.GateObject, Point, string>) null;
      int[][] circlePositions = gateIndex.getCirclePositions();
      Point pos = gateIndex.getPos();
      if (gateIndex.GetType() == typeof (Gates.Input))
      {
        Point point = new Point(pos.X + circlePositions[0][0], pos.Y + circlePositions[0][1] + 2);
        string str = "Out";
        return new Tuple<Gates.GateObject, Point, string>(gateIndex, point, str);
      }
      if (gateIndex.GetType() == typeof (Gates.Output))
      {
        Point point = new Point(pos.X + circlePositions[0][0], pos.Y + circlePositions[0][1] + 2);
        string str = "Left";
        return new Tuple<Gates.GateObject, Point, string>(gateIndex, point, str);
      }
      int index1 = 0;
      float num = -1f;
      for (int index2 = 0; index2 < circlePositions.Length; ++index2)
      {
        float distancePoints = this.getDistancePoints(new Point(mx, my), new Point(pos.X + circlePositions[index2][0], pos.Y + circlePositions[index2][1] + 2));
        if ((double) num == -1.0)
          num = distancePoints;
        if ((double) distancePoints < (double) num)
        {
          num = distancePoints;
          index1 = index2;
        }
      }
      Point point1 = new Point(pos.X + circlePositions[index1][0], pos.Y + circlePositions[index1][1] + 2);
      string str1 = index1 != 0 ? (index1 != 1 ? "Right" : "Left") : "Out";
      return new Tuple<Gates.GateObject, Point, string>(gateIndex, point1, str1);
    }

    private void connectGates(Gates.GateObject gate1, string in1, Gates.GateObject gate2, string in2)
    {
      if (in1 == "Out")
      {
        if (object.ReferenceEquals((object) gate1.input1, (object) gate2) || object.ReferenceEquals((object) gate1.input2, (object) gate2))
          return;
        if (in2 == "Left")
        {
          gate2.input1 = gate1;
        }
        else
        {
          if (!(in2 == "Right"))
            return;
          gate2.input2 = gate1;
        }
      }
      else
      {
        if (!(in2 == "Out") || (object.ReferenceEquals((object) gate2.input1, (object) gate1) || object.ReferenceEquals((object) gate2.input2, (object) gate1)))
          return;
        if (in1 == "Left")
          gate1.input1 = gate2;
        else if (in1 == "Right")
          gate1.input2 = gate2;
      }
    }

    public void AddGate(Gates.GateObject gate)
    {
      this.connectedGates.Add(gate);
      this.processingList.Add(gate);
      this.Invalidate();
    }

    public void deleteGate(Gates.GateObject gateToFind)
    {
      for (int index = 0; index < this.connectedGates.Count; ++index)
      {
        if (this.connectedGates[index] == gateToFind)
        {
          if (this.connectedGates[index].hasLeft() && this.connectedGates[index].input1 != null)
            this.connectedGates.Add(this.connectedGates[index].input1);
          if (this.connectedGates[index].hasRight() && this.connectedGates[index].input2 != null)
            this.connectedGates.Add(this.connectedGates[index].input2);
          this.connectedGates.RemoveAt(index);
        }
        else
          this.deleteGateRec(this.connectedGates[index], gateToFind, (Gates.GateObject) null);
      }
      this.processingList.Remove(gateToFind);
    }

    public void setProcessingList(Gates.GateObject node)
    {
      if (node == null)
        return;
      this.processingList.Add(node);
      if (node.hasLeft())
        this.setProcessingList(node.input1);
      if (!node.hasRight())
        return;
      this.setProcessingList(node.input2);
    }

    public void setDiagram(List<Gates.GateObject> diagram)
    {
      this.processingList.Clear();
      for (int index = 0; index < diagram.Count; ++index)
        this.setProcessingList(diagram[index]);
      this.connectedGates = diagram;
    }

    public void forceRedraw()
    {
      this.Invalidate();
    }

    public List<Gates.GateObject> getDiagram()
    {
      return this.connectedGates;
    }

    public List<Gates.GateObject> getProcessing()
    {
      return this.processingList;
    }

    public void setProcessing(List<Gates.GateObject> pList)
    {
      this.processingList = pList;
    }

    public void deleteGateRec(Gates.GateObject node, Gates.GateObject gateToFind, Gates.GateObject previous = null)
    {
      if (node == gateToFind)
      {
        if (node.hasLeft() && node.input1 != null)
          this.connectedGates.Add(node.input1);
        if (node.hasRight() && node.input2 != null)
          this.connectedGates.Add(node.input2);
        if (previous.hasRight() && previous.input2 == node)
          previous.input2 = (Gates.GateObject) null;
        if (previous.hasLeft() && previous.input1 == node)
          previous.input1 = (Gates.GateObject) null;
      }
      if (node == null)
        return;
      if (node.hasLeft() && node.input1 != null)
        this.deleteGateRec(node.input1, gateToFind, node);
      if (!node.hasRight() || node.input2 == null)
        return;
      this.deleteGateRec(node.input2, gateToFind, node);
    }

    public bool getClicked()
    {
      return this.isClicked;
    }

    public void toggleClicked()
    {
      this.isClicked = !this.isClicked;
    }

    public Point[] calculatePoints(Point start, Point end)
    {
      if (end.X > start.X)
      {
        Point[] pointArray = new Point[4];
        int x = start.X + (end.X - start.X) / 2;
        Point point1 = new Point(x, start.Y);
        Point point2 = new Point(x, end.Y);
        pointArray[0] = start;
        pointArray[1] = point1;
        pointArray[2] = point2;
        pointArray[3] = end;
        return pointArray;
      }
      Point[] pointArray1 = new Point[6];
      Point point3 = new Point(start.X + 10, start.Y);
      Point point4 = new Point(point3.X, point3.Y + (end.Y - start.Y) / 2);
      Point point5 = new Point(point4.X - (start.X - end.X + 20), point4.Y);
      Point point6 = new Point(point5.X, point5.Y - (start.Y - end.Y) / 2);
      pointArray1[0] = start;
      pointArray1[1] = point3;
      pointArray1[2] = point4;
      pointArray1[3] = point5;
      pointArray1[4] = point6;
      pointArray1[5] = end;
      return pointArray1;
    }

    public void renderGates(Gates.GateObject gate, PaintEventArgs e)
    {
      if (gate.getOutput() == 1)
        gate.setHighlight(true);
      else
        gate.setHighlight(false);
      Image image = gate.getImage();
      Point pos1 = gate.getPos();
      e.Graphics.DrawImageUnscaled(image, pos1);

      if (gate.GetType() == typeof (Gates.Input) || gate.GetType() == typeof (Gates.Output))
      {
        SolidBrush solidBrush = new SolidBrush(Color.Black);
        Font font = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Bold);
        Point point = new Point(pos1.X + 12, pos1.Y - 10);
        if (gate.GetType() == typeof (Gates.Input))
          e.Graphics.DrawString(gate.getName(), font, (Brush) solidBrush, (PointF) point);
        else
          e.Graphics.DrawString("Q", font, (Brush) solidBrush, (PointF) point);
      }

      Pen pen1 = new Pen(Color.Black, 1f);
      int[][] circlePositions1 = gate.getCirclePositions();
      for (int index = 0; index < circlePositions1.Length; ++index)
        e.Graphics.DrawEllipse(pen1, pos1.X + circlePositions1[index][0], pos1.Y + circlePositions1[index][1], circlePositions1[index][2], circlePositions1[index][3]);
      if (gate == null)
        return;
      Point pos2;
      Point start;
      Point end;
      if (gate.hasLeft() && gate.input1 != null)
      {
        Pen pen2 = new Pen(Color.Black, 2f);
        if (this.wireList.Count == this.wireHighlight && this.wireHighlight != -1)
          pen2 = new Pen(Color.Red, 2f);
        int[][] circlePositions2 = gate.input1.getCirclePositions();
        pos2 = gate.input1.getPos();
        start = new Point(circlePositions2[0][0] + pos2.X + 4, circlePositions2[0][1] + pos2.Y + 2);
        if (gate.input1.getOutput() == 1 && this.simulating)
          pen2 = new Pen(Color.FromArgb(38, 126, 241), 2f);
        if (circlePositions1.Length > 1)
        {
          end = new Point(circlePositions1[1][0] + pos1.X, circlePositions1[1][1] + pos1.Y + 2);
          Point[] points = this.calculatePoints(start, end);
          this.wireList.Add(points);
          e.Graphics.DrawLines(pen2, points);
        }
        else
        {
          end = new Point(circlePositions1[0][0] + pos1.X, circlePositions1[0][1] + pos1.Y + 2);
          Point[] points = this.calculatePoints(start, end);
          this.wireList.Add(points);
          e.Graphics.DrawLines(pen2, points);
        }
        this.renderGates(gate.input1, e);
      }
      if (!gate.hasRight() || gate.input2 == null)
        return;
      Pen pen3 = new Pen(Color.Black, 2f);
      if (this.wireList.Count == this.wireHighlight && this.wireHighlight != -1)
        pen3 = new Pen(Color.Red, 2f);
      int[][] circlePositions3 = gate.input2.getCirclePositions();
      if (gate.input2.getOutput() == 1 && this.simulating)
        pen3 = new Pen(Color.FromArgb(38, 126, 241), 2f);
      pos2 = gate.input2.getPos();
      start = new Point(circlePositions3[0][0] + pos2.X + 4, circlePositions3[0][1] + pos2.Y + 2);
      end = new Point(circlePositions1[2][0] + pos1.X, circlePositions1[2][1] + pos1.Y + 2);
      Point[] points1 = this.calculatePoints(start, end);
      this.wireList.Add(points1);
      e.Graphics.DrawLines(pen3, points1);
      this.renderGates(gate.input2, e);
    }

    public bool SimulateDiagram()
    {
      gateArea.newTreeAnalyser newTreeAnalyser = new gateArea.newTreeAnalyser();
      for (int index = 0; index < this.connectedGates.Count; ++index)
      {
        if (this.connectedGates[index].GetType() == typeof (Gates.Output))
        {
          newTreeAnalyser.simulateDiagram(this.connectedGates[0]);
          if (newTreeAnalyser.error)
          {
            int num = (int) MessageBox.Show((IWin32Window) this, "Diagram incomplete or disconnected objects present!", "Diagram Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.stopSimulation();
            return false;
          }
          this.simulating = true;
        }
      }
      this.Invalidate();
      return true;
    }

    public void stopSimulation()
    {
      this.simulating = false;
      this.resetDiagram(this.connectedGates[0]);
      this.Invalidate();
    }

    public void resetDiagram(Gates.GateObject node)
    {
      node.setHighlight(false);
      if (node.GetType() != typeof (Gates.Input))
      {
        node.in1val = -1;
        node.in2val = -1;
      }
      if (node == null)
        return;
      if (node.hasLeft() && node.input1 != null)
        this.resetDiagram(node.input1);
      if (!node.hasRight() || node.input2 == null)
        return;
      this.resetDiagram(node.input2);
    }

    public string ConvDiaToEquation()
    {
      if (this.connectedGates.Count < 1)
      {
        int num = (int) MessageBox.Show((IWin32Window) this, "Diagram incomplete or disconnected objects present!", "Diagram Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return "ERR";
      }
      gateArea.DiagramToEquation diagramToEquation = new gateArea.DiagramToEquation();
      for (int index = 0; index < this.connectedGates.Count; ++index)
      {
        if (this.connectedGates[index].GetType() == typeof (Gates.Output))
        {
          diagramToEquation.doConversion(this.connectedGates[index]);
          return diagramToEquation.getEquation();
        }
      }
      return "";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.BackColor = SystemColors.GradientInactiveCaption;
      this.Size = new Size(234, 150);
      this.ResumeLayout(false);
    }

    private class ObjectFinder
    {
      public Gates.GateObject output;

      public ObjectFinder()
      {
        this.output = (Gates.GateObject) null;
      }

      public void findRecursive(Gates.GateObject Node, int mx, int my)
      {
        Point pos = Node.getPos();
        if (mx >= pos.X - 30 && mx <= pos.X + 70 && (my >= pos.Y - 30 && my <= pos.Y + 50))
        {
          this.output = Node;
        }
        else
        {
          if (Node == null)
            return;
          if (Node.hasLeft() && Node.input1 != null)
            this.findRecursive(Node.input1, mx, my);
          if (!Node.hasRight() || Node.input2 == null)
            return;
          this.findRecursive(Node.input2, mx, my);
        }
      }
    }

    private class TreeAnalyser
    {
      private Stack<int> stack = new Stack<int>();
      public bool error = false;
      private int result;

      private void simulateDiagramRec(Gates.GateObject Node)
      {
        bool flag = false;
        if (Node == null)
          this.result = this.stack.Pop();
        if (Node.getOutput() != -1)
        {
          this.stack.Push(Node.getOutput());
          if (Node.getOutput() == 1)
            Node.setHighlight(true);
        }
        if (Node.hasLeft())
        {
          if (Node.input1 != null)
          {
            if (Node.input1 == Node.input2)
              flag = true;
            this.simulateDiagramRec(Node.input1);
          }
          else
            this.error = true;
        }
        if (Node.hasRight() && !flag)
        {
          if (Node.input2 != null)
            this.simulateDiagramRec(Node.input2);
          else
            this.error = true;
        }
        if (Node.hasLeft() && Node.hasRight() && this.stack.Count > 0)
        {
          if (Node.in2val == -1 && !flag)
          {
            Node.in2val = this.stack.Pop();
          }
          else
          {
            int num = this.stack.Pop();
            Node.in2val = num;
            this.stack.Push(num);
          }
        }
        if (Node.in1val != -1 || this.stack.Count <= 0)
          return;
        Node.in1val = this.stack.Pop();
        if (Node.in2val != -1 || Node.hasLeft() && !Node.hasRight())
        {
          int output = Node.getOutput();
          this.stack.Push(output);
          if (output == 1)
            Node.setHighlight(true);
        }
      }

      public int simulateDiagram(Gates.GateObject node)
      {
        this.simulateDiagramRec(node);
        return this.result;
      }
    }

    private class newTreeAnalyser
    {
      public bool error = false;
      private int result;

      public void simulateDiagramRecursive(Gates.GateObject node)
      {
        if (node == null)
          return;
        if (node.hasLeft() && node.input1.getOutput() == -1)
          this.simulateDiagramRecursive(node.input1);
        if (node.hasLeft() && node.input1.getOutput() != -1)
          node.in1val = node.input1.getOutput();
        if (node.hasRight() && node.input2.getOutput() == -1)
          this.simulateDiagramRecursive(node.input2);
        if (node.hasRight() && node.input2.getOutput() != -1)
          node.in2val = node.input2.getOutput();
        if (!(node.GetType() == typeof (Gates.Output)) || node.in1val == -1)
          return;
        this.result = node.getOutput();
      }

      public int simulateDiagram(Gates.GateObject node)
      {
        this.simulateDiagramRecursive(node);
        return this.result;
      }
    }

    private class DiagramToEquation
    {
      private string equation = "";

      public string getEquationTerm(Gates.GateObject gate)
      {
        if (gate.GetType() == typeof (Gates.ANDGate))
          return "(#.#)";
        if (gate.GetType() == typeof (Gates.ORGate))
          return "(#+#)";
        if (gate.GetType() == typeof (Gates.XORGate))
          return "(#^#)";
        if (gate.GetType() == typeof (Gates.NANDGate))
          return "`(#.#)";
        if (gate.GetType() == typeof (Gates.NORGate))
          return "`(#+#)";
        if (gate.GetType() == typeof (Gates.XNORGate))
          return "`(#^#)";
        if (gate.GetType() == typeof (Gates.NOTGate))
          return "`(#)";
        return gate.getName();
      }

      public void doConversion(Gates.GateObject node)
      {
        if (node.GetType() != typeof (Gates.Output))
        {
          string equationTerm = this.getEquationTerm(node);
          if (this.equation == "")
          {
            this.equation = equationTerm;
          }
          else
          {
            for (int startIndex = 0; startIndex < this.equation.Length; ++startIndex)
            {
              if ((int) this.equation[startIndex] == 35)
              {
                this.equation = this.equation.Remove(startIndex, 1);
                this.equation = this.equation.Insert(startIndex, equationTerm);
                break;
              }
            }
          }
        }
        if (node == null)
          return;
        if (node.hasLeft() && node.input1 != null)
          this.doConversion(node.input1);
        if (!node.hasRight() || node.input2 == null)
          return;
        this.doConversion(node.input2);
      }

      public string getEquation()
      {
        if (this.equation == "")
        {
          int num = (int) MessageBox.Show("Circuit could not be converted due to incomplete diagram", "Error", MessageBoxButtons.OK);
          return "";
        }
        for (int index = 0; index < this.equation.Length; ++index)
        {
          if ((int) this.equation[index] == 35)
          {
            int num = (int) MessageBox.Show("Circuit could not be converted due to incomplete diagram", "Error", MessageBoxButtons.OK);
            return "";
          }
        }
        if ((int) this.equation[0] != 96 && !char.IsLetter(this.equation[0]))
        {
          this.equation = this.equation.Remove(this.equation.Length - 1, 1);
          this.equation = this.equation.Remove(0, 1);
        }
        return this.equation;
      }
    }
  }
}
