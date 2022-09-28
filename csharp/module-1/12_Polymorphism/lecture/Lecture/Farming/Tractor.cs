
namespace Lecture.Farming
{
    public class Tractor : ISingable, IDriveable // same syntax as when you're inheriting a class. 
    {
        public string Name { get; }
        public string Sound { get; }

        public Tractor()
        {
            Name = "Tractor";
            Sound = "vroom";
        }

        public void Drive()
        {
            System.Console.WriteLine("Wooo driving my tractor!");
        }
    }
}
