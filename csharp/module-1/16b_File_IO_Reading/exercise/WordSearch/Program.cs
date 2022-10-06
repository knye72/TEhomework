using System;
using System.IO;

namespace WordSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("What is the fully qualified name of the file that should be searched?");
            string filePath = Console.ReadLine();
            Console.WriteLine("What is the search term you are looking for?");
            string wordToFind = Console.ReadLine();
            Console.WriteLine("Should the search be case sensitive? (Y/N)");
            string caseSensitive = Console.ReadLine();

            if (caseSensitive.ToUpper() == "N")
            {
                wordToFind = wordToFind.ToLower();
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        int lineNumber = 0;
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string lineTwo = line.ToLower();
                            //string lineTwo = line.ToLower();
                            lineNumber++;
                            if (lineTwo.Contains(wordToFind))
                            {
                                Console.WriteLine($"{lineNumber}) {line}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please try again and provide a valid response.");
                    Console.WriteLine(ex.Message);
                }
            }
            

            else
            {
                try
                {

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        int lineNumber = 0;
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            lineNumber++;
                            if (line.Contains(wordToFind))
                            {
                                Console.WriteLine($"{lineNumber}) {line}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please try again and provide a valid response.");
                    Console.WriteLine(ex.Message);
                }


                //1. Ask the user for the file path
                //2. Ask the user for the search string
                //3. Open the file
                //4. Loop through each line in the file
                //5. If the line contains the search string, print it out along with its line number
            }
        }
    }
}
