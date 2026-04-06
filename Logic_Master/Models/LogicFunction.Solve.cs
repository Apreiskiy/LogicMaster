using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    public partial class LogicFunction
    {
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
                    if (number < 0 || number > 1)
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





        //Установить курсор в конец блока и вернуть информацию о блоке (File LogicFunctionSolve, str = 253)
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

            for (; FPosition < FLength; FPosition++)
            {
                type = FFunction[FPosition] >> 8;
                argumentType = (ArgumentType)type;

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
                    break;
                }
            }
            return block;
        }

        //Установить курсор в начало блока и вернуть информацию о блоке
        public int GetBlockLeft()
        {
            int brackets = 0;
            int block = -1;
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

            for (FPosition = FPosition; FPosition >= 0; FPosition--)
            {
                type = FFunction[FPosition] >> 8;
                argumentType = (ArgumentType)type;

                if (argumentType == ArgumentType.Variable || argumentType == ArgumentType.NVariable || argumentType == ArgumentType.FixedValue)
                {
                    bl = false;
                    if (FPosition == 0)
                    {
                        block = (int)Block.Normal;
                        break;
                    }
                    FPosition--;
                    type = FFunction[FPosition] >> 8;
                    argumentType = (ArgumentType)type;

                    if (argumentType != ArgumentType.Operation)
                    {
                        FPosition++;
                        block = (int)Block.Normal;
                        break;
                    }
                }
                else
                {
                    brackets++;

                    while (brackets != 0 && FPosition != 0)
                    {
                        FPosition--;
                        type = FFunction[FPosition] >> 8;
                        argumentType = (ArgumentType)type;

                        if (argumentType == ArgumentType.BracketLeft || argumentType == ArgumentType.NBracketLeft)
                        {
                            brackets--;
                        }
                        if (argumentType == ArgumentType.BracketRight)
                        {
                            brackets++;
                        }
                    }

                    if (FPosition != 0)
                    {
                        type = FFunction[FPosition - 1] >> 8;
                        argumentType = (ArgumentType)type;

                    }

                    if (FPosition == 0 || argumentType == ArgumentType.BracketLeft || argumentType == ArgumentType.NBracketLeft)
                    {
                        type = FFunction[FPosition] >> 8;
                        argumentType = (ArgumentType)type;

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
                        break;
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
            int i = 0;
            int type = 0; //возможно не так, в их коде не присваивается
            int num, pos, w;
            int[] com = new int[20];
            bool neg;
            string str;
            ArgumentType argumentType = (ArgumentType)type;


            //перевод строки в массив:
            while (i < change.Length)
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
                        com[k] = ((int)ArgumentType.Operation << 8) + 6; //Отличие
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
                argumentType = (ArgumentType)type;
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
                                nf[nl] = FFunction[i];
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
                            for (i = pos + 1; i < FPosition; i++)
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
                for (i = FPosition; i < FLength; i++)
                {
                    FFunction[i - w + nl] = FFunction[i];
                }
                FLength -= w - nl;
            }
            if (nl > w)
            {
                for (i = FLength - 1; i >= FPosition; i--)
                {
                    if (i + nl - w < LIMIT)
                    {
                        FFunction[i + nl - w] = FFunction[i];
                    }
                }

                FLength += nl - w;
                if (FLength > LIMIT)
                {
                    FLength = LIMIT;
                }
            }
            FPosition -= w;

            for (i = 0; i < nl; i++)
            {
                if (FPosition + i < LIMIT)
                {
                    FFunction[FPosition + i] = nf[i];
                }
            }
        }


        //Заменить значение базисом:
        public void ChangeValue(string change, bool fixedValue)
        {
            int[] nf = new int[LIMIT];
            int k = 0;
            int nl = 0;
            int i = 0;
            int type = 0;
            int pos, w;
            int[] com = new int[20];
            bool neg;
            string str;


            //перевод из строки в массив
            while (i < change.Length)
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
                        com[k] = ((int)ArgumentType.Operation << 8) + 6; //Отличие
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
                argumentType = (ArgumentType)type;

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



            //Создание нового блока:
            while (com[k] != 0)
            {
                type = com[k] >> 8;
                argumentType = (ArgumentType)type;

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
                for (i = FLength - 1; i >= FPosition; i--)
                {
                    if (i + nl - w < LIMIT)
                    {
                        FFunction[i + nl - w] = FFunction[i];
                    }
                }

                FLength += nl - w;
                if (FLength > LIMIT)
                {
                    FLength = LIMIT;
                }
            }

            FPosition -= w;
            for (i = 0; i < nl; i++)
            {
                if (FPosition + i < LIMIT)
                {
                    FFunction[FPosition + i] = nf[i]; //была ошибка +1
                }
            }
        }




        //Представить функцию в базисе
        public bool Basis(int bs) //bs - номер базиса в BoxBasis (в нашем случае BazisComboBox)
        {
            bool ret = true;
            int type;
            int num;
            string change;
            FPosition = 0;


            while (FPosition < FLength)
            {
                type = FFunction[FPosition] >> 8;
                ArgumentType argumentType = (ArgumentType)type;
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
                        goto case 2;
                    case 2:
                        if (bs == 2 && argumentType == ArgumentType.Operation && num == 1)
                        {
                            change = "!(!x+!y)";
                        }
                        goto case 0;
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
                        goto case 3;

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
                                break;
                        }
                        break;
                    case 6:
                        if (argumentType == ArgumentType.NVariable)
                        {
                            change = "(!x!+!x)";
                        }
                        goto case 5;

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
                                        change = "!(x*y)";
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
                                        change = "(!x*y)";
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
            int type;
            int typel;
            FPosition = 0;

            while (true)
            {
                type = FFunction[FPosition] >> 8;
                ArgumentType argumentType = (ArgumentType)type;
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
                    typel = FPosition == 0 ? 0 : FFunction[FPosition - 1] >> 8;

                    if (typel != (int)ArgumentType.Operation)
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
                                DelArgumentRight();
                                DelArgumentLeft();
                                FPosition = pos;
                                DelArgumentRight();
                                DelArgumentRight();
                                FPosition = pos;
                            }
                            else
                            {
                                FPosition = pos + 1;
                                if (GetBlockRight() == (int)Block.Brackets && FPosition - pos == w - 1)
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
                                FPosition++;
                                DelArgumentRight();
                                FPosition--;
                                DelArgumentLeft();
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
                            w = FPosition - pos;
                            FPosition = pos + 1;
                            if (w == 3)
                            {
                                Negative();
                                FPosition--;
                                Negative();
                            }
                            else if (GetBlockRight() == (int)Block.NBrackets && FPosition - pos == w - 1)
                            {
                                DelArgumentRight();
                                FPosition = pos;
                                DelArgumentRight();
                                Negative();
                            }
                            else
                            {
                                FPosition = pos + 1;
                                if (GetBlockRight() == (int)Block.Brackets && FPosition - pos == w - 1)
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

                }
            }
            return true;
        }
    }
}
