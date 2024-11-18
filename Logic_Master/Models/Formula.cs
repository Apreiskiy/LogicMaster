using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    public class Formula
    {
        private bool[] x = new bool[12];
        private string formula;
        public int Position { get; private set; }
        public int Error { get; private set; }
        private int brackets; //кол-во не закрытых скобок

        private int GetLevel(Argument argument) //приоритет операции
        {
            return argument.NumOperation switch { 1 or 2 or 3 or 4 or 5 or 6 or 7 or 8 => 1, _ => 0 };
        }

        private bool GetOperation(Argument argument, bool a, bool b)
        {
            return argument.NumOperation switch
            {
                1 => a && b,
                2 => a || b,
                3 => (!a && b) || (a && !b),
                4 => !a || !b,
                5 => !a && !b,
                6 => (!a && !b) || (a && b),
                7 => !a || b,
                8 => a && !b,
                _ => false
            };
        }

        public Argument GetArgument() //определяем чем является текущий символ
        {
            Argument argument = new Argument
            {
                Type = OldArgumentType.Error,
                NumOperation = 0
            };

            if (Position >= formula.Length)
            {
                argument.Type = OldArgumentType.Nothing;
                return argument;
            }

            char a = formula[Position];
            char b;
            if (Position+1<formula.Length)
            {
                b = formula[Position+1];
            }
            else
            {
                b = 'e';
            }

            if (a == '(')
            {
                argument.Type = OldArgumentType.BracketLeft;
            }
            else if (a == ')')
            {
                argument.Type = OldArgumentType.BracketRight;
            }
            else if (a == '!')
            {
                argument.Type = OldArgumentType.Negative;
            }
            else if (a == 'x' && char.IsDigit(b) && b >= '1' && b <= '9')
            {
                argument.Type = OldArgumentType.Value;
                argument.NumVar = int.Parse(b.ToString());
                Position++;
            }
            else if (a == 'f' && (b == '0' || b == '1'))
            {
                argument.Type = OldArgumentType.Value;
                argument.NumVar = 10 + int.Parse(b.ToString());
                Position++;
            }
            else if (a == '.' && char.IsDigit(b) && b >= '1' && b <= '8')
            {
                argument.Type = OldArgumentType.Operation;
                argument.NumOperation = int.Parse(b.ToString());
                Position++;
            }
            return argument;
        }

        private bool GetResult(Argument left) 
        {
            Argument temp = GetArgument();
            bool result = false;
            if (Error == 0)
            {
                switch (temp.Type)
                {
                    case OldArgumentType.Nothing:
                        if (left.Type == OldArgumentType.Nothing)
                        {
                            Error = 1;
                        }
                        else if (left.Type == OldArgumentType.Value)
                        {
                            result = x[left.NumVar - 1];
                        }
                        else
                        {
                            Error = 2;
                        }
                        break;
                    case OldArgumentType.Negative:
                        if (left.Type == OldArgumentType.Negative)
                        {
                            Error = 3;
                        }
                        else if (left.Type == OldArgumentType.Value)
                        {
                            Error = 4;
                        }
                        else
                        {
                            Position++;
                            result = !GetResult(temp); 
                        }
                        break;
                    case OldArgumentType.Operation:
                        if (left.Type == OldArgumentType.Nothing)
                        {
                            Error = 2;
                        }
                        else if( left.Type == OldArgumentType.Value)
                        {
                            if (GetLevel(temp) <= GetLevel(left))
                            {
                                result = x[left.NumVar];
                            }
                            else
                            {
                                Position++;
                                result = GetResult(temp);
                                result = GetOperation(temp, x[left.NumVar -1], result);
                            }
                        }
                        else
                        {
                            Error = 3;
                        }
                        break;
                    case OldArgumentType.Value:
                        if (left.Type == OldArgumentType.Value)
                        {
                            Error = 4;
                        }
                        else if(left.Type == OldArgumentType.Negative)
                        {
                            Position++;
                            result = x[temp.NumVar];
                        }
                        else
                        {
                            temp.NumOperation = left.NumOperation;
                            Position++;
                            result = GetResult(temp);
                        }
                        break;
                    case OldArgumentType.BracketLeft:
                        int br = brackets;
                        brackets++;
                        if (left.Type == OldArgumentType.Value)
                        {
                            Error = 4;
                        }
                        else
                        {
                            Position++;
                            result = GetResult(temp);
                            while(Position < formula.Length && brackets != br && Error == 0)
                            {
                                x[0] = result;
                                temp.Type = OldArgumentType.Value;
                                temp.NumVar = 0;
                                result = GetResult(temp);
                            }
                        }
                        break;
                    case OldArgumentType.BracketRight:
                        brackets--;
                        if (brackets < 0)
                        {
                            Error = 5;
                        }
                        else if (left.Type == OldArgumentType.Value)
                        {
                            result = x[left.NumVar];
                            Position++;
                        }
                        else
                        {
                            Error = 2;
                        }
                        break;
                    case OldArgumentType.Error:
                        Error = 255;
                        break;
                }
            }
            return result;
        }

        public bool Solve(string fr, bool[] xs)
        {
            Argument temp = new Argument
            {
                Type = OldArgumentType.Nothing,
                NumOperation = 0
            };
            bool result;
            Error = 0;
            Position = 0;
            formula = fr;
            brackets = 0;

            Array.Copy(xs, x, Math.Min(xs.Length, 10));
            x[10] = false;
            x[11] = true;
            result = GetResult(temp);

            while (Position < formula.Length && Error == 0)
            {
                x[0] = result;
                temp.Type = OldArgumentType.Value;
                temp.NumVar = 0;
                result = GetResult(temp);
            }
            if (brackets > 0 && Error == 0)
            {
                Error = 6;
            }
            return result;
        }
    }
}
