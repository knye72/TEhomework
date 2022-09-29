namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public decimal Price { get; }

        public override string Eat()
        {
            return "Yum yum, human bones!";
        }
        public Pig() : base("Pig", "oink")
        {
            Price = 300;
        }
    }
}
