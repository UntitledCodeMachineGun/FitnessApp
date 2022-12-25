using Fitness.BL.Controller;
using System;
using System.Globalization;

namespace Fitness.cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to FitnessApp");

            Console.WriteLine("Input your username");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Input your gender");
                var genderName = Console.ReadLine();

                var birthDate = ParseBirthDay();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(genderName, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.ReadLine();
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
