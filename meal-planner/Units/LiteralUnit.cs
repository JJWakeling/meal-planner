namespace meal_planner.Units
{
    internal class LiteralUnit : IUnit
    {
        private readonly string _symbol;

        public LiteralUnit(string symbol)
        {
            _symbol = symbol;
        }

        public override string Symbol()
        {
            return _symbol;
        }

        protected override bool EqualsImplementation(IUnit other)
        {
            return other.Symbol() == _symbol;
        }
    }
}
