using meal_planner.Ui;
using System;

namespace Demo_v0_3_2
{
    internal class Program
    {
        static void Main()
        {
            var recipe = new ConsoleRecipeFactory()
                .Recipe();

            Console.WriteLine($"{recipe.Name()}:");
            foreach (var ingredient in recipe.Ingredients())
            {
                Console.WriteLine($"{ingredient.Name()} {ingredient.Quantity()}");
            }

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
