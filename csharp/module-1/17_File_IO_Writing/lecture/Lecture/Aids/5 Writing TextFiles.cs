using System;
using System.IO;

namespace Lecture.Aids
{
    public static class WritingTextFiles
    {
        /*
        * This method below provides sample code for printing out a message to a text file.
        */
        public static void WritingAFile()
        {
            //setup for file
            string directory = Environment.CurrentDirectory; 
            //you can cut and paste your file-path here if you want it to appear in the solution explorer window to the right. use an @sign.

            string fileName = "output.txt";   // if the file doesn't already exist it'll just make a new file with this name.
                                              // if file does exist, it'll overwrite the existing file. 

            string fullPath = Path.Combine(directory, fileName);

            //step 2
            try
            {
                //step 3: using the streamwriter to write the file data
                using (StreamWriter sw = new StreamWriter(fullPath)) //unclear if it matters whether you put fullPath or fileName, but prob wanna do the path instead of file.
                {
                    //output.txt will be created.
                    sw.WriteLine("This is the start of my first file!"); //writes this line to the file. 
                    sw.Write("Hello ");
                    sw.Write("World!"); //puts "Hello World!" on the same line b/c there's no "line" in the write command. 

                    sw.WriteLine(); //an empty line
                    sw.WriteLine("Tech Elevator!");

                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("Oops, something went wrong writing output.txt.");
            }

           

            // After the using statement ends, file has now been written
            // and closed for further writing
        }
    }
}
