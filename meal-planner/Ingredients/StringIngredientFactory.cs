using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using meal_planner.Units;
using meal_planner.Quantities;

namespace meal_planner.Ingredients
{
    public class StringIngredientFactory : IIngredientFactory
    {
        private readonly string _source;

        public StringIngredientFactory(string source)
        {
            _source = source.Trim();
        }

        //TODO: reduce complexity
        public IIngredient Ingredient()
        {
            var regex = new Regex(@"^(\D+)\s(\d+\.?\d*|.\d+)(\w*)$");

            if (!regex.IsMatch(_source))
            {
                return new LiteralIngredient(
                    _source,
                    new MixedQuantity(new Dictionary<IUnit, double>(), 1)
                );
            }

            var captures = 
                (
                    (IEnumerable<Group>)
                    regex
                    .Match(_source)
                    .Groups
                )
                .Select(g => g.Captures[0].Value)
                .ToList();

            return new LiteralIngredient(
                captures[1],
                new MixedQuantity(
                    new Dictionary<IUnit, double>()
                    {
                        {
                            new LiteralUnit(captures[3]),
                            double.Parse(captures[2])
                        }
                    },
                    0
                )
            );
        }
    }
}
