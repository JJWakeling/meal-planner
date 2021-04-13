using meal_planner.Ingredients;
using System.Collections.Generic;

namespace meal_planner.Recipes
{
    public interface IRecipe : IParsedJson
    {
        string Name();
        IEnumerable<IIngredient> Ingredients();
    }
}
