using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationLecture.Classes
{
    public class Person
    {
        // name
        public string Name { get; set; }
        // age
        public int Age
        {  // based on birth year compared to current date
            //derived property. only get = readonly.
            get
            {
                int currentYear = DateTime.Now.Year;
                return currentYear - birthYear;
            }
        }
        private int birthYear { get; set; }

        // height
        public double Height { get; set; }
        
        // SSN
        private string ssn { get; set; }

        //constructor:
        //once a constructor is defined, the default no-arg constructor is not available. 
        public Person(int yearOfBirth) //means we're building an object of this class 
        {

        }

        public Person()
        {

        }
    }
}
