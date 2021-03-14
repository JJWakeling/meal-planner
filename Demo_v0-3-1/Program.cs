using meal_planner.Meals;
using meal_planner.RecipeBooks;
using meal_planner.ShoppingLists;
using System;
using System.IO;
using System.Linq;

namespace Demo_v0_3_1
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

            Console.WriteLine(
                new ShoppingList(
                    recipeBook
                        .Recipes()
                        .Select(r =>
                            new LiteralMeal(r, 1)
                        )
                )
                .ToString()
            );

            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
