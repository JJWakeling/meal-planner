using Json;
using meal_planner.Ingredients;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace meal_planner.Recipes
{
    internal class JsonRecipe : IRecipe
    {
        private readonly JsonElement _json;

        public JsonRecipe(JsonElement json)
        {
            _json = json;
        }

        public string Name()
        {
            return _json
                .GetProperty("name")
                .GetString();
        }

        public IEnumerable<IIngredient> Ingredients()
        {
            return _json
                .GetProperty("ingredients")
                .EnumerateArray()
                .Select(j => new JsonIngredient(j));
        }

        public IJson Json()
        {
            return new RawJson(
                _json.GetRawText()
            );
        }
    }
}
