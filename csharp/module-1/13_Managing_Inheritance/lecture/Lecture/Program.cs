using Lecture.Farming;
using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // OLD MACDONALD
            //

            Cow sirloin = new Cow();
            Chicken frederick = new Chicken();
            Pig bacon = new Pig();
            Cat philco = new Cat();
            Tractor internationalHarvester = new Tractor();

            philco.Sleep(true); //puts Phil down for a nap
            bacon.Sleep(true);

            // FarmAnimal animal = new Cow(); you can't make a new instance of FarmAnimal but you can do a cow.
            /*FarmAnimal[] farmAnimals = new FarmAnimal[] { sirloin, frederick, bacon };
            Cow farmCow = new Cow(); //basically the same as below...for now. eg: there's no farmAnimal.Type for types of cow. 
            FarmAnimal farmCowTwo = new Cow(); */

            Console.WriteLine(philco.Eat());
            Console.WriteLine(frederick.Eat());

            ISingable[] singables = new ISingable[]
            {
                //new Cow(), new Chicken(), new Pig(), new Tractor()
                sirloin, frederick, bacon, philco, internationalHarvester
            };

            foreach(ISingable singable in singables)
            {
                Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
                Console.WriteLine("And on his farm he had a " + singable.Name + ", ee ay ee ay oh!");
                Console.WriteLine("With a " + singable.Sound + " " + singable.Sound + " here");
                Console.WriteLine("And a " + singable.Sound + " " + singable.Sound + " there");
                Console.WriteLine("Here a " + singable.Sound + " there a " + singable.Sound + " everywhere a " + singable.Sound + " " + singable.Sound);
                Console.WriteLine();
            }

            ISellable[] sellables = new ISellable[]
            {
                new Cow(), new Pig(), new Egg()
            };

            foreach(ISellable sellable in sellables)
            {
                Console.WriteLine("Step right up and get your " + sellable.Name);
                Console.WriteLine("Only $" + sellable.Price);
            }
        }
    }
}