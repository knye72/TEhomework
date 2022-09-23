namespace Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; private set; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            this.TypeOfFruit = typeOfFruit;
            PiecesOfFruitLeft = startingPiecesOfFruit;
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {
            if(PiecesOfFruitLeft >=  numberOfPiecesToRemove)
            {
                PiecesOfFruitLeft = PiecesOfFruitLeft - numberOfPiecesToRemove;
                return true;
            }
            else
            {
                PiecesOfFruitLeft = PiecesOfFruitLeft;
                return false;
            }

        }
    }
}
