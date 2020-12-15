using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dinning_Philosophers
{
    class Philosopher
    {
        public int Identity { get; set; }

        public PhilosopherState State { get; set; }

        public bool HasForkInRightHand{ get; set; }
        public bool HasForkInLeftHand{ get; set; }

        public readonly Fork RightFork;
        public readonly Fork LeftFork;

        Random rand = new Random();

        public Philosopher(Fork rightFork, Fork leftFork, int identity)
        {
            RightFork = rightFork;
            LeftFork = leftFork;
            Identity = identity;
            State = PhilosopherState.Thinking;
        }

        public void Eat()
        {
            //Check if the Philosopher is sitting at an even chair.
            if(Identity % 2 == 0)
            {
                if (TakeForkInLeftHand())
                {
                    HasForkInLeftHand = true;
                }
            }
            else
            {
                if (TakeForkInRightHand())
                {
                    HasForkInRightHand = true;
                }
            }

            //Get the other fork
            if (Identity % 2 == 0)
            {
                if (TakeForkInRightHand())
                {
                    HasForkInRightHand = true;
                }
            }
            else
            {
                if (TakeForkInLeftHand())
                {
                    HasForkInLeftHand = true;
                }

            }

            //If the Philosopher has a fork in both hands
            if (HasForkInRightHand && HasForkInLeftHand)
            {
                //Eat, and spend a random amount of time.
                Console.WriteLine("Philosopher: {0} is ready to eat", Identity);
                Thread.Sleep(rand.Next(4000, 8000));

                Console.WriteLine("Philosopher: {0} is done eating", Identity);

                //Put the utensils back for another person to use.
                RightFork.Put();
                LeftFork.Put();
            }

            else
            {
                Console.WriteLine("Philosopher: {0} was unable to get enough forks, and will need to wait.", Identity);
            }

            //Return to thinking
            Think();
        }

        public void Think()
        {
            //Think for a random amount of time.
            this.State = PhilosopherState.Thinking;
            Console.WriteLine("Philosopher: {0} is thinking...", Identity);
            Thread.Sleep(rand.Next(200, 5000));
            Eat();
        }

        private bool TakeForkInLeftHand()
        {
            return LeftFork.Take(Identity);
        }

        private bool TakeForkInRightHand()
        {
            return RightFork.Take(Identity);
        }

    }
}
