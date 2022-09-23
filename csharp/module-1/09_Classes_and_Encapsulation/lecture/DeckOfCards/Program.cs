using System;
using DeckOfCards.Stubs;
using System.Drawing;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            WoodenPencil pencil = new WoodenPencil();
            pencil.Length = 5.0; // can change the indivdual pencil length becuase it's not a const or static.
            
        }
    }
}
