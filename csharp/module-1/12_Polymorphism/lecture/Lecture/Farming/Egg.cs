using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Egg : ISellable
    {
        public string Name { get;  }
        public decimal Price { get; }

        public Egg()
        {
            Name = "Egg";
            Price = (decimal)0.25;
        }
    }
}
