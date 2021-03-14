using meal_planner.Recipes;

namespace meal_planner.Meals
{
    // Represents the total amount of a recipe to be cooked
    public interface IMeal
    {
        IRecipe Recipe();
        int Servings();
    }
}
