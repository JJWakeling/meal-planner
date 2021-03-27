using meal_planner.Ingredients;
using meal_planner.Recipes;
using System;
using System.Collections.Generic;

namespace meal_planner.Ui
{
    public class ConsoleRecipeFactory : IRecipeFactory
    {
        //TODO: make this less procedural: maybe use recursion to avoid horrible "while (true)" construction
        public IRecipe Recipe()
        {
            Console.WriteLine("Recipe name:");
            var name = Console.ReadLine();

            var ingredients = new List<IIngredient>();
            while (true)
            {
                Console.WriteLine("Specify new ingredient or press return to finish");
                var response = Console.ReadLine();
                if (response == "")
                {
                    break;
                }
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
