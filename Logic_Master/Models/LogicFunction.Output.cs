using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    public partial class LogicFunction
    {
        public int GetWidth(int mode, int x)
        {
            if (FField == null)
            {
                return -1;
            }

            int i, w; //i=Счетчик, w=ширина строки
            int p = FLength; //позиция в строке
            int wx = x - FFieldOffset - FFieldRect.Left; //Координата х в ширину
            int type, num; //Аргумент
            string io; //Выводимый символ
            int position = FLength; //Позиция до которой происходит вычисление

            // Вычисление ширины '𝑓 = '
            //FFontCurrent = new Font("Segoe UI Symbol", FFontSize * 1.3f);
            Font font = new Font("Segoe UI Symbol", FFontSize * 1.3f);

            w = (int)FField.MeasureString("𝑓 = ", font).Width + SPACE * 2;


            int dx, dxp;
            if (mode == 3)
            {
                dx = Math.Abs(wx - w);
            }
            else
            {
                dx = 0;
            }


            // Вычисление ширины самой лог. функции (цикл для каждого символа)
            if (mode == 1)
            {
                position = FPosition;
            }
            else if (mode == 2)
            {
                position = FPositionOld;
            }
            else if (mode == 3)
            {
                position = FLength + 1;
            }
            for (i = 0; i < position; i++)
            {
                if (mode == 3)
                {
                    dxp = Math.Abs(wx - w);
                    if (dxp > dx)
                    {
                        p = i - 1;
                        break;
                    }
                    else
                    {
                        dx = dxp;
                    }
                }


                // Определение следующего символа по аргументу
                type = FFunction[i] >> 8;
                num = FFunction[i] & 0xFF;
                ArgumentType argumentType = (ArgumentType)type;
                switch (argumentType)
                {
                    case ArgumentType.Operation:
                        io = FSigns.Substring(num, 1);
                        break;
                    case ArgumentType.Variable:
                        io = "𝑋";
                        break;
                    case ArgumentType.NVariable:
                        io = "𝑋";
                        break;
                    case ArgumentType.FixedValue:
                        io = num == 0 ? "0" : "1";
                        break;
                    case ArgumentType.BracketLeft:
                        io = "(";
                        break;
                    case ArgumentType.NBracketLeft:
                        io = "(";
                        break;
                    case ArgumentType.BracketRight:
                        io = ")";
                        break;
                    default:
                        io = "";
                        break;
                }
                font = new Font("Segoe UI Symbol", FFontSize);
                w += (int)FField.MeasureString(io, font).Width + SPACE;

                // Вывод индекса у переменных
                if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable)
                {
                    w -= SPACE;
                    io = num.ToString();
                    font = new Font("Segoe UI Symbol", FFontSize * 7.0f / 11.0f);
                    w += (int)FField.MeasureString(io, font).Width + SPACE;
                }
            }
            font.Dispose();
            if (mode == 3)
            {
                return p;
            }
            return w;

        }

        public int GetWidth()
        {
            return GetWidth(0, 0);
        }

        public int GetCursorPosX()
        {
            return GetWidth(1, 0);
        }




        public void GoPositionError()
        {
            FPosition = FPositionError;
        }


        public void SetPositionXY(int x, int y)
        {
            if (x >= FFieldRect.Left && x < FFieldRect.Right && y > FFieldRect.Top && y < FFieldRect.Bottom)
            {
                FPosition = GetWidth(3, x);
            }
        }


        public bool Align(Aligment align)
        {
            if (FField == null)
            {
                return false;
            }

            int w, p, f, x;
            FFontCurrent = new Font("Segoe UI Symbol", FFontSize * 1.3f);

            switch (align)
            {
                case Aligment.Left:
                    if (FFieldOffset != FRAME)
                    {
                        FRepaint = true;
                        FFieldOffset = FRAME;
                    }
                    break;
                case Aligment.Center:
                    w = GetWidth();
                    x = (FFieldRect.Right - FFieldRect.Left) / 2 - w / 2;
                    if (FFieldOffset != x)
                    {
                        FRepaint = true;
                        FFieldOffset = x;
                    }
                    break;
                case Aligment.Right:
                    w = GetWidth();
                    x = FFieldRect.Right - FFieldRect.Left - w - FRAME;
                    if (FFieldOffset != x)
                    {
                        FRepaint = true;
                        FFieldOffset = x;
                    }
                    break;
                case Aligment.Cursor:
                    p = GetCursorPosX();
                    f = (int)FField.MeasureString("𝑓 = ", FFontCurrent).Width + SPACE * 2;
                    if (FFieldOffset + p < FRAME + f)
                    {
                        FRepaint = true;
                        FFieldOffset = FRAME + f - p;
                    }
                    if (FFieldOffset + p > FFieldRect.Right - FFieldRect.Left - FRAME)
                    {
                        FRepaint = true;
                        FFieldOffset = FFieldRect.Right - FFieldRect.Left - FRAME - p;
                    }
                    break;
            }
            return true;
        }


        public bool Offset(Direction sp)
        {
            if (FField == null)
            {
                return false;
            }

            switch (sp)
            {
                case Direction.Left:
                    FRepaint = true;
                    FFieldOffset += 10;
                    break;

                case Direction.Right:
                    FRepaint = true;
                    FFieldOffset -= 10;
                    break;

                case Direction.LLeft:
                    FRepaint = true;
                    FFieldOffset += (FFieldRect.Right - FFieldRect.Left) / 2;
                    break;

                case Direction.RRight:
                    FRepaint = true;
                    FFieldOffset -= (FFieldRect.Right - FFieldRect.Left) / 2;
                    break;
            }
            return true;
        }

        public void SetOutput(Rectangle rect)
        {
            Fbitmap = new Bitmap(rect.Width, rect.Height);
            FField = Graphics.FromImage(Fbitmap);
            FFieldColor = Color.White; //настройки цветов
            FFieldRect = rect;
            FFieldCursor = true;
            FRepaint = true;
        }

        public void SetRectangle(Rectangle rect)
        {
            Fbitmap = new Bitmap(rect.Width, rect.Height);
            FField = Graphics.FromImage(Fbitmap);
            FFieldRect = rect;
            FRepaint = true;

        }


        public void SetFontSize(int fontSize)
        {
            FFontSize = fontSize;
        }

        public void SetFieldColor(Color color)
        {
            FFieldColor = color;
            FRepaint = true;
        }

        public void SetCursor(bool cursor)
        {
            FFieldCursor = cursor;
        }

        public string GetSign(int num)
        {
            if (num < 1 || num > 12)
            {
                return "";
            }
            if (num == 11)
            {
                return "0";
            }
            if (num == 12)
            {
                return "1";
            }
            return FSigns.Substring(num, 1);
        }

        public bool SetSign(int num, string s)
        {
            if (num < 1 || num > 12)
            {
                return false;
            }
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            if (s.Length > 1)
            {
                s = s.Substring(1, 1);
            }

            FSigns.Remove(num, 1);
            FSigns.Insert(num, s);
            FRepaint = true;
            return true;
        }

        public bool ClearField()
        {
            if (FField == null)
            {
                return false;
            }
            Brush brush = new SolidBrush(FFieldColor);
            FField.FillRectangle(brush, FFieldRect);
            brush.Dispose();
            return true;
        }

        public bool Paint()
        {
            if (FField == null)
            {
                return false;
            }

            FField.Clear(Color.White);
            Pen pen = new Pen(Color.Black);
            FFontCurrent = new Font("Segoe UI Symbol", FFontSize);


            bool res;
            int i, j;
            int h = (int)FField.MeasureString("𝑋", FFontCurrent).Height;
            int w = (int)FField.MeasureString("(", FFontCurrent).Width;
            int x, y;
            int type, num;
            int xPos = FFieldRect.Left + FFieldOffset;
            int yPos = (FFieldRect.Top + FFieldRect.Bottom) / 2;
            int numBrackets = 0;
            int openBrackets = 0;
            string io;
            //𝑓
            Bracket[] brackets = new Bracket[LIMIT];
            CloseBracket[] closeBrackets = new CloseBracket[LIMIT];

            Rectangle temp = FFieldRect;
            FFontCurrent = new Font("Segoe UI Symbol", FFontSize * 1.3f);
            SizeF textSize = FField.MeasureString("𝑓 = ", FFontCurrent);

            FField.DrawString("𝑓 = ", FFontCurrent, Brushes.Black, xPos, yPos - (textSize.Height - h) / 2.0f);
            xPos += (int)textSize.Width + SPACE * 2;
            res = Solve(true);

            //Brush color = Brushes.Black;

            for (i = 0; i <= FLength; i++)
            {
                if (FPositionError == i && FError != Error.NoError && FFieldCursor)
                {
                    Pen errorPen = new Pen(Color.Red);
                    x = xPos - SPACE;
                    if (x > FFieldRect.Left && x < FFieldRect.Right)
                    {
                        y = yPos < FFieldRect.Top ? FFieldRect.Top : yPos;
                        int oldY = y;
                        y = yPos + h > FFieldRect.Bottom ? FFieldRect.Bottom : yPos + h;
                        FField.DrawLine(errorPen, x, oldY, x, y);
                    }
                }

                else if (FPosition == i)
                {
                    x = xPos - SPACE;
                    if (FFieldCursor && x > FFieldRect.Left && x < FFieldRect.Right)
                    {
                        FPositionOld = FPosition;
                        y = yPos < FFieldRect.Top ? FFieldRect.Top : yPos;
                        int oldY = y;
                        y = yPos + h > FFieldRect.Bottom ? FFieldRect.Bottom : yPos + h;
                        FField.DrawLine(pen, x, oldY, x, y);
                    }
                    else
                    {
                        FPositionOld = -1;
                    }
                }


                else if (i == FLength)
                {
                    break;
                }


                type = FFunction[i] >> 8;
                num = FFunction[i] & 0xFF;
                ArgumentType argumentType = (ArgumentType)type;
                Brush color;
                switch (argumentType)
                {
                    case ArgumentType.Operation:
                        color = Brushes.Blue;
                        io = FSigns.Substring(num, 1);
                        break;
                    case ArgumentType.Variable:
                        color = Brushes.Navy;
                        io = "𝑋";
                        break;
                    case ArgumentType.NVariable:
                        color = Brushes.Navy;
                        io = "𝑋";
                        break;
                    case ArgumentType.FixedValue:
                        color = Brushes.Maroon;
                        io = num == 0 ? "0" : "1";
                        break;
                    case ArgumentType.BracketLeft:
                        color = Brushes.Green;
                        brackets[openBrackets].Type = ArgumentType.BracketLeft;
                        brackets[openBrackets].Start = xPos;
                        openBrackets++;
                        io = "(";
                        break;
                    case ArgumentType.NBracketLeft:
                        color = Brushes.Green;
                        brackets[openBrackets].Type = ArgumentType.NBracketLeft;
                        brackets[openBrackets].Start = xPos;
                        openBrackets++;
                        io = "(";
                        break;
                    case ArgumentType.BracketRight:
                        color = Brushes.Green;
                        if (openBrackets > 0)
                        {
                            openBrackets--;
                            if (brackets[openBrackets].Type == ArgumentType.NBracketLeft)
                            {
                                closeBrackets[numBrackets].Start = brackets[openBrackets].Start;
                                closeBrackets[numBrackets].End = xPos;
                                numBrackets++;
                            }
                        }
                        io = ")";
                        break;
                    default:
                        color = Brushes.Red;
                        io = "";
                        break;

                }

                if (FLength >= LIMIT)
                {
                    color = Brushes.Red;
                }

                if (xPos > temp.Left)
                {
                    temp.X = xPos;
                }

                FFontCurrent = new Font("Segoe UI Symbol", FFontSize);
                
                if (temp.Left < temp.Right)
                {
                    FField.DrawString(io, FFontCurrent, color, xPos, yPos);
                }


                int ioSize = (int)FField.MeasureString(io, FFontCurrent).Width;


                if (argumentType == ArgumentType.NVariable && yPos >= FFieldRect.Top && yPos < FFieldRect.Bottom && xPos < FFieldRect.Right && xPos + ioSize >= FFieldRect.Left)
                {
                    Pen linePen;
                    if (FLength >= LIMIT)
                    {
                        linePen = new Pen(Brushes.Red);
                    }
                    else
                    {
                        linePen = new Pen(Brushes.Navy);
                    }
                    x = xPos < FFieldRect.Left ? FFieldRect.Left : xPos;

                    int oldX = x;
                    x = xPos + ioSize > FFieldRect.Right ? FFieldRect.Right : xPos + ioSize;

                    FField.DrawLine(linePen, oldX, yPos, x, yPos);
                    linePen.Dispose();
                }
                xPos += ioSize + SPACE;

                if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable)
                {
                    xPos -= SPACE;
                    io = num.ToString();
                    FFontCurrent = new Font("Segoe UI Symbol", FFontSize * 7 / 11.0f);

                    if (xPos > temp.Left)
                    {
                        temp.X = xPos;
                    }

                    if (temp.Left < temp.Right)
                    {
                        SizeF ioSizeF = FField.MeasureString(io, FFontCurrent);
                        FField.DrawString(io, FFontCurrent, color, xPos, yPos + h - ioSizeF.Height);
                        xPos += (int)ioSizeF.Width + SPACE;
                    }

                }

            }

            if (FCountVariable == 0 && FError == Error.NoError)
            {
                FFontCurrent = new Font("Segoe UI Symbol", FFontSize * 1.3f);
                io = res ? "=1" : "=0";
                if (xPos > temp.Left)
                {
                    temp.X = xPos;
                }
                if (temp.Left < temp.Right)
                {
                    int ioHeight = (int)FField.MeasureString(io, FFontCurrent).Height;
                    FField.DrawString(io, FFontCurrent, Brushes.Black, xPos, yPos - (ioHeight - h + 3) / 2.0f);
                }

            }


            for (i = openBrackets - 1; i >= 0; i--)
            {
                if (brackets[i].Type == ArgumentType.NBracketLeft)
                {
                    closeBrackets[numBrackets].Start = brackets[i].Start;
                    closeBrackets[numBrackets].End = xPos;
                    numBrackets++;
                }
            }

            closeBrackets[0].Level = 0;
            int maxLevel = 0;
            for (i = 1; i < numBrackets; i++)
            {
                for (j = i - 1; j >= 0; j--)
                {
                    if (closeBrackets[i].Start < closeBrackets[j].End && maxLevel <= closeBrackets[j].Level)
                    {
                        maxLevel = closeBrackets[j].Level + 1;
                    }
                }
                closeBrackets[i].Level = maxLevel;
                maxLevel = 0;
            }

            for (i = 0; i < numBrackets; i++)
            {
                y = yPos - closeBrackets[i].Level * 2 - 2;
                if (y >= FFieldRect.Top && y < FFieldRect.Bottom && closeBrackets[i].Start + w < FFieldRect.Right && closeBrackets[i].End >= FFieldRect.Left)
                {
                    Pen nBrush;
                    if (closeBrackets[i].End == xPos || FLength >= LIMIT)
                    {
                        nBrush = new Pen(Color.Red);
                    }
                    else
                    {
                        nBrush = new Pen(Color.Navy);
                    }
                    x = closeBrackets[i].Start + w < FFieldRect.Left ? FFieldRect.Left : closeBrackets[i].Start + w;
                    int oldX = x;
                    x = closeBrackets[i].End > FFieldRect.Right ? FFieldRect.Right : closeBrackets[i].End;

                    FField.DrawLine(nBrush, oldX, y, x, y);
                    nBrush.Dispose();
                }
            }
            pen.Dispose();
            FRepaint = false;
            return true;
        }


        public bool Update(bool cursorVisible) 
        {

            if (FField == null || FRepaint)
            {
                return false;
            }

            Font font = new Font("Segoe UI Symbol", FFontSize);

            int x = GetWidth(2, 0) + FFieldOffset + FFieldRect.Left - SPACE;
            int y;
            int yPos = (FFieldRect.Top + FFieldRect.Bottom) / 2;
            int h = (int)FField.MeasureString("𝑋", font).Height;
            //𝑥
            if (!cursorVisible || FPositionOld != -1 && FFieldCursor)
            { //𝑋
                Pen pen;
                if (cursorVisible && FPositionOld == FPositionError && FError != Error.NoError)
                {
                    pen = new Pen(Color.Red);
                }
                else
                {
                    pen = new Pen(FFieldColor);
                }
                y = yPos < FFieldRect.Top ? FFieldRect.Top : yPos;

                int oldY = y;
                y = yPos + h > FFieldRect.Bottom ? FFieldRect.Bottom : yPos + h;

                FField.DrawLine(pen, x, oldY, x, y);
            }
            if (cursorVisible)
            {
                x = GetWidth(1, 0) + FFieldOffset + FFieldRect.Left - SPACE;
                if (FFieldCursor && x >= FFieldRect.Left && x < FFieldRect.Right)
                {
                    FPositionOld = FPosition;
                    Pen pen = new Pen(Color.Black);
                    y = yPos < FFieldRect.Top ? FFieldRect.Top : yPos;
                    int oldY = y;
                    y = yPos + h > FFieldRect.Bottom ? FFieldRect.Bottom : yPos + h;
                    FField.DrawLine(pen, x, oldY, x, y);

                }
                else
                {
                    FPositionOld = -1;
                }
            }
            font.Dispose();
            return true;
        }
    }
}
