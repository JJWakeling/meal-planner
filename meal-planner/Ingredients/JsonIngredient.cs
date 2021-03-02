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

        public string Name()
        {
            return _json
                .GetProperty("name")
                .GetString();
        }
    }
}
