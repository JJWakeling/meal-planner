using meal_planner.Units;
using System.Text.Json;

namespace meal_planner.Quantities
{
    internal class JsonQuantity : IQuantity
    {
        private readonly JsonElement _json;

        public JsonQuantity(JsonElement json)
        {
            _json = json;
        }

        protected override string Representation()
        {
            return _json
                .GetProperty("number")
                .GetDouble()
                .ToString()
                +
                new LiteralUnit(
                    _json
                    .GetProperty("unit")
                    .GetString()
                )
                .Symbol();
        }
    }
}
