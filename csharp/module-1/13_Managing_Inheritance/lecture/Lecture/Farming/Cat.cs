namespace Lecture.Farming
{
    public sealed class Cat : FarmAnimal, ISellable //means there's no chance for inheritance/subclasses of cat. 
    {
        public decimal Price { get; }

        public Cat() : base("Cat", "meow")
        {
            
        }

        public override string Eat()
        {
            return "Yum yum, cat food!";
        }

        public override string Sound
        {
            get
            {
                return "meow";
            }
        }
    }
}
