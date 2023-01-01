using System;


namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Proteins
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fats
        /// </summary>
        public double Fats { get; }
        public double Carbonhydrates { get; }

        /// <summary>
        /// Carbohydrates
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Calories / 100 grammes of product
        /// </summary>
        public double Calories { get; }

        private double CaloriesOneGramm { get { return Calories / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbonhydrates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbonhydrates = carbonhydrates / 100.0;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
