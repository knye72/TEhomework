namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        3. Return the last element of the array
            TOPIC: Accessing Array Elements
        */
        public int ReturnLastElement()
        {
            int[] portNumbers = { 80, 8080, 443 };

            return portNumbers[portNumbers.Length -1];
            // return portNumbers[2];
            // return portNumbers[^1]; the ^ takes you to the end of the array and 1 moves you over 1. length =3 so that gives us index 2
            // each of these options would work as well
        }
    }
}
