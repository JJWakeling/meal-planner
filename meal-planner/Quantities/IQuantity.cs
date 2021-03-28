using Json;
using meal_planner.Units;
using System.Collections.Generic;

namespace meal_planner.Quantities
{
    //TODO: (worth doing soon) try removing some responsibilities from this interface; it has 4 methods (ignoring overloading)
    // probably best to split into an ICompoundQuantity and IBaseQuantity{double number, IUnit unit} that exposes both number and unit, but that will require some thought
    // you probably made this more difficult than it needed to be by trying to resist treating objects like data bags too much
    // even Bugayenkoism has its limits
    // on the other hand, maybe you wouldn't have figured out the exact way you needed to split the interfaces without going down this path, who knows?
    public abstract class IQuantity
    {
        protected abstract string Representation();
        public abstract IQuantity Sum(
            IReadOnlyDictionary<IUnit, double> addends,
            int unspecifieds
        );
        public abstract IQuantity Sum(IQuantity addend);
        public abstract IQuantity Product(double multiplier);
        public abstract IJson Json();

        public override string ToString()
        {
            return Representation();
        }
    }
}
