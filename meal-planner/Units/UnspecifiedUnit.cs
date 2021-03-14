namespace meal_planner.Units
{
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
