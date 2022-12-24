using System;


namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender.
    /// </summary>
    
    [Serializable]
    
    public class Gender
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create a new gender.
        /// </summary>
        /// <param name="name">Name of gender</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of gender can`t be empty or null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
