using meal_planner.Recipes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace meal_planner.RecipeBooks
{
    public class JsonStreamRecipeBook : IRecipeBook
    {
        private readonly TextReader _source;

        public JsonStreamRecipeBook(TextReader source)
        {
            _source = source;
        }

        public IEnumerable<IRecipe> Recipes()
        {
            return JsonDocument
                .Parse(_source.ReadToEnd())
                .RootElement
                .EnumerateArray()
                .Select(j => new JsonRecipe(j));
        }
    }
}
