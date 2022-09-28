using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Truck : IDriveable
    {
        public string Name { get;  }
        public string Sound { get; }

        public Truck()
        {
            Name = "Truck";
            Sound = "Brrrrrr";
        }
        public void Drive()
        {
            Console.WriteLine("Crank up the radio and play a truck song.");
        }
    }
}
