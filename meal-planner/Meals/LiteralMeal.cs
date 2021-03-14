using meal_planner.Recipes;

namespace meal_planner.Meals
{
    internal class LiteralMeal : IMeal
    {
        private readonly IRecipe _recipe;
        private readonly int _servings;

        public LiteralMeal(IRecipe recipe, int servings)
        {
            _recipe = recipe;
            _servings = servings;
        }

        public IRecipe Recipe()
        {
            return _recipe;
        }

        public int Servings()
        {
            return _servings;
        }
    }
}
