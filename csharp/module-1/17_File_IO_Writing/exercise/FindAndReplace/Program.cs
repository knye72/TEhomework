using System;
using System.IO;

namespace FindAndReplace
{
    public class Program
    {
		public static void Main(string[] args)
		{
            Console.WriteLine("What is the word you'd like to replace?");
            string wordToReplace = Console.ReadLine();
            Console.WriteLine("What is the word you would like to use instead?");
            string newWord = Console.ReadLine();
            Console.WriteLine("What is the source file?");
            string filePath = Console.ReadLine();
            Console.WriteLine("What is the destination file?");
            string destFilePath = Console.ReadLine();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    using (StreamWriter sw = new StreamWriter(destFilePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string fixedLine = line.Replace(wordToReplace, newWord);

                            sw.WriteLine(fixedLine);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Please try again with a valid response.");
                Console.WriteLine(e.Message);
            }
            }
        }
    }
