using Fitness.BL.Controller;
using System;

namespace Fitness.cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to FitnessApp");

            Console.WriteLine("Input your username");
            var name = Console.ReadLine();

            Console.WriteLine("Input your gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Input date of your birth");
            var bDay = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Input your weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Input your height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, bDay, weight, height);

            userController.Save();
        }
    }
}
