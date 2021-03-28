using Json;
using meal_planner.Recipes;
using System.Collections.Generic;
using System.Linq;

namespace meal_planner.RecipeBooks
{
    public class LiteralRecipeBook : IRecipeBook
    {
        private readonly IEnumerable<IRecipe> _recipes;

        public LiteralRecipeBook(IEnumerable<IRecipe> recipes)
        {
            _recipes = recipes;
        }

        public IRecipeBook Composition(IRecipeBook other)
        {
            return new LiteralRecipeBook(
                _recipes.Concat(other.Recipes())
            );
        }

        public IJson Json()
        {
            return new JsonArray(
                _recipes.Select(r => r.Json())
            );
        }

        public IEnumerable<IRecipe> Recipes()
        {
            return _recipes;
        }
    }
}
