using meal_planner.Ingredients;
using System;

namespace meal_planner.ShoppingLists
{
    internal class ShoppingListLine : IShoppingListLine
    {
        private readonly IIngredient _ingredient;
        private readonly int _quantityIndentation;

        public ShoppingListLine(IIngredient ingredient, int quantityIndentation)
        {
            _ingredient = ingredient;
            _quantityIndentation = quantityIndentation;
        }

        protected override string Representation()
        {
            if (_quantityIndentation <= _ingredient.Name().Length)
            {
                throw new Exception(
                    $"Cannot print quantity at indentation {_quantityIndentation} if ingredient is {_ingredient.Name().Length} characters long"
                );
            }

            return $"{_ingredient.Name().PadRight(_quantityIndentation)}{_ingredient.Quantity()}";
        }
    }
}
