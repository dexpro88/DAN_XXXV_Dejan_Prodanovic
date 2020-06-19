using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXV_Dejan_Prodanovic
{
    class MyThreads
    {
        //number of threads
        private int numberOfParticipants;
        private int wantedNumber;
        Random rnd = new Random();
        public List<Thread> threads = new List<Thread>();
        bool numberGuessed = false;
        public bool inputTaken = false;
        private static object theLock = new object();

        /// <summary>
        /// method for the first thread
        /// it takes input from the keyboard
        /// when the input is taken second thread will start
        /// it also tells user how many participants(threads) he input and which number he chose
        /// </summary>
        public void AppInput()
        {
                Console.WriteLine("Unesite broj ucesnika koji ucestvuju u pogadjanju:");
                numberOfParticipants = IntInputForNumberOfParticipants();
                Console.WriteLine("Unesite broj koji treba da se pogodi:");
                wantedNumber = IntInputForWantedNumber();


                inputTaken = true;
                Thread.Sleep(100);

                Console.WriteLine("Uneli ste {0} ucesnika u pogadjanju", numberOfParticipants);
                Console.WriteLine("Broj koji treba da se pogodi je {0}", wantedNumber);           
                        
        }

        /// <summary>
        /// method that takes input for wanted number
        /// it disables user to take the wrong input(non integer or integer that is non in wanted range)
        /// 
        /// </summary>
        /// <returns></returns>
        int IntInputForWantedNumber()
        {
            bool succes = false;
            int inputValue;
            do
            {
                succes = Int32.TryParse(Console.ReadLine(), out inputValue);
                if (!succes || inputValue < 1 || inputValue > 100)
                    Console.WriteLine("Nevalidan unos.Unesite ceo broj izmedju 1 i 100");
            } while (!succes|| inputValue<1 || inputValue >100);
            return inputValue;
        }
        /// <summary>
        /// method that takes input for number of participants
        ///  it disables user to take the wrong input(non integer or number less than 1)
        /// </summary>
        /// <returns></returns>
        int IntInputForNumberOfParticipants()
        {
            bool succes = false;
            int inputValue;
            do
            {
                succes = Int32.TryParse(Console.ReadLine(), out inputValue);
                if (!succes || inputValue < 1)
                    Console.WriteLine("Nevalidan unos.Unesite pozitivan ceo broj");
            } while (!succes || inputValue < 1);
            return inputValue;
        }

        /// <summary>
        /// method that generates list of threads and gives them names
        /// </summary>
        public void ThreadGeneratorMethod()
        {       
                for (int i = 0; i < numberOfParticipants; i++)
                {
                    Thread t = new Thread(GuessWantedNumber);
                    t.Name = String.Format("Ucesnik_{0}", i + 1);
                    threads.Add(t);
                    
                }              
        }

        /// <summary>
        /// method that will be forwarded to threads from the list 
        /// it generate a random number and check if it is a wanted number
        /// it uses while loop and in every iteration it sleeps for 100 ms
        /// because we use multithreading more than one thread will enter in the loop even if the number is 
        /// already guessed 
        /// </summary>
        public void GuessWantedNumber()
        {
            int generatedNumber = rnd.Next(1,101);
            while (generatedNumber != wantedNumber)
            {
                
                Thread.Sleep(100);
                generatedNumber = rnd.Next(1, 101);

                //we check if the number is already guessed and if it is we break the loop
                if (numberGuessed)
                {
                    break;
                }

               /*we lock this section because we want only one thread to ckeck if the number is found.
                 If it is found it prints the message and it sets numberGuessed variable to true.
                 So even if another thread comes to this section after him and if it guess the number
                 it will not print the message because we set numberGUesed on true and the if condition will 
                 not be fulfilled after we find the number for the first time*/
                lock (theLock)
                {
                    if (generatedNumber == wantedNumber&& !numberGuessed)
                    {
                        numberGuessed = true;
                        Console.WriteLine("{0} je pobedio", Thread.CurrentThread.Name);
                       
                    }
                    else
                    {
                        //some thrads may come to this part even when we find the number so we check if
                        //the number is found end we break the loop if it is
                        if (numberGuessed)
                        {
                            break;
                        }
                        Console.Write("{0} je pokusao pogoditi broj {1}", Thread.CurrentThread.Name,
                            generatedNumber);

                        //we check if thread guessed parity of number 
                        if (generatedNumber%2==wantedNumber%2)
                        {
                            Console.Write("{0} je pogodio  parnost broja\n", Thread.CurrentThread.Name);
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }             
            }               
            
        }
    }
}
