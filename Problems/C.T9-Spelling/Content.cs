namespace Problems.C
{
    public class Content<T> : IContent<T>
    {
        private readonly T _value;

        public Content(T value)
        {
            _value = value;
        }
        public T Value()
        {
            return _value;
        }
    }
}
