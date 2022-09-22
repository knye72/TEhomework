using System;
using System.Collections.Generic;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
        static void Main(string[] args)
        {

			// Be careful removing items from a list while looping becuase it'll change indices. 

			// DICTIONARY -  a collection that stores objects
			// - is NOT ordered. first unordered collection we've seen.
			// - store data in key-value pair.
			// - values are retrieved by using the key.
			// - values can have duplicates 
			// - keys cant have duplicates.
			// - think of "key" as the word in the dictionary and "value" is the definition.
			// - keys need to be the same type.
			// - values need to be the same type. 
			// - keys and values do NOT need to be the same type. 



			Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();

			//declaring a dictionary. using data type string and value string.
			Dictionary<string, string> nameToZip = new Dictionary<string, string>();
			// adding to dictionary

			nameToZip["David"] = "44120"; // putting pair together directly. simplest/safest way. it will insert a new one or update an existing key.
			// nameToZip.Add("David", "44170"); // if there's already a key with that name we get an error. we can't just ADD david if it already exists.
			nameToZip["David"] = "44170"; // this will just update david to a different zip.

			nameToZip["Tori"] = "44102";
			nameToZip["Ben"] = "44124";

            // retrieving values from dictionary: you ask for a key and it provides you the value. it's like printing an index.

            Console.WriteLine("David lives in " + nameToZip["David"]);

			// retrieving just the keys from the dictionary.
			IEnumerable<string> keys = nameToZip.Keys; //returns a collection of all keys in the dictionary.
                                                       //data type (string) should match your key data type
													   //the IEnumerable doesn't return a simple list/array. 

            foreach (string keyName in keys)
            {
                Console.WriteLine(keyName + " lives in " + nameToZip[keyName]);
            }

			//keys isn't a list so we can't do .length or .count, which makes a for loop tricky.
			// for(int i = 0; i < keys.length doesnt work). 

			//checking if a Key is in a dictionary:

			if (nameToZip.ContainsKey("David"))
            {
                Console.WriteLine("David exists.");
            }

			// update david's zip to be 12345
			nameToZip["David"] = "12345";

            Console.WriteLine("David's zip is " + nameToZip["David"]);

			foreach(KeyValuePair<string, string> nameZip in nameToZip)
            {
                Console.WriteLine(nameZip.Key + " liveth in " + nameZip.Value);
            }
            Console.WriteLine();

			nameToZip.Remove("David");
            Console.WriteLine("Removed David");

			foreach(KeyValuePair<string, string> nameZip in nameToZip)
            {
                Console.WriteLine($"Key: {nameZip.Key}, value: {nameZip.Value}");
            }

			IEnumerable<string> values = nameToZip.Values;


			// how to initialize a dictionary with known key-value pairs. 

			Dictionary<string, string> studentNames = new Dictionary<string, string>()
			{
				{"Tracy", "Barry" },
				{"Colin", "Detwiler" },
				{"Kim", "Barry" },
				{"Maria G", "Garcia" },
				{"Amy", "Drapac" },
				{"Ben", "Measor" },
				{"Joe", "Gibson" },
				{"Alex", "Hewson" }
			};

			// Debugging. adding the red dot allows us to pause and look at what's happening.
			// you *can* change things while you're debugging but probably shouldn't do it. 
			// ex: don't change something in a foreach loop while the loop is running.

			if(nameToZip.Count < 3)
            {
				Console.WriteLine("name to zip dictionary is small");
            }
			else
            {
                Console.WriteLine("name to zip diciontary is not small");
            }
			
			foreach(KeyValuePair<string, string> student in studentNames)
            {
                Console.WriteLine("Key: " + student.Key);
                Console.WriteLine("Value: " + student.Value);
            }
		}
	}
}
