using meal_planner.Quantities;

namespace meal_planner.Ingredients
{
    public interface IIngredient : IParsedJson
    {
        string Name();
        IMixedQuantity Quantity();
    }
}
