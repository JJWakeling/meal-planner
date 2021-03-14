using meal_planner.Recipes;

namespace meal_planner.Meals
{
    public class LiteralMeal : IMeal
    {
        private readonly IRecipe _recipe;
        private readonly double _servings;

        public LiteralMeal(IRecipe recipe, double servings)
        {
            _recipe = recipe;
            _servings = servings;
        }

        public IRecipe Recipe()
        {
            return _recipe;
        }

        public double Servings()
        {
            return _servings;
        }
    }
}
