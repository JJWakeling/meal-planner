using meal_planner.Ingredients;
using System.Collections.Generic;

namespace meal_planner.Recipes
{
    public class LiteralRecipe : IRecipe
    {
        private readonly string _name;
        private IEnumerable<IIngredient> _ingredients;

        public LiteralRecipe(string name, IEnumerable<IIngredient> ingredients)
        {
            _name = name;
            _ingredients = ingredients;
        }

        public IEnumerable<IIngredient> Ingredients()
        {
            return _ingredients;
        }

        public string Name()
        {
            return _name;
        }
    }
}
