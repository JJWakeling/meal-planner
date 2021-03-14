using meal_planner.Ingredients;
using meal_planner.Meals;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meal_planner.ShoppingLists
{
    public class ShoppingList : IShoppingList
    {
        private readonly IMeal[] _meals;

        public ShoppingList(IMeal[] meals)
        {
            _meals = meals;
        }

        //TODO: make this more OO, less procedural
        protected override string Representation()
        {
            var ingredients = new List<IIngredient>();
            foreach (var meal in _meals)
            {
                foreach (var ingredient in meal.Recipe().Ingredients())
                {
                    if (ingredients.Any(i => i.Name() == ingredient.Name()))
                    {
                        var previous = ingredients.First(i => i.Name() == ingredient.Name());
                        ingredients.Remove(previous);
                        ingredients.Add(
                            new LiteralIngredient(
                                ingredient.Name(),
                                ingredient.Quantity().Sum(previous.Quantity())
                            )
                        );
                    }
                }
            }

            return new StringBuilder()
                .AppendJoin(
                    "\n",
                    ingredients.Select(i => $"{i.Name()} \t{i.Quantity()}")
                )
                .ToString();
        }
    }
}
