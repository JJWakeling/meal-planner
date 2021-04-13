using meal_planner.Units;

namespace meal_planner.Quantities
{
    public abstract class IBaseQuantity : IQuantity
    {
        public abstract double Number();
        public abstract IUnit Unit();
    }
}
