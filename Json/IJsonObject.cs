namespace Json
{
    public abstract class IJsonObject : IJson
    {
        public abstract IJsonObject WithProperty(string name, IJson value);
    }
}
