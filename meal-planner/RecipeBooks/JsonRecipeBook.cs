using Json;
using meal_planner.Recipes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace meal_planner.RecipeBooks
{
    public class JsonRecipeBook : IRecipeBook
    {
        private readonly JsonElement _json;

        public JsonRecipeBook(JsonElement json)
        {
            _json = json;
        }

        //TODO: find out why 'doing work' in ctors is frowned upon
        // and if convinced, refactor this burden onto the client code
        public JsonRecipeBook(TextReader source)
            : this(JsonDocument.Parse(source.ReadToEnd()).RootElement)
        {
        }

        public IRecipeBook Composition(IRecipeBook other)
        {
            return new LiteralRecipeBook(
                Recipes()
                .Concat(other.Recipes())
            );
        }

        public IJson Json()
        {
            return new RawJson(
                _json.GetRawText()
            );
        }

        public IEnumerable<IRecipe> Recipes()
        {
            return _json
                .EnumerateArray()
                .Select(j => new JsonRecipe(j));
        }
    }
}
