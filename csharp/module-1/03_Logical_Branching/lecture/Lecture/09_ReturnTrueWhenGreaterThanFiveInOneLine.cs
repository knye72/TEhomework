namespace Lecture
{
    public partial class LectureExample
    {
        /*
         9. How can we rewrite exercise 8 to have only one line of code?
            TOPIC: Boolean Expression & Comparison Operators
        */
        public bool ReturnTrueWhenGreaterThanFiveInOneLine(int number)
        {

            
            //return true if number is greater than 5
            return (number > 5); // What can we put here that returns a bool that we want? this evaluates the expression within the parentheses. 
            //you can do it without the parentheses but it's ugly.
        }
    }
}
