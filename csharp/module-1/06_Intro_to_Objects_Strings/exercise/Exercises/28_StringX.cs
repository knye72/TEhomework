namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return a version where all the "x" have been removed. Except an "x" at the very start or end
        should not be removed.
        StringX("xxHxix") → "xHix"
        StringX("abxxxcd") → "abcd"
        StringX("xabxxxcdx") → "xabcdx"
        */
        public string StringX(string str)
        {
            int numberOfX = 0;
            for(int i = 1; i < str.Length -1; i++)
            {
                string lessX = str.Substring(1, str.Length - 1);
                if(str[i] == 'x')
                {
                    return str.Replace('x', ' ');
                }
                
            }
            return null;
        }
    }
}
