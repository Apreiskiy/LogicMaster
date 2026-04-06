using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    public partial class LogicFunction
    {
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
            int number = FFunction[FPosition] & 0xFF;
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
    }
}
