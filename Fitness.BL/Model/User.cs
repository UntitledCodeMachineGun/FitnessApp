﻿using System;


namespace Fitness.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
     
    [Serializable]

    public class User
    {
        #region properties

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Date of user`s birth
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// User`s weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Uset`s height
        /// </summary>
        public double Height { get; set; }

        #endregion

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
                throw new ArgumentNullException("Wrong date of birth.", nameof(birthDate));
            }

            if (weight <= 0)
            { 
                throw new ArgumentNullException("Wrong weight.", nameof(weight));
            }

            if (height <= 0)
            { 
                throw new ArgumentNullException("Wrong height.", nameof(height));
            }

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
