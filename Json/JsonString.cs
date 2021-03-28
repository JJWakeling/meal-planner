namespace Json
{
    public class JsonString : IJson
    {
        private readonly string _value;

        public JsonString(string value)
        {
            _value = value;
        }

        protected override string Text()
        {
            return $"\"{_value}\"";
        }
    }
}
