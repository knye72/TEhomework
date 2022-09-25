namespace Exercises.Classes
{
    public class Elevator
    {
        public int CurrentLevel { get; private set; } = 1;
        public int NumberOfLevels { get; private set; }
        public bool DoorIsOpen { get; private set; } = false;

        public Elevator(int numberOfLevels)
        {
            NumberOfLevels = numberOfLevels;
        }
 
        public void OpenDoor()
        {
            if (DoorIsOpen == false)
            {
                DoorIsOpen = true;
            }
            else DoorIsOpen = true;
        }
        public void CloseDoor()
        {
            if (DoorIsOpen == true)
            {
                DoorIsOpen = false;
            }
            else DoorIsOpen = false;
        }

        public void GoUp(int desiredFloor)
        {
            if (DoorIsOpen == false && desiredFloor <= NumberOfLevels && desiredFloor > CurrentLevel)
            {
                CurrentLevel = desiredFloor;
            }
            else CurrentLevel = CurrentLevel;
        }
        public void GoDown(int desiredFloor)
        {
            if (DoorIsOpen == false && desiredFloor <= NumberOfLevels && desiredFloor < CurrentLevel && desiredFloor > 0)
            {
                CurrentLevel = desiredFloor;
            }
            else CurrentLevel = CurrentLevel;
        }
    }
}
