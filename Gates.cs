using Logical.Properties;
using System;
using System.Drawing;

namespace Logical
{
  public class Gates
  {
    [Serializable]
    public class GateObject
    {
      protected int[][] circlepos = new int[3][];
      protected Point pos;
      protected Image gateImage;
      public Gates.GateObject input1;
      public Gates.GateObject input2;
      public int in1val;
      public int in2val;
      protected string name;

      public GateObject(Point initialpos)
      {
        this.pos = initialpos;
        this.name = "";
        this.in1val = -1;
        this.in2val = -1;
      }

      public GateObject()
      {
      }

      public Point getPos()
      {
        return this.pos;
      }

      public void setPos(Point newPos)
      {
        this.pos = newPos;
      }

      public Image getImage()
      {
        return this.gateImage;
      }

      public virtual int[][] getCirclePositions()
      {
        return this.circlepos;
      }

      public virtual bool hasLeft()
      {
        return this.input1 != null;
      }

      public virtual bool hasRight()
      {
        return this.input2 != null;
      }

      public virtual int getOutput()
      {
        return -1;
      }

      public virtual void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.AND_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.AND);
      }

      public string getName()
      {
        return this.name;
      }

      public void setName(string objName)
      {
        this.name = objName;
      }
    }

    [Serializable]
    public class ANDGate : Gates.GateObject
    {
      public ANDGate(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.AND);
        this.circlepos[0] = new int[4]
        {
          40,
          18,
          4,
          4
        };
        this.circlepos[1] = new int[4]
        {
          -5,
          8,
          4,
          4
        };
        this.circlepos[2] = new int[4]
        {
          -5,
          28,
          4,
          4
        };
      }

      public override int getOutput()
      {
        if (this.in1val == -1 || this.in2val == -1)
          return -1;
        return this.in1val & this.in2val;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.AND_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.AND);
      }
    }

    [Serializable]
    public class ORGate : Gates.GateObject
    {
      public ORGate(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.OR);
        this.circlepos[0] = new int[4]
        {
          48,
          18,
          4,
          4
        };
        this.circlepos[1] = new int[4]
        {
          1,
          10,
          4,
          4
        };
        this.circlepos[2] = new int[4]
        {
          1,
          26,
          4,
          4
        };
      }

      public override int getOutput()
      {
        if (this.in1val == -1 || this.in2val == -1)
          return -1;
        return this.in1val == 1 || this.in2val == 1 || this.in1val == 1 && this.in2val == 1 ? 1 : 0;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.OR_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.OR);
      }
    }

    [Serializable]
    public class XORGate : Gates.GateObject
    {
      public XORGate(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.XOR);
        this.circlepos[0] = new int[4]
        {
          54,
          18,
          4,
          4
        };
        this.circlepos[1] = new int[4]
        {
          1,
          8,
          4,
          4
        };
        this.circlepos[2] = new int[4]
        {
          1,
          27,
          4,
          4
        };
      }

      public override int getOutput()
      {
        if (this.in1val == -1 || this.in2val == -1)
          return -1;
        return this.in1val ^ this.in2val;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.XOR_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.XOR);
      }
    }

    [Serializable]
    public class NANDGate : Gates.GateObject
    {
      public NANDGate(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.NAND);
        this.circlepos[0] = new int[4]
        {
          50,
          18,
          4,
          4
        };
        this.circlepos[1] = new int[4]
        {
          -5,
          8,
          4,
          4
        };
        this.circlepos[2] = new int[4]
        {
          -5,
          27,
          4,
          4
        };
      }

      public override int getOutput()
      {
        if (this.in1val == -1 || this.in2val == -1)
          return -1;
        return (this.in1val & this.in2val) == 1 ? 0 : 1;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.NAND_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.NAND);
      }
    }

    [Serializable]
    public class NORGate : Gates.GateObject
    {
      public NORGate(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.NOR);
        this.circlepos[0] = new int[4]
        {
          56,
          18,
          4,
          4
        };
        this.circlepos[1] = new int[4]
        {
          1,
          8,
          4,
          4
        };
        this.circlepos[2] = new int[4]
        {
          1,
          27,
          4,
          4
        };
      }

      public override int getOutput()
      {
        if (this.in1val == -1 || this.in2val == -1)
          return -1;
        return this.in1val == 1 || this.in2val == 1 || this.in1val == 1 && this.in2val == 1 ? 0 : 1;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.NOR_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.NOR);
      }
    }

    [Serializable]
    public class XNORGate : Gates.GateObject
    {
      public XNORGate(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.XNOR);
        this.circlepos[0] = new int[4]
        {
          62,
          18,
          4,
          4
        };
        this.circlepos[1] = new int[4]
        {
          1,
          8,
          4,
          4
        };
        this.circlepos[2] = new int[4]
        {
          1,
          27,
          4,
          4
        };
      }

      public override int getOutput()
      {
        if (this.in1val == -1 || this.in2val == -1)
          return -1;
        return (this.in1val ^ this.in2val) == 1 ? 0 : 1;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.XNOR_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.XNOR);
      }
    }

    [Serializable]
    public class NOTGate : Gates.GateObject
    {
      protected new int[][] circlepos = new int[2][];

      public NOTGate(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.NOT);
        this.circlepos[0] = new int[4]
        {
          52,
          20,
          4,
          4
        };
        this.circlepos[1] = new int[4]
        {
          -4,
          20,
          4,
          4
        };
      }

      public override int getOutput()
      {
        if (this.in1val == -1)
          return -1;
        return this.in1val == 1 ? 0 : 1;
      }

      public override int[][] getCirclePositions()
      {
        return this.circlepos;
      }

      public override bool hasRight()
      {
        return false;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.NOT_H);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.NOT);
      }
    }

    [Serializable]
    public class Input : Gates.GateObject
    {
      protected new int[][] circlepos = new int[1][];

      public Input(Point initialpos, string name)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.outin);
        this.circlepos[0] = new int[4]
        {
          29,
          17,
          4,
          4
        };
        this.in1val = 1;
        this.name = name;
      }

      public override bool hasRight()
      {
        return false;
      }

      public override bool hasLeft()
      {
        return false;
      }

      public void setInput(int value)
      {
        if (value < 0 || value > 1)
          return;
        this.in1val = value;
      }

      public override int[][] getCirclePositions()
      {
        return this.circlepos;
      }

      public override int getOutput()
      {
        return this.in1val;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.outInH);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.outin);
      }
    }

    [Serializable]
    public class Output : Gates.GateObject
    {
      protected new int[][] circlepos = new int[1][];

      public Output(Point initialpos)
        : base(initialpos)
      {
        this.gateImage = (Image) new Bitmap((Image) Resources.outin);
        this.circlepos[0] = new int[4]
        {
          8,
          17,
          4,
          4
        };
      }

      public override bool hasRight()
      {
        return false;
      }

      public override int[][] getCirclePositions()
      {
        return this.circlepos;
      }

      public override void setHighlight(bool val)
      {
        if (val)
          this.gateImage = (Image) new Bitmap((Image) Resources.outInH);
        else
          this.gateImage = (Image) new Bitmap((Image) Resources.outin);
      }

      public override int getOutput()
      {
        return this.in1val;
      }
    }
  }
}
