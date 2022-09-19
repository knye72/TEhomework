using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char).
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            char firstCharacter = name[0];
            char lastCharacter = name[name.Length - 1]; //name[^2]

            Console.WriteLine($"First is {firstCharacter} and Last Character is {lastCharacter}.");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            string firstThree = name.Substring(0, 3);

            Console.WriteLine($"First 3 characters: {firstThree}");

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            string lastThree = name.Substring(9, 3);

            Console.WriteLine($"First 3 plus last 3 is {firstThree}{lastThree} ");

            // 4. What about the last word?
            // Output: Lovelace

            // string lastWord = name.Substring(4, 8);

            string[] lastWord = name.Split(' '); // now we've split it into 2 so we have to specify

            Console.WriteLine($"Last Word: {lastWord[1]} ");

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            bool isLoveThere = name.Contains("Love");

            Console.WriteLine($"Contains \"Love\": {isLoveThere}"); // the use of forward slash is an escape character to make sure the " doens't work"

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            int laceStart = name.IndexOf("lace");

            Console.WriteLine($"Index of \"lace\": {laceStart}");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3


            int numberOfLetterA = 0;

            for(int i = 0; i < name.Length; i++)
            {
                if(name[i] == 'a' || name[i] == 'A')
                {
                numberOfLetterA++;
                }
            }
            Console.WriteLine($"Number of \"a's\": {numberOfLetterA} ");

            // second option

            int countLowercase = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if(name.ToLower()[i] == 'a'){
                    countLowercase++;
            }
            }
            string lowerName = name.ToLower();
            Console.WriteLine($"number of small a: {countLowercase}");
           

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            // string replaceString = name.Replace("Ada", "Ada, Countess of Lovelace"); this would create a new string named "replaceString"

            name = name.Replace("Ada", "Ada, Countess of Lovelace"); 

            Console.WriteLine(name);

            // 9. Set name equal to null.

            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            
            //if (name == null || name == "") ; can be simplified below

            if(String.IsNullOrEmpty(name))
            {
                Console.WriteLine("All Done");
            }
            Console.ReadLine();
        }
    }
}

    