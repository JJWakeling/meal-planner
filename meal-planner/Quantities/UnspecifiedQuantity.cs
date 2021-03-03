namespace meal_planner.Quantities
{
    internal class UnspecifiedQuantity : IQuantity
    {
        protected override string Representation()
        {
            return "Unspecified Quantity";
        }
    }
}
