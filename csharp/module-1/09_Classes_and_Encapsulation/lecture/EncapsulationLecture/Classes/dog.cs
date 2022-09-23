using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationLecture.Classes
{
    public class dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        private bool isSpayed { get; set; }
        private string speakSound; // this is called a backing field. we need this if we're doing the just-set one below.
        public string SpeakSound
        {
            set
            {
                this.speakSound = value; //value is the new data getting assigned from the main
            }
        }
        public dog()
        {
            Console.WriteLine("inside dog constructor");
        }
        //
        public dog(string name, string breed, bool isSpayed)
        {
            //this - a keyword which refers to the current object. usually optional but allows you to specify the object you are working in.
            this.Name = name; //sets the current thing you're building. 
            Breed = breed;
            this.isSpayed = isSpayed;
        }
        //adding behaviors. this method will cause the dog to bark. 
        

        //multiple versions of the same method. called OVERLOADING. one takes a parameter
        //the other defaults.
        //we have a different number or type(s) of parameters. 1st one uses nothing
        //second one uses {sound}
        public void Speak()
        {
            Console.WriteLine($"{this.Name} says {this.speakSound}");
        }

        public string GetGreeting()
        {
            return $"Hello {this.Name}, you are a good dog";
        }

    }
}
