namespace Exercises.Classes
{
    public class Television
    {
        public bool IsOn { get; private set; } = false;
        public int CurrentChannel { get; private set; } = 3;
        public int CurrentVolume { get; private set; } = 2;


        public void TurnOff()
        {
            this.IsOn = false;
        }
        public void TurnOn()
        {
            this.IsOn = true;
        }
        public void ChangeChannel(int newChannel)
        {
            if(IsOn == true)
            {
                if (newChannel >= 3 && newChannel <= 18)
                {
                    this.CurrentChannel = newChannel;
                }
                else
                {
                    this.CurrentChannel = CurrentChannel;
                }
            }
           
        }
        public void ChannelUp()
        {
            if (IsOn == true)
            {
                if(CurrentChannel == 18)
                {
                    this.CurrentChannel = 3;
                }
                else
                {
                    this.CurrentChannel++;
                }
            }
        }
        public void ChannelDown()
        {
            if (IsOn == true)
            {
                if(CurrentChannel == 3)
                {
                    this.CurrentChannel = 18;
                }
                else
                {
                    this.CurrentChannel--;
                }
            }
        }
        public void RaiseVolume()
        {
            if(IsOn == true)
            {
                if (CurrentVolume >= 10)
                {
                    this.CurrentVolume = CurrentVolume;
                }
                else if (CurrentVolume < 10 && CurrentVolume >= 0)
                {
                    this.CurrentVolume++;
                }
            }
            
        }
        public void LowerVolume()
        {
            if (IsOn == true)
            {
                if (CurrentVolume == 0)
                {
                    this.CurrentVolume = CurrentVolume;
                }
                else if (CurrentVolume > 0)
                {
                    this.CurrentVolume--;
                }
            }
           
        }
    }
}
