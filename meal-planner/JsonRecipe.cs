using System.Text.Json;

namespace meal_planner
{
    public class JsonRecipe : IRecipe
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
                .ToString();
        }
    }
}
