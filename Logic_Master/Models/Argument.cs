using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.Models
{
    public struct Argument
    {
        public OldArgumentType Type { get; set; }
        public int NumVar {  get; set; }
        public int NumOperation { get; set; }
    }
}
