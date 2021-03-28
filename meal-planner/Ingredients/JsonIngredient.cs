using Json;
using meal_planner.Quantities;
using meal_planner.Units;
using System.Collections.Generic;
using System.Text.Json;

namespace meal_planner.Ingredients
{
    internal class JsonIngredient : IIngredient
    {
        private readonly JsonElement _json;

        public JsonIngredient(JsonElement json)
        {
            _json = json;
        }

        public IJson Json()
        {
            return new RawJson(_json.GetRawText());
        }

        public string Name()
        {
            return _json
                .GetProperty("name")
                .GetString();
        }

        //TODO: URGENT: fix this to read in new form of quantity as of specification v1-0-0
        public IQuantity Quantity()
        {
            return _json.TryGetProperty("quantity", out var quantity)
                ? new JsonQuantityFactory(quantity).Quantity()
                : new MixedQuantity(new Dictionary<IUnit, double>(), 1);
        }
    }
}
