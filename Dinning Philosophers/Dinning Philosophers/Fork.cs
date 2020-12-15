using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinning_Philosophers
{
    class Fork
    {
        public bool IsTaken{ get; set; }
        public int TakenBy { get; set; }

        public bool Take(int takenBy)
        {
            lock(this)
            {
                if (IsTaken == false)
                {
                    IsTaken = true;
                    TakenBy = takenBy;
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        public void Put()
        {
            IsTaken = false;
            TakenBy = 0;
        }
    }
}
