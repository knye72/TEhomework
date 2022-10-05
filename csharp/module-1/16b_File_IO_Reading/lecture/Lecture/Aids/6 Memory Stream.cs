using System;
using System.IO;

namespace Lecture.Aids
{
    public class Memory_StreamSample
    {
        public static void ReadStream()
        {
            string folder = Environment.CurrentDirectory;
            string file = "input.txt";
            string fullPath = Path.Combine(folder, file);

            byte[] bytes = File.ReadAllBytes(fullPath); //File class has ReadAllBytes(path) that reads all the data in a file to a byte array
            Console.Write(bytes); // gives us a byte array but doesn't present it to us. we likely won't be using this anytime soon. 
            // we would need to convert the byte array into something else but that's complicated for now.
        }
    }
}
