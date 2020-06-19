using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXV_Dejan_Prodanovic
{
    class MyThreads
    {
        public void AppInput()
        {
            Console.WriteLine("Unesite broj tredova koji ucestvuju u pogadjanju:");
            IntInputForNumberOfParticipants();
            Console.WriteLine("Unesite broj koji treba da se pogodi:");
            IntInputForWantedNumber();
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
    }
}
