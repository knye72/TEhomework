using System;

namespace IntroToObjectsTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // ***********  Step 1: Use the *new* operator to create strings on the Heap  *************
            char[] helloChars = new char[] { 'h', 'e', 'l', 'l', 'o', '!' };
            string greeting = new string(helloChars);
            Console.WriteLine("Greeting: " + greeting);

            // ***********  Step 2: Try out some string methods  *************


        }
    }
}
