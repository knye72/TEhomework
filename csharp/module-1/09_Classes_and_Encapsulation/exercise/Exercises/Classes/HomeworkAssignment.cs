namespace Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; private set; }
        public string SubmitterName { get; private set; }

        public string LetterGrade
        {
            get
            {
                double grades = (double)EarnedMarks / PossibleMarks * 100;
                if (grades >= 90)
                {
                    return "A";
                }
                else if (grades >= 80)
                {
                    return "B";
                }
                else if (grades >= 70)
                {
                    return "C";
                }
                else if (grades >= 60)
                {
                    return "D";
                }
                else return "F";
            }
            
        }
        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            this.PossibleMarks = possibleMarks;
            this.SubmitterName = submitterName;
        }


        


    }
}
