using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    public enum OldArgumentType
    {
        Nothing = 0,
        Negative = 1,
        Operation = 2,
        Value = 3,
        BracketLeft = 4,
        BracketRight = 5,
        Error = 255
    }
}
