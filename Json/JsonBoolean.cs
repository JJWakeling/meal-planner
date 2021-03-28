namespace Json
{
    public class JsonBoolean : IJson
    {
        private readonly bool _value;

        public JsonBoolean(bool value)
        {
            _value = value;
        }

        protected override string Text()
        {
            return _value ? "true" : "false";
        }
    }
}
