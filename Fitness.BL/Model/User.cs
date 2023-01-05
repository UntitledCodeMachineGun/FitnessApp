using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
     
    [Serializable]

    public class User
    {

        #region properties

        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        public int? GenderId { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Date of user`s birth
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// User`s weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Uset`s height
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// User`s age
        /// </summary>
        public int Age { 
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.AddYears(age) > today)
                {
                    age--;
                }

                return age;
            } 
        }
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        #endregion

        public User() { }


        /// <summary>
        /// Crate new user
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthDate">Date of birth.</param>
        /// <param name="weight">Weight<./param>
        /// <param name="height">Height.</param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Input check

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name can`t be null or whitespace.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can`t be null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentNullException("Wrong date of birth.", nameof(BirthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentNullException("Wrong weight.", nameof(Weight));
            }
            Weight = weight;

            if (height <= 0)
            {
                throw new ArgumentNullException("Wrong height.", nameof(Height));
            }
            Height = height;

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username can`t be null or whitespace", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
