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
            Thread t2 = new Thread(mt.ThreadGeneratorMethod);

            t1.Start();


            while (!mt.inputTaken)
            {
                Thread.Sleep(10);
            }
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine();

            foreach (var t in mt.threads)
            {
                t.Start();
            }

            foreach (var t in mt.threads)
            {
                t.Join();
            }

            Console.ReadLine();
        }
    }
}
