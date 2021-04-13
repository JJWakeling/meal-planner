using Json;
using meal_planner.Units;
using System.Collections.Generic;

namespace meal_planner.Quantities
{
    public abstract class IQuantity : IParsedJson
    {
        protected abstract string Representation();
        public override string ToString()
        {
            return Representation();
        }
        public abstract IJson Json();
    }
}
