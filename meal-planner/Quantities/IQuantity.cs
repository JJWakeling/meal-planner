namespace meal_planner.Quantities
{
    public abstract class IQuantity
    {
        protected abstract string Representation();

        public override string ToString()
        {
            return Representation();
        }
    }
}
