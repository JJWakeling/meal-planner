using meal_planner.Recipes;
using System.Collections.Generic;

namespace meal_planner.RecipeBooks
{
    public interface IRecipeBook
    {
        IEnumerable<IRecipe> Recipes();
    }
}
