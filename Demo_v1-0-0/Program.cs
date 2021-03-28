using meal_planner.RecipeBooks;
using meal_planner.Recipes;
using meal_planner.Ui;
using System;

namespace Demo_v1_0_0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var recipeBook = new LiteralRecipeBook(
                new IRecipe[]
                {
                    new ConsoleRecipeFactory().Recipe()
                }
            );

            Console.WriteLine($"\n\nJson serialisation of recipe:\n{recipeBook.Json()}\n\nPress any key to quit");
            Console.ReadKey();
        }
    }
}
