namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingable
    {
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        private string sound;
        /// <summary>
        /// The farm animal's sound. Need to make sure the animal is awake first. 
        /// </summary>
        public virtual string Sound
        {
            get
            {
                if (IsAsleep)
                {
                    return "Zzz...";
                }
                return sound;
            }
            set
            {
                sound = value;
            }
        }
        public bool IsAsleep { get; private set; }

                /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        /// <param name="sound">The sound that the animal makes.</param>
        public FarmAnimal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }
        // making the animal take a nap
        public void Sleep(bool isAsleep)
        {
            IsAsleep = isAsleep;
        }

        //make the animal eat

        public abstract string Eat(); // no logic for abstract methods. MUST be implemented in child classes. 
        
    }
}
