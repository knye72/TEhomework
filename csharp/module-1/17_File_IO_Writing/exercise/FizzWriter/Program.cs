using System;
using System.IO;

namespace FizzWriter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please provide a valid destination file location.");
            string destFilePath = Console.ReadLine();
            //string filePath = Environment.CurrentDirectory;
            

           
/*                using (StreamReader sr = new StreamReader(filePath))
                {*/
               using (StreamWriter sw = new StreamWriter(destFilePath))
                    {

                    for (int i = 1; i <= 300; i++)
                    {
                        if (i % 3 == 0 && i % 5 == 0)
                        {
                            sw.WriteLine("FizzBuzz");
                        }
                        else if (i % 3 == 0)
                        {
                            sw.WriteLine("Fizz");
                        }
                        else if (i % 5 == 0)
                        {
                            sw.WriteLine("Buzz");
                        }
                        else
                        {
                            sw.WriteLine(i);
                        }

                    }
                           
                            
                            
                        
                    }
                
                
            
            
        }
    }
}
