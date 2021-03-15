using meal_planner.Ingredients;
using meal_planner.Recipes;
using System;
using System.Collections.Generic;

namespace meal_planner.Ui
{
    public class ConsoleRecipeFactory : IRecipeFactory
    {
        public IRecipe Recipe()
        {
            Console.WriteLine("Recipe name:");
            var name = Console.ReadLine();

            var ingredients = new List<IIngredient>();
            var response = " ";
            while (response != "")
            {
                Console.WriteLine("Specify new ingredient or press return to finish");
                response = Console.ReadLine();
                try
                {
                    ingredients.Add(
                        new StringIngredientFactory(response.Trim())
                            .Ingredient()
                    );
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            return new LiteralRecipe(name, ingredients);
        }
    }
}
