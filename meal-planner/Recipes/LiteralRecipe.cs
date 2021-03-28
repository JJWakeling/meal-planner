using Json;
using meal_planner.Ingredients;
using System.Collections.Generic;
using System.Linq;

namespace meal_planner.Recipes
{
    public class LiteralRecipe : IRecipe
    {
        private readonly string _name;
        private readonly IEnumerable<IIngredient> _ingredients;

        public LiteralRecipe(string name, IEnumerable<IIngredient> ingredients)
        {
            _name = name;
            _ingredients = ingredients;
        }

        public IEnumerable<IIngredient> Ingredients()
        {
            return _ingredients;
        }

        public IJson Json()
        {
            return new JsonObject()
                .WithProperty("name", new JsonString(_name))
                .WithProperty(
                    "ingredients",
                    new JsonArray(_ingredients.Select(i => i.Json()))
                );
        }

        public string Name()
        {
            return _name;
        }
    }
}
