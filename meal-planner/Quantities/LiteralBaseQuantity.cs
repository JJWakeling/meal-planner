using Json;
using meal_planner.Units;

namespace meal_planner.Quantities
{
    internal class LiteralBaseQuantity : IBaseQuantity
    {
        private readonly double _number;
        private readonly IUnit _unit;

        public LiteralBaseQuantity(double number, IUnit unit)
        {
            _number = number;
            _unit = unit;
        }

        public override IJson Json()
        {
            return new JsonObject()
                .WithProperty("number", new JsonDouble(_number))
                .WithProperty("unit", new JsonString(_unit.Symbol()));
        }

        public override double Number()
        {
            return _number;
        }

        public override IUnit Unit()
        {
            return _unit;
        }

        protected override string Representation()
        {
            //TODO: always display to 4sf
            return $"{_number}{_unit.Symbol()}";
        }
    }
}
