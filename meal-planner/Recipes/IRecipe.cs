using Json;
using meal_planner.Ingredients;
using System.Collections.Generic;

namespace meal_planner.Recipes
{
    public interface IRecipe
    {
        string Name();
        IEnumerable<IIngredient> Ingredients();
        IJson Json();
    }
}
