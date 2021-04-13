using meal_planner.Ingredients;
using meal_planner.Meals;
using meal_planner.Quantities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meal_planner.ShoppingLists
{
    public class ShoppingList : IShoppingList
    {
        private readonly IEnumerable<IMeal> _meals;

        public ShoppingList(IEnumerable<IMeal> meals)
        {
            _meals = meals;
        }

        //TODO: extract some of the responsibilities of this method
        protected override string Representation()
        {
            var ingredients = new IngredientTotals(
                _meals.
                    SelectMany(m =>
                        m
                            .Recipe()
                            .Ingredients()
                            .Select(i =>
                                new LiteralIngredient(
                                    i.Name(),
                                    new MixedQuantity(i.Quantity(), m.Servings())
                                )
                            )
                    )
            )
                .Totals();

            var quantityIndentation = ingredients
                .Max(i => i.Name().Length)
                + 1;

            return new StringBuilder()
                .AppendJoin(
                    "\n",
                    ingredients.Select(i => new ShoppingListLine(i, quantityIndentation).ToString())
                )
                .ToString();
        }
    }
}
