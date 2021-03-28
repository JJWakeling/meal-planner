namespace Json
{
    public abstract class IJson
    {
        protected abstract string Text();

        public override string ToString()
        {
            return Text();
        }
    }
}
