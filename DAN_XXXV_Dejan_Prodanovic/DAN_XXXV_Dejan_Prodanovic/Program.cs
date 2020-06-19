using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXV_Dejan_Prodanovic
{
    class Program
    {

        static void Main(string[] args)
        {
            MyThreads mt = new MyThreads();
            Thread t1 = new Thread(mt.AppInput);
            t1.Start();
           
            t1.Join();
            for (int i = 0; i < 100; i++)
            {
                mt.GuessWantedNumber();
            }
            //mt.AppInput();
            Console.ReadLine();
        }
    }
}
