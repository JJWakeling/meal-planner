using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class JsonArray : IJson
    {
        private readonly IEnumerable<IJson> _values;

        public JsonArray(IEnumerable<IJson> values)
        {
            _values = values;
        }

        protected override string Text()
        {
            return new StringBuilder()
                .Append('[')
                .AppendJoin(", ", _values)
                .Append(']')
                .ToString();
        }
    }
}
