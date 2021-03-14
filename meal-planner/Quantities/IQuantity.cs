using meal_planner.Units;
using System.Collections.Generic;

namespace meal_planner.Quantities
{
    public abstract class IQuantity
    {
        protected abstract string Representation();
        public abstract IQuantity Sum(
            IReadOnlyDictionary<IUnit, double> addends,
            int unspecifieds
        );
        public abstract IQuantity Sum(IQuantity addend);
        public abstract IQuantity Product(double multiplier);

        public override string ToString()
        {
            return Representation();
        }
    }
}
