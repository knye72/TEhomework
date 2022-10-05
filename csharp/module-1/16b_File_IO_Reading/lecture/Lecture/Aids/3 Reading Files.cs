﻿using System;
using System.IO;

namespace Lecture.Aids
{
    /*
    * Reading files for input involves working with streams and readers.
    */
    public static class ReadingInFiles
    {
        // Reading in a character file involves working with classes that derive from
        // TextWriter. TextWriter is an abstract class for working with character input.
        // The StreamReader inherits from TextWriter and that is often used.
        public static void ReadACharacterFile()
        {
            // Start with the file path to input
            string directory = Environment.CurrentDirectory;
            string filename = "Input.txt";

            // Create the full path
            string fullPath = Path.Combine(directory, filename);

            // Wrap the effort in a try-catch block to handle any exceptions
            try //reading file data is inherently dangerous bc maybe there are file corruption issues or it's formatted wrong or whatever.
            {
                //Open a StreamReader with the using statement
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    // Read the file until the end of the stream is reached
                    // EndOfStream is a "marker" that the stream uses to determine
                    // if it has reached the end
                    // As we read forward the marker moves forward like a typewriter.
                    while (!sr.EndOfStream) //while streamreader is not at end of stream...
                    {
                        // Read in the line. they go 1 line at a time. 
                        string line = sr.ReadLine();

                        // Print it to the screen
                        Console.WriteLine(line);
                    }
                }
            }
            catch(IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
        }
    }
}
