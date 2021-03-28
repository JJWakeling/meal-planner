namespace Json
{
    public class RawJson : IJson
    {
        private readonly string _json;

        public RawJson(string json)
        {
            _json = json;
        }

        protected override string Text()
        {
            return _json;
        }
    }
}
