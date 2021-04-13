using meal_planner.Quantities;
using System.Collections.Generic;
using System.Linq;

namespace meal_planner.Ingredients
{
    internal class IngredientTotals : IIngredientTotals
    {
        private readonly IEnumerable<IIngredient> _components;

        public IngredientTotals(IEnumerable<IIngredient> components)
        {
            _components = components;
        }

        //TODO: extract some of this nesting
        public IEnumerable<IIngredient> Totals()
        {
            return _components
                .Aggregate(
                    (IEnumerable<IIngredient>) new List<IIngredient>(),
                    (totals, next) =>
                        totals.Any(i => i.Name() == next.Name())
                        ? totals
                            .Where(i => i.Name() != next.Name())
                            .Append(
                                new LiteralIngredient(
                                    next.Name(),
                                    new MixedQuantity(
                                        new IMixedQuantity[]
                                        {
                                            next.Quantity(),
                                            totals
                                                .First(i => i.Name() == next.Name())
                                                .Quantity()
                                        }
                                    )
                                )
                            )
                    : totals.Append(next)
                );
        }
    }
}
