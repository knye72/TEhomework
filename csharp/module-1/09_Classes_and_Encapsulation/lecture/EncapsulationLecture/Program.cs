using System;
using EncapsulationLecture.Classes;

namespace EncapsulationLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person david = new Person(1989);
            string dogName = "Jerry";

            dog davidsDog = new dog(dogName, "Shepherd-mix", true);
            dog charliesDog = new dog("Snoopy", "Beagle", false);

            dog emptyDog = new dog(); // this accesses the dog with no parameters.

            davidsDog.SpeakSound = "Ruff";
            //calling Speak on davids dog. in the dog.cs page we've made Speak become "dogName says WOOF"
            davidsDog.Speak();

            //calling Speak on charlie's dog.
            charliesDog.SpeakSound = "arf";
            charliesDog.Speak();


            string charliesDogGreeting = charliesDog.GetGreeting();
            Console.WriteLine(charliesDogGreeting);
            Console.WriteLine(davidsDog.GetGreeting());
           // charliesDog.Speak("grrr"); //if we pass in a value it inputs the value. if not, the Speak() defaults to arf, i think.
        }
    }
}
