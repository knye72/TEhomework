namespace Lecture.Farming
{
    public class Cow : FarmAnimal, ISellable
    {
        public decimal Price { get; }

        public override string Eat()
        {
            return "Yum yum, grass!";
        }
        public Cow() : base("Cow", "moo")
        {
            Price = 1500;
        }
    }
}
