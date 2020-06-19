﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXV_Dejan_Prodanovic
{
    class MyThreads
    {
        private int numberOfParticipants;
        private int wantedNumber;
        Random rnd = new Random();

        public void AppInput()
        {
            Console.WriteLine("Unesite broj ucesnika koji ucestvuju u pogadjanju:");
            numberOfParticipants = IntInputForNumberOfParticipants();
            Console.WriteLine("Unesite broj koji treba da se pogodi:");
            wantedNumber = IntInputForWantedNumber();

            Thread.Sleep(1000);

            Console.WriteLine("Unesli ste {0} ucesnika u pogadjanju",numberOfParticipants);
            Console.WriteLine("Broj koji treba da se pogodi je {0}",wantedNumber);
        }

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

        int IntInputForNumberOfParticipants()
        {
            bool succes = false;
            int inputValue;
            do
            {
                succes = Int32.TryParse(Console.ReadLine(), out inputValue);
                if (!succes || inputValue < 1)
                    Console.WriteLine("Nevalidan unos.Unesite pozitivan ceo broj");
            } while (!succes);
            return inputValue;
        }
        //public void ThreadGeneratorMethod()
        //{
        //    for (int i = 0; i < numberOfParticipants; i++)
        //    {
        //        Thread t = new Thread();
        //    }
        //}

        public void GuessWantedNumber()
        {
            int generatedNumber = rnd.Next(1,101);
            //while (generatedNumber != wantedNumber)
            //{
            //    Thread.Sleep(100);
            //}

            if (generatedNumber == wantedNumber)
            {
                Console.WriteLine("pogodili ste  broj");
            }  
          
            
        }
    }
}
