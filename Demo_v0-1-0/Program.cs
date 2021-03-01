using meal_planner;
using System;
using System.IO;

namespace Demo_v0_1_0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRecipeBook recipeBook = new JsonStreamRecipeBook(
                new StreamReader(
                    new FileStream(args[0], FileMode.Open)
                    )
                );

            Console.WriteLine("Recipes:");
            foreach (var recipe in recipeBook.Recipes())
            {
                Console.WriteLine(recipe.Name());
            }

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
