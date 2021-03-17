namespace meal_planner.ShoppingLists
{
    public abstract class IShoppingListLine
    {
        protected abstract string Representation();

        public override string ToString()
        {
            return Representation();
        }
    }
}
