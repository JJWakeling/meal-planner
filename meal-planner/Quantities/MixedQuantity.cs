using meal_planner.Units;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meal_planner.Quantities
{
    internal class MixedQuantity : IQuantity
    {
        private readonly IReadOnlyDictionary<IUnit, double> _components;
        private readonly int _unspecifieds;

        public MixedQuantity(IReadOnlyDictionary<IUnit, double> components, int unspecifieds)
        {
            _components = components;
            _unspecifieds = unspecifieds;
        }

        //TODO: make some of these methods a little less verbose

        public override IQuantity Product(double multiplier)
        {
            var totals = new Dictionary<IUnit, double>();
            foreach (var unit in _components.Keys)
            {
                totals.Add(unit, _components[unit] * multiplier);
            }

            return new MixedQuantity(totals, _unspecifieds);
        }

        public override IQuantity Sum(IQuantity addend)
        {
            return addend.Sum(_components, _unspecifieds);
        }

        public override IQuantity Sum(
            IReadOnlyDictionary<IUnit, double> addends,
            int unspecifieds
        )
        {
            var units = _components
                .Keys
                .Union(addends.Keys);
            var totals = new Dictionary<IUnit, double>();
            foreach (var unit in units)
            {
                totals.Add(
                    unit,
                    (_components.ContainsKey(unit) ? _components[unit] : 0)
                    +
                    (addends.ContainsKey(unit) ? addends[unit] : 0)
                );
            }

            return new MixedQuantity(totals, _unspecifieds + unspecifieds);
        }

        protected override string Representation()
        {
            return new StringBuilder()
                .AppendJoin(
                    " + ",
                    _components
                        .Keys
                        //TODO: always display to 4sf
                        .Select(u => $"{_components[u]}{u.Symbol()}")
                    )
                .Append(
                    _unspecifieds > 0
                    ? $" + {_unspecifieds} * unspecified"
                    : ""
                )
                .ToString();
        }
    }
}
