using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            var culture = CultureInfo.CreateSpecificCulture("uk-UA");
            var resourceManager = new ResourceManager("Fitness.cmd.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("WelcomeMsg", culture));

            Console.WriteLine(resourceManager.GetString("InputUserName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("InputGender", culture));
                var genderName = Console.ReadLine();

                var birthDate = ParseBirthDay();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(genderName, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E - enter eating");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Input product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("callories count");
            var proteins = ParseDouble("proteins count");
            var fats = ParseDouble("fats count");
            var carbs = ParseDouble("carbonhydrates cont");
            var weigth = ParseDouble("portion weight");

            var product = new Food(food, calories, proteins, fats, carbs);

            return (Food: product, Weight: weigth);
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Input {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"False {name} format");
                }
            }
        }

        private static DateTime ParseBirthDay()
        {
            while (true)
            {
                Console.WriteLine("Input date of your birth (dd.MM.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), CultureInfo.GetCultureInfo("uk-UA"),
                                      DateTimeStyles.None, out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("False birth day format");
                }
            }
        }
    }
}
