namespace Kalendra.Commons.Runtime.Architecture.Patterns
{
    public interface IFactory<out T>
    {
        T Create();
    }

    public class GenericFactory<T> : IFactory<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }

    public interface IFactory<out T, in TArg>
    {
        T Create(TArg arg);
    }
}