using System.Collections.Generic;

namespace meal_planner
{
    public interface IRecipeBook
    {
        IEnumerable<IRecipe> Recipes();
    }
}
