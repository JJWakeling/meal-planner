using meal_planner.Ingredients;
using meal_planner.Meals;
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

        //TODO: make this more OO, less procedural
        //TODO: print all quantities at same tabulation
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
                                ingredient
                                    .Quantity()
                                    .Product(meal.Servings())
                                    .Sum(previous.Quantity())
                            )
                        );
                    }
                    else
                    {
                        ingredients.Add(
                            new LiteralIngredient(
                                ingredient.Name(),
                                ingredient
                                    .Quantity()
                                    .Product(meal.Servings())
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
