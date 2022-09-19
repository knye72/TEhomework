using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double newNumber = 0;
            Console.WriteLine("Provide a number to convert to binary");

            string value = Console.ReadLine();
            newNumber = double.Parse(value);

            string[] binaryArray = value.Split(' ');
            for (int i = 0; i < binaryArray.Length; i++)
            {
                string newValue = binaryArray[i];
                int thirdValue = int.Parse(newValue);
                string binary = Convert.ToString(thirdValue, 2);

                Console.WriteLine(value + " in binary is " + binary);
            }
        }
    }
}
