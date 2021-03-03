using meal_planner.Quantities;

namespace meal_planner.Ingredients
{
    public interface IIngredient
    {
        string Name();
        IQuantity Quantity();
    }
}
