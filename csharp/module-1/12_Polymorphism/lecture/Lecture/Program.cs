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
            // FarmAnimal[] animals = new FarmAnimal[] { new Cow(), new Chicken(), new Pig() };
            ISingable[] singables = new ISingable[] { new Cow(), new Chicken(), new Pig(), new Tractor() };

            //foreach (FarmAnimal animal in animals)
            foreach (ISingable thing in singables)
            {
                Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
                Console.WriteLine("And on his farm he had a " + thing.Name + ", ee ay ee ay oh!");
                Console.WriteLine("With a " + thing.Sound + " " + thing.Sound + " here");
                Console.WriteLine("And a " + thing.Sound + " " + thing.Sound + " there");
                Console.WriteLine("Here a " + thing.Sound + " there a " + thing.Sound + " everywhere a " + thing.Sound + " " + thing.Sound);
                Console.WriteLine();
            }

            Console.WriteLine("----------");

            // time to sell some stuff. 

            ISellable[] sellables = new ISellable[] { new Cow(), new Chicken(), new Pig(), new Egg() };
            foreach(ISellable item in sellables)
            {

                Console.WriteLine($"Please buy this {item.Name} for only {item.Price}!");
            }

            Console.WriteLine("-----------------");

            Tractor myTractor = new Tractor();
            myTractor.Drive();
            Truck myTruck = new Truck();
            myTruck.Drive();
        }
    }
}