using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    enum ArgumentType
    {
        Operation = 1,
        Variable = 2,
        NVariable = 3,
        FixedValue = 4,
        BracketLeft = 5,
        NBracketLeft = 6,
        BracketRight = 7
    }

}
