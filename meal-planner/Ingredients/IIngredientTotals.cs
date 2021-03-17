using System.Collections.Generic;

namespace meal_planner.Ingredients
{
    public interface IIngredientTotals
    {
        public IEnumerable<IIngredient> Totals();
    }
}
