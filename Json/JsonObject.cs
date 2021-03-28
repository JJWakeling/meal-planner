using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    public class JsonObject : IJsonObject
    {
        private readonly IReadOnlyDictionary<string, IJson> _properties;

        //TODO: try to find literature on private ctors; not sure it's something I agree with
        private JsonObject(IReadOnlyDictionary<string, IJson> properties)
        {
            _properties = properties;
        }

        public JsonObject()
            : this(new Dictionary<string, IJson>())
        {
        }

        public override IJsonObject WithProperty(string name, IJson value)
        {
            var totalProperties = new Dictionary<string, IJson>(_properties);
            totalProperties.Add(name, value);

            return new JsonObject(totalProperties);
        }

        protected override string Text()
        {
            return new StringBuilder()
                .Append('{')
                .AppendJoin(
                    ", ",
                    _properties
                        .Select(p => $"\"{p.Key}\": {p.Value}")
                )
                .Append('}')
                .ToString();
        }
    }
}
