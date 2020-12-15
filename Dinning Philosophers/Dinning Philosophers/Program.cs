using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dinning_Philosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize Philosophers
            Philosopher Philosopher1 = new Philosopher(Table.Fork5, Table.Fork1, 1);
            Philosopher Philosopher2 = new Philosopher(Table.Fork1, Table.Fork2, 2);
            Philosopher Philosopher3 = new Philosopher(Table.Fork2, Table.Fork3, 3);
            Philosopher Philosopher4 = new Philosopher(Table.Fork3, Table.Fork4, 4);
            Philosopher Philosopher5 = new Philosopher(Table.Fork4, Table.Fork5, 5);

            //Start philosophers threads
            new Thread(Philosopher1.Think).Start();
            new Thread(Philosopher2.Think).Start();
            new Thread(Philosopher3.Think).Start();
            new Thread(Philosopher4.Think).Start();
            new Thread(Philosopher5.Think).Start();

            //Start status thread
            Thread statusPrinter = new Thread(new ThreadStart(StatusPrinter));
            statusPrinter.Start();

            Console.ReadKey();
        }

        public static void StatusPrinter()
        {
            while (true)
            {
                Console.WriteLine("Fork1: is taken: "+Table.Fork1.IsTaken);
                Console.WriteLine("Fork2: is taken: "+Table.Fork2.IsTaken);
                Console.WriteLine("Fork3: is taken: "+Table.Fork3.IsTaken);
                Console.WriteLine("Fork4: is taken: "+Table.Fork4.IsTaken);
                Console.WriteLine("Fork5: is taken: "+Table.Fork5.IsTaken);
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
    }
}
