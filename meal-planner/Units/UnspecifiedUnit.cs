namespace meal_planner.Units
{
    //TODO: check if this class is still required now unspecified units are dealt with in the quantities themselves
    // if not still required, delete this class
    internal class UnspecifiedUnit : IUnit
    {
        public override string Symbol()
        {
            return "UNSPECIFIED UNITS";
        }

        protected override bool EqualsImplementation(IUnit other)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
