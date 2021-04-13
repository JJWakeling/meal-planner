using Json;
using meal_planner.Quantities;
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

        public IMixedQuantity Quantity()
        {
            return _json.TryGetProperty("quantity", out var quantity)
                ? new JsonQuantityFactory(quantity).Quantity()
                : new MixedQuantity(new IBaseQuantity[0], 1);
        }
    }
}
