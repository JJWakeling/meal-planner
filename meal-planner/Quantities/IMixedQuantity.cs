using System.Collections.Generic;

namespace meal_planner.Quantities
{
    public abstract class IMixedQuantity : IQuantity
    {
        public abstract IEnumerable<IBaseQuantity> Components();
        public abstract int Unspecifieds();
    }
}
