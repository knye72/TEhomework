namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return a version without the first and last char, so "Hello" yields "ell".
        The string length will be at least 2.
        WithoutEnd("Hello") → "ell"
        WithoutEnd("java") → "av"
        WithoutEnd("coding") → "odin"
        */
        public string WithoutEnd(string str)
        {
            if (str.Length >= 3)
            {

                return (str.Substring(1, str.Length ^ 1));
            }
            return null;
        }
    }
}
