using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    enum Error
    {
        NoError,
        Empty,
        UnknownArgument,
        AbsentValue,
        AbsentOperation,
        AbsentBracketLeft,
        AbsentBracketRight,
        End
    }
}
