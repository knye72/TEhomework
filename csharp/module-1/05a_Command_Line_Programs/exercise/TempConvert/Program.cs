using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            double temperature = 0;

            Console.WriteLine("Please enter a temperature.");
            string value = Console.ReadLine();
            temperature = double.Parse(value);



            string celsiusOrFahrenheit = " ";
            do
            {
                Console.WriteLine("Please enter 'c' for celsius or 'f' for fahrenheit.");
                celsiusOrFahrenheit = Console.ReadLine();
            }
            while (celsiusOrFahrenheit != "c" && celsiusOrFahrenheit != "f");

            /*Console.WriteLine("Please enter either an 'c' or an 'f'.");*/

            if (celsiusOrFahrenheit == "c")
            {
                double newTemp = temperature * 1.8 + 32; // convert meters to feet
                Console.WriteLine(temperature + "c is " + newTemp + "f");
            }
            else if (celsiusOrFahrenheit == "f")
            {
                double thirdTemp = (temperature - 32) / 1.8;                //convert feet to meters
                Console.WriteLine(temperature + "f is " + thirdTemp + "c.");
            }


        }
    }
}
