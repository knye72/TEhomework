using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the
         * number of times that string appears in the array.
         *
         * ** A CLASSIC **
         *
         * WordCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
         * WordCount(["a", "b", "a", "c", "b"]) → {"b": 2, "c": 1, "a": 2}
         * WordCount([]) → {}
         * WordCount(["c", "b", "a"]) → {"b": 1, "c": 1, "a": 1}
         *
         */
        public Dictionary<string, int> WordCount(string[] words)
        {
            // i want to return a dicionary with <string, int> as the data types. i want those data types to come
            // from th words in the string array. i also want to count the instances of each element of the string.
            // first i need to get the words from the array.
            
            // setting a value of 1 if the key hasnt' appeared before. if ti has, then the value is 1 + itself.
            // .contains might work. 
            Dictionary<string, int> countingWords = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!countingWords.ContainsKey(words[i]))
                {
                    countingWords[words[i]] = 1;
                }
                else
                {
                    countingWords[words[i]] += 1;
                }
            }
            return countingWords;
        }
    }
}
