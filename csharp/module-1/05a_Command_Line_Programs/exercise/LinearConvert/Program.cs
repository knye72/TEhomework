using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = 0;
            do
            {
                Console.WriteLine("Please enter a length.");
                string value = Console.ReadLine();
                length = double.Parse(value);

            }
            while (length < 0);


            string metersOrFeet = " ";
            do
            {
                Console.WriteLine("Please enter 'm' for meters or 'f' for feet.");
                metersOrFeet = Console.ReadLine();
            }
            while (metersOrFeet != "m" && metersOrFeet != "f");
            
                Console.WriteLine("Please enter either an 'm' or an 'f'.");

                if (metersOrFeet == "m")
            {
                double newLength = length * 3.2808399; // convert meters to feet
                Console.WriteLine(length + " meters is " + newLength + "feet");
            }
            else if(metersOrFeet == "f")
            {
                double thirdLength = length * 0.3048;                //convert feet to meters
                Console.WriteLine(length + " feet is " + thirdLength + "meters.");
            }
         
            }
        }
    }

