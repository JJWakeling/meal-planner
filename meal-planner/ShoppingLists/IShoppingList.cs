namespace meal_planner.ShoppingLists
{
    public abstract class IShoppingList
    {
        protected abstract string Representation();

        public override string ToString()
        {
            return Representation();
        }
    }
}
