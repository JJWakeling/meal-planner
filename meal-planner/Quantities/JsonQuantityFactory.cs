using meal_planner.Units;
using System.Linq;
using System.Text.Json;

namespace meal_planner.Quantities
{
    internal class JsonQuantityFactory : IQuantityFactory
    {
        private readonly JsonElement _json;

        public JsonQuantityFactory(JsonElement json)
        {
            _json = json;
        }

        public IMixedQuantity Quantity()
        {
            return new MixedQuantity(
                _json
                    .GetProperty("components")
                    .EnumerateArray()
                    .Select(c =>
                        new LiteralBaseQuantity(
                            c.GetProperty("number").GetDouble(),
                            new LiteralUnit(c.GetProperty("unit").GetString())
                        )
                    ),
                _json.GetProperty("unspecifieds").GetInt32()
            );
        }
    }
}
