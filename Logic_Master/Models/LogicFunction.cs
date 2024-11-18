using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Logic_Master.Models
{
    class LogicFunction
    {
        public string Title { get; set; } = "LogicFunction"; 



        public const int LIMIT = 10240;
        public const int SPACE = 1;
        public const int FRAME = 10;

        public int[] FFunction { get; set; } = new int[LIMIT];
        public int FPosition;
        public int FPositionOld;
        public int FLength { get; set; }
        public string FSigns;

        public int FPositionError;
        public Error FError;
        public int FData;
        public int FBrackets;
        public int FCountVariable; //FCount

        public bool FRepaint;
        public Graphics FField;
        public Bitmap Fbitmap;
        public Color FFieldColor;
        public Rectangle FFieldRect;
        public int FFieldOffset;
        public bool FFieldCursor;
        public int FFontSize;

        //LogicFunctionWork File

        public LogicFunction()
        {
            FRepaint = true;
            FPosition = 0;
            FPositionOld = 1;
            FLength = 0;
            FSigns = " &+⊕/↓≡→←><";
            FPositionError = 0;
            FError = Error.Empty;
            FCountVariable = 0;
            FFieldOffset = FRAME;
            FFontSize = 11;
        }


        public bool AddArgument(ArgumentType type, int number)
        {
            if (FLength >= LIMIT)
            {
                return false;
            }
            if (type < ArgumentType.Operation || type > ArgumentType.FixedValue)
            {
                return false;
            }
            if (type == ArgumentType.Operation && (number < 1 || number > 10))
            {
                return false;
            }
            if ((type == ArgumentType.Variable || type == ArgumentType.NVariable) && (number < 1 || number > 9))
            {
                return false;
            }
            if (type == ArgumentType.FixedValue && (number < 0 || number > 1))
            {
                return false;
            }

            int argument = ((int)type << 8) | number;

            for (int i = FLength; i > FPosition; i--)
            {
                FFunction[i] = FFunction[i - 1];
            }
            FFunction[FPosition] = argument;
            FLength++;
            FPosition++;
            FRepaint = true;
            return true;

        }

        public bool AddArgument(ArgumentType type)
        {
            if (type < ArgumentType.BracketLeft || type > ArgumentType.BracketRight)
            {
                return false;
            }
            if (FLength >= LIMIT)
            {
                return false;
            }

            int argument = (int)type << 8;
            for (int i = FLength; i > FPosition; i--)
            {
                FFunction[i] = FFunction[i - 1];
            }
            FFunction[FPosition] = argument;
            FLength++;
            FPosition++;
            FRepaint = true;
            return true;
        }

        public bool DelArgumentLeft()
        {
            if (FPosition == 0)
            {
                return false;
            }

            for (int i = FPosition; i <= FLength; i++)
            {
                FFunction[i - 1] = FFunction[i];
            }
            FLength--;
            FPosition--;
            FRepaint = true;
            return true;
        }

        public bool DelArgumentRight()
        {
            if (FPosition == FLength)
            {
                return false;
            }

            for (int i = FPosition + 1; i <= FLength; i++)
            {
                FFunction[i - 1] = FFunction[i];
            }
            FLength--;
            FRepaint = true;
            return true;
        }

        public bool Negative()
        {
            bool right = true;
            bool cycle = true;
            int type = FFunction[FPosition] >> 8;
            int number = FFunction[FPosition + 1] & 0xFF;
            if (FPosition == FLength)
            {
                type = 0;
            }
            ArgumentType argumentType = (ArgumentType)type;
            while (true)
            {
                cycle = false;
                switch (argumentType)
                {
                    case ArgumentType.Variable:
                        argumentType = ArgumentType.NVariable;
                        break;
                    case ArgumentType.NVariable:
                        argumentType = ArgumentType.Variable;
                        break;
                    case ArgumentType.FixedValue:
                        number = number == 0 ? 1 : 0;
                        break;
                    case ArgumentType.BracketLeft:
                        argumentType = ArgumentType.NBracketLeft;
                        break;
                    case ArgumentType.NBracketLeft:
                        argumentType = ArgumentType.BracketLeft;
                        break;
                    default:
                        if (!right)
                        {
                            return false;
                        }
                        if (FPosition != 0)
                        {
                            type = FFunction[FPosition - 1] >> 8;
                            argumentType = (ArgumentType)type;
                            number = FFunction[FPosition - 1] & 0xFF;
                            right = false;
                            cycle = true;
                        }
                        break;
                }
                if (!cycle)
                {
                    break;
                }
            }
            type = (int)argumentType;
            if (right)
            {
                FFunction[FPosition] = (type << 8) | number;
            }
            else
            {
                FFunction[FPosition - 1] = (type << 8) | number;
            }
            FRepaint = true;
            return true;
        }






        public void SetPosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.Begin:
                    FPosition = 0;
                    break;
                case Direction.End:
                    FPosition = FLength;
                    break;
                case Direction.Left:
                    if (FPosition != 0)
                    {
                        FPosition--;
                    }
                    break;
                case Direction.Right:
                    if (FPosition != FLength)
                    {
                        FPosition++;
                    }
                    break;
            }
        }



        public void Clear()
        {
            FPosition = 0;
            FPositionOld = -1;
            FLength = 0;
            FPositionError = 0;
            FFunction = new int[LIMIT];
            FError = Error.Empty;
            FCountVariable = 0;
            FFieldOffset = FRAME;
            FRepaint = true;
        }

        public void GetInformation(ref int countOperations, ref int countNegatives)
        {
            ArgumentType type = new ArgumentType();

            countOperations = 0;
            countNegatives = 0;
            int argument = 0;

            for (int i = 0; i < FLength; i++)
            {
                argument = FFunction[i] >> 8;
                type = (ArgumentType)argument;
                switch (type)
                {
                    case ArgumentType.Operation:
                        countOperations++;
                        break;
                    case ArgumentType.NVariable:
                    case ArgumentType.NBracketLeft:
                        countNegatives++;
                        break;
                }
            }
        }
        private int GetLength()
        {
            return FLength;
        }


        public bool SaveFunctionJSON(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(this, options: new JsonSerializerOptions { WriteIndented = true});
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения в JSON: {ex.Message}");
                return false;
            }
        }

        public bool LoadFunctionJSON(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Ошибка загрузки JSON: Файла не существует!");
                    return false;
                }
                else
                {
                    string json = File.ReadAllText(filePath);
                    LogicFunction? logicFunction = JsonSerializer.Deserialize<LogicFunction>(json);
                    if (logicFunction == null || logicFunction.Title != "LogicFunction")
                    {
                        MessageBox.Show($"Ошибка загрузки JSON: Неверный формат файла");
                        return false;
                    }
                    if (logicFunction.FLength > 1024)
                    {
                        MessageBox.Show("Ошибка загрузки файла JSON: Длина функции превысила допустимое значение");
                        return false;
                    }
                    Clear();
                    FLength = logicFunction.FLength;
                    FFunction = logicFunction.FFunction;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла JSON: {ex.Message}");
                return false;
            }
        }









        //LogicFunctionOutPut File

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

            // Вычисление ширины 'ƒ='
            Font fontF = new Font("Segoe UI Symbol", FFontSize);
            Font font = new Font("Segoe UI Symbol", FFontSize * 1.3f);

            w = (int)FField.MeasureString("ƒ=", font).Width + SPACE * 2;


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
                        io = "𝑥";
                        break;
                    case ArgumentType.NVariable:
                        io = "𝑥";
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
                w += (int)FField.MeasureString(io, fontF).Width + SPACE;

                // Вывод индекса у переменных
                if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable)
                {
                    w -= SPACE;
                    io = num.ToString();
                    Font smollFont = new Font(font.FontFamily, FFontSize * 7.0f / 11.0f);
                    w += (int)FField.MeasureString(io, smollFont).Width + SPACE;
                    smollFont.Dispose();
                }
            }
            if (mode == 3)
            {
                return p;
            }
            font.Dispose();

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
            Font font = new Font("Segoe UI Symbol", FFontSize * 1.3f);

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
                    f = (int)FField.MeasureString("ƒ=", font).Width + SPACE * 2;
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
            font.Dispose();
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

        public void SetFontSize(Rectangle rect)
        {
            FFieldRect = rect;
            FRepaint = true;
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
            Font font = new Font("Segoe UI Symbol", FFontSize);
            Brush brush = new SolidBrush(FFieldColor);


            bool res;
            int i, j;
            int h = (int)FField.MeasureString("𝑥", font).Height;
            int w = (int)FField.MeasureString("(", font).Width;
            int x, y;
            int type, num;
            int xPos = FFieldRect.Left + FFieldOffset;
            int yPos = (FFieldRect.Top + FFieldRect.Bottom) / 2;
            int numBrackets = 0;
            int openBrackets = 0;
            string io;

            Bracket[] brackets = new Bracket[LIMIT];
            CloseBracket[] closeBrackets = new CloseBracket[LIMIT];
            
            Rectangle temp = FFieldRect;
            Font fontF = new Font(font.FontFamily, FFontSize * 1.3f);
            SizeF textSize = FField.MeasureString("ƒ=", fontF); 

            FField.DrawString("ƒ=", fontF, Brushes.Black, xPos, yPos - (textSize.Height - h) / 2.0f);
            xPos += (int)textSize.Width + SPACE * 2;
            res = Solve(true);

            for (i = 0; i <= FLength; i++)
            {
                if (FPositionError == i && FError != Error.NoError && FFieldCursor)
                {
                    Pen errorPen = new Pen(Color.Red);
                    x = xPos - SPACE;
                    if (x > FFieldRect.Left && x < FFieldRect.Right)
                    {
                        y = yPos < FFieldRect.Top ? FFieldRect.Top : yPos;
                        //FField.TranslateTransform(x, y);
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
                        io = "𝑥";
                        break;
                    case ArgumentType.NVariable:
                        color = Brushes.Navy;
                        io = "𝑥";
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

                if (temp.Left < temp.Right)
                {
                    FField.DrawString(io, font, color, xPos, yPos);
                }


                int ioSize = (int)FField.MeasureString(io, font).Width;


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
                }
                xPos += ioSize + SPACE;

                if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable)
                {
                    xPos -= SPACE;
                    io = num.ToString();
                    Font smallFont = new Font(font.FontFamily, FFontSize * 7 / 11.0f);

                    if (xPos > temp.Left)
                    {
                        temp.X = xPos;
                    }

                    if (temp.Left < temp.Right)
                    {
                        SizeF ioSizeF = FField.MeasureString(io, smallFont);
                        FField.DrawString(io, smallFont, color, xPos, yPos + h - ioSizeF.Height);
                        xPos += (int)ioSizeF.Width + SPACE;
                    }

                }

            }

            if (FCountVariable == 0 && FError == Error.NoError)
            {
                io = res ? "1" : "0";
                if (xPos > temp.Left)
                {
                    temp.X = xPos;
                }
                if (temp.Left < temp.Right)
                {
                    int ioHeight = (int)FField.MeasureString(io, fontF).Height;
                    FField.DrawString(io, fontF, Brushes.Black, xPos, yPos - (ioHeight - h) / 2.0f);
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
                }
            }

            FRepaint = false;
            return true;
        }


        public bool Update(bool cursorVisible) //обновляет положение курсора
        {
            Font font = new Font("Segoe UI Symbol", FFontSize);
            

            if (FField == null || FRepaint)
            {
                return false;
            }

            int x = GetWidth(2, 0) + FFieldOffset + FFieldRect.Left - SPACE;
            int y;
            int yPos = (FFieldRect.Top + FFieldRect.Bottom) / 2;
            int h = (int)FField.MeasureString("𝑥", font).Height;

            if (!cursorVisible || FPositionOld != -1 && FFieldCursor) 
            {
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

            return true;
        }





        //LogicFunction Solve файл

        public Error GetError()
        {
            return FError;
        }



        public bool Solve(bool clr)
        {
            if (FLength == 0)
            {
                FError = Error.Empty;
                return false;   
            }

            FPositionError = 0;
            FBrackets = 0;
            FError = Error.NoError;
            if (clr)
            {
                FCountVariable = 0;
            }
            bool result = SolveBlock();
            if (FError == Error.NoError && FBrackets > 0)
            {
                FError = Error.AbsentBracketRight;
            }
            return result;
        }


        public bool SolveBlock()
        {
            bool result = GetValue();
            while (FPositionError < FLength && FError == Error.NoError)
            {
                result = GetOperation(result);
            }
            if (FError == Error.End)
            {
                FError = Error.NoError;
            }
            return result;
        }

        private bool GetOperation(bool a)
        {
            int type = FFunction[FPositionError] >> 8;
            int number = FFunction[FPositionError] & 0xFF;
            ArgumentType argumentType = (ArgumentType)type;

            if (argumentType != ArgumentType.Operation && argumentType != ArgumentType.BracketRight) 
            {
                FError = Error.AbsentOperation;
                return false;   
            }
            bool b;
            bool result = false;
            switch (argumentType)
            {
                case ArgumentType.Operation:
                    if (number < 1 || number > 10)
                    {
                        FError = Error.UnknownArgument;
                        break;
                    }
                    FPositionError++;
                    b = GetValue();
                    switch (number)
                    {
                        case 1:
                            result = a && b;
                            break;
                        case 2:
                            result = a || b;
                            break;
                        case 3:
                            result = (!a && b) || (a && !b);
                            break;
                        case 4:
                            result = !a || b;
                            break;
                        case 5:
                            result = a && !b;
                            break;
                        case 6:
                            result = !(a && b);
                            break;
                        case 7:
                            result = !(a || b);
                            break;
                        case 8:
                            result = (!a && !b) || (a && b);
                            break;
                        case 9:
                            result = a || !b;
                            break;
                        case 10:
                            result = !a && b;
                            break;
                    }
                    break;
                case ArgumentType.BracketRight:
                    if (FBrackets == 0)
                    {
                        FError = Error.AbsentBracketLeft;
                        break;
                    }
                    FBrackets--;
                    FError = Error.End;
                    FPositionError++;
                    result = a;
                    break;
            }
            return result;
        }

        private bool GetValue()
        {
            if (FPositionError == FLength)
            {
                FError = Error.AbsentValue;
                return false;
            }
            int type = FFunction[FPositionError] >> 8;
            int number = FFunction[FPositionError] & 0xFF;
            ArgumentType argumentType = (ArgumentType)type;
            if (argumentType == ArgumentType.Operation || argumentType == ArgumentType.BracketRight)
            {
                FError = Error.AbsentValue;
                return false;
            }
            bool result = false;
            int rr;

            switch (argumentType)
            {
                case ArgumentType.Variable:
                    if (number < 1 || number > 9)
                    {
                        FError = Error.UnknownArgument;
                        break;
                    }
                    if (FCountVariable < number)
                    {
                        FCountVariable = number;
                    }
                    rr = FData & (1 << (FCountVariable - number));
                    result = rr == 0 ? false : true;
                    FPositionError++;
                    break;
                case ArgumentType.NVariable:
                    if (number < 1 || number > 9)
                    {
                        FError = Error.UnknownArgument;
                        break;
                    }
                    if (FCountVariable < number)
                    {
                        FCountVariable = number;
                    }
                    result = (FData & (1 << (FCountVariable - number))) == 0 ? true : false;
                    FPositionError++;
                    break;
                case ArgumentType.FixedValue:
                    if (number < 1 || number > 1)
                    {
                        FError = Error.UnknownArgument;
                        break;
                    }
                    result = number == 0 ? false : true;
                    FPositionError++;
                    break;
                case ArgumentType.BracketLeft:
                    FBrackets++;
                    FPositionError++;
                    result = SolveBlock();
                    break;
                case ArgumentType.NBracketLeft:
                    FBrackets++;
                    FPositionError++;
                    result = !SolveBlock();
                    break;
                default:
                    FError = Error.UnknownArgument;
                    break;
                    
            }
            return result;
        }




        /*//Установить курсор в конец блока и вернуть информацию о блоке (File LogicFunctionSolve, str = 253)
        public int GetBlockRight()
        {
            int brackets = 0;
            int block;
            int type = FFunction[FPosition] >> 8;

            ArgumentType argumentType = (ArgumentType)type;

            if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable || argumentType == ArgumentType.FixedValue)
            {
                FPosition++;
                return (int)Block.Normal;
            }
            if (argumentType == ArgumentType.BracketLeft)
            {
                block = (int)Block.Brackets;
            }
            else if (argumentType == ArgumentType.NBracketLeft)
            {
                block = (int)Block.NBrackets;
            }
            else
            {
                return -1;
            }
            for (FPosition < FLength; FPosition++)
            {
                type = FFunction[FPosition] >> 8;
                if (argumentType == ArgumentType.BracketLeft || argumentType == ArgumentType.NBracketLeft)
                {
                    brackets++;
                }
                if (argumentType == ArgumentType.BracketRight)
                {
                    brackets--;
                }
                if (brackets == 0)
                {
                    FPosition++;
                }
            }
            return block;
        }

        //Установить курсор в начало блока и вернуть информацию о блоке
        public int GetBlockLeft()
        {
            int brackets = 0;
            int block;
            bool bl = true;
            int type;
            FPosition--;
            type = FFunction[FPosition] >> 8;
            ArgumentType argumentType = (ArgumentType)type;

            if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable || argumentType == ArgumentType.FixedValue)
            {
                block = (int)Block.Normal;
            }
            else if (argumentType != ArgumentType.BracketRight)
            {
                return -1;
            }

            for (FPosition = FPosition; FPosition >=0; FPosition--)
            {
                type = FFunction[FPosition] >> 8;
                if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable || argumentType == ArgumentType.FixedValue)
                {
                    bl = false;
                    if (FPosition == 0)
                    {
                        block = (int)Block.Normal;
                    }
                    FPosition--;
                    type = FFunction[FPosition] >> 8;
                    if (argumentType != ArgumentType.Operation)
                    {
                        FPosition++;
                        block = (int)Block.Normal;
                    }
                }
                else
                {
                    brackets++;

                    while (brackets !=0 && FPosition != 0)
                    {
                        FPosition--;
                        type = FFunction[FPosition] >> 8;
                        if (argumentType == ArgumentType.BracketLeft || argumentType == ArgumentType.NBracketLeft)
                        {
                            brackets--;
                        }
                        if (argumentType == ArgumentType.BracketRight || argumentType == ArgumentType.NBracketLeft)
                        {
                            type = FFunction[FPosition] >> 8;
                            if (!bl)
                            {
                                block = (int)Block.Normal;
                            }
                            if (bl && argumentType == ArgumentType.BracketLeft)
                            {
                                block = (int)Block.Brackets;
                            }
                            if (bl && argumentType == ArgumentType.NBracketLeft)
                            {
                                block = (int)Block.NBrackets;
                            }
                        }
                    }
                    FPosition--;
                    bl = false;
                }
            }
            return block;
        }



        //  заменить операцию базисом (File LogicFunctionSolve)
        public void ChangeOperation(string change)
        {
            int[] nf = new int[LIMIT];
            int k = 0;
            int nl = 0;
            int i = 1;
            int type = 0; //возможно не так, в их коде не присваивается
            int num, pos, w;
            int[] com = new int[20];
            bool neg;
            string str;
            ArgumentType argumentType = (ArgumentType)type;


            //перевод строки в массив:
            while (i <= change.Length)
            {
                neg = false;
                str = change.Substring(i,1);
                if (str == "!")
                {
                    neg = true;
                    i++;
                    str = change.Substring(i, 1);
                }
                if (!neg)
                {
                    if (str == "(")
                    {
                        com[k] = (int)ArgumentType.BracketLeft << 8;
                    }
                    else if (str == ")")
                    {
                        com[k] = (int)ArgumentType.BracketRight << 8;
                    }
                    else if (str == "x")
                    {
                        com[k] = ((int)ArgumentType.Variable << 8) + 1;
                    }
                    else if (str == "y")
                    {
                        com[k] = ((int)ArgumentType.Variable << 8) + 2;
                    }
                    else if (str == "*")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 1;
                    }
                    else if (str == "+")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 2;
                    }
                    else if (str == "#")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 3;
                    }
                    else if(str == "}")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 4;
                    }
                    else if (str == ">")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 5;
                    }
                    else if (str == "0")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 0;
                    }
                    else if (str == "1")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 1;
                    }
                }
                else
                {
                    if (str == "(")
                    {
                        com[k] = (int)ArgumentType.NBracketLeft << 8;
                    }
                    else if (str == "x")
                    {
                        com[k] = ((int)ArgumentType.NVariable << 8) + 1;
                    }
                    else if (str == "y")
                    {
                        com[k] = ((int)ArgumentType.NVariable << 8) + 2;
                    }
                    else if (str == "*")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 6;
                    }
                    else if (str == "+")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 7;
                    }
                    else if (str == "#")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 8;
                    }
                    else if (str == "}")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 9;
                    }
                    else if (str == ">")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 10;
                    }
                    else if (str == "0")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 1;
                    }
                    else if (str == "1")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 0;
                    }
                }
                i++; k++;
            }
            com[k] = 0;
            k = 0;



            //создание нового блока:
            while (com[k] != 0)
            {
                type = com[k] >> 8;
                num = com[k] & 0xFF;

                switch (argumentType)
                {
                    case ArgumentType.Operation:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.Variable:
                        if (num == 1)
                        {
                            pos = FPosition;
                            GetBlockLeft(); 
                            for (i = FPosition; i < pos; i++)
                            {
                                nf[nl] = FFunction[i];
                                if (nl < LIMIT)
                                {
                                    nl++;
                                }
                            }
                            FPosition = pos;
                        }
                        else
                        {
                            pos = FPosition;
                            FPosition++;
                            GetBlockRight();
                            for (i = pos + 1; i < FPosition; i++)
                            {
                                nf[nl] = FFunction[i];
                                if (nl < LIMIT)
                                {
                                    nl++;
                                }
                            }
                            FPosition = pos;
                        }
                        break;
                    case ArgumentType.NVariable:
                        if (num == 1)
                        {
                            nf[nl] = (int)ArgumentType.NBracketLeft << 8;
                            nl++;
                            pos = FPosition;
                            GetBlockLeft();
                            for (i = FPosition; i < pos; i++)
                            {
                                nf[nl] = FFunction[i] << 8;
                                if (nl < LIMIT)
                                {
                                    nl++;
                                }
                            }
                            nf[nl] = (int)ArgumentType.BracketRight << 8;
                            if (nl < LIMIT)
                            {
                                nl++;
                            }
                            FPosition = pos;
                        }
                        else
                        {
                            pos = FPosition;
                            FPosition++;
                            Negative();
                            GetBlockRight();
                            for (i = pos+1;i<FPosition; i++)
                            {
                                nf[nl] = FFunction[i];
                                if (nl < LIMIT)
                                {
                                    nl++;
                                }
                            }

                            FPosition = pos + 1;
                            Negative();
                            FPosition = pos;
                        }
                        break;
                    case ArgumentType.FixedValue:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.BracketLeft:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.NBracketLeft:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.BracketRight:
                        nf[nl] = com[k];
                        nl++;
                        break;
                }

                if (nl >= LIMIT)
                {
                    nl = LIMIT;
                }
                k++;
            }



            //удаление старых блоков:
            pos = FPosition;
            GetBlockLeft();
            w = FPosition;
            FPosition = pos + 1;
            GetBlockRight();
            w = FPosition - w;
            if (nl < w)
            {
                for (i = FPosition; i <FLength; i++)
                {
                    FFunction[i-w+nl] = FFunction[i];
                }
                FLength -= w - nl;
            }
            if (nl > w)
            {
                for (i = FLength - 1; i >= FPosition; i--)
                {
                    if (i + nl - w < LIMIT)
                    {
                        FFunction[i+nl-w] = FFunction[i];
                    }
                    FLength += nl - w;
                    if (FLength > LIMIT)
                    {
                        FLength = LIMIT;
                    }
                }
            }
            FPosition -= w;

            for (i = 0; i < nl; i++)
            {
                if (FPosition + i < LIMIT)
                {
                    FFunction[FPosition + 1] = nf[i];
                }
            }
        }


        //Заменить значение базисом:
        public void ChangeValue(string change, bool fixedValue)
        {
            int[] nf = new int[LIMIT];
            int k = 0;
            int nl = 0;
            int i = 1;
            int type = 0;
            int pos, w;
            int[] com = new int[20];
            bool neg;
            string str;


            //перевод из строки в массив
            while (i <= change.Length)
            {
                neg = false;
                str = change.Substring(i, 1);
                if (str == "!")
                {
                    neg = true;
                    i++;
                    str = change.Substring(i, 1);
                }
                if (!neg)
                {
                    if (str == "(")
                    {
                        com[k] = (int)ArgumentType.BracketLeft << 8;
                    }
                    else if (str == ")")
                    {
                        com[k] = (int)ArgumentType.BracketRight << 8;
                    }
                    else if (str == "x")
                    {
                        com[k] = ((int)ArgumentType.Variable << 8) + 1;
                    }
                    else if (str == "y")
                    {
                        com[k] = ((int)ArgumentType.Variable << 8) + 2;
                    }
                    else if (str == "*")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 1;
                    }
                    else if (str == "+")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 2;
                    }
                    else if (str == "#")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 3;
                    }
                    else if (str == "}")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 4;
                    }
                    else if (str == ">")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 5;
                    }
                    else if (str == "0")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 0;
                    }
                    else if (str == "1")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 1;
                    }
                }
                else
                {
                    if (str == "(")
                    {
                        com[k] = (int)ArgumentType.NBracketLeft << 8;
                    }
                    else if (str == "x")
                    {
                        com[k] = ((int)ArgumentType.NVariable << 8) + 1;
                    }
                    else if (str == "y")
                    {
                        com[k] = ((int)ArgumentType.NVariable << 8) + 2;
                    }
                    else if (str == "*")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 6;
                    }
                    else if (str == "+")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 7;
                    }
                    else if (str == "#")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 8;
                    }
                    else if (str == "}")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 9;
                    }
                    else if (str == ">")
                    {
                        com[k] = ((int)ArgumentType.Operation << 8) + 10;
                    }
                    else if (str == "0")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 1;
                    }
                    else if (str == "1")
                    {
                        com[k] = ((int)ArgumentType.FixedValue << 8) + 0;
                    }
                }
                i++; k++;
            }
            com[k] = 0;
            k = 0;

            ArgumentType argumentType = (ArgumentType)type;

            while (com[k] != 0)
            {
                type = com[k] >> 8;
                switch (argumentType)
                {
                    case ArgumentType.Operation:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.Variable:
                        if (fixedValue)
                        {
                            nf[nl] = ((int)ArgumentType.Variable << 8) + 1;
                            nl++;
                        }
                        else
                        {
                            pos = FPosition;
                            GetBlockRight();
                            for (i = pos; i < FPosition; i++)
                            {
                                nf[nl] = FFunction[i];
                                if (nl < LIMIT)
                                {
                                    nl++;
                                }
                            }
                            FPosition = pos;
                        }
                        break;
                    case ArgumentType.NVariable:
                        if (fixedValue)
                        {
                            nf[nl] = ((int)ArgumentType.NVariable << 8) + 1;
                            nl++;
                        }
                        else
                        {
                            pos = FPosition;
                            Negative();
                            GetBlockRight();
                            for (i = pos; i < FPosition; i++)
                            {
                                nf[nl] = FFunction[i];
                                if (nl < LIMIT)
                                {
                                    nl++;
                                }
                                FPosition = pos;
                                Negative();
                            }
                        }
                        break;
                    case ArgumentType.FixedValue:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.BracketLeft:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.NBracketLeft:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.BracketRight:
                        nf[nl] = com[k];
                        nl++;
                        break;
                }
                if (nl >= LIMIT)
                {
                    nl = LIMIT;
                }
                k++;

            }



            //Создание нового блока:
            while (com[k] != 0)
            {
                type = com[k] >> 8;
                switch (argumentType)
                {
                    case ArgumentType.Operation:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.Variable:
                        if (fixedValue)
                        { 
                            nf[nl] = ((int)ArgumentType.Variable << 8) + 1;
                            nl++;
                        }
                        else
                        {
                            pos = FPosition;
                            GetBlockRight();
                            for (i = pos; i < FPosition; i++)
                            {
                                nf[nl] = FFunction[i]; 
                                if (nl < LIMIT)
                                {
                                    nl++;
                                }
                            }
                            FPosition = pos;
                        }
                        break;
                    case ArgumentType.NVariable:
                        if (fixedValue)
                        {
                            nf[nl] = ((int)ArgumentType.NVariable << 8) + 1;
                            nl++;
                        }
                        else
                        {
                            pos = FPosition;
                            Negative();
                            GetBlockRight();
                            for (i = pos; i < FPosition; i++)
                            {
                                nf[nl] = FFunction[i];
                                if (nl< LIMIT)
                                {
                                    nl++;
                                }
                            }
                            FPosition = pos;
                            Negative();
                        }
                        break;

                    case ArgumentType.FixedValue:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.BracketLeft:
                        nf[nl] = com[k];
                        nl++;
                        break;
                    case ArgumentType.NBracketLeft:
                        nf[nl] = com[k];
                        nl++;
                        break;
                        case ArgumentType.BracketRight:
                        nf[nl] = com[k];
                        nl++;
                        break;
                }
                if (nl >= LIMIT)
                {
                    nl = LIMIT;
                }
                k++;
            }

            //Удаление старых блоков:
            pos = FPosition;
            GetBlockRight();
            w = FPosition - pos;
            if (nl < w)
            {
                for (i = FPosition; i < FLength; i++)
                {
                    FFunction[i - w + nl] = FFunction[i];
                }
                FLength -= w - nl;
            }
            if (nl > w)
            {
                for(i = FLength - 1; i >= FPosition; i--)
                {
                    if (i + nl - w < LIMIT)
                    {
                        FFunction[i + nl - w] = FFunction[i];
                    }
                    FLength += nl - w;
                    if (FLength > LIMIT)
                    {
                        FLength = LIMIT;
                    }
                }
            }
            FPosition -= w;
            for (i = 0; i < nl; i++)
            {
                if (FPosition + i < LIMIT)
                {
                    FFunction[FPosition + 1] = nf[i];
                }
            }
        }




        //Представить функцию в базисе
        public bool Bazis(int bs) //bs - номер базиса в BoxBasis (в нашем случае BazisComboBox)
        {
            bool ret = true;
            int type = 0; //в их коде ничего не присваивали (строка 579)
            int num;
            string change;
            FPosition = 0;

            ArgumentType argumentType = (ArgumentType)type;

            while (FPosition < FLength)
            {
                type = FFunction[FPosition] >> 8;
                num = FFunction[FPosition] & 0xFF;
                if (argumentType == ArgumentType.NBracketLeft)
                {
                    argumentType = ArgumentType.NVariable;
                }
                change = "";
                switch (bs)
                {
                    case 1:
                        if (argumentType == ArgumentType.Operation && num == 2)
                        {
                            change = "!(!x*!y)";
                        }
                        break;
                    case 2:
                        if (bs == 2 && argumentType == ArgumentType.Operation && num == 1)
                        {
                            change = "!(!x+!y)";
                        }
                        break;
                    case 0:
                        switch (argumentType)
                        {
                            case ArgumentType.Operation:
                                switch (num)
                                {
                                    case 1: break;
                                    case 2: break;
                                    case 3:
                                        change = "((!x*y)+(x*!y))";
                                        break;
                                    case 4:
                                        change = "(!x+y)";
                                        break;
                                    case 5:
                                        change = "(x*!y)";
                                        break;
                                    case 6:
                                        change = "!(x*y)";
                                        break;
                                    case 7:
                                        change = "!(x+y)";
                                        break;
                                    case 8:
                                        change = "((!x*!y)+(x*y))";
                                        break;
                                    case 9:
                                        change = "(x+!y)";
                                        break;
                                    case 10:
                                        change = "(!x*y)";
                                        break;

                                }
                                break;
                            case ArgumentType.FixedValue:
                                switch (num)
                                {
                                    case 0:
                                        change = "(x*!x)";
                                        break;
                                    case 1:
                                        change = "(x+!x)";
                                        break;
                                }
                                break;
                        }
                        break;
                    case 4:
                        if (argumentType == ArgumentType.NVariable)
                        {
                            change = "(!x!*!x)";
                        }
                        break;

                    case 3:
                        switch (argumentType)
                        {
                            case ArgumentType.Operation:
                                switch (num)
                                {
                                    case 1:
                                        change = "!(x!*y)";
                                        break;
                                    case 2:
                                        change = "(!x!*!y)";
                                        break;
                                    case 3:
                                        change = "((!x!*y)!*(x!*!y))";
                                        break;
                                    case 4:
                                        change = "(x!*!y)";
                                        break;
                                    case 5:
                                        change = "!(x!*!y)";
                                        break;
                                    case 6: break;
                                    case 7:
                                        change = "!(!x!*!y)";
                                        break;
                                    case 8:
                                        change = "((!x!*!y)!*(x!*y))";
                                        break;
                                    case 9:
                                        change = "(!x!*y)";
                                        break;
                                    case 10:
                                        change = "!(!x!*y)";
                                        break;
                                }
                                break;
                            case ArgumentType.FixedValue:
                                switch (num)
                                {
                                    case 0:
                                        change = "(x!+!x)";
                                        break;
                                    case 1:
                                        change = "(x!*!x)";
                                        break;
                                }
                        }
                        break;
                    case 6:
                        if (argumentType == ArgumentType.NVariable)
                        {
                            change = "(!x!+!x)";
                        }
                        break;
                    case 5:
                        switch (argumentType)
                        {
                            case ArgumentType.Operation:
                                switch (num)
                                {
                                    case 1:
                                        change = "(!x!+!y)";
                                        break;
                                    case 2:
                                        change = "!(x!+y)";
                                        break;
                                    case 3:
                                        change = "((!x!+!y)!+(x!+y))";
                                        break;
                                    case 4:
                                        change = "!(!x!+y)";
                                        break;
                                    case 5:
                                        change = "(!x!+y)";
                                        break;
                                    case 6:
                                        change = "!(!x!+!y)";
                                        break;
                                    case 7:
                                        change = "";
                                        break;
                                    case 8:
                                        change = "((!x!+y)!+(x!+!y))";
                                        break;
                                    case 9:
                                        change = "!(x!+!y)";
                                        break;
                                    case 10:
                                        change = "(x!+!y)";
                                        break;
                                }
                                break;
                            case ArgumentType.FixedValue:
                                switch (num)
                                {
                                    case 0:
                                        change = "(x!+!x)";
                                        break;
                                    case 1:
                                        change = "!(x!+!x)";
                                        break;
                                }
                                break;

                        }
                        break;

                    case 7:
                        switch (argumentType)
                        {
                            case ArgumentType.NVariable:
                                change = "(1#!x)";
                                break;
                            case ArgumentType.Operation:
                                switch (num)
                                {
                                    case 1: break;
                                    case 2: break;
                                    case 3: break;
                                    case 4:
                                        change = "(!x+y)";
                                        break;
                                    case 5:
                                        change = "(x*!y)";
                                        break;
                                    case 6:
                                        change = "\"!(x*y)";
                                        break;
                                    case 7:
                                        change = "!(x+y)";
                                        break;
                                    case 8:
                                        change = "!(x#y)";
                                        break;
                                    case 9:
                                        change = "(x+!y)";
                                        break;
                                    case 10:
                                        change = "(!x*y";
                                        break;
                                }
                                break;
                            case ArgumentType.FixedValue:
                                switch (num)
                                {
                                    case 0:
                                        change = "(x#x)";
                                        break;
                                    case 1: break;
                                }
                                break;
                        }
                    break;
                }
                if (change == "")
                {
                    FPosition++;
                    ret = false;
                }
                else
                {
                    switch (argumentType)
                    {
                        case ArgumentType.NVariable:
                            ChangeValue(change, false);
                            break;
                        case ArgumentType.Operation:
                            ChangeOperation(change);
                            break;
                        case ArgumentType.FixedValue:
                            ChangeValue(change, true);
                            break;
                    }
                }
            }
            return ret;
        }





        //Метод оптимизации (File LogicFunctionSolve строка 35)
        public bool Optimization()
        {
            Solve(true);
            if (FError != Error.NoError)
            {
                return false;
            }

            int pos, w;
            int type = 0; //тоже не присваивали они
            int typel;
            FPosition = 0;
            ArgumentType argumentType = (ArgumentType)type;

            while (true)
            {
                type = FFunction[FPosition] >> 8;
                if (FPosition == FLength)
                {
                    break;
                }
                if (argumentType != ArgumentType.BracketLeft && argumentType != ArgumentType.NBracketLeft)
                {
                    FPosition++;
                }
                else
                {
                    //FPosition == 0 ? typel = FFunction[FPosition - 1] >> 8 : 0;
                    if (typel != ArgumentType.Operation)
                    {
                        pos = FPosition;
                        GetBlockRight();
                        if (argumentType == ArgumentType.BracketLeft)
                        {
                            DelArgumentLeft();
                            FPosition = pos;
                            DelArgumentRight();
                        }
                        else
                        {
                            w = FPosition - pos;
                            FPosition = pos + 1;
                            if (w == 3)
                            {
                                Negative();
                                FPosition++;
                                DelArgumentRight();
                                FPosition--;
                                DelArgumentLeft();
                            }
                            else if (GetBlockRight() == (int)Block.NBrackets && FPosition - pos == w - 1)
                            {
                                DelArgumentRight(); DelArgumentLeft();
                                FPosition = pos;
                                DelArgumentRight(); DelArgumentLeft();
                                FPosition = pos;
                            }
                            else
                            {
                                FPosition = pos + 1;
                                if (GetBlockRight() == (int)Block.NBrackets && FPosition - pos == w - 1)
                                {
                                    DelArgumentRight();
                                    FPosition = pos + 1;
                                    DelArgumentRight();
                                    FPosition = pos;
                                }
                                else
                                {
                                    FPosition = pos + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (argumentType == ArgumentType.BracketLeft)
                        {
                            pos = FPosition;
                            GetBlockRight();
                            w = FPosition - pos;
                            FPosition = pos + 1;
                            if (w == 3)
                            {
                                FPosition++; DelArgumentRight();
                                FPosition--; DelArgumentLeft();
                            }
                            else
                            {
                                typel = GetBlockRight();
                                if ((typel == (int)Block.NBrackets || typel == (int)Block.Brackets) && FPosition - pos == w - 1)
                                {
                                    DelArgumentLeft();
                                    FPosition = pos;
                                    DelArgumentRight();
                                }
                                else
                                {
                                    FPosition = pos + 1;
                                }
                            }
                        }
                        else
                        {
                            pos = FPosition;
                            GetBlockRight();
                            w=FPosition - pos;
                            FPosition = pos + 1;
                            if (w == 3)
                            {
                                Negative();
                                FPosition--;
                                Negative();
                            }
                            else if (GetBlockRight()==(int)Block.NBrackets && FPosition - pos == w - 1)
                            {
                                DelArgumentRight(); FPosition = pos;
                                DelArgumentRight(); Negative();
                            }
                            else
                            {
                                FPosition = pos + 1;
                                if (GetBlockRight() == (int)Block.Brackets() && FPosition - pos == w - 1)
                                {
                                    DelArgumentRight(); FPosition = pos + 1;
                                    DelArgumentRight(); FPosition = pos;
                                }
                                else
                                {
                                    FPosition = pos + 1;
                                }
                            }
                        }

                    }

                }
            }
            return true;
        }
*/

    }
}
