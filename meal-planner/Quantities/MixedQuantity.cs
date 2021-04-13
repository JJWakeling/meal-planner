using Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meal_planner.Quantities
{
    public class MixedQuantity : IMixedQuantity
    {
        private readonly IEnumerable<IBaseQuantity> _components;
        private readonly int _unspecifieds;

        #region ctors
        public MixedQuantity(IEnumerable<IBaseQuantity> components, int unspecifieds)
        {
            _components = components;
            _unspecifieds = unspecifieds;
        }

        public MixedQuantity(IEnumerable<IMixedQuantity> components)
            : this(
                  components.SelectMany(c => c.Components()),
                  components.Sum(c => c.Unspecifieds())
              )
        {
        }

        public MixedQuantity(IMixedQuantity multiplicand, double multiplier)
            : this(
                  multiplicand
                      .Components()
                      .Select(q => new LiteralBaseQuantity(q.Number() * multiplier, q.Unit())),
                  multiplicand.Unspecifieds()
              )
        {
        }

        #endregion

        //TODO: test that this compares IUnits appropriately
        public override IEnumerable<IBaseQuantity> Components()
        {
            return _components
                .GroupBy(c => c.Unit())
                .Select(g =>
                    new LiteralBaseQuantity(
                        g.Sum(q => q.Number()),
                        g.Key
                    )
                );
        }

        public override IJson Json()
        {
            return new JsonObject()
                .WithProperty("unspecifieds", new JsonDouble(_unspecifieds))
                .WithProperty(
                    "components",
                    new JsonArray(_components.Select(c => c.Json()))
                );
        }

        public override int Unspecifieds()
        {
            return _unspecifieds;
        }

        protected override string Representation()
        {
            return new StringBuilder()
                .AppendJoin(" + ", _components.Select(q => q.ToString()))
                .Append(
                    _unspecifieds > 0
                    ? $" + {_unspecifieds} * unspecified"
                    : ""
                )
                .ToString();
        }
    }
}
