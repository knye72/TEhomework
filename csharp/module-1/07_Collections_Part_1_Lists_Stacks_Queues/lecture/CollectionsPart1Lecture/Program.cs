using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
	{
        static void Main(string[] args)
        {
			/* ARRAYS
			 * 
			 * */
			double[] averageScores = new double[20];
			averageScores[0] = 3.0; //can only be doubles. putting = "3.0" is not allowed.

			// lists live in System.Collections.Generic;


			string[] teStaff = new string[6];
			teStaff[0] = "David";
			teStaff[1] = "Tori";
			teStaff[2] = "John";
			teStaff[3] = "Ben";
			teStaff[4] = "Kaitlin";
			teStaff[5] = "Chelsea";

			// to do the same on a list is easier. 			

			Console.WriteLine("####################");
			Console.WriteLine("       LISTS");
			Console.WriteLine("####################");

			List<string> names = new List<string>(); // the () calls the constructor for this list. 
			names.Add("Frodo"); //add is a method that takes in a value, hence the quote
			names.Add("Sam");
			names.Add("Pippin");
			names.Add("Merry");
			names.Add("Gandalf");
			names.Add("Aragorn");
			names.Add("Boromoir");
			names.Add("Gimli");
			names.Add("Legolas");


			// if this were an array:
			/*for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
*/
			// for a list, we use count

			for(int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");

			names.Add("Sam"); // you're able to have multiple indices with the same value

			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine(names[i]);
			}


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");

			names.Insert(2, "David");

			for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");

			names.RemoveAt(2);

			for (int i = 0; i < names.Count; i++)
            {
				Console.WriteLine(names[i]) ;
            }


			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");

			bool isItemInList = names.Contains("Gandalf");
            Console.WriteLine("Is Gandalf in the names list? " + isItemInList);


			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");

			/*int gandalfIndex = -1;
			for(int i = 0; i < names.Count; i++)
            {
				if (names[i] == "Gandalf")
                {
					gandalfIndex = i;
                }
            }
            Console.WriteLine("Gandalf is located at index " + gandalfIndex);*/

			int gandalfIndex = names.IndexOf("Gandalf");
            Console.WriteLine("");

			// if it doesn't find something within the list/collection, you'll get a return value of -1. 


            Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");

			string[] namesArray = names.ToArray();

			for(int i = 0; i < namesArray.Length; i++)
            {
                Console.WriteLine(namesArray[i]);
            }


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");

			names.Sort(); //using sort will change the actual list. it won't make a copy. 

			for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");

			names.Reverse(); // materially changes the list and puts it in reverse order. there's no undo once you've changed the list.

			for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }


			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();

			// the below will loop through names
			//it will run the codeblock (writeline) on every item in the collection.
			// explanation: foreach(Type variableName in Collection)
			foreach(string name in names) // "name" is a variable. it doesn't have to be anything in particular. 
            {
                Console.WriteLine(name);
            }

			string myWord = "TechElevator"; // a string is a collection/array of characters, so a foreach loop works. 

			foreach(char letter in myWord)
            {
                Console.WriteLine(letter);
            }

			// List<Dog> dogs = new List<Dog>();

			List<bool> isWeekend = new List<bool>();

			// starting with tuesday becuase today is tuesday
			isWeekend.Add(false);
			isWeekend.Add(false);
			isWeekend.Add(false);
			isWeekend.Add(false);
			isWeekend.Add(true);
			isWeekend.Add(true);
			isWeekend.Add(false);

			foreach(bool dayOfWeek in isWeekend)
            {
                Console.WriteLine(dayOfWeek);
            }

			Queue<Dog> dogQueue = new Queue<Dog>();
			dogQueue.Enqueue(zachDog); //enqueue is just adding
			dogQueue.Enqueue(davidsDog);

			dogQueue.Dequeue(); //removing from queue.
		}
	}
}
