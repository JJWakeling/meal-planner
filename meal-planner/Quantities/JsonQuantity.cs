using meal_planner.Units;
using System.Collections.Generic;
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

        public override IQuantity Product(double multiplier)
        {
            var components = new Dictionary<IUnit, double>
            {
                { Unit(), Number() }
            };

            return new MixedQuantity(components, 0)
                .Product(multiplier);
        }

        public override IQuantity Sum(IQuantity addend)
        {
            var components = new Dictionary<IUnit, double>
            {
                { Unit(), Number() }
            };

            return new MixedQuantity(components, 0)
                .Sum(addend);
        }

        public override IQuantity Sum(
            IReadOnlyDictionary<IUnit, double> addends,
            int unspecifieds
        )
        {
            var components = new Dictionary<IUnit, double>
            {
                { Unit(), Number() }
            };

            return new MixedQuantity(components, 0)
                .Sum(addends, unspecifieds);
        }

        protected override string Representation()
        {
            return Number().ToString() + Unit().Symbol();
        }

        private double Number()
        {
            return _json.GetProperty("number").GetDouble();
        }

        private IUnit Unit()
        {
            return new LiteralUnit(
                _json.GetProperty("unit").GetString()
            );
        }
    }
}
