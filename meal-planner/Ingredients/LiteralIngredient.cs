using Json;
using meal_planner.Quantities;

namespace meal_planner.Ingredients
{
    internal class LiteralIngredient : IIngredient
    {
        private readonly string _name;
        private readonly IQuantity _quantity;

        public LiteralIngredient(string name, IQuantity quantity)
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

        public IQuantity Quantity()
        {
            return _quantity;
        }
    }
}
