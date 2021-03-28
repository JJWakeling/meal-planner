namespace Json
{
    public class JsonDouble : IJson
    {
        private readonly double _value;

        public JsonDouble(double value)
        {
            _value = value;
        }

        protected override string Text()
        {
            return _value.ToString();
        }
    }
}
