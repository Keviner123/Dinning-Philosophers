using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinning_Philosophers
{
    class Table
    {
        internal static Fork Fork1 = new Fork() { IsTaken = false };
        internal static Fork Fork2 = new Fork() { IsTaken = false };
        internal static Fork Fork3 = new Fork() { IsTaken = false };
        internal static Fork Fork4 = new Fork() { IsTaken = false };
        internal static Fork Fork5 = new Fork() { IsTaken = false };
    }
}
