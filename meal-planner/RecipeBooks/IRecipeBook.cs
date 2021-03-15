using meal_planner.Recipes;
using System.Collections.Generic;

namespace meal_planner.RecipeBooks
{
    public interface IRecipeBook
    {
        IRecipeBook Composition(IRecipeBook other);
        IEnumerable<IRecipe> Recipes();
    }
}
