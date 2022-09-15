namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        10. What code do we need to write so that we can find the highest
             number in the array randomNumbers?
             TOPIC: Looping Through Arrays
        */
        public int FindTheHighestNumber(int[] randomNumbers)
        {
            // need to do a comparison in an if statement and also do a loop. 
            int highestValue = randomNumbers[0];
            for (int i = 0; i < randomNumbers.Length; i++) 
            {
                int currentValue = randomNumbers[i];
                if (currentValue > highestValue)
                {
                    highestValue = currentValue; // resets highest value if current value > existing high value
                }

            }
            return highestValue;
        }
    }
}
