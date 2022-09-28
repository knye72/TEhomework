namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable //inherits from FarmAnimal and implements ISellable interface. 
    {
        public decimal Price { get; }
        public Pig() : base("Pig", "oink")
        {
            Price = 60;
        }
    }
}
