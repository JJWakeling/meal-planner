using Json;
using meal_planner.Quantities;

namespace meal_planner.Ingredients
{
    internal class LiteralIngredient : IIngredient
    {
        private readonly string _name;
        private readonly IMixedQuantity _quantity;

        public LiteralIngredient(string name, IMixedQuantity quantity)
        {
            _name = name;
            _quantity = quantity;
        }

        public IJson Json()
        {
            return new JsonObject()
                .WithProperty("name", new JsonString(_name))
                .WithProperty("quantity", _quantity.Json());
        }

        public string Name()
        {
            return _name;
        }

        public IMixedQuantity Quantity()
        {
            return _quantity;
        }
    }
}
