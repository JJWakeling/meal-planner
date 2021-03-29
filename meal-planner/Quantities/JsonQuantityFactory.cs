using meal_planner.Units;
using System.Collections.Generic;
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

        public IQuantity Quantity()
        {
            return new MixedQuantity(
                new Dictionary<IUnit, double>(
                    _json
                        .GetProperty("components")
                        .EnumerateArray()
                        .Select(c =>
                            new KeyValuePair<IUnit, double> (
                                new LiteralUnit(c.GetProperty("unit").GetString()),
                                c.GetProperty("number").GetDouble()
                            )
                        )
                ),
                _json.GetProperty("unspecifieds").GetInt32()
            );
        }
    }
}
