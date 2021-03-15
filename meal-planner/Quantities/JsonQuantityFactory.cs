using meal_planner.Units;
using System.Collections.Generic;
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
                new Dictionary<IUnit, double>
                {
                    {
                        new LiteralUnit(
                            _json.GetProperty("unit").GetString()
                        ),
                        _json.GetProperty("number").GetDouble()
                    }
                },
                0
            );
        }
    }
}
